namespace RexVOIS3
{
    partial class frmFilterGrid
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFilterGrid));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
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
            this.gv1 = new RexVOIS3.clsGridView();
            this.gv2 = new RexVOIS3.clsGridView();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlSpecial = new System.Windows.Forms.Panel();
            this.pnlPB = new System.Windows.Forms.Panel();
            this.lblAssociate = new System.Windows.Forms.Label();
            this.chkOpen = new System.Windows.Forms.CheckBox();
            this.lnkNew = new System.Windows.Forms.LinkLabel();
            this.chkOnly = new System.Windows.Forms.CheckBox();
            this.ddlAssociate = new RexVOIS3.clsCombo();
            this.pnlTopright = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lnkClearAll = new System.Windows.Forms.LinkLabel();
            this.lnkExcel = new System.Windows.Forms.LinkLabel();
            this.lnkReset = new System.Windows.Forms.LinkLabel();
            this.lblNotes = new System.Windows.Forms.Label();
            this.lblFindResults = new System.Windows.Forms.Label();
            this.gv3 = new RexVOIS3.clsGridView();
            this.lnkGetResults = new System.Windows.Forms.LinkLabel();
            this.chkSupport = new System.Windows.Forms.CheckBox();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.chkOmit = new System.Windows.Forms.CheckBox();
            this.lnkReport = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.ddlReport = new RexVOIS3.clsCombo();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFindPrevious = new System.Windows.Forms.Button();
            this.ddlOption = new RexVOIS3.clsCombo();
            this.btnFindNext = new System.Windows.Forms.Button();
            this.lblFind = new System.Windows.Forms.Label();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.pnlNotUsing = new System.Windows.Forms.Panel();
            this.pnlFill = new System.Windows.Forms.Panel();
            this.pnlDates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv2)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlSpecial.SuspendLayout();
            this.pnlPB.SuspendLayout();
            this.pnlTopright.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv3)).BeginInit();
            this.pnlFilter.SuspendLayout();
            this.pnlNotUsing.SuspendLayout();
            this.pnlFill.SuspendLayout();
            this.SuspendLayout();
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
            this.pnlDates.Location = new System.Drawing.Point(465, 204);
            this.pnlDates.Margin = new System.Windows.Forms.Padding(4);
            this.pnlDates.Name = "pnlDates";
            this.pnlDates.Size = new System.Drawing.Size(151, 215);
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
            this.lnkAging.Location = new System.Drawing.Point(31, 181);
            this.lnkAging.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkAging.Name = "lnkAging";
            this.lnkAging.Size = new System.Drawing.Size(82, 17);
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
            this.lnkClear.Location = new System.Drawing.Point(92, 5);
            this.lnkClear.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkClear.Name = "lnkClear";
            this.lnkClear.Size = new System.Drawing.Size(51, 17);
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
            this.lnkDateOmit.Location = new System.Drawing.Point(29, 150);
            this.lnkDateOmit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkDateOmit.Name = "lnkDateOmit";
            this.lnkDateOmit.Size = new System.Drawing.Size(88, 17);
            this.lnkDateOmit.TabIndex = 10;
            this.lnkDateOmit.TabStop = true;
            this.lnkDateOmit.Text = "Show Blanks";
            this.lnkDateOmit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDateOmit_LinkClicked);
            // 
            // dtEnd
            // 
            this.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEnd.Location = new System.Drawing.Point(11, 84);
            this.dtEnd.Margin = new System.Windows.Forms.Padding(4);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(128, 22);
            this.dtEnd.TabIndex = 9;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(7, 58);
            this.lblTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(33, 22);
            this.lblTo.TabIndex = 8;
            this.lblTo.Text = "To:";
            // 
            // dtStart
            // 
            this.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtStart.Location = new System.Drawing.Point(9, 27);
            this.dtStart.Margin = new System.Windows.Forms.Padding(4);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(128, 22);
            this.dtStart.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 22);
            this.label1.TabIndex = 6;
            this.label1.Text = "From:";
            // 
            // lnkCancel
            // 
            this.lnkCancel.AutoSize = true;
            this.lnkCancel.LinkColor = System.Drawing.Color.Red;
            this.lnkCancel.Location = new System.Drawing.Point(73, 118);
            this.lnkCancel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkCancel.Name = "lnkCancel";
            this.lnkCancel.Size = new System.Drawing.Size(51, 17);
            this.lnkCancel.TabIndex = 1;
            this.lnkCancel.TabStop = true;
            this.lnkCancel.Text = "Cancel";
            this.lnkCancel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCancel_LinkClicked);
            // 
            // lnkOk
            // 
            this.lnkOk.ActiveLinkColor = System.Drawing.Color.Blue;
            this.lnkOk.AutoSize = true;
            this.lnkOk.Location = new System.Drawing.Point(23, 118);
            this.lnkOk.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkOk.Name = "lnkOk";
            this.lnkOk.Size = new System.Drawing.Size(28, 17);
            this.lnkOk.TabIndex = 0;
            this.lnkOk.TabStop = true;
            this.lnkOk.Text = "OK";
            this.lnkOk.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkOk_LinkClicked);
            // 
            // gv1
            // 
            this.gv1.AllowUserToAddRows = false;
            this.gv1.AllowUserToDeleteRows = false;
            this.gv1.AllowUserToResizeColumns = false;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.Black;
            this.gv1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle19;
            this.gv1.BackgroundColor = System.Drawing.Color.White;
            this.gv1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gv1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.DarkKhaki;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gv1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.gv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv1.ColumnHeadersVisible = false;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gv1.DefaultCellStyle = dataGridViewCellStyle21;
            this.gv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gv1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gv1.EnableHeadersVisualStyles = false;
            this.gv1.GridColor = System.Drawing.Color.DarkKhaki;
            this.gv1.Location = new System.Drawing.Point(0, 0);
            this.gv1.Margin = new System.Windows.Forms.Padding(4);
            this.gv1.Name = "gv1";
            this.gv1.NAVID = 0;
            this.gv1.PK = 0;
            this.gv1.RowHeadersVisible = false;
            this.gv1.Size = new System.Drawing.Size(1499, 270);
            this.gv1.TabIndex = 0;
            this.gv1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv1_CellClick);
            this.gv1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv1_CellEndEdit);
            this.gv1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gv1_CellMouseDown);
            this.gv1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gv1_DataError_1);
            this.gv1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.gv1_Scroll);
            // 
            // gv2
            // 
            this.gv2.AllowUserToAddRows = false;
            this.gv2.AllowUserToDeleteRows = false;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.Color.Black;
            this.gv2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle22;
            this.gv2.BackgroundColor = System.Drawing.Color.White;
            this.gv2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gv2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.DarkKhaki;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gv2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle23;
            this.gv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gv2.DefaultCellStyle = dataGridViewCellStyle24;
            this.gv2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gv2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gv2.EnableHeadersVisualStyles = false;
            this.gv2.GridColor = System.Drawing.Color.DarkKhaki;
            this.gv2.Location = new System.Drawing.Point(0, 0);
            this.gv2.Margin = new System.Windows.Forms.Padding(4);
            this.gv2.Name = "gv2";
            this.gv2.NAVID = 0;
            this.gv2.PK = 0;
            this.gv2.RowHeadersVisible = false;
            this.gv2.RowTemplate.Height = 44;
            this.gv2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gv2.ShowCellToolTips = false;
            this.gv2.Size = new System.Drawing.Size(1499, 91);
            this.gv2.TabIndex = 0;
            this.gv2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv2_CellClick);
            this.gv2.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv2_CellValueChanged);
            this.gv2.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gv2_ColumnHeaderMouseClick);
            this.gv2.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.gv2_ColumnWidthChanged);
            this.gv2.CurrentCellDirtyStateChanged += new System.EventHandler(this.gv2_CurrentCellDirtyStateChanged);
            this.gv2.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gv2_DataError);
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.Ivory;
            this.pnlTop.Controls.Add(this.pnlSpecial);
            this.pnlTop.Controls.Add(this.gv3);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1499, 73);
            this.pnlTop.TabIndex = 0;
            // 
            // pnlSpecial
            // 
            this.pnlSpecial.BackColor = System.Drawing.Color.Ivory;
            this.pnlSpecial.Controls.Add(this.pnlPB);
            this.pnlSpecial.Controls.Add(this.pnlTopright);
            this.pnlSpecial.Controls.Add(this.lblNotes);
            this.pnlSpecial.Controls.Add(this.lblFindResults);
            this.pnlSpecial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSpecial.Location = new System.Drawing.Point(0, 0);
            this.pnlSpecial.Margin = new System.Windows.Forms.Padding(4);
            this.pnlSpecial.Name = "pnlSpecial";
            this.pnlSpecial.Size = new System.Drawing.Size(1499, 73);
            this.pnlSpecial.TabIndex = 13;
            // 
            // pnlPB
            // 
            this.pnlPB.Controls.Add(this.lblAssociate);
            this.pnlPB.Controls.Add(this.chkOpen);
            this.pnlPB.Controls.Add(this.lnkNew);
            this.pnlPB.Controls.Add(this.chkOnly);
            this.pnlPB.Controls.Add(this.ddlAssociate);
            this.pnlPB.Location = new System.Drawing.Point(5, 31);
            this.pnlPB.Margin = new System.Windows.Forms.Padding(4);
            this.pnlPB.Name = "pnlPB";
            this.pnlPB.Size = new System.Drawing.Size(1139, 39);
            this.pnlPB.TabIndex = 42;
            this.pnlPB.Visible = false;
            // 
            // lblAssociate
            // 
            this.lblAssociate.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssociate.ForeColor = System.Drawing.Color.Black;
            this.lblAssociate.Location = new System.Drawing.Point(240, 8);
            this.lblAssociate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAssociate.Name = "lblAssociate";
            this.lblAssociate.Size = new System.Drawing.Size(163, 22);
            this.lblAssociate.TabIndex = 40;
            this.lblAssociate.Text = "Associate:";
            this.lblAssociate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblAssociate.Visible = false;
            // 
            // chkOpen
            // 
            this.chkOpen.AutoSize = true;
            this.chkOpen.Location = new System.Drawing.Point(848, 10);
            this.chkOpen.Margin = new System.Windows.Forms.Padding(4);
            this.chkOpen.Name = "chkOpen";
            this.chkOpen.Size = new System.Drawing.Size(136, 21);
            this.chkOpen.TabIndex = 41;
            this.chkOpen.Text = "OPEN tasks only";
            this.chkOpen.UseVisualStyleBackColor = true;
            this.chkOpen.Visible = false;
            this.chkOpen.CheckedChanged += new System.EventHandler(this.chkOpen_CheckedChanged);
            this.chkOpen.Click += new System.EventHandler(this.chkOpen_Click);
            // 
            // lnkNew
            // 
            this.lnkNew.AutoSize = true;
            this.lnkNew.LinkColor = System.Drawing.Color.Blue;
            this.lnkNew.Location = new System.Drawing.Point(3, 15);
            this.lnkNew.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkNew.Name = "lnkNew";
            this.lnkNew.Size = new System.Drawing.Size(232, 17);
            this.lnkNew.TabIndex = 36;
            this.lnkNew.TabStop = true;
            this.lnkNew.Text = "Add NEW Material Tracking Record";
            this.lnkNew.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkNew_LinkClicked);
            // 
            // chkOnly
            // 
            this.chkOnly.AutoSize = true;
            this.chkOnly.Location = new System.Drawing.Point(716, 10);
            this.chkOnly.Margin = new System.Windows.Forms.Padding(4);
            this.chkOnly.Name = "chkOnly";
            this.chkOnly.Size = new System.Drawing.Size(117, 21);
            this.chkOnly.TabIndex = 37;
            this.chkOnly.Text = "MY tasks only";
            this.chkOnly.UseVisualStyleBackColor = true;
            this.chkOnly.CheckedChanged += new System.EventHandler(this.chkOnly_CheckedChanged);
            this.chkOnly.Click += new System.EventHandler(this.chkOnly_Click);
            // 
            // ddlAssociate
            // 
            this.ddlAssociate.FormattingEnabled = true;
            this.ddlAssociate.LimitToList = true;
            this.ddlAssociate.Location = new System.Drawing.Point(409, 8);
            this.ddlAssociate.Margin = new System.Windows.Forms.Padding(4);
            this.ddlAssociate.Name = "ddlAssociate";
            this.ddlAssociate.Size = new System.Drawing.Size(289, 24);
            this.ddlAssociate.TabIndex = 39;
            this.ddlAssociate.Visible = false;
            this.ddlAssociate.SelectionChangeCommitted += new System.EventHandler(this.ddlAssociate_SelectionChangeCommitted);
            // 
            // pnlTopright
            // 
            this.pnlTopright.Controls.Add(this.panel1);
            this.pnlTopright.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlTopright.Location = new System.Drawing.Point(1152, 0);
            this.pnlTopright.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTopright.Name = "pnlTopright";
            this.pnlTopright.Size = new System.Drawing.Size(347, 73);
            this.pnlTopright.TabIndex = 38;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lnkClearAll);
            this.panel1.Controls.Add(this.lnkExcel);
            this.panel1.Controls.Add(this.lnkReset);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 45);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(347, 28);
            this.panel1.TabIndex = 36;
            // 
            // lnkClearAll
            // 
            this.lnkClearAll.AutoSize = true;
            this.lnkClearAll.Dock = System.Windows.Forms.DockStyle.Right;
            this.lnkClearAll.LinkColor = System.Drawing.Color.Blue;
            this.lnkClearAll.Location = new System.Drawing.Point(36, 0);
            this.lnkClearAll.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkClearAll.Name = "lnkClearAll";
            this.lnkClearAll.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.lnkClearAll.Size = new System.Drawing.Size(104, 29);
            this.lnkClearAll.TabIndex = 35;
            this.lnkClearAll.TabStop = true;
            this.lnkClearAll.Text = "Clear Criteria";
            this.lnkClearAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkClearAll_LinkClicked);
            // 
            // lnkExcel
            // 
            this.lnkExcel.AutoSize = true;
            this.lnkExcel.Dock = System.Windows.Forms.DockStyle.Right;
            this.lnkExcel.LinkColor = System.Drawing.Color.Blue;
            this.lnkExcel.Location = new System.Drawing.Point(140, 0);
            this.lnkExcel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkExcel.Name = "lnkExcel";
            this.lnkExcel.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.lnkExcel.Size = new System.Drawing.Size(99, 29);
            this.lnkExcel.TabIndex = 32;
            this.lnkExcel.TabStop = true;
            this.lnkExcel.Text = "Export to XL";
            this.lnkExcel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkExcel_LinkClicked);
            // 
            // lnkReset
            // 
            this.lnkReset.AutoSize = true;
            this.lnkReset.Dock = System.Windows.Forms.DockStyle.Right;
            this.lnkReset.LinkColor = System.Drawing.Color.Blue;
            this.lnkReset.Location = new System.Drawing.Point(239, 0);
            this.lnkReset.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkReset.Name = "lnkReset";
            this.lnkReset.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.lnkReset.Size = new System.Drawing.Size(108, 29);
            this.lnkReset.TabIndex = 30;
            this.lnkReset.TabStop = true;
            this.lnkReset.Text = "Reset Criteria";
            this.lnkReset.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkReset_LinkClicked);
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotes.ForeColor = System.Drawing.Color.Black;
            this.lblNotes.Location = new System.Drawing.Point(4, 7);
            this.lblNotes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(633, 22);
            this.lblNotes.TabIndex = 28;
            this.lblNotes.Text = "Enter.....  *  to omit blank fields.....  #  to omit completed fields..... ! to e" +
    "xclude text (eg !658).";
            // 
            // lblFindResults
            // 
            this.lblFindResults.AutoSize = true;
            this.lblFindResults.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFindResults.Location = new System.Drawing.Point(1283, 84);
            this.lblFindResults.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFindResults.Name = "lblFindResults";
            this.lblFindResults.Size = new System.Drawing.Size(0, 17);
            this.lblFindResults.TabIndex = 15;
            this.lblFindResults.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFindResults.Visible = false;
            // 
            // gv3
            // 
            this.gv3.AllowUserToDeleteRows = false;
            dataGridViewCellStyle25.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.Color.Black;
            this.gv3.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle25;
            this.gv3.BackgroundColor = System.Drawing.Color.White;
            this.gv3.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle26.BackColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle26.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.Color.DarkKhaki;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gv3.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle26;
            this.gv3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle27.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gv3.DefaultCellStyle = dataGridViewCellStyle27;
            this.gv3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gv3.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gv3.EnableHeadersVisualStyles = false;
            this.gv3.GridColor = System.Drawing.Color.DarkKhaki;
            this.gv3.Location = new System.Drawing.Point(0, 0);
            this.gv3.Margin = new System.Windows.Forms.Padding(4);
            this.gv3.Name = "gv3";
            this.gv3.NAVID = 0;
            this.gv3.PK = 0;
            this.gv3.RowHeadersVisible = false;
            this.gv3.Size = new System.Drawing.Size(1499, 73);
            this.gv3.TabIndex = 29;
            this.gv3.Visible = false;
            // 
            // lnkGetResults
            // 
            this.lnkGetResults.AutoSize = true;
            this.lnkGetResults.Enabled = false;
            this.lnkGetResults.LinkColor = System.Drawing.Color.Blue;
            this.lnkGetResults.Location = new System.Drawing.Point(573, 42);
            this.lnkGetResults.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkGetResults.Name = "lnkGetResults";
            this.lnkGetResults.Size = new System.Drawing.Size(58, 17);
            this.lnkGetResults.TabIndex = 34;
            this.lnkGetResults.TabStop = true;
            this.lnkGetResults.Text = "Execute";
            this.lnkGetResults.Visible = false;
            this.lnkGetResults.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkGetResults_LinkClicked);
            // 
            // chkSupport
            // 
            this.chkSupport.AutoSize = true;
            this.chkSupport.Location = new System.Drawing.Point(247, 28);
            this.chkSupport.Margin = new System.Windows.Forms.Padding(4);
            this.chkSupport.Name = "chkSupport";
            this.chkSupport.Size = new System.Drawing.Size(182, 21);
            this.chkSupport.TabIndex = 33;
            this.chkSupport.Text = "Include Supporting Data";
            this.chkSupport.UseVisualStyleBackColor = true;
            this.chkSupport.Visible = false;
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(181, 57);
            this.txtFind.Margin = new System.Windows.Forms.Padding(4);
            this.txtFind.Multiline = true;
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(132, 29);
            this.txtFind.TabIndex = 11;
            this.txtFind.Visible = false;
            this.txtFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFind_KeyPress);
            // 
            // chkOmit
            // 
            this.chkOmit.AutoSize = true;
            this.chkOmit.Location = new System.Drawing.Point(237, 10);
            this.chkOmit.Margin = new System.Windows.Forms.Padding(4);
            this.chkOmit.Name = "chkOmit";
            this.chkOmit.Size = new System.Drawing.Size(192, 21);
            this.chkOmit.TabIndex = 29;
            this.chkOmit.Text = "Suspend Screen Updates";
            this.chkOmit.UseVisualStyleBackColor = true;
            this.chkOmit.Visible = false;
            this.chkOmit.CheckedChanged += new System.EventHandler(this.chkOmit_CheckedChanged);
            // 
            // lnkReport
            // 
            this.lnkReport.AutoSize = true;
            this.lnkReport.Location = new System.Drawing.Point(152, 22);
            this.lnkReport.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkReport.Name = "lnkReport";
            this.lnkReport.Size = new System.Drawing.Size(84, 17);
            this.lnkReport.TabIndex = 27;
            this.lnkReport.TabStop = true;
            this.lnkReport.Text = "View Report";
            this.lnkReport.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 12);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 24);
            this.label7.TabIndex = 26;
            this.label7.Text = "Report:";
            this.label7.UseCompatibleTextRendering = true;
            this.label7.Visible = false;
            // 
            // ddlReport
            // 
            this.ddlReport.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlReport.FormattingEnabled = true;
            this.ddlReport.LimitToList = true;
            this.ddlReport.Location = new System.Drawing.Point(69, 10);
            this.ddlReport.Margin = new System.Windows.Forms.Padding(4);
            this.ddlReport.Name = "ddlReport";
            this.ddlReport.Size = new System.Drawing.Size(73, 28);
            this.ddlReport.TabIndex = 25;
            this.ddlReport.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(411, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 22);
            this.label2.TabIndex = 5;
            this.label2.Text = "Options:";
            this.label2.Visible = false;
            // 
            // btnFindPrevious
            // 
            this.btnFindPrevious.Enabled = false;
            this.btnFindPrevious.FlatAppearance.BorderColor = System.Drawing.Color.DarkKhaki;
            this.btnFindPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindPrevious.Font = new System.Drawing.Font("Wingdings 3", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnFindPrevious.ForeColor = System.Drawing.Color.Black;
            this.btnFindPrevious.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFindPrevious.ImageIndex = 5;
            this.btnFindPrevious.Location = new System.Drawing.Point(313, 57);
            this.btnFindPrevious.Margin = new System.Windows.Forms.Padding(4);
            this.btnFindPrevious.Name = "btnFindPrevious";
            this.btnFindPrevious.Size = new System.Drawing.Size(36, 30);
            this.btnFindPrevious.TabIndex = 9;
            this.btnFindPrevious.Tag = "Find Previous";
            this.btnFindPrevious.Text = "p";
            this.btnFindPrevious.UseVisualStyleBackColor = true;
            this.btnFindPrevious.Visible = false;
            this.btnFindPrevious.Click += new System.EventHandler(this.btnFindPrevious_Click);
            this.btnFindPrevious.MouseHover += new System.EventHandler(this.btn_ToolTip);
            // 
            // ddlOption
            // 
            this.ddlOption.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlOption.FormattingEnabled = true;
            this.ddlOption.LimitToList = true;
            this.ddlOption.Location = new System.Drawing.Point(485, 36);
            this.ddlOption.Margin = new System.Windows.Forms.Padding(4);
            this.ddlOption.Name = "ddlOption";
            this.ddlOption.Size = new System.Drawing.Size(79, 28);
            this.ddlOption.TabIndex = 4;
            this.ddlOption.Visible = false;
            this.ddlOption.SelectionChangeCommitted += new System.EventHandler(this.ddlOption_SelectionChangeCommitted);
            // 
            // btnFindNext
            // 
            this.btnFindNext.Enabled = false;
            this.btnFindNext.FlatAppearance.BorderColor = System.Drawing.Color.DarkKhaki;
            this.btnFindNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindNext.Font = new System.Drawing.Font("Wingdings 3", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnFindNext.ForeColor = System.Drawing.Color.Black;
            this.btnFindNext.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFindNext.ImageIndex = 5;
            this.btnFindNext.Location = new System.Drawing.Point(345, 57);
            this.btnFindNext.Margin = new System.Windows.Forms.Padding(4);
            this.btnFindNext.Name = "btnFindNext";
            this.btnFindNext.Size = new System.Drawing.Size(36, 30);
            this.btnFindNext.TabIndex = 10;
            this.btnFindNext.Tag = "Find Next";
            this.btnFindNext.Text = "q";
            this.btnFindNext.UseVisualStyleBackColor = true;
            this.btnFindNext.Visible = false;
            this.btnFindNext.Click += new System.EventHandler(this.btnFindNext_Click);
            this.btnFindNext.MouseHover += new System.EventHandler(this.btn_ToolTip);
            // 
            // lblFind
            // 
            this.lblFind.AutoSize = true;
            this.lblFind.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFind.ForeColor = System.Drawing.Color.Black;
            this.lblFind.Location = new System.Drawing.Point(61, 60);
            this.lblFind.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFind.Name = "lblFind";
            this.lblFind.Size = new System.Drawing.Size(115, 22);
            this.lblFind.TabIndex = 7;
            this.lblFind.Text = "Find in results:";
            this.lblFind.Visible = false;
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.gv2);
            this.pnlFilter.Controls.Add(this.pnlNotUsing);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 73);
            this.pnlFilter.Margin = new System.Windows.Forms.Padding(4);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1499, 91);
            this.pnlFilter.TabIndex = 2;
            // 
            // pnlNotUsing
            // 
            this.pnlNotUsing.Controls.Add(this.txtFind);
            this.pnlNotUsing.Controls.Add(this.lblFind);
            this.pnlNotUsing.Controls.Add(this.btnFindNext);
            this.pnlNotUsing.Controls.Add(this.lnkGetResults);
            this.pnlNotUsing.Controls.Add(this.btnFindPrevious);
            this.pnlNotUsing.Controls.Add(this.chkSupport);
            this.pnlNotUsing.Controls.Add(this.ddlReport);
            this.pnlNotUsing.Controls.Add(this.label7);
            this.pnlNotUsing.Controls.Add(this.label2);
            this.pnlNotUsing.Controls.Add(this.lnkReport);
            this.pnlNotUsing.Controls.Add(this.ddlOption);
            this.pnlNotUsing.Controls.Add(this.chkOmit);
            this.pnlNotUsing.Location = new System.Drawing.Point(176, 48);
            this.pnlNotUsing.Margin = new System.Windows.Forms.Padding(4);
            this.pnlNotUsing.Name = "pnlNotUsing";
            this.pnlNotUsing.Size = new System.Drawing.Size(665, 101);
            this.pnlNotUsing.TabIndex = 37;
            this.pnlNotUsing.Visible = false;
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.gv1);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(0, 164);
            this.pnlFill.Margin = new System.Windows.Forms.Padding(4);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(1499, 270);
            this.pnlFill.TabIndex = 3;
            // 
            // frmFilterGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1499, 434);
            this.Controls.Add(this.pnlDates);
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmFilterGrid";
            this.Text = "Credo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCredoMD_FormClosing);
            this.Load += new System.EventHandler(this.frmCredoMD_Load);
            this.Shown += new System.EventHandler(this.frmFilterGrid_Shown);
            this.pnlDates.ResumeLayout(false);
            this.pnlDates.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv2)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlSpecial.ResumeLayout(false);
            this.pnlSpecial.PerformLayout();
            this.pnlPB.ResumeLayout(false);
            this.pnlPB.PerformLayout();
            this.pnlTopright.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv3)).EndInit();
            this.pnlFilter.ResumeLayout(false);
            this.pnlNotUsing.ResumeLayout(false);
            this.pnlNotUsing.PerformLayout();
            this.pnlFill.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblFind;
        private System.Windows.Forms.Button btnFindNext;
        private System.Windows.Forms.Button btnFindPrevious;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlSpecial;
        private System.Windows.Forms.Label label2;
        private clsCombo ddlOption;
        private System.Windows.Forms.Label lblFindResults;
        private System.Windows.Forms.LinkLabel lnkReport;
        private System.Windows.Forms.Label label7;
        private clsCombo ddlReport;
        private clsGridView gv2;
        private clsGridView gv1;
        private System.Windows.Forms.Panel pnlDates;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lnkCancel;
        private System.Windows.Forms.LinkLabel lnkOk;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.LinkLabel lnkDateOmit;
        private clsGridView gv3;
        private System.Windows.Forms.CheckBox chkOmit;
        private System.Windows.Forms.LinkLabel lnkReset;
        private System.Windows.Forms.LinkLabel lnkExcel;
        private System.Windows.Forms.CheckBox chkSupport;
        private System.Windows.Forms.LinkLabel lnkGetResults;
        private System.Windows.Forms.LinkLabel lnkClear;
        private System.Windows.Forms.LinkLabel lnkAging;
        private System.Windows.Forms.LinkLabel lnkClearAll;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Panel pnlFill;
        private System.Windows.Forms.LinkLabel lnkNew;
        private System.Windows.Forms.Panel pnlNotUsing;
        private System.Windows.Forms.CheckBox chkOnly;
        private System.Windows.Forms.Label lblAssociate;
        private clsCombo ddlAssociate;
        private System.Windows.Forms.Panel pnlTopright;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkOpen;
        private System.Windows.Forms.Panel pnlPB;
    }
}