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
using FPY;

namespace FPY
{
    public partial class frmFPY24Hour : clsForm
    {
        int intFWDClicked = 0;
        int intBackClicked = 0;
        List<Tuple<int, int, int, int>> trueCycleTimes = new List<Tuple<int, int, int, int>>();
        public string strLineSpecificStoredProc = "";
        public string strLineSpecificPctStoredProc = "";

        public frmFPY24Hour()
        {
            InitializeComponent();
        }

        private void frmFPY24Hour_Load(object sender, EventArgs e)
        {
            this.LNID = 1;
            this.gvWholeTimeline.DoubleBuffered(true);
            this.gvHours.DoubleBuffered(true);
            this.gvTimeLine.DoubleBuffered(true);
            this.gvWorkOrder.DoubleBuffered(true);
            this.gvTrueCycle.DoubleBuffered(true);

           
        }

      

        private void frmFPY24Hour_Shown(object sender, EventArgs e)
        {
            

            if (this.LNID == 1)
            {
                this.lblLine.Text = "PKU 1";
                strLineSpecificStoredProc = "p_tblLeakTestFPYPKU1 ";
                strLineSpecificPctStoredProc = "p_tblLeakTestFPY24PctsPKU1 ";
            }

            if (this.LNID == 2)
            {
                this.lblLine.Text = "PKU 2";
                strLineSpecificStoredProc = "p_tblLeakTestFPYPKU2 ";
                strLineSpecificPctStoredProc = "p_tblLeakTestFPY24PctsPKU2";

            }

            var dtNow = DateTime.Now;
            var xxx = dtNow.Hour;
            string strdt = dtNow.ToString("yyyy/MM/dd, HH:mm:ss");

            string strHour = (Convert.ToInt32(xxx.ToString()) - 4).ToString(); //edit

            //SetGrids(strHour);
            SetGrids("0");
            SetPcts();
            timer1.Start();
            timer2.Start();

        }


        public bool IsDivisible(int x, int n)
        {
            return (x % n) == 0;
        }
        private void SetPcts()
        {
            //string strSQL = "p_tblLeakTestFPYPcts2";
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
                DataTable dt4 = ds.Tables[3];

                strFPY24Hour = dt.Rows[0]["FPY"].ToString();
                strFPYShift = dt2.Rows[0]["FPY"].ToString();
                strNu24Hour = dt.Rows[0]["Nu"].ToString();
                strNuShift = dt2.Rows[0]["Nu"].ToString();
                intNuShiftTarget = Convert.ToInt32(dt4.Rows[0]["Nu_ShiftTarget"].ToString());
                intNu24Target = Convert.ToInt32(dt4.Rows[0]["Nu_TwentyFourTarget"].ToString());

                //Set label on display to int values from dt4
                lblFPYCurrShiftTarget.Text = intFPYShiftTarget.ToString() + "%";
                lblFPY24Target.Text = intFPY24Target.ToString() + "%";
                lblNUCurrTarget.Text = intNuShiftTarget.ToString() + "%";
                lblNU24Target.Text = intNu24Target.ToString() + "%";

                //lblFPY24Actual.Text = strFPY24Hour + "%";
                //int intFPY24Actual = Convert.ToInt32(dt.Rows[0]["FPY"].ToString());

                //lblFPYCurrShift.Text = strFPYShift + "%";
                //int intFPYCurrShift = Convert.ToInt32(dt2.Rows[0]["FPY"].ToString());

                //if (intFPY24Actual >= 75)
                //{
                //    lblFPY24Actual.BackColor = Color.MediumSeaGreen;
                //    lblFPY24Actual.ForeColor = Color.WhiteSmoke;
                //}
                //else
                //{
                //    lblFPY24Actual.BackColor = Color.Firebrick;
                //    lblFPY24Actual.ForeColor = Color.WhiteSmoke;
                //}

                //if(intFPYCurrShift >= 95)
                //{
                //    lblFPYCurrShift.BackColor = Color.MediumSeaGreen;
                //    lblFPYCurrShift.ForeColor = Color.WhiteSmoke;
                //}
                //else
                //{
                //    lblFPYCurrShift.BackColor = Color.Firebrick;
                //    lblFPYCurrShift.ForeColor = Color.WhiteSmoke;
                //}

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
            //string strHour = "";

            //var dtNow = DateTime.Now.AddHours(-4);
            //var xxx = dtNow.Hour;
            //string strdt = dtNow.ToString("yyyy/MM/dd, HH:mm:ss");

            //strHour = dtNow.ToString("%h");
            
            SetGrids("0");
            SetPcts();
            

        }

        private void SetTimeLine()
        {
            
            //var date = DateTime.Now;
            //var colorCurrentTime = ((date.Hour * 60) ) + date.Minute;

            //for (int z = 0; z < 1440; z++)
            //{
            //    if (z == colorCurrentTime)
            //    {
            //        gvWholeTimeline.Rows[0].Cells[z].Style.BackColor = Color.Khaki;
            //        gvWholeTimeline.Rows[0].Cells[z + 1].Style.BackColor = Color.Khaki;
            //        gvWholeTimeline.Rows[0].Cells[z - 1].Style.BackColor = Color.FromKnownColor(KnownColor.Window);

            //        gvWorkOrder.Rows[0].Cells[z].Style.BackColor = Color.Khaki;
            //        gvWorkOrder.Rows[0].Cells[z+1].Style.BackColor = Color.Khaki;
            //        gvWorkOrder.Rows[0].Cells[z - 1].Style.BackColor = Color.FromKnownColor(KnownColor.Window);

            //        gvTimeLine.Rows[0].Cells[z].Style.BackColor = Color.Khaki;
            //        gvTimeLine.Rows[0].Cells[z + 1].Style.BackColor = Color.Khaki;
            //        gvTimeLine.Rows[0].Cells[z - 1].Style.BackColor = Color.FromKnownColor(KnownColor.Window);
            //    }
            //}
               

         
        }
        private void SetGrids(string strHour)
        {
            lblFocus.Focus();
            gvWholeTimeline.Columns.Clear();
            gvHours.Columns.Clear();
            gvTimeLine.Columns.Clear();
            gvWorkOrder.Columns.Clear();
            gvTrueCycle.Columns.Clear();


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

                foreach(DataRow dr in dt1.Rows)
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

                    if (intPassFail == 1)
                    {
                        trueCycleTimes.Add(new Tuple<int, int, int, int>(intHour, intMinute, intCycleTime, intGridCol));
                    }

                    
                }

                foreach(DataRow dr in dt2.Rows)
                {
                    int intHour = Convert.ToInt32(dr["hour"].ToString());
                    int intMinute = Convert.ToInt32(dr["minit"].ToString());
                    int intDuration = Convert.ToInt32(dr["Duration"].ToString());
                    string strBreakType = dr["BreakType"].ToString();
                    int intBreakCol = Convert.ToInt32(dr["BreakCol"].ToString());
                    breakList.Add(intHour, intMinute, intDuration, strBreakType, intBreakCol);
                }

                //foreach (DataTable table in ds.Tables)
                //{
                //    foreach (DataRow dr in table.Rows)
                //    {
                //        int intHour = Convert.ToInt32(dr["hour"].ToString());
                //        int intMinute = Convert.ToInt32(dr["minit"].ToString());
                //        int intPassFail = Convert.ToInt32(dr["cntPass"].ToString());
                //        int intGridCol = Convert.ToInt32(dr["GridCol"].ToString());
                //        string strWO = dr["WorkOrder"].ToString();
                //        int intColSpan = Convert.ToInt32(dr["WOGridSpan"].ToString());
                //        int intBegWOCol = Convert.ToInt32(dr["WOGridStart"].ToString());
                //        leakTests.Add(intHour, intMinute, intPassFail, intGridCol, strWO, intColSpan, intBegWOCol);
                //    }
                //}

            }

            DataGridViewTextBoxColumnEx col3 = new DataGridViewTextBoxColumnEx();

            for (int z = 0; z < 1440; z++)
            {
                DataGridViewTextBoxColumnEx col = new DataGridViewTextBoxColumnEx();
                DataGridViewTextBoxColumnEx col5 = new DataGridViewTextBoxColumnEx();
                DataGridViewTextBoxColumnEx col6 = new DataGridViewTextBoxColumnEx();
                DataGridViewTextBoxColumnEx col7 = new DataGridViewTextBoxColumnEx();


                gvWholeTimeline.RowHeadersVisible = false;
                gvWholeTimeline.ColumnHeadersVisible = false;
                //gvWholeTimeline.ScrollBars = ScrollBars.None;
                gvWholeTimeline.CellBorderStyle = DataGridViewCellBorderStyle.None;
                gvWholeTimeline.BorderStyle = BorderStyle.None;

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

                gvWholeTimeline.Columns.Add(col);
                gvWorkOrder.Columns.Add(col5);
                gvTimeLine.Columns.Add(col6);
                gvTrueCycle.Columns.Add(col7);


                gvWholeTimeline.Height = gvWholeTimeline.Rows[0].Height +20;
                gvWorkOrder.Height = gvWorkOrder.Rows[0].Height;
                gvTimeLine.Height = gvTimeLine.Rows[0].Height;
                gvTrueCycle.Height = gvTimeLine.Rows[0].Height + 10;

                lblFocus.Focus();
            }


            int setHour = 0;
            for (int z = 0; z <= 60; z++)
            {
                DataGridViewTextBoxColumnEx col2 = new DataGridViewTextBoxColumnEx();
                //col2.FillWeight = 10;
                col2.Width = 300;
                col2.Name = z.ToString();

                gvHours.RowHeadersVisible = false;
                gvHours.ColumnHeadersVisible = false;
                gvHours.ScrollBars = ScrollBars.None;
                gvHours.CellBorderStyle = DataGridViewCellBorderStyle.None;
                gvHours.BorderStyle = BorderStyle.None;
                gvHours.Columns.Add(col2);
                gvHours.Height = gvHours.Rows[0].Height;



                //strHour = dtNow.ToString("%h");

                gvHours.Rows[0].Cells[z].Style.Font = new Font("Arial", 24F, FontStyle.Bold, GraphicsUnit.Pixel);
                

                if (z == 0)
                {
                    //gvHours.Rows[0].Cells[z].Value = strHour;
                    gvHours.Rows[0].Cells[z].Value = TwelveHour(Convert.ToInt32(strHour));
                    setHour = Convert.ToInt32(strHour);
                }
                else
                {
                    setHour = setHour + 1;
                    //gvHours.Rows[0].Cells[z].Value = setHour.ToString();
                    gvHours.Rows[0].Cells[z].Value = TwelveHour(setHour);
                }

            }


            for (int z = 0; z < 1440; z++)
            {
                foreach (var x in leakTests)
                {
                    int [] ticks = {720,735,750,765,780,795, 810, 825,840, 855, 870,885 };

                    foreach (var ct in trueCycleTimes)
                    {
                        if (ct.Item4 == z)
                        {
                            SetSpan(gvTrueCycle, ct.Item4, 0, ct.Item3, 0, "Middle");
                            gvTrueCycle.Rows[0].Cells[ct.Item4].Value = ct.Item3.ToString() + " min";
                            gvTrueCycle.Rows[0].Cells[ct.Item4].Style.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Pixel);
                        }
                    }


                    if (z%15 == 0)
                    {
                        gvWholeTimeline.Rows[0].Cells[z].Value = "*";
                        gvWholeTimeline.Rows[0].Cells[z].Style.Font = new Font("Arial", 8F, FontStyle.Bold, GraphicsUnit.Pixel);

                        int[] hours = { 0, 60, 120, 180,240,300,360,420,480,540,600,660,720,780,840,900,960,1020,1080,1140,1200,1260,1320,1380,1440 };

                        if (hours.Contains(z))
                        {
                            gvWholeTimeline.Rows[0].Cells[z].Value = null;
                        }
                    }


                    if (x.Item4 == z)
                    {
                        if (x.Item3 == 0)
                        {
                            gvWholeTimeline.Rows[0].Cells[x.Item4].Style.BackColor = Color.Firebrick;
                        }
                        if (x.Item3 == 1)
                        {
                            gvWholeTimeline.Rows[0].Cells[x.Item4].Style.BackColor = Color.MediumSeaGreen;
                            
                        }

                    }

                   
                    if(x.Item7 == z)
                    {
                        gvWorkOrder.Rows[0].Cells[x.Item7].Style.BackColor = Color.WhiteSmoke;

                        if(x.Item6 == 0)
                        {
                            gvWorkOrder.Rows[0].Cells[20].Style.BackColor = Color.WhiteSmoke;
                            SetSpan(gvWorkOrder, x.Item7, 0, 20, 0, "Middle");
                            gvWorkOrder.Rows[0].Cells[x.Item7].Value = x.Item5.ToString();
                            gvWorkOrder.Rows[0].Cells[z].Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                        }
                        else
                        {
                            for (int colSpan = 1; colSpan <= x.Item6; colSpan++)
                            {
                                gvWorkOrder.Rows[0].Cells[x.Item7 + colSpan].Style.BackColor = Color.WhiteSmoke;
                            }

                            SetSpan(gvWorkOrder, x.Item7, 0, x.Item6, 0, "Middle");
                            gvWorkOrder.Rows[0].Cells[x.Item7].Value = x.Item5.ToString();
                            gvWorkOrder.Rows[0].Cells[z].Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);

                        }

                       

                    }

                   
                }


                var date = DateTime.Now;
                var colorCurrentTime = ((date.Hour * 60) ) + date.Minute;
                if (z == colorCurrentTime)
                {
                    gvWholeTimeline.Rows[0].Cells[z].Style.BackColor = Color.Khaki;
                    gvWholeTimeline.Rows[0].Cells[z + 1].Style.BackColor = Color.Khaki;
                    gvWholeTimeline.Rows[0].Cells[z - 1].Style.BackColor = Color.FromKnownColor(KnownColor.Window);

                    gvWorkOrder.Rows[0].Cells[z].Style.BackColor = Color.Khaki;
                    gvWorkOrder.Rows[0].Cells[z + 1].Style.BackColor = Color.Khaki;
                    gvWorkOrder.Rows[0].Cells[z - 1].Style.BackColor = Color.FromKnownColor(KnownColor.Window);

                    gvTimeLine.Rows[0].Cells[z].Style.BackColor = Color.Khaki;
                    gvTimeLine.Rows[0].Cells[z + 1].Style.BackColor = Color.Khaki;
                    gvTimeLine.Rows[0].Cells[z - 1].Style.BackColor = Color.FromKnownColor(KnownColor.Window);
                }
                ////test color 60 minutes
                //if (z >= 900 && z <= 959)
                //{
                //    gvWholeTimeline.Rows[0].Cells[z].Style.BackColor = Color.Khaki;
                //    gvWholeTimeline.Rows[0].Cells[z].Value = "$";
                //}
                //if (z >= 960 && z <= 1019)
                //{
                //    gvWholeTimeline.Rows[0].Cells[z].Style.BackColor = Color.LightCoral;
                //    gvWholeTimeline.Rows[0].Cells[z].Value = "$";
                //}

               
                foreach(var col in breakList)
                {
                    if(col.Item5 == z && col.Item4.Contains("Break"))
                    {
                        SetSpan(gvTimeLine, z, 0, col.Item3, 0, "Middle");
                        gvTimeLine.Rows[0].Cells[z].Value = "Break";
                        gvTimeLine.Rows[0].Cells[z].Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                        gvTimeLine.Rows[0].Cells[z].Style.BackColor = Color.LightSteelBlue;
                        gvTimeLine.Rows[0].Cells[z].Style.ForeColor = Color.Black;
                    }

                    if (col.Item5 == z && col.Item4.Contains("Lunch"))
                    {
                        SetSpan(gvTimeLine, z, 0, col.Item3, 0, "Middle");
                        gvTimeLine.Rows[0].Cells[z].Value = "Lunch";
                        gvTimeLine.Rows[0].Cells[z].Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                        gvTimeLine.Rows[0].Cells[z].Style.BackColor = Color.LightSteelBlue;
                        gvTimeLine.Rows[0].Cells[z].Style.ForeColor = Color.Black;
                    }
                }

                //if (z == 600 || z ==840)
                //{
                //    SetSpan(gvTimeLine, z, 0, 10, 0, "Middle");
                //    gvTimeLine.Rows[0].Cells[z].Value = "Break";
                //    gvTimeLine.Rows[0].Cells[z].Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                //    gvTimeLine.Rows[0].Cells[z].Style.BackColor = Color.LightSteelBlue;
                //    gvTimeLine.Rows[0].Cells[z].Style.ForeColor = Color.Black;

                //}

                //if (z == 720)
                //{
                //    SetSpan(gvTimeLine, z, 0, 20, 0, "Middle");
                //    gvTimeLine.Rows[0].Cells[z].Value = "Lunch";
                //    gvTimeLine.Rows[0].Cells[z].Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                //    gvTimeLine.Rows[0].Cells[z].Style.BackColor = Color.LightSteelBlue;
                //    gvTimeLine.Rows[0].Cells[z].Style.ForeColor = Color.Black;
                //}

              

            }

            //int intShiftGrid = (Convert.ToInt32(strHour) * 60) + 60;
            //gvWholeTimeline.FirstDisplayedScrollingColumnIndex = intShiftGrid;
            //gvWorkOrder.FirstDisplayedScrollingColumnIndex = intShiftGrid;
            //gvTimeLine.FirstDisplayedScrollingColumnIndex = intShiftGrid;

        }

      
        private void timer2_Tick(object sender, EventArgs e)
        {
            SetTimeLine();
        }

        private void ManageClicks(string strSender)
        {

            if(strSender == "btnFwd")
            {
                intFWDClicked = intFWDClicked + 1;
            }
            if(strSender == "btnBack")
            {
                intBackClicked = intBackClicked + 1;
            }
            

        }
       
        

        private void btnFwd_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
          

            int intFWDColumns = 360;
            int intFWDHours = 6;

            if(gvWholeTimeline.FirstDisplayedScrollingColumnIndex + intFWDColumns > 1430)
            {
                MessageBox.Show("End of range to view.");
                return;
            }


            gvWholeTimeline.FirstDisplayedScrollingColumnIndex = gvWholeTimeline.FirstDisplayedScrollingColumnIndex + intFWDColumns;
            gvTimeLine.FirstDisplayedScrollingColumnIndex = gvTimeLine.FirstDisplayedScrollingColumnIndex + intFWDColumns;
            gvWorkOrder.FirstDisplayedScrollingColumnIndex = gvWorkOrder.FirstDisplayedScrollingColumnIndex + intFWDColumns;
            gvHours.FirstDisplayedScrollingColumnIndex = gvHours.FirstDisplayedScrollingColumnIndex + intFWDHours;
            gvTrueCycle.FirstDisplayedScrollingColumnIndex = gvTrueCycle.FirstDisplayedScrollingColumnIndex + intFWDColumns;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();

            int intBackColumns = 360;
            int intBackHours = 6;

            if (gvWholeTimeline.FirstDisplayedScrollingColumnIndex - intBackColumns < -6)
            {
                MessageBox.Show("End of range to view.");
                return;
            }

            if (gvWholeTimeline.FirstDisplayedScrollingColumnIndex < 360)
            {
                gvWholeTimeline.FirstDisplayedScrollingColumnIndex = 0;
                gvWorkOrder.FirstDisplayedScrollingColumnIndex = 0;
                gvHours.FirstDisplayedScrollingColumnIndex = 0;
                gvTrueCycle.FirstDisplayedScrollingColumnIndex = 0;
                //frmFPY24Hour_Shown(btnPKU1, EventArgs.Empty);  refactor how data is pulled and this might be the way:  <= 360
            }
            else
            {
                gvWholeTimeline.FirstDisplayedScrollingColumnIndex = gvWholeTimeline.FirstDisplayedScrollingColumnIndex - intBackColumns;
                gvTimeLine.FirstDisplayedScrollingColumnIndex = gvTimeLine.FirstDisplayedScrollingColumnIndex - intBackColumns;
                gvWorkOrder.FirstDisplayedScrollingColumnIndex = gvWorkOrder.FirstDisplayedScrollingColumnIndex - intBackColumns;
                gvHours.FirstDisplayedScrollingColumnIndex = gvHours.FirstDisplayedScrollingColumnIndex - intBackHours;
                gvTrueCycle.FirstDisplayedScrollingColumnIndex = gvTrueCycle.FirstDisplayedScrollingColumnIndex - intBackColumns;
            }

        }

        private void btnPKU1_Click(object sender, EventArgs e)
        {
            this.LNID = 1;
            trueCycleTimes.Clear();
            frmFPY24Hour_Shown(btnPKU1, EventArgs.Empty);
        }

        private void btnPKU2_Click(object sender, EventArgs e)
        {
            this.LNID = 2;
            trueCycleTimes.Clear();
            frmFPY24Hour_Shown(btnPKU2, EventArgs.Empty);
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
    }
}

public class TupleWO<T1, T2, T3> : List<Tuple<T1, T2, T3>>
{
    public void Add(T1 item, T2 item2, T3 item3)
    {
        Add(new Tuple<T1, T2, T3>(item, item2, item3));
    }
}


public class TupleListBreaks<T1, T2, T3, T4, T5> : List<Tuple<T1, T2, T3, T4, T5>>
{
    public void Add(T1 item, T2 item2, T3 item3, T4 item4, T5 item5)
    {
        Add(new Tuple<T1, T2, T3, T4, T5>(item, item2, item3, item4, item5));
    }
}

//public static class ExtensionMethods
//{
//    public static void DoubleBuffered(this DataGridView dgv, bool setting)
//    {
//        Type dgvType = dgv.GetType();
//        PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
//        pi.SetValue(dgv, setting, null);
//    }
//}
