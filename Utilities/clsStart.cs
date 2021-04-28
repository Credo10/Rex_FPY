using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Data.Linq;
using Microsoft.Win32;
using System.Linq;
using HRLData;
using Encryption;
using RexrothData;
using Visual;

namespace FPY
{

    public class clsStart
    {





        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.DoEvents();

          

            string[] varApp = new string[6];

            //change made

            string strApp;
            string strUser = "";
            string strLNID = "";
            string strTSID = "";

            int intLNID;
            int intTSID;

            varApp = Environment.GetCommandLineArgs();

            if (varApp.Length == 1)
            {

                strApp = clsUtility.ConfigVal("APPID");
                strLNID = clsUtility.ConfigVal("LNID");
                strTSID = clsUtility.ConfigVal("TSID");
                try
                {
                    intLNID = Convert.ToInt32(strLNID);
                }
                catch (Exception ex)
                {

                    intLNID = 0;
                }

                try
                {
                    intTSID = Convert.ToInt32(strTSID);
                }
                catch (Exception ex)
                {

                    intTSID= 404;
                }
            }
            else
            {

                strApp = varApp[1].ToString().Trim();
                intLNID = Convert.ToInt32(varApp[2]);
                intTSID = Convert.ToInt32(varApp[3]);
                //intTSID = 404;

                try
                {
                    if (varApp[3].Length > 3)
                    {
                        strUser = varApp[3];
                    }
                }
                catch (Exception ex)
                {

                }
            }


            Int32 intAPPID = Convert.ToInt32(strApp);

            PostMain(intAPPID, intLNID, strUser, intTSID);


        }



        public static HRLEntities efdb()
        {
            HRLEntities tmp = new HRLEntities();
            tmp.Database.Connection.ConnectionString = clsDAL.GetCon("HRL");
            return tmp;
        }

        public static HRLEntities efdbReadOnly()
        {
            HRLEntities tmp = new HRLEntities();
            tmp.Database.Connection.ConnectionString = clsDAL.GetCon("HRL");
            tmp.Configuration.AutoDetectChangesEnabled = false;
            return tmp;
        }

        public static RexrothEntities efdbRexroth()
        {
            RexrothEntities tmp = new RexrothEntities();
            tmp.Database.Connection.ConnectionString = clsDAL.GetCon("Rexroth");
            tmp.Database.CommandTimeout = 120;          
            return tmp;
        }

        public static RexrothEntities efdbRexrothReadOnly()
        {
            RexrothEntities tmp = new RexrothEntities();
            tmp.Database.Connection.ConnectionString = clsDAL.GetCon("Rexroth");
            tmp.Database.CommandTimeout = 120;
            tmp.Configuration.AutoDetectChangesEnabled = false;
            return tmp;
        }


        public static VisualEntities efdbVisual()
        {
            VisualEntities tmp = new VisualEntities();
            tmp.Database.Connection.ConnectionString = clsDAL.GetCon("Visual");
            tmp.Database.CommandTimeout = 120;

            return tmp;
        }

        public static VisualEntities efdbVisualReadOnly()
        {
            VisualEntities tmp = new VisualEntities();
            tmp.Database.Connection.ConnectionString = clsDAL.GetCon("Visual");
            tmp.Database.CommandTimeout = 120;
            tmp.Configuration.AutoDetectChangesEnabled = false;
            return tmp;
        }

        public static void PostMain(Int32 intAPPID, Int32 intLNID, string strUser, int intTSID)
        {

            string strVer = "";
            string strAppBeta = "";
            string strDEV = clsUtility.ConfigVal("DEV");
            HRLEntities db = efdb();
            RexrothEntities dbRexroth = efdbRexroth();



            try
            {
                System.Security.Principal.WindowsPrincipal s = new System.Security.Principal.WindowsPrincipal(System.Security.Principal.WindowsIdentity.GetCurrent());

                if (strUser == "")
                {
                    strUser = s.Identity.Name;
                    strUser = strUser.Substring(strUser.IndexOf("\\") + 1);
                }

                //var list = db.tblBISystemUID.Where(w => w.BSU_Active == true && w.BSU_Deleted.HasValue == false).ToList();
                //var systemUIDs = list.Select(uid => uid.BSU_UID).ToList();



                if (strDEV == "1")
                {
                    string strDevUser = clsUtility.ConfigVal("UID");

                    if (strDevUser + "" != "")
                    {
                        strUser = strDevUser;

                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Credo");

            }

            try
            {


                //Verify the version
                var qryApp = (from ap in db.tblApp
                              where ap.APPID == intAPPID
                              select ap).FirstOrDefault();


                strVer = qryApp.APP_Version;

                Assembly assembly = Assembly.GetExecutingAssembly();
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);

                string strVer2 = fvi.FileVersion.ToString().Substring(0, strVer.Length).Trim();


                if (Debugger.IsAttached == false)
                {
                    if (strVer != strVer2)
                    {
                        MessageBox.Show("This App is version " + strVer2 + ", should be " + strVer + ". Be certain you are using the correct shortcut and re-open.", "Credo");
                        return;
                    }
                }


                intAPPID = Convert.ToInt16(qryApp.APP_BetaFor);

                if (intAPPID == 22 || intAPPID == 24)
                {
                    var appUserBIList = (from ap in db.vwAppView2
                                        where ap.APPID == 22 && ap.AB_Level == 2
                                        select ap.AS_User).ToList();

                    var appUserBIAdminList = (from ap in db.vwAppView2
                        where ap.APPID == 22 && ap.AB_Level > 2
                        select ap.AS_User).ToList();

                    var removeList = new List<string>();

                    foreach (var user in appUserBIList)
                    {
                        if (appUserBIAdminList.Contains(user))
                        {
                            removeList.Add(user);
                        }
                    }

                    foreach (var user in removeList)
                    {
                        appUserBIList.Remove(user);
                    }

                    
                }




                frmNavigate f = new frmNavigate();
                Boolean fOpen = false;

                //if navidation is already open, then close
                try
                {
                    frmNavigate frm = clsFormUtil.ReturnFormInst("frmNavigate");
                    if (frm.Name == "frmNavigate")
                    {
                        f = frm;
                        fOpen = true;
                    }
                }
                catch (Exception ex)
                {
                }


                f.WindowState = FormWindowState.Maximized;
                f.Text = qryApp.APP_Desc + "  Version " + strVer2;
                f.Token = strUser + "_" + DateTime.Now.ToLongTimeString();
                f.Parm1 = qryApp.APP_Color;
                f.AppName = qryApp.APP_Desc;
                f.LNID = intLNID;
                f.TSID = intTSID;
                f.Image = Convert.ToInt32(qryApp.APP_Image);
                try
                {
                    vwAssociate qry = (from ct in db.vwAssociate
                                       where ct.AS_User == strUser
                                       && ct.APPID == intAPPID
                                       orderby ct.AB_Level descending
                                       select ct).First();
                    f.Associate = qry;

                    //clsMail.SendPBRoleAssign(1901, 0, qry, true);
                }
                catch (Exception ex)
                {

                    //get default user
                    vwAssociate qry = (from ct in db.vwAssociate
                                       where ct.ASID == 1
                                        && ct.APPID == intAPPID
                                       orderby ct.AB_Level descending
                                       select ct).First();

                    try
                    {
                        //supplement the default user with this users info...
                        var qry2 = (from ct in dbRexroth.tblAssociate
                                    where ct.AS_User == strUser
                                    select ct).First();

                        qry.ASID = qry2.ASID;
                        qry.AS_Email = qry2.AS_Email;
                        qry.AS_First = qry2.AS_First;
                        qry.AS_Last = qry2.AS_Last;
                        qry.AS_User = qry2.AS_User;
                        qry.FullName = qry2.AS_Display;

                    }
                    catch (Exception ex2)
                    {

                    }



                    f.Associate = qry;
                    //}

                }
                //try
                //{
                //    var qry5 = (from ct in dbRexroth.tblAssociate
                //                where ct.AS_User == strUser
                //                select ct).First();
                //    f.RexAssoc = qry5;
                //}
                //catch (Exception ex4)
                //{
                //    //throw ex4;
                //}

                f.APPID = intAPPID;

                if (fOpen == false)
                {
                    Application.Run(f);
                }
                else
                {
                    f.SetButtons();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Credo");

            }
        }
    }
}
