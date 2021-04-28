using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using VisualData;
using HRLData;

namespace RexVOIS3
{
    public partial class frmReport : clsForm
    {
        public frmReport()
        {
            InitializeComponent();
        }

        VisualEntities db = clsStart.efdbVisual();
        HRLEntities dbHRL = clsStart.efdb();


        tblReport tbl = new tblReport();

        DataSet ds = new DataSet();
        Workbook workbook;
        Worksheet worksheet;
        Range range;
        Microsoft.Office.Interop.Excel.Application application;

        private void frmReport_Load(object sender, EventArgs e)
        {



            var dsRp = (from rpt in dbHRL.tblAppReport
                        where rpt.APPID == this.APPID
                        orderby rpt.RP_Desc
                        select new { rpt.RPID, rpt.RP_Desc }).ToList();

            dsRp.Insert(0, new { RPID = 0, RP_Desc = "--Select Report--" });
            ddlReport.DataSource = new BindingSource(dsRp, null);
            ddlReport.DisplayMember = "RP_Desc";
            ddlReport.ValueMember = "RPID";
            ddlReport.SelectedValue = 0;

            if (this.APPID == 6)
            {
                this.pnlNMR.Visible = true;
            }

            List<EntityData.p_DropDown_Result> qPBSID = dbHRL.p_DropDown(this.APPID, this.tblNav.NAVID, "PBDVID", "", 0).ToList<EntityData.p_DropDown_Result>();
            ddlPBDVID.DataSource = clsDropDownUtil.AddDropItem(qPBSID, "--Select Group--");
            ddlPBDVID.DisplayMember = "Display";
            ddlPBDVID.ValueMember = "ID";
            ddlPBDVID.SelectedValue = 0;

            //var dsOp = (from rpt in db.tblOptions
            //            where rpt.OP_Function == 29
            //            orderby rpt.OP_Desc
            //            select new { rpt.OP_ID, rpt.OP_Desc }).ToList();

            //dsOp.Insert(0, new { OP_ID = 0, OP_Desc = "--Select Type--" });
            //ddlType.DataSource = new BindingSource(dsOp, null);
            //ddlType.DisplayMember = "OP_Desc";
            //ddlType.ValueMember = "OP_ID";
            //ddlType.SelectedValue = 0;

            this.pictureBox1.Visible = false;
            this.pictureBox1.Image = RexVOIS3.Properties.Resources.Report0;
        }

        private string GetDate(DateTime dtOrg)
        {
            string dt = "";
            if (dtOrg.Month < 10)
            {
                dt = "0" + dtOrg.Month.ToString() + @"/";
            }
            else
            {
                dt = dtOrg.Month.ToString() + @"/";
            }

            if (dtOrg.Day < 10)
            {
                dt = dt + "0" + dtOrg.Day.ToString() + @"/" + dtOrg.Year.ToString();
            }
            else
            {
                dt = dt + dtOrg.Day.ToString() + @"/" + dtOrg.Year.ToString();
            }

            return dt;
        }
        private string GetDateSQL()
        {
            DateTime dtFroms = Convert.ToDateTime(dtFrom.Value.ToShortDateString());
            DateTime dtTos = Convert.ToDateTime(dtTo.Value.ToShortDateString());


            string dt = "";

            dt = "'" + GetDate(dtFroms) + "', " + "'" + GetDate(dtTos) + "'";

            return dt;
        }

        private string GetDateAcc()
        {
            DateTime dtFroms = Convert.ToDateTime(dtFrom.Value.ToShortDateString());
            DateTime dtTos = Convert.ToDateTime(dtTo.Value.ToShortDateString());


            string dt = "";

            dt = "#" + GetDate(dtFroms) + "# and #" + GetDate(dtTos) + "#";

            return dt;
        }
        private string GetReportSQL(Int32 intRPID)
        {

            string strSQL = "";

            string dt = GetDateSQL();

            string strPBDID = "";
            try
            {
                foreach (DataGridViewRow row in gv1.Rows)
                {
                    if (gv1.Rows[row.Index].DefaultCellStyle.BackColor == Color.Yellow)
                    {
                        strPBDID = strPBDID + "," + gv1.Rows[row.Index].Cells["PBDID"].Value.ToString();
                    }

                }

            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
            }

            string strMaterial = this.txtMaterial.Text.ToString();
            string strZMNR = this.txtZMNR.Text.ToString();

            switch (intRPID)
            {

                case 51: //Extended material

                    strSQL = "p_PBTracking_Reports  " + intRPID.ToString() + ", " + dt + ", '" + strPBDID + "', '" + strMaterial + "', '" + strZMNR + "'";

                    break;

                case 52: //3 day

                    strSQL = "p_PBTracking_Reports  " + intRPID.ToString() + ", " + dt + ", '" + strPBDID + "', '" + strMaterial + "', '" + strZMNR + "'";

                    break;

                case 53: //summary

                    strSQL = "p_PBTracking_Reports  " + intRPID.ToString() + ", " + dt + ", '" + strPBDID + "', '" + strMaterial + "', '" + strZMNR + "'";

                    break;

                case 27:

                    strSQL = "p_tblShipping_Delivered2  " + dt + ", '1','" + this.txtCustomer.Text.ToString() + "', '" + this.txtMRP.Text.ToString() + "', " + this.ddlType.SelectedValue.ToString() + ", ''";

                    break;

                case 32:

                    strSQL = "p_tblShipping_ReasonCode " + dt;

                    break;

                case 54: //WIP

                    strSQL = "p_PBTracking_Reports  " + intRPID.ToString() + ", " + dt + ", '" + strPBDID + "', '" + strMaterial + "', '" + strZMNR + "'";

                    break;


                case 56: //Task Days

                    strSQL = "p_PBTracking_Reports  " + intRPID.ToString() + ", " + dt + ", '" + strPBDID + "', '" + strMaterial + "', '" + strZMNR + "'";

                    break;

                case 57:

                    strSQL = "p_tblValueMachine_Reports " + intRPID.ToString() + ", " + dt;

                    break;

                case 58:

                    strSQL = "p_tblValueMachine_Reports " + intRPID.ToString() + ", " + dt;

                    break;
                case 59:

                    strSQL = "p_tblValueMachine_Reports " + intRPID.ToString() + ", " + dt;

                    break;

                case 60:

                    strSQL = "p_tblValueMachine_Reports " + intRPID.ToString() + ", " + dt;

                    break;

                case 61:

                    strSQL = "p_tblValueMachine_Reports " + intRPID.ToString() + ", " + dt;

                    break;


                case 62:

                    strSQL = "p_tblValueMachine_Reports " + intRPID.ToString() + ", " + dt;

                    break;

                case 63:

                    strSQL = "p_tblValueMachine_Reports " + intRPID.ToString() + ", " + dt;

                    break;

                case 64:

                    strSQL = "p_tblValueMachine_Reports " + intRPID.ToString() + ", " + dt;

                    break;
            }

            return strSQL;

        }

        private bool GetReportData(Int32 intRPID)
        {
            UpdateProgress("Getting report data...");

            string strSQL = GetReportSQL(intRPID);

            if (this.APPID == 6) //PB
            {
                ds = clsDAL.ProcessSQL(strSQL, "HRL");
            }
            else
            {
                ds = clsDAL.ProcessSQL(strSQL, "Visual");
            }


            try
            {
                if (!(clsUtility.dsHasData(ds)))
                {
                    MessageBox.Show("There is no data to export.", "");
                    this.Cursor = Cursors.Default;
                    return false;

                }
            }
            catch (Exception ex)
            {
                UpdateProgress("");
                this.Cursor = Cursors.Default;
                return false;
            }

            return true;
        }

       
        private bool GetReportXL(Int32 intRPID)
        {

            UpdateProgress("Getting chart file...");
            string strXL = "";
            string strFileName = "";
            string strRpt = this.ddlReport.SelectedValue.ToString();
            string strStartup = System.Windows.Forms.Application.StartupPath.ToString() + @"\Reports\";

            try
            {
                var dsRp = (from rpt in dbRexroth.tblReport
                            where rpt.RPID == intRPID
                            orderby rpt.RP_Desc
                            select rpt).First();



                strXL = strStartup + dsRp.RP_XL.ToString();

                strFileName = clsExport.CreateTempFile(strXL);

                if (strFileName == "")
                {
                    UpdateProgress("");
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Cannot Create XL Temp File.", this.Text);
                    return false;
                }
            }
            catch (Exception ex)
            {
                //UpdateProgress("");
                //this.Cursor = Cursors.Default;
                //MessageBox.Show("Cannot Determine XL template.", this.Text);
                return true;
            }



            try
            {

                Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
                workbook = application.Workbooks.Open(strFileName, 0, false, 5, "", "", false, XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                workbook.Application.Visible = true;


            }
            catch (Exception ex)
            {
                UpdateProgress("");
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, this.Text);
                return false;
            }

            return true;
        }

        private bool PutReportData(Int32 intRPID)
        {

            try
            {

                UpdateProgress("Sending Chart data...");

                object missing;

                int pivotTablesCount = 0;

                switch (intRPID)
                {


                    case 32:

                        worksheet = (Worksheet)workbook.Worksheets.get_Item("ChartData");
                        worksheet.Activate();
                        clsExport.ExcelExportExisting(worksheet, ds.Tables[1], 0, 0);

                        UpdateProgress("Sending Supporting Data... " + ds.Tables[0].Rows.Count.ToString() + " rows in all.");

                        worksheet = (Worksheet)workbook.Worksheets.get_Item("SupportingData");
                        worksheet.Activate();

                        clsExport.ExcelExportExisting(worksheet, ds.Tables[0], 0, 0);

                        worksheet = (Worksheet)workbook.Worksheets.get_Item("Chart");
                        worksheet.Activate();

                        break;

                    case 51:

                        clsExport.ExcelExport(ds.Tables[0], true, true);

                        break;

                    case 52:

                        clsExport.ExcelExport(ds.Tables[0], true, true);

                        break;

                    case 53:

                        clsExport.ExcelExport(ds.Tables[0], true, true);

                        break;

                    case 54:

                        worksheet = (Worksheet)workbook.Worksheets.get_Item("ChartData");
                        worksheet.Activate();
                        clsExport.ExcelExportExisting(worksheet, ds.Tables[0], 0, 0);



                        worksheet = (Worksheet)workbook.Worksheets.get_Item("Chart");
                        worksheet.Activate();

                        missing = Type.Missing;

                        Microsoft.Office.Interop.Excel.PivotTables pivotTables = (Microsoft.Office.Interop.Excel.PivotTables)worksheet.PivotTables(missing);
                        pivotTablesCount = pivotTables.Count;
                        if (pivotTablesCount > 0)
                        {
                            for (int i = 1; i <= pivotTablesCount; i++)
                            {
                                pivotTables.Item(i).RefreshTable(); //The Item method throws an exception
                            }
                        }


                        break;

                    case 56:

                        worksheet = (Worksheet)workbook.Worksheets.get_Item("ChartData");
                        worksheet.Activate();
                        clsExport.ExcelExportExisting(worksheet, ds.Tables[0], 0, 0);



                        worksheet = (Worksheet)workbook.Worksheets.get_Item("Chart");
                        worksheet.Activate();

                        missing = Type.Missing;

                        Microsoft.Office.Interop.Excel.PivotTables pivotTables56 = (Microsoft.Office.Interop.Excel.PivotTables)worksheet.PivotTables(missing);
                        pivotTablesCount = pivotTables56.Count;
                        if (pivotTablesCount > 0)
                        {
                            for (int i = 1; i <= pivotTablesCount; i++)
                            {
                                pivotTables56.Item(i).RefreshTable(); //The Item method throws an exception
                            }
                        }


                        break;

                    case 57:

                        clsExport.ExcelExport(ds.Tables[0], true, true);

                        break;

                    case 58:

                        worksheet = (Worksheet)workbook.Worksheets.get_Item("ChartData");
                        worksheet.Activate();
                        clsExport.ExcelExportExisting(worksheet, ds.Tables[0], 0, 0);

                        worksheet = (Worksheet)workbook.Worksheets.get_Item("RawData");
                        worksheet.Activate();
                        clsExport.ExcelExportExisting(worksheet, ds.Tables[1], 0, 0);


                        worksheet = (Worksheet)workbook.Worksheets.get_Item("Chart");
                        worksheet.Activate();

                        missing = Type.Missing;

                        Microsoft.Office.Interop.Excel.PivotTables pivotTables58 = (Microsoft.Office.Interop.Excel.PivotTables)worksheet.PivotTables(missing);
                        pivotTablesCount = pivotTables58.Count;
                        if (pivotTablesCount > 0)
                        {
                            for (int i = 1; i <= pivotTablesCount; i++)
                            {
                                pivotTables58.Item(i).RefreshTable(); //The Item method throws an exception
                            }
                        }


                        break;

                    case 60:



                        worksheet = (Worksheet)workbook.Worksheets.get_Item("RawData");
                        worksheet.Activate();
                        clsExport.ExcelExportExistingNoHeader(60, worksheet, ds.Tables[0], 0, 0, false, false);
                        clsExport.ExcelExportExistingNoHeader(60, worksheet, ds.Tables[1], 0, 8, false, false);
                        clsExport.ExcelExportExistingNoHeader(60, worksheet, ds.Tables[2], -1, 11, false, false);

                        Range endCell = (Range)worksheet.Cells[ds.Tables[0].Rows.Count + 2, 1];
                        Range endCell2 = (Range)worksheet.Cells[1000, 26];
                        Range writeRange = worksheet.Range[endCell, endCell2];
                        writeRange.Delete();


                        break;

                    case 61:

                        clsExport.ExcelExport(ds.Tables[0], true, true);

                        break;

                    case 62:


                        worksheet = (Worksheet)workbook.Worksheets.get_Item("ChartData");
                        worksheet.Activate();
                        clsExport.ExcelExportExisting(worksheet, ds.Tables[0], 0, 0);



                        worksheet = (Worksheet)workbook.Worksheets.get_Item("Chart");
                        worksheet.Activate();

                        missing = Type.Missing;

                        Microsoft.Office.Interop.Excel.PivotTables pivotTables62 = (Microsoft.Office.Interop.Excel.PivotTables)worksheet.PivotTables(missing);
                        pivotTablesCount = pivotTables62.Count;
                        if (pivotTablesCount > 0)
                        {
                            for (int i = 1; i <= pivotTablesCount; i++)
                            {
                                pivotTables62.Item(i).RefreshTable(); //The Item method throws an exception
                            }
                        }


                        break;

                    case 63:


                        worksheet = (Worksheet)workbook.Worksheets.get_Item("ChartData");
                        worksheet.Activate();
                        clsExport.ExcelExportExisting(worksheet, ds.Tables[0], 0, 0);



                        worksheet = (Worksheet)workbook.Worksheets.get_Item("Chart");
                        worksheet.Activate();

                        missing = Type.Missing;

                        Microsoft.Office.Interop.Excel.PivotTables pivotTables63 = (Microsoft.Office.Interop.Excel.PivotTables)worksheet.PivotTables(missing);
                        pivotTablesCount = pivotTables63.Count;
                        if (pivotTablesCount > 0)
                        {
                            for (int i = 1; i <= pivotTablesCount; i++)
                            {
                                pivotTables63.Item(i).RefreshTable(); //The Item method throws an exception
                            }
                        }


                        break;

                    case 64:

                        worksheet = (Worksheet)workbook.Worksheets["MissingRunTimes"];
                        worksheet.Activate();
                        clsExport.ExcelExportExisting(worksheet, ds.Tables[0], 0, 0);


                        worksheet = (Worksheet)workbook.Worksheets["SavedDailySchedule"];
                        worksheet.Activate();
                        clsExport.ExcelExportExisting(worksheet, ds.Tables[1], 0, 0);

                        worksheet = (Worksheet)workbook.Worksheets["DailyConfirmations"];
                        worksheet.Activate();
                        clsExport.ExcelExportExisting(worksheet, ds.Tables[2], 0, 0);

                        worksheet = (Worksheet)workbook.Worksheets["Combined"];
                        worksheet.Activate();
                        clsExport.ExcelExportExisting(worksheet, ds.Tables[3], 0, 0);

                        worksheet = (Worksheet)workbook.Worksheets["Chart"];
                        worksheet.Activate();

                        missing = Type.Missing;

                        try
                        {
                            Microsoft.Office.Interop.Excel.PivotTables pivotTables64 = (Microsoft.Office.Interop.Excel.PivotTables)worksheet.PivotTables(missing);
                            pivotTablesCount = pivotTables64.Count;
                            if (pivotTablesCount > 0)
                            {
                                for (int i = 1; i <= pivotTablesCount; i++)
                                {
                                    pivotTables64.Item(i).RefreshTable(); //The Item method throws an exception
                                }
                            }
                        }
                        catch (Exception)
                        {

                            
                        }
                        


                        break;
                }

            }
            catch (Exception ex)
            {
                UpdateProgress("");
                workbook.Application.Visible = true;
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, this.Text);
                return false;
            }

            try
            {
                workbook.Application.Visible = true;
            }
            catch (Exception ex)
            {

            }

            return true;
        }

        private bool PutRDLData(Int32 intRPID)
        {

            try
            {

                UpdateProgress("Sending Chart data...");


                switch (intRPID)
                {

                    case 26:

                        frmReportViewer rpt = new frmReportViewer();
                        string strCriteria = GetCriteria();
                        rpt.strForm = strCriteria;
                        rpt.ds = this.ds;
                        rpt.ECID = 26;
                        rpt.RDL = tbl.RP_RDL;
                        rpt.MdiParent = this.MdiParent;
                        rpt.Show();
                        this.Cursor = Cursors.Default;

                        break;

                }

            }
            catch (Exception ex)
            {
                UpdateProgress("");
                workbook.Application.Visible = true;
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, this.Text);
                return false;
            }

            //workbook.Application.Visible = true;

            return true;
        }

        #region "Grid Events"

        public void BindGrid(Int32 intID, DataGridView gv)
        {
            int? intNAVID = this.tblNav.NAVID;

            int? intAPPID = this.APPID;

            gv.Columns.Clear();
            gv.DataSource = null;

            this.Cursor = Cursors.WaitCursor;


            var q162 = from ct in dbHRL.tblPBDistribution
                       where ct.PBD_Deleted.HasValue == false
                       orderby ct.PBD_Desc
                       select ct;

            var qry162 = (from ct in q162
                          select ct).ToList();

            BindGridData(qry162, gv);


            //Should be a better way to do this
            try
            {
                foreach (DataGridViewRow row in gv1.Rows)
                {
                    gv1.Rows[row.Index].Cells["Select"].Value = "Select";

                }

            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
            }


            this.Cursor = Cursors.Default;


        }

        public void BindGridData<T>(IEnumerable<T> result, DataGridView gv)
        {



            if (!(gv.Columns.Count > 0))
            {
                gv.Columns.Clear();
                gv.AutoGenerateColumns = false;
                gv.AllowUserToAddRows = false;
                gv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

                Int32 intAPPID = this.APPID;



                try
                {


                    List<EntityData.tblAppColumns> properties = (from col in dbHRL.tblAppColumns
                                                                 where col.NAVID == 162
                                                                 && col.APC_Grid == gv.Name
                                                                 orderby col.APC_Order
                                                                 select col).ToList<EntityData.tblAppColumns>();


                    foreach (var property in properties)
                    {
                        clsGridUtil.AddColumns(gv, this.tblNav.NAVID, property, dbHRL, this.APPID, intAPPID, this.Associate.ASID);

                    }





                }
                catch (Exception ex)
                {

                }
            }

            try
            {
                gv.DataSource = null;
                //bs1.DataSource = result;
                gv.DataSource = result;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.AppName);
                return;
            }
        }



        private void gv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridView gv = (DataGridView)sender;

            //Ignore clicks that are not on button cells. 
            if (e.RowIndex < 0)
            {
                return;
            }

            Boolean fHandled = clsGridUtil.Grid_CellClick(gv, e); //handle common tasks

            if (fHandled == false)
            {
                try
                {



                }
                catch (Exception ex)
                {

                }
            }

        }

        #endregion
        private void UpdateProgress(string strProgress)
        {
            this.lblProgress.Text = strProgress;
            this.Refresh();
        }

        private void lnkReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.ddlReport.SelectedValue.ToString() + "" == "0")
            {
                MessageBox.Show("Please select a Report.", "Credo");
                return;
            }

            Int32 intRPID = Convert.ToInt32(ddlReport.SelectedValue.ToString());

            if (intRPID == 51 | intRPID == 52 | intRPID == 53 | intRPID == 56)
            {
                string strPBDID = "";
                try
                {
                    foreach (DataGridViewRow row in gv1.Rows)
                    {
                        if (gv1.Rows[row.Index].DefaultCellStyle.BackColor == Color.Yellow)
                        {
                            strPBDID = strPBDID + "," + gv1.Rows[row.Index].Cells["PBDID"].Value.ToString();
                        }

                    }

                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                }

                if (strPBDID + "" == "")
                {
                    MessageBox.Show("Please select at least one Distribution.", "Credo");
                    return;
                }

            }

            tbl = (from ct in dbRexroth.tblReport
                   where ct.RPID == intRPID
                   select ct).First();

            UpdateProgress("Getter report file...");

            if (GetReportData(intRPID))
            {

                if (tbl.RP_RDL + "" != "")
                {
                    PutRDLData(intRPID);
                }
                else
                {
                    if (GetReportXL(intRPID))
                    {

                        if (PutReportData(intRPID))
                        {

                            if (intRPID != 51 && intRPID != 52 && intRPID != 53 && intRPID != 60)
                            {
                                try
                                {
                                    UpdateProgress("Setting report criteria...");
                                    Microsoft.Office.Interop.Excel.Range CRName = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, 1];
                                    CRName.Value = this.ddlReport.Text;
                                    Microsoft.Office.Interop.Excel.Range CRCriteria = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[2, 1];
                                    CRCriteria.Value = GetCriteria();
                                    Microsoft.Office.Interop.Excel.Range CRCriteria2 = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, 5];
                                    CRCriteria2.Select();

                                    try
                                    {
                                        worksheet = (Worksheet)workbook.Worksheets.get_Item("LostTime");
                                    }
                                    catch (Exception)
                                    {


                                    }

                                    try
                                    {
                                        worksheet = (Worksheet)workbook.Worksheets.get_Item("Chart");
                                    }
                                    catch (Exception)
                                    {


                                    }

                                    worksheet.Activate();

                                    application.Interactive = true;
                                }
                                catch (Exception ex)
                                {

                                }
                            }
                            UpdateProgress("");
                        }

                    }
                }
            }

            UpdateProgress("");
            this.Cursor = Cursors.Default;


        }

        private string GetCriteria()
        {


            string strCrits = "From: " + dtFrom.Value.ToShortDateString() + ", To: " + dtTo.Value.ToShortDateString();




            try
            {
                if (this.txtMRP.Text + "" != "")
                {
                    strCrits = strCrits + ", MRP: " + txtMRP.Text;
                }
            }
            catch (Exception)
            {


            }



            try
            {
                if (this.txtCustomer.Text + "" != "")
                {
                    strCrits = strCrits + ", Customer: " + txtCustomer.Text;
                }
            }
            catch (Exception)
            {


            }

            try
            {
                if (this.ddlType.SelectedValue.ToString() != "0")
                {
                    strCrits = strCrits + ", Type: " + ddlType.Text;
                }
            }
            catch (Exception)
            {


            }


            string strCriteria = "Criteria: " + strCrits;

            return strCriteria;


        }

        private void ddlReport_SelectionChangeCommitted(object sender, EventArgs e)
        {



            if (this.ddlReport.SelectedValue.ToString() != "0")
            {

                Int32 intRPID = Convert.ToInt32(this.ddlReport.SelectedValue.ToString());

                switch (intRPID)
                {




                    case 26:

                        this.pictureBox1.Image = RexVOIS3.Properties.Resources.Report26;

                        break;

                    case 27:

                        this.pictureBox1.Image = RexVOIS3.Properties.Resources.Report27;



                        break;

                    case 32:

                        this.pictureBox1.Image = RexVOIS3.Properties.Resources.Report32;

                        break;

                    case 52:

                        SelectNone();

                        //select if ZMRN
                        try
                        {
                            foreach (DataGridViewRow row in gv1.Rows)
                            {
                                if (gv1.Rows[row.Index].Cells["PBD_Desc"].Value.ToString().Contains("ZMNR"))
                                {
                                    gv1.Rows[row.Index].DefaultCellStyle.BackColor = Color.Yellow;
                                    gv1.Rows[row.Index].Cells["Select"].Value = "Un Select";
                                }

                            }

                        }
                        catch (Exception ex)
                        {
                            this.Cursor = Cursors.Default;
                        }

                        return;

                        break;



                }




                var qry = from ct in dbRexroth.tblReportOption
                          where ct.RPID == intRPID
                          select ct;

                foreach (Control ctl in panel1.Controls)
                {
                    try
                    {
                        if (ctl is System.Windows.Forms.Label)
                        {

                        }
                        else
                        {
                            ctl.Enabled = false;
                            ctl.BackColor = Color.Gainsboro;
                        }
                    }
                    catch (Exception)
                    {

                    }

                }

                foreach (var ctltxt in qry)
                {
                    foreach (Control ctl in panel1.Controls)
                    {
                        try
                        {
                            if (ctltxt.RPO_Desc == ctl.Name)
                            {
                                ctl.Enabled = true;
                                ctl.BackColor = Color.White;
                            }
                        }
                        catch (Exception)
                        {

                        }

                    }
                }
            }

        }

        private void frmReport_Shown(object sender, EventArgs e)
        {
            BindGrid(0, gv1);

            SelectAll();
        }

        private void SelectAll()
        {
            lnkSelAll.Text = "Select NONE";

            try
            {
                foreach (DataGridViewRow row in gv1.Rows)
                {
                    gv1.Rows[row.Index].DefaultCellStyle.BackColor = Color.Yellow;
                    gv1.Rows[row.Index].Cells["Select"].Value = "Un Select";

                }

            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void SelectGroup()
        {
            SelectNone();

            try
            {
                Int32 intDV = gv1.Columns["PBDVID"].Index;

                foreach (DataGridViewRow row in gv1.Rows)
                {
                    if (row.Cells[intDV].Value.ToString() == this.ddlPBDVID.SelectedValue.ToString())
                    {
                        gv1.Rows[row.Index].DefaultCellStyle.BackColor = Color.Yellow;
                        gv1.Rows[row.Index].Cells["Select"].Value = "Un Select";
                    }

                }

            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void SelectNone()
        {
            lnkSelAll.Text = "Select ALL";
            try
            {
                foreach (DataGridViewRow row in gv1.Rows)
                {
                    gv1.Rows[row.Index].Cells["Select"].Value = "Select";

                    if (row.Index % 2 == 0)
                    {
                        gv1.Rows[row.Index].DefaultCellStyle.BackColor = gv1.DefaultCellStyle.BackColor;
                    }
                    else
                    {
                        gv1.Rows[row.Index].DefaultCellStyle.BackColor = gv1.AlternatingRowsDefaultCellStyle.BackColor;
                    }
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void lnkSelAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.ddlPBDVID.SelectedValue = 0;

            if (lnkSelAll.Text == "Select ALL")
            {
                SelectAll();
            }
            else
            {
                SelectNone();
            }
        }

        private void txtMaterial_TextChanged(object sender, EventArgs e)
        {
            TestDateEnable();
        }

        private void TestDateEnable()
        {
            if (this.txtMaterial.Text.ToString() + "" != "" || this.txtZMNR.Text.ToString() + "" != "")
            {
                this.dtFrom.Enabled = false;
                this.dtTo.Enabled = false;
                SelectAll();
                this.gv1.Enabled = false;
                this.lnkSelAll.Enabled = false;
            }
            else
            {
                this.dtFrom.Enabled = true;
                this.dtTo.Enabled = true;
                this.gv1.Enabled = true;
                this.lnkSelAll.Enabled = true;
            }
        }

        private void txtZMNR_TextChanged(object sender, EventArgs e)
        {
            TestDateEnable();
        }

        private void ddlPBDVID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SelectGroup();
        }

    }
}
