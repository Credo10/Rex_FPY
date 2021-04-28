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
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Linq.Dynamic;
using RexrothData;

namespace RexVOIS3
{
    public partial class frmFilterMin : clsForm
    {
        HRLEntities db = clsStart.efdb();
        List<DataGridViewCell> cells = new List<DataGridViewCell>();
        DataGridViewCell cell;
        Int32 intFindTotal = 0;
        Int32 intFindPosition = 0;
        string strOut = "";
        string strPRPIDs = "";
        string strRpt = "";


        public frmFilterMin()
        {
            InitializeComponent();
        }

        #region "FormEvents"

            private void frmCredoMD_Load(object sender, EventArgs e)
            {

                ResetCriteria(true);

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

            private void frmFilterMin_Shown(object sender, EventArgs e)
            {

                ResetCriteria(true);
                SetHeaderColor();

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

                if(fReset)
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

                    var qry = (from ct in db.tblAppFilter
                                where ct.AFLT_GV == "gv2"
                                && ct.AFLT_Token == this.Token
                                && ct.NAVID == this.tblNav.NAV_GV2
                                select ct).ToList();

                    BindGridData(qry, gv2);

                    UpdateData(true);

                    //BindGrid(0, gv1);

                    //ISingleResult<PGetWOCOOISFinalV2Result> query262 = db.pGetWOCOOISFinalV2b(this.Token, "", "Blank");
                    //BindGridData(query262, gv1, bs1);

                    //SetHeaderColor();

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
              string strWhere = "";

               if(this.chkOmit.Checked == false)
               {

                   this.Cursor = Cursors.WaitCursor;

                   try
                   {

                       UpdateData(false);

                       int? intNAVID = this.tblNav.NAVID;

                       strWhere = clsGridUtil.DynamicWhere(gv2);


                   //    switch (this.tblNav.NAVID)
                   //    {

                           

                   //    }
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

                if (!(gv.Columns.Count > 0))
                {
                    gv.Columns.Clear();
                    gv.AutoGenerateColumns = false;
                    gv.AllowUserToAddRows = false;
                    gv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                    try
                    {

                        Int32 intNAVID = 0;


                        List<vwAppColumnFilterFields> qry2 = (from Visible in db.vwAppColumnFilterFields
                                  where Visible.NAVID == this.tblNav.NAVID
                                  && Visible.APC_Grid == gv.Name
                                  orderby Visible.APC_Order
                                  select Visible).ToList<vwAppColumnFilterFields>();



                        List<EntityData.tblAppColumns> properties = qry2
                        .Select(x => new EntityData.tblAppColumns()
                        {
                            APC_Default = x.APC_Default,
                            APC_QueryField = x.APC_QueryField,
                        APC_Deleted = x.APC_Deleted, APC_Desc = x.APC_Desc, APC_Name = x.APC_Name, APC_Grid = x.APC_Grid, 
                        APC_Order = x.APC_Order, APC_ReadOnly = x.APC_ReadOnly, APC_Width = x.APC_Width, 
                        APCID = x.APCID, APCOID = x.APCOID, NAVID = x.NAVID})
                        .ToList<EntityData.tblAppColumns>();


                        foreach (var property in properties)
                        {
                            clsGridUtil.AddColumns(gv, intNAVID, property, db, this.APPID, this.APPID, this.Associate.ASID);
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


                        List<EntityData.tblAppColumns> properties = (from Visible in db.tblAppColumns
                                                                  where Visible.NAVID == this.tblNav.NAVID
                                                                  && Visible.APC_Grid == gv.Name
                                                                  orderby Visible.APC_Order
                                                                     select Visible).ToList<EntityData.tblAppColumns>();

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
                        if (e.ColumnIndex == gv.Columns["Details"].Index)
                        {

                            


                        }

                    }
                    catch (Exception ex)
                    {

                    }

                    try
                    {
                        if (e.ColumnIndex == gv.Columns["AddComment"].Index)
                        {

                           


                        }

                    }
                    catch (Exception ex)
                    {

                    }
                }

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
                catch(Exception ex)
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
                            string strVisible = gv2.Columns[e.ColumnIndex].HeaderText;
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
    
                            }
                            else
                            {
                                gv2[e.ColumnIndex, e.RowIndex].Value = "Select All";
          
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

                    int intVisible = e.ColumnIndex;

                    foreach(DataGridViewColumn Visible in gv1.Columns)
                    {
                        gv2.Columns[Visible.Index].HeaderCell.SortGlyphDirection = SortOrder.None;
                    }

                    DataGridViewColumn oldColumn = gv1.SortedColumn;
                    ListSortDirection direction;

                    // If oldColumn is null, then the DataGridView is not currently sorted. 
                    if (oldColumn != null)
                    {
                        // Sort the same Column again, reversing the SortOrder. 
                        if (oldColumn.Index == intVisible)
                        {
                            if (gv1.SortOrder == SortOrder.Ascending)
                            {
                                this.gv1.Sort(this.gv1.Columns[intVisible], ListSortDirection.Descending);
                                gv2.Columns[intVisible].HeaderCell.SortGlyphDirection = SortOrder.Descending;
                            }
                            else 
                            {
                                this.gv1.Sort(this.gv1.Columns[intVisible], ListSortDirection.Ascending);
                                gv2.Columns[intVisible].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                            }
                        }
                        else
                        {
                            this.gv1.Sort(this.gv1.Columns[intVisible], ListSortDirection.Ascending);
                            gv2.Columns[intVisible].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                        }
                    }
                    else
                    {
                        this.gv1.Sort(this.gv1.Columns[intVisible], ListSortDirection.Ascending);
                        gv2.Columns[intVisible].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                    }

                    this.Cursor = Cursors.Default;

                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                }
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
                        catch(Exception ex)
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
                catch(Exception ex)
                {

                }
            }

            private void lnkClearAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
            {
                ResetCriteria(false);
            }

            private void gv2_DataError(object sender, DataGridViewDataErrorEventArgs e)
            {

            }


        #endregion

        #region "Data Events"

            private string UpdateData(Boolean fShowMsg)
            {
                this.gv2.EndEdit();

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

                    BindGrid(0, gv1);

                }
            }
        
            private void btnAdd_Click(object sender, EventArgs e)
            {
                Int32 intPK = 0;
                int? intNAVID = this.tblNav.NAVID;
                int? intBTID = 0;

                intPK = clsGridUtil.AddGridRecord(intNAVID, this.APPID, intBTID, this.Associate.AS_User);

                BindGrid(intPK, gv1);
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


                        e.Handled = true;
                    }
                }
                catch (Exception ex)
                {

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

                    gv2.CurrentCell.Style.BackColor = Color.Beige;
                    pnlDates.Visible = false;
            }

            private void lnkOk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
            {
                gv2.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Tag = dtStart.Value.ToShortDateString();
                gv2.Rows[cell.RowIndex].Cells[cell.ColumnIndex].ToolTipText = dtEnd.Value.ToShortDateString();
                gv2.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Value = dtStart.Value.ToShortDateString() + " ~ " + dtEnd.Value.ToShortDateString();
                gv2.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Style.BackColor = Color.AliceBlue;
                pnlDates.Visible = false;

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
                BindGrid(0, gv1);
            }

        #endregion

            private void chkOmit_CheckedChanged(object sender, EventArgs e)
            {

            }



    }
}
