using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RexrothData;
using HRLData;

namespace FPY
{
    public partial class frmAddUser : clsForm
    {
        public frmAddUser()
        {
            InitializeComponent();
        }

        HRLEntities db = clsStart.efdb();
        RexrothEntities dbRexroth = clsStart.efdbRexroth();

        private void frmAddUser_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            LoadUsers();

            List<HRLData.p_DropDown_Result> q2 = db.p_DropDown(this.APPID, this.tblNav.NAVID, "ADDARID", this.Parm1, this.Associate.ASID).ToList<HRLData.p_DropDown_Result>();

            var qryARID = (from ct in q2
                           select ct).ToList();

            ddlARID.DataSource = new BindingSource(qryARID, null);
            ddlARID.DisplayMember = "Display";
            ddlARID.ValueMember = "ID";
            ddlARID.SelectedValue = 0;

            this.Cursor = Cursors.Default;
            ddlASID.Select();

        }

        private void LoadUsers()
        {

            List<HRLData.p_DropDown_Result> q = db.p_DropDown(this.APPID, this.tblNav.NAVID, "ADDASID", "", this.Associate.ASID).ToList<HRLData.p_DropDown_Result>();

            var qryASID = (from ct in q
                           select ct).ToList();

            ddlASID.DataSource = new BindingSource(qryASID, null);
            ddlASID.DisplayMember = "Display";
            ddlASID.ValueMember = "ID";
            ddlASID.SelectedValue = 0;

        }

        private void lnkCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void lnkAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try 
            {
                if (this.ddlARID.SelectedValue.ToString() == "0")
                {
                    MessageBox.Show("Please select a Role.", "App User");
                    return;
                }

                if (this.ddlASID.SelectedValue.ToString() == "0")
                {
                    MessageBox.Show("Please select an Associate.", "App User");
                    return;
                }

                if(this.Parm1.Contains("HRL"))
                {
                    HRLData.tblAppUser tbl = new HRLData.tblAppUser();
                    tbl.ARID = Convert.ToInt32(this.ddlARID.SelectedValue.ToString());
                    tbl.ASID = Convert.ToInt32(this.ddlASID.SelectedValue.ToString());
                    db.tblAppUser.Add(tbl);
                    db.SaveChanges();

                }
               

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Add User");
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();

        }

        private void lnkAddUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.txtUID.Text.ToString() + "" == "")
            {
                Cursor.Current = Cursors.WaitCursor;
                MessageBox.Show("Please enter the new associate's USER ID.", this.AppName);
                Cursor.Current = Cursors.Default;
                return;
            }


            try
            {
                Int32 intASID = 0;

                intASID = clsAD.AddUserByUID(this.txtUID.Text.ToString(), this.APPID);

                if (intASID > 0)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    LoadUsers();
                    this.ddlASID.SelectedValue = intASID;

                    Cursor.Current = Cursors.Default;
                    
                }
                else
                {
                    MessageBox.Show("User WAS NOT added.", "Add User");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add User");
            }
        }

       
    }
}
