using System;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Collections;
using HRLData;
using System.Data.Entity;

namespace FPY
{

	public class DataGridViewComboBoxColumnCredo : DataGridViewComboBoxColumn
	{
		public DataGridViewComboBoxColumnCredo()
		{
			this.CellTemplate = new DataGridViewComboBoxCell();
		}

		public string DataPropertyFilterName { get; set; }

	}

	public partial class p_DropDown_ResultString
	{
		public string ID { get; set; }
		public string Display { get; set; }
	}

	public class clsDropDownUtil
	{

		public static List<p_DropDown_Result> AddDropItem(List<p_DropDown_Result>  lst, string strItem)
		{
			p_DropDown_Result rel = new p_DropDown_Result();
			rel.ID = 0;
			rel.Display = strItem;
			lst.Insert(0, rel);

			return lst;

		}

		//public static Dictionary<int, string> AddDropItem(Dictionary<int, string> lst, string strItem)
		//{
		//	Dictionary<int, string> rel = new Dictionary<int, string>();

		//	lst.Add(0, strItem);

		//	return lst;

		//}

		public static Dictionary<int, string> DropDownTBL(Int32 intAPPID, Int32 intNAVID, string strCol, string strCriteria, int intASID)
		{

			var dy = new Dictionary<int, string>();

			try
			{
				string strSQL = "p_DropDown_TBL " + intAPPID.ToString() + ", " + intNAVID.ToString() + ", " + strCol + ", '" + strCriteria + "', " + intASID.ToString();

				DataSet ds = clsDAL.ProcessSQL(strSQL, "HRL");

				if (clsDAL.dsHasData(ds))
				{
					DataTable dt = ds.Tables[0];
					dy = dt.AsEnumerable()
								   .ToDictionary<DataRow, int, string>(row => row.Field<int>(0),
									   row => row.Field<string>(1));
				}

				else
				{
					HRLEntities db = clsStart.efdb();
					var q = db.p_DropDown(intAPPID, intNAVID, strCol, "", intASID);

					var qry = (from ct in q
							   select ct).ToList();
					dy = qry.ToDictionary(x => x.ID, x => x.Display);

				}

			 

			}
			catch (Exception ex)
			{

			}

			return dy;
		}


		public static void DropDownTBL(Int32 intAPPID, Int32 intNAVID, string strCol, string strCriteria, int intASID, ComboBox ddl, string strBlank)
		{

			var dy = new Dictionary<int, string>();

			try
			{
				string strSQL = "p_DropDown_TBL " + intAPPID.ToString() + ", " + intNAVID.ToString() + ", " + strCol + ", '" + strCriteria + "', " + intASID.ToString();

				DataSet ds = clsDAL.ProcessSQL(strSQL, "HRL");

				if (clsDAL.dsHasData(ds))
				{
					DataTable dt = ds.Tables[0];
					dy = dt.AsEnumerable()
								   .ToDictionary<DataRow, int, string>(row => row.Field<int>(0),
									   row => row.Field<string>(1));
				}

				else
				{
					HRLEntities db = clsStart.efdb();
					var q = db.p_DropDown(intAPPID, intNAVID, strCol, "", intASID);

					var qry = (from ct in q
							   select ct).ToList();
					dy = qry.ToDictionary(x => x.ID, x => x.Display);

				}

				if (strBlank + "" != "")
				{
					dy = (new Dictionary<int, string> { { 0, strBlank } }).Concat(dy).ToDictionary(k => k.Key, v => v.Value);
				}

				ddl.DataSource = new BindingSource(dy.ToList(), null);
				ddl.DisplayMember = "Value";
				ddl.ValueMember = "Key";

			}
			catch (Exception ex)
			{

			}


		}

		public static void DropDownTBL(clsForm frm, TypeAhead txt, Int32 intAPPID, Int32 intNAVID, string strCol, string strCriteria, int intASID,  string strDefault, int intVal)
		{

			var dy = new Dictionary<int, string>();

			try
			{
				string strSQL = "p_DropDown_TBL " + intAPPID.ToString() + ", " + intNAVID.ToString() + ", " + strCol + ", '" + strCriteria + "', " + intASID.ToString();

				DataSet ds = clsDAL.ProcessSQL(strSQL, "HRL");

				if (clsDAL.dsHasData(ds))
				{
					DataTable dt = ds.Tables[0];
					dy = dt.AsEnumerable()
								   .ToDictionary<DataRow, int, string>(row => row.Field<int>(0),
									   row => row.Field<string>(1));
				}

				else
				{
					HRLEntities db = clsStart.efdb();

					string strDebug = "p_DropDown " + intAPPID.ToString() + ", " + intNAVID.ToString() + ", " + strCol + ", '', " + intASID.ToString();

					Debug.Print(strDebug);

					var q = db.p_DropDown(intAPPID, intNAVID, strCol, "", intASID);

					var qry = (from ct in q
							   select ct).ToList();
					dy = qry.ToDictionary(x => x.ID, x => x.Display);

				}

				if (strDefault + "" != "")
				{
					dy = (new Dictionary<int, string> { { 0, strDefault } }).Concat(dy).ToDictionary(k => k.Key, v => v.Value);
				}


				txt.ParentForm = frm; 
				txt.DefaultText = strDefault;
				txt.Text = strDefault;
				txt.DataSource = dy;
				txt.lstWidth = txt.Width;// * intVal;
				if (intVal > 0)
				{
					txt.SelectedValue = intVal;
					try
					{
						var q = (from ct in txt.DataSource
								 where ct.Key == intVal
								 select ct).First();

						txt.Text = q.Value.ToString();
					}
					catch (Exception ex)
					{

					}
				}


			}
			catch (Exception ex)
			{

			}


		}

		public static void DropDown(DataGridView gv, Int32 intNAVID, tblAppColumns tbl, HRLData.HRLEntities db,  Int32 intApp, Int32 intAPPID, Int32 intASID, Boolean fShowArrow)
		{
			DataGridViewComboBoxColumnCredo gvCbo = new DataGridViewComboBoxColumnCredo();

			switch (tbl.APCOID)
			{

				case 2:

					var qry = new Dictionary<int, string>();

					try
					{
						List<p_DropDown_Result> q = db.p_DropDown(intAPPID, intNAVID, tbl.APC_Desc, "", intASID).ToList<p_DropDown_Result>();
						qry = q.ToDictionary(pl => pl.ID, pl => pl.Display);
					}
					catch (Exception ex)
					{

					}
					if (qry.Count > 0)
					{
						gvCbo.DataSource = qry.ToList();
					}

					break;

				case 21:

					var qry2 = new Dictionary<string, string>();

					try
					{
						List<p_DropDownFilter_Result> q = db.p_DropDownFilter(intNAVID, tbl.APC_Desc, "", tbl.APC_QueryField, intASID).ToList<p_DropDownFilter_Result>();
						qry2 = q.ToDictionary(pl => pl.ID, pl => pl.Display);
					}
					catch (Exception ex)
					{

					}

					if (qry2.Count > 0)
					{
						gvCbo.DataSource = qry2.ToList();
					}

					break;

				case 25:

				   var qry25 = new Dictionary<string, string>();

					try
					{

						string strSQL = "p_DropDownFilter " + intNAVID.ToString() + ", '" + tbl.APC_Desc + "', '','" + tbl.APC_QueryField + "', " +  intASID.ToString();

						DataSet ds = clsDAL.ProcessSQL(strSQL, "app");

						//var q = (from myRow in ds.Tables[0].AsEnumerable()
						//               select new {ID = myRow.Field<Int32>("ID"), Display = myRow.Field<string>("Display")}).ToList();

						var q = (from myRow in ds.Tables[0].AsEnumerable()
								 select new { ID = myRow.Field<string>("ID"), Display = myRow.Field<string>("Display") }).ToList();


						qry25 = q.ToDictionary(pl => pl.ID.ToString(), pl => pl.Display);



					}
					catch (Exception ex)
					{

					}

					if (qry25.Count > 0)
					{
						gvCbo.DataSource = qry25.ToList();
					}

					break;

				case 28:

					var qry28 = new Dictionary<int, string>();

					try
					{
						qry28 = DropDownTBL(intAPPID, intNAVID, tbl.APC_Desc, "", intASID);

						//List<p_DropDown_Result> q = db.p_DropDown(intAPPID, intNAVID, tbl.APC_Desc, "", intASID).ToList<p_DropDown_Result>();
						//qry28 = q.ToDictionary(pl => pl.ID, pl => pl.Display);
					}
					catch (Exception ex)
					{

					}
					if (qry28.Count > 0)
					{
						gvCbo.DataSource = qry28.ToList();
					}

					break;

				case 31:

					var qry31 = new Dictionary<int, string>();

					try
					{
						List<p_DropDown_Result> q31 = db.p_DropDown(intAPPID, intNAVID, tbl.APC_Desc, "", intASID).ToList<p_DropDown_Result>();
						try
						{
							q31 = clsDropDownUtil.AddDropItem(q31, "-");
						}
						catch(Exception ex2)
						{

						}

						qry31 = q31.ToDictionary(pl => pl.ID, pl => pl.Display);
					}
					catch (Exception ex)
					{

					}
					if (qry31.Count > 0)
					{
						gvCbo.DataSource = qry31.ToList();
					}

					break;

				case 37:

					var qry37 = new Dictionary<int, string>();

					try
					{
						List<p_DropDown_Result> q = db.p_DropDown(intAPPID, intNAVID, tbl.APC_Desc, "", intASID).ToList<p_DropDown_Result>();
						qry37 = q.ToDictionary(pl => pl.ID, pl => pl.Display);
					}
					catch (Exception ex)
					{

					}
					if (qry37.Count > 0)
					{
						gvCbo.DataSource = qry37.ToList();
					}

					break;

			}
			string strName = tbl.APC_Desc;
			gvCbo.DisplayMember = "Value";
			gvCbo.ValueMember = "Key";
			gvCbo.FlatStyle = FlatStyle.Flat;
			gvCbo.Name = tbl.APC_Desc;
			gvCbo.HeaderText = tbl.APC_Name;
			gvCbo.DataPropertyFilterName = tbl.APC_QueryField;
			gvCbo.DataPropertyName = strName;

			gvCbo.Tag = tbl.APCID.ToString();
			gvCbo.ReadOnly = Convert.ToBoolean(tbl.APC_ReadOnly);

			if (fShowArrow == false)
			{
				gvCbo.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
			}

			if (tbl.APC_Width == 0)
			{
				gvCbo.Visible = false;
			}
			else
			{
				gvCbo.Width = tbl.APC_Width;
			}

			gvCbo.SortMode = DataGridViewColumnSortMode.Automatic;
			gvCbo.AutoComplete = true;
			gv.Columns.Add(gvCbo);

		}

		public static void DropDown(DataGridView gv, Int32 intNAVID, tblAppColumns tbl, RexrothData.RexrothEntities db, Int32 intApp, Int32 intAPPID, Int32 intASID)
		{
			DataGridViewComboBoxColumnCredo gvCbo = new DataGridViewComboBoxColumnCredo();

			switch (tbl.APCOID)
			{

				//case 2:

				//    var qry = new Dictionary<int, string>();

				//    try
				//    {
				//        var q = db.p_DropDown(intNAVID, tbl.APC_Desc, "", intASID).ToList();
				//        qry = q.ToDictionary(pl => pl.ID, pl => pl.Display);
				//    }
				//    catch (Exception ex)
				//    {

				//    }
				//    if (qry.Count > 0)
				//    {
				//        gvCbo.DataSource = qry.ToList();
				//    }

				//    break;

				//case 21:

				//    var qry2 = new Dictionary<string, string>();

				//    try
				//    {
				//        List<p_DropDownFilter_Result> q = db.p_DropDownFilter(intNAVID, tbl.APC_Desc, "", tbl.APC_QueryField, intASID).ToList<p_DropDownFilter_Result>();
				//        qry2 = q.ToDictionary(pl => pl.ID, pl => pl.Display);
				//    }
				//    catch (Exception ex)
				//    {

				//    }

				//    if (qry2.Count > 0)
				//    {
				//        gvCbo.DataSource = qry2.ToList();
				//    }

				//    break;

				//case 25:

				//    var qry25 = new Dictionary<string, string>();

				//    try
				//    {
				//        List<p_DropDownFilter_Result> q = db.p_DropDownFilter(intNAVID, tbl.APC_Desc, "", tbl.APC_QueryField, intASID).ToList<p_DropDownFilter_Result>();
				//        qry25 = q.ToDictionary(pl => pl.ID, pl => pl.Display);
				//    }
				//    catch (Exception ex)
				//    {

				//    }

				//    if (qry25.Count > 0)
				//    {
				//        gvCbo.DataSource = qry25.ToList();
				//    }

				//    break;

			}
			string strName = tbl.APC_Desc;
			gvCbo.DisplayMember = "Value";
			gvCbo.ValueMember = "Key";
			gvCbo.FlatStyle = FlatStyle.Flat;
			gvCbo.Name = tbl.APC_Desc;
			gvCbo.HeaderText = tbl.APC_Name;
			gvCbo.DataPropertyFilterName = tbl.APC_QueryField;
			gvCbo.DataPropertyName = strName;

			gvCbo.Tag = tbl.APCID.ToString();
			gvCbo.ReadOnly = Convert.ToBoolean(tbl.APC_ReadOnly);

			if (tbl.APC_Width == 0)
			{
				gvCbo.Visible = false;
			}
			else
			{
				gvCbo.Width = tbl.APC_Width;
			}

			gvCbo.AutoComplete = true;
			gv.Columns.Add(gvCbo);

		}
	}
}
