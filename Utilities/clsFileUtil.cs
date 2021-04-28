using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Linq;
using LinqToExcel;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;
using ECRData;
using System.Drawing;
using System.Drawing.Imaging;


namespace RexVOIS3
{
    class clsFileUtil
    {

        public static string OpenFile(byte[] img, string strExt)
        {

            try
            {
               

                int num = new Random().Next(0, 0x2710);
                string strFileName = Path.GetTempPath() + @"\" + num.ToString() + "." + strExt;

                //Write file data to selected file.
                using (FileStream fs = new FileStream(strFileName, FileMode.Create))
                {
                    fs.Write(img, 0, img.Length);
                    fs.Close();
                }



                Process training = new Process();
                training.StartInfo.FileName = strFileName;
                training.Start();

               

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }

            return "OK";
        }

        public static byte[] ReadFileToByte(string sPath)
        {
            FileStream fs;
            fs = new FileStream(sPath, FileMode.Open, FileAccess.Read);
            byte[] picbyte = new byte[fs.Length];
            fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();
            return picbyte;
        }

     

        public static int ReadXLAndSplit(string strPath)
        {



            try
            {
                ECREntities db = clsStart.efdbECR();

                    tblFile fl = new tblFile();
                    fl.FL_Desc = strPath;
                    fl.FL_DateCreated = DateTime.Now;
                    fl.FL_Date = DateTime.Now;
                    fl.FTID = 0;

                    db.tblFile.Add(fl);
                    db.SaveChanges();

                    if (fl.FLID > 0)
                    {

                        DataTable dt = new DataTable();
                        string strField = "";

                        dt.Columns.Add("FLID");

                        Int32 i = 0;

                        for (i = 1; i <= 113; i++)
                        {
                            strField = "F" + i.ToString();
                            dt.Columns.Add(strField);
                        }


                        Int32 intRow = 0;

                        try
                        {

                            var excelFile = new ExcelQueryFactory(strPath);
                            var worksheetNames = excelFile.GetWorksheetNames();

                            string strSheet = worksheetNames.First();

                            var qry = from a in excelFile.Worksheet(strSheet) select a;

                            foreach (var row in qry)
                            {
                                dt.Rows.Add(fl.FLID);

                                i = 1;
                                foreach (string cell in row)
                                {
                                    strField = "F" + i.ToString();
                                    string strVal = cell.ToString();

                                    if (i < 114)
                                    {
                                        if (strVal.Length > 48)
                                        {
                                            strVal = strVal.Substring(0, 48);
                                        }
                                        try
                                        {
                                            dt.Rows[intRow][strField] = strVal;
                                        }
                                        catch (Exception ex)
                                        {
                                            Debug.WriteLine(ex.Message);
                                        }
                                    }
                                    i = i + 1;

                                }

                                intRow = intRow + 1;
                            }


                            InsertLinesFields(dt, fl);

                            return fl.FLID;


                        }
                        catch (Exception ex)
                        {
                            return 0;
                            //LogProgress(q, ex.ToString());

                        }


                    }
                    else
                    {
                        return 0;
                    }




            }
            catch (Exception ex)
            {
                return 0;
                //LogProgress(
                //LogProgress(q, ex.ToString());
                //return false;
            }

            return 0;
            //return true;
        }

        private static void InsertLinesFields(DataTable dt, tblFile fl)
        {

            try
            {
                //clsDAL.ExecuteSQL("truncate table tblFileDetailField", "BPS");

                string sqlConnectionString = "";


                sqlConnectionString = clsDAL.GetCon("ECR");



                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(sqlConnectionString))
                {
                    bulkCopy.DestinationTableName = "tblFileDetailField";

                    bulkCopy.BulkCopyTimeout = 180;

                    foreach (DataColumn dc in dt.Columns)
                    {

                        bulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(dc.ColumnName, dc.ColumnName));
                    }


                    bulkCopy.WriteToServer(dt);
                }

            }
            catch (Exception ex)
            {

                //LogProgress(q, ex.ToString());
            }


        }

    }
}
