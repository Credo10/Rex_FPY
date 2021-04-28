namespace FPY
{
    partial class frmCredoMin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCredoMin));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.gv1 = new FPY.clsGridView();
            this.pnlTop = new FPY.GradientPanel();
            this.pnlFill = new System.Windows.Forms.Panel();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.lnk69 = new System.Windows.Forms.LinkLabel();
            this.ddlFilter = new System.Windows.Forms.ComboBox();
            this.lblRoute = new System.Windows.Forms.Label();
            this.pnlFind = new System.Windows.Forms.Panel();
            this.pnlResults = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblLine = new System.Windows.Forms.Label();
            this.lblSource = new System.Windows.Forms.Label();
            this.ddlDate = new System.Windows.Forms.DateTimePicker();
            this.ddlLine = new System.Windows.Forms.ComboBox();
            this.ddlSource = new System.Windows.Forms.ComboBox();
            this.lblFindResults = new System.Windows.Forms.Label();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.btnFindPrevious = new System.Windows.Forms.Button();
            this.btnFindNext = new System.Windows.Forms.Button();
            this.lblFind = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv1)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlFill.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlFind.SuspendLayout();
            this.pnlResults.SuspendLayout();
            this.SuspendLayout();
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
            // panel1
            // 
            this.panel1.Controls.Add(this.gv1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 35);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1194, 318);
            this.panel1.TabIndex = 3;
            // 
            // gv1
            // 
            this.gv1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Ivory;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.gv1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gv1.BackgroundColor = System.Drawing.Color.White;
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
            this.gv1.RowHeadersVisible = false;
            this.gv1.Size = new System.Drawing.Size(1194, 318);
            this.gv1.TabIndex = 1;
            this.gv1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gv1_CellBeginEdit);
            this.gv1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv1_CellClick);
            this.gv1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gv1_ColumnHeaderMouseClick);
            this.gv1.CurrentCellDirtyStateChanged += new System.EventHandler(this.gv1_CurrentCellDirtyStateChanged);
            this.gv1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gv1_DataError);
            // 
            // pnlTop
            // 
            this.pnlTop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlTop.BackgroundImage")));
            this.pnlTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTop.Controls.Add(this.pnlFill);
            this.pnlTop.Controls.Add(this.pnlFind);
            this.pnlTop.Controls.Add(this.btnExport);
            this.pnlTop.Controls.Add(this.btnAdd);
            this.pnlTop.Controls.Add(this.btnUndo);
            this.pnlTop.Controls.Add(this.btnSave);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(2);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.PageEndColor = System.Drawing.Color.LightSteelBlue;
            this.pnlTop.PageStartColor = System.Drawing.Color.WhiteSmoke;
            this.pnlTop.Size = new System.Drawing.Size(1194, 35);
            this.pnlTop.TabIndex = 2;
            // 
            // pnlFill
            // 
            this.pnlFill.BackColor = System.Drawing.Color.Transparent;
            this.pnlFill.Controls.Add(this.pnlFilter);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFill.Location = new System.Drawing.Point(644, 0);
            this.pnlFill.Margin = new System.Windows.Forms.Padding(2);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(519, 33);
            this.pnlFill.TabIndex = 37;
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.Transparent;
            this.pnlFilter.Controls.Add(this.lnk69);
            this.pnlFilter.Controls.Add(this.ddlFilter);
            this.pnlFilter.Controls.Add(this.lblRoute);
            this.pnlFilter.Location = new System.Drawing.Point(6, 9);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(239, 19);
            this.pnlFilter.TabIndex = 14;
            // 
            // lnk69
            // 
            this.lnk69.AutoSize = true;
            this.lnk69.Location = new System.Drawing.Point(389, 10);
            this.lnk69.Name = "lnk69";
            this.lnk69.Size = new System.Drawing.Size(75, 13);
            this.lnk69.TabIndex = 34;
            this.lnk69.TabStop = true;
            this.lnk69.Text = "Add Associate";
            this.lnk69.Visible = false;
            this.lnk69.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk69_LinkClicked);
            // 
            // ddlFilter
            // 
            this.ddlFilter.FormattingEnabled = true;
            this.ddlFilter.Location = new System.Drawing.Point(73, 6);
            this.ddlFilter.Name = "ddlFilter";
            this.ddlFilter.Size = new System.Drawing.Size(110, 21);
            this.ddlFilter.TabIndex = 33;
            this.ddlFilter.SelectionChangeCommitted += new System.EventHandler(this.ddlFilter_SelectionChangeCommitted);
            // 
            // lblRoute
            // 
            this.lblRoute.AutoSize = true;
            this.lblRoute.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoute.Location = new System.Drawing.Point(3, 7);
            this.lblRoute.Name = "lblRoute";
            this.lblRoute.Size = new System.Drawing.Size(39, 16);
            this.lblRoute.TabIndex = 32;
            this.lblRoute.Text = "Filter:";
            // 
            // pnlFind
            // 
            this.pnlFind.BackColor = System.Drawing.Color.Transparent;
            this.pnlFind.Controls.Add(this.pnlResults);
            this.pnlFind.Controls.Add(this.lblFindResults);
            this.pnlFind.Controls.Add(this.txtFind);
            this.pnlFind.Controls.Add(this.btnFindPrevious);
            this.pnlFind.Controls.Add(this.btnFindNext);
            this.pnlFind.Controls.Add(this.lblFind);
            this.pnlFind.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFind.Location = new System.Drawing.Point(120, 0);
            this.pnlFind.Name = "pnlFind";
            this.pnlFind.Size = new System.Drawing.Size(524, 33);
            this.pnlFind.TabIndex = 13;
            this.pnlFind.Visible = false;
            // 
            // pnlResults
            // 
            this.pnlResults.Controls.Add(this.lblDate);
            this.pnlResults.Controls.Add(this.lblLine);
            this.pnlResults.Controls.Add(this.lblSource);
            this.pnlResults.Controls.Add(this.ddlDate);
            this.pnlResults.Controls.Add(this.ddlLine);
            this.pnlResults.Controls.Add(this.ddlSource);
            this.pnlResults.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlResults.Location = new System.Drawing.Point(0, 0);
            this.pnlResults.Name = "pnlResults";
            this.pnlResults.Size = new System.Drawing.Size(482, 33);
            this.pnlResults.TabIndex = 13;
            this.pnlResults.Visible = false;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(320, 8);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(30, 13);
            this.lblDate.TabIndex = 24;
            this.lblDate.Text = "Date";
            // 
            // lblLine
            // 
            this.lblLine.AutoSize = true;
            this.lblLine.Location = new System.Drawing.Point(180, 8);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(27, 13);
            this.lblLine.TabIndex = 23;
            this.lblLine.Text = "Line";
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Location = new System.Drawing.Point(7, 8);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(41, 13);
            this.lblSource.TabIndex = 22;
            this.lblSource.Text = "Source";
            // 
            // ddlDate
            // 
            this.ddlDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ddlDate.Location = new System.Drawing.Point(356, 5);
            this.ddlDate.Name = "ddlDate";
            this.ddlDate.Size = new System.Drawing.Size(107, 20);
            this.ddlDate.TabIndex = 21;
            this.ddlDate.ValueChanged += new System.EventHandler(this.ddlDate_ValueChanged);
            // 
            // ddlLine
            // 
            this.ddlLine.FormattingEnabled = true;
            this.ddlLine.Location = new System.Drawing.Point(219, 6);
            this.ddlLine.Name = "ddlLine";
            this.ddlLine.Size = new System.Drawing.Size(95, 21);
            this.ddlLine.TabIndex = 20;
            this.ddlLine.SelectionChangeCommitted += new System.EventHandler(this.ddlLine_SelectionChangeCommitted);
            // 
            // ddlSource
            // 
            this.ddlSource.FormattingEnabled = true;
            this.ddlSource.Location = new System.Drawing.Point(50, 5);
            this.ddlSource.Name = "ddlSource";
            this.ddlSource.Size = new System.Drawing.Size(110, 21);
            this.ddlSource.TabIndex = 19;
            this.ddlSource.SelectionChangeCommitted += new System.EventHandler(this.ddlSource_SelectionChangeCommitted);
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
            this.btnExport.TabIndex = 10;
            this.btnExport.Tag = "Export Results";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAdd.ImageKey = "add.ico";
            this.btnAdd.ImageList = this.imageList1;
            this.btnAdd.Location = new System.Drawing.Point(60, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(30, 33);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Tag = "Add New ";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnUndo.ImageKey = "undo.ico";
            this.btnUndo.ImageList = this.imageList1;
            this.btnUndo.Location = new System.Drawing.Point(30, 0);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(30, 33);
            this.btnUndo.TabIndex = 8;
            this.btnUndo.Tag = "Undo Changes";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSave.ImageKey = "saveas.ico";
            this.btnSave.ImageList = this.imageList1;
            this.btnSave.Location = new System.Drawing.Point(0, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(30, 33);
            this.btnSave.TabIndex = 7;
            this.btnSave.Tag = "Save Changes";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmCredoMin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 353);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlTop);
            this.Name = "frmCredoMin";
            this.Text = "Credo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCredoMD_FormClosing);
            this.Load += new System.EventHandler(this.frmCredoMD_Load);
            this.Shown += new System.EventHandler(this.frmCredoMin_Shown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv1)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlFill.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlFind.ResumeLayout(false);
            this.pnlFind.PerformLayout();
            this.pnlResults.ResumeLayout(false);
            this.pnlResults.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private clsGridView gv1;
        private System.Windows.Forms.ImageList imageList1;
        private GradientPanel pnlTop;
        private System.Windows.Forms.Panel pnlFind;
        private System.Windows.Forms.Label lblFindResults;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Button btnFindPrevious;
        private System.Windows.Forms.Button btnFindNext;
        private System.Windows.Forms.Label lblFind;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlFill;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.LinkLabel lnk69;
        private System.Windows.Forms.ComboBox ddlFilter;
        private System.Windows.Forms.Label lblRoute;
        private System.Windows.Forms.Panel pnlResults;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.DateTimePicker ddlDate;
        private System.Windows.Forms.ComboBox ddlLine;
        private System.Windows.Forms.ComboBox ddlSource;
    }
}