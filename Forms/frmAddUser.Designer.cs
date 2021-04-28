namespace FPY
{
    partial class frmAddUser
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lnkCancel = new System.Windows.Forms.LinkLabel();
            this.lnkAdd = new System.Windows.Forms.LinkLabel();
            this.lnkAddUser = new System.Windows.Forms.LinkLabel();
            this.txtUID = new FPY.clsTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ddlARID = new FPY.clsCombo();
            this.label2 = new System.Windows.Forms.Label();
            this.ddlASID = new FPY.clsCombo();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Beige;
            this.panel1.Controls.Add(this.lnkCancel);
            this.panel1.Controls.Add(this.lnkAdd);
            this.panel1.Controls.Add(this.lnkAddUser);
            this.panel1.Controls.Add(this.txtUID);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.ddlARID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ddlASID);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(585, 242);
            this.panel1.TabIndex = 0;
            // 
            // lnkCancel
            // 
            this.lnkCancel.AutoSize = true;
            this.lnkCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkCancel.LinkColor = System.Drawing.Color.Red;
            this.lnkCancel.Location = new System.Drawing.Point(460, 69);
            this.lnkCancel.Name = "lnkCancel";
            this.lnkCancel.Size = new System.Drawing.Size(56, 16);
            this.lnkCancel.TabIndex = 9;
            this.lnkCancel.TabStop = true;
            this.lnkCancel.Text = "Cancel";
            this.lnkCancel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCancel_LinkClicked);
            // 
            // lnkAdd
            // 
            this.lnkAdd.AutoSize = true;
            this.lnkAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkAdd.Location = new System.Drawing.Point(460, 38);
            this.lnkAdd.Name = "lnkAdd";
            this.lnkAdd.Size = new System.Drawing.Size(73, 16);
            this.lnkAdd.TabIndex = 8;
            this.lnkAdd.TabStop = true;
            this.lnkAdd.Text = "Add User";
            this.lnkAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAdd_LinkClicked);
            // 
            // lnkAddUser
            // 
            this.lnkAddUser.AutoSize = true;
            this.lnkAddUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkAddUser.Location = new System.Drawing.Point(294, 190);
            this.lnkAddUser.Name = "lnkAddUser";
            this.lnkAddUser.Size = new System.Drawing.Size(137, 16);
            this.lnkAddUser.TabIndex = 7;
            this.lnkAddUser.TabStop = true;
            this.lnkAddUser.Text = "Find and Add User";
            this.lnkAddUser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAddUser_LinkClicked);
            // 
            // txtUID
            // 
            this.txtUID.Location = new System.Drawing.Point(172, 187);
            this.txtUID.Name = "txtUID";
            this.txtUID.Size = new System.Drawing.Size(100, 20);
            this.txtUID.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(77, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Enter UserID:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(172, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(317, 45);
            this.label3.TabIndex = 4;
            this.label3.Text = "If the user you are trying to add is not in the list above... you can attempt to " +
    "add them here: ";
            // 
            // ddlARID
            // 
            this.ddlARID.FormattingEnabled = true;
            this.ddlARID.LimitToList = true;
            this.ddlARID.Location = new System.Drawing.Point(172, 81);
            this.ddlARID.Name = "ddlARID";
            this.ddlARID.Size = new System.Drawing.Size(246, 21);
            this.ddlARID.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(82, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Select Role:";
            // 
            // ddlASID
            // 
            this.ddlASID.FormattingEnabled = true;
            this.ddlASID.LimitToList = true;
            this.ddlASID.Location = new System.Drawing.Point(172, 36);
            this.ddlASID.Name = "ddlASID";
            this.ddlASID.Size = new System.Drawing.Size(246, 21);
            this.ddlASID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Associate:";
            // 
            // frmAddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(605, 262);
            this.Controls.Add(this.panel1);
            this.Name = "frmAddUser";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Add User";
            this.Load += new System.EventHandler(this.frmAddUser_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private clsCombo ddlASID;
        private System.Windows.Forms.Label label1;
        private clsCombo ddlARID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lnkCancel;
        private System.Windows.Forms.LinkLabel lnkAdd;
        private System.Windows.Forms.LinkLabel lnkAddUser;
        private clsTextBox txtUID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}