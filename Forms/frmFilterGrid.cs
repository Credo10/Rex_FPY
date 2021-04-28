using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.Linq;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRLData;
using VisualData;
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Data.Entity.Core.Objects;

namespace RexVOIS3
{
    public partial class frmFilterGrid : clsForm
    {
        Boolean fChanges = false;
        HRLEntities db = clsStart.efdb();
        HRLEntities db2 = clsStart.efdb();
        VisualEntities dbVisual = clsStart.efdbVisual();
        BindingSource bs1 = new BindingSource();
        BindingSource bs2 = new BindingSource();
        List<DataGridViewCell> cells = new List<DataGridViewCell>();
        DataGridViewCell cell;
        Int32 intFindTotal = 0;
        Int32 intFindPosition = 0;
        Boolean fImpersonate = false;
        string strOut = "";
        string strPRPIDs = "";
        private List<tblAppColumns> properties;
        string strRpt = "";
        int[] lstService = new int[] { 34, 44, 52 };
        //int[] lstProtoAdmin = new int[] { 52 };

        public frmFilterGrid()
        {
            InitializeComponent();
        }

        #region "FormEvents"

        private void frmCredoMD_Load(object sender, EventArgs e)
        {

            List<p_DropDown_Result> qOPID = db.p_DropDown(this.APPID, this.tblNav.NAVID, "APOPID", "", this.Associate.ASID).ToList<p_DropDown_Result>();
            ddlOption.DataSource = clsDropDownUtil.AddDropItem(qOPID, "--Print Options--");
            ddlOption.DisplayMember = "Display";
            ddlOption.ValueMember = "ID";

            List<p_DropDown_Result> qAssociate = db.p_DropDown(this.APPID, this.tblNav.NAVID, "ASID_PB", "", this.Associate.ASID).ToList<p_DropDown_Result>();
            ddlAssociate.DataSource = clsDropDownUtil.AddDropItem(qAssociate, "--Select Task Owner--");
            ddlAssociate.DisplayMember = "Display";
            ddlAssociate.ValueMember = "ID";

        }

        private void frmCredoMD_FormClosing(object sender, FormClosingEventArgs e)
        {

            string strMsg = UpdateData(false);
            if (strMsg != "")
            {
                string strresult = "Data did not save? \n\n To Close WITHOUT saving, click 'Ok'. \n To attempt to repair your error, click 'Cancel' \n\n\n" + strMsg;
                if (MessageBox.Show(strresult, this.AppName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            };
        }

        private void frmFilterGrid_Shown(object sender, EventArgs e)
        {


            this.gv1.Columns.Clear();
            this.Refresh();
            ResetCriteria(true);


            if (this.APPID == 6 && this.tblNav.NAVID != 269) //PB tracking
            {
                this.pnlPB.Visible = true;
                this.chkOpen.Checked = true;
                this.chkOpen.Visible = true;

                if (this.Associate.ARID == 30)//user
                {
                    this.chkOnly.Checked = true;
                    this.chkOnly.Visible = true;
                    this.lnkNew.Visible = false;
                }
                else if (lstService.Contains(this.Associate.ARID)) //service, prototype, protoadmin
                {
                    this.chkOnly.Checked = true;
                    this.chkOnly.Visible = true;
                    this.lnkNew.Visible = true;
                }
                else
                {
                    this.chkOnly.Visible = true;
                    this.lnkNew.Visible = true;
                    this.lblAssociate.Visible = true;
                    ddlAssociate.Visible = true;
                }

                //if use can impersonate then load the ddl with that
                if(ddlAssociate.Visible == false)
                {
                    try
                    {
                        var q = (from ct in db.tblPBProxy
                                 where ct.ASID == this.Associate.ASID
                                 select ct).First();

                        ddlAssociate.DataSource = null;
                        List<p_DropDown_Result> qAssociate = db.p_DropDown(this.APPID, this.tblNav.NAVID, "ASID_Impersonate", "", this.Associate.ASID).ToList<p_DropDown_Result>();
                        ddlAssociate.DataSource = clsDropDownUtil.AddDropItem(qAssociate, "--Select Task Owner--");
                        ddlAssociate.DisplayMember = "Display";
                        ddlAssociate.ValueMember = "ID";
                        this.lblAssociate.Visible = true;
                        ddlAssociate.Visible = true;
                        lblAssociate.Text = "Impersonate For:";
                        fImpersonate = true;
                        
                    }
                    catch (Exception)
                    {

                      
                    }
                }


            }
            else
            {
                this.chkOnly.Visible = false;
                this.lnkNew.Visible = false;
            }

            SetupChecks();
            SetFilterHeight();

            SetHeaderColor();

            try
            {
                gv2.Columns["|"].Visible = false;
            }
            catch (Exception)
            {

                
            }

        }

        private void SetFilterHeight()
        {
            try
            {

                int intCell = 10;
                if (this.tblNav.NAVID == 269)
                {
                    intCell = 3;
                }


                var Cell = gv2.GetCellDisplayRectangle(intCell, 0, true);
                Int32 intBottom = Cell.Bottom;
                Int32 intTop = gv2.Top;
                Int32 intHeight = intBottom - intTop;
                if (intHeight > 0)
                {
                    pnlFilter.Size = new Size(pnlFilter.Width, intHeight + 5);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private string GetCriteria()
        {
            string strCriteria = "Criteria: ";
            string strCell = "";

            foreach (DataGridViewCell cell in gv2.Rows[0].Cells)
            {
                try
                {
                    if (cell.Value.ToString() + "" != "" && cell.Value.ToString() != gv2.Columns[cell.ColumnIndex].HeaderText.ToString())
                    {

                        strCell = cell.FormattedValue.ToString();

                        if (strCell == "*")
                        {
                            strCell = "(NO Blanks)";
                        }

                        if (strCell == "#")
                        {
                            strCell = "(Blanks)";
                        }
                        //}


                        if (gv2.Columns[cell.ColumnIndex].HeaderText.ToString() == "Sch Release" && strRpt == "34") //OTD Performance
                        {
                            strCriteria = strCriteria + "  Sch Release, Or Sch Start or Sch Finish: " + strCell;

                        }
                        else
                        {
                            strCriteria = strCriteria + "   " + gv2.Columns[cell.ColumnIndex].HeaderText.ToString() + ": " + strCell;
                        }

                    }
                }
                catch (Exception ex)
                {

                }
            }

            Debug.Print("Criteria = " + strCriteria);
            return strCriteria;
        }



        #endregion

        #region "Grid Events"

        private void ResetCriteria(Boolean fReset)
        {

            this.Cursor = Cursors.WaitCursor;

            string strClear = "";

            if (fReset)
            {
                strClear = "Default";

            }
            else
            {
                strClear = "Clear";
            }

            try
            {


                db.p_tblAppFilter(this.Token, this.tblNav.NAV_GV2, "gv2", strClear);

                var qry = (from ct in db2.tblAppFilter
                           where ct.AFLT_GV == "gv2"
                           && ct.AFLT_Token == this.Token
                           && ct.NAVID == this.tblNav.NAV_GV2
                           select ct).ToList();

                BindGridData(qry, gv2);

                if (fReset)
                {
                    BindGrid(0, gv1);
                }
                else
                {
                    gv1.DataSource = null;
                }


            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
            }

            this.Cursor = Cursors.Default;
        }

        public void BindGrid(Int32 intID, DataGridView gv)
        {

            this.Cursor = Cursors.WaitCursor;

            GetSelected();


            if (this.chkOmit.Checked == false)
            {

                this.Cursor = Cursors.WaitCursor;

                try
                {

                    UpdateData(false);

                    int? intNAVID = this.tblNav.NAVID;

                    string strDate = DateTime.Now.ToShortDateString() + "  " + DateTime.Now.ToShortTimeString();

                    //this.lblStatus.Text = "Last Updated " + strDate;

                    switch (this.tblNav.NAVID)
                    {

                        case 18:

                            //string strRpt = this.ddlReport.SelectedValue.ToString();
                            //string strOpt = this.ddlOption.SelectedValue.ToString();

                            string strSQL = "p_PullPartDisplay '" + this.Token + "', '0','0'"; // + strRpt + "', '" + strOpt + "'"; 
                            Debug.WriteLine(strSQL);

                            DataSet ds = clsDAL.ProcessSQL(strSQL, "APP");

                            BindGridDataGV1(ds.Tables[0], gv);

                            SetSelected();
                            SetExpeditedColor();

                            this.gv1.ReadOnly = true;

                            gv2.CurrentCell = null;
                            gv1.CurrentCell = null;

                            Int32 intCol = gv1.Columns["Select"].Index;

                            gv1.Columns[intCol].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                            this.Cursor = Cursors.Default;

                            break;

                        case 86:

                            string strMyOnly = this.chkOnly.Checked.ToString();
                            string strOpen = this.chkOpen.Checked.ToString();
                            string strASID = this.ddlAssociate.SelectedValue.ToString();

                            string strSQL86 = "p_tblPBTracking_FilterGrid_v3 '" + this.Token + "', '" + strMyOnly + "', '" + strOpen + "', '" + strASID + "', '" + this.Associate.ASID.ToString() + "'";

                            Debug.WriteLine(strSQL86);

                            DataSet ds86 = clsDAL.ProcessSQL(strSQL86, "APP");

                            if (clsUtility.dsHasData(ds86))
                            {
                                var results = (from myRow in ds86.Tables[0].AsEnumerable()
                                               select myRow.Field<int>("PBID")).ToList();

                                HRLEntities db3 = clsStart.efdb();

                                var qry = from ct in db3.vwPBTracking
                                          where results.Contains(ct.PBID)
                                          select ct;

                                if (intID > 0)
                                {
                                    qry = qry.OrderByDescending(w => w.PBID == intID).ThenBy(y => y.PBID);
                                }
                                else
                                {
                                    qry = qry.OrderBy(y => y.PBID);
                                }

                                var qry2 = (from ct in qry
                                            select ct).ToList();

                                BindGridData(qry2, gv1);
                            }
                            else
                            {
                                gv1.DataSource = null;
                            }


                            SetSelected();
                            SetExpeditedColor();

                            gv1.Columns[7].Frozen = true;
                            gv2.Columns[7].Frozen = true;

                            gv2.CurrentCell = null;
                            gv1.CurrentCell = null;

                            if (this.Associate.ARID == 30)//user 
                            {
                                gv1.Columns["lnkDel"].Visible = false;
                            }

                            this.Cursor = Cursors.Default;

                            break;

                        case 145:

                            //string strRpt = this.ddlReport.SelectedValue.ToString();
                            //string strOpt = this.ddlOption.SelectedValue.ToString();

                            string strSQL145 = "p_tblTestStand_FilterGrid '" + this.Token + "', '0','0'"; // + strRpt + "', '" + strOpt + "'"; 
                            Debug.WriteLine(strSQL145);

                            DataSet ds145 = clsDAL.ProcessSQL(strSQL145, "APP");


                            if (clsUtility.dsHasData(ds145))
                            {
                                var results = (from myRow in ds145.Tables[0].AsEnumerable()
                                               select myRow.Field<int>("TDID")).ToList();

                                var qry = from ct in db.vwTestStand
                                          where results.Contains(ct.TDID)
                                          orderby ct.THID, ct.TSID, ct.TDID
                                          select ct;


                                var qry2 = (from ct in qry
                                            select ct).ToList();

                                BindGridData(qry2, gv1);
                            }
                            else
                            {
                                gv1.DataSource = null;
                            }

                            this.gv1.ReadOnly = true;

                            gv2.CurrentCell = null;
                            gv1.CurrentCell = null;

                            this.Cursor = Cursors.Default;

                            break;

                        case 192:

                            //string strRpt = this.ddlReport.SelectedValue.ToString();
                            //string strOpt = this.ddlOption.SelectedValue.ToString();

                            string strSQL192 = "p_tblWarranty_FilterGrid '" + this.Token + "', '0','0'"; // + strRpt + "', '" + strOpt + "'"; 
                            Debug.WriteLine(strSQL192);

                            DataSet ds192 = clsDAL.ProcessSQL(strSQL192, "APP");


                            if (clsUtility.dsHasData(ds192))
                            {
                                var results = (from myRow in ds192.Tables[0].AsEnumerable()
                                               select myRow.Field<int>("WARID")).ToList();

                                var qry = from ct in db.vwWarrantyShowLast
                                          where results.Contains(ct.WARID)
                                          select ct;


                                var qry2 = (from ct in qry
                                            select ct).ToList();

                                BindGridData(qry2, gv1);
                            }
                            else
                            {
                                gv1.DataSource = null;
                            }

                            this.gv1.ReadOnly = true;

                            gv2.CurrentCell = null;
                            gv1.CurrentCell = null;

                            this.Cursor = Cursors.Default;

                            break;

                        case 269:


                            string strSQL269 = "p_tblPartBOMComp_FilterGrid '" + this.Token + "', '0','0'"; // + strRpt + "', '" + strOpt + "'"; 
                            Debug.WriteLine(strSQL269);

                            DataSet ds269 = clsDAL.ProcessSQL(strSQL269, "Visual");


                            if (clsUtility.dsHasData(ds269))
                            {
                                var results = (from myRow in ds269.Tables[0].AsEnumerable()
                                               select myRow.Field<int>("BCID")).ToList();

                                var qry = from ct in dbVisual.tblPartBOMComp
                                          where results.Contains(ct.BCID)
                                          select ct;


                                var qry2 = (from ct in qry
                                            select ct).ToList();

                                BindGridData(qry2, gv1);
                            }
                            else
                            {
                                gv1.DataSource = null;
                            }



                            gv2.CurrentCell = null;
                            gv1.CurrentCell = null;

                            this.Cursor = Cursors.Default;

                            break;
                    }
                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                }

            }

            this.Cursor = Cursors.Default;
        }

        public void BindGridData<T>(IEnumerable<T> result, DataGridView gv)
        {

            if (!(gv.Columns.Count > 0) || (this.APPID == 6 && this.tblNav.NAVID != 269)) //pb tracking...not sure why we had regen each time for PB
            {
                gv.Columns.Clear();
                gv.AutoGenerateColumns = false;
                gv.AllowUserToAddRows = false;
                gv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                try
                {

                    Int32 intNAVID = 0;

                    if (gv.Name == "gv1")
                    {
                        intNAVID = this.tblNav.NAVID;

                        List<tblAppColumns> properties = (from col in db.tblAppColumns
                                                          where col.NAVID == intNAVID
                                                          && col.APC_Grid == gv.Name
                                                          orderby col.APC_Order
                                                          select col).ToList<tblAppColumns>();

                        foreach (var property in properties)
                        {

                            clsGridUtil.AddColumns(gv, this.tblNav.NAVID, property, db, this.APPID, this.APPID, this.Associate.ASID);

                        }

                        if (this.APPID == 6 && this.tblNav.NAVID != 269) //PB tracking
                        {
                            if (this.Associate.ARID < 30)//menu / admin
                            {
                                gv1.Columns["PBID"].ReadOnly = false;
                                gv1.Columns["PB2ID"].ReadOnly = false;
                            }
                        }
                    }
                    else
                    {
                        intNAVID = Convert.ToInt32(this.tblNav.NAV_GV2);

                        List<vwAppColumnFilterFields> qry2 = (from col in db.vwAppColumnFilterFields
                                                              where col.NAVID == this.tblNav.NAVID
                                                              && col.APC_Grid == gv.Name
                                                              orderby col.APC_Order
                                                              select col).ToList<vwAppColumnFilterFields>();



                        List<tblAppColumns> properties = qry2
                        .Select(x => new tblAppColumns()
                        {
                            APC_Default = x.APC_Default,
                            APC_QueryField = x.APC_QueryField,
                            APC_Deleted = x.APC_Deleted,
                            APC_Desc = x.APC_Desc,
                            APC_Name = x.APC_Name,
                            APC_Grid = x.APC_Grid,
                            APC_Order = x.APC_Order,
                            APC_ReadOnly = x.APC_ReadOnly,
                            APC_Width = x.APC_Width,
                            APCID = x.APCID,
                            APCOID = x.APCOID,
                            NAVID = x.NAVID
                        })
                        .ToList<tblAppColumns>();

                        foreach (var property in properties)
                        {

                            clsGridUtil.AddColumns(gv, intNAVID, property, db, this.APPID, this.APPID, this.Associate.ASID);


                        }

                    }
                }
                catch (Exception ex)
                {

                }
            }

            try
            {
                gv.DataSource = null;
                gv.DataSource = result;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.AppName);
                return;
            }
        }

        public void BindGridDataGV1(System.Data.DataTable result, DataGridView gv)
        {

            if (!(gv.Columns.Count > 0))
            {
                gv.Columns.Clear();
                gv.AutoGenerateColumns = false;
                gv.AllowUserToAddRows = false;
                gv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;


                try
                {


                    List<tblAppColumns> properties = (from col in db.tblAppColumns
                                                      where col.NAVID == this.tblNav.NAVID
                                                      && col.APC_Grid == gv.Name
                                                      orderby col.APC_Order
                                                      select col).ToList<tblAppColumns>();

                    foreach (var property in properties)
                    {

                        clsGridUtil.AddColumns(gv, this.tblNav.NAVID, property, db, this.APPID, this.APPID, this.Associate.ASID);

                    }


                }
                catch (Exception ex)
                {

                }
            }

            try
            {
                gv.DataSource = null;
                gv.DataSource = result;
                //SetGridColor();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.AppName);
                return;
            }
        }


        private void SetupChecks()
        {

            if (this.APPID == 6 && this.tblNav.NAVID != 269) //PB Tracking
            {
                if (chkOpen.Checked == false && chkOnly.Checked == false)
                {
                    try
                    {
                        gv2.Rows[0].Cells["F6"].Value = "0";
                        gv2.Rows[0].Cells["F12"].Value = "";
                    }
                    catch (Exception ex)
                    {

                    }
                    gv2.Refresh();
                    UpdateData(false);
                }


                //Per Team Review 5/4/2016, set Status to "--ALL--"
                if (chkOpen.Checked == false && chkOnly.Checked == true)
                {
                    try
                    {
                        gv2.Rows[0].Cells["F6"].Value = "0";
                        gv2.Rows[0].Cells["F12"].Value = "";
                    }
                    catch (Exception ex)
                    {

                    }
                    gv2.Refresh();
                    UpdateData(false);
                }

                //Per Team Review 5/4/2016, set Status to "--ALL--"
                if (chkOpen.Checked == true && chkOnly.Checked == true)
                {
                    try
                    {
                        gv2.Rows[0].Cells["F6"].Value = "-1";
                        gv2.Rows[0].Cells["F12"].Value = this.Associate.AS_Last + ", " + this.Associate.AS_First;
                    }
                    catch (Exception ex)
                    {

                    }
                    gv2.Refresh();
                    UpdateData(false);
                }

                if (this.ddlAssociate.SelectedValue.ToString() + "" != "0")
                {
                    if (chkOpen.Checked == true && chkOnly.Checked == false)
                    {
                        try
                        {
                            Int32 intASID = Convert.ToInt32(this.ddlAssociate.SelectedValue.ToString());

                            var qry = (from ct in db.tblAssociate
                                       where ct.ASID == intASID
                                       select ct).First();

                            gv2.Rows[0].Cells["F6"].Value = "-1";
                            gv2.Rows[0].Cells["F12"].Value = qry.AS_Last + ", " + qry.AS_First;
                        }
                        catch (Exception ex)
                        {

                        }
                        gv2.Refresh();
                        UpdateData(false);
                    }
                }
                else
                {
                    if (chkOpen.Checked == true && chkOnly.Checked == false)
                    {
                        try
                        {
                            gv2.Rows[0].Cells["F6"].Value = "-1";

                        }
                        catch (Exception ex)
                        {

                        }
                        gv2.Refresh();
                        UpdateData(false);
                    }
                }


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



            try
            {
                //added 8-24-16 -- Patrick to pull up warranty comment history.
                if (e.ColumnIndex == gv.Columns["WARC_Comment"].Index)
                {
                    Int32 intECID = clsGridUtil.GetPK(gv1);


                    frmCredoMin frm = new frmCredoMin();
                    frm.Associate = this.Associate;
                    frm.Text = "Comment History";
                    frm.Icon = this.Icon;
                    frm.tblNav = this.tblNav;
                    frm.tblNav.NAVID = 192;
                    frm.ECID = intECID;
                    frm.ShowDialog();


                    return;
                }
            }
            catch (Exception ex)
            {

            }


            try
            {


                if (e.ColumnIndex == gv.Columns["Email"].Index)
                {
                    if (this.tblNav.NAVID == 86)
                    {
                        Int32 intECID = clsGridUtil.GetPK(gv1);
                        frmPBEmail frm = new frmPBEmail();
                        frm.ECID = intECID;
                        frm.Associate = this.Associate;
                        frm.tblNav = this.tblNav;

                        frm.ShowDialog();


                        return;
                    }


                }

            }
            catch (Exception ex)
            {

            }

            try
            {


                if (e.ColumnIndex == gv.Columns["View"].Index)
                {
                    if (this.tblNav.NAVID == 86)
                    {
                        Int32 intECID = clsGridUtil.GetPK(gv1);
                        frmPB frm = new frmPB();

                        if (fImpersonate == true)
                        {
                            int intASID = 0;

                            try
                            {
                                intASID = Convert.ToInt32(this.ddlAssociate.SelectedValue.ToString());

                                var AssociateImp = (from ct in db.vwAssociate
                                                where ct.ASID == intASID
                                                select ct).First();
                                frm.Associate = AssociateImp;
                            }
                            catch (Exception)
                            {
                                frm.Associate = this.Associate;

                            }
                        }
                        else
                        {
                            frm.Associate = this.Associate;
                        }

                        frm.Text = this.Text;
                        frm.Icon = this.Icon;
                        frm.tblNav = this.tblNav;
                        frm.ECID = intECID;

                        if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {

                            BindGrid(0, gv1);
                        }

                        return;
                    }
                    //if (this.tblNav.NAVID == 192)
                    //{
                    //    Int32 intECID = clsGridUtil.GetPK(gv1);
                    //    frmWarranty frm = new frmWarranty();
                    //    frm.Associate = this.Associate;
                    //    frm.Text = "Comment History";
                    //    frm.Icon = this.Icon;
                    //    frm.tblNav = this.tblNav;
                    //    frm.tblNav.NAVID = 192;
                    //    frm.ECID = intECID;


                    //    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    //    {

                    //        BindGrid(0, gv1);
                    //    }

                    //}

                }

            }
            catch (Exception ex)
            {

            }
            try
            {


                if (e.ColumnIndex == gv.Columns["PB2ID"].Index)
                {
                    Int32 intPBID = Convert.ToInt32(gv1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());

                    if (this.tblNav.NAVID == 86)
                    {
                        Int32 intECID = intPBID;
                        frmPB frm = new frmPB();
                        if (fImpersonate == true)
                        {
                            int intASID = 0;

                            try
                            {
                                intASID = Convert.ToInt32(this.ddlAssociate.SelectedValue.ToString());

                                var AssociateImp = (from ct in db.vwAssociate
                                                    where ct.ASID == intASID
                                                    select ct).First();
                                frm.Associate = AssociateImp;
                            }
                            catch (Exception)
                            {
                                frm.Associate = this.Associate;

                            }
                        }
                        else
                        {
                            frm.Associate = this.Associate;
                        }
                        frm.Text = this.Text;
                        frm.Icon = this.Icon;
                        frm.tblNav = this.tblNav;
                        frm.ECID = intECID;

                        if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {

                            BindGrid(0, gv1);
                        }

                        return;
                    }


                }

            }
            catch (Exception ex)
            {

            }


            //if service user only allow them to delete their entries. 
            try
            {
                if (e.ColumnIndex == gv.Columns["lnkDel"].Index)
                {
                    if (lstService.Contains(this.Associate.ARID)) //service, prototype, protoadmin
                    {
                        if (gv.Rows[e.RowIndex].Cells["ASID"].Value.ToString() != this.Associate.ASID.ToString())
                        {
                            MessageBox.Show("You can't delete this record, it was created by someone else.", "PB Tracking");
                            return;
                        }
                        else if (gv.Rows[e.RowIndex].Cells["ASID"].Value.ToString() == this.Associate.ASID.ToString() && gv.Rows[e.RowIndex].Cells["PBSID"].Value.ToString() != "7") //they created but it's not the Created status
                        {
                            MessageBox.Show("You can't delete this record. It is not in the Created status.", "PB Tracking");
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

            #region "Deletes"
            try
            {
                if (gv.Columns[e.ColumnIndex].Tag.ToString() == "10")
                {
                    try
                    {

                        if (MessageBox.Show("Delete this Row?", "Credo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {


                            Int32 intDel = 0;

                            foreach (DataGridViewColumn col in gv.Columns)
                            {
                                if (col.Name.EndsWith("Deleted"))
                                {

                                    Int32 intPK = clsGridUtil.GetPK(gv1);

                                    string strSQL = "UPDATE tblPBTracking SET PB_Deleted = '" + Convert.ToString(DateTime.Now) + "' WHERE PBID=" + intPK.ToString();

                                    clsDAL.ExecuteSQL(strSQL, "HRL");

                                    Int32 intRow = gv.CurrentRow.Index;

                                    gv.CurrentCell = null;
                                    gv.Rows[intRow].Visible = false;

                                    return;

                                }
                            }


                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Credo");
                    }

                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message.ToString());
            }
            #endregion


            Boolean fHandled = clsGridUtil.Grid_CellClick(gv, e); //handle common tasks


            //if (fHandled == false)
            //{


            //}

        }

        private void gv2_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            //this is need to commit the dropdown value to be saved
            try
            {

                DataGridViewComboBoxCell cbo = (DataGridViewComboBoxCell)gv2.CurrentCell;

                if (gv2.IsCurrentCellDirty)
                {
                    gv2.CommitEdit(DataGridViewDataErrorContexts.Commit);

                    //string strVal = cbo.Value.ToString();
                    BindGrid(0, gv1);
                }

            }
            catch (Exception ex)
            {

            }

        }

        private void gv2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            //this is good to determine if a non dropdown cell has changed values
            string strVal = "";

            try
            {
                strVal = gv2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                gv2.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.AliceBlue;
            }
            catch (Exception ex)
            {
                gv2.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Beige;
            }

            BindGrid(0, gv1);


        }

        private void gv2_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                gv1.Columns[e.Column.Index].Width = gv2.Columns[e.Column.Index].Width;
            }
            catch (Exception ex)
            {

            }
        }

        private void gv1_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {


                this.pnlDates.Visible = false;
                if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
                {
                    gv2.HorizontalScrollingOffset = e.NewValue;
                }

                gv2.Columns["|"].Visible = true;

            }
            catch (Exception ex)
            {

            }
        }

        private void gv2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {

                try
                {

                    if (gv2.Columns[e.ColumnIndex].Tag.ToString() == "20") //Date Filer Link
                    {

                        lnkCancel.Text = "Cancel";
                        this.dtStart.Value = DateTime.Today.AddMonths(-1);
                        this.dtEnd.Value = DateTime.Today;
                        string strCol = gv2.Columns[e.ColumnIndex].HeaderText;
                        cell = gv2.CurrentCell;
                        string strDate = cell.Value.ToString();
                        System.Drawing.Rectangle rec = new System.Drawing.Rectangle();
                        rec = gv2.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                        pnlDates.Left = rec.Left - 1;
                        pnlDates.Top = gv1.Top;
                        this.pnlDates.Show();

                        if (cell.Value.ToString() == "(Blanks)")
                        {
                            lnkDateOmit.Text = "Show All";
                        }
                        else
                        {
                            lnkDateOmit.Text = "Show Blanks";
                        }


                        dtStart.Value = Convert.ToDateTime(cell.Tag.ToString());
                        dtEnd.Value = Convert.ToDateTime(cell.ToolTipText.ToString());
                        //lnkCancel.Text = "Clear Filter";
                    }

                    if (gv2.Columns[e.ColumnIndex].Tag.ToString() == "22") //Select Filer Link
                    {
                        if (gv2[e.ColumnIndex, e.RowIndex].Value.ToString() == "Select All")
                        {
                            gv2[e.ColumnIndex, e.RowIndex].Value = "Select None";
                            SetSelectedAll();
                        }
                        else
                        {
                            gv2[e.ColumnIndex, e.RowIndex].Value = "Select All";
                            SetDeSelected();
                        }
                        gv2.CurrentCell = null;
                    }

                }
                catch (Exception ex)
                {

                }
            }

        }

        private void gv2_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            try
            {
                this.Cursor = Cursors.WaitCursor;

                int intCol = e.ColumnIndex;

                foreach (DataGridViewColumn col in gv1.Columns)
                {
                    gv2.Columns[col.Index].HeaderCell.SortGlyphDirection = SortOrder.None;
                }

                DataGridViewColumn oldColumn = gv1.SortedColumn;
                ListSortDirection direction;

                // If oldColumn is null, then the DataGridView is not currently sorted. 
                if (oldColumn != null)
                {
                    // Sort the same column again, reversing the SortOrder. 
                    if (oldColumn.Index == intCol)
                    {
                        if (gv1.SortOrder == SortOrder.Ascending)
                        {
                            this.gv1.Sort(this.gv1.Columns[intCol], ListSortDirection.Descending);
                            gv2.Columns[intCol].HeaderCell.SortGlyphDirection = SortOrder.Descending;
                        }
                        else
                        {
                            this.gv1.Sort(this.gv1.Columns[intCol], ListSortDirection.Ascending);
                            gv2.Columns[intCol].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                        }
                    }
                    else
                    {
                        this.gv1.Sort(this.gv1.Columns[intCol], ListSortDirection.Ascending);
                        gv2.Columns[intCol].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                    }
                }
                else
                {
                    this.gv1.Sort(this.gv1.Columns[intCol], ListSortDirection.Ascending);
                    gv2.Columns[intCol].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                }

                this.Cursor = Cursors.Default;

            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
            }

            SetExpeditedColor();
        }

        private void SetHeaderColor()
        {

            try
            {

                foreach (DataGridViewCell cell in gv2.Rows[0].Cells)
                {
                    try
                    {
                        DataGridViewLinkCell links = (DataGridViewLinkCell)cell;
                        gv2.Rows[0].Cells[links.ColumnIndex].Style.BackColor = Color.Beige;
                        if (gv2.Rows[0].Cells[links.ColumnIndex].Value.ToString() != gv2.Columns[links.ColumnIndex].HeaderText)
                        {
                            links.LinkColor = Color.Olive;
                            gv2.Rows[0].Cells[links.ColumnIndex].Style.BackColor = Color.AliceBlue;
                        }
                        else
                        {
                            links.LinkColor = Color.Blue;
                        }
                    }
                    catch (Exception ex)
                    {

                    }

                    try
                    {
                        DataGridViewComboBoxCell links = (DataGridViewComboBoxCell)cell;
                        //gv2.Rows[0].Cells[links.ColumnIndex].Style.BackColor = Color.Beige;
                        if (gv2.Rows[0].Cells[links.ColumnIndex].Value.ToString() != gv2.Columns[links.ColumnIndex].HeaderText & gv2.Rows[0].Cells[links.ColumnIndex].Value.ToString() != "ALL" & gv2.Rows[0].Cells[links.ColumnIndex].Value.ToString() != "3")
                        {
                            //links.LinkColor = Color.Olive;
                            gv2.Rows[0].Cells[links.ColumnIndex].Style.BackColor = Color.AliceBlue;
                        }
                        else
                        {
                            //links.LinkColor = Color.Blue;
                        }
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

        private void SetSelectedAll()
        {
            try
            {
                Int32 intCol = gv1.Columns["Select"].Index;
                Int32 intCol2 = gv1.PK;
                strPRPIDs = "";


                var strForeLink = (from ct in gv1.Rows.Cast<DataGridViewRow>()
                                   select ct.Cells[intCol2]).ToList();

                foreach (DataGridViewCell strVal in strForeLink)
                {
                    strPRPIDs = strPRPIDs + ", " + strVal.Value.ToString();
                    gv1[intCol, strVal.RowIndex].Value = "Un Select";
                    gv1.Rows[strVal.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void SetSelected()
        {
            try
            {
                if (strPRPIDs != "")
                {
                    Int32 intCol = gv1.Columns["Select"].Index;
                    Int32 intCol2 = gv1.PK;

                    var strForeLink = (from ct in gv1.Rows.Cast<DataGridViewRow>()
                                       where strPRPIDs.Contains(ct.Cells[intCol2].Value.ToString())
                                       select ct.Cells[intCol2]).ToList();

                    strPRPIDs = ""; //reset as some rows may not be in this result set

                    foreach (DataGridViewCell strVal in strForeLink)
                    {
                        strPRPIDs = strPRPIDs + ", " + strVal.Value.ToString();
                        gv1[intCol, strVal.RowIndex].Value = "Un Select";
                        gv1.Rows[strVal.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void SetSelectedasStatus(Int32 intSTPID)
        {
            try
            {
                if (strPRPIDs != "")
                {
                    Int32 intCol = gv1.Columns["STP_Desc"].Index;
                    Int32 intCol3 = gv1.Columns["PSP_DateTime"].Index;
                    Int32 intCol2 = gv1.PK;

                    var strForeLink = (from ct in gv1.Rows.Cast<DataGridViewRow>()
                                       where strPRPIDs.Contains(ct.Cells[intCol2].Value.ToString())
                                       select ct.Cells[intCol2]).ToList();




                }
            }
            catch (Exception ex)
            {

            }
        }

        private void SetDeSelected()
        {
            try
            {

                Int32 intCol = gv1.Columns["Select"].Index;
                strPRPIDs = "";

                foreach (DataGridViewRow row in gv1.Rows)
                {
                    gv1[intCol, row.Index].Value = "Select";
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

            }
        }

        private string GetSelected()
        {

            try
            {
                strPRPIDs = "";
                Int32 intCol = gv1.Columns["Select"].Index;
                Int32 intCol2 = gv1.PK;

                var strForeLink = (from ct in gv1.Rows.Cast<DataGridViewRow>()
                                   where ct.Cells[intCol].Value.ToString() == "Un Select"
                                   select ct.Cells[intCol2]).ToList();

                foreach (DataGridViewCell strVal in strForeLink)
                {
                    strPRPIDs = strPRPIDs + ", " + strVal.Value.ToString();
                }
            }
            catch (Exception ex)
            {

            }

            return strPRPIDs;
        }

        private void gv2_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void SetExpeditedColor()
        {
            try
            {

                Int32 intCol = gv1.Columns["PRP_Expedite"].Index;
                Int32 intCol2 = gv1.PK;
                Int32 intCol3 = gv1.Columns["PullLate"].Index;
                Int32 intCol4 = gv1.Columns["STP_Desc"].Index;

                var strForeLink = (from ct in gv1.Rows.Cast<DataGridViewRow>()
                                   where ct.Cells[intCol].Value.ToString() == "True"
                                   select ct.Cells[intCol2]).ToList();

                foreach (DataGridViewCell strVal in strForeLink)
                {
                    gv1.Rows[strVal.RowIndex].Cells[intCol].Style.BackColor = Color.Red;
                    gv1.Rows[strVal.RowIndex].Cells[intCol].Style.ForeColor = Color.White;
                }

                var strForeLate = (from ct in gv1.Rows.Cast<DataGridViewRow>()
                                   where ct.Cells[intCol3].Value.ToString() == "1"
                                   select ct.Cells[intCol2]).ToList();

                foreach (DataGridViewCell strVal in strForeLate)
                {
                    gv1.Rows[strVal.RowIndex].Cells[intCol4].Style.BackColor = Color.Red;
                    gv1.Rows[strVal.RowIndex].Cells[intCol4].Style.ForeColor = Color.White;
                }

            }
            catch (Exception ex)
            {

            }

            try
            {

                Int32 intCol = gv1.Columns["PastDue"].Index;
                Int32 intCol2 = gv1.Columns["PB_Material"].Index;


                var lstPastDue = (from ct in gv1.Rows.Cast<DataGridViewRow>()
                                  where ct.Cells[intCol].Value.ToString() == "1"
                                  select ct.Cells[intCol2]).ToList();

                foreach (DataGridViewCell strVal in lstPastDue)
                {
                    //gv1.Rows[strVal.RowIndex].Cells[intCol2].Style.BackColor = Color.Red;
                    //gv1.Rows[strVal.RowIndex].Cells[intCol2].Style.ForeColor = Color.White;

                    DataGridViewCellStyle style = new DataGridViewCellStyle();
                    style.Font = new System.Drawing.Font(gv1.Font, FontStyle.Bold);
                    style.ForeColor = Color.White;
                    style.BackColor = Color.Red;

                    gv1.Rows[strVal.RowIndex].Cells[intCol2].Style = style;
                }


            }
            catch (Exception ex)
            {

            }
        }


        #endregion

        #region "Data Events"

        private string UpdateData(Boolean fShowMsg)
        {
            this.gv2.EndEdit();
            this.gv1.EndEdit();

            if (this.tblNav.NAVID == 86)
            {
                try
                {

                    if (fChanges == true)
                    {
                        foreach (DataGridViewRow row in gv1.Rows)
                        {
                            try
                            {

                                string strSQL = "UPDATE tblPBTracking SET PB2ID = " + row.Cells["PB2ID"].Value.ToString() + " WHERE PBID =" + row.Cells["PBID"].Value.ToString();
                                clsDAL.ExecuteSQL(strSQL, "HRL");

                            }
                            catch (Exception ex)
                            {

                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }

            try
            {
                db.SaveChanges();

            }

            catch (System.Exception ex)
            {

            }

            try
            {
                db2.SaveChanges();

            }

            catch (System.Exception ex)
            {

            }

            try
            {
                dbVisual.SaveChanges();

            }

            catch (System.Exception ex)
            {

            }


            return "";
        }

        private void gv1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        #endregion

        #region "ButtonEvents"

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateData(true);
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to unto all changes?", this.AppName,
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                       == DialogResult.Yes)
            {

                gv1.EndEdit();

                var context = db;
                var changedEntries = context.ChangeTracker.Entries().Where(x => x.State != System.Data.Entity.EntityState.Unchanged).ToList();

                foreach (var entry in changedEntries.Where(x => x.State == System.Data.Entity.EntityState.Modified))
                {
                    entry.CurrentValues.SetValues(entry.OriginalValues);
                    entry.State = System.Data.Entity.EntityState.Unchanged;
                }

                foreach (var entry in changedEntries.Where(x => x.State == System.Data.Entity.EntityState.Added))
                {
                    entry.State = System.Data.Entity.EntityState.Detached;
                }

                foreach (var entry in changedEntries.Where(x => x.State == System.Data.Entity.EntityState.Deleted))
                {
                    entry.State = System.Data.Entity.EntityState.Unchanged;
                }

                BindGrid(0, gv1);

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            Int32 intPK = 0;

            try
            {
                switch (this.tblNav.NAVID)
                {



                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.AppName);
            }

            BindGrid(intPK, gv1);

            if (this.tblNav.NAVID == 99)
            {
                MessageBox.Show("Highlighted cell is the new record. Replace your name with another Associate.", this.AppName);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            clsExport.ExportViaCopy(gv1, this.tblNav.NAVID);
            //clsExport.ExcelExport(dt, "", true, true);
        }

        private void btn_ToolTip(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Button btn = (System.Windows.Forms.Button)sender;

                if (btn.Tag.ToString().Length > 0)
                {
                    System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
                    ToolTip1.SetToolTip(btn, btn.Tag.ToString());
                }
            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        #region "FindEvents"

        private void btnFindPrevious_Click(object sender, EventArgs e)
        {
            intFindPosition = intFindPosition - 1;
            gvMoveToCell();
        }

        private void btnFindNext_Click(object sender, EventArgs e)
        {
            intFindPosition = intFindPosition + 1;
            gvMoveToCell();
        }

        private void gvMoveToCell()
        {
            gv1.CurrentCell = cells[intFindPosition];

            this.lblFindResults.Text = "(" + (intFindPosition + 1).ToString() + " of " + intFindTotal.ToString() + ")";

            if (intFindPosition == 0)
            {
                btnFindPrevious.Enabled = false;
            }
            else
            {
                btnFindPrevious.Enabled = true;
            }

            if (intFindPosition == intFindTotal - 1)
            {
                btnFindNext.Enabled = false;
            }
            else
            {
                btnFindNext.Enabled = true;
            }
        }

        private void ResetFind()
        {
            this.lblFindResults.Text = "";
            intFindPosition = 0;
            intFindTotal = 0;
            this.btnFindPrevious.Enabled = false;
            this.btnFindNext.Enabled = false;
        }

        private void txtFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {

                    clsGridUtil.ResetCells(gv1, cells);

                    string strFind = this.txtFind.Text.ToString().ToUpper();

                    if (strFind.Trim() + "" != "")
                    {

                        cells = gv1.Rows.Cast<DataGridViewRow>()
                            .SelectMany(row => gv1.Columns.Cast<DataGridViewColumn>()
                            .Select(col => row.Cells[col.Name])
                            .OrderBy(cell => cell.RowIndex))
                            .Where(cell => cell.FormattedValue.ToString().ToUpper().Contains(strFind)
                            && cell.Visible == true)
                            .ToList<DataGridViewCell>();

                        if (cells.Count > 0)
                        {
                            clsGridUtil.ShowFoundCells(gv1, cells);

                            intFindPosition = 0;
                            intFindTotal = cells.Count;

                            this.btnFindPrevious.Enabled = false;

                            if (cells.Count > 1)
                            {
                                this.btnFindNext.Enabled = true;
                            }

                            gvMoveToCell();

                        }
                        else
                        {
                            ResetFind();
                        }

                    }
                    else
                    {
                        ResetFind();
                    }


                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {

            }

        }

        #endregion

        #region "Header Actions"

        private void lnkNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {


            frmAddPB frm = new frmAddPB();
            frm.frmFG = this;
            frm.tblNav = this.tblNav;
            frm.APPID = this.APPID;
            frm.Associate = this.Associate;

            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                Int32 intECID = this.ECID;
                frmPB frm2 = new frmPB();
                frm2.Associate = this.Associate;
                frm2.Text = this.Text;
                frm2.Icon = this.Icon;
                frm2.tblNav = this.tblNav;
                frm2.ECID = intECID;

                if (frm2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    BindGrid(0, gv1);
                }

            }




        }

        private void ddlOption_SelectionChangeCommitted(object sender, EventArgs e)
        {

            if (this.ddlOption.SelectedValue.ToString() == "0")
            {
                this.lnkGetResults.Enabled = false;
            }
            else
            {
                this.lnkGetResults.Enabled = true;
            }


            //if(ddlOption.SelectedValue.ToString() == "2")
            //{ 
            //    Int32 IntCol = gv2.Columns["F42"].Index;
            //    gv2.Rows[0].Cells[IntCol].Tag = "Blank";
            //    gv2.Rows[0].Cells[IntCol].ToolTipText = "Blank";
            //    gv2.Rows[0].Cells[IntCol].Value = "(Blanks)";

            //    SetHeaderColor();
            //}
            //else
            //{

            //    Int32 IntCol = gv2.Columns["F42"].Index;
            //    gv2.Rows[0].Cells[IntCol].Tag = "";
            //    gv2.Rows[0].Cells[IntCol].ToolTipText = "";
            //    gv2.Rows[0].Cells[IntCol].Value = gv2.Columns["F42"].HeaderText;

            //    SetHeaderColor();
            //}

            //BindGrid(0,gv1);
        }

        //private void lnkReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    if (this.ddlReport.SelectedValue.ToString() + "" == "0")
        //    {
        //        MessageBox.Show("Please select a Report.", this.AppName);
        //        return;
        //    }

        //    this.Cursor = Cursors.WaitCursor;

        //    string strXL = "";
        //    string strFileName = "";

        //    GetCriteria();


        //    string strOpt = this.ddlOption.SelectedValue.ToString();
        //    string strRpt = this.ddlReport.SelectedValue.ToString();

        //    string strSQL = "p_GetWOCOOISFinal_v7 '" + this.Token + "', '" + strRpt + "', '" + strOpt + "'";

        //    //DataSet ds = clsDAL.ProcessSQL(strSQL, "Visual");

        //    //try
        //    //{
        //    //    if (!(clsUtility.dsHasData(ds)))
        //    //    {
        //    //        MessageBox.Show("There is no data to export.", "OTD");
        //    //        return;
        //    //    }
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    this.Cursor = Cursors.Default;
        //    //}

        //    string strStartup = System.Windows.Forms.Application.StartupPath.ToString() + @"\Reports\";

        //    switch (ddlReport.SelectedValue.ToString())
        //    {
        //        case "34":
        //            strXL = strStartup + "ReleasePerformance.xlsx";
        //            break;
        //        case "35":
        //            strXL = strStartup + "Throughput.xlsx";
        //            break;
        //        case "36":
        //            strXL = strStartup + "TopLevel.xlsx";
        //            break;
        //        case "37":
        //            strXL = strStartup + "Shortage.xlsx";
        //            break;
        //        case "38":
        //            strXL = strStartup + "FGPerformance.xlsx";
        //            break;
        //        case "39":
        //            strXL = strStartup + "Shortage.xlsx";
        //            break;
        //        case "40":
        //            strXL = strStartup + "Shortage.xlsx";
        //            break;
        //        case "41":
        //            strXL = strStartup + "Shortage.xlsx";
        //            break;
        //    }

        //    strFileName = clsExport.CreateTempFile(strXL);

        //    if (strFileName == "")
        //    {
        //        this.Cursor = Cursors.Default;
        //        return;
        //    }



        //    Workbook workbook;
        //    Worksheet worksheet;
        //    Range range;

        //    try
        //    {

        //        Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.ApplicationClass();
        //        //application.Interactive = false;
        //        workbook = application.Workbooks.Open(strFileName, 0, false, 5, "", "", false, XlPlatform.xlWindows, "", true, false, 0, true, false, false);
        //        workbook.Application.Visible = true;

        //        worksheet = (Worksheet)workbook.Worksheets.get_Item("ChartData");
        //        worksheet.Activate();

        //        this.gv3.Columns.Clear();
        //        this.gv3.DataSource = ds.Tables[0];
        //        this.gv3.AutoGenerateColumns = true;



        //        //RPID	RP_Desc
        //        //34	OTD Performance (uses Sch Release Date Criteria)


        //        switch (ddlReport.SelectedValue.ToString())
        //        {

        //            case "34":

        //                clsExport.ExcelExportExisting(worksheet, ds.Tables[0], 0, 0);

        //                if (this.chkSupport.Checked == true)
        //                {

        //                    worksheet = (Worksheet)workbook.Worksheets.get_Item("ScheduleData");
        //                    worksheet.Activate();

        //                    this.gv3.Columns.Clear();
        //                    this.gv3.DataSource = ds.Tables[1];
        //                    this.gv3.AutoGenerateColumns = true;
        //                    clsExport.ExportViaCopyExisting(worksheet, gv3);

        //                    worksheet = (Worksheet)workbook.Worksheets.get_Item("StartData");
        //                    worksheet.Activate();

        //                    this.gv3.Columns.Clear();
        //                    this.gv3.DataSource = ds.Tables[2];
        //                    this.gv3.AutoGenerateColumns = true;
        //                    clsExport.ExportViaCopyExisting(worksheet, gv3);

        //                    worksheet = (Worksheet)workbook.Worksheets.get_Item("FinishData");
        //                    worksheet.Activate();

        //                    this.gv3.Columns.Clear();
        //                    this.gv3.DataSource = ds.Tables[3];
        //                    this.gv3.AutoGenerateColumns = true;
        //                    clsExport.ExportViaCopyExisting(worksheet, gv3);

        //                }

        //                break;


        //        }

        //        worksheet = (Worksheet)workbook.Worksheets.get_Item("Chart");
        //        worksheet.Activate();
        //        Microsoft.Office.Interop.Excel.Range CRName = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, 1];
        //        CRName.Value = this.ddlReport.Text;
        //        Microsoft.Office.Interop.Excel.Range CRCriteria = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[2, 1];
        //        CRCriteria.Value = GetCriteria();
        //        application.ActiveWindow.Activate();
        //        application.Interactive = true;


        //        this.Cursor = Cursors.Default;

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message.ToString(), this.AppName);
        //        this.Cursor = Cursors.Default;
        //    }

        //}

        private void chkOmit_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOmit.Checked == false)
            {
                string strRun = GetCriteria();
                if (strRun != "Criteria: ")
                {
                    BindGrid(0, gv1);
                }
            }
        }

        private void lnkReset_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetFilterHeight();
            this.chkOpen.Checked = true;
            ResetCriteria(true);

        }

        private void lnkExcel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            clsExport.ExportViaCopy(gv1, this.tblNav.NAVID);
        }

        private void lnkClearAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResetCriteria(false);
        }

        private void lnkGetResults_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Int32 intOption = Convert.ToInt32(this.ddlOption.SelectedValue.ToString());
            string strSQL = "";
            string strPRPIDs = "";
            DataSet ds;

            switch (intOption)
            {

                case 1:



                    strPRPIDs = GetSelected();

                    break;

                case 3:


                    strPRPIDs = GetSelected();


                    break;

                case 4:


                    break;
            }
        }

        #endregion

        #region "Date Panel"

        private void pnlDates_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Rectangle rect = pnlDates.ClientRectangle;
            rect.Width--;
            rect.Height--;
            e.Graphics.DrawRectangle(Pens.DarkKhaki, rect);
        }

        private void lnkCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //if (lnkCancel.Text == "Clear Filter")
            //{
            //    gv2.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Tag = "";
            //    gv2.Rows[cell.RowIndex].Cells[cell.ColumnIndex].ToolTipText = "";
            //    gv2.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Value = gv2.Columns[cell.ColumnIndex].HeaderText;
            //    SetDates();
            //    gv2.CurrentCell.Style.BackColor = Color.Beige;
            //    pnlDates.Visible = false;

            //    BindGrid(0, gv1);
            //}
            //else
            //{
            gv2.CurrentCell.Style.BackColor = Color.Beige;
            pnlDates.Visible = false;
            //}
        }

        private void lnkOk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            gv2.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Tag = dtStart.Value.ToShortDateString();
            gv2.Rows[cell.RowIndex].Cells[cell.ColumnIndex].ToolTipText = dtEnd.Value.ToShortDateString();
            gv2.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Value = dtStart.Value.ToShortDateString() + " ~ " + dtEnd.Value.ToShortDateString();
            gv2.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Style.BackColor = Color.AliceBlue;
            pnlDates.Visible = false;
            this.lnkGetResults.LinkColor = Color.Blue;
        }

        private void lnkDateOmit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (gv2.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Value.ToString() == "(Blanks)")
            {
                gv2.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Tag = "";
                gv2.Rows[cell.RowIndex].Cells[cell.ColumnIndex].ToolTipText = "";
                gv2.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Value = gv2.Columns[cell.ColumnIndex].HeaderText;
                gv2.CurrentCell.Style.BackColor = Color.Beige;
            }
            else
            {
                gv2.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Tag = "Blank";
                gv2.Rows[cell.RowIndex].Cells[cell.ColumnIndex].ToolTipText = "Blank";
                gv2.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Value = "(Blanks)";
                gv2.CurrentCell.Style.BackColor = Color.AliceBlue;
            }

            pnlDates.Visible = false;

            //SetDates();
            this.lnkGetResults.LinkColor = Color.Blue;
            BindGrid(0, gv1);
        }

        private void lnkClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            try
            {
                if (gv2.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Value.ToString() != gv2.Columns[cell.ColumnIndex].HeaderText.ToString()) //nothing to clear
                {
                    gv2.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Tag = "";
                    gv2.Rows[cell.RowIndex].Cells[cell.ColumnIndex].ToolTipText = "";
                    gv2.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Value = gv2.Columns[cell.ColumnIndex].HeaderText;
                    gv2.CurrentCell.Style.BackColor = Color.Beige;


                    DataGridViewLinkColumn links = (DataGridViewLinkColumn)gv2.Columns[cell.ColumnIndex];

                    links.VisitedLinkColor = Color.Blue;

                    pnlDates.Visible = false;

                    //SetDates();
                    this.lnkGetResults.LinkColor = Color.Blue;
                    BindGrid(0, gv1);
                }
                else
                {
                    pnlDates.Visible = false;
                }
            }
            catch (Exception ex)
            {
                pnlDates.Visible = false;
            }
        }

        private void lnkAging_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (gv2.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Value.ToString() == "(Aging)")
            {
                gv2.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Tag = "";
                gv2.Rows[cell.RowIndex].Cells[cell.ColumnIndex].ToolTipText = "";
                gv2.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Value = gv2.Columns[cell.ColumnIndex].HeaderText;
                gv2.CurrentCell.Style.BackColor = Color.Beige;
            }
            else
            {
                gv2.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Tag = "Aging";
                gv2.Rows[cell.RowIndex].Cells[cell.ColumnIndex].ToolTipText = "Aging";
                gv2.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Value = "(Aging)";
                gv2.CurrentCell.Style.BackColor = Color.AliceBlue;
            }

            pnlDates.Visible = false;

            //SetDates();
            this.lnkGetResults.LinkColor = Color.Blue;
            BindGrid(0, gv1);
        }

        #endregion

        private void gv1_DataError_1(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void chkOnly_CheckedChanged(object sender, EventArgs e)
        {




        }

        private void ddlAssociate_SelectionChangeCommitted(object sender, EventArgs e)
        {


            if (this.ddlAssociate.SelectedValue.ToString() != "0")
            {

                this.chkOnly.Visible = false;
                this.chkOnly.Checked = false;

                this.chkOpen.Checked = true;
                this.chkOpen.Visible = true;


            }
            else
            {
                this.chkOnly.Visible = true;
                this.chkOpen.Checked = false;
                this.chkOpen.Visible = false;

            }

            SetupChecks();
            BindGrid(0, gv1);

        }

        private void gv1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            fChanges = true;

            try
            {
                DataGridViewRow row = gv1.CurrentCell.OwningRow;

                try
                {

                    string strSQL = "UPDATE tblPBTracking SET PB2ID = " + row.Cells["PB2ID"].Value.ToString() + " WHERE PBID =" + row.Cells["PBID"].Value.ToString();
                    clsDAL.ExecuteSQL(strSQL, "HRL");

                }
                catch (Exception ex)
                {

                }

            }
            catch (Exception ex)
            {

            }
        }

        private void chkOpen_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkOnly_Click(object sender, EventArgs e)
        {
            if (this.chkOnly.Checked)
            {
                this.chkOpen.Visible = true;
                this.chkOpen.Checked = true;
            }
            else
            {
                this.chkOpen.Visible = false;
                this.chkOpen.Checked = false;
            }

            SetupChecks();

            BindGrid(0, gv1);

        }

        private void chkOpen_Click(object sender, EventArgs e)
        {
            SetupChecks();
            BindGrid(0, gv1);
        }

        private void gv1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right && e.RowIndex != -1)
                {

                    ContextMenuStrip Menu = new ContextMenuStrip();
                    ToolStripMenuItem MenuNewCom = new ToolStripMenuItem("Add Comment");
                    MenuNewCom.Tag = e.RowIndex;

                    Menu.Items.AddRange(new ToolStripItem[] { MenuNewCom });
                    Menu.Show(MousePosition);
                    MenuNewCom.MouseDown += new MouseEventHandler(gv1_AddCommentClick);
                    gv1.Rows[e.RowIndex].Selected = true; //added 9/2/2016

                }
            }


            catch
            {

            }
        }

        private void gv1_AddCommentClick(object sender, MouseEventArgs e)
        {
            try
            {

                var clickedMenuItem = sender as ToolStripDropDownItem;
                var menuText = clickedMenuItem.Text;


                ToolStripDropDownItem itm = (ToolStripDropDownItem)sender;
                DataGridViewCell cell = gv1.Rows[Convert.ToInt32(itm.Tag)].Cells[gv1.Columns["WARC_Comment"].Index];


                int intWO = Convert.ToInt32(gv1.Rows[Convert.ToInt32(itm.Tag)].Cells[gv1.Columns["WARID"].Index].Value.ToString());
                string strWO = gv1.Rows[Convert.ToInt32(itm.Tag)].Cells[gv1.Columns["WAR_Notification"].Index].Value.ToString();

                //TODOCredo

                //frmWarrantyComment f = new frmWarrantyComment(cell, "");//(cell,"");

                //f.Text = strWO;
                //f.Opt = 0;
                //f.ECID = intWO;
                //f.tblNav = this.tblNav;
                //f.Associate= this.Associate;
                ////f.ShowInTaskbar = true;
                ////f.MdiParent = this.MdiParent;
                ////f.ShowDialog();

                //if (f.ShowDialog() == DialogResult.Yes)
                //{


                //}
                int ridx = gv1.CurrentRow.Index;

                gv1.Rows[ridx].Selected = false;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Int32 intASID = Convert.ToInt32(ddlAssociate.SelectedValue.ToString());
            clsUtility.Impersonate(this.APPID, intASID);
        }
    }
}
