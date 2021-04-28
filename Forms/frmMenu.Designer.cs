namespace FPY
{
    partial class frmMenu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlSpecial = new System.Windows.Forms.Panel();
            this.ddlFilter = new System.Windows.Forms.ComboBox();
            this.lblRoute = new System.Windows.Forms.Label();
            this.pnlFind = new System.Windows.Forms.Panel();
            this.lblFindResults = new System.Windows.Forms.Label();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.btnFindPrevious = new System.Windows.Forms.Button();
            this.btnFindNext = new System.Windows.Forms.Button();
            this.lblFind = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gv1 = new FPY.clsGridView();
            this.lstImageView = new System.Windows.Forms.ListView();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlMisc = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.lnkExport = new System.Windows.Forms.LinkLabel();
            this.pnlTop.SuspendLayout();
            this.pnlSpecial.SuspendLayout();
            this.pnlFind.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv1)).BeginInit();
            this.pnlGrid.SuspendLayout();
            this.pnlMisc.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.Ivory;
            this.pnlTop.Controls.Add(this.pnlSpecial);
            this.pnlTop.Controls.Add(this.pnlFind);
            this.pnlTop.Controls.Add(this.btnExport);
            this.pnlTop.Controls.Add(this.btnAdd);
            this.pnlTop.Controls.Add(this.btnUndo);
            this.pnlTop.Controls.Add(this.btnSave);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(919, 33);
            this.pnlTop.TabIndex = 0;
            // 
            // pnlSpecial
            // 
            this.pnlSpecial.Controls.Add(this.ddlFilter);
            this.pnlSpecial.Controls.Add(this.lblRoute);
            this.pnlSpecial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSpecial.Location = new System.Drawing.Point(431, 0);
            this.pnlSpecial.Name = "pnlSpecial";
            this.pnlSpecial.Size = new System.Drawing.Size(488, 33);
            this.pnlSpecial.TabIndex = 13;
            this.pnlSpecial.Visible = false;
            // 
            // ddlFilter
            // 
            this.ddlFilter.FormattingEnabled = true;
            this.ddlFilter.Location = new System.Drawing.Point(100, 7);
            this.ddlFilter.Name = "ddlFilter";
            this.ddlFilter.Size = new System.Drawing.Size(186, 21);
            this.ddlFilter.TabIndex = 33;
            this.ddlFilter.SelectionChangeCommitted += new System.EventHandler(this.ddlFilter_SelectionChangeCommitted_1);
            // 
            // lblRoute
            // 
            this.lblRoute.AutoSize = true;
            this.lblRoute.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoute.Location = new System.Drawing.Point(55, 9);
            this.lblRoute.Name = "lblRoute";
            this.lblRoute.Size = new System.Drawing.Size(39, 16);
            this.lblRoute.TabIndex = 32;
            this.lblRoute.Text = "Filter:";
            // 
            // pnlFind
            // 
            this.pnlFind.Controls.Add(this.lnkExport);
            this.pnlFind.Controls.Add(this.lblFindResults);
            this.pnlFind.Controls.Add(this.txtFind);
            this.pnlFind.Controls.Add(this.btnFindPrevious);
            this.pnlFind.Controls.Add(this.btnFindNext);
            this.pnlFind.Controls.Add(this.lblFind);
            this.pnlFind.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFind.Location = new System.Drawing.Point(120, 0);
            this.pnlFind.Name = "pnlFind";
            this.pnlFind.Size = new System.Drawing.Size(311, 33);
            this.pnlFind.TabIndex = 12;
            // 
            // lblFindResults
            // 
            this.lblFindResults.AutoSize = true;
            this.lblFindResults.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFindResults.Location = new System.Drawing.Point(197, 9);
            this.lblFindResults.Name = "lblFindResults";
            this.lblFindResults.Size = new System.Drawing.Size(0, 15);
            this.lblFindResults.TabIndex = 12;
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(43, 7);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(100, 20);
            this.txtFind.TabIndex = 11;
            this.txtFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFind_KeyPress);
            // 
            // btnFindPrevious
            // 
            this.btnFindPrevious.Enabled = false;
            this.btnFindPrevious.FlatAppearance.BorderColor = System.Drawing.Color.DarkKhaki;
            this.btnFindPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindPrevious.Font = new System.Drawing.Font("Wingdings 3", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnFindPrevious.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFindPrevious.ImageIndex = 5;
            this.btnFindPrevious.Location = new System.Drawing.Point(142, 7);
            this.btnFindPrevious.Name = "btnFindPrevious";
            this.btnFindPrevious.Size = new System.Drawing.Size(27, 20);
            this.btnFindPrevious.TabIndex = 9;
            this.btnFindPrevious.Tag = "Find Previous";
            this.btnFindPrevious.Text = "p";
            this.btnFindPrevious.UseVisualStyleBackColor = true;
            this.btnFindPrevious.Click += new System.EventHandler(this.btnFindPrevious_Click);
            this.btnFindPrevious.MouseHover += new System.EventHandler(this.btn_ToolTip);
            // 
            // btnFindNext
            // 
            this.btnFindNext.Enabled = false;
            this.btnFindNext.FlatAppearance.BorderColor = System.Drawing.Color.DarkKhaki;
            this.btnFindNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindNext.Font = new System.Drawing.Font("Wingdings 3", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnFindNext.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFindNext.ImageIndex = 5;
            this.btnFindNext.Location = new System.Drawing.Point(166, 7);
            this.btnFindNext.Name = "btnFindNext";
            this.btnFindNext.Size = new System.Drawing.Size(27, 20);
            this.btnFindNext.TabIndex = 10;
            this.btnFindNext.Tag = "Find Next";
            this.btnFindNext.Text = "q";
            this.btnFindNext.UseVisualStyleBackColor = true;
            this.btnFindNext.Click += new System.EventHandler(this.btnFindNext_Click);
            this.btnFindNext.MouseHover += new System.EventHandler(this.btn_ToolTip);
            // 
            // lblFind
            // 
            this.lblFind.AutoSize = true;
            this.lblFind.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFind.Location = new System.Drawing.Point(6, 8);
            this.lblFind.Name = "lblFind";
            this.lblFind.Size = new System.Drawing.Size(36, 16);
            this.lblFind.TabIndex = 7;
            this.lblFind.Text = "Find:";
            // 
            // btnExport
            // 
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnExport.ImageKey = "stats.ico";
            this.btnExport.ImageList = this.imageList1;
            this.btnExport.Location = new System.Drawing.Point(90, 0);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(30, 33);
            this.btnExport.TabIndex = 6;
            this.btnExport.Tag = "Export Results";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            this.btnExport.MouseHover += new System.EventHandler(this.btn_ToolTip);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "saveas.ico");
            this.imageList1.Images.SetKeyName(1, "undo.ico");
            this.imageList1.Images.SetKeyName(2, "add.ico");
            this.imageList1.Images.SetKeyName(3, "stats.ico");
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAdd.ImageKey = "add.ico";
            this.btnAdd.ImageList = this.imageList1;
            this.btnAdd.Location = new System.Drawing.Point(60, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(30, 33);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Tag = "Add New ";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnAdd.MouseHover += new System.EventHandler(this.btn_ToolTip);
            // 
            // btnUndo
            // 
            this.btnUndo.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnUndo.ImageKey = "undo.ico";
            this.btnUndo.ImageList = this.imageList1;
            this.btnUndo.Location = new System.Drawing.Point(30, 0);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(30, 33);
            this.btnUndo.TabIndex = 4;
            this.btnUndo.Tag = "Undo Changes";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            this.btnUndo.MouseHover += new System.EventHandler(this.btn_ToolTip);
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSave.ImageKey = "saveas.ico";
            this.btnSave.ImageList = this.imageList1;
            this.btnSave.Location = new System.Drawing.Point(0, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(30, 33);
            this.btnSave.TabIndex = 3;
            this.btnSave.Tag = "Save Changes";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.MouseHover += new System.EventHandler(this.btn_ToolTip);
            // 
            // gv1
            // 
            this.gv1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.gv1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.gv1.BackgroundColor = System.Drawing.Color.White;
            this.gv1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.DarkKhaki;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gv1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.gv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gv1.DefaultCellStyle = dataGridViewCellStyle9;
            this.gv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gv1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gv1.EnableHeadersVisualStyles = false;
            this.gv1.GridColor = System.Drawing.Color.DarkKhaki;
            this.gv1.Location = new System.Drawing.Point(0, 0);
            this.gv1.Name = "gv1";
            this.gv1.NAVID = 0;
            this.gv1.PK = 0;
            this.gv1.RowHeadersVisible = false;
            this.gv1.Size = new System.Drawing.Size(620, 320);
            this.gv1.TabIndex = 1;
            this.gv1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv1_CellClick);
            this.gv1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gv1_DataError);
            // 
            // lstImageView
            // 
            this.lstImageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstImageView.Location = new System.Drawing.Point(0, 230);
            this.lstImageView.Name = "lstImageView";
            this.lstImageView.Size = new System.Drawing.Size(294, 90);
            this.lstImageView.TabIndex = 5;
            this.lstImageView.UseCompatibleStateImageBehavior = false;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.gv1);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlGrid.Location = new System.Drawing.Point(0, 33);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(620, 320);
            this.pnlGrid.TabIndex = 3;
            // 
            // txtOutput
            // 
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtOutput.Location = new System.Drawing.Point(0, 0);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(294, 225);
            this.txtOutput.TabIndex = 5;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.SkyBlue;
            this.splitter1.Location = new System.Drawing.Point(620, 33);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 320);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // pnlMisc
            // 
            this.pnlMisc.Controls.Add(this.lstImageView);
            this.pnlMisc.Controls.Add(this.splitter2);
            this.pnlMisc.Controls.Add(this.txtOutput);
            this.pnlMisc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMisc.Location = new System.Drawing.Point(625, 33);
            this.pnlMisc.Name = "pnlMisc";
            this.pnlMisc.Size = new System.Drawing.Size(294, 320);
            this.pnlMisc.TabIndex = 5;
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.Color.SkyBlue;
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 225);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(294, 5);
            this.splitter2.TabIndex = 6;
            this.splitter2.TabStop = false;
            // 
            // lnkExport
            // 
            this.lnkExport.AutoSize = true;
            this.lnkExport.Location = new System.Drawing.Point(220, 10);
            this.lnkExport.Name = "lnkExport";
            this.lnkExport.Size = new System.Drawing.Size(88, 13);
            this.lnkExport.TabIndex = 34;
            this.lnkExport.TabStop = true;
            this.lnkExport.Text = "Export All Images";
            this.lnkExport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkExport_LinkClicked);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 353);
            this.Controls.Add(this.pnlMisc);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlTop);
            this.Name = "frmMenu";
            this.Text = "Credo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCredoMD_FormClosing);
            this.Load += new System.EventHandler(this.frmCredoMD_Load);
            this.Shown += new System.EventHandler(this.frmMenu_Shown);
            this.pnlTop.ResumeLayout(false);
            this.pnlSpecial.ResumeLayout(false);
            this.pnlSpecial.PerformLayout();
            this.pnlFind.ResumeLayout(false);
            this.pnlFind.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv1)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            this.pnlMisc.ResumeLayout(false);
            this.pnlMisc.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblFind;
        private System.Windows.Forms.Button btnFindNext;
        private System.Windows.Forms.Button btnFindPrevious;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Panel pnlFind;
        private System.Windows.Forms.Label lblFindResults;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlSpecial;
        private clsGridView gv1;
        private System.Windows.Forms.ComboBox ddlFilter;
        private System.Windows.Forms.Label lblRoute;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView lstImageView;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel pnlMisc;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.LinkLabel lnkExport;
    }
}