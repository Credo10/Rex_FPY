using System;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Linq;
using System.IO;
using System.Drawing;
using HRLData;
using System.Threading.Tasks;
using System.Configuration;
using Encryption;



namespace FPY
{
	//this is used to save a forms opening panels to determine if we need to save
	public class CredoPanel
	{
		public string Name { get; set; }
		public double Width { get; set; }
		public double Height { get; set; }
	}
	public class clsUtility
	{


		public static string ConfigVal(string strVAl)
		{
			string strRet = "";
			try
			{
				strRet = ConfigurationManager.AppSettings[strVAl].ToString();
			}
			catch (Exception ex)
			{

			}

			return strRet;
		}

		public static string ConnectionVal(string strVAl)
		{
			string strRet = "";
			try
			{
				strRet = ConfigurationManager.ConnectionStrings[strVAl].ToString();
			}
			catch (Exception ex)
			{

			}

			return strRet;
		}

		public static IEnumerable<Control> AllSubControls(Control control) => Enumerable.Repeat(control, 1)
			   .Union(control.Controls.OfType<Control>()
					  .SelectMany(AllSubControls)
			);

       
        public static void LoadFormSetting(Form frm, int intASID, int intNAVID)
		{
			HRLEntities db = clsStart.efdb();

			var q = from ct in db.tblAppNavigationUser
					where ct.ASID == intASID
					&& ct.NAVID == intNAVID
					select ct;

			foreach (var ctl in q)
			{
				try
				{
					string strControl = ctl.AG_FormItem;

					var aoControls = frm.Controls.Find(strControl, true);
					if ((aoControls != null) && (aoControls.Length != 0))
					{
						Control foundControl = aoControls[0];
						foundControl.Width = Convert.ToInt32(ctl.AG_Width);
						foundControl.Height = Convert.ToInt32(ctl.AG_Height);
					}



				}
				catch (Exception ex)
				{

				}

			}
		}

        public static void Impersonate(int intAPPID, int intASID)
        {
            try
            {
                HRLEntities db = clsStart.efdb();
                string file = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
                string app = System.IO.Path.GetFileNameWithoutExtension(file) + ".exe";
                string strUser = "";

                
                try
                {
                    var q = (from ct in db.tblAssociate
                             where ct.ASID == intASID
                             select ct).First();

                    strUser = q.AS_UserID;

                    string strPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                    strPath = Path.Combine(strPath, app);
                    Process pro = new Process();
                    pro.StartInfo.FileName = strPath;
                    pro.StartInfo.Arguments = intAPPID.ToString() + " 0 " + strUser;
                    pro.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not determine user id.");
                    
                }

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
		public static void SaveFormSettings(int intASID, int intNAVID, string strForm, int intWidth, int intHeight)
		{
			HRLEntities db = clsStart.efdb();
			try
			{
				db.p_tblAppNavigationUser_Add(intNAVID, intASID, strForm, intHeight, intWidth);
			}
			catch (Exception ex)
			{

			}

		}
		public static List<T> CreateList<T>(params T[] values)
		{
			return new List<T>(values);
		}

		public static Image byteArrayToImage(byte[] byteArrayIn)
		{
			//System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
			//Image img = (Image)converter.ConvertFrom(byteArrayIn);
			//return img;

			using (MemoryStream mStream = new MemoryStream(byteArrayIn))
			{
				Image img = Image.FromStream(mStream);

				

				return img;
			}




		}

		public static string Right(string sValue, int iMaxLength)
		{
			//Check if the value is valid
			if (string.IsNullOrEmpty(sValue))
			{
				//Set valid empty string as string could be null
				sValue = string.Empty;
			}
			else if (sValue.Length > iMaxLength)
			{
				//Make the string no longer than the max length
				sValue = sValue.Substring(sValue.Length - iMaxLength, iMaxLength);
			}

			//Return the string
			return sValue;
		}


		public static Int32 CleanInt(string strInt)
		{
			Int32 intRet = 0;

			try
			{
				intRet = Convert.ToInt32(strInt);
			}
			catch (Exception ex)
			{

			}

			return intRet;
		}

		public static Decimal CleanDec(string strDec)
		{
			Decimal decRet = 0;

			try
			{
				decRet = Convert.ToDecimal(strDec);
			}
			catch (Exception ex)
			{

			}

			return decRet;
		}

		public static Double CleanDbl(string strDbl)
		{
			Double DblRet = 0;

			try
			{
				DblRet = Convert.ToDouble(strDbl);
			}
			catch (Exception ex)
			{

			}

			return DblRet;
		}
		public static string CleanString(String strText)
		{

			strText = strText.Replace("'", "`");

			return strText;

		}

		public static Boolean IsNumber(String s)
		{
			Boolean value = true;
			foreach (Char c in s.ToCharArray())
			{
				value = value && Char.IsDigit(c);
			}

			return value;
		}
		public static DataRow CurrentRow(DataGridView aGrid)
		{
			CurrencyManager xCM =
			  (CurrencyManager)aGrid.BindingContext[aGrid.DataSource, aGrid.DataMember];
			DataRowView xDRV = (DataRowView)xCM.Current;
			return xDRV.Row;
		}

		public static void CopyDirectory(DirectoryInfo source, DirectoryInfo destination)
		{
			if (!destination.Exists)
			{
				destination.Create();
			}

			// Copy all files.
			FileInfo[] files = source.GetFiles();
			foreach (FileInfo file in files)
			{
				file.CopyTo(Path.Combine(destination.FullName, file.Name));
			}

			// Process subdirectories.
			DirectoryInfo[] dirs = source.GetDirectories();
			foreach (DirectoryInfo dir in dirs)
			{
				// Get destination directory.
				string destinationDir = Path.Combine(destination.FullName, dir.Name);

				// Call CopyDirectory() recursively.
				CopyDirectory(dir, new DirectoryInfo(destinationDir));
			}
		}

		public static string Truncate(string value, int maxLength)
		{
			if (string.IsNullOrEmpty(value)) return value;
			return value.Length <= maxLength ? value : value.Substring(0, maxLength);

		}

		public static bool IsDate(Object obj)
		{
			string strDate = obj.ToString();
			try
			{
				DateTime dt = DateTime.Parse(strDate);
				if (dt != DateTime.MinValue && dt != DateTime.MaxValue)
					return true;
				return false;
			}
			catch
			{
				return false;
			}
		}

		public static bool IsFileInUse(string path)

		{



			if (string.IsNullOrEmpty(path))
				return false;

			try
			{
				using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read)) { }
			}
			catch (IOException)
			{
				return true;
			}

			return false;

		}

		public static DateTime StartOfWeek(DateTime dt, DayOfWeek startOfWeek)
		{
			int diff = dt.DayOfWeek - startOfWeek;
			if (diff < 0)
			{
				diff += 7;
			}

			return dt.AddDays(-1 * diff).Date;
		}

		public static bool IsOpen(tblAppNavigation tbl)
		{

			bool rVal = false;
			try
			{

				// loop though all forms in MDI container to determine if form designated by FormName is open

				foreach (Form frm in Application.OpenForms)
				{

					if (frm.Name.Equals(tbl.NAV_Item) && frm.Text.Equals(tbl.NAV_Desc))
					{
						rVal = true;
						break;
					}

				}
			}
			catch (Exception ex)
			{
				return false;
			}
			//Debug.WriteLine(rVal);
			return rVal;
		}

		//public static string GetOper(EOL.frmData f, Int32 intLNID, string strApp)
		//{
		//    frmOpLogin f2 = new frmOpLogin();
		//    f2.LNID = intLNID;
		//    f2.App = Convert.ToInt32(strApp);
		//    f2.ShowDialog();

		//    f.OperID = f2.ECID;

		//    DateTime time = new DateTime();
		//    time = DateTime.Now;
		//    if (time.Hour >= 7 && time.Hour < 16)
		//    {
		//        f.Shift = 1;
		//    }
		//    else if (time.Hour >= 15 && time.Hour <= 23)
		//    {
		//        f.Shift = 2;
		//    }
		//    else
		//    {
		//        f.Shift = 3;
		//    }

		//    return f2.ECID.ToString();
		//}

		public static bool DocTop(string FormName)
		{

			bool rVal = false;

			// loop though all forms in MDI container to determine if form designated by FormName is open

			foreach (Form frm in frmNavigate.ActiveForm.MdiChildren)
			{

				if (frm.Text.Equals(FormName))
				{
					frm.Dock = DockStyle.Top;
					break;
				}

			}
			//Debug.WriteLine(rVal);
			return rVal;
		}
		public static bool DocFill(string FormName)
		{

			bool rVal = false;

			// loop though all forms in MDI container to determine if form designated by FormName is open

			foreach (Form frm in frmNavigate.ActiveForm.MdiChildren)
			{

				if (frm.Text.Equals(FormName))
				{
					frm.Dock = DockStyle.Fill;
					break;
				}

			}
			//Debug.WriteLine(rVal);
			return rVal;
		}
		public static bool IsDate(string strDate)
		{
			try
			{
				DateTime dt = DateTime.Parse(strDate);
				if (dt != DateTime.MinValue && dt != DateTime.MaxValue)
					return true;
				return false;
			}
			catch
			{
				return false;
			}
		}

		public static bool IsMatch(string str, string expression)
		{
			if (Regex.IsMatch(str, expression))
				return true;
			else
				return false;
		}
		public static string GetSQLDate(System.DateTime dtFrom, System.DateTime dtTo, System.DateTime tmFrom, System.DateTime tmTo) 
		{

			string strTime;   
			string strMonth;  
			string strDay;     
			string strSQL;

			//From Date
			strMonth = dtFrom.Month.ToString();
			strDay = dtFrom.Day.ToString();
			if (strMonth.Length < 2)
			{
				strMonth = "0" + strMonth;
			}
			if (strDay.Length < 2)
			{
				strDay = "0" + strDay;
			}
			strSQL = "'" + dtFrom.Year + strMonth + strDay;

			//From Time
			strTime = tmFrom.Hour.ToString();
			if (strTime.Length < 2)
			{
				strTime = "0" + tmFrom.Hour;
			}
			else
			{
				strTime = tmFrom.Hour.ToString();
			}
			strTime = strTime + ":" + tmFrom.Minute;
			strSQL = strSQL + " " + strTime + "'";

			//To Date
			strMonth = dtTo.Month.ToString();
			strDay = dtTo.Day.ToString();
			if (strMonth.Length < 2)
			{
				strMonth = "0" + strMonth;
			}
			if (strDay.Length < 2)
			{
				strDay = "0" + strDay;
			}
			strSQL = strSQL + ", '" + dtTo.Year + strMonth + strDay;

			//To Time
			strTime = tmTo.Hour.ToString();
			if (strTime.Length < 2)
			{
				strTime = "0" + tmTo.Hour;
			}
			else
			{
				strTime = tmTo.Hour.ToString();
			}
			strTime = strTime + ":" + tmTo.Minute;
			strSQL = strSQL + " " + strTime + "'";

			return strSQL;
																						
		}

		public static string GetCriteriaDate(System.DateTime dtFrom)
		{

			string strTime;
			string strMonth;
			string strDay;
			string strSQL;

			//From Date
			strMonth = dtFrom.Month.ToString();
			strDay = dtFrom.Day.ToString();
			if (strMonth.Length < 2)
			{
				strMonth = "0" + strMonth;
			}
			if (strDay.Length < 2)
			{
				strDay = "0" + strDay;
			}
			strSQL = strMonth + "/" + strDay + "/" + dtFrom.Year.ToString();


			return strSQL;

		}

		public static string GetSQLDateOnly(System.DateTime dtFrom, System.DateTime dtTo)
		{

			string strTime;
			string strMonth;
			string strDay;
			string strSQL;

			//From Date
			strMonth = dtFrom.Month.ToString();
			strDay = dtFrom.Day.ToString();
			if (strMonth.Length < 2)
			{
				strMonth = "0" + strMonth;
			}
			if (strDay.Length < 2)
			{
				strDay = "0" + strDay;
			}
			strSQL = "'" + dtFrom.Year + strMonth + strDay;

		   

			//To Date
			strMonth = dtTo.Month.ToString();
			strDay = dtTo.Day.ToString();
			if (strMonth.Length < 2)
			{
				strMonth = "0" + strMonth;
			}
			if (strDay.Length < 2)
			{
				strDay = "0" + strDay;
			}
			strSQL = strSQL + "', '" + dtTo.Year + strMonth + strDay + "'";


			return strSQL;

		}

		public static string GetSQLDateOnlySingleNoQuote(System.DateTime dtFrom)
		{

			string strTime;
			string strMonth;
			string strDay;
			string strSQL;

			//From Date
			strMonth = dtFrom.Month.ToString();
			strDay = dtFrom.Day.ToString();
			if (strMonth.Length < 2)
			{
				strMonth = "0" + strMonth;
			}
			if (strDay.Length < 2)
			{
				strDay = "0" + strDay;
			}
			strSQL =  dtFrom.Year + strMonth + strDay;





			return strSQL;

		}

		public static bool dsHasData(DataSet ds)
		{
			if (ds.Tables.Count >  0)
			{
				if (ds.Tables[0].Rows.Count >  0)
				{
					return true;
				}

				else
				{
					return false;
				}
			}

			else
			{
				return false;
			}

		}
		public bool IsOpenOption(string FormName, string strCaption)
		{
			bool rVal = false;

			// loop though all forms in MDI container to determine if form designated by FormName is open

			foreach (Form frm in frmNavigate.ActiveForm.MdiChildren)
			{
				if (frm.Name ==  FormName)
				{
					if (frm.Text ==  strCaption)
					{
						rVal = true;
						break;
					}
				}
			}
			return rVal;
		}
		public void UpdateScan(string FormName)
						

					{
//						frmScan frm;
						// loop though all forms in MDI container to determine if form designated by FormName is open

						foreach (Form frm in frmNavigate.ActiveForm.MdiChildren)
						{
							if (frm.Name ==  FormName)
							{
//								frm.BindPallet(0);
//								frm.BindGrid(false);
							}

						}

						// Return rVal

					}
		public void CloseForm(string FormName)	

					{
						//Form frm;

						foreach (Form frm in frmNavigate.ActiveForm.MdiChildren)
						{
							if (frm.Name ==  FormName)
							{
								frm.Close();
								break;
							}

						}

					}
		Form GetForm(string FormName)


		{
			foreach (Form frm in frmNavigate.ActiveForm.MdiChildren)
			{
				if (frm.Name ==  FormName)
				{
					return frm;
				}

			}
			return frmNavigate.ActiveForm;

		}
		public static bool Restore(tblAppNavigation tbl)

		{
			bool rVal = false;
			
			foreach (Form frm in frmNavigate.ActiveForm.MdiChildren)
			{
				try
				{
					clsForm f = (clsForm)frm;

					if (f.tblNav.NAVID ==  tbl.NAVID)
					{
						frm.BringToFront();
						frm.Focus();
						frm.WindowState = FormWindowState.Normal;
						rVal = true;
					}
				}
				catch(Exception ex)
				{
					if (frm.Name == tbl.NAV_Item)
					{
						frm.BringToFront();
						frm.Focus();
						frm.WindowState = FormWindowState.Normal;
						rVal = true;
					}
				}
				

			}

			return rVal;
		}

	    

    }
}
