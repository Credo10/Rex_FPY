using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Linq;
using LinqToExcel;
using System.Text;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using RexrothData;
using System.Windows.Forms;
using System.Reflection;
using System.DirectoryServices.AccountManagement;




namespace RexVOIS3
{
    public class clsSAP
    {


        #region "Process"

        [DllImport("kernel32.dll")]
        static extern bool CreateProcess(
          string lpApplicationName,
          string lpCommandLine,
          IntPtr lpProcessAttributes,
          IntPtr lpThreadAttributes,
          bool bInheritHandles,
          uint dwCreationFlags,
          IntPtr lpEnvironment,
          string lpCurrentDirectory,
          ref STARTUPINFO lpStartupInfo,
          out PROCESS_INFORMATION lpProcessInformation);


        public struct PROCESS_INFORMATION
        {
            public IntPtr hProcess;
            public IntPtr hThread;
            public uint dwProcessId;
            public uint dwThreadId;
        }
        public struct STARTUPINFO
        {
            public uint cb;
            public string lpReserved;
            public string lpDesktop;
            public string lpTitle;
            public uint dwX;
            public uint dwY;
            public uint dwXSize;
            public uint dwYSize;
            public uint dwXCountChars;
            public uint dwYCountChars;
            public uint dwFillAttribute;
            public uint dwFlags;
            public short wShowWindow;
            public short cbReserved2;
            public IntPtr lpReserved2;
            public IntPtr hStdInput;
            public IntPtr hStdOutput;
            public IntPtr hStdError;
        }


        private static PROCESS_INFORMATION StartProcess(vwSAPDetail q, string strCommand)
        {
            STARTUPINFO si = new STARTUPINFO();
            PROCESS_INFORMATION pi = new PROCESS_INFORMATION();


            //LogProgress(q, strCommand);

            try
            {

                CreateProcess(null, strCommand, IntPtr.Zero, IntPtr.Zero, false, 0, IntPtr.Zero, null, ref si, out pi);

            }
            catch (Exception ex)
            {
                LogProgress(ex.ToString());
            }

            return pi;
        }

        #endregion

        private static void wait(Int32 intWait)
        {
            Console.WriteLine("Waiting...." + intWait.ToString());
            System.Threading.Thread.Sleep(intWait);
        }

        private static void testConnection()
        {
            //SapROTWr.CSapROTWrapper sapROTWrapper = new SapROTWr.CSapROTWrapper();
            //object SapGuilRot = sapROTWrapper.GetROTEntry("SAPGUI");
            //object engine = SapGuilRot.GetType().InvokeMember("GetSCriptingEngine", System.Reflection.BindingFlags.InvokeMethod, null, SapGuilRot, null);
            //SAPconnection.sapGuiApp = engine as GuiApplication;
            //GuiConnection connection = sapGuiApp.Connections.ElementAt(0) as GuiConnection;
            //GuiSession session = connection.Children.ElementAt(0) as GuiSession;
            //MessageBox.Show(session.Info.User + " !!||!! " + session.Info.Transaction);


        }
        private static void kill(string strKill)
        {

            try
            {
                Process[] procs = Process.GetProcessesByName(strKill);

                foreach (Process proc in procs)
                    proc.Kill();
            }
            catch (Exception winException)
            {
                // process was terminating or can't be terminated - deal with it
            }

        }
        private static Boolean CreateLogon(vwSAPDetail q)
        {


            Boolean fRet = true;
            string strSAPSys = q.SY_Desc;
            string strSAPUser = q.SG_User;



            string strSAP = clsUtility.ConfigVal("SAPPath");
            string strArg = "";
            try
            {


                strArg = q.SY_Server + "  -user=" + q.SG_User + " -pw=" + Encryption.clsEncrypt.Decrypt(q.SG_PWD) +
                         " -system=" + q.SY_Desc + " -Client=" + q.SY_Client;



                ProcessStartInfo startInfo = new ProcessStartInfo(strSAP);
                startInfo.Arguments = strArg;
                Process proc = Process.Start(startInfo);
                proc.WaitForExit();
            }
            catch (Exception ex)
            {
                fRet = false;
                LogProgress(ex.Message);

            }

            return fRet;

        }
        public static void LogProgress(string strEX, [CallerMemberName] string callerName = "", int intSeverity = 0)
        {
            RexrothEntities db = new RexrothEntities();

            try
            {

                tblSAPDetailLog tbl = new tblSAPDetailLog();
                tbl.SAPL_Date = DateTime.Now;
                tbl.SAPTID = 0;
                tbl.SAPT_Message = strEX;
                tbl.SAPT_Severity = intSeverity;
                db.tblSAPDetailLog.Add(tbl);
                db.SaveChanges();

            }
            catch (Exception ex)
            {

            }

        }

        public static Boolean RunSAP(int intVPID, int intSJID, int intASID, string strParm1 = "", string strParm2 = "", string strParm3 = "", string strParm4 = "", string strParm5 = "", string strParm6 = "", string strParm7 = "", string strParm8 = "", string strParm9 = "", string strParm10 = "")
        {

            RexrothEntities db = clsStart.efdbRexroth();

            kill("saplgpad");
            kill("saplogon");
            kill("guixt");

            bool fRet = true;
            string command = "";
            string strScript = "";
            string args = "";
            string fullCommand = "";
            string strStartup = Path.GetTempPath().ToString();


            try
            {

                var lst = (from ct2 in db.vwSAPDetail
                           where ct2.SJID == intSJID
                           orderby ct2.SAPT_Sort
                           select ct2).ToList();

                foreach (var q in lst)
                {
                    command = q.SAPA_Path;
                    strScript = q.SAPT_Script;

                    strScript = strScript.Replace("&V[Parm1]", strParm1);
                    strScript = strScript.Replace("&V[Parm2]", strParm2);
                    strScript = strScript.Replace("&V[Parm3]", strParm3);
                    strScript = strScript.Replace("&V[Parm4]", strParm4);
                    strScript = strScript.Replace("&V[Parm5]", strParm5);
                    strScript = strScript.Replace("&V[Parm6]", strParm6);
                    strScript = strScript.Replace("&V[Parm7]", strParm7);
                    strScript = strScript.Replace("&V[Parm8]", strParm8);
                    strScript = strScript.Replace("&V[Parm9]", strParm9);
                    strScript = strScript.Replace("&V[Parm10]", strParm10);

                    args = "\"" + @"Input=OK: process=" + strStartup + q.SAPT_Command + "\"";

                    fullCommand = command + " " + args;

                    fRet = RunAutomation(q, fullCommand, strScript);
                }
            }
            catch (Exception ex)
            {
                fRet = false;
                LogProgress(ex.ToString());
            }

            //testConnection();
            //kill("saplgpad");
            //kill("saplogon");
            //kill("guixt");

            return fRet;
        }

        private static Boolean RunAutomation(vwSAPDetail q, string strFullCommand, string strScript)
        {

            int intWait;

            try
            {

                intWait = Convert.ToInt32(q.SAPT_Wait);

                string strStartup = Path.GetTempPath().ToString();
                string strFileGen = q.SAPT_Command.Replace(".txt", "").Replace("_", "") + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + "_" + DateTime.Now.Second.ToString() + ".csv";
                string path = Path.Combine(strStartup, q.SAPT_Command.ToString());

                if (q.SAPAID == 2 || q.SAPAID == 3) //fni,adp
                {
                    try
                    {

                        if (!(path.Contains(".txt")))
                        {
                            path = path + ".txt";
                        }

                        if (!File.Exists(path))
                        {
                            File.Create(path);
                            TextWriter tw = new StreamWriter(path);
                            tw.WriteLine(strScript);
                            tw.Close();
                        }
                        else if (File.Exists(path))
                        {
                            TextWriter tw = new StreamWriter(path);
                            tw.WriteLine(strScript);
                            tw.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        LogProgress(ex.ToString());
                    }

                   

                    StartProcess(q, strFullCommand);

                }
                else
                {

                    switch (q.SAPAID)
                    {

                        case 5://SAP Shortcut

                            string strSAPVersion = clsUtility.ConfigVal("SAPVersion");
                            CreateLogon(q);
                            break;

                        case 7://c# code

                            Type type = typeof(clsSAP);
                            MethodInfo method = type.GetMethod(q.SAPT_Command);
                            method.Invoke(type, null);

                            break;

                    }
                }

                wait(intWait);
                return true;

            }
            catch (Exception ex)
            {
                LogProgress(ex.ToString());
                return false;
            }
        }

    }
}
