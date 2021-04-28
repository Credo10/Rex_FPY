namespace RexVOIS3
{
    partial class frmFilterMin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFilterMin));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlFind = new System.Windows.Forms.Panel();
            this.chkOmit = new System.Windows.Forms.CheckBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lnkClearAll = new System.Windows.Forms.LinkLabel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblFindResults = new System.Windows.Forms.Label();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.btnFindPrevious = new System.Windows.Forms.Button();
            this.btnFindNext = new System.Windows.Forms.Button();
            this.lblFind = new System.Windows.Forms.Label();
            this.pnlDates = new System.Windows.Forms.Panel();
            this.lnkAging = new System.Windows.Forms.LinkLabel();
            this.lnkClear = new System.Windows.Forms.LinkLabel();
            this.lnkDateOmit = new System.Windows.Forms.LinkLabel();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lnkCancel = new System.Windows.Forms.LinkLabel();
            this.lnkOk = new System.Windows.Forms.LinkLabel();
            this.gv2 = new RexVOIS3.clsGridView();
            this.gv1 = new RexVOIS3.clsGridView();
            this.pnlTop.SuspendLayout();
            this.pnlFind.SuspendLayout();
            this.pnlDates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.Ivory;
            this.pnlTop.Controls.Add(this.pnlFind);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(933, 34);
            this.pnlTop.TabIndex = 0;
            // 
            // pnlFind
            // 
            this.pnlFind.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFind.Controls.Add(this.chkOmit);
            this.pnlFind.Controls.Add(this.btnExport);
            this.pnlFind.Controls.Add(this.lnkClearAll);
            this.pnlFind.Controls.Add(this.btnAdd);
            this.pnlFind.Controls.Add(this.btnUndo);
            this.pnlFind.Controls.Add(this.btnSave);
            this.pnlFind.Controls.Add(this.lblFindResults);
            this.pnlFind.Controls.Add(this.txtFind);
            this.pnlFind.Controls.Add(this.btnFindPrevious);
            this.pnlFind.Controls.Add(this.btnFindNext);
            this.pnlFind.Controls.Add(this.lblFind);
            this.pnlFind.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFind.Location = new System.Drawing.Point(0, 0);
            this.pnlFind.Name = "pnlFind";
            this.pnlFind.Size = new System.Drawing.Size(933, 33);
            this.pnlFind.TabIndex = 36;
            // 
            // chkOmit
            // 
            this.chkOmit.AutoSize = true;
            this.chkOmit.Location = new System.Drawing.Point(508, 9);
            this.chkOmit.Name = "chkOmit";
            this.chkOmit.Size = new System.Drawing.Size(148, 17);
            this.chkOmit.TabIndex = 36;
            this.chkOmit.Text = "Suspend Screen Updates";
            this.chkOmit.UseVisualStyleBackColor = true;
            this.chkOmit.Visible = false;
            // 
            // btnExport
            // 
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnExport.ImageKey = "stats.ico";
            this.btnExport.ImageList = this.imageList1;
            this.btnExport.Location = new System.Drawing.Point(90, 0);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(30, 31);
            this.btnExport.TabIndex = 16;
            this.btnExport.Tag = "Export Results";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "add.ico");
            this.imageList1.Images.SetKeyName(1, "floppy.ico");
            this.imageList1.Images.SetKeyName(2, "undo.ico");
            this.imageList1.Images.SetKeyName(3, "movefile.ico");
            this.imageList1.Images.SetKeyName(4, "stats.ico");
            this.imageList1.Images.SetKeyName(5, "up.ico");
            this.imageList1.Images.SetKeyName(6, "down.ico");
            // 
            // lnkClearAll
            // 
            this.lnkClearAll.AutoSize = true;
            this.lnkClearAll.LinkColor = System.Drawing.Color.Blue;
            this.lnkClearAll.Location = new System.Drawing.Point(396, 10);
            this.lnkClearAll.Name = "lnkClearAll";
            this.lnkClearAll.Size = new System.Drawing.Size(66, 13);
            this.lnkClearAll.TabIndex = 35;
            this.lnkClearAll.TabStop = true;
            this.lnkClearAll.Text = "Clear Criteria";
            this.lnkClearAll.Visible = false;
            this.lnkClearAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkClearAll_LinkClicked);
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAdd.ImageKey = "add.ico";
            this.btnAdd.ImageList = this.imageList1;
            this.btnAdd.Location = new System.Drawing.Point(60, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(30, 31);
            this.btnAdd.TabIndex = 15;
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
            this.btnUndo.Size = new System.Drawing.Size(30, 31);
            this.btnUndo.TabIndex = 14;
            this.btnUndo.Tag = "Undo Changes";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSave.ImageKey = "floppy.ico";
            this.btnSave.ImageList = this.imageList1;
            this.btnSave.Location = new System.Drawing.Point(0, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(30, 31);
            this.btnSave.TabIndex = 13;
            this.btnSave.Tag = "Save Changes";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblFindResults
            // 
            this.lblFindResults.AutoSize = true;
            this.lblFindResults.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFindResults.Location = new System.Drawing.Point(333, 8);
            this.lblFindResults.Name = "lblFindResults";
            this.lblFindResults.Size = new System.Drawing.Size(0, 15);
            this.lblFindResults.TabIndex = 12;
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(179, 6);
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
            this.btnFindPrevious.Location = new System.Drawing.Point(278, 6);
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
            this.btnFindNext.Location = new System.Drawing.Point(302, 6);
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
            this.lblFind.Location = new System.Drawing.Point(142, 7);
            this.lblFind.Name = "lblFind";
            this.lblFind.Size = new System.Drawing.Size(36, 16);
            this.lblFind.TabIndex = 7;
            this.lblFind.Text = "Find:";
            // 
            // pnlDates
            // 
            this.pnlDates.BackColor = System.Drawing.Color.LightBlue;
            this.pnlDates.Controls.Add(this.lnkAging);
            this.pnlDates.Controls.Add(this.lnkClear);
            this.pnlDates.Controls.Add(this.lnkDateOmit);
            this.pnlDates.Controls.Add(this.dtEnd);
            this.pnlDates.Controls.Add(this.lblTo);
            this.pnlDates.Controls.Add(this.dtStart);
            this.pnlDates.Controls.Add(this.label1);
            this.pnlDates.Controls.Add(this.lnkCancel);
            this.pnlDates.Controls.Add(this.lnkOk);
            this.pnlDates.Location = new System.Drawing.Point(349, 166);
            this.pnlDates.Name = "pnlDates";
            this.pnlDates.Size = new System.Drawing.Size(113, 175);
            this.pnlDates.TabIndex = 1;
            this.pnlDates.Visible = false;
            this.pnlDates.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlDates_Paint);
            // 
            // lnkAging
            // 
            this.lnkAging.ActiveLinkColor = System.Drawing.Color.Teal;
            this.lnkAging.AutoSize = true;
            this.lnkAging.ForeColor = System.Drawing.Color.Khaki;
            this.lnkAging.LinkColor = System.Drawing.Color.Purple;
            this.lnkAging.Location = new System.Drawing.Point(23, 147);
            this.lnkAging.Name = "lnkAging";
            this.lnkAging.Size = new System.Drawing.Size(64, 13);
            this.lnkAging.TabIndex = 12;
            this.lnkAging.TabStop = true;
            this.lnkAging.Text = "Show Aging";
            this.lnkAging.Visible = false;
            this.lnkAging.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAging_LinkClicked);
            // 
            // lnkClear
            // 
            this.lnkClear.ActiveLinkColor = System.Drawing.Color.Teal;
            this.lnkClear.AutoSize = true;
            this.lnkClear.ForeColor = System.Drawing.Color.Khaki;
            this.lnkClear.LinkColor = System.Drawing.Color.Teal;
            this.lnkClear.Location = new System.Drawing.Point(69, 4);
            this.lnkClear.Name = "lnkClear";
            this.lnkClear.Size = new System.Drawing.Size(37, 13);
            this.lnkClear.TabIndex = 11;
            this.lnkClear.TabStop = true;
            this.lnkClear.Text = "(Clear)";
            this.lnkClear.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkClear_LinkClicked);
            // 
            // lnkDateOmit
            // 
            this.lnkDateOmit.ActiveLinkColor = System.Drawing.Color.Teal;
            this.lnkDateOmit.AutoSize = true;
            this.lnkDateOmit.ForeColor = System.Drawing.Color.Khaki;
            this.lnkDateOmit.LinkColor = System.Drawing.Color.Teal;
            this.lnkDateOmit.Location = new System.Drawing.Point(22, 122);
            this.lnkDateOmit.Name = "lnkDateOmit";
            this.lnkDateOmit.Size = new System.Drawing.Size(69, 13);
            this.lnkDateOmit.TabIndex = 10;
            this.lnkDateOmit.TabStop = true;
            this.lnkDateOmit.Text = "Show Blanks";
            this.lnkDateOmit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDateOmit_LinkClicked);
            // 
            // dtEnd
            // 
            this.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEnd.Location = new System.Drawing.Point(8, 68);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(97, 20);
            this.dtEnd.TabIndex = 9;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(5, 47);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(25, 16);
            this.lblTo.TabIndex = 8;
            this.lblTo.Text = "To:";
            // 
            // dtStart
            // 
            this.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtStart.Location = new System.Drawing.Point(7, 22);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(97, 20);
            this.dtStart.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "From:";
            // 
            // lnkCancel
            // 
            this.lnkCancel.AutoSize = true;
            this.lnkCancel.LinkColor = System.Drawing.Color.Red;
            this.lnkCancel.Location = new System.Drawing.Point(55, 96);
            this.lnkCancel.Name = "lnkCancel";
            this.lnkCancel.Size = new System.Drawing.Size(40, 13);
            this.lnkCancel.TabIndex = 1;
            this.lnkCancel.TabStop = true;
            this.lnkCancel.Text = "Cancel";
            this.lnkCancel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCancel_LinkClicked);
            // 
            // lnkOk
            // 
            this.lnkOk.ActiveLinkColor = System.Drawing.Color.Blue;
            this.lnkOk.AutoSize = true;
            this.lnkOk.Location = new System.Drawing.Point(17, 96);
            this.lnkOk.Name = "lnkOk";
            this.lnkOk.Size = new System.Drawing.Size(22, 13);
            this.lnkOk.TabIndex = 0;
            this.lnkOk.TabStop = true;
            this.lnkOk.Text = "OK";
            this.lnkOk.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkOk_LinkClicked);
            // 
            // gv2
            // 
            this.gv2.AllowUserToAddRows = false;
            this.gv2.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.gv2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.gv2.BackgroundColor = System.Drawing.Color.White;
            this.gv2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gv2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.DarkKhaki;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gv2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.gv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gv2.DefaultCellStyle = dataGridViewCellStyle9;
            this.gv2.Dock = System.Windows.Forms.DockStyle.Top;
            this.gv2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gv2.EnableHeadersVisualStyles = false;
            this.gv2.GridColor = System.Drawing.Color.DarkKhaki;
            this.gv2.Location = new System.Drawing.Point(0, 34);
            this.gv2.Name = "gv2";
            this.gv2.NAVID = 0;
            this.gv2.PK = 0;
            this.gv2.RowHeadersVisible = false;
            this.gv2.RowTemplate.Height = 44;
            this.gv2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gv2.ShowCellToolTips = false;
            this.gv2.Size = new System.Drawing.Size(933, 59);
            this.gv2.TabIndex = 0;
            this.gv2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv2_CellClick);
            this.gv2.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv2_CellValueChanged);
            this.gv2.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gv2_ColumnHeaderMouseClick);
            this.gv2.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.gv2_ColumnWidthChanged);
            this.gv2.CurrentCellDirtyStateChanged += new System.EventHandler(this.gv2_CurrentCellDirtyStateChanged);
            this.gv2.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gv2_DataError);
            // 
            // gv1
            // 
            this.gv1.AllowUserToAddRows = false;
            this.gv1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            this.gv1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.gv1.BackgroundColor = System.Drawing.Color.White;
            this.gv1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gv1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.DarkKhaki;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gv1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.gv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv1.ColumnHeadersVisible = false;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gv1.DefaultCellStyle = dataGridViewCellStyle12;
            this.gv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gv1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gv1.EnableHeadersVisualStyles = false;
            this.gv1.GridColor = System.Drawing.Color.DarkKhaki;
            this.gv1.Location = new System.Drawing.Point(0, 93);
            this.gv1.Name = "gv1";
            this.gv1.NAVID = 0;
            this.gv1.PK = 0;
            this.gv1.RowHeadersVisible = false;
            this.gv1.Size = new System.Drawing.Size(933, 260);
            this.gv1.TabIndex = 0;
            this.gv1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv1_CellClick);
            this.gv1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.gv1_Scroll);
            // 
            // frmFilterMin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 353);
            this.Controls.Add(this.pnlDates);
            this.Controls.Add(this.gv1);
            this.Controls.Add(this.gv2);
            this.Controls.Add(this.pnlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmFilterMin";
            this.Text = "Credo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCredoMD_FormClosing);
            this.Load += new System.EventHandler(this.frmCredoMD_Load);
            this.Shown += new System.EventHandler(this.frmFilterMin_Shown);
            this.pnlTop.ResumeLayout(false);
            this.pnlFind.ResumeLayout(false);
            this.pnlFind.PerformLayout();
            this.pnlDates.ResumeLayout(false);
            this.pnlDates.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel pnlTop;
        private clsGridView gv2;
        private clsGridView gv1;
        private System.Windows.Forms.Panel pnlDates;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lnkCancel;
        private System.Windows.Forms.LinkLabel lnkOk;
        private System.Windows.Forms.LinkLabel lnkDateOmit;
        private System.Windows.Forms.LinkLabel lnkClear;
        private System.Windows.Forms.LinkLabel lnkAging;
        private System.Windows.Forms.Panel pnlFind;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblFindResults;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Button btnFindPrevious;
        private System.Windows.Forms.Button btnFindNext;
        private System.Windows.Forms.Label lblFind;
        private System.Windows.Forms.LinkLabel lnkClearAll;
        private System.Windows.Forms.CheckBox chkOmit;

    }
}