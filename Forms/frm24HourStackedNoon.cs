using SpannedDataGridViewNet2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FPY
{
    public partial class frm24HourStackedNoon : clsForm
    {

        List<Tuple<int, int, int, int>> trueCycleTimes = new List<Tuple<int, int, int, int>>();
        public string strLineSpecificStoredProc = "";
        public string strLineSpecificPctStoredProc = "";
        DateTime reportDate = DateTime.Now;

        public frm24HourStackedNoon()
        {
            InitializeComponent();

            //this.Width = Screen.PrimaryScreen.WorkingArea.Width / 2;
            //this.Height = Screen.PrimaryScreen.WorkingArea.Height / 2;
            //this.Top = (Screen.PrimaryScreen.WorkingArea.Top + Screen.PrimaryScreen.WorkingArea.Height) / 4;
            //this.Left = (Screen.PrimaryScreen.WorkingArea.Left + Screen.PrimaryScreen.WorkingArea.Width) / 4;
        }

        private void frm24HourStackedNoon_Load(object sender, EventArgs e)
        {
            this.LNID = 1;
            this.gvWholeTimeline1.DoubleBuffered(true);
            this.gvHours1.DoubleBuffered(true);
            this.gvTimeLine1.DoubleBuffered(true);
            this.gvWorkOrder1.DoubleBuffered(true);
            this.gvTrueCycle1.DoubleBuffered(true);

            this.gvWholeTimeline2.DoubleBuffered(true);
            this.gvHours2.DoubleBuffered(true);
            this.gvTimeLine2.DoubleBuffered(true);
            this.gvWorkOrder2.DoubleBuffered(true);
            this.gvTrueCycle2.DoubleBuffered(true);

            this.gvWholeTimeline3.DoubleBuffered(true);
            this.gvHours3.DoubleBuffered(true);
            this.gvTimeLine3.DoubleBuffered(true);
            this.gvWorkOrder3.DoubleBuffered(true);
            this.gvTrueCycle3.DoubleBuffered(true);

            this.gvWholeTimeline4.DoubleBuffered(true);
            this.gvHours4.DoubleBuffered(true);
            this.gvTimeLine4.DoubleBuffered(true);
            this.gvWorkOrder4.DoubleBuffered(true);
            this.gvTrueCycle4.DoubleBuffered(true);
        }

        private void frm24HourStackedNoon_Shown(object sender, EventArgs e)
        {
           FormCollection fc = Application.OpenForms;
           Form frmClose = new Form();
           Form frmClose2 = new Form();

            foreach (Form frm in fc)
            {
                //iterate through
                if (frm.Name == "frmFPYThreeHourB" )
                {
                    frmClose = frm;
                }

                if(frm.Name == "frmFPYThreeHourTest")
                {
                    frmClose2 = frm;
                }
                
            }

            if(frmClose.Name + " " != " ")
            {
                frmClose.Close();
            }

            if (frmClose2.Name + " " != " ")
            {
                frmClose2.Close();
            }

           

            if (this.LNID == 1)
            {
                //reportDate = DateTime.Now;
                this.lblLine.Text = "PKU 1";
                strLineSpecificStoredProc = "p_tblLeakTestFPYPKU1_Noon '" + reportDate.ToShortDateString() + "'";
                strLineSpecificPctStoredProc = "p_tblLeakTestFPY24PctsPKU1 ";
            }

            if (this.LNID == 2)
            {
                this.lblLine.Text = "PKU 2";
                strLineSpecificStoredProc = "p_tblLeakTestFPYPKU2_Noon '" + reportDate.ToShortDateString() + "'";
                strLineSpecificPctStoredProc = "p_tblLeakTestFPY24PctsPKU2";

            }

            var dtNow = DateTime.Now;
            var xxx = dtNow.Hour;
            string strdt = dtNow.ToString("yyyy/MM/dd, HH:mm:ss");

            string strHour = (Convert.ToInt32(xxx.ToString()) - 4).ToString(); //edit

            //SetGrids(strHour);
            SetGrids("0");
            //SetPcts();
            //timer1.Start();
            //timer2.Start();
            this.Cursor = Cursors.Default;
        }
        private void SetSpan(DataGridView gv, int intCol, int intRow, int intColSpan, int intRowSpan, string strAlign)
        {
            try
            {
                var cell = (DataGridViewTextBoxCellEx)gv[intCol, intRow];
                if (intColSpan > 0)
                {
                    cell.ColumnSpan = intColSpan;
                }
                if (intRowSpan > 0)
                {
                    cell.RowSpan = intRowSpan;
                }
                if (strAlign == "Left")
                {
                    cell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
                if (strAlign == "Right")
                {
                    cell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                if (strAlign == "Middle")
                {
                    cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);

            }

        }

        private void SetGrids(string strHour)
        {
            lblFocus.Focus();
            gvWholeTimeline1.Columns.Clear();
            gvHours1.Columns.Clear();
            gvTimeLine1.Columns.Clear();
            gvWorkOrder1.Columns.Clear();
            gvTrueCycle1.Columns.Clear();

            gvWholeTimeline2.Columns.Clear();
            gvHours2.Columns.Clear();
            gvTimeLine2.Columns.Clear();
            gvWorkOrder2.Columns.Clear();
            gvTrueCycle2.Columns.Clear();

            gvWholeTimeline3.Columns.Clear();
            gvHours3.Columns.Clear();
            gvTimeLine3.Columns.Clear();
            gvWorkOrder3.Columns.Clear();
            gvTrueCycle3.Columns.Clear();

            gvWholeTimeline4.Columns.Clear();
            gvHours4.Columns.Clear();
            gvTimeLine4.Columns.Clear();
            gvWorkOrder4.Columns.Clear();
            gvTrueCycle4.Columns.Clear();


            //string strSQL = "p_tblLeakTestFPY";
            string strSQL = strLineSpecificStoredProc;
            DataSet ds = clsDAL.ProcessSQL(strSQL, "Visual");
            var leakTests = new TupleList4<int, int, int, int, string, int, int>();
            var breakList = new TupleListBreaks<int, int, int, string, int>();
            var spanWO = new TupleWO<int, int, string>();

            if (clsDAL.dsHasData(ds))
            {
                DataTable dt1 = ds.Tables[0];
                DataTable dt2 = ds.Tables[1];

                foreach (DataRow dr in dt1.Rows)
                {
                    int intHour = Convert.ToInt32(dr["hour"].ToString());
                    int intMinute = Convert.ToInt32(dr["minit"].ToString());
                    int intPassFail = Convert.ToInt32(dr["cntPass"].ToString());
                    int intGridCol = Convert.ToInt32(dr["GridCol"].ToString());
                    string strWO = dr["WorkOrder"].ToString();
                    int intColSpan = Convert.ToInt32(dr["WOGridSpan"].ToString());
                    int intBegWOCol = Convert.ToInt32(dr["WOGridStart"].ToString());
                    int intCycleTime = Convert.ToInt32(dr["TCycle"].ToString());
                    leakTests.Add(intHour, intMinute, intPassFail, intGridCol, strWO, intColSpan, intBegWOCol);

                    if(intPassFail == 1)
                    {
                        trueCycleTimes.Add(new Tuple<int, int, int, int>(intHour, intMinute, intCycleTime, intGridCol));
                    }
                   
                }

                foreach (DataRow dr in dt2.Rows)
                {
                    int intHour = Convert.ToInt32(dr["hour"].ToString());
                    int intMinute = Convert.ToInt32(dr["minit"].ToString());
                    int intDuration = Convert.ToInt32(dr["Duration"].ToString());
                    string strBreakType = dr["BreakType"].ToString();
                    int intBreakCol = Convert.ToInt32(dr["BreakCol"].ToString());
                    breakList.Add(intHour, intMinute, intDuration, strBreakType, intBreakCol);
                }

   
            }

            //DataGridViewTextBoxColumnEx col3 = new DataGridViewTextBoxColumnEx();
            for (int y = 1; y <= 4; y++)
            {
                for (int z = 0; z < 380; z++)
                {
                    DataGridViewTextBoxColumnEx col = new DataGridViewTextBoxColumnEx();
                    DataGridViewTextBoxColumnEx col5 = new DataGridViewTextBoxColumnEx();
                    DataGridViewTextBoxColumnEx col6 = new DataGridViewTextBoxColumnEx();
                    DataGridViewTextBoxColumnEx col7 = new DataGridViewTextBoxColumnEx();

                    col.FillWeight = 10;
                    col.Width = 4;
                    col.Name = z.ToString();

                    col5.FillWeight = 10;
                    col5.Width = 4;
                    col5.Name = z.ToString();

                    col6.FillWeight = 10;
                    col6.Width = 4;
                    col6.Name = z.ToString();

                    col7.FillWeight = 10;
                    col7.Width = 10;
                    col7.Name = z.ToString();

                    switch (y)
                    {
                        case (1):
                            gvWholeTimeline1.RowHeadersVisible = false;
                            gvWholeTimeline1.ColumnHeadersVisible = false;
                            gvWholeTimeline1.ScrollBars = ScrollBars.None;
                            gvWholeTimeline1.CellBorderStyle = DataGridViewCellBorderStyle.None;
                            gvWholeTimeline1.BorderStyle = BorderStyle.None;

                            gvWorkOrder1.RowHeadersVisible = false;
                            gvWorkOrder1.ColumnHeadersVisible = false;
                            gvWorkOrder1.ScrollBars = ScrollBars.None;
                            gvWorkOrder1.CellBorderStyle = DataGridViewCellBorderStyle.None;
                            gvWorkOrder1.BorderStyle = BorderStyle.None;

                            gvTimeLine1.RowHeadersVisible = false;
                            gvTimeLine1.ColumnHeadersVisible = false;
                            gvTimeLine1.ScrollBars = ScrollBars.None;
                            gvTimeLine1.CellBorderStyle = DataGridViewCellBorderStyle.None;
                            gvTimeLine1.BorderStyle = BorderStyle.None;

                            gvTrueCycle1.RowHeadersVisible = false;
                            gvTrueCycle1.ColumnHeadersVisible = false;
                            gvTrueCycle1.ScrollBars = ScrollBars.None;
                            gvTrueCycle1.CellBorderStyle = DataGridViewCellBorderStyle.None;
                            gvTrueCycle1.BorderStyle = BorderStyle.None;



                            gvWholeTimeline1.Columns.Add(col);
                            gvWorkOrder1.Columns.Add(col5);
                            gvTimeLine1.Columns.Add(col6);
                            gvTrueCycle1.Columns.Add(col7);


                            gvWholeTimeline1.Height = gvWholeTimeline1.Rows[0].Height + 20;
                            gvWorkOrder1.Height = gvWorkOrder1.Rows[0].Height;
                            gvTimeLine1.Height = gvTimeLine1.Rows[0].Height;
                            gvTrueCycle1.Height = gvTimeLine1.Rows[0].Height + 10;
                            break;

                        case (2):
                            gvWholeTimeline2.RowHeadersVisible = false;
                            gvWholeTimeline2.ColumnHeadersVisible = false;
                            gvWholeTimeline3.ScrollBars = ScrollBars.None;
                            gvWholeTimeline2.CellBorderStyle = DataGridViewCellBorderStyle.None;
                            gvWholeTimeline2.BorderStyle = BorderStyle.None;

                            gvWorkOrder2.RowHeadersVisible = false;
                            gvWorkOrder2.ColumnHeadersVisible = false;
                            gvWorkOrder2.ScrollBars = ScrollBars.None;
                            gvWorkOrder2.CellBorderStyle = DataGridViewCellBorderStyle.None;
                            gvWorkOrder2.BorderStyle = BorderStyle.None;

                            gvTimeLine2.RowHeadersVisible = false;
                            gvTimeLine2.ColumnHeadersVisible = false;
                            gvTimeLine2.ScrollBars = ScrollBars.None;
                            gvTimeLine2.CellBorderStyle = DataGridViewCellBorderStyle.None;
                            gvTimeLine2.BorderStyle = BorderStyle.None;

                            gvTrueCycle2.RowHeadersVisible = false;
                            gvTrueCycle2.ColumnHeadersVisible = false;
                            gvTrueCycle2.ScrollBars = ScrollBars.None;
                            gvTrueCycle2.CellBorderStyle = DataGridViewCellBorderStyle.None;
                            gvTrueCycle2.BorderStyle = BorderStyle.None;



                            gvWholeTimeline2.Columns.Add(col);
                            gvWorkOrder2.Columns.Add(col5);
                            gvTimeLine2.Columns.Add(col6);
                            gvTrueCycle2.Columns.Add(col7);


                            gvWholeTimeline2.Height = gvWholeTimeline2.Rows[0].Height + 20;
                            gvWorkOrder2.Height = gvWorkOrder2.Rows[0].Height;
                            gvTimeLine2.Height = gvTimeLine2.Rows[0].Height;
                            gvTrueCycle2.Height = gvTimeLine2.Rows[0].Height + 10;
                            break;

                        case (3):
                            gvWholeTimeline3.RowHeadersVisible = false;
                            gvWholeTimeline3.ColumnHeadersVisible = false;
                            gvWholeTimeline3.ScrollBars = ScrollBars.None;
                            gvWholeTimeline3.CellBorderStyle = DataGridViewCellBorderStyle.None;
                            gvWholeTimeline3.BorderStyle = BorderStyle.None;

                            gvWorkOrder3.RowHeadersVisible = false;
                            gvWorkOrder3.ColumnHeadersVisible = false;
                            gvWorkOrder3.ScrollBars = ScrollBars.None;
                            gvWorkOrder3.CellBorderStyle = DataGridViewCellBorderStyle.None;
                            gvWorkOrder3.BorderStyle = BorderStyle.None;

                            gvTimeLine3.RowHeadersVisible = false;
                            gvTimeLine3.ColumnHeadersVisible = false;
                            gvTimeLine3.ScrollBars = ScrollBars.None;
                            gvTimeLine3.CellBorderStyle = DataGridViewCellBorderStyle.None;
                            gvTimeLine3.BorderStyle = BorderStyle.None;

                            gvTrueCycle3.RowHeadersVisible = false;
                            gvTrueCycle3.ColumnHeadersVisible = false;
                            gvTrueCycle3.ScrollBars = ScrollBars.None;
                            gvTrueCycle3.CellBorderStyle = DataGridViewCellBorderStyle.None;
                            gvTrueCycle3.BorderStyle = BorderStyle.None;



                            gvWholeTimeline3.Columns.Add(col);
                            gvWorkOrder3.Columns.Add(col5);
                            gvTimeLine3.Columns.Add(col6);
                            gvTrueCycle3.Columns.Add(col7);


                            gvWholeTimeline3.Height = gvWholeTimeline3.Rows[0].Height + 20;
                            gvWorkOrder3.Height = gvWorkOrder3.Rows[0].Height;
                            gvTimeLine3.Height = gvTimeLine3.Rows[0].Height;
                            gvTrueCycle3.Height = gvTimeLine3.Rows[0].Height + 10;
                            break;

                        case (4):
                            gvWholeTimeline4.RowHeadersVisible = false;
                            gvWholeTimeline4.ColumnHeadersVisible = false;
                            gvWholeTimeline3.ScrollBars = ScrollBars.None;
                            gvWholeTimeline4.CellBorderStyle = DataGridViewCellBorderStyle.None;
                            gvWholeTimeline4.BorderStyle = BorderStyle.None;

                            gvWorkOrder4.RowHeadersVisible = false;
                            gvWorkOrder4.ColumnHeadersVisible = false;
                            gvWorkOrder4.ScrollBars = ScrollBars.None;
                            gvWorkOrder4.CellBorderStyle = DataGridViewCellBorderStyle.None;
                            gvWorkOrder4.BorderStyle = BorderStyle.None;

                            gvTimeLine4.RowHeadersVisible = false;
                            gvTimeLine4.ColumnHeadersVisible = false;
                            gvTimeLine4.ScrollBars = ScrollBars.None;
                            gvTimeLine4.CellBorderStyle = DataGridViewCellBorderStyle.None;
                            gvTimeLine4.BorderStyle = BorderStyle.None;

                            gvTrueCycle4.RowHeadersVisible = false;
                            gvTrueCycle4.ColumnHeadersVisible = false;
                            gvTrueCycle4.ScrollBars = ScrollBars.None;
                            gvTrueCycle4.CellBorderStyle = DataGridViewCellBorderStyle.None;
                            gvTrueCycle4.BorderStyle = BorderStyle.None;



                            gvWholeTimeline4.Columns.Add(col);
                            gvWorkOrder4.Columns.Add(col5);
                            gvTimeLine4.Columns.Add(col6);
                            gvTrueCycle4.Columns.Add(col7);


                            gvWholeTimeline4.Height = gvWholeTimeline4.Rows[0].Height + 20;
                            gvWorkOrder4.Height = gvWorkOrder4.Rows[0].Height;
                            gvTimeLine4.Height = gvTimeLine4.Rows[0].Height;
                            gvTrueCycle4.Height = gvTimeLine4.Rows[0].Height + 10;
                            break;
                    };

                   

                    lblFocus.Focus();
                }
            }


            //gvHours Set
            int setHour = 0;
            for (int y = 1; y <= 4; y++)
            {
                switch (y)
                {
                    case (1):
                        for (int z = 0; z <= 6; z++)
                        {
                            DataGridViewTextBoxColumnEx col2 = new DataGridViewTextBoxColumnEx();
                            col2.Width = 300;
                            col2.Name = z.ToString();

                            gvHours1.RowHeadersVisible = false;
                            gvHours1.ColumnHeadersVisible = false;
                            gvHours1.ScrollBars = ScrollBars.None;
                            gvHours1.CellBorderStyle = DataGridViewCellBorderStyle.None;
                            gvHours1.BorderStyle = BorderStyle.None;
                            gvHours1.Columns.Add(col2);
                            gvHours1.Height = gvHours1.Rows[0].Height;


                            gvHours1.Rows[0].Cells[z].Style.Font = new Font("Arial", 20F, FontStyle.Bold, GraphicsUnit.Pixel);


                            if (z == 0)
                            {
                                //gvHours.Rows[0].Cells[z].Value = strHour;
                                gvHours1.Rows[0].Cells[z].Value = TwelveHour(z + 12);
                                setHour = z + 12;
                            }
                            else
                            {
                                setHour = setHour + 1;
                                if (z == 6)
                                {
                                    string truncatedHour = TwelveHour(setHour);

                                    int length = truncatedHour.ToString().Length - 2;
                                    gvHours1.Rows[0].Cells[z].Value = truncatedHour.Substring(0, length);
                                }
                                else
                                {
                                    gvHours1.Rows[0].Cells[z].Value = TwelveHour(setHour);
                                }

                            }

                        }

                        break;

                    case (2):
                        for (int z = 0; z <= 6; z++)
                        {
                            DataGridViewTextBoxColumnEx col2 = new DataGridViewTextBoxColumnEx();
                            col2.Width = 300;

                            col2.Name = z.ToString();

                            gvHours2.RowHeadersVisible = false;
                            gvHours2.ColumnHeadersVisible = false;
                            gvHours2.ScrollBars = ScrollBars.None;
                            gvHours2.CellBorderStyle = DataGridViewCellBorderStyle.None;
                            gvHours2.BorderStyle = BorderStyle.None;
                            gvHours2.Columns.Add(col2);
                            gvHours2.Height = gvHours1.Rows[0].Height;


                            gvHours2.Rows[0].Cells[z].Style.Font = new Font("Arial", 20F, FontStyle.Bold, GraphicsUnit.Pixel);


                            if (z == 0)
                            {
                                //gvHours.Rows[0].Cells[z].Value = strHour;
                                gvHours2.Rows[0].Cells[z].Value = TwelveHour(z + 18);
                                setHour = z + 18;
                            }
                            else
                            {
                                setHour = setHour + 1;
                                //gvHours.Rows[0].Cells[z].Value = setHour.ToString();
                                if (z == 6)
                                {
                                    string truncatedHour = TwelveHour(0);

                                    int length = truncatedHour.ToString().Length - 2;
                                    gvHours2.Rows[0].Cells[z].Value = truncatedHour.Substring(0, length);
                                }
                                else
                                {
                                    gvHours2.Rows[0].Cells[z].Value = TwelveHour(setHour);
                                }

                            }

                        }

                        break;

                    case (3):
                        for (int z = 0; z <= 6; z++)
                        {
                            DataGridViewTextBoxColumnEx col2 = new DataGridViewTextBoxColumnEx();
                            col2.Width = 300;
                            col2.Name = z.ToString();

                            gvHours3.RowHeadersVisible = false;
                            gvHours3.ColumnHeadersVisible = false;
                            gvHours3.ScrollBars = ScrollBars.None;
                            gvHours3.CellBorderStyle = DataGridViewCellBorderStyle.None;
                            gvHours3.BorderStyle = BorderStyle.None;
                            gvHours3.Columns.Add(col2);
                            gvHours3.Height = gvHours3.Rows[0].Height;


                            gvHours3.Rows[0].Cells[z].Style.Font = new Font("Arial", 20F, FontStyle.Bold, GraphicsUnit.Pixel);


                            if (z == 0)
                            {
                                //gvHours.Rows[0].Cells[z].Value = strHour;
                                gvHours3.Rows[0].Cells[z].Value = TwelveHour(z);
                                setHour = z;
                            }
                            else
                            {
                                setHour = setHour + 1;
                                if (z == 6)
                                {
                                    string truncatedHour = TwelveHour(setHour);

                                    int length = truncatedHour.ToString().Length - 2;
                                    gvHours3.Rows[0].Cells[z].Value = truncatedHour.Substring(0, length);
                                }
                                else
                                {
                                    gvHours3.Rows[0].Cells[z].Value = TwelveHour(setHour);
                                }

                            }

                        }

                        break;

                    case (4):
                        for (int z = 0; z <= 6; z++)
                        {
                            DataGridViewTextBoxColumnEx col2 = new DataGridViewTextBoxColumnEx();
                            col2.Width = 300;
                            col2.Name = z.ToString();

                            gvHours4.RowHeadersVisible = false;
                            gvHours4.ColumnHeadersVisible = false;
                            gvHours4.ScrollBars = ScrollBars.None;
                            gvHours4.CellBorderStyle = DataGridViewCellBorderStyle.None;
                            gvHours4.BorderStyle = BorderStyle.None;
                            gvHours4.Columns.Add(col2);
                            gvHours4.Height = gvHours1.Rows[0].Height;


                            gvHours4.Rows[0].Cells[z].Style.Font = new Font("Arial", 20F, FontStyle.Bold, GraphicsUnit.Pixel);


                            if (z == 0)
                            {
                                //gvHours.Rows[0].Cells[z].Value = strHour;
                                gvHours4.Rows[0].Cells[z].Value = TwelveHour(z + 6);
                                setHour = z + 6;
                            }
                            else
                            {
                                setHour = setHour + 1;
                                if (z == 6)
                                {
                                    string truncatedHour = TwelveHour(setHour);

                                    int length = truncatedHour.ToString().Length - 2;
                                    gvHours4.Rows[0].Cells[z].Value = truncatedHour.Substring(0, length);
                                }
                                else
                                {
                                    gvHours4.Rows[0].Cells[z].Value = TwelveHour(setHour);
                                }

                            }

                        }

                        break;
                };

              

                PlotLeakTests(y, leakTests, trueCycleTimes, breakList);

                //var date = DateTime.Now;
                //var colorCurrentTime = ((date.Hour * 60)) + date.Minute;
                //if (z == colorCurrentTime)
                //{
                //    gvWholeTimeline1.Rows[0].Cells[z].Style.BackColor = Color.Khaki;
                //    gvWholeTimeline1.Rows[0].Cells[z + 1].Style.BackColor = Color.Khaki;
                //    gvWholeTimeline1.Rows[0].Cells[z - 1].Style.BackColor = Color.FromKnownColor(KnownColor.Window);

                //    gvWorkOrder1.Rows[0].Cells[z].Style.BackColor = Color.Khaki;
                //    gvWorkOrder1.Rows[0].Cells[z + 1].Style.BackColor = Color.Khaki;
                //    gvWorkOrder1.Rows[0].Cells[z - 1].Style.BackColor = Color.FromKnownColor(KnownColor.Window);

                //    gvTimeLine1.Rows[0].Cells[z].Style.BackColor = Color.Khaki;
                //    gvTimeLine1.Rows[0].Cells[z + 1].Style.BackColor = Color.Khaki;
                //    gvTimeLine1.Rows[0].Cells[z - 1].Style.BackColor = Color.FromKnownColor(KnownColor.Window);
                //}



                //foreach (var col in breakList)
                //{
                //    if (col.Item5 == z && col.Item4.Contains("Break"))
                //    {
                //        SetSpan(gvTimeLine1, z, 0, col.Item3, 0, "Middle");
                //        gvTimeLine1.Rows[0].Cells[z].Value = "Break";
                //        gvTimeLine1.Rows[0].Cells[z].Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                //        gvTimeLine1.Rows[0].Cells[z].Style.BackColor = Color.LightSteelBlue;
                //        gvTimeLine1.Rows[0].Cells[z].Style.ForeColor = Color.Black;
                //    }

                //    if (col.Item5 == z && col.Item4.Contains("Lunch"))
                //    {
                //        SetSpan(gvTimeLine1, z, 0, col.Item3, 0, "Middle");
                //        gvTimeLine1.Rows[0].Cells[z].Value = "Lunch";
                //        gvTimeLine1.Rows[0].Cells[z].Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                //        gvTimeLine1.Rows[0].Cells[z].Style.BackColor = Color.LightSteelBlue;
                //        gvTimeLine1.Rows[0].Cells[z].Style.ForeColor = Color.Black;
                //    }
                //}
            }





            //int intShiftGrid = (Convert.ToInt32(strHour) * 60) + 60;
            //gvWholeTimeline.FirstDisplayedScrollingColumnIndex = intShiftGrid;
            //gvWorkOrder.FirstDisplayedScrollingColumnIndex = intShiftGrid;
            //gvTimeLine.FirstDisplayedScrollingColumnIndex = intShiftGrid;

        }

        public void PlotLeakTests(int intY, TupleList4<int, int, int, int, string, int, int> leakTests, List<Tuple<int, int, int, int>> trueCycleTimes, TupleListBreaks<int, int, int, string, int> breaklist)
        {
            int intLoop = 0;
            var loopLeakTest = new TupleList4<int, int, int, int, string, int, int>();
            var loopTrueCycleTime = new List<Tuple<int, int, int, int>>();
            var loopbreakList = new TupleListBreaks<int, int, int, string, int>();

            //if (intY == 1) { intY = 4; }
            //else if (intY == 2) { intY = 3; }
            //else if (intY == 3) { intY = 1; }
            //else if (intY == 4) { intY = 2; }

            switch (intY)
            {
                case (1):
                    foreach (var del in leakTests)
                    {
                        if (del.Item1 >= 12 && del.Item1 < 18)
                        {
                            loopLeakTest.Add(del);
                        }
                    }

                    foreach (var delCT in trueCycleTimes)
                    {
                        if (delCT.Item1 >= 12 && delCT.Item1 < 18)
                        {
                            loopTrueCycleTime.Add(delCT);
                        }
                    }

                    foreach (var brk in breaklist)
                    {
                        if (brk.Item1 >= 12 && brk.Item1 < 20)
                        {
                            loopbreakList.Add(brk);
                        }
                    }
                    //Plot Leak Tests
                    try
                    {
                        for (int z = 0; z < 359; z++)
                        {
                            foreach (var x in loopLeakTest)
                            {


                                foreach (var ct in loopTrueCycleTime)
                                {

                                    if (ct.Item4 == z  && ct.Item4 + ct.Item3 < 360)
                                    {
                                        SetSpan(gvTrueCycle1, z, 0, ct.Item3, 0, "Middle");
                                        gvTrueCycle1.Rows[0].Cells[z].Value = ct.Item3.ToString() + " min";
                                        gvTrueCycle1.Rows[0].Cells[z].Style.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Pixel);
                                    }

                                    if (ct.Item4 == z  && ct.Item4 + ct.Item3 >= 360)
                                    {
                                        int intShrinkSpan = 10;
                                        SetSpan(gvTrueCycle1, z, 0, intShrinkSpan, 0, "Middle");
                                        gvTrueCycle1.Rows[0].Cells[z].Value = ct.Item3.ToString() + " min";
                                        gvTrueCycle1.Rows[0].Cells[z].Style.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Pixel);
                                    }

                                }


                                //15 minute Tick Marks
                                if (z % 15 == 0)
                                {
                                    gvWholeTimeline1.Rows[0].Cells[z].Value = "*";
                                    gvWholeTimeline1.Rows[0].Cells[z].Style.Font = new Font("Arial", 8F, FontStyle.Bold, GraphicsUnit.Pixel);

                                    int[] hours = { 0, 60, 120, 180, 240, 300 };

                                    if (hours.Contains(z))
                                    {
                                        gvWholeTimeline1.Rows[0].Cells[z].Value = null;
                                    }
                                }

                                //Green Red Marks
                                if (x.Item4 == z )
                                {
                                    decimal decCell = x.Item4 / 12;
                                    decCell = Math.Round(decCell);
                                    int intCell = Convert.ToInt32(decCell);

                                    if (x.Item3 == 0)
                                    {
                                        gvWholeTimeline1.Rows[0].Cells[x.Item4].Style.BackColor = Color.Firebrick;
                                    }
                                    if (x.Item3 == 1)
                                    {
                                        gvWholeTimeline1.Rows[0].Cells[x.Item4].Style.BackColor = Color.MediumSeaGreen;

                                    }

                                }


                                //Work Order
                                if (x.Item7 == z )
                                {
                                    gvWorkOrder1.Rows[0].Cells[x.Item7].Style.BackColor = Color.WhiteSmoke;

                                    //if (x.Item6 == 0)
                                    //{
                                    //    gvWorkOrder1.Rows[0].Cells[20].Style.BackColor = Color.WhiteSmoke;
                                    //    SetSpan(gvWorkOrder1, x.Item7, 0, 20, 0, "Middle");
                                    //    gvWorkOrder1.Rows[0].Cells[x.Item7].Value = x.Item5.ToString();
                                    //    gvWorkOrder1.Rows[0].Cells[z].Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                                    //}

                                    if (x.Item7 + x.Item6 >= 359)
                                    {
                                        int intShrinkSpan = 359 - x.Item7;
                                        SetSpan(gvWorkOrder1, x.Item7 , 0, intShrinkSpan, 0, "Middle");
                                        gvWorkOrder1.Rows[0].Cells[x.Item7 ].Value = x.Item5.ToString();
                                        gvWorkOrder1.Rows[0].Cells[z].Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                                    }
                                    else
                                    {
                                        for (int colSpan = 1; colSpan <= x.Item6; colSpan++)
                                        {
                                            gvWorkOrder1.Rows[0].Cells[x.Item7 + colSpan].Style.BackColor = Color.WhiteSmoke;
                                        }

                                        SetSpan(gvWorkOrder1, x.Item7, 0, x.Item6, 0, "Middle");
                                        gvWorkOrder1.Rows[0].Cells[x.Item7].Value = x.Item5.ToString();
                                        gvWorkOrder1.Rows[0].Cells[z].Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);

                                    }

                                }

                                foreach (var col in loopbreakList)
                                {
                                    if (col.Item5 == z  && col.Item4.Contains("Break"))
                                    {
                                        SetSpan(gvTimeLine1, z, 0, col.Item3, 0, "Middle");
                                        gvTimeLine1.Rows[0].Cells[z].Value = "Break";
                                        gvTimeLine1.Rows[0].Cells[z].Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                                        gvTimeLine1.Rows[0].Cells[z].Style.BackColor = Color.LightSteelBlue;
                                        gvTimeLine1.Rows[0].Cells[z].Style.ForeColor = Color.Black;
                                    }

                                    if (col.Item5 == z  && col.Item4.Contains("Lunch"))
                                    {
                                        SetSpan(gvTimeLine1, z, 0, col.Item3, 0, "Middle");
                                        gvTimeLine1.Rows[0].Cells[z].Value = "Lunch";
                                        gvTimeLine1.Rows[0].Cells[z].Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                                        gvTimeLine1.Rows[0].Cells[z].Style.BackColor = Color.LightSteelBlue;
                                        gvTimeLine1.Rows[0].Cells[z].Style.ForeColor = Color.Black;
                                    }
                                }

                            }

                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    break;


                case (2):
                    foreach (var del in leakTests)
                    {
                        if (del.Item1 >= 18 && del.Item1 < 24)
                        {
                            loopLeakTest.Add(del);
                        }
                    }

                    foreach (var delCT in trueCycleTimes)
                    {
                        if (delCT.Item1 >= 18 && delCT.Item1 < 24)
                        {
                            loopTrueCycleTime.Add(delCT);
                        }
                    }

                    foreach (var brk in breaklist)
                    {
                        if (brk.Item1 >= 18)
                        {
                            loopbreakList.Add(brk);
                        }
                    }
                    //Plot Leak Tests
                    try
                    {
                        for (int z = 0; z < 359; z++)
                        {
                            foreach (var x in loopLeakTest)
                            {

                                foreach (var ct in loopTrueCycleTime)
                                {

                                    if (ct.Item4 == z + 360 && ct.Item4 + ct.Item3 < 720)
                                    {
                                        SetSpan(gvTrueCycle2, z, 0, ct.Item3, 0, "Middle");
                                        gvTrueCycle2.Rows[0].Cells[z].Value = ct.Item3.ToString() + " min";
                                        gvTrueCycle2.Rows[0].Cells[z].Style.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Pixel);
                                    }

                                    if (ct.Item4 == z + 360 && ct.Item4 + ct.Item3 >= 720)
                                    {
                                        int intShrinkSpan = 10;
                                        SetSpan(gvTrueCycle2, z, 0, intShrinkSpan, 0, "Middle");
                                        gvTrueCycle2.Rows[0].Cells[z].Value = ct.Item3.ToString() + " min";
                                        gvTrueCycle2.Rows[0].Cells[z].Style.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Pixel);
                                    }

                                }



                                //15 minute Tick Marks
                                if (z % 15 == 0)
                                {
                                    gvWholeTimeline2.Rows[0].Cells[z].Value = "*";
                                    gvWholeTimeline2.Rows[0].Cells[z].Style.Font = new Font("Arial", 8F, FontStyle.Bold, GraphicsUnit.Pixel);

                                    int[] hours = { 0, 60, 120, 180, 240, 300 };

                                    if (hours.Contains(z))
                                    {
                                        gvWholeTimeline2.Rows[0].Cells[z].Value = null;
                                    }
                                }

                                //Green Red Marks
                                if (x.Item4 == z + 360)
                                {
                                    decimal decCell = x.Item4 / 6;
                                    decCell = Math.Round(decCell);
                                    int intCell = Convert.ToInt32(decCell);

                                    if (x.Item3 == 0)
                                    {
                                        gvWholeTimeline2.Rows[0].Cells[z].Style.BackColor = Color.Firebrick;
                                    }
                                    if (x.Item3 == 1)
                                    {
                                        gvWholeTimeline2.Rows[0].Cells[z].Style.BackColor = Color.MediumSeaGreen;

                                    }

                                }


                                //Work Order
                                if (x.Item7 == z + 360)
                                {
                                    gvWorkOrder2.Rows[0].Cells[x.Item7 - 360].Style.BackColor = Color.WhiteSmoke;

                                    if (x.Item6 == 0)
                                    {
                                        gvWorkOrder2.Rows[0].Cells[20].Style.BackColor = Color.WhiteSmoke;
                                        SetSpan(gvWorkOrder2, x.Item7, 0, 20, 0, "Middle");
                                        gvWorkOrder2.Rows[0].Cells[x.Item7].Value = x.Item5.ToString();
                                        gvWorkOrder2.Rows[0].Cells[z].Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                                    }

                                    if (x.Item7 + x.Item6 >= 719)
                                    {
                                        int intShrinkSpan = 719 - x.Item7;
                                        SetSpan(gvWorkOrder2, x.Item7 - 360, 0, intShrinkSpan, 0, "Middle");
                                        gvWorkOrder2.Rows[0].Cells[x.Item7 - 360].Value = x.Item5.ToString();
                                        gvWorkOrder2.Rows[0].Cells[z].Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                                    }
                                    else
                                    {
                                        for (int colSpan = 1; colSpan <= x.Item6; colSpan++)
                                        {
                                            gvWorkOrder2.Rows[0].Cells[x.Item7 - 360 + colSpan].Style.BackColor = Color.WhiteSmoke;
                                        }

                                        SetSpan(gvWorkOrder2, x.Item7 - 360, 0, x.Item6, 0, "Middle");
                                        gvWorkOrder2.Rows[0].Cells[x.Item7 - 360].Value = x.Item5.ToString();
                                        gvWorkOrder2.Rows[0].Cells[z].Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);

                                    }

                                }

                                foreach (var col in loopbreakList)
                                {
                                    if (col.Item5 == z + 360 && col.Item4.Contains("Break"))
                                    {
                                        SetSpan(gvTimeLine2, z, 0, col.Item3, 0, "Middle");
                                        gvTimeLine2.Rows[0].Cells[z].Value = "Break";
                                        gvTimeLine2.Rows[0].Cells[z].Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                                        gvTimeLine2.Rows[0].Cells[z].Style.BackColor = Color.LightSteelBlue;
                                        gvTimeLine2.Rows[0].Cells[z].Style.ForeColor = Color.Black;
                                    }

                                    if (col.Item5 == z + 360 && col.Item4.Contains("Lunch"))
                                    {
                                        SetSpan(gvTimeLine2, z, 0, col.Item3, 0, "Middle");
                                        gvTimeLine2.Rows[0].Cells[z].Value = "Lunch";
                                        gvTimeLine2.Rows[0].Cells[z].Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                                        gvTimeLine2.Rows[0].Cells[z].Style.BackColor = Color.LightSteelBlue;
                                        gvTimeLine2.Rows[0].Cells[z].Style.ForeColor = Color.Black;
                                    }
                                }

                            }

                        }
                    }
                    catch (Exception ex)
                    {

                    }



                    break;

                case (3):
                    //loopLeakTest = leakTests;
                    foreach (var del in leakTests)
                    {
                        if (del.Item1 >= 0 && del.Item1 < 6)
                        {
                            loopLeakTest.Add(del);
                        }
                    }

                    foreach (var delCT in trueCycleTimes)
                    {
                        if (delCT.Item1 >= 0 && delCT.Item1 < 6)
                        {
                            loopTrueCycleTime.Add(delCT);
                        }
                    }

                    foreach (var brk in breaklist)
                    {
                        if (brk.Item1 >= 0 && brk.Item1 < 6)
                        {
                            loopbreakList.Add(brk);
                        }
                    }

                    //Plot Leak Tests
                    try
                    {
                        for (int z = 0; z < 359; z++)
                        {
                            foreach (var x in loopLeakTest)
                            {

                                ////True CycleTimes
                                //foreach (var ct in loopTrueCycleTime)
                                //{
                                //    //decimal decConvertedCol = (ct.Item4 / 6);
                                //    //decConvertedCol = Math.Round(decConvertedCol);
                                //    //int intConvertedCol = Convert.ToInt32(decConvertedCol);

                                //    if (ct.Item4 == z + 720)
                                //    {
                                //        SetSpan(gvTrueCycle3, z, 0, ct.Item3, 0, "Middle");
                                //        gvTrueCycle3.Rows[0].Cells[z].Value = ct.Item3.ToString() + " min";
                                //        gvTrueCycle3.Rows[0].Cells[z].Style.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Pixel);
                                //    }
                                //}

                                foreach (var ct in loopTrueCycleTime)
                                {

                                    if (ct.Item4 == z + 720 && ct.Item4 + ct.Item3 < 1080)
                                    {
                                        SetSpan(gvTrueCycle3, z, 0, ct.Item3, 0, "Middle");
                                        gvTrueCycle3.Rows[0].Cells[z].Value = ct.Item3.ToString() + " min";
                                        gvTrueCycle3.Rows[0].Cells[z].Style.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Pixel);
                                    }

                                    if (ct.Item4 == z + 720 && ct.Item4 + ct.Item3 >= 1080)
                                    {
                                        int intShrinkSpan = 10;
                                        SetSpan(gvTrueCycle3, z, 0, intShrinkSpan, 0, "Middle");
                                        gvTrueCycle3.Rows[0].Cells[z].Value = ct.Item3.ToString() + " min";
                                        gvTrueCycle3.Rows[0].Cells[z].Style.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Pixel);
                                    }

                                }


                                //15 minute Tick Marks
                                if (z % 15 == 0)
                                {
                                    gvWholeTimeline3.Rows[0].Cells[z].Value = "*";
                                    gvWholeTimeline3.Rows[0].Cells[z].Style.Font = new Font("Arial", 8F, FontStyle.Bold, GraphicsUnit.Pixel);

                                    int[] hours = { 0, 60, 120, 180, 240, 300 };

                                    if (hours.Contains(z))
                                    {
                                        gvWholeTimeline3.Rows[0].Cells[z].Value = null;
                                    }
                                }

                                //Green Red Marks
                                if (x.Item4 == z + 720)
                                {
                                    decimal decCell = x.Item4 / 12;
                                    decCell = Math.Round(decCell);
                                    int intCell = Convert.ToInt32(decCell);

                                    if (x.Item3 == 0)
                                    {
                                        gvWholeTimeline3.Rows[0].Cells[z].Style.BackColor = Color.Firebrick;
                                    }
                                    if (x.Item3 == 1)
                                    {
                                        gvWholeTimeline3.Rows[0].Cells[z].Style.BackColor = Color.MediumSeaGreen;

                                    }

                                }


                                //Work Order
                                if (x.Item7 == z + 720)
                                {
                                    gvWorkOrder3.Rows[0].Cells[x.Item7 - 720].Style.BackColor = Color.WhiteSmoke;

                                    if (x.Item6 == 0)
                                    {
                                        gvWorkOrder3.Rows[0].Cells[20].Style.BackColor = Color.WhiteSmoke;
                                        SetSpan(gvWorkOrder3, x.Item7, 0, 20, 0, "Middle");
                                        gvWorkOrder3.Rows[0].Cells[x.Item7].Value = x.Item5.ToString();
                                        gvWorkOrder3.Rows[0].Cells[z].Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                                    }

                                    if (x.Item7 + x.Item6 >= 1080)
                                    {
                                        int intShrinkSpan = 1080 - x.Item7;
                                        SetSpan(gvWorkOrder3, x.Item7 - 720, 0, intShrinkSpan, 0, "Middle");
                                        gvWorkOrder3.Rows[0].Cells[x.Item7 - 720].Value = x.Item5.ToString();
                                        gvWorkOrder3.Rows[0].Cells[z].Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                                    }
                                    else
                                    {
                                        for (int colSpan = 1; colSpan <= x.Item6; colSpan++)
                                        {
                                            gvWorkOrder3.Rows[0].Cells[x.Item7 - 720 + colSpan].Style.BackColor = Color.WhiteSmoke;
                                        }

                                        SetSpan(gvWorkOrder3, x.Item7 - 720, 0, x.Item6, 0, "Middle");
                                        gvWorkOrder3.Rows[0].Cells[x.Item7 - 720].Value = x.Item5.ToString();
                                        gvWorkOrder3.Rows[0].Cells[z].Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);

                                    }

                                }

                                foreach (var col in loopbreakList)
                                {
                                    if (col.Item5 == z + 720 && col.Item4.Contains("Break"))
                                    {
                                        SetSpan(gvTimeLine3, z, 0, col.Item3, 0, "Middle");
                                        gvTimeLine3.Rows[0].Cells[z].Value = "Break";
                                        gvTimeLine3.Rows[0].Cells[z].Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                                        gvTimeLine3.Rows[0].Cells[z].Style.BackColor = Color.LightSteelBlue;
                                        gvTimeLine3.Rows[0].Cells[z].Style.ForeColor = Color.Black;
                                    }

                                    if (col.Item5 == z + 720 && col.Item4.Contains("Lunch"))
                                    {
                                        SetSpan(gvTimeLine3, z, 0, col.Item3, 0, "Middle");
                                        gvTimeLine3.Rows[0].Cells[z].Value = "Lunch";
                                        gvTimeLine3.Rows[0].Cells[z].Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                                        gvTimeLine3.Rows[0].Cells[z].Style.BackColor = Color.LightSteelBlue;
                                        gvTimeLine3.Rows[0].Cells[z].Style.ForeColor = Color.Black;
                                    }
                                }

                            }

                        }
                    }
                    catch (Exception ex)
                    {

                    }

                    break;

                case (4):
                    //loopLeakTest = leakTests;
                    foreach (var del in leakTests)
                    {
                        if (del.Item1 >= 6 && del.Item1 < 12)
                        {
                            loopLeakTest.Add(del);
                        }
                    }

                    foreach (var delCT in trueCycleTimes)
                    {
                        if (delCT.Item1 >= 6 && delCT.Item1 < 12)
                        {
                            loopTrueCycleTime.Add(delCT);
                        }
                    }

                    foreach (var brk in breaklist)
                    {
                        if (brk.Item1 >= 6 && brk.Item1 < 12)
                        {
                            loopbreakList.Add(brk);
                        }
                    }

                    //Plot Leak Tests
                    try
                    {
                        for (int z = 0; z < 359; z++)
                        {
                            foreach (var x in loopLeakTest)
                            {

                                ////True CycleTimes
                                //foreach (var ct in loopTrueCycleTime)
                                //{
                                //    //decimal decConvertedCol = (ct.Item4 / 6);
                                //    //decConvertedCol = Math.Round(decConvertedCol);
                                //    //int intConvertedCol = Convert.ToInt32(decConvertedCol);

                                //    if (ct.Item4 == z + 720)
                                //    {
                                //        SetSpan(gvTrueCycle3, z, 0, ct.Item3, 0, "Middle");
                                //        gvTrueCycle3.Rows[0].Cells[z].Value = ct.Item3.ToString() + " min";
                                //        gvTrueCycle3.Rows[0].Cells[z].Style.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Pixel);
                                //    }
                                //}

                                foreach (var ct in loopTrueCycleTime)
                                {

                                    if (ct.Item4 == z + 1080 && ct.Item4 + ct.Item3 < 1440)
                                    {
                                        SetSpan(gvTrueCycle4, z, 0, ct.Item3, 0, "Middle");
                                        gvTrueCycle4.Rows[0].Cells[z].Value = ct.Item3.ToString() + " min";
                                        gvTrueCycle4.Rows[0].Cells[z].Style.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Pixel);
                                    }

                                    if (ct.Item4 == z + 1080 && ct.Item4 + ct.Item3 >= 1440)
                                    {
                                        int intShrinkSpan = 10;
                                        SetSpan(gvTrueCycle4, z, 0, intShrinkSpan, 0, "Middle");
                                        gvTrueCycle4.Rows[0].Cells[z].Value = ct.Item3.ToString() + " min";
                                        gvTrueCycle4.Rows[0].Cells[z].Style.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Pixel);
                                    }

                                }


                                //15 minute Tick Marks
                                if (z % 15 == 0)
                                {
                                    gvWholeTimeline4.Rows[0].Cells[z].Value = "*";
                                    gvWholeTimeline4.Rows[0].Cells[z].Style.Font = new Font("Arial", 8F, FontStyle.Bold, GraphicsUnit.Pixel);

                                    int[] hours = { 0, 60, 120, 180, 240, 300 };

                                    if (hours.Contains(z))
                                    {
                                        gvWholeTimeline4.Rows[0].Cells[z].Value = null;
                                    }
                                }

                                //Green Red Marks
                                if (x.Item4 == z + 1080)
                                {
                                    decimal decCell = x.Item4 / 18;
                                    decCell = Math.Round(decCell);
                                    int intCell = Convert.ToInt32(decCell);

                                    if (x.Item3 == 0)
                                    {
                                        gvWholeTimeline4.Rows[0].Cells[z].Style.BackColor = Color.Firebrick;
                                    }
                                    if (x.Item3 == 1)
                                    {
                                        gvWholeTimeline4.Rows[0].Cells[z].Style.BackColor = Color.MediumSeaGreen;

                                    }

                                }


                                //Work Order
                                if (x.Item7 == z + 1080)
                                {
                                    gvWorkOrder4.Rows[0].Cells[x.Item7 - 1080].Style.BackColor = Color.WhiteSmoke;

                                    if (x.Item6 == 0)
                                    {
                                    //    gvWorkOrder4.Rows[0].Cells[20].Style.BackColor = Color.WhiteSmoke;
                                    //    SetSpan(gvWorkOrder4, x.Item7, 0, 20, 0, "Middle");
                                    //    gvWorkOrder4.Rows[0].Cells[x.Item7].Value = x.Item5.ToString();
                                    //    gvWorkOrder4.Rows[0].Cells[z].Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                                    }

                                    if (x.Item7 + x.Item6 >= 1440)
                                    {
                                        int intShrinkSpan = 1440 - x.Item7;
                                        SetSpan(gvWorkOrder4, x.Item7 - 1080, 0, intShrinkSpan, 0, "Middle");
                                        gvWorkOrder4.Rows[0].Cells[x.Item7 - 1080].Value = x.Item5.ToString();
                                        gvWorkOrder4.Rows[0].Cells[z].Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                                    }
                                    else
                                    {
                                        for (int colSpan = 1; colSpan <= x.Item6; colSpan++)
                                        {
                                            gvWorkOrder4.Rows[0].Cells[x.Item7 - 1080 + colSpan].Style.BackColor = Color.WhiteSmoke;
                                        }

                                        SetSpan(gvWorkOrder4, x.Item7 - 1080, 0, x.Item6, 0, "Middle");
                                        gvWorkOrder4.Rows[0].Cells[x.Item7 - 1080].Value = x.Item5.ToString();
                                        gvWorkOrder4.Rows[0].Cells[z].Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);

                                    }

                                }

                                foreach (var col in loopbreakList)
                                {
                                    if (col.Item5 == z + 1080 && col.Item4.Contains("Break"))
                                    {
                                        SetSpan(gvTimeLine4, z, 0, col.Item3, 0, "Middle");
                                        gvTimeLine4.Rows[0].Cells[z].Value = "Break";
                                        gvTimeLine4.Rows[0].Cells[z].Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                                        gvTimeLine4.Rows[0].Cells[z].Style.BackColor = Color.LightSteelBlue;
                                        gvTimeLine4.Rows[0].Cells[z].Style.ForeColor = Color.Black;
                                    }

                                    if (col.Item5 == z + 1080 && col.Item4.Contains("Lunch"))
                                    {
                                        SetSpan(gvTimeLine4, z, 0, col.Item3, 0, "Middle");
                                        gvTimeLine4.Rows[0].Cells[z].Value = "Lunch";
                                        gvTimeLine4.Rows[0].Cells[z].Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                                        gvTimeLine4.Rows[0].Cells[z].Style.BackColor = Color.LightSteelBlue;
                                        gvTimeLine4.Rows[0].Cells[z].Style.ForeColor = Color.Black;
                                    }
                                }

                            }

                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    break;

            };

        }


        private string TwelveHour(int intHour)
        {
            switch (intHour)
            {
                case (1):
                    return "1am";
                    break;
                case (2):
                    return "2am";
                    break;
                case (3):
                    return "3am";
                    break;
                case (4):
                    return "4am";
                    break;
                case (5):
                    return "5am";
                    break;
                case (6):
                    return "6am";
                    break;
                case (7):
                    return "7am";
                    break;
                case (8):
                    return "8am";
                    break;
                case (9):
                    return "9am";
                    break;
                case (10):
                    return "10am";
                    break;
                case (11):
                    return "11am";
                    break;
                case (12):
                    return "12pm";
                    break;
                case (13):
                    return "1pm";
                    break;
                case (14):
                    return "2pm";
                    break;
                case (15):
                    return "3pm";
                    break;
                case (16):
                    return "4pm";
                    break;
                case (17):
                    return "5pm";
                    break;
                case (18):
                    return "6pm";
                    break;
                case (19):
                    return "7pm";
                    break;
                case (20):
                    return "8pm";
                    break;
                case (21):
                    return "9pm";
                    break;
                case (22):
                    return "10pm";
                    break;
                case (23):
                    return "11pm";
                    break;
                case (0):
                    return "12am";
                    break;
            };
            return "";
        }

        private void btnPKU2_Click(object sender, EventArgs e)
        {
            this.LNID = 2;
            trueCycleTimes.Clear();
            this.Cursor = Cursors.WaitCursor;
            frm24HourStackedNoon_Shown(btnPKU2, EventArgs.Empty);
        }

        private void btnPKU1_Click(object sender, EventArgs e)
        {
            this.LNID = 1;
            trueCycleTimes.Clear();
            this.Cursor = Cursors.WaitCursor;
            frm24HourStackedNoon_Shown(btnPKU2, EventArgs.Empty);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            trueCycleTimes.Clear();
            frm24HourStackedNoon_Shown(timer1, EventArgs.Empty);
        }

        private void dtForReport_CloseUp(object sender, EventArgs e)
        {
            reportDate = this.dtForReport.Value;
            this.Cursor = Cursors.WaitCursor;
            trueCycleTimes.Clear();
            frm24HourStackedNoon_Shown(sender, EventArgs.Empty);
            
        }
    }
}
