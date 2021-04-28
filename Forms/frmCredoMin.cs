using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using HRLData;
using RexrothData;
using Visual;



namespace FPY
{
    public partial class frmCredoMin : clsForm
    {

        HRLEntities db = clsStart.efdb();
        RexrothEntities dbRexroth = clsStart.efdbRexroth();
        VisualEntities dbVisual = clsStart.efdbVisual();
        BindingSource bs1 = new BindingSource();
        List<DataGridViewCell> cells = new List<DataGridViewCell>();
        Int32 intFindTotal = 0;
        Int32 intFindPosition = 0;
        Boolean fEdit = false;
        string strSort = "";

        List<Tuple< int, int, string>> TLine = new List<Tuple< int, int, string>>();

        public class Rewards
        {
            public string Select { get; set; }
            public int Ct { get; set; }
        }

        //change made


        public frmCredoMin()
        {
            InitializeComponent();
        }

        #region "FormEvents"

        private void frmCredoMD_Load(object sender, EventArgs e)
        {

            try
            {
                Color col = clsFormUtil.GetHeaderColor(this.tblNav);

                if (!(col.IsEmpty))
                {
                    this.pnlTop.PageEndColor = col;
                    //set alt rows lighter than header
                    Color col2 = clsFormUtil.AdjustColor(col, 5, true);
                    gv1.AlternatingRowsDefaultCellStyle.BackColor = col2;


                    //set grid background even lighter                    
                    col2 = clsFormUtil.AdjustColor(col2, 2, true);
                    gv1.BackgroundColor = col2;
                    gv1.ColumnHeadersDefaultCellStyle.BackColor = col;


                }
            }
            catch (Exception ex)
            {

            }
        }

        


        private void frmCredoMD_FormClosing(object sender, FormClosingEventArgs e)
        {

            string strMsg = UpdateData(false);
            if (strMsg != "")
            {
                string strresult =
                    "Data did not save? \n\n To Close WITHOUT saving, click 'Ok'. \n To attempt to repair your error, click 'Cancel' \n\n\n" +
                    strMsg;
                if (MessageBox.Show(strresult, this.AppName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) ==
                    DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
            ;

        }

        private void frmCredoMin_Shown(object sender, EventArgs e)
        {
            btnAdd.Tag = "Add New " + this.Text.ToString();

            var qry = new Dictionary<int, string>();

           
            pnlFilter.Visible = false;


            var lstNew = new int[] {78, 260, 310, 321, 300};

            var lstAssociate = new int[] {1, 2, 14};


            if (lstNew.Contains(this.tblNav.NAVID))
            {
                this.btnAdd.Visible = false;
                this.btnSave.Visible = false;
                this.btnUndo.Visible = false;
            }


            var lstNav = new int[] {1, 2, 3, 4, 5, 8, 9, 13, 71, 255, 256, 300, 310, 322};

            if (lstNav.Contains(this.tblNav.NAVID))
            {
                this.pnlFind.Visible = false;
            }
            else
            {
                this.pnlFind.Visible = true;
            }

            var lstAdd = new int[] {69};
            if (lstAdd.Contains(this.tblNav.NAVID))
            {
                this.lnk69.Visible = true;
                this.btnAdd.Enabled = false;
            }


            var lstNoAdds = new int[] {257, 321};

            if (lstNoAdds.Contains(this.tblNav.NAVID))
            {

                this.btnAdd.Enabled = false;
            }

           if(this.tblNav.NAVID == 709)
            {
                
                TLine.Add(new Tuple<int, int,string>(0, 280, "PKU1"));
                TLine.Add(new Tuple<int, int, string>(0, 281, "PKU2"));
                TLine.Add(new Tuple<int, int, string>(0, 9, "PRU"));
                TLine.Add(new Tuple<int, int, string>(0, 17, "SLU"));
                TLine.Add(new Tuple<int, int, string>(0, 14, "TLU"));

                Dictionary<int, string> Line = new Dictionary<int, string>();
                Line.Add(0, "All Lines");
                Line.Add(1, "PKU1");
                Line.Add(2, "PKU2");
                Line.Add(3, "PRU");
                Line.Add(4, "SLU");
                Line.Add(5, "TLU");



                ddlLine.DataSource = new BindingSource(Line, null);
                ddlLine.DisplayMember = "Value";
                ddlLine.ValueMember = "Key";
                ddlLine.SelectedIndex = 0;

                Dictionary<int, string> Source = new Dictionary<int, string>();
                Source.Add(0, "All Shifts");
                Source.Add(1, "First");
                Source.Add(2, "Second");
                Source.Add(3, "Third");
                Source.Add(4, "Twenty Four");



                ddlSource.DataSource = new BindingSource(Source, null);
                ddlSource.DisplayMember = "Value";
                ddlSource.ValueMember = "Key";
                ddlSource.SelectedIndex = 0;


            }

            if (this.tblNav.NAVID == 745)
            {

                TLine.Add(new Tuple<int, int, string>(0, 404, "404"));
                TLine.Add(new Tuple<int, int, string>(0, 405, "405"));
             

                Dictionary<int, string> Line = new Dictionary<int, string>();
                Line.Add(0, "All Test Stands");
                Line.Add(1, "404");
                Line.Add(2, "405");



                ddlLine.DataSource = new BindingSource(Line, null);
                ddlLine.DisplayMember = "Value";
                ddlLine.ValueMember = "Key";
                ddlLine.SelectedIndex = 0;

              

            }


            var lstImpersonate = new int[] {52, 81, 136};

            var lstDrop = new int[] {2, 3, 5, 8, 13, 65, 69, 95, 96, 175, 185, 210, 257, 710, 745};

            if (lstDrop.Contains(this.tblNav.NAVID) | lstImpersonate.Contains(this.tblNav.NAVID))
            {
                try
                {
                    var q = db.p_DropDown(this.APPID, this.tblNav.NAVID, this.tblNav.NAVID.ToString(), "",
                        this.Associate.ASID);

                    var qry8 = (from ct in q
                        select ct).ToList();

                    ddlFilter.DataSource = new BindingSource(qry8, null);
                    ddlFilter.DisplayMember = "Display";
                    ddlFilter.ValueMember = "ID";

                 

                    if (this.tblNav.NAVID == 69)
                    {
                        this.lblRoute.Text = "Add:";
                    }

                    if (this.tblNav.NAVID == 257)
                    {
                        this.lblRoute.Text = "Dept:";
                    }

                    if (this.tblNav.NAVID == 260)
                    {
                        this.lblRoute.Text = "Creator:";
                    }

                    if (this.tblNav.NAVID == 710)
                    {
                        this.lblRoute.Text = "Line:";
                    }

                    if (this.tblNav.NAVID == 745)
                    {
                        this.lblRoute.Text = "Test Stand:";
                    }

                    if (lstImpersonate.Contains(this.tblNav.NAVID))
                    {
                        this.lblRoute.Text = "";
                        this.lnk69.Text = "Impersonate";
                        lnk69.Visible = true;

                    }

                }
                catch (Exception ex)
                {

                }
                pnlFilter.Dock = DockStyle.Fill;

                this.pnlFilter.Visible = true;
                this.ddlFilter.Visible = true;
                this.lblRoute.Visible = true;

            }
            else
            {
                this.pnlFilter.Visible = false;
                this.ddlFilter.Visible = false;
                this.lblRoute.Visible = false;
            }


        
       

            this.Refresh();

            if (this.tblNav.NAV_Filter == false | this.txtFind.Text == "First 100...")
            {
                BindGrid(0, gv1);
            }
            else
            {
                this.lblFindResults.Text = "Enter text to search...";
            }


            clsGridUtil.SetGridColor(gv1);
            clsGridUtil.SetBITColumns(gv1);

        }


        private void SetTypeAhead(string strID, TypeAhead txt, string strDefault, Int32 intVal)
        {
            var strVal = intVal.ToString();
            List<HRLData.p_DropDown_Result> q2 = db
                .p_DropDown(this.APPID, this.tblNav.NAVID, strID, strVal, this.Associate.ASID)
                .ToList<HRLData.p_DropDown_Result>();
            txt.ParentForm = this;
            txt.DefaultText = strDefault;
            txt.DataSource = q2.ToDictionary(pl => pl.ID, pl => pl.Display);
            txt.lstWidth = txt.Width;
            if (intVal > 0)
            {
                txt.SelectedValue = Convert.ToInt32(intVal);
                try
                {
                    var q = (from ct in txt.DataSource
                        where ct.Key == intVal
                        select ct).First();

                    Color Visible = clsFormUtil.GetHeaderColor(this.tblNav);


                    txt.Text = q.Value.ToString();
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                txt.Text = strDefault;
            }

        }











        #endregion

        #region "Grid Events"

        public void BindGrid(Int32 intID, DataGridView gv)
        {
            int? intNAVID = this.tblNav.NAVID;

            int? intAPPID = this.APPID;

            gv.Columns.Clear();
            gv.DataSource = null;

            this.Cursor = Cursors.WaitCursor;

            try
            {
                intAPPID = Convert.ToInt32(ddlFilter.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
            }


            try
            {
                switch (this.tblNav.NAVID)
                {

                    case 2:

                        var q2 = from ct in db.tblAppButton
                            where ct.APPID == intAPPID
                                  && ct.BT_Deleted.HasValue == false
                            select ct;

                        if (intID > 0)
                        {
                            q2 = q2.OrderByDescending(w => w.BTID == intID).ThenBy(y => y.BT_Desc);
                        }
                        else
                        {
                            q2 = q2.OrderBy(w => w.BT_Desc);
                        }

                        var qry2 = (from ct in q2
                            select ct).ToList();

                        BindGridData(qry2, gv);

                        break;

                    case 3:


                        var q3 = from ct in db.tblAppRoleButtons
                            join bt in db.tblAppButton on ct.BTID equals bt.BTID
                            join ar in db.tblAppRoles on ct.ARID equals ar.ARID
                            join rl in db.tblAppRole on ar.RLID equals rl.RLID
                            where bt.APPID == intAPPID
                                  && ct.AB_Deleted.HasValue == false
                            select new {Buttons = ct, AppButtons = bt, Role = rl};

                        if (intID > 0)
                        {
                            q3 = q3.OrderByDescending(w => w.Buttons.ABID == intID).ThenBy(y => y.AppButtons.BT_Desc)
                                .ThenBy(y => y.Role.RL_Desc);
                        }
                        else
                        {
                            q3 = q3.OrderBy(w => w.AppButtons.BT_Desc).ThenBy(y => y.Role.RL_Desc);
                        }

                        var qry3 = (from ct in q3
                            select ct.Buttons).ToList();

                        BindGridData(qry3, gv);

                        break;

                    case 4:

                        var q4 = from ct in db.tblAppRole
                            where ct.RL_Deleted.HasValue == false
                            select ct;

                        if (intID > 0)
                        {
                            q4 = q4.OrderByDescending(w => w.RLID == intID).ThenBy(y => y.RL_Desc);
                        }
                        else
                        {
                            q4 = q4.OrderBy(w => w.RL_Desc);
                        }

                        var qry4 = (from ct in q4
                            select ct).ToList();

                        BindGridData(qry4, gv);

                        break;


                    case 5:


                        var q5 = from ct in db.tblAppRoles
                            join rl in db.tblAppRole on ct.RLID equals rl.RLID
                            where ct.AR_Deleted.HasValue == false
                                  && rl.RL_Deleted.HasValue == false
                            where ct.APPID == intAPPID
                            select new {AP = ct, Rl = rl};

                        if (intID > 0)
                        {
                            q5 = q5.OrderByDescending(w => w.AP.ARID == intID).ThenBy(y => y.Rl.RL_Desc);
                        }
                        else
                        {
                            q5 = q5.OrderBy(w => w.Rl.RL_Desc);
                        }

                        var qry5 = (from ct in q5
                            select ct.AP).ToList();

                        BindGridData(qry5, gv);

                        break;

                    case 8:

                        Int32 intSel = Convert.ToInt32(this.ddlFilter.SelectedValue.ToString());

                        var q8 = from ct in db.tblAppColumns
                            where ct.APC_Deleted.HasValue == false
                                  && ct.NAVID == intSel
                            select ct;

                        if (intID > 0)
                        {
                            q8 = q8.OrderByDescending(w => w.APCID == intID).ThenBy(y => y.APC_Grid)
                                .ThenBy(z => z.APC_Order);
                        }
                        else
                        {
                            q8 = q8.OrderBy(y => y.APC_Grid).ThenBy(z => z.APC_Order);
                        }


                        var qry8 = (from ct in q8
                            select ct).ToList();

                        BindGridData(qry8, gv);

                        break;


                    case 10:


                        var q10 = from ct in db.tblAppColumnOption
                            where ct.APCO_Deleted.HasValue == false
                            select ct;

                        if (intID > 0)
                        {
                            q10 = q10.OrderByDescending(w => w.APCOID == intID).ThenBy(y => y.APCO_Desc);
                        }
                        else
                        {
                            q10 = q10.OrderBy(y => y.APCO_Desc);
                        }


                        var qry10 = (from ct in q10
                            select ct).ToList();

                        BindGridData(qry10, gv);

                        break;

                    case 13:

                        Int32 intSel13 = Convert.ToInt32(this.ddlFilter.SelectedValue.ToString());
                        string strSel = ddlFilter.GetItemText(ddlFilter.SelectedItem);

                        string strSQL = "p_AppUser " + intSel13.ToString() + ", " + this.tblNav.NAVID.ToString() +
                                        ", '" + strSel + "', '" + this.Associate.AS_User + "', " +
                                        this.Associate.ASID.ToString();

                        DataSet ds = clsDAL.ProcessSQL(strSQL, "HRL");

                        if (clsUtility.dsHasData(ds))
                        {
                            BindGridDataGV1(ds.Tables[0], gv);
                        }

                        break;


                    case 52:


                        string strSQL52 = "p_AppUser " + this.APPID.ToString() + ", " + this.tblNav.NAVID.ToString() +
                                          ", 'HRL', '" + this.Associate.AS_User + "', " +
                                          this.Associate.ASID.ToString();

                        DataSet ds52 = clsDAL.ProcessSQL(strSQL52, "HRL");

                        if (clsUtility.dsHasData(ds52))
                        {
                            BindGridDataGV1(ds52.Tables[0], gv);
                        }


                        break;


                   

                    case 398:

                        var q398 = from ct in db.tblAppDropDown
                                   where ct.DD_Deleted.HasValue == false
                                   select ct;

                        if (intID > 0)
                        {
                            q398 = q398.OrderByDescending(w => w.DDID == intID).ThenBy(y => y.DD_Desc);
                        }
                        else
                        {
                            q398 = q398.OrderBy(w => w.DD_Desc);
                        }

                        var qry398 = (from ct in q398
                                      select ct).ToList();

                        BindGridData(qry398, gv);

                        break;

                    case 707:

                        var q707 = from ct in dbVisual.tblFPYBreaks
                                   where ct.FPY_Deleted.HasValue == false
                                   orderby ct.FPY_Shift, ct.FPY_Hour
                                   select ct;

                        if (intID > 0)
                        {
                            q707 = q707.OrderByDescending(w => w.FPYID == intID).ThenBy(y => y.FPY_Desc);
                        }
                        else
                        {
                            //q707 = q707.OrderBy(w => w.FPY_Desc);
                        }

                        var qry707 = (from ct in q707
                                      select ct).ToList();

                        this.btnAdd.Enabled = false;
                        BindGridData(qry707, gv);

                        break;



                    case 708:

                        
                        var q708 = from ct in dbVisual.tblFPYTargets
                                   where ct.FPYT_Deleted.HasValue == false
                                   select ct;


                        var qry708 = (from ct in q708
                                      select ct).ToList();

                        this.btnAdd.Enabled = true;
                        BindGridData(qry708, gv);

                        break;

                    case 709:
                        pnlResults.Visible = true;
                        string strSource = this.ddlSource.Text = this.ddlSource.GetItemText(ddlSource.SelectedItem).Replace(" ", "");
                        string strResultsLine = this.ddlLine.Text = this.ddlSource.GetItemText(ddlLine.SelectedItem);

                        string dtSelect = DateTime.Now.AddDays(-7).ToShortDateString();

                       

                        int intVSID = 0;

                        //string strSQLResults = "SELECT * FROM tblFPYResults WHERE CONVERT(date, ResultsDate) >= CONVERT(date, '1/1/2021') ORDER by ResultsDate desc, VSID";
                        string strSQLResults = "SELECT * FROM tblFPYResults	";
                        Debug.Print(strSQLResults);

                        if (intID > 0)
                        {

                            if (ddlDate.Value.ToShortDateString() == DateTime.Now.ToShortDateString())
                            {
                                dtSelect = DateTime.Now.AddDays(-7).ToShortDateString();
                            }
                            else
                            {
                                dtSelect = ddlDate.Value.ToShortDateString();
                                strSQLResults = "SELECT * FROM tblFPYResults WHERE CONVERT(date, ResultsDate) = CONVERT(date, '" + dtSelect + "')";
                                
                            }

                            foreach (var g in TLine)
                            {
                                if (g.Item3 == strResultsLine)
                                {
                                    intVSID = g.Item2;
                                    strSQLResults = strSQLResults + " AND VSID = " + intVSID.ToString();
                                }
                            }

                            if(strSource != "AllShifts")
                            {
                                strSQLResults = strSQLResults + " AND Source = '" + strSource + "'";
                            }

                         

                        }

                        //strSQLResults = strSQLResults + " ORDER BY CONVERT(date, ResultsDate) desc, VSID, Source";
                        strSQLResults = strSQLResults + "ORDER BY  DATEPART(month, resultsdate) desc , DATEPART(day, resultsdate) desc  , VSID , Source";
                        DataSet ds709 = clsDAL.ProcessSQL(strSQLResults, "Visual");

                        if (clsUtility.dsHasData(ds709))
                        {
                            BindGridDataGV1(ds709.Tables[0], gv);

                        }


                        break;


                    case 710:

                        string strLine = ddlFilter.GetItemText(ddlFilter.SelectedItem).ToString().Replace(" ", "");

                        var q710 = from ct in dbVisual.tblLeakTestCycleTime
                                   where ct.LTCY_Line == strLine && ct.LTCY_Deleted == null
                                   select ct;



                        if (intID > 0)
                        {
                            q710 = q710.OrderByDescending(w => w.LTCYID == intID).ThenBy(z => z.LTCY_Family);
                        }
                        else
                        {
                            //q710 = q710.OrderBy(w => w.LTCY_Line).ThenBy(z=> z.LTCY_Part);
                        }

                        var qry710 = (from ct in q710
                                      select ct).ToList();

                        this.btnAdd.Enabled = true;
                        BindGridData(qry710, gv);

                        break;

                    case 744:


                        var q744 = from ct in dbVisual.tblFPYTargetsTest
                                   where ct.FPYTS_Deleted.HasValue == false
                                   select ct;


                        var qry744 = (from ct in q744
                                      select ct).ToList();

                        this.btnAdd.Enabled = true;
                        BindGridData(qry744, gv);

                        break;

                    case 745:

                        string strTestSTand = ddlFilter.GetItemText(ddlFilter.SelectedItem).ToString().Replace(" ", "");

                        var q745 = from ct in dbVisual.tblTestStandCycleTime
                                   where ct.TSCY_TestStand.ToString() == strTestSTand && ct.TSCY_Deleted == null
                                   select ct;



                        if (intID > 0)
                        {
                            q745 = q745.OrderByDescending(w => w.TSCYID == intID).ThenBy(z => z.TSCY_Family);
                        }
                        else
                        {
                            //q745 = q745.OrderBy(w => w.LTCY_Line).ThenBy(z=> z.LTCY_Part);
                        }

                        var qry745 = (from ct in q745
                                      select ct).ToList();

                        this.btnAdd.Enabled = true;
                        BindGridData(qry745, gv);

                        break;

                }


            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
            }

            clsGridUtil.ShowNewEntry(gv1, intID);


            this.Cursor = Cursors.Default;


        }

        public void BindGridData<T>(IEnumerable<T> result, DataGridView gv)
        {

            var lstVisibleGrid = new int[] {3, 5}; //eg grid has app specific dropdowns so must redo Columns

            //List<T> itemsList = (List<T>)resultpre;
            //SortableBindingList<T> result = new SortableBindingList<T>(itemsList);




            if (!(gv.Columns.Count > 0) | lstVisibleGrid.Contains(this.tblNav.NAVID))
            {
                gv.Columns.Clear();
                gv.AutoGenerateColumns = false;
                gv.AllowUserToAddRows = false;
                gv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;


                Int32 intAPPID = this.APPID;

                var lstDrop = new int[] {3};

                if (lstDrop.Contains(this.tblNav.NAVID))
                {
                    intAPPID = Convert.ToInt32(this.ddlFilter.SelectedValue.ToString());
                }

                try
                {


                    List<HRLData.tblAppColumns> properties = (from Visible in db.tblAppColumns
                        where Visible.NAVID == this.tblNav.NAVID
                              && Visible.APC_Grid == gv.Name
                              && Visible.APC_Deleted.HasValue == false
                        orderby Visible.APC_Order
                        select Visible).ToList<HRLData.tblAppColumns>();


                    foreach (var property in properties)
                    {
                        clsGridUtil.AddColumns(gv, this.tblNav.NAVID, property, db, this.APPID, intAPPID,
                            this.Associate.ASID);

                        //if(this.tblNav.NAVID == 210)
                        //{
                        //    try
                        //    {
                        //        gv1.Columns[property.APC_Desc].SortMode = DataGridViewColumnSortMode.NotSortable;
                        //    }
                        //    catch(Exception ex)
                        //    {

                        //    }
                        //}

                    }





                }
                catch (Exception ex)
                {

                }
            }

            try
            {
                gv.DataSource = null;
                bs1.DataSource = result;
                gv.DataSource = bs1;

                gv1.SortCompare +=
                    new System.Windows.Forms.DataGridViewSortCompareEventHandler(clsGridUtil.SortCompare);



                clsGridUtil.SetGridColor(gv1);
                clsGridUtil.SetBITColumns(gv1);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.AppName);
                return;
            }
        }

        private void BindGridDataGV1(DataTable result, DataGridView gv)
        {

            if (!(gv.Columns.Count > 0))
            {
                gv.Columns.Clear();
                gv.AutoGenerateColumns = false;
                gv.AllowUserToAddRows = false;
                gv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;


                try
                {

                    List<HRLData.tblAppColumns> properties = (from Visible in db.tblAppColumns
                        where Visible.NAVID == this.tblNav.NAVID
                              && Visible.APC_Grid == gv.Name
                        orderby Visible.APC_Order
                        select Visible).ToList<HRLData.tblAppColumns>();

                    foreach (var property in properties)
                    {

                        clsGridUtil.AddColumns(gv, this.tblNav.NAVID, property, db, this.APPID, this.APPID,
                            this.Associate.ASID);

                    }

                }
                catch (Exception ex)
                {

                }

                if (this.tblNav.NAVID == 69)
                {
                    gv.Tag = "69";

                    foreach (DataColumn Column in result.Columns)
                    {
                        if (Column.ColumnName.StartsWith("Tbl") | (Column.ColumnName == "ASID") |
                            Column.ColumnName.StartsWith("AS_Display"))
                        {
                            continue;
                        }
                        if (!(Column.ColumnName.Contains("ASID")))
                        {
                            DataGridViewComboBoxColumnCredo gvCbo = new DataGridViewComboBoxColumnCredo();
                            var qry = new Dictionary<int, string>();

                            try
                            {
                                List<HRLData.p_DropDown_Result> q = db
                                    .p_DropDown(this.APPID, this.tblNav.NAVID, "DAATID", "", 0)
                                    .ToList<HRLData.p_DropDown_Result>();
                                qry = q.ToDictionary(pl => pl.ID, pl => pl.Display);

                            }
                            catch (Exception ex)
                            {

                            }
                            if (qry.Count > 0)
                            {
                                gvCbo.DataSource = qry.ToList();
                            }


                            string ColumnName = Column.ColumnName;
                            gvCbo.DisplayMember = "Value";
                            gvCbo.ValueMember = "Key";
                            gvCbo.FlatStyle = FlatStyle.Flat;
                            gvCbo.Name = Column.ColumnName;
                            gvCbo.HeaderText = Column.ColumnName;
                            gvCbo.DataPropertyName = Column.ColumnName;
                            gvCbo.Width = 95;
                            gvCbo.AutoComplete = true;
                            gv.Columns.Add(gvCbo);



                        }
                    }
                }

                if (this.tblNav.NAVID == 150)
                {
                    gv.Tag = "150";


                    foreach (DataColumn Column in result.Columns)
                    {
                        if (Column.ColumnName.StartsWith("Tbl") | (Column.ColumnName == "ASID") |
                            Column.ColumnName.StartsWith("AS_Display"))
                        {
                            continue;
                        }
                        if (!(Column.ColumnName.Contains("ASID")))
                        {
                            DataGridViewComboBoxColumnCredo gvCbo = new DataGridViewComboBoxColumnCredo();
                            var qry = new Dictionary<int, string>();

                            try
                            {
                                List<HRLData.p_DropDown_Result> q = db
                                    .p_DropDown(this.APPID, this.tblNav.NAVID, "ASID", "", 0)
                                    .ToList<HRLData.p_DropDown_Result>();
                                qry = q.ToDictionary(pl => pl.ID, pl => pl.Display);

                            }
                            catch (Exception ex)
                            {

                            }
                            if (qry.Count > 0)
                            {
                                gvCbo.DataSource = qry.ToList();
                            }


                            string ColumnName = Column.ColumnName;
                            gvCbo.DisplayMember = "Value";
                            gvCbo.ValueMember = "Key";
                            gvCbo.FlatStyle = FlatStyle.Flat;
                            gvCbo.Name = Column.ColumnName;

                            if (Column.ColumnName == "CZR_Desc")
                            {
                                gvCbo.HeaderText = "Role";
                            }
                            else
                            {
                                gvCbo.HeaderText = Column.ColumnName;
                            }



                            gvCbo.DataPropertyName = Column.ColumnName;
                            gvCbo.Width = 195;
                            gvCbo.AutoComplete = true;
                            gv.Columns.Add(gvCbo);
                        }
                    }
                }

                if (this.tblNav.NAVID == 248)
                {
                    gv.Tag = "248";


                    foreach (DataColumn Column in result.Columns)
                    {
                        if (Column.ColumnName.StartsWith("Tbl") | (Column.ColumnName == "ASID") |
                            Column.ColumnName.StartsWith("AS_Display"))
                        {
                            continue;
                        }
                        if (!(Column.ColumnName.Contains("ASID")))
                        {
                            DataGridViewComboBoxColumnCredo gvCbo = new DataGridViewComboBoxColumnCredo();
                            var qry = new Dictionary<int, string>();

                            try
                            {
                                List<HRLData.p_DropDown_Result> q = db
                                    .p_DropDown(this.APPID, this.tblNav.NAVID, "ASID", "", 0)
                                    .ToList<HRLData.p_DropDown_Result>();
                                qry = q.ToDictionary(pl => pl.ID, pl => pl.Display);

                            }
                            catch (Exception ex)
                            {

                            }
                            if (qry.Count > 0)
                            {
                                gvCbo.DataSource = qry.ToList();
                            }


                            string ColumnName = Column.ColumnName;
                            gvCbo.DisplayMember = "Value";
                            gvCbo.ValueMember = "Key";
                            gvCbo.FlatStyle = FlatStyle.Flat;
                            gvCbo.Name = Column.ColumnName;
                            gvCbo.HeaderText = Column.ColumnName;
                            gvCbo.DataPropertyName = Column.ColumnName;
                            gvCbo.Width = 195;
                            gvCbo.AutoComplete = true;
                            gv.Columns.Add(gvCbo);
                        }
                    }
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

            clsGridUtil.SetGridColor(gv1);
            clsGridUtil.SetBITColumns(gv1);
        }

        public void SortGrid<T>(IEnumerable<T> result, Int32 intVisible)
        {


            //List<T> the_source = gv1.DataSource as List<T>;
            //T c = (T)Activator.CreateInstance(typeof(T));
            //the_source.Add(c);

            BindGridData(result, gv1);

        }

        private void gv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridView gv = (DataGridView) sender;


            //Ignore clicks that are not on button cells. 
            if (e.RowIndex < 0)
            {


                if (e.RowIndex == -1 && this.tblNav.NAVID == 210)
                {
                    strSort = gv1.Columns[e.ColumnIndex].Name;

                    BindGrid(0, gv1);

                    //var result = (from DataGridViewRow row in gv1.Rows
                    //              orderby (string)row.Cells[e.ColumnIndex].FormattedValue.ToString()
                    //              select row).ToList();


                    //SortGrid(result, e.ColumnIndex);



                }

                return;
            }

           

            //#region "Type Ahead"

            //try
            //{

            //    if (e.ColumnIndex == gv.Columns["ASID"].Index)
            //    {
            //        DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)gv.Rows[e.RowIndex].Cells[e.ColumnIndex];

            //        int intPK = 0;

            //        try
            //        {
            //            intPK = Convert.ToInt32(cell.Value.ToString());
            //        }
            //        catch (Exception)
            //        {


            //        }

            //        //Rectangle rec = gv.GetCellDisplayRectangle(e.RowIndex, e.ColumnIndex, true);

            //        taBIAssoc.Location = gv.PointToScreen(gv.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location);

            //        //this.taBIAssoc.Bounds = rec;
            //        //this.taBIAssoc.Visible = true;

            //        gv.CurrentCell = null;


            //    }
            //}
            //catch (Exception ex)
            //{

            //}

            //#endregion

          

          


            try
            {
                //deleting an AppUser
                var lstUser = new int[] {13, 52, 71, 81, 151, 195, 255};

                if (gv.Columns[e.ColumnIndex].Tag.ToString() == "10" && lstUser.Contains(this.tblNav.NAVID))
                {
                    if (MessageBox.Show("Delete this Row?", "Credo", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Int32 intPk = clsGridUtil.GetPK(gv1);
                        string strSel = ddlFilter.GetItemText(ddlFilter.SelectedItem);

                        string strSQL = "DELETE FROM tblAppUser WHERE AUID =" + intPk.ToString();

                        if (this.tblNav.NAVID == 81 || this.tblNav.NAVID == 255) //pb trcking and 
                        {
                            //delete from HRL
                            clsDAL.ExecuteSQL(strSQL, "HRL");
                        }
                        else if ((this.tblNav.NAVID == 13 && strSel.Contains("HRL")) | this.ddlFilter.Visible == false)
                        {
                            //delete from HRL
                            clsDAL.ExecuteSQL(strSQL, "HRL");
                        }
                        else
                        {
                            //remove from Rexroth db
                            clsDAL.ExecuteSQL(strSQL, "Rexroth");
                        }

                        BindGrid(0, gv1);

                    }

                    return;
                }

                if (gv.Columns[e.ColumnIndex].Tag.ToString() == "10" && tblNav.NAVID == 707)
                {
                    if (MessageBox.Show("Delete this Row?", "Credo", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        
                        int intFPYID = Convert.ToInt32(gv.Rows[e.RowIndex].Cells[gv.Columns["FPYID"].Index].Value.ToString());
                        string strSQL = "UPDATE tblFPYBreaks SET FPY_Deleted = GETDATE() WHERE FPYID =" + intFPYID.ToString();

                        clsDAL.ExecuteSQL(strSQL, "Visual");


                        BindGrid(0, gv1);

                    }
                    return;
                }

                if (gv.Columns[e.ColumnIndex].Tag.ToString() == "10" && tblNav.NAVID == 708)
                {
                    if (MessageBox.Show("Delete this Row?", "Credo", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                      
                        int intFPYTID = Convert.ToInt32(gv.Rows[e.RowIndex].Cells[gv.Columns["FPYTID"].Index].Value.ToString());
                        string strSel = ddlFilter.GetItemText(ddlFilter.SelectedItem);

                        string strSQL = "UPDATE tblFPYTargets SET FPYT_Deleted = GETDATE() WHERE FPYTID =" + intFPYTID.ToString();

                        clsDAL.ExecuteSQL(strSQL, "Visual");


                        BindGrid(0, gv1);

                    }
                    return;
                }

                if (gv.Columns[e.ColumnIndex].Tag.ToString() == "10" && tblNav.NAVID == 710)
                {
                    if (MessageBox.Show("Delete this Row?", "Credo", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        
                        int intLTCYID = Convert.ToInt32(gv.Rows[e.RowIndex].Cells[gv.Columns["LTCYID"].Index].Value.ToString());
                        string strSel = ddlFilter.GetItemText(ddlFilter.SelectedItem);

                        string strSQL = "UPDATE tblLeakTestCycleTime SET LTCY_Deleted = GETDATE() WHERE LTCYID =" + intLTCYID.ToString();

                        //remove from Rexroth db
                        clsDAL.ExecuteSQL(strSQL, "Visual");


                        BindGrid(0, gv1);

                    }
                    return;
                }

                if (gv.Columns[e.ColumnIndex].Tag.ToString() == "10" && tblNav.NAVID == 744)
                {
                    if (MessageBox.Show("Delete this Row?", "Credo", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        int intFPYTSID = Convert.ToInt32(gv.Rows[e.RowIndex].Cells[gv.Columns["FPYTISD"].Index].Value.ToString());
                        string strSel = ddlFilter.GetItemText(ddlFilter.SelectedItem);

                        string strSQL = "UPDATE tblFPYTargetsTest SET FPYTS_Deleted = GETDATE() WHERE FPYTSID =" + intFPYTSID.ToString();

                        clsDAL.ExecuteSQL(strSQL, "Visual");


                        BindGrid(0, gv1);

                    }
                    return;
                }

                if (gv.Columns[e.ColumnIndex].Tag.ToString() == "10" && tblNav.NAVID == 745)
                {
                    if (MessageBox.Show("Delete this Row?", "Credo", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        int intTSCYID = Convert.ToInt32(gv.Rows[e.RowIndex].Cells[gv.Columns["TSCYID"].Index].Value.ToString());
                        string strSel = ddlFilter.GetItemText(ddlFilter.SelectedItem);

                        string strSQL = "UPDATE tblTestStandCycleTime SET TSCY_Deleted = GETDATE() WHERE TSCYID =" + intTSCYID.ToString();

                        //remove from Rexroth db
                        clsDAL.ExecuteSQL(strSQL, "Visual");


                        BindGrid(0, gv1);

                    }
                    return;
                }

            }
            catch (Exception ex)
            {

            }

            Boolean fHandled = clsGridUtil.Grid_CellClick(gv, e); //handle common tasks

            if (fHandled == false)
            {
                try
                {
                    try
                    {

                        try
                        {

                            if (e.ColumnIndex == gv.Columns["DD_SQL"].Index)
                            {

                                Int32 intDDID = clsGridUtil.GetPK(gv1);
                                DataGridViewCell cell = gv1.CurrentCell;

                                frmSQLText frm = new frmSQLText(cell);
                                frm.Text = this.Text;
                                frm.Icon = this.Icon;
                                frm.ECID = intDDID;
                                frm.ShowDialog();


                                return;
                            }

                        }
                        catch (Exception ex)
                        {

                        }

                       


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Could not find Doc to request.");
                        return;
                    }


                  




                    try
                    {
                        if (e.ColumnIndex == gv.Columns["check"].Index)
                        {

                            if (gv1.Rows[e.RowIndex].DefaultCellStyle.BackColor != System.Drawing.Color.LightGreen)
                            {
                                gv1.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;

                            }
                            else
                            {
                                gv1.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                            }
                        }

                    }
                    catch (Exception ex)
                    {


                    }

                  

                  
                }
                catch (Exception ex)
                {

                }
            }

        }
     
        private static void HighlightGvRow(DataGridViewCellEventArgs e, DataGridView gv)
        {
            gv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
        }

        private void ddlFilter_SelectionChangeCommitted(object sender, EventArgs e)
        {
            BindGrid(0, gv1);

        

         
        }



        private void SetGridColor()
        {


            try
            {
                List<DataGridViewCell> cells = new List<DataGridViewCell>();
                if (this.tblNav.NAVID == 65)
                {

                    var result = from DataGridViewRow row in gv1.Rows
                        where (string) row.Cells["DASID"].Value.ToString() == "5"
                        select row;


                    foreach (DataGridViewRow row in result) // added 9/21/2016
                    {
                        gv1.Rows[row.Index].DefaultCellStyle.BackColor = Color.LightGreen;
                        //DataGridViewLinkCell lnk = (DataGridViewLinkCell)gv1.Rows[row.Index].Cells["lnkApp"];
                        //lnk.UseColumnTextForLinkValue = false;
                        //lnk.Value = "";

                    }

                }

                else
                {
                    foreach (DataGridViewColumn idx in gv1.Columns)
                    {
                        var result = from DataGridViewRow row in gv1.Rows
                            where (string) row.Cells[idx.Index].Value.ToString() == "1"
                            select row.Cells[idx.Index];

                        cells.AddRange(result);
                    }


                    foreach (DataGridViewCell cell in cells)
                    {
                        DataGridViewComboBoxCell cbx = (DataGridViewComboBoxCell) cell;
                        cbx.Style.BackColor = Color.Navy;
                        //gv1.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Style.BackColor = Color.Navy;
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }


        private void gv1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            //this is need to commit the dropdown value to be saved
            try
            {

                DataGridViewComboBoxCell cbo = (DataGridViewComboBoxCell) gv1.CurrentCell;

                //if (gv1.IsCurrentCellDirty)
                //{

                gv1.CommitEdit(DataGridViewDataErrorContexts.Commit);

                if (this.APPID == 4 && this.tblNav.NAVID == 69) //
                {
                    Int32 intASID = gv1.Columns["ASID"].Index;
                    Int32 intVisible = gv1.Columns[cbo.ColumnIndex].Index;
                    string strASID = gv1.Rows[cbo.RowIndex].Cells[intASID].Value.ToString();
                    string strDoc = gv1.Columns[cbo.ColumnIndex].Name;
                    string strVal = gv1.Rows[cbo.RowIndex].Cells[intVisible].Value.ToString();
                    string strSQL = "p_tblDocLineAsc_Up3 " + strASID + ", '" + strDoc + "', " + strVal;

                    Debug.Write(strSQL);

                    clsDAL.ExecuteSQL(strSQL, "ECR");
                }

                if (this.APPID == 10 && this.tblNav.NAVID == 150) //Concession Matrix
                {

                    Int32 intVisible = gv1.Columns[cbo.ColumnIndex].Index;
                    string strRole = gv1.Rows[cbo.RowIndex].Cells[0].Value.ToString();
                    string strVal = gv1.Columns[cbo.ColumnIndex].Name;
                    string strASID = gv1.Rows[cbo.RowIndex].Cells[intVisible].Value.ToString();

                    string strSQL = "p_tblConcessionRoleAssign_Up " + strASID + ", '" + strRole + "', '" + strVal + "'";

                    Debug.Write(strSQL);

                    clsDAL.ExecuteSQL(strSQL, "ECR");
                }

                //}

            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        #region "Data Events"

        private string UpdateData(Boolean fShowMsg)
        {
            this.gv1.EndEdit();

            if (this.tblNav.NAVID == 65) //doc approval --- cannot save a view.
            {
                return "";
            }


            if (this.tblNav.NAVID == 210) //Part to Machine
            {
                if (fEdit == true)
                {
                    //var result = from DataGridViewRow row in gv1.Rows
                    //             where (string)row.Tag.ToString() == "Edit"
                    //             select row;


                    foreach (DataGridViewRow row in gv1.Rows)
                    {
                        try
                        {
                            if (row.Tag.ToString() == "edit")
                            {
                                string strSQL = "p_tblValueMachinePart_Up ";

                                string strPARTID = clsGridUtil.CellValStrQuote(row, "PARTID");
                                string strVMID1 = clsGridUtil.CellValStrQuote(row, "VMID1");
                                string strVMID2 = clsGridUtil.CellValStrQuote(row, "VMID2");
                                string strVMID3 = clsGridUtil.CellValStrQuote(row, "VMID3");
                                string strVMID4 = clsGridUtil.CellValStrQuote(row, "VMID4");
                                string strVMID5 = clsGridUtil.CellValStrQuote(row, "VMID5");
                                string strVMID6 = clsGridUtil.CellValStrQuote(row, "VMID6");
                                string strVMID7 = clsGridUtil.CellValStrQuote(row, "VMID7");
                                string strVMID8 = clsGridUtil.CellValStrQuote(row, "VMID8");
                                string strVMID9 = clsGridUtil.CellValStrQuote(row, "VMID9");
                                string strVMID10 = clsGridUtil.CellValStrQuote(row, "VMID10");
                                string strRunTime1 = clsGridUtil.CellValStrQuote(row, "RunTime1");
                                string strRunTime2 = clsGridUtil.CellValStrQuote(row, "RunTime2");
                                string strRunTime3 = clsGridUtil.CellValStrQuote(row, "RunTime3");
                                string strRunTime4 = clsGridUtil.CellValStrQuote(row, "RunTime4");
                                string strRunTime5 = clsGridUtil.CellValStrQuote(row, "RunTime5");
                                string strRunTime6 = clsGridUtil.CellValStrQuote(row, "RunTime6");
                                string strRunTime7 = clsGridUtil.CellValStrQuote(row, "RunTime7");
                                string strRunTime8 = clsGridUtil.CellValStrQuote(row, "RunTime8");
                                string strRunTime9 = clsGridUtil.CellValStrQuote(row, "RunTime9");
                                string strRunTime10 = clsGridUtil.CellValStrQuote(row, "RunTime10");
                                string strCASTID = clsGridUtil.CellValStrQuote(row, "CASTID");

                                strSQL = strSQL + strPARTID + ", " + strVMID1 + ", " + strVMID2 + ", " + strVMID3 +
                                         ", " + strVMID4 + ", " + strVMID5 + ", " + strVMID6 + ", " + strVMID7 + ", " +
                                         strVMID8 + ", " + strVMID9 + ", " + strVMID10 + ", ";
                                strSQL = strSQL + strRunTime1 + ", " + strRunTime2 + ", " + strRunTime3 + ", " +
                                         strRunTime4 + ", " + strRunTime5 + ", " + strRunTime6 + ", " + strRunTime7 +
                                         ", " + strRunTime8 + ", " + strRunTime9 + ", " + strRunTime10 + ", ";
                                strSQL = strSQL + strCASTID;
                                Debug.Print(strSQL);
                                clsDAL.ExecuteSQL(strSQL, "Visual");
                            }
                        }
                        catch (Exception ex)
                        {

                        }

                    }
                }
                return "";
            }
            if (this.tblNav.NAVID == 256) //Department/BoardOwner Assignment
            {
                if (fEdit == true)
                {
                    //var result = from DataGridViewRow row in gv1.Rows
                    //             where (string)row.Tag.ToString() == "Edit"
                    //             select row;


                    foreach (DataGridViewRow row in gv1.Rows)
                    {
                        try
                        {
                            if (row.Tag.ToString() == "edit")
                            {
                                string strSQL = "p_tblBI_Dept_Up ";

                                var strASID = clsGridUtil.CellValStrQuote(row, "ASID");
                                var strBIDID = clsGridUtil.CellValStrQuote(row, "BIDID");

                                strSQL = strSQL + strASID + ", " + strBIDID;
                                Debug.Print(strSQL);
                                clsDAL.ExecuteSQL(strSQL, "HRL");

                            }
                        }
                        catch (Exception e)
                        {

                        }
                    }
                }
            }



            try
            {
                db.SaveChanges();
                dbRexroth.SaveChanges();
                dbVisual.SaveChanges();
                return "";
            }

            catch (System.Exception ex)
            {
                if (fShowMsg == true)
                {
                    MessageBox.Show(ex.Message, this.AppName);
                    return "";
                }
                else
                {
                    return ex.Message;
                }
            }


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
                var changedEntries = context.ChangeTracker.Entries()
                    .Where(x => x.State != System.Data.Entity.EntityState.Unchanged).ToList();

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

            AddRecord(false);

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //DataTable dt =  clsExport.GVToDataTable(gv1, true);
            //clsExport.ExcelExport(dt, "", true, true);



            clsExport.ExportViaCopy(gv1, this.tblNav.NAVID);

        }

        private void btn_ToolTip(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button) sender;

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
            intFindPosition = 0;
            intFindTotal = 0;
            this.btnFindPrevious.Enabled = false;
            this.btnFindNext.Enabled = false;
        }

        private void txtFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char) 13)
                {




                    if (this.tblNav.NAV_Filter == true)
                    {
                        BindGrid(0, gv1);
                    }
                    else
                    {
                        clsGridUtil.ResetCells(gv1, cells);

                        string strFind = this.txtFind.Text.ToString().ToUpper();

                        if (strFind.Trim() + "" != "")
                        {

                            cells = gv1.Rows.Cast<DataGridViewRow>()
                                .SelectMany(row => gv1.Columns.Cast<DataGridViewColumn>()
                                    .Select(Visible => row.Cells[Visible.Name])
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

                    }
                    e.Handled = true;

                }
            }
            catch (Exception ex)
            {

            }

        }

        #endregion

        private void lnk69_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.ddlFilter.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("Please select an Associate.");
                return;
            }

            if (lnk69.Text == "Impersonate")
            {
                AddRecord(true);
            }
            else
            {
                AddRecord(false);
            }

        }

        private void AddRecord(Boolean fImpersonate)
        {
            Int32 intPK = 0;
            int? intNAVID = this.tblNav.NAVID;
            int? intBTID = 0;
            int? intAPPID = this.APPID;
            int? intBIDID = 0;
            var strUser = "";


            if (fImpersonate == true)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;


                    Int32 intASID = Convert.ToInt32(ddlFilter.SelectedValue.ToString());

                    clsUtility.Impersonate(this.APPID, intASID);

                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(ex.Message);

                }
                this.Cursor = Cursors.Default;
                return;
            }


            var lstDrop = new int[] {2, 3, 5, 13};

            if (lstDrop.Contains(this.tblNav.NAVID))
            {
                intAPPID = Convert.ToInt32(this.ddlFilter.SelectedValue.ToString());
            }

            if (this.ddlFilter.Visible == true)
            {
                if (tblNav.NAVID == 257)
                {
                    intBIDID = Convert.ToInt32(this.ddlFilter.SelectedValue.ToString());
                }
                else
                {
                    intBTID = Convert.ToInt32(this.ddlFilter.SelectedValue.ToString());
                }

            }

            var lstUser = new int[] {13, 52, 71, 81, 136, 137, 151, 195, 220, 255};

            if (lstUser.Contains(this.tblNav.NAVID))
            {
                this.Cursor = Cursors.WaitCursor;
                frmAddUser frm = new frmAddUser();
                frm.APPID = Convert.ToInt32(intAPPID);
                frm.tblNav = this.tblNav;
                frm.Icon = this.Icon;

                string strSel = ddlFilter.GetItemText(ddlFilter.SelectedItem);


                if (this.tblNav.NAVID == 13)
                {
                    frm.Parm1 = strSel;
                }
                else
                {
                    frm.Parm1 = "HRL";
                }

                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.Cursor = Cursors.Default;
                    BindGrid(0, gv1);
                }
                else
                {
                    this.Cursor = Cursors.Default;
                }

                return;
            }

           
            if(this.LNID == 1)
            {
                intBTID = 281;
            }

            if(this.LNID == 0)
            {
                intBTID = 280;
            }

            if(this.ddlFilter.GetItemText(ddlFilter.Text) == "PRU")
            {
                intBTID = 9;
            }

            if (this.ddlFilter.GetItemText(ddlFilter.Text) == "SLU")
            {
                intBTID = 17;
            }

            if (this.ddlFilter.GetItemText(ddlFilter.Text) == "TLU")
            {
                intBTID = 14;
            }






            intPK = clsGridUtil.AddGridRecord(intNAVID, intAPPID, intBTID, this.Associate.AS_User);

            BindGrid(intPK, gv1);
        }


        private void taAssoc_KeyDown(object sender, KeyEventArgs e)
        {
            //if (ddlASID.ListBox.Visible == false)
            //{
            //    try
            //    {
            //        var asid = ddlASID.SelectedValue;
            //        if (asid > 0)
            //        {
            //            BindGrid(asid, gv1);
            //        }


            //    }
            //    catch (Exception ex)
            //    {


            //    }
            //}

        }

        private void chkAssigned_CheckedChanged(object sender, EventArgs e)
        {
            BindGrid(0, gv1);
        }


        #region "Misc"

        //private void lnkAddUID_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    if (this.txtUID.Text.ToString() + "" == "")
        //    {
        //        MessageBox.Show("Please enter the new associate's USER ID.", this.AppName);
        //        return;
        //    }

        //    Int32 intASID = 0;

        //    intASID = clsAD.AddUserByUID(this.txtUID.Text.ToString(), this.APPID);

        //    if (intASID > 0)
        //    {
        //        BindGrid(0, gv1);
        //        MessageBox.Show(this.txtUID.Text.ToString() + " entered. Press the '+' button to assign their role.", this.AppName);

        //    }
        //}

        #endregion

        private void gv1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            fEdit = true;
        }

        private void gv1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            fEdit = true;
            gv1.Rows[e.RowIndex].Tag = "edit";
        }

        private void gv1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //var Result = gv1.Rows.OfType<DataGridViewRow>().Select(
            //r => r.Cells.OfType<DataGridViewCell>().Select(c => c.FormattedValue).ToArray()).ToList();
            //List<T> result = (List<T>)gv1.DataSource;

            //BindGridData(Result, gv1);

        }

        private void FillActiveChildFormToClient()
        {

            Form child = this.ActiveMdiChild;
            Rectangle mdiClientArea = Rectangle.Empty;

            foreach (Control c in this.Controls)
            {
                if (c is MdiClient)
                    mdiClientArea = c.ClientRectangle;
            }

            child.Bounds = mdiClientArea;

        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {

        }

        private void lnkAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int intASID = 0;

            //intASID = Convert.ToInt32(ddlASID.SelectedValue.ToString());

            //if (intASID > 0)
            //{
            //    int intPK = clsGridUtil.AddGridRecord(this.tblNav.NAVID, this.APPID, intASID, "");
            //    BindGrid(intPK, gv1);
            //}
            //else
            //{
            //    MessageBox.Show("Please select an Associate");
            //    return;
            //}

        }

        private void ddlSource_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.ddlSource.Text = this.ddlSource.GetItemText(ddlSource.SelectedItem);
            BindGrid(1, gv1);
        }

        private void ddlLine_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.ddlLine.Text = this.ddlLine.GetItemText(ddlLine.SelectedItem);
            BindGrid(1, gv1);
        }

        private void ddlDate_ValueChanged(object sender, EventArgs e)
        {
            BindGrid(1, gv1);
        }


 
    }
}

