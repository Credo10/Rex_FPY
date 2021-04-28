using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using RexrothData;
using HRLData;

namespace FPY
{
    public partial class frmSQLText : clsForm
    {

 

        public frmSQLText(DataGridViewCell cell)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.cell = cell;
            //this.FormBorderStyle = FormBorderStyle.None;

        }


        RexrothEntities dbRexroth = clsStart.efdbRexroth();
        HRLEntities db = clsStart.efdb();
        private DataGridViewCell cell;

        bool fSave = true;

        private void frmSQLText_Load(object sender, EventArgs e)
        {

            try
            {
                this.txtSQL.Text = this.cell.Value.ToString();
                BindGrid();
            }
            catch (Exception)
            {

            }
          
        }
       

        private void lnkCancel_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fSave = false;
            this.Close();
        }

        private void lnkAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
            this.Close();
        }

        private void frmSQLText_FormClosing(object sender, FormClosingEventArgs e)
        {
            Save();
        }

        private void Save()
        {
            if (fSave == true)
            {
                try
                {

                    var q = (from ct in db.tblAppDropDown
                             where ct.DDID == this.ECID
                             select ct).First();

                    q.DD_SQL = this.txtSQL.Text;
                    db.SaveChanges();

                    this.cell.Value = this.txtSQL.Text.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                } 
            }

          
        }

        private void BindGridDataGV1(DataTable result, DataGridView gv)
        {
            
            if (!(gv.Columns.Count > 0))
            {
                gv.Columns.Clear();
                gv.AutoGenerateColumns = false;
                gv.AllowUserToAddRows = false;
                gv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;


                try
                {

                    List<HRLData.tblAppColumns> properties = (from Visible in db.tblAppColumns
                                                                 where Visible.NAVID == 399
                                                                       && Visible.APC_Grid == gv.Name
                                                                 orderby Visible.APC_Order
                                                                 select Visible).ToList<HRLData.tblAppColumns>();

                    foreach (var property in properties)
                    {

                        clsGridUtil.AddColumns(gv, 399, property, db, this.APPID, this.APPID,
                            this.Associate.ASID);

                    }

                }
                catch (Exception ex)
                {

                }
                
            }

            try
            {
                gv.DataSource = null; gv.DataSource = result;
 
if(Associate.ARID == 104)
                {
                    gv.ReadOnly = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.AppName);
                return;
            }


        }

        private void BindGrid()
        {
            try
            {
                string strSQL = this.txtSQL.Text;

                DataSet ds = clsDAL.ProcessSQL(strSQL, "HRL");

                DataTable dt = ds.Tables[0];

                dt.Columns[0].ColumnName = "ID";
                dt.Columns[1].ColumnName = "Display";

                BindGridDataGV1(dt, gv1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private void lnkExecute_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BindGrid();
            

        }
    }
}
