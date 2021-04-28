namespace FPY
{
    partial class frmSQLText
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtSQL = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lnkAdd = new System.Windows.Forms.LinkLabel();
            this.lnkCancel = new System.Windows.Forms.LinkLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel5 = new System.Windows.Forms.Panel();
            this.gv1 = new clsGridView();
            this.lnkExecute = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(13, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(837, 533);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.splitter1);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 38);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(837, 495);
            this.panel3.TabIndex = 25;
            // 
            // txtSQL
            // 
            this.txtSQL.CausesValidation = false;
            this.txtSQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSQL.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSQL.ForeColor = System.Drawing.Color.MediumBlue;
            this.txtSQL.Location = new System.Drawing.Point(0, 0);
            this.txtSQL.Margin = new System.Windows.Forms.Padding(4);
            this.txtSQL.MaxLength = 25000;
            this.txtSQL.Name = "txtSQL";
            this.txtSQL.Size = new System.Drawing.Size(837, 182);
            this.txtSQL.TabIndex = 23;
            this.txtSQL.Text = "";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lnkExecute);
            this.panel2.Controls.Add(this.lnkAdd);
            this.panel2.Controls.Add(this.lnkCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(837, 38);
            this.panel2.TabIndex = 24;
            // 
            // lnkAdd
            // 
            this.lnkAdd.AutoSize = true;
            this.lnkAdd.Location = new System.Drawing.Point(716, 11);
            this.lnkAdd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkAdd.Name = "lnkAdd";
            this.lnkAdd.Size = new System.Drawing.Size(107, 17);
            this.lnkAdd.TabIndex = 28;
            this.lnkAdd.TabStop = true;
            this.lnkAdd.Text = "Save and Close";
            this.lnkAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAdd_LinkClicked);
            // 
            // lnkCancel
            // 
            this.lnkCancel.AutoSize = true;
            this.lnkCancel.LinkColor = System.Drawing.Color.DarkRed;
            this.lnkCancel.Location = new System.Drawing.Point(641, 11);
            this.lnkCancel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkCancel.Name = "lnkCancel";
            this.lnkCancel.Size = new System.Drawing.Size(51, 17);
            this.lnkCancel.TabIndex = 27;
            this.lnkCancel.TabStop = true;
            this.lnkCancel.Text = "Cancel";
            this.lnkCancel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCancel_LinkClicked_1);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtSQL);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(837, 182);
            this.panel4.TabIndex = 24;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.SteelBlue;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 182);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(837, 8);
            this.splitter1.TabIndex = 25;
            this.splitter1.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.gv1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 190);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(837, 305);
            this.panel5.TabIndex = 26;
            // 
            // gv1
            // 
            this.gv1.AllowUserToAddRows = false;
            this.gv1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.gv1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gv1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(250)))));
            this.gv1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkKhaki;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gv1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gv1.DefaultCellStyle = dataGridViewCellStyle3;
            this.gv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gv1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gv1.EnableHeadersVisualStyles = false;
            this.gv1.GridColor = System.Drawing.Color.DarkKhaki;
            this.gv1.Location = new System.Drawing.Point(0, 0);
            this.gv1.Name = "gv1";
            this.gv1.NAVID = 0;
            this.gv1.PK = 0;
            this.gv1.ReadOnly = true;
            this.gv1.RowHeadersVisible = false;
            this.gv1.RowTemplate.Height = 24;
            this.gv1.Size = new System.Drawing.Size(837, 305);
            this.gv1.TabIndex = 0;
            // 
            // lnkExecute
            // 
            this.lnkExecute.ActiveLinkColor = System.Drawing.Color.Navy;
            this.lnkExecute.AutoSize = true;
            this.lnkExecute.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkExecute.LinkColor = System.Drawing.Color.Navy;
            this.lnkExecute.Location = new System.Drawing.Point(287, 4);
            this.lnkExecute.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkExecute.Name = "lnkExecute";
            this.lnkExecute.Size = new System.Drawing.Size(155, 28);
            this.lnkExecute.TabIndex = 29;
            this.lnkExecute.TabStop = true;
            this.lnkExecute.Text = "Execute SQL";
            this.lnkExecute.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkExecute_LinkClicked);
            // 
            // frmSQLText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(863, 557);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSQLText";
            this.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.Text = "Add User";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSQLText_FormClosing);
            this.Load += new System.EventHandler(this.frmSQLText_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox txtSQL;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.LinkLabel lnkCancel;
        private System.Windows.Forms.LinkLabel lnkAdd;
        private System.Windows.Forms.Panel panel5;
        private clsGridView gv1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.LinkLabel lnkExecute;
    }
}