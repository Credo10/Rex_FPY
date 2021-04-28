using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Collections;
using System.IO;
using HRLData;


namespace FPY
{

    public class DataGridViewColumnCredo :DataGridViewColumn
    {
        public DataGridViewColumnCredo()
        {
            this.CellTemplate =  new DataGridViewTextBoxCell();
        }

        public string DataPropertyFilterName { get; set; }

    }

    public class clsGridUtil
    {
      

        public static void SetColBackColor(string colName, string hexString)
        {
            
        }
        public static void SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            var gv = (clsGridView)sender;

            DataGridViewColumn col = gv.Columns[e.Column.Index];

            Int32 intTag = 1;

            try
            {
                intTag = Convert.ToInt32(col.Tag.ToString());
            }
            catch (Exception ex)
            {

            }

            string value1 = "";
            string value2 = "";

            var lstDropdown = new int[] { 2, 21, 28, 31 };

            if (lstDropdown.Contains(intTag))
            {
                gv.Rows[e.RowIndex1].Cells[e.Column.Index].FormattedValue.ToString();
                gv.Rows[e.RowIndex2].Cells[e.Column.Index].FormattedValue.ToString();
            }
            else
            {
                gv.Rows[e.RowIndex1].Cells[e.Column.Index].Value.ToString();
                gv.Rows[e.RowIndex2].Cells[e.Column.Index].Value.ToString();
            }

            e.SortResult = System.String.Compare(value1, value2);
            e.Handled = true;
        }
        public static void gv_SortDropDown(object sender, DataGridViewSortCompareEventArgs e)
        {
            var dgv = (DataGridView)sender;
            string value1 = dgv.Rows[e.RowIndex1].Cells[e.Column.Index].FormattedValue.ToString();
            string value2 = dgv.Rows[e.RowIndex2].Cells[e.Column.Index].FormattedValue.ToString();

            e.SortResult = System.String.Compare(value1, value2);
            e.Handled = true;
        }
        public static decimal SumColumn(DataGridView gv, Int32 col)
        {
            Decimal dec = 0;

            foreach(DataGridViewRow row in gv.Rows)
            {
                try
                {
                    dec = dec + Convert.ToDecimal(row.Cells[col].Value.ToString());
                }
                catch(Exception ex)
                {

                }
            }

            return dec;
        }

        public static void SaveFormGridSettings(DataGridView gv, int intASID, int intNAVID)
        {
            HRLEntities db = clsStart.efdb();

            try
            {


                foreach (DataGridViewColumn col in gv.Columns)
                {

                    Int32 intSort = col.DisplayIndex;

                    Int32 intWidth = 0;
                    if (col.Visible == true)
                    {
                        intWidth = col.Width;
                    }

                    Int32 intAPCID = 0;

                    //this is a custom value...so we have to use reflection to get the value
                    try
                    {
                        string APCID = col.GetType().GetProperty("APCID").GetValue(col, null).ToString();
                        intAPCID = Convert.ToInt32(APCID);
                    }
                    catch (Exception ex)
                    {

                    }

                    try
                    {
                        db.p_tblAppNavigationUserGrid_Add(intNAVID, intASID, intAPCID, intWidth, intSort);

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



        public static List<tblAppColumns> GetUserColumns(int intNAVID, int intASID, string strGrid, int intFilterField)
        {

            string strSQL = "p_tblAppNavigationUserGrid_Load " + intNAVID.ToString() + ", " + intASID.ToString() + ", '" + strGrid + "', " + intFilterField.ToString();

            DataSet ds = clsDAL.ProcessSQL(strSQL, "APP");

            DataTable dt = ds.Tables[0];

            List<tblAppColumns> listName = dt.AsEnumerable().Select(m => new tblAppColumns()
            {
                APCID = m.Field<int>("APCID"),
                NAVID = m.Field<int>("NAVID"),
                APCOID = m.Field<int>("APCOID"),
                APC_Desc = m.Field<string>("APC_Desc"),
                APC_Name = m.Field<string>("APC_Name"),
                APC_Width = m.Field<int>("APC_Width"),
                APC_Order = m.Field<int>("APC_Order"),
                APC_Grid = m.Field<string>("APC_Grid"),
                APC_ReadOnly = m.Field<Boolean?>("APC_ReadOnly"),
                APC_Deleted = m.Field<DateTime?>("APC_Deleted"),
                APC_Default = m.Field<string>("APC_Default"),
                APC_QueryField = m.Field<string>("APC_QueryField")

            }).OrderBy(z => z.APC_Order).ToList();

            return listName;

        }
        public static void SetGridRowHeight(DataGridView gv)
        {

            try
            {
                //find columns that should wrap
                var result = from DataGridViewColumn col in gv.Columns
                             where col.Tag.ToString() == "29"
                              
                             select col;

                List<DataGridViewCell> cells = new List<DataGridViewCell>();

                foreach (DataGridViewColumn idx in result)
                {

                    try
                    {
                        var cell = from DataGridViewRow row in gv.Rows
                                   where row.Cells[idx.Index].Value.ToString() + "" != ""
                                   select row.Cells[idx.Index];

                        cells.AddRange(cell);
                    }
                    catch(Exception ex)
                    {

                    }
                }


                foreach (DataGridViewCell cell in cells)
                {
                    DataGridViewTextBoxCell cbx = (DataGridViewTextBoxCell)cell;
                    cbx.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                    cbx.Style.WrapMode = DataGridViewTriState.True;
                    gv.AutoResizeRow(cell.RowIndex, DataGridViewAutoSizeRowMode.AllCells);

                    }



            }
            catch (Exception ex)
            {

            }
        }

        public static int GetCellValueInt(DataGridViewRow row, string strCol)
        {
            int intRet = 0;

            try
            {
                intRet = Convert.ToInt32(row.Cells[strCol].Value.ToString());
            }
            catch (Exception ex)
            {

            }

            return intRet;
        }

        public static string CellValStr(DataGridViewRow row, string strCol)
        {
            string strRet = "";

            try
            {
                strRet = row.Cells[strCol].Value.ToString();
            }
            catch (Exception ex)
            {

            }

            return strRet;
        }

        public static string CellValStrQuote(DataGridViewRow row, string strCol)
        {
            string strRet = "";

            try
            {
                strRet = row.Cells[strCol].Value.ToString();
            }
            catch (Exception ex)
            {

            }

            return "'" + strRet + "'";
        }
        public static string DynamicWhere(DataGridView gv)
      {
          string strWhere = "";

          try
          {

              foreach (DataGridViewCell cell in gv.Rows[0].Cells)
              {
                  try
                  {
                      if (cell.Value == null || cell.Value.Equals(""))
                      {
                          continue;
                      }
                      else
                      {
                          try
                          {
                              DataGridViewColumnCredo col = (DataGridViewColumnCredo)gv.Columns[cell.ColumnIndex];
                              strWhere = strWhere + " && " + col.DataPropertyFilterName.ToString() + ".Contains('" + cell.Value.ToString() +  "')";

                          }
                          catch (Exception ex)
                          {

                          }
                          try
                          {
                              DataGridViewComboBoxColumnCredo col = (DataGridViewComboBoxColumnCredo)gv.Columns[cell.ColumnIndex];
                              DataGridViewComboBoxCell cl = (DataGridViewComboBoxCell)cell;
                              string strVal = cl.Value.ToString();
                              if (strVal != "0")
                              {
                                  strWhere = strWhere + " && " + col.DataPropertyFilterName.ToString() + "==" + cl.Value.ToString();
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
          }
          catch(Exception ex)
          {
              return "";
          }

          if (strWhere != "")
          {
              strWhere = strWhere.Substring(3, strWhere.Length -3);
              strWhere = strWhere.Replace("'", "\"");
              return strWhere;
          }
          else
          {
              return strWhere;
          }
      }

        public static void EncryptCol(DataGridView gv)
        {

            

            ArrayList al = new ArrayList();

            al.Add("Associate");
            al.Add("Asscoiate");
            al.Add("WODesc");
            al.Add("PARTDesc");
            al.Add("PARTTX");
            al.Add("SHDesc");
            al.Add("CSNDesc");
                

            foreach (string strCol in al)
            {
                try
                {
                    if (gv.Columns[strCol].Index > 0)
                    {

                        foreach (DataGridViewRow row in gv.Rows)
                        {

                            try
                            {
                               // row.Cells[strCol].Value = Encryption.clsEncrypt.Encrypt(row.Cells[strCol].Value.ToString());
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
        }

        public static void PasteValue(DataGridView gv, DataGridViewCell oCell)
         {


            try
            {
                string s = Clipboard.GetText();
                string[] lines = s.Split('\n');
                int iFail = 0;
                int iRow = gv.CurrentCell.RowIndex;
                int iCol = gv.CurrentCell.ColumnIndex;
                //DataGridViewCell oCell;


                //if (lines.Length > gv.Rows.Count)
                //{
                //    MessageBox.Show("Pasted content has more lines than will fit.", "OTD");
                //    return;
                //}




                foreach (string line in lines)
                {
                    if (iRow < gv.RowCount && line.Length > 0)
                    {
                        string[] sCells = line.Split('\t');

                        //if (sCells.Length > gv.Columns.Count)
                        //{
                        //    MessageBox.Show("Pasted content has more columns than will fit.", "OTD");
                        //    return;
                        //}

                        for (int i = 0; i < sCells.GetLength(0); ++i)
                        {
                            if (iCol + i < gv.ColumnCount)
                            {
                                //oCell = gv[iCol + i, iRow];

                                //if (!oCell.ReadOnly)
                                //{
                                //    if (oCell.Value == null || oCell.Value.ToString() != sCells[i])
                                //    {
                                        //oCell.Value = Convert.ChangeType(sCells[i],
                                        //oCell.ValueType);
                                        gv.Rows[iRow].Cells[iCol + i].Value = sCells[i];
                                        //oCell.Style.BackColor = Color.Tomato;
                                    //}
                                    //else
                                    //{
                                    //    iFail++;
                                    //}
                                //}
                            }
                            else
                            { 
                                break; 
                            }
                        }

                        iRow++;
                    }
                    else
                    { 
                        break; 
                    }

                    //if (iFail > 0)
                    //{
                    //    MessageBox.Show(string.Format("{0} updates failed due" +
                    //                    " to read only column setting", iFail));
                    //}
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("The data you pasted is in the wrong format for the cell", "Credo");
                return;

            }


         }

        public static void SetBITColumns(DataGridView gv)
        {
            try
            {

               var cols = (from DataGridViewColumn col in gv.Columns
                           where (string)col.Tag.ToString() == "26"
                           select col.Index).ToList();


                List<DataGridViewCell>  cells = gv.Rows.Cast<DataGridViewRow>()
                               .SelectMany(row => gv.Columns.Cast<DataGridViewColumn>()
                               .Select(col => row.Cells[col.Name]))
                               .Where(cell => cols.Contains(cell.ColumnIndex)).ToList<DataGridViewCell>();


                foreach (DataGridViewCell cell in cells)
                {
                    DataGridViewLinkCell lnk = (DataGridViewLinkCell)cell;
                    if (cell.Value.ToString() == "True")
                    {
                        lnk.LinkColor = Color.Green;
  
                    }
                    else
                    {
                        lnk.LinkColor = Color.Firebrick;
                    }

                }

                gv.Refresh();
            }
            catch (Exception ex)
            {

            }
        }

        public static void SetBITColumnsFullColor(DataGridView gv)
        {
            try
            {

                var cols = (from DataGridViewColumn col in gv.Columns
                            where (string)col.Tag.ToString() == "40"
                            select col.Index).ToList();


                List<DataGridViewCell> cells = gv.Rows.Cast<DataGridViewRow>()
                               .SelectMany(row => gv.Columns.Cast<DataGridViewColumn>()
                               .Select(col => row.Cells[col.Name]))
                               .Where(cell => cols.Contains(cell.ColumnIndex)).ToList<DataGridViewCell>();


                foreach (DataGridViewCell cell in cells)
                {

                    if (cell.Value.ToString() == "True")
                    {
                        cell.Style.BackColor = Color.Firebrick;
                        cell.Style.ForeColor = Color.Firebrick;

                    }
                    else
                    {
                        cell.Style.BackColor = Color.PaleGreen;
                        cell.Style.ForeColor = Color.PaleGreen;
                    }

                }

                gv.Refresh();
            }
            catch (Exception ex)
            {

            }
        }

        public static void SetGridColor(DataGridView gv)
        {

            string strForeLink = "";
            string strBackLink = "";
            Int32 intFore = 0;
            Int32 intBack = 0;
            Int32 intBIT = 0;



            try
            {

                try
                {
                    string strName = (from c in gv.Columns.Cast<DataGridViewColumn>()
                        where c.Tag.ToString() == "35"
                        select c.Name).First();

                    Int32 intColVal = (from c in gv.Columns.Cast<DataGridViewColumn>()
                        where c.Name == strName
                              && c.Tag.ToString() != "35"
                        select c.Index).First();


                    Int32 intCol = (from c in gv.Columns.Cast<DataGridViewColumn>()
                        where c.Name == strName
                              && c.Tag.ToString() == "35"
                        select c.Index).First();



                    foreach (DataGridViewRow row in gv.Rows)
                    {
                        try
                        {
                            string strHex = row.Cells[intColVal].Value.ToString();

                            Color color = System.Drawing.ColorTranslator.FromHtml(strHex);
                            Color ForeColor = ContrastColor(color);
                            gv.Rows[row.Index].Cells[intCol].Style.BackColor = color;

                            DataGridViewLinkCell lnk = (DataGridViewLinkCell) gv.Rows[row.Index].Cells[intCol];

                            lnk.LinkColor = ForeColor;

                        }
                        catch (Exception ex)
                        {

                        }
                    }


                }
                catch (Exception ex)
                {

                }
                try
                {
                    strForeLink = (from ct in gv.Columns.Cast<DataGridViewColumn>()
                        where ct.Tag.ToString() == "9"
                        select ct.Name).First();
                }
                catch (Exception ex)
                {

                }

                try
                {
                    strBackLink = (from ct in gv.Columns.Cast<DataGridViewColumn>()
                        where ct.Tag.ToString() == "15"
                        select ct.Name).First();
                }
                catch (Exception ex)
                {

                }

                try
                {
                    intFore = (from c in gv.Columns.Cast<DataGridViewColumn>()
                        where c.Name == strForeLink
                              && c.Tag.ToString() != "9"
                        select c.Index).First();
                }
                catch (Exception ex)
                {

                }

                try
                {
                    intBack = (from c in gv.Columns.Cast<DataGridViewColumn>()
                        where c.Name == strBackLink
                              && c.Tag.ToString() != "15"
                        select c.Index).First();
                }
                catch (Exception ex)
                {

                }

                gv.CurrentCell = null;


                if (intFore > 0 && intBack > 0)
                {
                    var lst = from c in gv.Columns.Cast<DataGridViewTextBoxColumn>()
                        where c.Width > 0
                        select c;

                    if (intFore > 0 && intBack > 0)
                    {
                        foreach (DataGridViewRow row in gv.Rows)
                        {
                            try
                            {
                                Int32 intForeColor = Convert.ToInt32(row.Cells[intFore].Value.ToString());
                                Int32 intBackColor = Convert.ToInt32(row.Cells[intBack].Value.ToString());

                                Color backcolor = Color.FromArgb(intBackColor);
                                Color forecolor = Color.FromArgb(intForeColor);

                                foreach (DataGridViewColumn dc in lst)
                                {
                                    row.Cells[dc.Index].Style.BackColor = backcolor;
                                    row.Cells[dc.Index].Style.ForeColor = forecolor;
                                }

                            }
                            catch (Exception ex)
                            {

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public static Boolean Grid_CellClick(DataGridView gv, DataGridViewCellEventArgs e)
        {

            Boolean fHandled = false;

          

            #region "BIT Column"

            try
            {

                if (gv.Columns[e.ColumnIndex].Tag.ToString() == "26")
                {
                     if(gv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "True")
                     {
                         DataGridViewLinkCell lnk = (DataGridViewLinkCell)gv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                         lnk.VisitedLinkColor = Color.Firebrick;
                         gv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = (Boolean)false;
                         
                     }
                     else
                     {
                         DataGridViewLinkCell lnk = (DataGridViewLinkCell)gv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                         lnk.VisitedLinkColor = Color.Green;
                         gv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = (Boolean)true; 
                     }

                     gv.CurrentCell = null;

                     return true;
                }
            }
            catch (Exception ex)
            {

            }


            #endregion

            #region "ColorDialog

            try
            {

            if (gv.Columns[e.ColumnIndex].Tag.ToString() == "9" || gv.Columns[e.ColumnIndex].Tag.ToString() == "15")
            {

                ColorDialog cd = new ColorDialog();

                DialogResult result = cd.ShowDialog();
                if (result.Equals(DialogResult.OK))
                {
                    string strName = gv.Columns[e.ColumnIndex].Name;

                    string strColor = cd.Color.Name;
                    Int32 intColor = clsFormUtil.ConvertColorNameToValue(strColor);
                    Int32 intCol = 0;

                    try 
                    {
 
                    }
                    catch(Exception ex)
                    {

                    }
                    //find a column that is a textbox column by the same name
                    foreach (DataGridViewColumn dc in gv.Columns)
                    {
                       
                        if (dc.GetType() == typeof(DataGridViewTextBoxColumn))
                        {

                            if (dc.DataPropertyName == strName)
                            {
                                gv.Rows[e.RowIndex].Cells[dc.Index].Value = intColor;
                            }

                            if (gv.Columns[e.ColumnIndex].Tag.ToString() == "9")
                            {
                                gv.Rows[e.RowIndex].Cells[dc.Index].Style.ForeColor = cd.Color;
                            }
                            if (gv.Columns[e.ColumnIndex].Tag.ToString() == "15")
                            {
                                gv.Rows[e.RowIndex].Cells[dc.Index].Style.BackColor = cd.Color;
                            }
                        }
                    }

                   

                  

                }

            }
               }
                    catch (Exception ex)
                    {

                    }


            #endregion


            #region "ColorHEXDialog

            try
            {

                if (gv.Columns[e.ColumnIndex].Tag.ToString() == "35")
                {

                    ColorDialog cd = new ColorDialog();

                    DialogResult result = cd.ShowDialog();
                    if (result.Equals(DialogResult.OK))
                    {
                        string strName = gv.Columns[e.ColumnIndex].Name;

                        string strColor = cd.Color.Name;
                        string strHex = "";
                       
                        try
                        {

                            strHex = "#" + cd.Color.R.ToString("X2") + cd.Color.G.ToString("X2") + cd.Color.B.ToString("X2");

                        }
                        catch (Exception ex)
                        {

                        }

                        try
                        {
                            Int32 intCol = (from c in gv.Columns.Cast<DataGridViewColumn>()
                                            where c.Name == strName
                                       && c.Tag.ToString() != "35"
                                       select c.Index).First();

                            gv.Rows[e.RowIndex].Cells[intCol].Value = strHex;
                        }
                        catch(Exception ex)
                        {

                        }

                        Color color = System.Drawing.ColorTranslator.FromHtml(strHex);
                        Color ForeColor = ContrastColor(color);
                        gv.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = color;

                        DataGridViewLinkCell lnk = (DataGridViewLinkCell)gv.Rows[e.RowIndex].Cells[e.ColumnIndex];

                        lnk.VisitedLinkColor = ForeColor;
                        gv.CurrentCell = null;
                    }

                }
            }
            catch (Exception ex)
            {

            }


            #endregion

            #region "Deletes"
            try
            {
                if (gv.Columns[e.ColumnIndex].Tag.ToString() == "10")
                {
                    try
                    {
                        fHandled = true;
                        if (MessageBox.Show("Delete this Row?", "Credo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {



                            var delDone = false;
                            try
                            {
                               

                               

                            }
                            catch(Exception ex)
                            {

                            }


                            
                           

                            Int32 intDel = 0;

                            foreach (DataGridViewColumn col in gv.Columns)
                            {
                                if (col.Name.EndsWith("Deleted"))
                                {
                                    intDel = col.Index;
                                }
                            }

                            if (!delDone)
                            {
                                if (intDel > 0)
                                {


                                    gv.Rows[e.RowIndex].Cells[intDel].Value = DateTime.Now.ToLongDateString();

                                    Int32 intRow = gv.CurrentRow.Index;

                                    gv.CurrentCell = null;
                                    gv.Rows[intRow].Visible = false;


                                }
                                else
                                {
                                    gv.Rows.Remove(gv.CurrentRow);
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

            #region "Highlight"

            try
            {

                if (gv.Columns[e.ColumnIndex].Tag.ToString() == "6") //header select all
                {
                    fHandled = true;

                    try
                    {
                        DataGridViewCheckBoxCell chkchecking = gv.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;

                        if (Convert.ToBoolean(chkchecking.EditedFormattedValue) == false)
                        {
                            gv.Rows[e.RowIndex].Selected = true;
                            chkchecking.Value = true;
                            gv.Rows[e.RowIndex].DefaultCellStyle.BackColor = gv.DefaultCellStyle.SelectionBackColor;

                        }
                        else
                        {
                            gv.Rows[e.RowIndex].Selected = false;
                            chkchecking.Value = false;
                            if (e.RowIndex % 2 == 0)
                            {
                                gv.Rows[e.RowIndex].DefaultCellStyle.BackColor = gv.DefaultCellStyle.BackColor;
                            }
                            else
                            {
                                gv.Rows[e.RowIndex].DefaultCellStyle.BackColor = gv.AlternatingRowsDefaultCellStyle.BackColor;
                            }
                        }


                    }
                    catch (Exception ex)
                    {

                    }

                }


            }
            catch (Exception ex)
            {
                //Debug.Print(ex.Message.ToString());
            }

            #endregion

            #region "Path"

            try
            {

               
                if (gv.Columns[e.ColumnIndex].Tag.ToString() == "8")
                {

                    fHandled = true;
                    string strPath = gv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                    //if(File.Exists(@strPath))
                    //{
                        Process.Start(@strPath);
                    //}
                    //{
                    //    MessageBox.Show(strPath + " does not exists.", "Path not Found");
                    //}
                }

            }
            catch(Exception ex)
            {

            }

            #endregion

            #region "Select"

            try
            {

                if (gv.Columns[e.ColumnIndex].Tag.ToString() == "16") //select
                {
                    fHandled = true;

                    try
                    {
                        DataGridViewCell col = gv.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCell;

                        if (gv[e.ColumnIndex, e.RowIndex].Value.ToString() == "Select")
                        {
                            gv[e.ColumnIndex, e.RowIndex].Value = "Un Select";
                            gv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;

                        }
                        else
                        {
                            gv[e.ColumnIndex, e.RowIndex].Value = "Select";
                            if (e.RowIndex % 2 == 0)
                            {
                                gv.Rows[e.RowIndex].DefaultCellStyle.BackColor = gv.DefaultCellStyle.BackColor;
                            }
                            else
                            {
                                gv.Rows[e.RowIndex].DefaultCellStyle.BackColor = gv.AlternatingRowsDefaultCellStyle.BackColor;
                            }
                            
                        }

                       
                    }
                    catch (Exception ex)
                    {
                        gv[e.ColumnIndex, e.RowIndex].Value = "Un Select";
                        gv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;

                    }

                }


            }
            catch (Exception ex)
            {
                //Debug.Print(ex.Message.ToString());
            }

            #endregion
            
        

            return fHandled;

        }

        public static Color ContrastColor(Color color)
        {
            int d = 0;

            // Counting the perceptive luminance - human eye favors green color... 
            double a = 1 - (0.299 * color.R + 0.587 * color.G + 0.114 * color.B) / 255;

            if (a < 0.5)
                d = 0; // bright colors - black font
            else
                d = 255; // dark colors - white font

            return Color.FromArgb(d, d, d);


        }

        public static void ResetCells(DataGridView gv, List<DataGridViewCell> cells)
        {
            foreach (DataGridViewCell cell in cells)
            {
                if (cell.RowIndex % 2 == 0)
                {
                    cell.Style.BackColor = gv.DefaultCellStyle.BackColor;
                }
                else
                {
                    cell.Style.BackColor = gv.AlternatingRowsDefaultCellStyle.BackColor;
                }
            }

        }

        public static int GetPK(clsGridView gv)
        {
            try
            {
                Int32 intSel = gv.CurrentCell.RowIndex;
                Int32 intCol = gv.PK;
                string strPK = gv.Rows[intSel].Cells[intCol].Value.ToString();
                Int32 intPK = Convert.ToInt32(strPK);

                return intPK;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select a row to the left.", "Credo");
                return 0;
            }


        }

        public static string GetCellValue(DataGridView gv, DataGridViewCellEventArgs e, string strCol)
        {
            Int32 intCol = 0;

            try
            {
                intCol = gv.Columns[strCol].Index;
                return gv.Rows[e.RowIndex].Cells[intCol].Value.ToString();
            }
            catch(Exception ex)
            {
                return "";
            }

        }
        
        public static void ShowNewEntry(DataGridView gv, Int32 intID)
        {
            if (intID > 0 && gv.Rows.Count > 0)
            {
                int index = gv.FirstDisplayedScrollingColumnIndex;

                if (gv.Controls.Count > 2) //first column is checkbox so go one more
                {
                    index = index + 1;
                }
                gv.CurrentCell = gv.Rows[0].Cells[index];
                gv.BeginEdit(true);
            }
        }
        
        public static void ShowFoundCells(DataGridView gv, List<DataGridViewCell> cells)
        {

            foreach (DataGridViewCell cell in cells)
            {
                cell.Style.BackColor = Color.PaleGoldenrod;
            }


        }

        public static void AddColumns(DataGridView gv, Int32 intNAVID, tblAppColumns tbl, HRLData.HRLEntities db, Int32 intApp, Int32 intAPPID, Int32 intASID)
        {



            if(tbl.APCOID == 2)
            {
                clsDropDownUtil.DropDown(gv, intNAVID, tbl, db, intApp, intAPPID, intASID, true);
            }

            else if (tbl.APCOID == 6)//check box header
            {
                clsGridUtil.AddCheckBoxColumn(gv, false,  tbl);

                CheckBox checkboxHeader = clsGridUtil.AddHeaderCheckBoxColumn(gv);
                checkboxHeader.CheckedChanged += new EventHandler(checkboxHeader_CheckedChanged);

                gv.Controls.Add(checkboxHeader);

            }
            else if (tbl.APCOID == 5)//check box
            {
                AddCheckBoxColumn(gv, true, tbl);
            }
            else if (tbl.APCOID == 7)//pk
            {
                clsGridView gv2 = (clsGridView)gv;
                AddPKColumn(gv2, tbl);
            }
            else if (tbl.APCOID == 9) //fore color
            {
                AddLinkColumn(gv, tbl);
            }
            else if (tbl.APCOID == 15)//back color
            {
                AddLinkColumn(gv, tbl);
            }
            else if (tbl.APCOID == 14)//active column
            {
                AddActiveColumn(gv, tbl);
            }
            else if (tbl.APCOID == 11)//filter
            {
                AddFilterColumn(gv,  tbl);
            }
            else if (tbl.APCOID == 3)//static link
            {
                AddLinkColumn(gv, tbl);
            }
            else if (tbl.APCOID == 4 )//data link
            {
                AddDataLinkColumn(gv, tbl);
            }
            else if (tbl.APCOID == 8)//path link
            {
                AddDataPathColumn(gv, tbl);
            }
            else if (tbl.APCOID == 10)//delete link
            {
                AddLinkColumn(gv, tbl);
            }
            else if (tbl.APCOID == 12)//add link
            {
                AddLinkColumn(gv, tbl);
            }
            else if (tbl.APCOID == 13)//view link
            {
                AddLinkColumn(gv, tbl);
            }
            else if (tbl.APCOID == 16)//select link
            {
                AddDataPathColumn(gv, tbl);
            }
            else if (tbl.APCOID == 17)//add Columns link
            {
                AddLinkColumn(gv, tbl);
            }
            else if (tbl.APCOID == 18)//release
            {
                AddLinkColumn(gv, tbl);
            }

            else if (tbl.APCOID == 19)//filter space holder
            {
                AddSpacerColumn(gv, tbl);
            }
            else if (tbl.APCOID == 20)//Date Filter Link
            {
                AddDataPathColumn(gv, tbl);
            }
            else if (tbl.APCOID == 21)
            {
                clsDropDownUtil.DropDown(gv, intNAVID, tbl, db, intApp, intAPPID, intASID, true);

            }
            else if (tbl.APCOID == 22)//Select Filter Link
            {
                AddDataPathColumn(gv, tbl);
            }
            else if (tbl.APCOID == 24)//Select Filter Link
            {
                AddLinkColumn(gv, tbl);
            }
            else if (tbl.APCOID == 25)//select filter int, string
            {
                clsDropDownUtil.DropDown(gv, intNAVID, tbl, db, intApp, intAPPID, intASID, true);

            }
            else if (tbl.APCOID == 26)//bit field....link
            {
                AddDataLinkColumn(gv, tbl);

            }
            else if (tbl.APCOID == 27)//static link
            {
                AddLinkColumn(gv, tbl);
            }
            else if (tbl.APCOID == 28)//select no arrow
            {
                clsDropDownUtil.DropDown(gv, intNAVID, tbl, db, intApp, intAPPID, intASID, false);

            }
            else if (tbl.APCOID == 31)//select no arrow, with zero default
            {
                clsDropDownUtil.DropDown(gv, intNAVID, tbl, db, intApp, intAPPID, intASID, false);

            }
            else if (tbl.APCOID == 32)
            {
                AddEditableLinkColumn(gv, tbl);
            }
            else if (tbl.APCOID == 33)//dynamic text link
            {
                AddDataPathColumn(gv, tbl);
            }
            else if (tbl.APCOID == 34)//file browser
            {
                AddDataPathColumn(gv, tbl);
            }
            else if (tbl.APCOID == 35)//back color hex
            {
                AddLinkColumn(gv, tbl);
            }
            else if (tbl.APCOID == 36)//rich text column
            {
                AddRichTextColumn(gv, tbl);
            }
            else if (tbl.APCOID == 37)//select no arrow, will be a type ahead on form
            {
                clsDropDownUtil.DropDown(gv, intNAVID, tbl, db, intApp, intAPPID, intASID, false);

            }
            else if (tbl.APCOID == 40)//bit field....link
            {
                AddDataColumn(gv, tbl);

            }
            else

            {
                AddDataColumn(gv, tbl);
            }

        }

        public static void AddCheckBoxColumn(DataGridView gv, Boolean fDataBound, tblAppColumns tbl)
        {
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            {
                string strName = tbl.APC_Desc;
                chk.Tag = tbl.APCOID.ToString();
                chk.Name = tbl.APC_Desc;
                chk.TrueValue = 1;
                chk.FalseValue = 0;
                //chk.TrueValue = true;
                //chk.FalseValue = false;
                chk.HeaderText = tbl.APC_Name;
                chk.Width = tbl.APC_Width;
                if (fDataBound == true)
                {
                    chk.DataPropertyName = strName;
                }
                chk.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                chk.FlatStyle = FlatStyle.Standard;
                chk.ThreeState = false;
                
                chk.CellTemplate = new DataGridViewCheckBoxCell();
                //chk.ReadOnly = true; //NOTE this assures that the click event has the same outcome whether or not the user chlicks the actual checkbox
                gv.Columns.Add(chk);



            }
        }

        public static CheckBox AddHeaderCheckBoxColumn(DataGridView gv)
        {
            // add checkbox header
            Rectangle rect = gv.GetCellDisplayRectangle(0, -1, true);
            // set checkbox header to center of header cell. +1 pixel to position correctly.
            rect.X = rect.Location.X + (rect.Width / 4) - 22;
            rect.Y = rect.Location.Y + 1;
            //rect.Y = rect.Location.Y + (rect.Height / 4) - 2;
            CheckBox checkboxHeader = new CheckBox();
            checkboxHeader.Tag = "6";
            checkboxHeader.Name = "checkboxHeader";
            checkboxHeader.Size = new Size(18, 18);
            checkboxHeader.Location = rect.Location;
            return checkboxHeader;
        }

        public static void AddActiveColumn(DataGridView gv, tblAppColumns tbl)
        {
            var items = new Dictionary<Int32, string>();

            DataGridViewComboBoxColumn gvCbo = new DataGridViewComboBoxColumn();

            items[0] = "In-Active";
            items[1] = "Active";

            gvCbo.Tag = tbl.APCOID.ToString();
            gvCbo.DataSource = new BindingSource(items, null);
            gvCbo.DisplayMember = "Value";
            gvCbo.ValueMember = "Key";
            gvCbo.FlatStyle = FlatStyle.Flat;
            gvCbo.Name = tbl.APC_Desc;
            gvCbo.HeaderText = tbl.APC_Name;
            gvCbo.Width = tbl.APC_Width;
            gvCbo.DataPropertyName = tbl.APC_Desc;
            gvCbo.AutoComplete = true;
            gv.Columns.Add(gvCbo);
        }

        public static void AddLinkColumn(DataGridView gv, tblAppColumns tbl)
        {
            DataGridViewLinkColumn button = new DataGridViewLinkColumn();
            button.Tag = tbl.APCOID.ToString();
            button.Name = tbl.APC_Desc;
            

            if(tbl.APC_Width == 0)
            {
                button.HeaderText = "";
                button.Visible = false;
            }
            else
            {
                button.Width = tbl.APC_Width;
                button.HeaderText = tbl.APC_Name;
                button.Visible = true;
            }


            var lstCol = new int[] { 16, 20 }; //select, Date Link

            if (lstCol.Contains(tbl.APCOID))
            {
                
                button.UseColumnTextForLinkValue = false;
            }
            else
            {
                button.Text = tbl.APC_Name;
                button.UseColumnTextForLinkValue = true;
            }

            if (tbl.APCOID == 10)
            {
                //button.LinkColor = Color.Navy;
                //button.ActiveLinkColor = Color.Navy;
                //button.VisitedLinkColor = Color.Navy;
                button.LinkColor = Color.Firebrick;
            }
            else if (tbl.APCOID == 12)
            {
                button.LinkColor = Color.DarkGreen;
            }
            else if (tbl.APCOID == 13)
            {
                button.LinkColor = Color.Navy;
            }
            else
            {
                button.LinkColor = Color.Navy;
                button.ActiveLinkColor = Color.Navy;
                button.VisitedLinkColor = Color.Navy;
            }

            gv.Columns.Add(button);
        }

        public static void AddDataLinkColumn(DataGridView gv, tblAppColumns tbl)
        {
            string strName = tbl.APC_Desc;
            DataGridViewLinkColumn button = new DataGridViewLinkColumn();
            button.Tag = tbl.APCOID.ToString();
            button.DataPropertyName = strName;
            button.Name = strName;
            button.Width = tbl.APC_Width;
            button.HeaderText = tbl.APC_Name;
            button.UseColumnTextForLinkValue = false;


            if (tbl.APCOID == 10)
            {
                button.LinkColor = Color.Firebrick;
            }
            if (tbl.APCOID == 12)
            {
                button.LinkColor = Color.DarkGreen;
            }
            if (tbl.APCOID == 13)
            {
                button.LinkColor = Color.Navy;
            }
            if (strName.ToString().Contains("Reason"))
            {
                button.LinkColor = Color.Navy;
            }

            if (tbl.APC_Desc == "QL_Desc")
            {
                button.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            //if (tbl.APCOID == 26)
            //{
            //    DataGridViewCellStyle cs1 = new DataGridViewCellStyle();
            //    cs1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            //    cs1.BackColor = gv.DefaultCellStyle.BackColor;
            //    cs1.Font = new System.Drawing.Font("Arial Narrow", 8.25F, FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //    button.DefaultCellStyle = cs1;
           
            //}
            gv.Columns.Add(button);
        }

        public static int AddGridRecord(int? intNAVID, int? intAPPID, int? intMisc, string strCurUser)
        {
            HRLEntities db = clsStart.efdb();
            Int32 intPK = 0;
            Int32 intPK2 = 0;
            string strErr = "";
            System.Data.Entity.Core.Objects.ObjectParameter err = new System.Data.Entity.Core.Objects.ObjectParameter("err", typeof(string));
            System.Data.Entity.Core.Objects.ObjectParameter pk1 = new System.Data.Entity.Core.Objects.ObjectParameter("pk1", typeof(int));
            System.Data.Entity.Core.Objects.ObjectParameter pk2 = new System.Data.Entity.Core.Objects.ObjectParameter("pk2", typeof(int));


            try
            {
                string strSQL = "p_AddDataRow " + intAPPID.ToString() + ", " + intNAVID.ToString() + ", '" + strCurUser + "', " + intMisc.ToString() + ",0,0,0";
                Debug.WriteLine(strSQL);
                db.p_AddDataRow(intAPPID, intNAVID, strCurUser, intMisc, err, pk1, pk2);
                intPK = Convert.ToInt32(pk1.Value.ToString());
                try
                {
                    intPK2 = Convert.ToInt32(pk2.Value.ToString());
                }
                catch(Exception ex)
                {

                }
                strErr = err.Value.ToString();

                if(intPK == 0)
                {
                    MessageBox.Show(strErr, "Credo");
                }
 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Credo");
            }

            return intPK;

        }

        public static void AddDataPathColumn(DataGridView gv, tblAppColumns tbl)
        {
            string strName = tbl.APC_Desc;

            DataGridViewCellStyle cs1 = new DataGridViewCellStyle();
            cs1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            cs1.BackColor = gv.DefaultCellStyle.BackColor;
            cs1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cs1.ForeColor = System.Drawing.Color.Blue;
            cs1.SelectionBackColor = System.Drawing.Color.Navy;
            cs1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            cs1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
           

            DataGridViewColumn button = new DataGridViewTextBoxColumn();
            button.Tag = tbl.APCOID.ToString();
            if(tbl.APCOID == 16)
            {
                button.CellTemplate.Value = "Select";                         
            }
            else
            {
                button.DataPropertyName = strName;
            }
            
            button.Name = strName;
            button.Width = tbl.APC_Width;
            button.HeaderText = tbl.APC_Name;
            button.DefaultCellStyle = cs1;
            gv.Columns.Add(button);
            
        }

        public static void AddEditableLinkColumn(DataGridView gv, tblAppColumns tbl)
        {
            string strName = tbl.APC_Desc;

            DataGridViewCellStyle cs1 = new DataGridViewCellStyle();
            cs1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            cs1.BackColor = gv.DefaultCellStyle.BackColor;
            cs1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cs1.ForeColor = System.Drawing.Color.Blue;
            cs1.SelectionBackColor = System.Drawing.Color.Navy;
            cs1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            cs1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;


            DataGridViewColumnCredo column = new DataGridViewColumnCredo();
            column.DataPropertyName = tbl.APC_Desc;
            column.DataPropertyFilterName = tbl.APC_QueryField;
            column.Name = tbl.APC_Desc;
            column.HeaderText = tbl.APC_Name;
            column.Tag = tbl.APCOID.ToString();
            
            column.DefaultCellStyle = cs1;

            if (tbl.APC_ReadOnly == true)
            {
                column.ReadOnly = true;
            }


            if (tbl.APC_Width == 0)
            {
                column.Visible = false;
            }
            else
            {
                column.Width = tbl.APC_Width;
            }


            gv.Columns.Add(column);



        }

        public static void AddSpacerColumn(DataGridView gv, tblAppColumns tbl)
        {
            DataGridViewColumnCredo column = new DataGridViewColumnCredo();
            column.DataPropertyName = tbl.APC_Desc;
            column.DataPropertyFilterName = tbl.APC_QueryField;
            column.Name = tbl.APC_Desc;
            column.HeaderText = tbl.APC_Name;
            column.Tag = tbl.APCOID.ToString();
            column.ReadOnly = true;
            column.Width = 20;
            if (gv.Name == "gv2")
            {
                gv.Columns.Add(column);
            }
        }

        public static void AddDataColumn(DataGridView gv, tblAppColumns tbl)
        {
            DataGridViewColumnCredo column = new DataGridViewColumnCredo();
            column.DataPropertyName = tbl.APC_Desc;
            
            column.DataPropertyFilterName = tbl.APC_QueryField;
            column.Name = tbl.APC_Desc;
            column.HeaderText = tbl.APC_Name;
            column.Tag = tbl.APCOID.ToString();

            if (tbl.APC_ReadOnly == true)
            {
                column.ReadOnly = true;
            }

            if (tbl.APC_Desc == "DA_Hot")
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            

            if (tbl.APCOID == 30)
            {
                column.DefaultCellStyle.Format = "MM/dd/yyyy";
                //column.DefaultCellStyle.NullValue = DateTime.Today.ToShortDateString(); //had the behaviour of always wanting to save rows with the default
            }

            if (tbl.APC_Width == 0)
            {
                column.Visible = false;
            }
            else
            {
                column.Width = tbl.APC_Width;
            }

            column.SortMode = DataGridViewColumnSortMode.Automatic;

            gv.Columns.Add(column);
        }

        public static void AddRichTextColumn(DataGridView gv, tblAppColumns tbl)
        {

            DataGridViewRichTextBoxColumn column = new DataGridViewRichTextBoxColumn();
            column.DataPropertyName = tbl.APC_Desc;
            column.Name = tbl.APC_Desc;
            column.HeaderText = tbl.APC_Name;
            column.Tag = tbl.APCOID.ToString();

            if (tbl.APC_ReadOnly == true)
            {
                column.ReadOnly = true;
            }

            if (tbl.APC_Width == 0)
            {
                column.Visible = false;
            }
            else
            {
                column.Width = tbl.APC_Width;
            }

            column.SortMode = DataGridViewColumnSortMode.Automatic;

            gv.Columns.Add(column);
        }
        public static void AddPKColumn(clsGridView gv, tblAppColumns tbl)
        {
            string strName = tbl.APC_Desc;

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = strName;
            column.Name = strName;
            column.HeaderText = tbl.APC_Name;
            column.Tag = tbl.APCOID.ToString();

            if (tbl.APC_ReadOnly == true)
            {
                column.ReadOnly = true;
            }

            if (tbl.APC_Width == 0)
            {
                column.Visible = false;
            }
            else
            {
                column.Width = tbl.APC_Width;
            }
            gv.Columns.Add(column);

            gv.PK = column.Index; //helps within the form to know this is the pk column

        }

        public static void AddFilterColumn(DataGridView gv, tblAppColumns tbl)
        {
            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "";
            column.Name = tbl.APC_Desc;
            column.HeaderText = tbl.APC_Name;
            column.ReadOnly = false;
            column.Tag = tbl.APCOID.ToString();

            if (tbl.APC_Width == 0)
            {
                column.Width = 0;
                column.Visible = false;
            }
            else
            {
                column.Width = tbl.APC_Width;
            }

            gv.Columns.Add(column);
        }

        private static void checkboxHeader_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;

            DataGridView gv = (DataGridView)chk.Parent;

            try
            {
                gv.CurrentCell = null;
            }
            catch
            {

            }


            Int32 intChk = gv.Columns["chkAllSel"].Index;

            foreach (DataGridViewRow row in gv.Rows)
            {
                (row.Cells[intChk] as DataGridViewCheckBoxCell).Value = chk.Checked;

                if (chk.Checked)
                {
                    row.Selected = true;
                    row.DefaultCellStyle.BackColor = gv.DefaultCellStyle.SelectionBackColor;
                }
                else
                {
                    row.Selected = false;
                    if (row.Index % 2 == 0)
                    {
                        //row.Selected = false;
                        row.DefaultCellStyle.BackColor = gv.DefaultCellStyle.BackColor;
                    }
                    else
                    {
                        //row.Selected = false;
                        row.DefaultCellStyle.BackColor = gv.AlternatingRowsDefaultCellStyle.BackColor;
                    }
                }

            }
        }

    }
}
