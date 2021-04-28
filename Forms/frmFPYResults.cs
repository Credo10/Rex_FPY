using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Visual;
using HRLData;
using RexrothData;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;

namespace FPY
{
    public partial class frmFPYResults : clsForm
    {
        HRLEntities db = clsStart.efdb();
        RexrothEntities dbRexroth = clsStart.efdbRexroth();
        VisualEntities dbVisual = clsStart.efdbVisual();

        public System.Windows.Forms.DataVisualization.Charting.SeriesCollection Series { get; }

        public frmFPYResults()
        {
            InitializeComponent();
        }

        private void frmFPYResults_Shown(object sender, EventArgs e)
        {
            lblKPI.Left = (this.pnlTop.Width - lblKPI.Width) / 2;
            lblKPI.Top = (this.pnlTop.Height - lblKPI.Height) / 2;


            string strWeekOf = DateTime.Now.ToShortDateString();
            ShowGraphs(strWeekOf);
        }

        void tlpGraphs_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            //for (int x = 0; x <= 4; x++)
            //{
            //    if (e.Column == x && e.Row == 1)
            //        e.Graphics.DrawRectangle(new Pen(Color.Black), e.CellBounds);
            //}
                
        }
        private void ShowGraphs(string strWeekOf)
        {
            string strSQL = "p_tblFPYChartResults '" + strWeekOf + "'";
            Debug.Print(strSQL);

            DataSet dsFPY = clsDAL.ProcessSQL(strSQL, "Visual");
            DataTable dtFPY;

            if (clsDAL.dsHasData(dsFPY))
            {
                dtFPY = dsFPY.Tables[0];

            }

            //PKU1
            chtFPYLTPKU1.DataSource = dsFPY.Tables[0];
            this.chtFPYLTPKU1.Series[0].XValueMember = "TruncatedDate";
            this.chtFPYLTPKU1.Series[0].YValueMembers = "FPY";
            this.chtFPYLTPKU1.DataBind();

            chtNuLTPKU1.DataSource = dsFPY.Tables[0];
            this.chtNuLTPKU1.Series[0].XValueMember = "TruncatedDate";
            this.chtNuLTPKU1.Series[0].YValueMembers = "Nu";
            this.chtNuLTPKU1.DataBind();


            //PKU2
            chtFPYLTPKU2.DataSource = dsFPY.Tables[1];
            this.chtFPYLTPKU2.Series[0].XValueMember = "TruncatedDate";
            this.chtFPYLTPKU2.Series[0].YValueMembers = "FPY";
            this.chtFPYLTPKU2.DataBind();

            chtNuLTPKU2.DataSource = dsFPY.Tables[1];
            this.chtNuLTPKU2.Series[0].XValueMember = "TruncatedDate";
            this.chtNuLTPKU2.Series[0].YValueMembers = "Nu";
            this.chtNuLTPKU2.DataBind();


            //this.chtFPYLTPKU1.ChartAreas[0].AxisX.MinorTickMark.Enabled = true;
            //this.chtFPYLTPKU1.ChartAreas[0].AxisX.Interval = 1;
            //this.chtFPYLTPKU1.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font(this.Font.Name, 12, FontStyle.Bold);
            //this.chtFPYLTPKU1.ChartAreas[0].AxisX.LabelStyle.Angle = -45;

            //this.chtFPYLTPKU2.ChartAreas[0].AxisX.MinorTickMark.Enabled = true;
            //this.chtFPYLTPKU2.ChartAreas[0].AxisX.Interval = 1;
            //this.chtFPYLTPKU2.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font(this.Font.Name, 12, FontStyle.Bold);
            //this.chtFPYLTPKU2.ChartAreas[0].AxisX.LabelStyle.Angle = -45;



            int intCTR = chtFPYLTPKU1.Series[0].Points.Count;
            int intCTR2 = chtFPYLTPKU2.Series[0].Points.Count;

            try
            {
                for (int z = 0; z <= intCTR; z++)
                {
                    if (Convert.ToInt32(chtFPYLTPKU1.Series[0].Points[z].YValues[0].ToString()) < 95)
                    {
                        chtFPYLTPKU1.Series["FPYPKU1"].Points[z].Color = Color.Firebrick;
                    }
                    else
                    {
                        chtFPYLTPKU1.Series["FPYPKU1"].Points[z].Color = Color.MediumSeaGreen;
                    }

                    if (Convert.ToInt32(chtNuLTPKU1.Series[0].Points[z].YValues[0].ToString()) < 80)
                    {
                        chtNuLTPKU1.Series["NUPKU1"].Points[z].Color = Color.Firebrick;
                    }
                    else
                    {
                        chtNuLTPKU1.Series["NUPKU1"].Points[z].Color = Color.MediumSeaGreen;
                    }

                }



            }
            catch (Exception ex)
            {

            }

            try
            {
                for (int x = 0; x <= intCTR2; x++)
                {
                    if (Convert.ToInt32(chtFPYLTPKU2.Series[0].Points[x].YValues[0].ToString()) < 95)
                    {
                        chtFPYLTPKU2.Series["FPYPKU2"].Points[x].Color = Color.Firebrick;
                    }
                    else
                    {
                        chtFPYLTPKU2.Series["FPYPKU2"].Points[x].Color = Color.MediumSeaGreen;
                    }

                    if (Convert.ToInt32(chtNuLTPKU2.Series[0].Points[x].YValues[0].ToString()) < 80)
                    {
                        chtNuLTPKU2.Series["NUPKU2"].Points[x].Color = Color.Firebrick;
                    }
                    else
                    {
                        chtNuLTPKU2.Series["NUPKU2"].Points[x].Color = Color.MediumSeaGreen;
                    }

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void ShowGraphsMonthly()
        {
            string strSQL = "p_tblFPYChartResultsMonthly ";
            Debug.Print(strSQL);

            DataSet dsFPY = clsDAL.ProcessSQL(strSQL, "Visual");
            DataTable dtFPY;

            if (clsDAL.dsHasData(dsFPY))
            {
                dtFPY = dsFPY.Tables[0];

            }

            //PKU1
            chtFPYLTPKU1.DataSource = dsFPY.Tables[0];
            this.chtFPYLTPKU1.Series[0].XValueMember = "MonthName";
            this.chtFPYLTPKU1.Series[0].YValueMembers = "FPY";
            //this.chtFPYLTPKU1.Series[0].Font = new System.Drawing.Font("arial", 8f, FontStyle.Bold);
            this.chtFPYLTPKU1.DataBind();

            chtNuLTPKU1.DataSource = dsFPY.Tables[0];
            this.chtNuLTPKU1.Series[0].XValueMember = "MonthName";
            this.chtNuLTPKU1.Series[0].YValueMembers = "Nu";
            //this.chtNuLTPKU1.Series[0].Font = new System.Drawing.Font("arial", 8f, FontStyle.Bold);
            this.chtNuLTPKU1.DataBind();


            //PKU2
            chtFPYLTPKU2.DataSource = dsFPY.Tables[1];
            this.chtFPYLTPKU2.Series[0].XValueMember = "MonthName";
            this.chtFPYLTPKU2.Series[0].YValueMembers = "FPY";
            this.chtFPYLTPKU2.DataBind();

            chtNuLTPKU2.DataSource = dsFPY.Tables[1];
            this.chtNuLTPKU2.Series[0].XValueMember = "MonthName";
            this.chtNuLTPKU2.Series[0].YValueMembers = "Nu";
            this.chtNuLTPKU2.DataBind();


            this.chtFPYLTPKU1.ChartAreas[0].AxisX.MinorTickMark.Enabled = true;
            this.chtFPYLTPKU1.ChartAreas[0].AxisX.Interval = 1;
            this.chtFPYLTPKU1.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font(this.Font.Name, 8, FontStyle.Regular);
            this.chtFPYLTPKU1.ChartAreas[0].AxisX.LabelStyle.Angle = -45;

            this.chtNuLTPKU1.ChartAreas[0].AxisX.MinorTickMark.Enabled = true;
            this.chtNuLTPKU1.ChartAreas[0].AxisX.Interval = 1;
            this.chtNuLTPKU1.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font(this.Font.Name, 8, FontStyle.Regular);
            this.chtNuLTPKU1.ChartAreas[0].AxisX.LabelStyle.Angle = -45;

            this.chtFPYLTPKU2.ChartAreas[0].AxisX.MinorTickMark.Enabled = true;
            this.chtFPYLTPKU2.ChartAreas[0].AxisX.Interval = 1;
            this.chtFPYLTPKU2.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font(this.Font.Name, 8, FontStyle.Regular);
            this.chtFPYLTPKU2.ChartAreas[0].AxisX.LabelStyle.Angle = -45;

            this.chtNuLTPKU2.ChartAreas[0].AxisX.MinorTickMark.Enabled = true;
            this.chtNuLTPKU2.ChartAreas[0].AxisX.Interval = 1;
            this.chtNuLTPKU2.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font(this.Font.Name, 8, FontStyle.Regular);
            this.chtNuLTPKU2.ChartAreas[0].AxisX.LabelStyle.Angle = -45;



            int intCTR = chtFPYLTPKU1.Series[0].Points.Count;
            int intCTR2 = chtFPYLTPKU2.Series[0].Points.Count;

            try
            {
                for (int z = 0; z <= intCTR; z++)
                {
                    if (Convert.ToInt32(chtFPYLTPKU1.Series[0].Points[z].YValues[0].ToString()) < 95)
                    {
                        chtFPYLTPKU1.Series["FPYPKU1"].Points[z].Color = Color.Firebrick;
                    }
                    else
                    {
                        chtFPYLTPKU1.Series["FPYPKU1"].Points[z].Color = Color.MediumSeaGreen;
                    }

                    if (Convert.ToInt32(chtNuLTPKU1.Series[0].Points[z].YValues[0].ToString()) < 80)
                    {
                        chtNuLTPKU1.Series["NUPKU1"].Points[z].Color = Color.Firebrick;
                    }
                    else
                    {
                        chtNuLTPKU1.Series["NUPKU1"].Points[z].Color = Color.MediumSeaGreen;
                    }

                }



            }
            catch (Exception ex)
            {

            }

            try
            {
                for (int x = 0; x <= intCTR2; x++)
                {
                    if (Convert.ToInt32(chtFPYLTPKU2.Series[0].Points[x].YValues[0].ToString()) < 95)
                    {
                        chtFPYLTPKU2.Series["FPYPKU2"].Points[x].Color = Color.Firebrick;
                    }
                    else
                    {
                        chtFPYLTPKU2.Series["FPYPKU2"].Points[x].Color = Color.MediumSeaGreen;
                    }

                    if (Convert.ToInt32(chtNuLTPKU2.Series[0].Points[x].YValues[0].ToString()) < 80)
                    {
                        chtNuLTPKU2.Series["NUPKU2"].Points[x].Color = Color.Firebrick;
                    }
                    else
                    {
                        chtNuLTPKU2.Series["NUPKU2"].Points[x].Color = Color.MediumSeaGreen;
                    }

                }
            }
            catch (Exception ex)
            {

            }
        }
        private void dtWeekOf_CloseUp(object sender, EventArgs e)
        {
            string strWeekOf = dtWeekOf.Value.ToShortDateString();
            ShowGraphs(strWeekOf);
        }

        //private void chkMonthly_CheckedChanged(object sender, EventArgs e)
        //{
         
        //}

        //private void chkWeekly_CheckedChanged(object sender, EventArgs e)
        //{
          
        //}

        private void chkMonthly_Click(object sender, EventArgs e)
        {
            if (this.chkWeekly.CheckState == CheckState.Checked)
            {
                this.chkWeekly.CheckState = CheckState.Unchecked;
                this.chkMonthly.CheckState = CheckState.Checked;
            }

            ShowGraphsMonthly();
        }

        private void chkWeekly_Click(object sender, EventArgs e)
        {
            if (this.chkMonthly.CheckState == CheckState.Checked)
            {
                this.chkMonthly.CheckState = CheckState.Unchecked;
                this.chkWeekly.CheckState = CheckState.Checked;
            }

            string strWeekOf = dtWeekOf.Value.ToShortDateString();
            ShowGraphs(strWeekOf);
        }
    }
}
