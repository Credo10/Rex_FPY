using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using HRLData;


namespace FPY
{
    public partial class frmMenu : clsForm
    {
        HRLEntities db = clsStart.efdb();
        BindingSource bs1 = new BindingSource();
        List<DataGridViewCell> cells = new List<DataGridViewCell>();
        Int32 intFindTotal = 0;
        Int32 intFindPosition = 0;

        public frmMenu()
        {
            InitializeComponent();
        }

        #region "FormEvents"

            private void frmCredoMD_Load(object sender, EventArgs e)
            {
                btnAdd.Tag = "Add New " + this.Text.ToString();

                var lstNav = new int[] { 71, 203};

                if (lstNav.Contains(this.tblNav.NAVID))
                {
                    btnAdd.Enabled = false;
                    btnSave.Enabled = false;
                    btnUndo.Enabled = false;
                }

                ShowImages();

                if (this.tblNav.NAVID == 9)
                {

                    try
                    {
                        List<p_DropDown_Result> q = db.p_DropDown(this.APPID, this.tblNav.NAVID, "BTID", "", this.Associate.ASID).ToList<p_DropDown_Result>();

                        var qry9 = (from ct in q
                                    select ct).ToList();

                        ddlFilter.DataSource = new BindingSource(qry9, null);
                        ddlFilter.DisplayMember = "Display";
                        ddlFilter.ValueMember = "ID";

                    }
                    catch (Exception ex)
                    {

                    }

                    this.pnlSpecial.Visible = true;
                    this.ddlFilter.Visible = true;
                    this.lblRoute.Visible = true;
                    return;
                }

                BindGrid(0, gv1);

               


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
            
            private void frmMenu_Shown(object sender, EventArgs e)
            {

                SetGridColor();
            }
        
        #endregion

        #region "Grid Events"

            public void BindGrid(Int32 intID, DataGridView gv)
            {

                switch (this.tblNav.NAVID)
                {

                    case 1:

                        var q1 = from ct in db.tblApp
                                 where ct.APP_Deleted.HasValue == false
                                       select ct;

                        if (intID > 0)
                        {
                            q1 = q1.OrderByDescending(w => w.APPID == intID).ThenBy(y => y.APP_Desc);
                        }
                        else
                        {
                            q1 = q1.OrderBy(w => w.APP_Desc);
                        }

                        var qry = (from ct in q1
                                   select ct).ToList();

                        BindGridData(qry, gv);

                        break;

                    case 9:

                        Int32 intSel = Convert.ToInt32(this.ddlFilter.SelectedValue.ToString());

                        var q9 = from ct in db.tblAppNavigation
                                 where ct.NAV_Deleted.HasValue == false
                                 && ct.BTID == intSel
                                 select ct;

                        if (intID > 0)
                        {
                            q9 = q9.OrderByDescending(w => w.NAVID == intID).ThenBy(y => y.NAV_Order);
                        }
                        else
                        {
                            q9 = q9.OrderBy(w => w.NAV_Order);
                        }


                        var qry9 = (from ct in q9
                                    select ct).ToList();

                        BindGridData(qry9, gv);

                        break;


          
                }

                clsGridUtil.ShowNewEntry(gv1, intID);


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



                        List<tblAppColumns> properties = (from Visible in db.tblAppColumns
                                                                  where Visible.NAVID == this.tblNav.NAVID
                                                                  && Visible.APC_Grid == gv.Name
                                                                  orderby Visible.APC_Order
                                                                  select Visible).ToList<tblAppColumns>();


                        //var lstDrops = new string[] { "Asid", "Arid", "Brrid", "Cmaid", "Cosupid", "Dstid", "Ftid", "MASTDSB", "MRPType", "Mastid", "Mrgtid", "Mrrid", "Rpid", "Rpdid", "Shaid", "Shmsid", "Vsid", "Vsgid", "Cosupid" };

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
                    //bs1.DataSource = result.ToList();
                    gv.DataSource = result;

                    SetGridColor();

                    //clsGridUtil.EncryptVisible(gv);

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
                        #region AddColumns

                        try
                        {

                            if (gv.Columns[e.ColumnIndex].Tag.ToString() == "17") 
                            {
                                //if (MessageBox.Show("Are you sure you want to Add Columns for this Nav Item?", this.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                //{
                                    string intNAVID = this.gv1.Rows[e.RowIndex].Cells["NAVID"].Value.ToString();
                                    string strTable = this.gv1.Rows[e.RowIndex].Cells["NAV_Table"].Value.ToString();
                                    string strServer = this.gv1.Rows[e.RowIndex].Cells["NAV_Server"].Value.ToString();
                                    string strPre = "_";
                                    string strGV = "gv1";

                                    db.p_AddColumns(intNAVID, strGV);

                                    string strSQL = "SELECT Column_NAME FROM " + strServer + ".INFORMATION_SCHEMA.Columns WHERE TABLE_NAME = '" + strTable + "'";

                                    DataSet ds = clsDAL.ProcessSQL(strSQL, strServer);

                                    if(clsUtility.dsHasData(ds))
                                    {
                                        strPre = ds.Tables[0].Rows[0].ItemArray[0].ToString().Substring(0, 2);
                                    }
                                    StringBuilder str = new StringBuilder();

                                    str.AppendLine("IF @NAVID =" + intNAVID);
                                    str.AppendLine();
                                    str.AppendLine("    BEGIN");
                                    str.AppendLine();
                                    str.AppendLine("        INSERT INTO " + strServer + ".dbo." + strTable + "(" + strPre + "_Desc)");
                                    str.AppendLine("        SELECT 'New " + strTable + "'");
                                    str.AppendLine();
                                    str.AppendLine("        SET @PK1 = Scope_Identity()");
		                            str.AppendLine();
                                    str.AppendLine("    END");
                                    str.AppendLine();
                                    str.AppendLine();
                                    str.AppendLine("**************************************");
                                    str.AppendLine("case " + intNAVID + ":");
                                    str.AppendLine();
                                    str.AppendLine("var q" + intNAVID + " = from ct in db." + strTable);
                                    str.AppendLine("where ct." + strPre + "_Deleted.HasValue == false");
                                    str.AppendLine("select ct;");
                                    str.AppendLine();
                                    str.AppendLine("if (intID > 0)");
                                    str.AppendLine("{");
                                    str.AppendLine("    q" + intNAVID + " = q" + intNAVID + ".OrderByDescending(w => w." + strPre + "ID== intID).ThenBy(y => y." + strPre + "_Desc);");
                                    str.AppendLine("}");
                                    str.AppendLine("else");
                                    str.AppendLine("{");
                                    str.AppendLine("    q" + intNAVID + " = q" + intNAVID + " .OrderBy(w => w." + strPre + "_Desc);");
                                    str.AppendLine("}");
                                    str.AppendLine();
                                    str.AppendLine("var qry" + intNAVID + "  = (from ct in q" + intNAVID );
                                    str.AppendLine("            select ct).ToList();");
                                    str.AppendLine();
                                    str.AppendLine("BindGridData(qry" + intNAVID + " , gv);");
                                    str.AppendLine();
                                    str.AppendLine("break;");
                                    str.AppendLine();

                                    this.txtOutput.Text = str.ToString();



                                }
                            //}
                        }
                        catch(Exception ex)
                        {

                        }

                        #endregion

                        #region "OpenApp"

                        try
                        {

                            if (gv.Columns[e.ColumnIndex].Tag.ToString() == "27")
                            {
                                Int32 intAPP = clsGridUtil.GetPK(gv1);
                                clsStart.PostMain(intAPP, 0, "",0);
                                fHandled = true;

                            }
                        }
                        catch (Exception ex)
                        {

                        }
                        #endregion

                        #region "Release"

                        try{

                            if (gv.Columns[e.ColumnIndex].Tag.ToString() == "18") 
                        {

                            fHandled = true;

                            string strApp = gv.Rows[e.RowIndex].Cells["APP_Desc"].Value.ToString();


                            try
                            {


                                string strFld = "app"; // gv1.Rows[e.RowIndex].Cells[gv1.Columns["APFolder"].Index].Value.ToString().TrimEnd();
                                string strVer = gv1.Rows[e.RowIndex].Cells[gv1.Columns["APP_Version"].Index].Value.ToString().TrimEnd();

                                Int32 intPreVer = 0;
                                Int32 intPreVerDecimal = 0;
                                //Int32 intPreVer = 0;

                                if (MessageBox.Show("Are you sure you want to Release '" + strApp + "' ?", this.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {

                                    this.txtOutput.Text = "";

                                    //string strFolder = gv.Rows[e.RowIndex].Cells[gv.Columns["APP_DesignFolder"].Index].Value.ToString();

                                    string strFolder = System.Windows.Forms.Application.StartupPath.ToString().Replace("Debug", "Release");

                                    string strDestPre = gv.Rows[e.RowIndex].Cells[gv.Columns["APP_ReleaseFolder"].Index].Value.ToString();
                                    string strPreVer = "";


                                    try
                                    {
                                        intPreVerDecimal = Convert.ToInt32(strVer.Substring(strVer.Length - 1, 1)) - 1;
                                        if (intPreVerDecimal == -1)
                                        {
                                            // Current version is (*).0 so previous version is (*-1).9
                                            intPreVerDecimal = 9;
                                            intPreVer = Convert.ToInt32(strVer.Substring(0, strVer.Length - 2)) - 1;
                                        }
                                        else
                                        {
                                            intPreVer = Convert.ToInt32(strVer.Substring(0, strVer.Length - 2));
                                        }
                                        //strPreVer = Path.Combine(strDestPre, strFld + strVer.Substring(0, strVer.Length - 1) + intPreVerDecimal.ToString());
                                        strPreVer = Path.Combine(strDestPre, strFld + intPreVer.ToString() + "." + intPreVerDecimal.ToString());
                                    }

                                    catch (Exception ex)
                                    {

                                    }


                                    strDestPre = Path.Combine(strDestPre, strFld + strVer + "\\");

                                    DirectoryInfo diP = new DirectoryInfo(strDestPre);


                                    string strReleaseEXE = gv.Rows[e.RowIndex].Cells[gv.Columns["APP_EXE"].Index].Value.ToString();
                                    string strDesignEXE = gv.Rows[e.RowIndex].Cells[gv.Columns["APP_DesignEXE"].Index].Value.ToString();

                                    Boolean fFound = false;

                                    StringBuilder strBody = new StringBuilder();
                                    DirectoryInfo di = new DirectoryInfo(strDestPre);

                                    if (di.Exists == false)
                                    {
                                        di.Create();
                                        DirectoryInfo dipv = new DirectoryInfo(strPreVer);

                                        if (!(dipv.Exists)) //may be that the current folder has no version number
                                        {
                                            strPreVer = strPreVer.Substring(0, strPreVer.Length - strVer.Length);
                                            dipv = new DirectoryInfo(strPreVer);
                                        }
                                        strBody.AppendLine();
                                        strBody.AppendLine();
                                        strBody.Append("******************Creating new release folder from former location" + strApp).AppendLine();

                                        CopyDirectory(dipv, di);

                                    }

                                    var filelist = di.GetFiles("*.*");
                                    string strDest = "";

                                    DirectoryInfo di2 = new DirectoryInfo(strFolder);
                                    filelist = di2.GetFiles("*.*");


                                    DirectoryInfo dil2 = new DirectoryInfo(strDestPre);
                                    var filelocal = dil2.GetFiles("*.*");

                                    strBody.AppendLine();
                                    strBody.AppendLine();
                                    strBody.Append("******************Releasing " + strApp).AppendLine();
                                    strBody.AppendLine();
                                    strBody.AppendLine();
                                    this.txtOutput.Text = strBody.ToString();
                                    this.Update();


                                    //copy root files
                                    try
                                    {
                                        foreach (FileInfo file in filelist)
                                        {

                                            //Debug.Print(file.Name);

                                            if (file.Name.ToString().EndsWith("pdb") | file.Name.ToString().EndsWith("bat") | file.Name.ToString().EndsWith("lnk") | file.Name.ToString().EndsWith("manifest") | file.Name.ToString().Contains("vshost") | file.Name.ToString().EndsWith("mdb") | file.Name.ToString().EndsWith("scc"))
                                            {
                                                continue;
                                            }

                                            if (file.Name.ToString().ToUpper() == strDesignEXE.ToUpper())
                                            {
                                                strDest = Path.Combine(strDestPre, strReleaseEXE);
                                                strBody.Append(file.ToString() + " as " + strReleaseEXE).AppendLine();
                                            }
                                            else if (file.Name.ToString().EndsWith("config"))
                                            {
                                                strDest = Path.Combine(strDestPre, file.Name.Replace(strDesignEXE, strReleaseEXE));
                                            }
                                            else
                                            {
                                                strDest = Path.Combine(strDestPre, file.Name);
                                                strBody.Append(file.ToString()).AppendLine();
                                            }

                                            fFound = false;

                                            this.txtOutput.Text = strBody.ToString();
                                            this.Update();


                                            foreach (FileInfo fl in filelocal)
                                            {
                                                if (fl.Name.ToString().ToUpper() == file.Name.ToString().ToUpper() | (fl.Name.ToString().ToUpper() == strReleaseEXE.ToString().ToUpper() && file.Name.EndsWith("exe")))
                                                {
                                                    fFound = true;

                                                    if (fl.LastWriteTime < file.LastWriteTime)
                                                    {

                                                        if (fl.Name.ToString().ToUpper() == strDesignEXE.ToString().ToUpper() | fl.Name.ToString().ToUpper() == strReleaseEXE.ToString().ToUpper())
                                                        {
                                                            strDest = Path.Combine(strDestPre, strReleaseEXE);
                                                            strBody.Append("Copying......" + file.Name.ToString() + " as " + strReleaseEXE).AppendLine();
                                                            strBody.AppendLine();
                                                        }
                                                        else if (file.Name.ToString().EndsWith("config"))
                                                        {
                                                            strDest = Path.Combine(strDestPre, file.Name.Replace(strDesignEXE, strReleaseEXE));
                                                        }
                                                        else
                                                        {
                                                            strBody.Append("Copying......" + file.Name.ToString()).AppendLine();
                                                            strBody.AppendLine();
                                                        }
                                                        this.txtOutput.Text = strBody.ToString();
                                                        this.Update();
                                                        try
                                                        {
                                                            File.Copy(Path.Combine(file.DirectoryName, file.Name), strDest, true);
                                                        }
                                                        catch (System.Exception eMain)
                                                        {
                                                            strBody.Append(eMain.Message.ToString()).AppendLine();
                                                            strBody.AppendLine();
                                                            this.txtOutput.Text = strBody.ToString();
                                                            this.Update();
                                                        }
                                                    }
                                                }
                                            }

                                            if (fFound == false)
                                            {
                                                strDest = strDestPre + file.Name;

                                                if (file.Name.ToString().ToUpper() == strDesignEXE.ToString().ToUpper() | file.Name.ToString().ToUpper() == strReleaseEXE.ToString().ToUpper())
                                                {
                                                    strDest = Path.Combine(strDestPre, strReleaseEXE);
                                                    strBody.Append("Creating......" + file.Name.ToString() + " as " + strReleaseEXE).AppendLine();
                                                    strBody.AppendLine();
                                                }
                                                else if (file.Name.ToString().EndsWith("config"))
                                                {
                                                    strDest = Path.Combine(strDestPre, file.Name.Replace(strDesignEXE, strReleaseEXE));
                                                }
                                                else
                                                {
                                                    strBody.Append("Creating......" + file.Name.ToString()).AppendLine();
                                                    strBody.AppendLine();
                                                }

                                                this.txtOutput.Text = strBody.ToString();
                                                this.Update();
                                                try
                                                {
                                                    File.Copy(Path.Combine(file.DirectoryName, file.Name), strDest, true);
                                                }
                                                catch (System.Exception eMain)
                                                {
                                                    strBody.Append(eMain.Message.ToString()).AppendLine();
                                                    strBody.AppendLine();
                                                    this.txtOutput.Text = strBody.ToString();
                                                    this.Update();
                                                }
                                            }



                                        }

                                        strBody.AppendLine();
                                        strBody.AppendLine();
                                        strBody.Append("******************Main Complete!").AppendLine();
                                        strBody.AppendLine();
                                        this.txtOutput.Text = strBody.ToString();
                                        this.Update();
                                    }
                                    catch (System.Exception eMain)
                                    {
                                        strBody.Append(eMain.Message.ToString()).AppendLine();
                                        strBody.AppendLine();
                                        this.Update();
                                    }

                                    //could loop though these, but not every app needs all sub folders
                                    //copy reports
                                    strFolder = strFolder.Replace("Release", "Debug");

                                    string strReportPath = Path.Combine(strFolder, "Reports");
                                    string strReportDest = Path.Combine(strDestPre, "Reports");
                                    DirectoryInfo diReport = new DirectoryInfo(strReportPath);
                                    DirectoryInfo diReportDest = new DirectoryInfo(strReportDest);
                                    //CopyDirectory(diReport, diReportDest);

                                    strBody.AppendLine();
                                    strBody.AppendLine();
                                    strBody.Append("******************Report Complete!").AppendLine();
                                    strBody.AppendLine();
                                    this.txtOutput.Text = strBody.ToString();
                                    this.Update();

                                    //copy images
                                    if (this.APPID == 11) //QVS
                                    {
                                        strReportPath = Path.Combine(strFolder, "Images");
                                        strReportDest = Path.Combine(strPreVer, "Images");
                                        DirectoryInfo diImage = new DirectoryInfo(strReportPath);
                                        DirectoryInfo diImageDest = new DirectoryInfo(strReportDest);
                                        CopyDirectory(diReport, diImageDest);

                                        strBody.AppendLine();
                                        strBody.AppendLine();
                                        strBody.Append("******************Images Complete!").AppendLine();
                                        strBody.AppendLine();
                                        this.txtOutput.Text = strBody.ToString();
                                        this.Update();
                                    }

                                    strBody.AppendLine();
                                    strBody.AppendLine();
                                    strBody.Append("******************DONE!").AppendLine();
                                    strBody.AppendLine();
                                    this.txtOutput.Text = strBody.ToString();
                                    this.Update();

                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString(), this.AppName);
                            }


                        }
                         }
                        catch(Exception ex)
                        {

                        }
                        #endregion


                        #region AddFilterColumns

                        try
                        {

                            if (gv.Columns[e.ColumnIndex].Tag.ToString() == "24")
                            {
                                if (MessageBox.Show("Are you sure you want to Add Filter Columns for this Nav Item?", this.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {

                                    UpdateData(true);

                                    string intNAVID = this.gv1.Rows[e.RowIndex].Cells["NAVID"].Value.ToString();
                                    string intNAV_GV2 = this.gv1.Rows[e.RowIndex].Cells["NAV_GV2"].Value.ToString();

                                    if (intNAV_GV2.ToString() + "" == "")
                                    {
                                        MessageBox.Show("Please add a GV2 value of an existsing NAVID",this.AppName);
                                        return;
                                    }

                                    string strGV = "gv1";

                                    db.p_AddFilterColumns(intNAVID);

                                    MessageBox.Show("Done", this.AppName);
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }

                        #endregion

                    }
                    catch (Exception ex)
                    {

                    }
                }

            }

            private void ddlFilter_SelectionChangeCommitted_1(object sender, EventArgs e)
            {
                BindGrid(0, gv1);
            }

            private void SetGridColor()
            {
                try
                {

                    if (this.tblNav.NAVID == 102)
                    {
                        Int32 intVisibleFore = gv1.Columns["SHCTForeColor"].Index;
                        Int32 intVisibleBack = gv1.Columns["SHCTColor"].Index;
                        Int32 intVisibleType = gv1.Columns["SHCTDesc"].Index;

                        foreach (DataGridViewRow row in gv1.Rows)
                        {
                            try
                            {
                                Int32 intForeColor = Convert.ToInt32(row.Cells[intVisibleFore].Value.ToString());
                                Int32 intBackColor = Convert.ToInt32(row.Cells[intVisibleBack].Value.ToString());

                                Color BackColor = Color.FromArgb(intBackColor);
                                Color foreColor = Color.FromArgb(intForeColor);

                                row.Cells[intVisibleType].Style.BackColor = BackColor;
                                row.Cells[intVisibleType].Style.ForeColor = foreColor;
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
    

        #endregion

        #region "Data Events"

            private string UpdateData(Boolean fShowMsg)
            {
                this.gv1.EndEdit();

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

                    foreach (var entry in changedEntries.Where(x=>x.State ==  System.Data.Entity.EntityState.Modified))
                    {
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = System.Data.Entity.EntityState.Unchanged;
                    }

                    foreach (var entry in changedEntries.Where(x=>x.State ==  System.Data.Entity.EntityState.Added))
                    {
                        entry.State = System.Data.Entity.EntityState.Detached;
                    }

                    foreach (var entry in changedEntries.Where(x=>x.State ==  System.Data.Entity.EntityState.Deleted))
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
                try
                {
                    intBTID = Convert.ToInt32(this.ddlFilter.SelectedValue.ToString());
                }
                catch (Exception ex) { }

                intPK = clsGridUtil.AddGridRecord(intNAVID, this.APPID, intBTID, this.Associate.AS_User);

                BindGrid(intPK, gv1);

              
            }

            private void btnExport_Click(object sender, EventArgs e)
            {
                //DataTable dt =  clsExport.GVToDataTable(gv1, true);
                //clsExport.ExcelExport(dt, "", true, true);
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

        #region "Misc"
        

        static void CopyDirectory(DirectoryInfo source, DirectoryInfo destination)
            {
                if (!destination.Exists)
                {
                    destination.Create();
                }

                if (source.Exists)
                {
                    // Copy all files.
                    FileInfo[] files = source.GetFiles();
                    foreach (FileInfo file in files)
                    {
                        file.CopyTo(Path.Combine(destination.FullName, file.Name), true);
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

   
        }


            private void ShowImages()
            {
                Int32 intNums = 0;

                lstImageView.Visible = true;
                

                frmNavigate f = (frmNavigate)this.MdiParent;

                lstImageView.LargeImageList = f.lstImage;
                intNums = f.lstImage.Images.Count;

                var query = (from app in db.Nums
                             where app.n < intNums
                             select app).ToList();

                try
                {
                    Int32 i = 0;
                    foreach (var r in query)
                    {
                        this.lstImageView.Items.Add(r.n.ToString());
                        this.lstImageView.Items[i].ImageIndex = r.n;

                        i = i + 1;
                    }
                }
                catch (System.ArgumentOutOfRangeException exc)
                {
                    //Debug.WriteLine("Out of range" + exc.Message);
                }

            }








        #endregion

        private void lnkExport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            frmNavigate f = (frmNavigate)this.MdiParent;
            ImageList il = f.lstImage;
            string strPath = Path.GetTempPath().ToString();


            for (int x = 0; x < il.Images.Count; ++x)
            {
                strPath = Path.Combine(strPath, "tmpimage");

                if(!(System.IO.Directory.Exists(strPath)))
                {
                    Directory.CreateDirectory(strPath);
                }
                strPath = Path.Combine(strPath, x.ToString() + ".bmp");

                try
                {
                    Image temp = imageList1.Images[x];
                   
                    temp.Save(strPath);
                }
                catch(Exception ex)
                {

                }
            }
        }
    }
}
