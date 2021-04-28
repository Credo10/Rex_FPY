using System;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Data.Linq;
using System.Reflection;
using System.Data.OleDb;
using System.Diagnostics;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;
using HRLData;
using System.Windows.Forms;
using RexrothData;

namespace FPY
{

    public class clsAD
    {

        public static int AddUserByUID(string strUser, Int32 intAPPID)
        {

            Int32 intASID = 0;

            RexrothEntities db = clsStart.efdbRexroth();
            string strDomain = "";
            System.Data.Entity.Core.Objects.ObjectParameter pk = new System.Data.Entity.Core.Objects.ObjectParameter("PK", typeof(int));
            
            System.Data.Entity.Core.Objects.ObjectParameter error = new System.Data.Entity.Core.Objects.ObjectParameter("EMessage", typeof(string));
            Cursor.Current = Cursors.WaitCursor;

            var lstDomains = new string[] { "US", "DE", "MX" };

            if (!(UserExists(strUser)))
            {
                foreach (string strDom in lstDomains)
                    try
                    {

                        //var qry = (from ct in db.tblApp
                        //           where ct.APPID == intAPPID
                        //           select ct).FirstOrDefault();

                        PrincipalContext domainContext = new PrincipalContext(ContextType.Domain, strDom);
                       

                        UserPrincipal user = new UserPrincipal(domainContext);

                    //Specify the search parameters
                    user.Name = strUser;

                    PrincipalSearcher pS = new PrincipalSearcher();
                    pS.QueryFilter = user;
 
                    PrincipalSearchResult<Principal> results = pS.FindAll();
                    
 
                    //If necessary, request more details
                    //Principal pc = results.ToList()[0];
                    //DirectoryEntry de = (DirectoryEntry)pc.GetUnderlyingObject();

                    if (results.ToList().Count > 0)
                    {
                        
                        foreach (UserPrincipal usr in results)
                        {
                             
                           //tblAssociate tbl = new tblAssociate();

                            
                            
                           

                           //ObjectParameter name = new ObjectParameter("Name", typeof(String));
                            db.p_SaveChangesEF(usr.GivenName, usr.Surname, usr.SamAccountName, usr.EmailAddress.ToString(), usr.DisplayName, pk, error);

                            if (Convert.ToInt32(pk.Value) == 0)
                            {
                                MessageBox.Show(error.ToString());
                                
                            }

                            else
                            {
                                Cursor.Current = Cursors.Default;
                                MessageBox.Show(usr.DisplayName + " added!", "Credo");
                            }
                              

                            
                        }
                    }
                    else
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show(strUser + " not found.", "Credo");
                    }

                  
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(ex.Message, "Credo");
                }

            }
            else
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(strUser + " already exists.", "Credo");

            }
            Cursor.Current = Cursors.Default;
            
            intASID = Convert.ToInt32(pk.Value);
            return intASID;


        }

        public static bool UserExists(string strUser)
        {

            RexrothEntities db = clsStart.efdbRexroth();

            try
            {
                var qry = (from ct in db.tblAssociate
                           where ct.AS_User == strUser
                           select ct).First();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

    }

}
