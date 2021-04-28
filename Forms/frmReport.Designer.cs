namespace RexVOIS3
{
    partial class frmReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReport));
            this.panel3 = new System.Windows.Forms.Panel();
            this.gv1 = new RexVOIS3.clsGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlNMR = new System.Windows.Forms.Panel();
            this.pnlZMRN = new System.Windows.Forms.Panel();
            this.txtZMNR = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlMaterial = new System.Windows.Forms.Panel();
            this.txtMaterial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlDistribution = new System.Windows.Forms.Panel();
            this.ddlPBDVID = new System.Windows.Forms.ComboBox();
            this.lnkSelAll = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlType = new System.Windows.Forms.Panel();
            this.ddlType = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pnlCustomer = new System.Windows.Forms.Panel();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlMPR = new System.Windows.Forms.Panel();
            this.txtMRP = new System.Windows.Forms.TextBox();
            this.lblMRP = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ddlReport = new System.Windows.Forms.ComboBox();
            this.txtLine = new System.Windows.Forms.TextBox();
            this.lblReportTitle = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lnkReport = new System.Windows.Forms.LinkLabel();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.lblRoute = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlNMR.SuspendLayout();
            this.pnlZMRN.SuspendLayout();
            this.pnlMaterial.SuspendLayout();
            this.pnlDistribution.SuspendLayout();
            this.pnlType.SuspendLayout();
            this.pnlCustomer.SuspendLayout();
            this.pnlMPR.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.gv1);
            this.panel3.Location = new System.Drawing.Point(120, 41);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(381, 329);
            this.panel3.TabIndex = 55;
            // 
            // gv1
            // 
            this.gv1.AllowUserToAddRows = false;
            this.gv1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.gv1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gv1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(250)))));
            this.gv1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DarkKhaki;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gv1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gv1.DefaultCellStyle = dataGridViewCellStyle6;
            this.gv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gv1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gv1.EnableHeadersVisualStyles = false;
            this.gv1.GridColor = System.Drawing.Color.DarkKhaki;
            this.gv1.Location = new System.Drawing.Point(0, 0);
            this.gv1.Margin = new System.Windows.Forms.Padding(4);
            this.gv1.Name = "gv1";
            this.gv1.NAVID = 0;
            this.gv1.PK = 0;
            this.gv1.ReadOnly = true;
            this.gv1.RowHeadersVisible = false;
            this.gv1.Size = new System.Drawing.Size(381, 329);
            this.gv1.TabIndex = 0;
            this.gv1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv1_CellClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LemonChiffon;
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(15);
            this.panel2.Size = new System.Drawing.Size(1103, 871);
            this.panel2.TabIndex = 52;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.Controls.Add(this.pnlNMR);
            this.panel1.Controls.Add(this.lblProgress);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.ddlReport);
            this.panel1.Controls.Add(this.txtLine);
            this.panel1.Controls.Add(this.lblReportTitle);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.lnkReport);
            this.panel1.Controls.Add(this.dtFrom);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.dtTo);
            this.panel1.Controls.Add(this.lblRoute);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(15, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1073, 841);
            this.panel1.TabIndex = 50;
            // 
            // pnlNMR
            // 
            this.pnlNMR.Controls.Add(this.pnlZMRN);
            this.pnlNMR.Controls.Add(this.pnlMaterial);
            this.pnlNMR.Controls.Add(this.pnlDistribution);
            this.pnlNMR.Controls.Add(this.pnlType);
            this.pnlNMR.Controls.Add(this.pnlCustomer);
            this.pnlNMR.Controls.Add(this.pnlMPR);
            this.pnlNMR.Location = new System.Drawing.Point(57, 156);
            this.pnlNMR.Margin = new System.Windows.Forms.Padding(4);
            this.pnlNMR.Name = "pnlNMR";
            this.pnlNMR.Size = new System.Drawing.Size(540, 586);
            this.pnlNMR.TabIndex = 58;
            this.pnlNMR.Visible = false;
            // 
            // pnlZMRN
            // 
            this.pnlZMRN.Controls.Add(this.txtZMNR);
            this.pnlZMRN.Controls.Add(this.label3);
            this.pnlZMRN.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlZMRN.Location = new System.Drawing.Point(0, 541);
            this.pnlZMRN.Margin = new System.Windows.Forms.Padding(4);
            this.pnlZMRN.Name = "pnlZMRN";
            this.pnlZMRN.Size = new System.Drawing.Size(540, 39);
            this.pnlZMRN.TabIndex = 5;
            // 
            // txtZMNR
            // 
            this.txtZMNR.BackColor = System.Drawing.Color.White;
            this.txtZMNR.Location = new System.Drawing.Point(120, 7);
            this.txtZMNR.Margin = new System.Windows.Forms.Padding(4);
            this.txtZMNR.Name = "txtZMNR";
            this.txtZMNR.Size = new System.Drawing.Size(160, 22);
            this.txtZMNR.TabIndex = 49;
            this.txtZMNR.TextChanged += new System.EventHandler(this.txtZMNR_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(52, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 22);
            this.label3.TabIndex = 48;
            this.label3.Text = "ZMNR:";
            // 
            // pnlMaterial
            // 
            this.pnlMaterial.Controls.Add(this.txtMaterial);
            this.pnlMaterial.Controls.Add(this.label2);
            this.pnlMaterial.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMaterial.Location = new System.Drawing.Point(0, 502);
            this.pnlMaterial.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMaterial.Name = "pnlMaterial";
            this.pnlMaterial.Size = new System.Drawing.Size(540, 39);
            this.pnlMaterial.TabIndex = 4;
            // 
            // txtMaterial
            // 
            this.txtMaterial.BackColor = System.Drawing.Color.White;
            this.txtMaterial.Location = new System.Drawing.Point(120, 7);
            this.txtMaterial.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.Size = new System.Drawing.Size(160, 22);
            this.txtMaterial.TabIndex = 49;
            this.txtMaterial.TextChanged += new System.EventHandler(this.txtMaterial_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 22);
            this.label2.TabIndex = 48;
            this.label2.Text = "Material:";
            // 
            // pnlDistribution
            // 
            this.pnlDistribution.Controls.Add(this.ddlPBDVID);
            this.pnlDistribution.Controls.Add(this.lnkSelAll);
            this.pnlDistribution.Controls.Add(this.panel3);
            this.pnlDistribution.Controls.Add(this.label1);
            this.pnlDistribution.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDistribution.Location = new System.Drawing.Point(0, 117);
            this.pnlDistribution.Margin = new System.Windows.Forms.Padding(4);
            this.pnlDistribution.Name = "pnlDistribution";
            this.pnlDistribution.Size = new System.Drawing.Size(540, 385);
            this.pnlDistribution.TabIndex = 3;
            // 
            // ddlPBDVID
            // 
            this.ddlPBDVID.FormattingEnabled = true;
            this.ddlPBDVID.Location = new System.Drawing.Point(233, 7);
            this.ddlPBDVID.Margin = new System.Windows.Forms.Padding(4);
            this.ddlPBDVID.Name = "ddlPBDVID";
            this.ddlPBDVID.Size = new System.Drawing.Size(267, 24);
            this.ddlPBDVID.TabIndex = 59;
            this.ddlPBDVID.SelectionChangeCommitted += new System.EventHandler(this.ddlPBDVID_SelectionChangeCommitted);
            // 
            // lnkSelAll
            // 
            this.lnkSelAll.AutoSize = true;
            this.lnkSelAll.Location = new System.Drawing.Point(124, 18);
            this.lnkSelAll.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkSelAll.Name = "lnkSelAll";
            this.lnkSelAll.Size = new System.Drawing.Size(76, 17);
            this.lnkSelAll.TabIndex = 58;
            this.lnkSelAll.TabStop = true;
            this.lnkSelAll.Text = "Select ALL";
            this.lnkSelAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSelAll_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 22);
            this.label1.TabIndex = 57;
            this.label1.Text = "Distributions:";
            // 
            // pnlType
            // 
            this.pnlType.Controls.Add(this.ddlType);
            this.pnlType.Controls.Add(this.label10);
            this.pnlType.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlType.Location = new System.Drawing.Point(0, 78);
            this.pnlType.Margin = new System.Windows.Forms.Padding(4);
            this.pnlType.Name = "pnlType";
            this.pnlType.Size = new System.Drawing.Size(540, 39);
            this.pnlType.TabIndex = 2;
            this.pnlType.Visible = false;
            // 
            // ddlType
            // 
            this.ddlType.FormattingEnabled = true;
            this.ddlType.Location = new System.Drawing.Point(120, 7);
            this.ddlType.Margin = new System.Windows.Forms.Padding(4);
            this.ddlType.Name = "ddlType";
            this.ddlType.Size = new System.Drawing.Size(160, 24);
            this.ddlType.TabIndex = 56;
            this.ddlType.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(61, 9);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 22);
            this.label10.TabIndex = 48;
            this.label10.Text = "Type:";
            this.label10.Visible = false;
            // 
            // pnlCustomer
            // 
            this.pnlCustomer.Controls.Add(this.txtCustomer);
            this.pnlCustomer.Controls.Add(this.label8);
            this.pnlCustomer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCustomer.Location = new System.Drawing.Point(0, 39);
            this.pnlCustomer.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCustomer.Name = "pnlCustomer";
            this.pnlCustomer.Size = new System.Drawing.Size(540, 39);
            this.pnlCustomer.TabIndex = 1;
            this.pnlCustomer.Visible = false;
            // 
            // txtCustomer
            // 
            this.txtCustomer.BackColor = System.Drawing.Color.White;
            this.txtCustomer.Location = new System.Drawing.Point(120, 7);
            this.txtCustomer.Margin = new System.Windows.Forms.Padding(4);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(160, 22);
            this.txtCustomer.TabIndex = 47;
            this.txtCustomer.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(27, 9);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 22);
            this.label8.TabIndex = 46;
            this.label8.Text = "Customer:";
            this.label8.Visible = false;
            // 
            // pnlMPR
            // 
            this.pnlMPR.Controls.Add(this.txtMRP);
            this.pnlMPR.Controls.Add(this.lblMRP);
            this.pnlMPR.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMPR.Location = new System.Drawing.Point(0, 0);
            this.pnlMPR.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMPR.Name = "pnlMPR";
            this.pnlMPR.Size = new System.Drawing.Size(540, 39);
            this.pnlMPR.TabIndex = 0;
            this.pnlMPR.Visible = false;
            // 
            // txtMRP
            // 
            this.txtMRP.BackColor = System.Drawing.Color.White;
            this.txtMRP.Location = new System.Drawing.Point(120, 6);
            this.txtMRP.Margin = new System.Windows.Forms.Padding(4);
            this.txtMRP.Name = "txtMRP";
            this.txtMRP.Size = new System.Drawing.Size(160, 22);
            this.txtMRP.TabIndex = 45;
            this.txtMRP.Visible = false;
            // 
            // lblMRP
            // 
            this.lblMRP.AutoSize = true;
            this.lblMRP.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMRP.Location = new System.Drawing.Point(63, 7);
            this.lblMRP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMRP.Name = "lblMRP";
            this.lblMRP.Size = new System.Drawing.Size(47, 22);
            this.lblMRP.TabIndex = 44;
            this.lblMRP.Text = "MRP:";
            this.lblMRP.Visible = false;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblProgress.Location = new System.Drawing.Point(796, 87);
            this.lblProgress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(0, 24);
            this.lblProgress.TabIndex = 53;
            // 
            // pictureBox1
            // 
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(758, 243);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.pictureBox1.Size = new System.Drawing.Size(263, 176);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ddlReport
            // 
            this.ddlReport.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlReport.FormattingEnabled = true;
            this.ddlReport.Location = new System.Drawing.Point(177, 85);
            this.ddlReport.Margin = new System.Windows.Forms.Padding(4);
            this.ddlReport.Name = "ddlReport";
            this.ddlReport.Size = new System.Drawing.Size(463, 27);
            this.ddlReport.TabIndex = 35;
            this.ddlReport.SelectionChangeCommitted += new System.EventHandler(this.ddlReport_SelectionChangeCommitted);
            // 
            // txtLine
            // 
            this.txtLine.BackColor = System.Drawing.Color.Gainsboro;
            this.txtLine.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLine.Location = new System.Drawing.Point(27, 58);
            this.txtLine.Margin = new System.Windows.Forms.Padding(4);
            this.txtLine.Multiline = true;
            this.txtLine.Name = "txtLine";
            this.txtLine.Size = new System.Drawing.Size(1071, 4);
            this.txtLine.TabIndex = 52;
            // 
            // lblReportTitle
            // 
            this.lblReportTitle.AutoSize = true;
            this.lblReportTitle.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportTitle.Location = new System.Drawing.Point(23, 25);
            this.lblReportTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReportTitle.Name = "lblReportTitle";
            this.lblReportTitle.Size = new System.Drawing.Size(96, 27);
            this.lblReportTitle.TabIndex = 51;
            this.lblReportTitle.Text = "Reports";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(361, 126);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 22);
            this.label12.TabIndex = 43;
            this.label12.Text = "To:";
            // 
            // lnkReport
            // 
            this.lnkReport.AutoSize = true;
            this.lnkReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkReport.Location = new System.Drawing.Point(667, 89);
            this.lnkReport.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkReport.Name = "lnkReport";
            this.lnkReport.Size = new System.Drawing.Size(100, 20);
            this.lnkReport.TabIndex = 50;
            this.lnkReport.TabStop = true;
            this.lnkReport.Text = "View Report";
            this.lnkReport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkReport_LinkClicked);
            // 
            // dtFrom
            // 
            this.dtFrom.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFrom.Location = new System.Drawing.Point(177, 124);
            this.dtFrom.Margin = new System.Windows.Forms.Padding(4);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(160, 27);
            this.dtFrom.TabIndex = 40;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(123, 126);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 22);
            this.label11.TabIndex = 41;
            this.label11.Text = "From:";
            // 
            // dtTo
            // 
            this.dtTo.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTo.Location = new System.Drawing.Point(397, 124);
            this.dtTo.Margin = new System.Windows.Forms.Padding(4);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(160, 27);
            this.dtTo.TabIndex = 42;
            // 
            // lblRoute
            // 
            this.lblRoute.AutoSize = true;
            this.lblRoute.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoute.Location = new System.Drawing.Point(60, 87);
            this.lblRoute.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRoute.Name = "lblRoute";
            this.lblRoute.Size = new System.Drawing.Size(108, 22);
            this.lblRoute.TabIndex = 34;
            this.lblRoute.Text = "Select Report:";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Report46.png");
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 871);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmReport";
            this.Text = "frmReport";
            this.Load += new System.EventHandler(this.frmReport_Load);
            this.Shown += new System.EventHandler(this.frmReport_Shown);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlNMR.ResumeLayout(false);
            this.pnlZMRN.ResumeLayout(false);
            this.pnlZMRN.PerformLayout();
            this.pnlMaterial.ResumeLayout(false);
            this.pnlMaterial.PerformLayout();
            this.pnlDistribution.ResumeLayout(false);
            this.pnlDistribution.PerformLayout();
            this.pnlType.ResumeLayout(false);
            this.pnlType.PerformLayout();
            this.pnlCustomer.ResumeLayout(false);
            this.pnlCustomer.PerformLayout();
            this.pnlMPR.ResumeLayout(false);
            this.pnlMPR.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox ddlReport;
        private System.Windows.Forms.TextBox txtLine;
        private System.Windows.Forms.Label lblMRP;
        private System.Windows.Forms.Label lblReportTitle;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.LinkLabel lnkReport;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.TextBox txtMRP;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Label lblRoute;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ComboBox ddlType;
        private clsGridView gv1;
        private System.Windows.Forms.Panel pnlNMR;
        private System.Windows.Forms.Panel pnlDistribution;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlType;
        private System.Windows.Forms.Panel pnlCustomer;
        private System.Windows.Forms.Panel pnlMPR;
        private System.Windows.Forms.LinkLabel lnkSelAll;
        private System.Windows.Forms.Panel pnlZMRN;
        private System.Windows.Forms.TextBox txtZMNR;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlMaterial;
        private System.Windows.Forms.TextBox txtMaterial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ddlPBDVID;
    }
}