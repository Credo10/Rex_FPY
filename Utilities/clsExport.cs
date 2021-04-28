using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data.Linq;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Drawing.Printing;
using System.Diagnostics;
using System.Drawing;
using Microsoft.Win32;
using System.Management;
using System.Text.RegularExpressions;



namespace FPY
{
    public class clsExport
    {

        public static Boolean PrintLabel(string strPart, string strSerial, string strAssociate, string strBarCode)
        {
            Boolean fPrinted = false;

            try
            {
                //string strPath = System.Windows.Forms.Application.StartupPath.ToString();
                //strPath = strPath + @"\ASV_Label.label";


                //DYMO.Label.Framework.ILabel _dymoLabel;

                //_dymoLabel = Framework.Open(strPath);

                //_dymoLabel.SetObjectText("lblPart_1", "Part Num: " + strPart);
                //_dymoLabel.SetObjectText("Barcode", strBarCode);
                //_dymoLabel.SetObjectText("lblMadeBy", "Made with pride by:");
                //_dymoLabel.SetObjectText("lblAssociate", strAssociate);  // associate not showing as object error _dymoLabel.SetField("lblAssociate", this.Associate.AS_First.ToString() + ", " + Associate.AS_Last.ToString());
                //_dymoLabel.SetObjectText("lblSerial", "Serial: " + strSerial);
                //_dymoLabel.SetObjectText("lblDate", "Date: " + DateTime.Now.ToShortDateString());
                //_dymoLabel.SetObjectText("lblTime", "Time: " + DateTime.Now.ToShortTimeString());

                PrinterSettings settings = new PrinterSettings();
                foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {

                    if (printer == "DYMO LabelWriter 450")
                    {
                        //LabelWriterPrintParams prms = new LabelWriterPrintParams(1,"print job 1", DYMO.Label.Framework.FlowDirection.LeftToRight, RollSelection.Auto, LabelWriterPrintQuality.Text);  
                        //_dymoLabel.Print(printer.ToString(), prms);


                        fPrinted = true;
                    }
                }


                //_dymoLabel.Print(settings.PrinterName.ToString());

                fPrinted = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                fPrinted = false;
            }

            return fPrinted;

        }

        public static void ExportChartSimple(System.Data.DataSet ds, string strReport)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Workbook workbook;
                Worksheet worksheet;
                object missing;
                int pivotTablesCount = 0;
                Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
                string strXL = System.Windows.Forms.Application.StartupPath.ToString() + @"\Reports\" + strReport;
                string strFileName = CreateTempFile(strXL);

                //application = new Microsoft.Office.Interop.Excel.ApplicationClass();
                workbook = application.Workbooks.Open(strFileName, 0, false, 5, "", "", false, XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                application.Visible = true;
                Int32 intSheet = 4;

                foreach (System.Data.DataTable dt in ds.Tables)
                {
                    worksheet = (Worksheet)workbook.Worksheets[intSheet];
                    worksheet.Activate();
                    ExcelExportExisting(worksheet, dt, 0, 0);

                    intSheet = intSheet + 1;
                }



                intSheet = 1;
                foreach (var ws in workbook.Worksheets)
                {
                    worksheet = (Worksheet)workbook.Worksheets[intSheet];
                    worksheet.Activate();

                    missing = Type.Missing;
                    try
                    {
                        Microsoft.Office.Interop.Excel.PivotTables pivotTables = (Microsoft.Office.Interop.Excel.PivotTables)worksheet.PivotTables(missing);
                        pivotTablesCount = pivotTables.Count;
                        if (pivotTablesCount > 0)
                        {
                            for (int i = 1; i <= pivotTablesCount; i++)
                            {
                                pivotTables.Item(i).RefreshTable(); //The Item method throws an exception
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Cursor.Current = Cursors.Default;
                    }
                    intSheet = intSheet + 1;
                }

                worksheet = (Worksheet)workbook.Worksheets[1];
                worksheet.Activate();

                Cursor.Current = Cursors.Default;

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void ExportChartSimple(System.Data.DataTable dt, string strReport)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Workbook workbook;
                Worksheet worksheet;
                object missing;
                int pivotTablesCount = 0;
                Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
                string strXL = System.Windows.Forms.Application.StartupPath.ToString() + @"\Reports\" + strReport;
                string strFileName = CreateTempFile(strXL);

                //application = new Microsoft.Office.Interop.Excel.ApplicationClass();
                workbook = application.Workbooks.Open(strFileName, 0, false, 5, "", "", false, XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                application.Visible = true;
                worksheet = (Worksheet)workbook.Worksheets.get_Item("ChartData");
                worksheet.Activate();
                ExcelExportExistingNoHeader(0, worksheet, dt, 0, 0, true, true);
                worksheet = (Worksheet)workbook.Worksheets.get_Item("Chart");
                worksheet.Activate();

                string Defprinter = null;
                Defprinter = application.ActivePrinter;
                Debug.Print(Defprinter);

                application.ActivePrinter = "ad1p232 on AD1BE93E8 01 (DIRECT) on Ne07:";

                worksheet.PrintOutEx();
                //Debug.Print(worksheet.PrintOutEx(PrinterSettings.InstalledPrinters.ToString());


                missing = Type.Missing;
                try
                {
                    Microsoft.Office.Interop.Excel.PivotTables pivotTables = (Microsoft.Office.Interop.Excel.PivotTables)worksheet.PivotTables(missing);
                    pivotTablesCount = pivotTables.Count;
                    if (pivotTablesCount > 0)
                    {
                        for (int i = 1; i <= pivotTablesCount; i++)
                        {
                            pivotTables.Item(i).RefreshTable(); //The Item method throws an exception
                        }
                    }
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                }

                Cursor.Current = Cursors.Default;

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static string CreateTempFile(string strXL)
        {

            string strDate = DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + "_" + DateTime.Now.Second.ToString();

            string fileName = Path.GetTempPath() + @"\" + strDate + ".xls";

            if (File.Exists(strXL))
            {
                try
                {
                    File.Copy(strXL, fileName);
                    if (File.Exists(fileName))
                    {
                        return fileName;
                    }
                    else
                    {
                        MessageBox.Show("Cannot create " + fileName.ToString(), "Credo");
                        return "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Credo");
                    return "";
                }
            }
            else
            {
                MessageBox.Show("Cannot find " + Path.GetFileName(strXL), "Credo");
                return "";
            }
        }

        public static void ExcelExportExisting(Worksheet ws, System.Data.DataTable dt, Int32 RowOffSet, Int32 ColOffSet)
        {
            // Headers.  
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ws.Cells[1 + RowOffSet, i + 1 + ColOffSet] = dt.Columns[i].ColumnName;
            }

            //// Content.  
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    for (int j = 0; j < dt.Columns.Count; j++)
            //    {
            //        ws.Cells[i + 2 + RowOffSet, j + 1 + ColOffSet] = dt.Rows[i][j].ToString();
            //    }
            //}

            Int32 rows = dt.Rows.Count;
            Int32 columns = dt.Columns.Count;// - ColExclude;

            var data = new object[rows, columns];
            for (var row = 0; row <= rows - 1; row++)
            {
                for (var column = 0; column <= columns - 1; column++)
                {
                    data[row, column] = dt.Rows[row][column].ToString();
                }
            }

            rows = rows + RowOffSet;
            columns = columns + ColOffSet;

            var startCell = (Range)ws.Cells[2 + RowOffSet, 1 + ColOffSet];
            var endCell = (Range)ws.Cells[rows + 1, columns];
            var writeRange = ws.Range[startCell, endCell];
            writeRange.Value2 = data;




            try
            {
                ws.Columns.AutoFit();
            }
            catch (Exception exc)
            {


            }


            try
            {

                ws.UsedRange.AutoFilter(1, Type.Missing, XlAutoFilterOperator.xlAnd, Type.Missing, true);
            }
            catch (Exception exc)
            {

            }

        }

        public static void ExcelExportExistingNoHeader(int intRPID, Worksheet ws, System.Data.DataTable dt, Int32 RowOffSet, Int32 ColOffSet, Boolean fAutoFit, Boolean fFilter)
        {


            Int32 rows = dt.Rows.Count;
            Int32 columns = dt.Columns.Count;// - ColExclude;

            var data = new object[rows, columns];
            for (var row = 0; row <= rows - 1; row++)
            {
                for (var column = 0; column <= columns - 1; column++)
                {
                    data[row, column] = dt.Rows[row][column].ToString();
                }
            }

            rows = rows + RowOffSet;
            columns = columns + ColOffSet;

            var startCell = (Range)ws.Cells[2 + RowOffSet, 1 + ColOffSet];
            var endCell = (Range)ws.Cells[rows + 1, columns];
            var writeRange = ws.Range[startCell, endCell];
            writeRange.Value2 = data;

            if (fAutoFit)
            {
                try
                {
                    writeRange.AutoFit();
                }
                catch (Exception exc)
                {


                }
            }


            if (fFilter)
            {
                try
                {

                    writeRange.AutoFilter(1, Type.Missing, XlAutoFilterOperator.xlAnd, Type.Missing, true);
                }
                catch (Exception exc)
                {

                }
            }



        }

        public static System.Data.DataTable GridViewToDataTable(DataGridView gv)
        {
            var dataTable = new System.Data.DataTable();

            Array.ForEach(
                gv.Columns.Cast<DataGridViewColumn>().ToArray(),
                arg => dataTable.Columns.Add(arg.HeaderText));
            Array.ForEach(
                gv.Rows.Cast<DataGridViewRow>().ToArray(),
                arg => dataTable.Rows.Add(arg.Cells.Cast<DataGridViewCell>().Select(cell => cell.Value)));

            return dataTable;

        }

        static string strVal(object strVar)
        {
            if (strVar == DBNull.Value)
            {
                return "-";
            }
            else
            {
                return strVar.ToString();
            }

        }


        public static void ExcelExport(System.Data.DataTable data, bool openAfter, bool filter)
        {

            string strXL = "";
            string strFileName = "";
            strXL = System.Windows.Forms.Application.StartupPath.ToString() + @"\Reports\Report.xlsx";

            try
            {

                strFileName = CreateTempFile(strXL);

                if (strFileName == "")
                {
                    MessageBox.Show("Cannot Create XL Temp File.", "DA");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot Determine XL template.", "DA");
            }



            try
            {
                Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
                Workbook workbook;
                Worksheet worksheet;
                Range range;

                //application = new ApplicationClass();
                workbook = application.Workbooks.Open(strFileName, 0, false, 5, "", "", false, XlPlatform.xlWindows, "", true, false, 0, true, false, false);

                worksheet = (Worksheet)workbook.Worksheets.get_Item("Sheet1");


                clsExport.ExcelExportExisting(worksheet, data, 0, 0);

                application.ActiveWindow.Activate();
                application.Interactive = true;
                workbook.Application.Visible = true;


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "DA");

            }
        }

       
        public static void ExportChartSimple(System.Data.DataTable dt, string strReport, string strPrinter, string intIUID)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Microsoft.Office.Interop.Excel.Workbook workbook;
                Microsoft.Office.Interop.Excel.Worksheet worksheet;
                Range range;
                object oMissing = System.Reflection.Missing.Value;
                object missing;
                string strPort;
                int pivotTablesCount = 0;
                Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
                //MessageBox.Show(System.Windows.Forms.Application.StartupPath.ToString() + @"\Reports\" + strReport);
                string strXL = System.Windows.Forms.Application.StartupPath.ToString() + @"\Reports\" + strReport;
                string strFileName = CreateTempFile(strXL);

                workbook = application.Workbooks.Open(strFileName, 0, false, 5, "", "", false, XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                if (Debugger.IsAttached == false)
                {
                    application.Visible = false;
                }
                else
                {
                    application.Visible = true;
                }

                worksheet = (Worksheet)workbook.Worksheets.get_Item("SheetData");
                worksheet.Activate();
                ExcelExportExisting(worksheet, dt, 0, 0);
                worksheet = (Worksheet)workbook.Worksheets.get_Item("Request");
                worksheet.Activate();

                // Setup our sheet
                var _with1 = worksheet.PageSetup;
                // A4 papersize
                _with1.PaperSize = XlPaperSize.xlPaperA4;
                // Landscape orientation
                _with1.Orientation = XlPageOrientation.xlLandscape;
                // Fit Sheet on One Page 
                _with1.FitToPagesWide = 1;
                _with1.FitToPagesTall = 1;
                // Normal Margins
                _with1.LeftMargin = application.InchesToPoints(0.7);
                _with1.RightMargin = application.InchesToPoints(0.7);
                _with1.TopMargin = application.InchesToPoints(0.75);
                _with1.BottomMargin = application.InchesToPoints(0.75);
                _with1.HeaderMargin = application.InchesToPoints(0.3);
                _with1.FooterMargin = application.InchesToPoints(0.3);
                

                //Set Excel Cell for Barcode and Paste in
                object barcodeCell = "E24";
                Microsoft.Office.Interop.Excel.Range range3 = worksheet.get_Range(barcodeCell, barcodeCell);

                Microsoft.Office.Interop.Excel.Range range2 = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[20, 5];
                range3.Select();
                worksheet.Paste(oMissing, oMissing);

                //set up printer settings   
                if (strPrinter != "" + "")
                {
                    //ad1p232 on AD1BE93E8 01 (DIRECT)
                    String key = @"Software\Microsoft\Windows NT\CurrentVersion\Devices";

                    // read current user settings for header and footer

                    // Anderson Printer
                    //String _footer = Registry.CurrentUser.OpenSubKey(key).
                    //GetValue("ad1p232 on AD1BE93E8 01 (DIRECT)").ToString();

                    // FtInn Printer
                    try
                    {
                        String _footer = Registry.CurrentUser.OpenSubKey(key).
                                  GetValue(strPrinter).ToString();

                        string strNEPort = _footer.Substring(_footer.Length - 5);
                        strPrinter = strPrinter + " on " + strNEPort;

                        application.ActivePrinter = strPrinter;
                        //application.ActivePrinter = "FNIP3095 on rb-oms01 (DIRECT) on " + strNEPort;
                        //application.ActivePrinter = "ad1p232 on AD1BE93E8 01 (DIRECT) on " + strNEPort;

                        string Defprinter = null;
                        Defprinter = application.ActivePrinter;
                        Debug.Print(Defprinter);
                    }
                    catch (Exception ex)
                    {


                    }




                    try
                    {
                        if (Debugger.IsAttached == false)
                        {
                            worksheet.PrintOutEx();
                        }
                        workbook.Close(false, Missing.Value, Missing.Value);
                        application.Quit();

                    }
                    catch (Exception ex)
                    {

                    }

                }




                missing = Type.Missing;
                try
                {
                    Microsoft.Office.Interop.Excel.PivotTables pivotTables = (Microsoft.Office.Interop.Excel.PivotTables)worksheet.PivotTables(missing);
                    pivotTablesCount = pivotTables.Count;
                    if (pivotTablesCount > 0)
                    {
                        for (int i = 1; i <= pivotTablesCount; i++)
                        {
                            pivotTables.Item(i).RefreshTable(); //The Item method throws an exception
                        }
                    }
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                }

                Cursor.Current = Cursors.Default;

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void ExcelExport(System.Data.DataTable data, String fileName, bool openAfter, bool filter)
        {

            try
            {
                //export a DataTable to Excel
                DialogResult retry = DialogResult.Retry;

                if (fileName == "")
                {
                    int num = new Random().Next(0, 0x2710);
                    fileName = Path.GetTempPath() + @"\" + num.ToString() + ".xml";
                }

                while (retry == DialogResult.Retry)
                {
                    try
                    {
                        using (ExcelWriter writer = new ExcelWriter(fileName))
                        {
                            writer.WriteStartDocument();

                            // Write the worksheet contents
                            writer.WriteStartWorksheet("Sheet1");

                            //Write header row
                            writer.WriteStartRow();
                            foreach (DataColumn col in data.Columns)
                                writer.WriteExcelUnstyledCell(col.Caption);
                            writer.WriteEndRow();

                            //write data
                            foreach (DataRow row in data.Rows)
                            {
                                writer.WriteStartRow();
                                foreach (object o in row.ItemArray)
                                {
                                    if (Convert.IsDBNull(o))
                                    {
                                        writer.WriteExcelAutoStyledCell("");

                                    }
                                    else
                                    {
                                        writer.WriteExcelAutoStyledCell(o);
                                    }
                                }
                                writer.WriteEndRow();
                            }

                            // Close up the document
                            writer.WriteEndWorksheet();
                            writer.WriteEndDocument();
                            writer.Close();

                            if (openAfter)
                            {
                                if (!(filter))
                                {
                                    System.Diagnostics.Process.Start(fileName);
                                }
                                else
                                {
                                    Microsoft.Office.Interop.Excel.Application xl = new Microsoft.Office.Interop.Excel.Application();

                                    Workbooks workbooks = xl.Workbooks; // <-- the important part

                                    Workbook workBook = workbooks.Open(fileName,
                                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                    Type.Missing, Type.Missing);
                                    xl.Visible = true;

                                    Worksheet sheet = (Worksheet)workBook.Sheets[1];
                                    Range rng = sheet.UsedRange;

                                    try
                                    {
                                        sheet.Columns.AutoFit();
                                    }
                                    catch (Exception exc)
                                    {



                                    }


                                    try
                                    {

                                        sheet.UsedRange.AutoFilter(1, Type.Missing, XlAutoFilterOperator.xlAnd, Type.Missing, true);
                                    }
                                    catch (Exception exc)
                                    {

                                    }


                                    Marshal.ReleaseComObject(workBook);
                                    Marshal.ReleaseComObject(workbooks);
                                    Marshal.ReleaseComObject(xl);


                                }

                            }


                            retry = DialogResult.Cancel;
                        }
                    }
                    catch (Exception myException)
                    {
                        retry = MessageBox.Show(myException.Message, "Credo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Asterisk);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Credo");
            }
        }

        public static void ExcelExportDataSet(System.Data.DataSet ds, String fileName, bool openAfter, bool filter)
        {
            //export a DataTable to Excel
            DialogResult retry = DialogResult.Retry;

            if (fileName == "")
            {
                int num = new Random().Next(0, 0x2710);
                fileName = Path.GetTempPath() + @"\" + num.ToString() + ".xml";
            }

            Int32 intSheet = 0;

            while (retry == DialogResult.Retry)
            {
                try
                {
                    using (ExcelWriter writer = new ExcelWriter(fileName))
                    {
                        writer.WriteStartDocument();

                        foreach (System.Data.DataTable data in ds.Tables)
                        {


                            intSheet = intSheet + 1;
                            // Write the worksheet contents
                            writer.WriteStartWorksheet(data.TableName.ToString());

                            //Write header row
                            writer.WriteStartRow();
                            foreach (DataColumn col in data.Columns)
                                writer.WriteExcelUnstyledCell(col.Caption);
                            writer.WriteEndRow();

                            //write data
                            foreach (DataRow row in data.Rows)
                            {
                                writer.WriteStartRow();
                                foreach (object o in row.ItemArray)
                                {
                                    if (Convert.IsDBNull(o))
                                    {
                                        writer.WriteExcelAutoStyledCell("");

                                    }
                                    else
                                    {
                                        writer.WriteExcelAutoStyledCell(o);
                                    }
                                }
                                writer.WriteEndRow();
                            }

                            // Close up the document
                            writer.WriteEndWorksheet();
                        }
                        writer.WriteEndDocument();
                        writer.Close();

                        if (openAfter)
                        {
                            if (!(filter))
                            {
                                System.Diagnostics.Process.Start(fileName);
                            }
                            else
                            {
                                Microsoft.Office.Interop.Excel.Application xl = new Microsoft.Office.Interop.Excel.Application();

                                Workbooks workbooks = xl.Workbooks; // <-- the important part

                                Workbook workBook = workbooks.Open(fileName,
                                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                Type.Missing, Type.Missing);

                                xl.Visible = true;

                                foreach (Worksheet sheet in workBook.Sheets)
                                {


                                    Range rng = sheet.UsedRange;

                                    try
                                    {
                                        sheet.UsedRange.EntireColumn.AutoFit();
                                    }
                                    catch (Exception exc)
                                    {

                                    }

                                    try
                                    {

                                        sheet.UsedRange.AutoFilter(1, Type.Missing, XlAutoFilterOperator.xlAnd, Type.Missing, true);
                                    }
                                    catch (Exception exc)
                                    {

                                    }
                                }

                                Marshal.ReleaseComObject(workBook);
                                Marshal.ReleaseComObject(workbooks);
                                Marshal.ReleaseComObject(xl);


                            }

                        }



                        retry = DialogResult.Cancel;
                    }
                }
                catch (Exception myException)
                {
                    retry = MessageBox.Show(myException.Message, "Credo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Asterisk);
                }
            }
        }

        public static void ExportViaCopy(DataGridView gv, int intNAVID)
        {

            CopyGVToClipboard(gv);

            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;

            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Microsoft.Office.Interop.Excel.Application();
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            List<int> lstDel = new List<int>();

            // Headers
            try
            {
                Int32 i = 0;

                foreach (DataGridViewColumn col in gv.Columns)
                {

                    if (col.Visible)
                    {
                        xlWorkSheet.Cells[1, i + 1] = col.HeaderText;

                        if (col.Name.Contains("lnk") | (col.Name == "Open" | col.Name == "Delete"))
                        {
                            lstDel.Add(i);
                        }


                        i = i + 1;
                    }
                }



            }
            catch (Exception ex)
            {

            }


            Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[2, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

            try
            {
                foreach (var col in lstDel)
                {
                    string strCol = GetExcelColumnName(Convert.ToInt32(col) + 1) + "1";
                    Microsoft.Office.Interop.Excel.Range range = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.get_Range(strCol);
                    range.EntireColumn.Delete(Type.Missing);
                }
            }
            catch (Exception exc)
            {

            }

            try
            {
                xlWorkSheet.UsedRange.EntireColumn.AutoFit();
            }
            catch (Exception exc)
            {

            }

            Int32 intRow = 0;

            if (intNAVID != 269)
            {
                foreach (Range rrow in xlWorkSheet.UsedRange.Rows)
                {
                    if (rrow.Row != 1)
                    {
                        try
                        {
                            DataGridViewRow row = gv.Rows[intRow];
                            System.Drawing.Color fcolor = row.DefaultCellStyle.ForeColor;
                            System.Drawing.Color bcolor = row.DefaultCellStyle.BackColor;
                            if (bcolor.Name != "0")
                            {

                                rrow.Font.Color = System.Drawing.ColorTranslator.ToOle(fcolor);
                                rrow.Interior.Color = System.Drawing.ColorTranslator.ToOle(bcolor);
                            }

                            if (intNAVID == 241)
                            {
                                ExportViaCopyColColor(rrow, row);
                            }

                            intRow = intRow + 1;
                        }
                        catch (Exception)
                        {


                        }
                        
                    }


                }
            }
            try
            {

                xlWorkSheet.UsedRange.AutoFilter(1, Type.Missing, XlAutoFilterOperator.xlAnd, Type.Missing, true);
            }
            catch (Exception exc)
            {

            }



        }

        public static void ExportViaCopyModelCode(string strModel, DataGridView gv, DataGridView gv2)
        {

            CopyGVToClipboard(gv);

            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;

            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Microsoft.Office.Interop.Excel.Application();
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);


            List<int> lstDel = new List<int>();

            // Headers
            try
            {
                Int32 i = 1;

                foreach (DataGridViewColumn col in gv.Columns)
                {

                    if (col.Visible)
                    {
                        xlWorkSheet.Cells[1, i + 1] = col.HeaderText;

                        if (col.Name.Contains("lnk") | (col.Name == "Open" | col.Name == "Delete"))
                        {
                            lstDel.Add(i);
                        }


                        i = i + 1;
                    }
                }



            }
            catch (Exception ex)
            {

            }


            Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[2, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

            try
            {
                foreach (var col in lstDel)
                {
                    string strCol = GetExcelColumnName(Convert.ToInt32(col) + 1) + "1";
                    Microsoft.Office.Interop.Excel.Range range = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.get_Range(strCol);
                    range.EntireColumn.Delete(Type.Missing);
                }
            }
            catch (Exception exc)
            {

            }

            //try
            //{
            //    xlWorkSheet.UsedRange.EntireColumn.AutoFit();
            //}
            //catch (Exception exc)
            //{

            //}

            Int32 intRow = 0;

            try
            {
                foreach (Range rrow in xlWorkSheet.UsedRange.Rows)
                {
                    if (rrow.Row != 1)
                    {
                        try
                        {
                            DataGridViewRow row = gv.Rows[intRow];
                            System.Drawing.Color fcolor = row.DefaultCellStyle.ForeColor;
                            System.Drawing.Color bcolor = row.DefaultCellStyle.BackColor;
                            if (bcolor.Name != "0")
                            {

                                rrow.Font.Color = System.Drawing.ColorTranslator.ToOle(fcolor);
                                rrow.Interior.Color = System.Drawing.ColorTranslator.ToOle(bcolor);
                            }


                            try
                            {
                                ExportViaCopyColColor(rrow, row);
                            }
                            catch (Exception ex)
                            {

                               
                            }


                            intRow = intRow + 1;
                        }
                        catch (Exception)
                        {


                        }

                    }


                }
            }
            catch (Exception ex)
            {


            }

            //System.Data.DataTable dt = GridViewToDataTable(gv2);
            Clipboard.Clear();
            CopyGVToClipboard(gv2);

            // Headers
            try
            {
                Int32 i = 1;

                foreach (DataGridViewColumn col in gv2.Columns)
                {

                    if (col.Visible)
                    {
                        xlWorkSheet.Cells[5, i + 1] = col.HeaderText;
                        i = i + 1;
                    }
                }



            }
            catch (Exception ex)
            {

            }


            try
            {
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[6, 1];
                CR.Select();
                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);


                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                strModel = Regex.Replace(strModel, @"[^A-Za-z0-9]+", "");

                path = Path.Combine(path, strModel);

                xlexcel.DisplayAlerts = false;

                xlWorkBook.SaveAs(path, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, true, false, XlSaveAsAccessMode.xlNoChange, XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);

            }
            catch (Exception ex)
            {

                throw;
            }


        }
        public static void ExportViaCopyColColor(Range rng, DataGridViewRow row)
        {

            try
            {
               foreach(DataGridViewCell cell in row.Cells)
                {
                    System.Drawing.Color fcolor = cell.Style.ForeColor;
                    System.Drawing.Color bcolor = cell.Style.BackColor;
                    if (bcolor.Name != "0")
                    {

                        Microsoft.Office.Interop.Excel.Range r1 = (Microsoft.Office.Interop.Excel.Range)rng.Worksheet.Cells[rng.Row, cell.ColumnIndex];
                           
                        r1.Font.Color = System.Drawing.ColorTranslator.ToOle(fcolor);
                        r1.Interior.Color = System.Drawing.ColorTranslator.ToOle(bcolor);
                    }
                }
               
            }
            catch (Exception ex)
            {


            }
           


        }
        private static string GetExcelColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName;

        }

        public static void ExportViaCopyExisting(Worksheet ws, DataGridView gv, Int32 RowOffSet, Int32 ColOffSet)
        {

            CopyGVToClipboard(gv);

            List<int> lstDel = new List<int>();

            // Headers
            try
            {
                Int32 i = 0;

                foreach (DataGridViewColumn col in gv.Columns)
                {

                    if (col.Visible)
                    {
                        ws.Cells[1 + RowOffSet, i + 1 + ColOffSet] = col.HeaderText;

                        if (col.Name.Contains("lnk") | (col.Name == "Open" | col.Name == "Delete"))
                        {
                            lstDel.Add(i);
                        }


                        i = i + 1;
                    }
                }



            }
            catch (Exception ex)
            {

            }


            Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)ws.Cells[2 + RowOffSet, 1 + ColOffSet];
            CR.Select();
            ws.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

            for (int i = 1; i <= ws.UsedRange.Rows.Count; i++)
            {
                string strVal = ws.Cells[i + RowOffSet, 1 + ColOffSet].ToString();

                if (strVal + "" == "")
                {
                    ((Range)ws.Rows[i]).Delete();
                }
            }

            try
            {
                foreach (var col in lstDel)
                {
                    string strCol = GetExcelColumnName(Convert.ToInt32(col) + 1) + "1";
                    Microsoft.Office.Interop.Excel.Range range = (Microsoft.Office.Interop.Excel.Range)ws.get_Range(strCol, Missing.Value);
                    range.EntireColumn.Delete(Missing.Value);
                }
            }
            catch (Exception exc)
            {

            }

            try
            {
                ws.UsedRange.EntireColumn.AutoFit();
            }
            catch (Exception exc)
            {

            }

            try
            {

                ws.UsedRange.AutoFilter(1, Type.Missing, XlAutoFilterOperator.xlAnd, Type.Missing, true);
            }
            catch (Exception exc)
            {

            }



        }




        private static void CopyGVToClipboard(DataGridView gv)
        {


            //string dgvToHTMLTable = ConvertDataGridViewToHTMLWithFormatting(gv);
            //Clipboard.SetText(dgvToHTMLTable);

            gv.SelectAll();
            DataObject dataObj = gv.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
            gv.ClearSelection();
        }


        #region Export To HTML


        //====================================================
        //DataGridView Export To HTML by Jeremy Thompson: https://stackoverflow.com/questions/39210329/
        //====================================================
        public static string ConvertDataGridViewToHTMLWithFormatting(DataGridView dgv)
        {
            StringBuilder sb = new StringBuilder();
            //create html & table
            sb.AppendLine("<html><body><center><table border='1' cellpadding='0' cellspacing='0'>");
            sb.AppendLine("<tr>");
            //create table header
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                sb.Append(DGVHeaderCellToHTMLWithFormatting(dgv, i));
                sb.Append(DGVCellFontAndValueToHTML(dgv.Columns[i].HeaderText, dgv.Columns[i].HeaderCell.Style.Font));
                sb.AppendLine("</td>");
            }
            sb.AppendLine("</tr>");
            //create table body
            for (int rowIndex = 0; rowIndex < dgv.Rows.Count; rowIndex++)
            {
                sb.AppendLine("<tr>");
                foreach (DataGridViewCell dgvc in dgv.Rows[rowIndex].Cells)
                {
                    sb.AppendLine(DGVCellToHTMLWithFormatting(dgv, rowIndex, dgvc.ColumnIndex));
                    string cellValue = dgvc.Value == null ? string.Empty : dgvc.Value.ToString();
                    sb.AppendLine(DGVCellFontAndValueToHTML(cellValue, dgvc.Style.Font));
                    sb.AppendLine("</td>");
                }
                sb.AppendLine("</tr>");
            }
            //table footer & end of html file
            sb.AppendLine("</table></center></body></html>");
            return sb.ToString();
        }

        //TODO: Add more cell styles described here: https://msdn.microsoft.com/en-us/library/1yef90x0(v=vs.110).aspx
        private static string DGVHeaderCellToHTMLWithFormatting(DataGridView dgv, int col)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<td");
            sb.Append(DGVCellColorToHTML(dgv.Columns[col].HeaderCell.Style.ForeColor, dgv.Columns[col].HeaderCell.Style.BackColor));
            sb.Append(DGVCellAlignmentToHTML(dgv.Columns[col].HeaderCell.Style.Alignment));
            sb.Append(">");
            return sb.ToString();
        }

        private static string DGVCellToHTMLWithFormatting(DataGridView dgv, int row, int col)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<td");
            sb.Append(DGVCellColorToHTML(dgv.Rows[row].Cells[col].Style.ForeColor, dgv.Rows[row].Cells[col].Style.BackColor));
            sb.Append(DGVCellAlignmentToHTML(dgv.Rows[row].Cells[col].Style.Alignment));
            sb.Append(">");
            return sb.ToString();
        }

        private static string DGVCellColorToHTML(System.Drawing.Color foreColor, System.Drawing.Color backColor)
        {
            if (foreColor.Name == "0" && backColor.Name == "0") return string.Empty;

            StringBuilder sb = new StringBuilder();
            sb.Append(" style=\"");
            if (foreColor.Name != "0" && backColor.Name != "0")
            {
                sb.Append("color:#");
                sb.Append(foreColor.R.ToString("X2") + foreColor.G.ToString("X2") + foreColor.B.ToString("X2"));
                sb.Append("; background-color:#");
                sb.Append(backColor.R.ToString("X2") + backColor.G.ToString("X2") + backColor.B.ToString("X2"));
            }
            else if (foreColor.Name != "0" && backColor.Name == "0")
            {
                sb.Append("color:#");
                sb.Append(foreColor.R.ToString("X2") + foreColor.G.ToString("X2") + foreColor.B.ToString("X2"));
            }
            else //if (foreColor.Name == "0" &&  backColor.Name != "0")
            {
                sb.Append("background-color:#");
                sb.Append(backColor.R.ToString("X2") + backColor.G.ToString("X2") + backColor.B.ToString("X2"));
            }

            sb.Append(";\"");
            return sb.ToString();
        }

        public static string DGVCellFontAndValueToHTML(string value, System.Drawing.Font font)
        {
            return value;

            ////If no font has been set then assume its the default as someone would be expected in HTML or Excel
            //if (font == null || font == this.Font && !(font.Bold | font.Italic | font.Underline | font.Strikeout)) return value;
            //StringBuilder sb = new StringBuilder();
            //sb.Append(" ");
            //if (font.Bold) sb.Append("<b>");
            //if (font.Italic) sb.Append("<i>");
            //if (font.Strikeout) sb.Append("<strike>");

            ////The <u> element was deprecated in HTML 4.01. The new HTML 5 tag is: text-decoration: underline
            //if (font.Underline) sb.Append("<u>");

            //string size = string.Empty;
            //if (font.Size != this.Font.Size) size = "font-size: " + font.Size + "pt;";

            ////The <font> tag is not supported in HTML5. Use CSS or a span instead. 
            //if (font.FontFamily.Name != this.Font.Name)
            //{
            //    sb.Append("<span style=\"font-family: ");
            //    sb.Append(font.FontFamily.Name);
            //    sb.Append("; ");
            //    sb.Append(size);
            //    sb.Append("\">");
            //}
            //sb.Append(value);
            //if (font.FontFamily.Name != this.Font.Name) sb.Append("</span>");

            //if (font.Underline) sb.Append("</u>");
            //if (font.Strikeout) sb.Append("</strike>");
            //if (font.Italic) sb.Append("</i>");
            //if (font.Bold) sb.Append("</b>");

            //return sb.ToString();
        }

        public static string DGVCellAlignmentToHTML(DataGridViewContentAlignment align)
        {
            if (align == DataGridViewContentAlignment.NotSet) return string.Empty;

            string horizontalAlignment = string.Empty;
            string verticalAlignment = string.Empty;
            CellAlignment(align, ref horizontalAlignment, ref verticalAlignment);
            StringBuilder sb = new StringBuilder();
            sb.Append(" align='");
            sb.Append(horizontalAlignment);
            sb.Append("' valign='");
            sb.Append(verticalAlignment);
            sb.Append("'");
            return sb.ToString();
        }

        private static void CellAlignment(DataGridViewContentAlignment align, ref string horizontalAlignment, ref string verticalAlignment)
        {
            switch (align)
            {
                case DataGridViewContentAlignment.MiddleRight:
                    horizontalAlignment = "right";
                    verticalAlignment = "middle";
                    break;
                case DataGridViewContentAlignment.MiddleLeft:
                    horizontalAlignment = "left";
                    verticalAlignment = "middle";
                    break;
                case DataGridViewContentAlignment.MiddleCenter:
                    horizontalAlignment = "centre";
                    verticalAlignment = "middle";
                    break;
                case DataGridViewContentAlignment.TopCenter:
                    horizontalAlignment = "centre";
                    verticalAlignment = "top";
                    break;
                case DataGridViewContentAlignment.BottomCenter:
                    horizontalAlignment = "centre";
                    verticalAlignment = "bottom";
                    break;
                case DataGridViewContentAlignment.TopLeft:
                    horizontalAlignment = "left";
                    verticalAlignment = "top";
                    break;
                case DataGridViewContentAlignment.BottomLeft:
                    horizontalAlignment = "left";
                    verticalAlignment = "bottom";
                    break;
                case DataGridViewContentAlignment.TopRight:
                    horizontalAlignment = "right";
                    verticalAlignment = "top";
                    break;
                case DataGridViewContentAlignment.BottomRight:
                    horizontalAlignment = "right";
                    verticalAlignment = "bottom";
                    break;

                default: //DataGridViewContentAlignment.NotSet
                    horizontalAlignment = "left";
                    verticalAlignment = "middle";
                    break;
            }
        }

        #endregion





        public class ExcelWriter : IDisposable
        {
            private XmlWriter _writer;

            public enum CellStyle { General, Number, Currency, DateTime, ShortDate };

            public void WriteStartDocument()
            {
                if (_writer == null) throw new NotSupportedException("Cannot write after closing.");

                _writer.WriteProcessingInstruction("mso-application", "progid=\"Excel.Sheet\"");
                _writer.WriteStartElement("ss", "Workbook", "urn:schemas-microsoft-com:office:spreadsheet");
                WriteExcelStyles();
            }

            public void WriteEndDocument()
            {
                if (_writer == null) throw new NotSupportedException("Cannot write after closing.");

                _writer.WriteEndElement();
            }

            private void WriteExcelStyleElement(CellStyle style)
            {
                _writer.WriteStartElement("Style", "urn:schemas-microsoft-com:office:spreadsheet");
                _writer.WriteAttributeString("ID", "urn:schemas-microsoft-com:office:spreadsheet", style.ToString());
                _writer.WriteEndElement();
            }

            private void WriteExcelStyleElement(CellStyle style, string NumberFormat)
            {
                _writer.WriteStartElement("Style", "urn:schemas-microsoft-com:office:spreadsheet");

                _writer.WriteAttributeString("ID", "urn:schemas-microsoft-com:office:spreadsheet", style.ToString());
                _writer.WriteStartElement("NumberFormat", "urn:schemas-microsoft-com:office:spreadsheet");
                _writer.WriteAttributeString("Format", "urn:schemas-microsoft-com:office:spreadsheet", NumberFormat);
                _writer.WriteEndElement();

                _writer.WriteEndElement();

            }

            private void WriteExcelStyles()
            {
                _writer.WriteStartElement("Styles", "urn:schemas-microsoft-com:office:spreadsheet");

                WriteExcelStyleElement(CellStyle.General);
                WriteExcelStyleElement(CellStyle.Number, "General Number");
                WriteExcelStyleElement(CellStyle.DateTime, "General Date");
                WriteExcelStyleElement(CellStyle.Currency, "Currency");
                WriteExcelStyleElement(CellStyle.ShortDate, "Short Date");

                _writer.WriteEndElement();
            }

            public void WriteStartWorksheet(string name)
            {
                if (_writer == null) throw new NotSupportedException("Cannot write after closing.");

                _writer.WriteStartElement("Worksheet", "urn:schemas-microsoft-com:office:spreadsheet");
                _writer.WriteAttributeString("Name", "urn:schemas-microsoft-com:office:spreadsheet", name);
                _writer.WriteStartElement("Table", "urn:schemas-microsoft-com:office:spreadsheet");
            }

            public void WriteEndWorksheet()
            {
                if (_writer == null) throw new NotSupportedException("Cannot write after closing.");

                _writer.WriteEndElement();
                _writer.WriteEndElement();
            }

            public ExcelWriter(string outputFileName)
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                _writer = XmlWriter.Create(outputFileName, settings);
            }

            public void Close()
            {
                if (_writer == null) throw new NotSupportedException("Already closed.");

                _writer.Close();
                _writer = null;
            }

            public void WriteExcelColumnDefinition(int columnWidth)
            {
                if (_writer == null) throw new NotSupportedException("Cannot write after closing.");

                _writer.WriteStartElement("Column", "urn:schemas-microsoft-com:office:spreadsheet");
                _writer.WriteStartAttribute("Width", "urn:schemas-microsoft-com:office:spreadsheet");
                _writer.WriteValue(columnWidth);
                _writer.WriteEndAttribute();
                _writer.WriteEndElement();
            }

            public void WriteExcelUnstyledCell(string value)
            {
                if (_writer == null) throw new NotSupportedException("Cannot write after closing.");

                _writer.WriteStartElement("Cell", "urn:schemas-microsoft-com:office:spreadsheet");
                _writer.WriteStartElement("Data", "urn:schemas-microsoft-com:office:spreadsheet");
                _writer.WriteAttributeString("Type", "urn:schemas-microsoft-com:office:spreadsheet", "String");

                _writer.WriteValue(value);
                _writer.WriteEndElement();
                _writer.WriteEndElement();
            }

            public void WriteStartRow()
            {
                if (_writer == null) throw new NotSupportedException("Cannot write after closing.");

                _writer.WriteStartElement("Row", "urn:schemas-microsoft-com:office:spreadsheet");
            }

            public void WriteEndRow()
            {
                if (_writer == null) throw new NotSupportedException("Cannot write after closing.");

                _writer.WriteEndElement();
            }

            public void WriteExcelStyledCell(object value, CellStyle style)
            {
                if (_writer == null) throw new NotSupportedException("Cannot write after closing.");

                _writer.WriteStartElement("Cell", "urn:schemas-microsoft-com:office:spreadsheet");
                _writer.WriteAttributeString("StyleID", "urn:schemas-microsoft-com:office:spreadsheet", style.ToString());
                _writer.WriteStartElement("Data", "urn:schemas-microsoft-com:office:spreadsheet");
                switch (style)
                {
                    case CellStyle.General:
                        _writer.WriteAttributeString("Type", "urn:schemas-microsoft-com:office:spreadsheet", "String");
                        break;
                    case CellStyle.Number:
                    case CellStyle.Currency:
                        _writer.WriteAttributeString("Type", "urn:schemas-microsoft-com:office:spreadsheet", "Number");
                        break;
                    case CellStyle.ShortDate:
                    case CellStyle.DateTime:
                        _writer.WriteAttributeString("Type", "urn:schemas-microsoft-com:office:spreadsheet", "DateTime");
                        break;
                }
                _writer.WriteValue(value);
                //  tag += String.Format("{1}\"><ss:Data ss:Type=\"DateTime\">{0:yyyy\\-MM\\-dd\\THH\\:mm\\:ss\\.fff}</ss:Data>", value,

                _writer.WriteEndElement();
                _writer.WriteEndElement();
            }

            public void WriteExcelAutoStyledCell(object value)
            {
                if (_writer == null) throw new NotSupportedException("Cannot write after closing.");

                //write the <ss:Cell> and <ss:Data> tags for something
                if (value is Int16 || value is Int32 || value is Int64 || value is SByte ||
                    value is UInt16 || value is UInt32 || value is UInt64 || value is Byte)
                {
                    WriteExcelStyledCell(value, CellStyle.Number);
                }
                else if (value is Single || value is Double || value is Decimal) //we'll assume it's a currency
                {
                    WriteExcelStyledCell(value, CellStyle.Number);
                }
                else if (value is DateTime)
                {
                    //check if there's no time information and use the appropriate style
                    WriteExcelStyledCell(value, ((DateTime)value).TimeOfDay.CompareTo(new TimeSpan(0, 0, 0, 0, 0)) == 0 ? CellStyle.ShortDate : CellStyle.DateTime);
                }
                else
                {
                    WriteExcelStyledCell(value, CellStyle.General);
                }
            }

            #region IDisposable Members

            public void Dispose()
            {
                if (_writer == null)
                    return;

                _writer.Close();
                _writer = null;
            }

            #endregion
        }


    }

}
