using SpannedDataGridViewNet2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FPY
{
    public partial class frmFPYThreeHourTest : clsForm
    {
        List<Tuple<int, int, int, int, string, int, int, Tuple<string> >> colorGrid = new List<Tuple<int, int, int, int, string, int, int, Tuple<string>>>();

        List<Tuple<int, int, int>> hourSets = new List<Tuple<int, int, int>>();

        List<Tuple<int, int, int, int, int>> breakTimes = new List<Tuple<int, int, int, int, int>>();

        List<Tuple<int, int, int>> trueCycleTimes = new List<Tuple<int, int, int>>();

        List<returnData> lstMaster = new List<returnData>();

        public int hourIdx = 0;
        public int intB1 = 0;
        public int intB1TotalMins = 0;
        public int intB2 = 0;
        public int intB2TotalMins = 0;
        public int lu = 0;
        public int intluTotalMins = 0;
        public string strLineSpecificStoredProc = "";
        public string strLineSpecificPctStoredProc = "";
        //public int TSID = 404;

        public frmFPYThreeHourTest()
        {
            InitializeComponent();
            
        }

        private void frmFPYThreeHourTest_Load(object sender, EventArgs e)
        {
            this.gvWholeTimeline.DoubleBuffered(true);
            this.gvHours.DoubleBuffered(true);
            this.gvTimeLine.DoubleBuffered(true);
            this.gvWorkOrder.DoubleBuffered(true);
            this.gvTrueCycle.DoubleBuffered(true);

        }

      

        private void frmFPYThreeHourTest_Shown(object sender, EventArgs e)
        {
            var dtNow = DateTime.Now.AddHours(0);
            var hour = dtNow.Hour;
            var min = dtNow.Minute;


            if (TSID == 404)
            {
                this.lblLine.Text = " Test Stand 404";
                strLineSpecificStoredProc = "p_FPYThreeHour404 " + hour.ToString() + ", " + TSID.ToString();
                strLineSpecificPctStoredProc = "p_tblLeakTestFPYPctsTestStands " + TSID.ToString();
            }
                
            

            if (TSID == 405)
            {
                this.lblLine.Text = "Test Stand 405";
                strLineSpecificStoredProc = "p_FPYThreeHour404 " + hour.ToString() + ", " + TSID.ToString();
                strLineSpecificPctStoredProc = "p_tblLeakTestFPYPctsTestStands " + TSID.ToString();
               
            }

            hourSets = HourSets();
            //int[] hours = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23 };

            
            

            foreach (var x in hourSets)
            {
                if (x.Item3 == hour)
                {
                    hourIdx = hourSets.FindLastIndex(t => t.Item2 == hour) + 1;  //Convert to 1 base index
                    break;
                }

                if (x.Item1 == hour )
                {
                    hourIdx = hourSets.FindLastIndex(t=> t.Item1 == hour) +1;  //Convert to 1 base index
                    break;
                }

                if(x.Item2 == hour)
                {
                    hourIdx = hourSets.FindLastIndex(t => t.Item2 == hour) +1;  //Convert to 1 base index
                    break;
                }

                
            }

            string strHour = (Convert.ToInt32(hour.ToString())).ToString(); //edit

            
                SetGrids(strHour);
                SetPcts();
                SetTimeLine(Convert.ToInt32(hour.ToString()), Convert.ToInt32(min.ToString()));


                timer1.Start();
                timer2.Start();
                
            splFPY24Header.SplitterDistance = (int)(splFPY24Header.ClientSize.Width * 0.50);
            splFPY24TargetActual.SplitterDistance = (int)(splFPY24TargetActual.ClientSize.Width * 0.50);
            splFPYCurrShift.SplitterDistance = (int)(splFPYCurrShift.ClientSize.Width * 0.50);
            splFPYTargetActual.SplitterDistance = (int)(splFPYTargetActual.ClientSize.Width * 0.50);

            lblLine.Left = (panel1.Width - lblLine.Size.Width) / 2;

        }


        public bool IsDivisible(int x, int n)
        {
            return (x % n) == 0;
        }

        private void SetThreeHour(int intHour)
        {

            

            for (int p = 0; p < 180; p++)
            {
                foreach (var g in colorGrid)
                {
                    if (g.Item1 == intHour)
                    {


                        Debug.Print(p.ToString() + ": " +intHour.ToString());

                        if (g.Item3 == 0)
                        {
                            gvWholeTimeline.Rows[0].Cells[g.Item2].Style.BackColor = Color.Firebrick;
                            //SetSpan(gvTrueCycle, g.Item3, 0, g.Item6 + 1, 0, "Middle");
                        }
                        if (g.Item3 == 1)
                        {
                            gvWholeTimeline.Rows[0].Cells[g.Item2].Style.BackColor = Color.MediumSeaGreen;
                            foreach(var ct in trueCycleTimes)
                            {
                                if(ct.Item1 == intHour && ct.Item2 == g.Item2)
                                {
                                    SetSpan(gvTrueCycle, ct.Item2, 0, ct.Item3, 0, "Middle");
                                    gvTrueCycle.Rows[0].Cells[g.Item2].Value = ct.Item3.ToString() + " min";
                                    gvTrueCycle.Rows[0].Cells[p].Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                                }
                            }
                        }

                            gvWorkOrder.Rows[0].Cells[g.Item7].Style.BackColor = Color.WhiteSmoke;
                            SetSpan(gvWorkOrder, g.Item7, 0, g.Item6+1, 0, "Middle");
                            gvWorkOrder.Rows[0].Cells[g.Item7].Value = g.Item5.ToString();
                            gvWorkOrder.Rows[0].Cells[p].Style.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Pixel);
                       

                    }

                    if (g.Item1 == intHour + 1)
                    {


                        Debug.Print((intHour + 1).ToString());

                        if (g.Item3 == 0)
                        {
                            gvWholeTimeline.Rows[0].Cells[g.Item2 + 60].Style.BackColor = Color.Firebrick;
                          
                        }
                        if (g.Item3 == 1)
                        {
                            gvWholeTimeline.Rows[0].Cells[g.Item2 + 60].Style.BackColor = Color.MediumSeaGreen;
                            foreach (var ct in trueCycleTimes)
                            {
                                if (ct.Item1 == intHour + 1 && ct.Item2 == g.Item2)
                                {
                                    SetSpan(gvTrueCycle, ct.Item2 + 60, 0, ct.Item3, 0, "Middle");
                                    gvTrueCycle.Rows[0].Cells[g.Item2 + 60].Value = ct.Item3.ToString() + " min";
                                    gvTrueCycle.Rows[0].Cells[p].Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                                }
                            }
                        }

                        
                            gvWorkOrder.Rows[0].Cells[g.Item7].Style.BackColor = Color.WhiteSmoke;
                            SetSpan(gvWorkOrder, g.Item7, 0, g.Item6+1, 0, "Middle");
                            gvWorkOrder.Rows[0].Cells[g.Item7].Value = g.Item5.ToString();
                            gvWorkOrder.Rows[0].Cells[p].Style.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Pixel);
                        

                    }

                    if (g.Item1 == intHour + 2)
                    {


                        Debug.Print((intHour + 2).ToString());

                        if (g.Item3 == 0)
                        {
                            gvWholeTimeline.Rows[0].Cells[g.Item2 + 120].Style.BackColor = Color.Firebrick;
                        }
                        if (g.Item3 == 1)
                        {
                            gvWholeTimeline.Rows[0].Cells[g.Item2 + 120].Style.BackColor = Color.MediumSeaGreen;
                            foreach (var ct in trueCycleTimes)
                            {
                                if (ct.Item1 == intHour + 2 && ct.Item2 == g.Item2)
                                {
                                    SetSpan(gvTrueCycle, ct.Item2 + 120, 0, ct.Item3, 0, "Middle");
                                    gvTrueCycle.Rows[0].Cells[g.Item2 + 120].Value = ct.Item3.ToString() + " min";
                                    gvTrueCycle.Rows[0].Cells[p].Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                                }
                            }
                        }

                        gvWorkOrder.Rows[0].Cells[g.Item7].Style.BackColor = Color.WhiteSmoke;
                        SetSpan(gvWorkOrder, g.Item7, 0, g.Item6+1, 0, "Middle");
                        gvWorkOrder.Rows[0].Cells[g.Item7].Value = g.Item5.ToString();
                        gvWorkOrder.Rows[0].Cells[p].Style.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Pixel);


                    }
                }


            }

            colorGrid.Clear();
            trueCycleTimes.Clear();

        }

        private void SetGrids(string strHour)
        {
            lblFocus.Focus();
            gvWholeTimeline.Columns.Clear();
            gvHours.Columns.Clear();
            gvTimeLine.Columns.Clear();
            gvWorkOrder.Columns.Clear();
            gvTrueCycle.Columns.Clear();

            

            int intHourSP = Convert.ToInt32(strHour);



            //string strSQL = "p_tblLeakTestFPYThreeHour " + intHourSP.ToString();
            string strSQL = strLineSpecificStoredProc; // + intHourSP.ToString() + ", " + TSID.ToString();
            DataSet ds = clsDAL.ProcessSQL(strSQL, "Visual");
            var leakTests = new TupleList4<int, int, int, int, string, int, int>();
            colorGrid.Clear();
            breakTimes.Clear();
            trueCycleTimes.Clear();

            returnData newList = new returnData();

            if (clsDAL.dsHasData(ds))
            {
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        int intHour = Convert.ToInt32(dr["hour"].ToString());
                        int intMinute = Convert.ToInt32(dr["minit"].ToString());
                        int intPassFail = Convert.ToInt32(dr["cntPass"].ToString());
                        int intGridCol = Convert.ToInt32(dr["GridCol"].ToString());
                        string strWO = dr["WorkOrder"].ToString();
                        int intColSpan = Convert.ToInt32(dr["WOGridSpan"].ToString());
                        int intBegWOCol = Convert.ToInt32(dr["WOGridStart"].ToString());
                        string strBegin = dr["Break1"].ToString();
                        leakTests.Add(intHour, intMinute, intPassFail, intGridCol, strWO, intColSpan, intBegWOCol);
                        colorGrid.Add(new Tuple<int, int, int, int, string, int, int, Tuple<string>>(intHour, intMinute, intPassFail, intGridCol, strWO, intColSpan, intBegWOCol, new Tuple<string>(strBegin)));

                        int intBreak1 = Convert.ToInt32(dr["Break1"].ToString());
                        int intLunch = Convert.ToInt32(dr["Lunch"].ToString());
                        int intBreak2 = Convert.ToInt32(dr["Break2"].ToString());
                        int intCycleTime = Convert.ToInt32(dr["TCycle"].ToString());

                        breakTimes.Add(new Tuple<int, int, int, int, int>(intHour, intMinute, intBreak1, intLunch, intBreak2));
                        trueCycleTimes.Add(new Tuple<int, int, int>(intHour, intMinute,intCycleTime ));
                    }
                }

                //lstMaster.Add(newList);
                
                


            }

            DataGridViewTextBoxColumnEx col3 = new DataGridViewTextBoxColumnEx();

            for (int z = 0; z < 180; z++)
            {
                DataGridViewTextBoxColumnEx col = new DataGridViewTextBoxColumnEx();
                DataGridViewTextBoxColumnEx col5 = new DataGridViewTextBoxColumnEx();
                DataGridViewTextBoxColumnEx col6 = new DataGridViewTextBoxColumnEx();
                DataGridViewTextBoxColumnEx col7 = new DataGridViewTextBoxColumnEx();

                gvWholeTimeline.RowHeadersVisible = false;
                gvWholeTimeline.ColumnHeadersVisible = false;
                gvWholeTimeline.ScrollBars = ScrollBars.None;
                gvWholeTimeline.CellBorderStyle = DataGridViewCellBorderStyle.None;
                gvWholeTimeline.BorderStyle = BorderStyle.None;
                gvWholeTimeline.DefaultCellStyle.BackColor = Color.White;


                gvWorkOrder.RowHeadersVisible = false;
                gvWorkOrder.ColumnHeadersVisible = false;
                gvWorkOrder.ScrollBars = ScrollBars.None;
                gvWorkOrder.CellBorderStyle = DataGridViewCellBorderStyle.None;
                gvWorkOrder.BorderStyle = BorderStyle.None;

                gvTimeLine.RowHeadersVisible = false;
                gvTimeLine.ColumnHeadersVisible = false;
                gvTimeLine.ScrollBars = ScrollBars.None;
                gvTimeLine.CellBorderStyle = DataGridViewCellBorderStyle.None;
                gvTimeLine.BorderStyle = BorderStyle.None;

                gvTrueCycle.RowHeadersVisible = false;
                gvTrueCycle.ColumnHeadersVisible = false;
                gvTrueCycle.ScrollBars = ScrollBars.None;
                gvTrueCycle.CellBorderStyle = DataGridViewCellBorderStyle.None;
                gvTrueCycle.BorderStyle = BorderStyle.None;


                col.FillWeight = 10;
                col.Width = 10;
                col.Name = z.ToString();

                col5.FillWeight = 10;
                col5.Width = 10;
                col5.Name = z.ToString();

                col6.FillWeight = 10;
                col6.Width = 10;
                col6.Name = z.ToString();

                col7.FillWeight = 10;
                col7.Width = 10;
                col7.Name = z.ToString();

                gvWholeTimeline.Columns.Add(col);
                gvWorkOrder.Columns.Add(col5);
                gvTimeLine.Columns.Add(col6);
                gvTrueCycle.Columns.Add(col7);

                //gvWholeTimeline.Rows[0].Cells[z].Value = z.ToString();
                gvWholeTimeline.Height = gvWholeTimeline.Rows[0].Height;
                gvWorkOrder.Height = gvWorkOrder.Rows[0].Height;
                gvTimeLine.Height = gvTimeLine.Rows[0].Height;
                gvTrueCycle.Height = gvTimeLine.Rows[0].Height;

                lblFocus.Focus();


                if (z % 15 == 0)
                {
                    gvWholeTimeline.Rows[0].Cells[z].Value = '\u25CF';
                    gvWholeTimeline.Rows[0].Cells[z].Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);

                    int[] hours = { 0, 60, 120, 180 };
                    if (hours.Contains(z))
                    {
                        gvWholeTimeline.Rows[0].Cells[z].Value = null;
                    }
                }



            }


            int setHour = 0;
            strHour = (Convert.ToInt32(strHour)-2 ).ToString();

            for (int z = 0; z <= 2; z++)
            {
                DataGridViewTextBoxColumnEx col2 = new DataGridViewTextBoxColumnEx();
                //col2.FillWeight = 10;
                col2.Width = 600;
                col2.Name = z.ToString();

                gvHours.RowHeadersVisible = false;
                gvHours.ColumnHeadersVisible = false;
                gvHours.ScrollBars = ScrollBars.None;
                gvHours.CellBorderStyle = DataGridViewCellBorderStyle.None;
                gvHours.BorderStyle = BorderStyle.None;
                gvHours.Columns.Add(col2);
                gvHours.Height = gvHours.Rows[0].Height;



                gvHours.Rows[0].Cells[z].Style.Font = new Font("Arial", 24F, FontStyle.Bold, GraphicsUnit.Pixel);

                SetBreaksFromTable(Convert.ToInt32(strHour));
               
                if (z == 0)
                {
                    //gvHours.Rows[0].Cells[z].Value = strHour;
                    gvHours.Rows[0].Cells[z].Value = TwelveHour(Convert.ToInt32(strHour));
                    setHour = Convert.ToInt32(strHour);

                    if(setHour == lu)
                    {
                        SetSpan(gvTimeLine, z, 0, intluTotalMins, 0, "Middle");
                        gvTimeLine.Rows[0].Cells[z].Value = "Lunch";
                        gvTimeLine.Rows[0].Cells[z].Style.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Pixel);
                        gvTimeLine.Rows[0].Cells[z].Style.BackColor = Color.LightSteelBlue;
                        gvTimeLine.Rows[0].Cells[z].Style.ForeColor = Color.Black;
                    }

                    if (setHour == intB1)
                    {
                        SetSpan(gvTimeLine, z, intB1TotalMins, 10, 0, "Middle");
                        gvTimeLine.Rows[0].Cells[z].Value = "Break";
                        gvTimeLine.Rows[0].Cells[z].Style.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Pixel);
                        gvTimeLine.Rows[0].Cells[z].Style.BackColor = Color.LightSteelBlue;
                        gvTimeLine.Rows[0].Cells[z].Style.ForeColor = Color.Black;
                    }

                    if (setHour == intB2)
                    {
                        SetSpan(gvTimeLine, z, 0, intB2TotalMins, 0, "Middle");
                        gvTimeLine.Rows[0].Cells[z].Value = "Break";
                        gvTimeLine.Rows[0].Cells[z].Style.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Pixel);
                        gvTimeLine.Rows[0].Cells[z].Style.BackColor = Color.LightSteelBlue;
                        gvTimeLine.Rows[0].Cells[z].Style.ForeColor = Color.Black;
                    }
                }

                if (z == 1)
                {
                  

                    setHour = setHour + 1;
                    //gvHours.Rows[0].Cells[z].Value = setHour.ToString();
                    gvHours.Rows[0].Cells[z].Value = TwelveHour(Convert.ToInt32(setHour));

                    if (setHour == 11)
                    {
                        SetSpan(gvTimeLine, 60, 0, intluTotalMins, 0, "Middle");
                        gvTimeLine.Rows[0].Cells[60].Value = "Lunch";
                        gvTimeLine.Rows[0].Cells[60].Style.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Pixel);
                        gvTimeLine.Rows[0].Cells[60].Style.BackColor = Color.LightSteelBlue;
                        gvTimeLine.Rows[0].Cells[60].Style.ForeColor = Color.Black;
                    }

                    if (setHour == 9)
                    {
                        SetSpan(gvTimeLine, 60, 0, intB1TotalMins, 0, "Middle");
                        gvTimeLine.Rows[0].Cells[60].Value = "Break";
                        gvTimeLine.Rows[0].Cells[60].Style.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Pixel);
                        gvTimeLine.Rows[0].Cells[60].Style.BackColor = Color.LightSteelBlue;
                        gvTimeLine.Rows[0].Cells[60].Style.ForeColor = Color.Black;
                    }

                    if (setHour == 13)
                    {
                        SetSpan(gvTimeLine, 60, 0, intB2TotalMins, 0, "Middle");
                        gvTimeLine.Rows[0].Cells[60].Value = "Break";
                        gvTimeLine.Rows[0].Cells[60].Style.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Pixel);
                        gvTimeLine.Rows[0].Cells[60].Style.BackColor = Color.LightSteelBlue;
                        gvTimeLine.Rows[0].Cells[60].Style.ForeColor = Color.Black;
                    }



                }

                if (z == 2)
                {
                  
                    setHour = setHour + 1;
                    //gvHours.Rows[0].Cells[z].Value = setHour.ToString();
                    gvHours.Rows[0].Cells[z].Value = TwelveHour(Convert.ToInt32(setHour));

                    if (setHour == 11)
                    {
                        SetSpan(gvTimeLine, 120, 0, intluTotalMins, 0, "Middle");
                        gvTimeLine.Rows[0].Cells[120].Value = "Lunch";
                        gvTimeLine.Rows[0].Cells[120].Style.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Pixel);
                        gvTimeLine.Rows[0].Cells[120].Style.BackColor = Color.LightSteelBlue;
                        gvTimeLine.Rows[0].Cells[120].Style.ForeColor = Color.Black;
                    }

                    if (setHour == 9)
                    {
                        SetSpan(gvTimeLine, 120, 0, intB1TotalMins, 0, "Middle");
                        gvTimeLine.Rows[0].Cells[120].Value = "Break";
                        gvTimeLine.Rows[0].Cells[120].Style.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Pixel);
                        gvTimeLine.Rows[0].Cells[120].Style.BackColor = Color.LightSteelBlue;
                        gvTimeLine.Rows[0].Cells[120].Style.ForeColor = Color.Black;
                    }

                    if (setHour == 13)
                    {
                        SetSpan(gvTimeLine, 120, 0, intB2TotalMins, 0, "Middle");
                        gvTimeLine.Rows[0].Cells[120].Value = "Break";
                        gvTimeLine.Rows[0].Cells[120].Style.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Pixel);
                        gvTimeLine.Rows[0].Cells[120].Style.BackColor = Color.LightSteelBlue;
                        gvTimeLine.Rows[0].Cells[120].Style.ForeColor = Color.Black;
                    }
                }


                if (z == 3)
                {
                    if (setHour == 11)
                    {
                        SetSpan(gvTimeLine, z, 0, intluTotalMins, 0, "Middle");
                        gvTimeLine.Rows[0].Cells[z].Value = "Lunch";
                        gvTimeLine.Rows[0].Cells[z].Style.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Pixel);
                        gvTimeLine.Rows[0].Cells[z].Style.BackColor = Color.LightSteelBlue;
                        gvTimeLine.Rows[0].Cells[z].Style.ForeColor = Color.Black;
                    }

                    setHour = setHour + 1;
                    gvHours.Rows[0].Cells[z].Value = setHour.ToString();
                }

                SetSpan(gvHours, z, 0, 60, 0, "Middle");
            }


            SetThreeHour(Convert.ToInt32(strHour));

            //int intShiftGrid = ((Convert.ToInt32(strHour) * 60) + 60) / 180;
            //gvWholeTimeline.FirstDisplayedScrollingColumnIndex = intShiftGrid;
            //gvWorkOrder.FirstDisplayedScrollingColumnIndex = intShiftGrid;
            //gvTimeLine.FirstDisplayedScrollingColumnIndex = intShiftGrid;

        }
        private void SetPcts()
        {
           

           
            try
            {
                //string strSQL = "p_tblLeakTestFPYPcts4";
                string strSQL = strLineSpecificPctStoredProc;
                string strFPY24Hour = "";
                string strFPYShift = "";
                string strNu24Hour = "";
                string strNuShift = "";
                int intFPYShiftTarget = 0;
                int intFPY24Target = 0;
                int intNuShiftTarget = 0;
                int intNu24Target = 0;

                DataSet ds = clsDAL.ProcessSQL(strSQL, "Visual");
                if (clsDAL.dsHasData(ds))
                {
                    DataTable dt = ds.Tables[0];
                    DataTable dt2 = ds.Tables[1];
                    DataTable dt3 = ds.Tables[2];
                    DataTable dt4 = ds.Tables[3];

                    strFPY24Hour = dt.Rows[0]["FPY"].ToString();
                    strFPYShift = dt2.Rows[0]["FPY"].ToString();
                    strNu24Hour = dt.Rows[0]["Nu"].ToString();
                    strNuShift = dt2.Rows[0]["Nu"].ToString();
                    intFPYShiftTarget = Convert.ToInt32(dt4.Rows[0]["FPYTS_ShiftTarget"].ToString());
                    intFPY24Target = Convert.ToInt32(dt4.Rows[0]["FPYTS_TwentyFourTarget"].ToString());
                    intNuShiftTarget = Convert.ToInt32(dt4.Rows[0]["Nu_ShiftTarget"].ToString());
                    intNu24Target = Convert.ToInt32(dt4.Rows[0]["Nu_TwentyFourTarget"].ToString());

                    //Set label on display to int values from dt4
                    lblFPYCurrShiftTarget.Text = intFPYShiftTarget.ToString() + "%";
                    lblFPY24Target.Text = intFPY24Target.ToString() + "%";
                    lblNUCurrTarget.Text = intNuShiftTarget.ToString() + "%";
                    lblNU24Target.Text = intNu24Target.ToString() + "%";


                    lblFPY24Actual.Text = strFPY24Hour + "%";
                    int intFPY24Actual = Convert.ToInt32(dt.Rows[0]["FPY"].ToString());

                    lblFPYCurrShift.Text = strFPYShift + "%";
                    int intFPYCurrShift = Convert.ToInt32(dt2.Rows[0]["FPY"].ToString());

                    lblNUCurrActual.Text = strNuShift + "%";
                    int intNUCurrShift = Convert.ToInt32(dt2.Rows[0]["Nu"].ToString());

                    lblNU24Actual.Text = strNu24Hour + "%";
                    int intNU24Actual = Convert.ToInt32(dt.Rows[0]["Nu"].ToString());

                    if (intFPY24Actual >= intFPY24Target)
                    {
                        lblFPY24Actual.BackColor = Color.MediumSeaGreen;
                        lblFPY24Actual.ForeColor = Color.WhiteSmoke;
                    }
                    else
                    {
                        lblFPY24Actual.BackColor = Color.Firebrick;
                        lblFPY24Actual.ForeColor = Color.WhiteSmoke;
                    }

                    if (intFPYCurrShift >= intFPYShiftTarget)
                    {
                        lblFPYCurrShift.BackColor = Color.MediumSeaGreen;
                        lblFPYCurrShift.ForeColor = Color.WhiteSmoke;
                    }
                    else
                    {
                        lblFPYCurrShift.BackColor = Color.Firebrick;
                        lblFPYCurrShift.ForeColor = Color.WhiteSmoke;
                    }

                    if (intNUCurrShift >= intNuShiftTarget)
                    {
                        lblNUCurrActual.BackColor = Color.MediumSeaGreen;
                        lblNUCurrActual.ForeColor = Color.WhiteSmoke;
                    }
                    else
                    {
                        lblNUCurrActual.BackColor = Color.Firebrick;
                        lblNUCurrActual.ForeColor = Color.WhiteSmoke;
                    }

                    if (intNU24Actual >= intNu24Target)
                    {
                        lblNU24Actual.BackColor = Color.MediumSeaGreen;
                        lblNU24Actual.ForeColor = Color.WhiteSmoke;
                    }
                    else
                    {
                        lblNU24Actual.BackColor = Color.Firebrick;
                        lblNU24Actual.ForeColor = Color.WhiteSmoke;
                    }

                    //lblBoltUpOperator.Text = "Bolt Up Operator: " + dt3.Rows[0]["LTCY_BoltUpTime"].ToString() + " min";
                    lblCycleTime.Text = "Cycle Time: " + dt3.Rows[0]["TSCY_Time"].ToString() + " min";
                    //lblHousingOperator.Text = "Housing Operator: " + dt3.Rows[0]["LTCY_HousingTime"].ToString() + " min";
                    //lblFlangeOperator.Text = "Flange Operator: " + dt3.Rows[0]["LTCY_FlangeTime"].ToString() + " min";
                    lblPartNo.Text = "Part Number: " + dt3.Rows[0]["TSCY_Part"].ToString();



                }
            }
            catch(Exception ex)
            {

            }
           
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
        ////private void btnScroll_Click(object sender, EventArgs e)
        //{
        //    gvWholeTimeline.FirstDisplayedScrollingColumnIndex = 361; // gvWholeTimeline.FirstDisplayedScrollingColumnIndex + 420;
        //    gvHours.FirstDisplayedScrollingColumnIndex = gvHours.FirstDisplayedScrollingColumnIndex + 6;
        //}

        private void gvFourHours_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string strHour = "";

            var dtNow = DateTime.Now;
            var hour = dtNow.Hour;
            var min = dtNow.Minute;
            //string strdt = dtNow.ToString("yyyy/MM/dd, HH:mm:ss");

            //strHour = dtNow.ToString("%h");

            
                SetGrids(hour.ToString());
                SetThreeHour(hour);
                SetTimeLine(Convert.ToInt32(hour.ToString()), Convert.ToInt32(min.ToString()));
                SetPcts();
           
            
            

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
                case (24):
                    return "12pm";
                    break;
            };
            return "";
        }
        private List<Tuple<int, int, int>> HourSets()
        {
            
            var lstHourSets = new List<Tuple<int, int, int>>();

            lstHourSets.Add(Tuple.Create(1,2,3));
            lstHourSets.Add(Tuple.Create(3,4,5));
            lstHourSets.Add(Tuple.Create(5,6,7));
            lstHourSets.Add(Tuple.Create(7,8,9));
            lstHourSets.Add(Tuple.Create(9,10,11));
            lstHourSets.Add(Tuple.Create(11,12,13));
            lstHourSets.Add(Tuple.Create(13,14,15));
            lstHourSets.Add(Tuple.Create(15,16,17));
            lstHourSets.Add(Tuple.Create(17,18,19));
            lstHourSets.Add(Tuple.Create(19,20,21));
            lstHourSets.Add(Tuple.Create(21,22,23));
            lstHourSets.Add(Tuple.Create(23,24,1));
            


            return lstHourSets;
        }

        private Tuple<int, int, int > SetBreaksFromTable(int intHour)
        {
            //add table reference for setHour to equal.  ex.  if setHour == intBreak1Hour, intLunchHour, intBreak2Hour
            int intShift = 0;
            if (intHour >= 7 && intHour <= 15)
            {
                intShift = 1;
            }
            string strSQLBreaks = "SELECT * FROM tblFPYBreaks WHERE FPY_Shift = " + intShift.ToString();
            Debug.Print(strSQLBreaks);

            DataSet dsBreaks = clsDAL.ProcessSQL(strSQLBreaks, "Visual");
            if (clsDAL.dsHasData(dsBreaks))
            {
                foreach (DataTable table in dsBreaks.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        if(dr["FPY_Desc"].ToString() == "Break1")
                        {
                            intB1 = Convert.ToInt32(dr["FPY_Hour"].ToString());
                            intB1TotalMins = Convert.ToInt32(dr["FPY_TotalMinutes"].ToString());
                        }

                        if (dr["FPY_Desc"].ToString() == "Break2")
                        {
                            intB2 = Convert.ToInt32(dr["FPY_Hour"].ToString());
                            intB2TotalMins = Convert.ToInt32(dr["FPY_TotalMinutes"].ToString());
                        }

                        if (dr["FPY_Desc"].ToString() == "Lunch")
                        {
                            lu = Convert.ToInt32(dr["FPY_Hour"].ToString());
                            intluTotalMins = Convert.ToInt32(dr["FPY_TotalMinutes"].ToString());
                        }

                    }
                }

            }



            return Tuple.Create(intB1, intB2, lu);



        }
        //private Tuple<int, int, int> SetBreaks(int intHour)
        //{
        //    int intbreak1 = 999;
        //    int intbreak2 = 999;
        //    int intlunch = 999;

        //    int intCurrHourOne = intHour - 2;
        //    int intCurrHourTwo = intHour-1;
        //    int intCurrHourThree = intHour;


        //    foreach (var hour in breakTimes)
        //    {
        //        //HourOne
        //        if (hour.Item1 == intCurrHourOne && hour.Item3 != 999)
        //        {
        //            intbreak1 = hour.Item3;
        //        }

        //        if (hour.Item1 == intCurrHourOne && hour.Item4 != 999)
        //        {
        //            intlunch = hour.Item4;
        //        }

        //        if (hour.Item1 == intCurrHourOne && hour.Item5 != 999)
        //        {
        //            intbreak2 = hour.Item5;
        //        }

        //        //HourTwo
        //        if (hour.Item1 == intCurrHourTwo && hour.Item3 != 999)
        //        {
        //            intbreak1 = hour.Item3;
        //        }

        //        if (hour.Item1 == intCurrHourTwo && hour.Item4 != 999)
        //        {
        //            intlunch = hour.Item4;
        //        }

        //        if (hour.Item1 == intCurrHourTwo && hour.Item5 != 999)
        //        {
        //            intbreak2 = hour.Item5;
        //        }

        //        //HourThree
        //        if (hour.Item1 == intCurrHourThree && hour.Item3 != 999)
        //        {
        //            intbreak1 = hour.Item3;
        //        }

        //        if (hour.Item1 == intCurrHourThree && hour.Item4 != 999)
        //        {
        //            intlunch = hour.Item4;
        //        }

        //        if (hour.Item1 == intCurrHourThree && hour.Item5 != 999)
        //        {
        //            intbreak2 = hour.Item5;
        //        }
        //    }

         

        //    return Tuple.Create(intbreak1,intlunch,intbreak2);
           
        //}
        private void SetTimeLine(int intHour, int intMin)
        {

            int intBreakHour1 = 0;
            int intBreakHour2 = 0;
            int intLunchHour = 0;

           
            //var result = SetBreaks(intHour);

 




            //intBreakHour1 = result.Item1;
            //intLunchHour = result.Item2;
            //intBreakHour2 = result.Item3;

            
            ////Move to SetGrids
            //for (int z = 0; z < 180; z++)
            //{
                
            //    if (z == intBreakHour1 || z == intBreakHour2)
            //    {
            //        SetSpan(gvTimeLine, z, 0, 10, 0, "Middle");
            //        gvTimeLine.Rows[0].Cells[z].Value = "Break";
            //        gvTimeLine.Rows[0].Cells[z].Style.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Pixel);
            //        gvTimeLine.Rows[0].Cells[z].Style.BackColor = Color.LightSteelBlue;
            //        gvTimeLine.Rows[0].Cells[z].Style.ForeColor = Color.Black;

            //    }

            //    if (z == intLunchHour)
            //    {
            //        SetSpan(gvTimeLine, z, 0, 20, 0, "Middle");
            //        gvTimeLine.Rows[0].Cells[z].Value = "Lunch";
            //        gvTimeLine.Rows[0].Cells[z].Style.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Pixel);
            //        gvTimeLine.Rows[0].Cells[z].Style.BackColor = Color.LightSteelBlue;
            //        gvTimeLine.Rows[0].Cells[z].Style.ForeColor = Color.Black;
            //    }

            //}

            //gvWholeTimeline.Rows[0].Cells[170].Style.BackColor = Color.Khaki;
            //gvWorkOrder.Rows[0].Cells[170].Style.BackColor = Color.Khaki;
            //gvTimeLine.Rows[0].Cells[170].Style.BackColor = Color.Khaki;

            foreach (var chooseHour in hourSets)
            {
                int intCurrentHour = DateTime.Now.Hour;

                //if (chooseHour.Item3 == intCurrentHour)
                //{
                //    gvWholeTimeline.Rows[0].Cells[intMin].Style.BackColor = Color.Khaki;
                //    //gvWholeTimeline.Rows[0].Cells[z + 1].Style.BackColor = Color.Khaki;
                //    gvWholeTimeline.Rows[0].Cells[intMin].Style.BackColor = Color.FromKnownColor(KnownColor.Window);

                //    gvWorkOrder.Rows[0].Cells[intMin].Style.BackColor = Color.Khaki;
                //    //gvWorkOrder.Rows[0].Cells[intMin+1].Style.BackColor = Color.Khaki;
                //    gvWorkOrder.Rows[0].Cells[intMin].Style.BackColor = Color.FromKnownColor(KnownColor.Window);

                //    gvTimeLine.Rows[0].Cells[intMin].Style.BackColor = Color.Khaki;
                //    //gvTimeLine.Rows[0].Cells[intMin + 1].Style.BackColor = Color.Khaki;
                //    gvTimeLine.Rows[0].Cells[intMin].Style.BackColor = Color.FromKnownColor(KnownColor.Window);
                //    return;
                //}

                //else if (chooseHour.Item2 == intCurrentHour)
                //{
                //    gvWholeTimeline.Rows[0].Cells[intMin + 60].Style.BackColor = Color.Khaki;
                //    //gvWholeTimeline.Rows[0].Cells[z + 1].Style.BackColor = Color.Khaki;
                //    gvWholeTimeline.Rows[0].Cells[intMin + 59].Style.BackColor = Color.FromKnownColor(KnownColor.Window);

                //    gvWorkOrder.Rows[0].Cells[intMin + 60].Style.BackColor = Color.Khaki;
                //    //gvWorkOrder.Rows[0].Cells[intMin+1].Style.BackColor = Color.Khaki;
                //    gvWorkOrder.Rows[0].Cells[intMin + 59].Style.BackColor = Color.FromKnownColor(KnownColor.Window);

                //    gvTimeLine.Rows[0].Cells[intMin + 60].Style.BackColor = Color.Khaki;
                //    //gvTimeLine.Rows[0].Cells[intMin + 1].Style.BackColor = Color.Khaki;
                //    gvTimeLine.Rows[0].Cells[intMin + 59].Style.BackColor = Color.FromKnownColor(KnownColor.Window);
                //    return;
                //}

                //else if (chooseHour.Item3 == intCurrentHour)
                //{
                    gvWholeTimeline.Rows[0].Cells[intMin + 120].Style.BackColor = Color.Khaki;
                    gvWholeTimeline.Rows[0].Cells[intMin + 119].Style.BackColor = Color.FromKnownColor(KnownColor.Window);
                    gvWholeTimeline.Rows[0].Cells[intMin + 118].Style.BackColor = Color.FromKnownColor(KnownColor.Window);

                    gvWorkOrder.Rows[0].Cells[intMin + 120].Style.BackColor = Color.Khaki;
                    gvWorkOrder.Rows[0].Cells[intMin + 119].Style.BackColor = Color.FromKnownColor(KnownColor.Window);
                    gvWorkOrder.Rows[0].Cells[intMin + 118].Style.BackColor = Color.FromKnownColor(KnownColor.Window);

                    gvTimeLine.Rows[0].Cells[intMin + 120].Style.BackColor = Color.Khaki;
                    gvTimeLine.Rows[0].Cells[intMin + 119].Style.BackColor = Color.FromKnownColor(KnownColor.Window);
                    gvTimeLine.Rows[0].Cells[intMin + 118].Style.BackColor = Color.FromKnownColor(KnownColor.Window);

                    gvTrueCycle.Rows[0].Cells[intMin + 120].Style.BackColor = Color.Khaki;
                    gvTrueCycle.Rows[0].Cells[intMin + 119].Style.BackColor = Color.FromKnownColor(KnownColor.Window);
                    gvTrueCycle.Rows[0].Cells[intMin + 118].Style.BackColor = Color.FromKnownColor(KnownColor.Window);

                return;
                //}
                //else
                //{

                //}
            }





        }
     

        
        private void timer2_Tick(object sender, EventArgs e)
        {
            var dtNow = DateTime.Now;
            var hour = dtNow.Hour;
            var min = dtNow.Minute;

            SetTimeLine(Convert.ToInt32(hour.ToString()), Convert.ToInt32(min.ToString()));
        }

    

     
        //private void btnPKU1_Click(object sender, EventArgs e)
        //{
            
        //}

        //private void btnPKU2_Click(object sender, EventArgs e)
        //{
            
        //}

        private void btn404_Click(object sender, EventArgs e)
        {
            TSID = 404;
            frmFPYThreeHourTest_Shown(btn404, EventArgs.Empty);
        }

        private void btn405_Click(object sender, EventArgs e)
        {
            TSID = 405;
            frmFPYThreeHourTest_Shown(btn405, EventArgs.Empty);
        }
    }

    //internal class List
    //{
    //}
}

//public class TupleList6<T1, T2, T3, T4, T5, T6, T7> : List<Tuple<T1, T2, T3, T4, T5, T6, T7>>
//{
    

//    public void Add(T1 item, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7)
//    {
//        Add(new Tuple<T1, T2, T3, T4, T5, T6, T7>(item, item2, item3, item4, item5, item6, item7));
//    }

    
//}

//class returnData
//{
//    public int Hour { get; set; }
//    public int Min { get; set; }

//    public int Break1 { get; set; }

//    public int Lunch { get; set; }

//    public int Break2 { get; set; }
//}





//public static class ExtensionMethods
//{
//    public static void DoubleBuffered(this DataGridView dgv, bool setting)
//    {
//        Type dgvType = dgv.GetType();
//        PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
//        pi.SetValue(dgv, setting, null);
//    }
//}
