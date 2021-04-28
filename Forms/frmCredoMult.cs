using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Data.Linq;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRLData;


namespace FPY
{
    public partial class frmCredoMult : clsForm
    {

        HRLEntities db = clsStart.efdb();
        List<DataGridViewCell> cells = new List<DataGridViewCell>();
        BindingSource bs1 = new BindingSource();
        Int32 intFindTotal = 0;
        Int32 intFindPosition = 0;

        public frmCredoMult()
        {
            InitializeComponent();
        }

        #region "FormEvents"

        private void frmCredoMD_Load(object sender, EventArgs e)
        {


            lnk1.Text = "Add New " + this.Text.ToString();


            gv1.NAVID = this.tblNav.NAVID;

            var lstDrop = new int[] { 163 };

            if (lstDrop.Contains(this.tblNav.NAVID))
            {
                this.pnlFilter.Visible = true;

                var q = db.p_DropDown(this.APPID, this.tblNav.NAVID, this.tblNav.NAVID.ToString(), "", this.Associate.ASID);

                var qry8 = (from ct in q
                            select ct).ToList();

                ddlFilter.DataSource = new BindingSource(qry8, null);
                ddlFilter.DisplayMember = "Display";
                ddlFilter.ValueMember = "ID";
            }
            else
            {
                gv1.NAVID = this.tblNav.NAVID;
                BindGrid(0);
            }

            var lstOpt = new int[] { 76, 90, 91, 99, 101, 102, 163, 164 };

            if (lstOpt.Contains(this.tblNav.NAVID))
            {
                this.p1t.Visible = false;
                this.p2t.Visible = false;
            }

            if (this.tblNav.NAVID == 248)
            {
                SetTypeAhead("ASID", typeAheadGV2, "--Select Assoc.--", 0);


            }


            try
            {
                var q2 = (from ct in db.tblAppNavigation where ct.NAVID == this.tblNav.NAV_GV2 select ct).First();
                lnk2.Text = "Add New " + q2.NAV_Desc;
                this.gv2.NAVID = Convert.ToInt32(this.tblNav.NAV_GV2);
            }
            catch (Exception ex)
            {
                this.splitter1.Visible = false;
                this.p2.Visible = false;
            }

            try
            {
                var q3 = (from ct in db.tblAppNavigation where ct.NAVID == this.tblNav.NAV_GV3 select ct).First();
                lnk3.Text = "Add New " + q3.NAV_Desc;
                this.gv3.NAVID = Convert.ToInt32(this.tblNav.NAV_GV3);
            }
            catch (Exception ex)
            {
                this.splitter2.Visible = false;
                this.p3.Visible = false;
                this.p2.Dock = DockStyle.Fill;
            }

            try
            {
                var q4 = (from ct in db.tblAppNavigation where ct.NAVID == this.tblNav.NAV_GV4 select ct).First();
                lnk4.Text = "Add New " + q4.NAV_Desc;
                this.gv4.NAVID = Convert.ToInt32(this.tblNav.NAV_GV4);
            }
            catch (Exception ex)
            {
                this.splitter3.Visible = false;
                this.p4.Visible = false;
                this.p3.Dock = DockStyle.Fill;
            }

            if (tblNav.NAVID == 256)
            {
                pnlTop.Visible = false;

                p1t.Visible = true;
                lnk1.Visible = true;
                lnk1.Enabled = true;
                textBox1.Visible = false;
                label1.Visible = false;
                label2.Visible = false;

                p2t.Visible = true;
                p2.Height = 400;
                lnk2.Visible = true;
                lnk2.Enabled = true;
                typeAheadGV2.Visible = false;

                p3t.Visible = true;
                lnk3.Visible = true;
                lnk3.Enabled = true;


            }



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
            if (tblNav.NAVID == 256)
            {
                SetActiveBoardOwner();
            }
        }

        private void SetActiveBoardOwner()
        {
            string strSQL = "p_tblBIUpdateBoardOwner ";
            db.Database.ExecuteSqlCommand(strSQL);
        }

        private void frmCredoMult_Shown(object sender, EventArgs e)
        {

            if (this.tblNav.NAV_Filter == false || this.ddlFilter.Visible == false)
            {
                BindGrid(0);
            }

            this.gv2.AlternatingRowsDefaultCellStyle = gv1.AlternatingRowsDefaultCellStyle;
            this.gv2.DefaultCellStyle = gv1.DefaultCellStyle;
            this.gv2.ColumnHeadersDefaultCellStyle = gv1.ColumnHeadersDefaultCellStyle;



        }



        #endregion

        #region "Grid Events"

        private void SetGridFormat(clsGridView gv)
        {
            gv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            gv.Refresh();

            ObjectContext oc;
            oc = ((IObjectContextAdapter)db).ObjectContext;


        }

        public void BindGrid(Int32 intID)
        {
            int? intNAVID = gv1.NAVID;

            switch (gv1.NAVID)
            {

              

                case 0:

                    //var q102 = (from ct in db.tblAppErrorLog
                    //            where ct.ER_UserName == "Replenish"
                    //            orderby ct.ERID descending
                    //            select ct).ToList();

                    //BindGridData(q102, gv1);

                    break;


              
            }



            //clsGridUtil.ShowNewEntry(gv1, intID);


        }

        public void BindGrid2(Int32 intID)
        {
            int? intNAVID = gv2.NAVID;

            Int32 intSel = clsGridUtil.GetPK(gv1);


            switch (gv2.NAVID)
            {


               case 0:

                    //var q201 = from ct in db.tblEmailDistributionDetail
                    //           join em in db.tblAssociate on ct.ASID equals em.ASID
                    //           where ct.EDD_Deleted.HasValue == false
                    //           && ct.EDID == intSel
                    //           select new { dist = ct, asso = em };

                    //if (intID > 0)
                    //{
                    //    q201 = q201.OrderByDescending(w => w.dist.EDDID == intID).ThenBy(y => y.asso.AS_Display);
                    //}
                    //else
                    //{
                    //    q201 = q201.OrderBy(w => w.asso.AS_Display);
                    //}

                    //var qry201 = (from ct in q201
                    //              select ct.dist).ToList();

                    //BindGridData(qry201, gv2);

                    break;







            }




        }

        public void BindGrid3(Int32 intID)
        {
            int? intNAVID = gv3.NAVID;

            Int32 intSel = clsGridUtil.GetPK(gv1);

            switch (gv3.NAVID)
            {

                case 15:

                break;
            }

            //clsGridUtil.ShowNewEntry(gv3, intID);


        }

        public void BindGrid4(Int32 intID)
        {
            int? intNAVID = gv4.NAVID;

            Int32 intSel = clsGridUtil.GetPK(gv1);

            switch (gv4.NAVID)
            {


                case 0:

                    //var q183 = from ct in db.tblAsvQuestionBaseList
                    //           where ct.BQID == intSel &&
                    //           ct.BQL_Deleted.HasValue == false
                    //           select ct;

                    //if (intID > 0)
                    //{
                    //    q183 = q183.OrderByDescending(w => w.BQLID == intID).ThenBy(y => y.BQL_Desc);
                    //}
                    //else
                    //{
                    //    q183 = q183.OrderBy(w => w.BQL_Desc);
                    //}

                    //var qry183 = (from ct in q183
                    //              select ct).ToList();

                    //BindGridData(qry183, gv4);

                    //gv4.CurrentCell = null;

                    break;

            }

            //clsGridUtil.ShowNewEntry(gv3, intID);


        }
        public void BindGridData<T>(IEnumerable<T> result, clsGridView gv)
        {

            if (!(gv.Columns.Count > 0))
            {
                gv.Columns.Clear();
                gv.AutoGenerateColumns = false;
                gv.AllowUserToAddRows = false;
                gv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

                try
                {



                    List<tblAppColumns> properties = (from col in db.tblAppColumns
                                                      where col.NAVID == gv.NAVID
                                                      && col.APC_Grid == gv.Name
                                                      && col.APC_Deleted == null
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
                //bs1.DataSource = result;
                gv.DataSource = result;

                clsGridUtil.SetGridColor(gv);

                clsGridUtil.SetGridRowHeight(gv);

                //clsGridUtil.EncryptCol(gv);

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

                   

                    if (gv.Columns[e.ColumnIndex].Tag.ToString() == "13" | gv.Columns[e.ColumnIndex].Tag.ToString() == "4" | gv.Columns[e.ColumnIndex].Tag.ToString() == "32")
                    {


                       
                            if (gv.Name == "gv1")
                            {
                                gv.ClearSelection();
                                gv.Rows[e.RowIndex].Selected = true;
                                BindGrid2(0);
                                BindGrid3(0);
                                //if need a list....
                               
                            }
                       
                        if (gv.Name == "gv1")
                        {
                            gv.ClearSelection();
                            gv.Rows[e.RowIndex].Selected = true;
                            BindGrid2(0);
                            BindGrid3(0);
                          
                        }

                        if (gv.Name == "gv2")
                        {
                           
                            gv.ClearSelection();
                            gv.Rows[e.RowIndex].Selected = true;
                            BindGrid3(0);
                        }

                    }
                    


                }
                catch (Exception ex)
                {

                }
            }

        }

        public void gv2_CellValueChanged(object sender,
            DataGridViewCellEventArgs e)
        {
            var columnIndex = 5;
            if (e.ColumnIndex == columnIndex)
            {
                // If the user checked this box, then uncheck all the other rows
                var isChecked = (bool)gv2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (isChecked)
                {
                    foreach (DataGridViewRow row in gv2.Rows)
                    {
                        if (row.Index != e.RowIndex)
                        {
                            row.Cells[columnIndex].Value = !isChecked;
                        }
                    }
                }
            }
        }

        private void gv2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (gv2.Columns.IndexOf(gv2.Columns["BB_Active"]) == e.ColumnIndex)
            //{
            //    int currentcolumnclicked = e.ColumnIndex;
            //    int currentrowclicked = e.RowIndex;
            //    foreach (DataGridViewRow dr in gv2.Rows)
            //    {
            //        if (dr.Index != currentrowclicked)
            //        {
            //            dr.Cells[currentcolumnclicked].Value = false;
            //        }

            //    }
            //    gv2.CurrentRow.Cells[currentrowclicked].Value = true;
            //}
        }

        private void gv1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView gv = (DataGridView)sender;

            //Ignore clicks that are not on button cells. 
            if (e.RowIndex < 0)
            {
                return;
            }

           
        }

        private void ddlFilter_SelectionChangeCommitted(object sender, EventArgs e)
        {

            BindGrid(0);
        }


        private void SetGridColor()
        {
            try
            {

                
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
            this.gv2.EndEdit();
            this.gv3.EndEdit();

            try
            {
                db.SaveChanges();
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

                BindGrid(0);

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            Int32 intPK = 0;
            int? intNAVID = this.tblNav.NAVID;
            int? intBTID = 0;

            if (this.ddlFilter.Visible == true)
            {
                intBTID = Convert.ToInt32(this.ddlFilter.SelectedValue.ToString());
            }

            intPK = clsGridUtil.AddGridRecord(intNAVID, this.APPID, intBTID, this.Associate.AS_User);

            BindGrid(intPK);


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
                Button btn = (Button)sender;

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
                if (e.KeyChar == (char)13)
                {
                    if (this.tblNav.NAV_Filter == true)
                    {
                        BindGrid(0);
                    }
                    else
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

                    }
                    e.Handled = true;

                }
            }
            catch (Exception ex)
            {

            }

        }

        #endregion

        #region "Misc"


        private void lnk1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UpdateData(false);

            Int32 intPK = 0;
            int? intNAVID = gv1.NAVID;

            intPK = clsGridUtil.AddGridRecord(intNAVID, this.APPID, 0, this.Associate.AS_User);


            BindGrid(intPK);
            clsGridUtil.ShowNewEntry(gv1, intPK);
            gv1.Rows[0].Selected = true;
            BindGrid2(intPK);
            BindGrid3(intPK);

        }

        private void lnk2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UpdateData(false);

            Int32 intPK = 0;

            Int32 intSel = clsGridUtil.GetPK(gv1);

            if (intSel > 0)
            {
                intPK = clsGridUtil.AddGridRecord(gv2.NAVID, this.APPID, intSel, this.Associate.AS_User);

                BindGrid2(intPK);

                clsGridUtil.ShowNewEntry(gv2, intPK);
            }

        }

        private void lnk3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            UpdateData(false);
            Int32 intPK = 0;
            var bidid = 0;
            Int32 intSel = 0;

            if (this.APPID == 11) //Assembly Verification
            {
                intSel = clsGridUtil.GetPK(gv1);
            }
            else if (this.tblNav.NAV_GV3 == 302)
            {
                intSel = clsGridUtil.GetPK(gv1);

                //try
                //{
                //    var pk = db.tblBI_OrgDept.First(f => f.BIOID == intSel).BIDID;
                //    bidid = Convert.ToInt32(pk);
                //}
                //catch (Exception)
                //{

                //    MessageBox.Show(
                //        "This Org Unit has not yet been assigned a dept. Please do so before assigning a Super Board Owner.");
                //}
            }
            else
            {
                intSel = clsGridUtil.GetPK(gv2);
            }

            if (intSel > 0)
            {
                intPK = clsGridUtil.AddGridRecord(gv3.NAVID, this.APPID, intSel, this.Associate.AS_User);

                if (tblNav.NAV_GV3 == 302)
                {
                    BindGrid3(bidid);
                }
                else
                {
                    BindGrid3(intPK);
                }


                clsGridUtil.ShowNewEntry(gv3, intPK);
            }
        }

        #endregion

        private void lnk4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UpdateData(false);
            Int32 intPK = 0;

            Int32 intSel = 0;

            if (this.APPID == 11) //Assembly Verification
            {
                intSel = clsGridUtil.GetPK(gv1);
            }
            else
            {
                intSel = clsGridUtil.GetPK(gv2);
            }

            if (intSel > 0)
            {
                intPK = clsGridUtil.AddGridRecord(gv4.NAVID, this.APPID, intSel, this.Associate.AS_User);

                BindGrid4(intPK);

                clsGridUtil.ShowNewEntry(gv4, intPK);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetGridFormat(gv1);
        }

        private void SetTypeAhead(string strID, TypeAhead txt, string strDefault, Int32 intVal)
        {
            List<HRLData.p_DropDown_Result> q2 = db
                .p_DropDown(this.APPID, this.tblNav.NAVID, strID, this.Parm1, this.RexAssoc.ASID)
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

    }
}
