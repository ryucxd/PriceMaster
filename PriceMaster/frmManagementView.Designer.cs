namespace PriceMaster
{
    partial class frmManagementView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManagementView));
            this.dgvChase = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCustomerSearch = new System.Windows.Forms.ComboBox();
            this.chkFuture = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbStaffSearch = new System.Windows.Forms.ComboBox();
            this.dteEnd = new System.Windows.Forms.DateTimePicker();
            this.dteStart = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.chkAllChases = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbChaseStatus = new System.Windows.Forms.ComboBox();
            this.dgvCorrespondence = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnShowAll = new PriceMaster.buttonFormatting();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkboxSlimline = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblChaseCount = new System.Windows.Forms.Label();
            this.lblCorrespondenceCount = new System.Windows.Forms.Label();
            this.btnLiveChart = new PriceMaster.buttonFormatting();
            this.btnExcel = new PriceMaster.buttonFormatting();
            this.buttonFormatting1 = new PriceMaster.buttonFormatting();
            this.btnClear = new PriceMaster.buttonFormatting();
            this.btnWeekly = new PriceMaster.buttonFormatting();
            this.btnCorrespondenceExport = new PriceMaster.buttonFormatting();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCorrespondence)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvChase
            // 
            this.dgvChase.AllowUserToAddRows = false;
            this.dgvChase.AllowUserToDeleteRows = false;
            this.dgvChase.AllowUserToResizeColumns = false;
            this.dgvChase.AllowUserToResizeRows = false;
            this.dgvChase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChase.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvChase.Location = new System.Drawing.Point(12, 78);
            this.dgvChase.Name = "dgvChase";
            this.dgvChase.ReadOnly = true;
            this.dgvChase.RowHeadersVisible = false;
            this.dgvChase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChase.Size = new System.Drawing.Size(1835, 424);
            this.dgvChase.TabIndex = 1;
            this.dgvChase.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label2.Location = new System.Drawing.Point(189, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 17);
            this.label2.TabIndex = 53;
            this.label2.Text = "Customer Search:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cmbCustomerSearch
            // 
            this.cmbCustomerSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbCustomerSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCustomerSearch.FormattingEnabled = true;
            this.cmbCustomerSearch.Location = new System.Drawing.Point(189, 34);
            this.cmbCustomerSearch.Name = "cmbCustomerSearch";
            this.cmbCustomerSearch.Size = new System.Drawing.Size(172, 23);
            this.cmbCustomerSearch.Sorted = true;
            this.cmbCustomerSearch.TabIndex = 52;
            this.cmbCustomerSearch.SelectedIndexChanged += new System.EventHandler(this.cmbCustomerSearch_SelectedIndexChanged);
            // 
            // chkFuture
            // 
            this.chkFuture.AutoSize = true;
            this.chkFuture.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.chkFuture.Location = new System.Drawing.Point(200, 36);
            this.chkFuture.Name = "chkFuture";
            this.chkFuture.Size = new System.Drawing.Size(119, 21);
            this.chkFuture.TabIndex = 54;
            this.chkFuture.Text = "Future Chases";
            this.chkFuture.UseVisualStyleBackColor = true;
            this.chkFuture.CheckedChanged += new System.EventHandler(this.chkFuture_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label3.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label3.Location = new System.Drawing.Point(529, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 55;
            this.label3.Text = "= Priority ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.LightSkyBlue;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label4.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label4.Location = new System.Drawing.Point(487, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 17);
            this.label4.TabIndex = 56;
            this.label4.Text = "       ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label5.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label5.Location = new System.Drawing.Point(5, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 17);
            this.label5.TabIndex = 58;
            this.label5.Text = "Staff Search:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cmbStaffSearch
            // 
            this.cmbStaffSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbStaffSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbStaffSearch.FormattingEnabled = true;
            this.cmbStaffSearch.Location = new System.Drawing.Point(5, 35);
            this.cmbStaffSearch.Name = "cmbStaffSearch";
            this.cmbStaffSearch.Size = new System.Drawing.Size(172, 23);
            this.cmbStaffSearch.Sorted = true;
            this.cmbStaffSearch.TabIndex = 57;
            this.cmbStaffSearch.SelectedIndexChanged += new System.EventHandler(this.cmbStaffSearch_SelectedIndexChanged);
            // 
            // dteEnd
            // 
            this.dteEnd.Location = new System.Drawing.Point(521, 36);
            this.dteEnd.Name = "dteEnd";
            this.dteEnd.Size = new System.Drawing.Size(132, 21);
            this.dteEnd.TabIndex = 62;
            this.dteEnd.CloseUp += new System.EventHandler(this.dteEnd_CloseUp);
            // 
            // dteStart
            // 
            this.dteStart.Location = new System.Drawing.Point(367, 37);
            this.dteStart.Name = "dteStart";
            this.dteStart.Size = new System.Drawing.Size(132, 21);
            this.dteStart.TabIndex = 63;
            this.dteStart.CloseUp += new System.EventHandler(this.dteStart_CloseUp);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label1.Location = new System.Drawing.Point(367, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 17);
            this.label1.TabIndex = 64;
            this.label1.Text = "Chase Date / Correspondence Date";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // chkAllChases
            // 
            this.chkAllChases.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkAllChases.AutoSize = true;
            this.chkAllChases.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.chkAllChases.Location = new System.Drawing.Point(1445, 12);
            this.chkAllChases.Name = "chkAllChases";
            this.chkAllChases.Size = new System.Drawing.Size(80, 21);
            this.chkAllChases.TabIndex = 65;
            this.chkAllChases.Text = "Show All";
            this.chkAllChases.UseVisualStyleBackColor = true;
            this.chkAllChases.Visible = false;
            this.chkAllChases.CheckedChanged += new System.EventHandler(this.chkCompleted_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.DarkGray;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label6.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label6.Location = new System.Drawing.Point(487, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 17);
            this.label6.TabIndex = 68;
            this.label6.Text = "       ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label6.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label7.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label7.Location = new System.Drawing.Point(529, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 17);
            this.label7.TabIndex = 67;
            this.label7.Text = "= Non Latest";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label7.Visible = false;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label8.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label8.Location = new System.Drawing.Point(6, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(188, 17);
            this.label8.TabIndex = 70;
            this.label8.Text = "Chase Status:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cmbChaseStatus
            // 
            this.cmbChaseStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbChaseStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbChaseStatus.FormattingEnabled = true;
            this.cmbChaseStatus.Items.AddRange(new object[] {
            "Chasing",
            "Won",
            "Lost"});
            this.cmbChaseStatus.Location = new System.Drawing.Point(6, 36);
            this.cmbChaseStatus.Name = "cmbChaseStatus";
            this.cmbChaseStatus.Size = new System.Drawing.Size(188, 23);
            this.cmbChaseStatus.TabIndex = 69;
            this.cmbChaseStatus.SelectedIndexChanged += new System.EventHandler(this.cmbChaseStatus_SelectedIndexChanged);
            // 
            // dgvCorrespondence
            // 
            this.dgvCorrespondence.AllowUserToAddRows = false;
            this.dgvCorrespondence.AllowUserToDeleteRows = false;
            this.dgvCorrespondence.AllowUserToResizeColumns = false;
            this.dgvCorrespondence.AllowUserToResizeRows = false;
            this.dgvCorrespondence.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCorrespondence.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCorrespondence.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCorrespondence.Location = new System.Drawing.Point(10, 539);
            this.dgvCorrespondence.Name = "dgvCorrespondence";
            this.dgvCorrespondence.ReadOnly = true;
            this.dgvCorrespondence.RowHeadersVisible = false;
            this.dgvCorrespondence.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCorrespondence.Size = new System.Drawing.Size(1835, 62);
            this.dgvCorrespondence.TabIndex = 71;
            this.dgvCorrespondence.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCorrespondence_CellClick);
            this.dgvCorrespondence.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCorrespondence_CellContentClick);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label9.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label9.Location = new System.Drawing.Point(10, 519);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(1835, 17);
            this.label9.TabIndex = 72;
            this.label9.Text = "Customer Correspondence:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.chkFuture);
            this.groupBox1.Controls.Add(this.cmbChaseStatus);
            this.groupBox1.Controls.Add(this.btnShowAll);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.groupBox1.Location = new System.Drawing.Point(13, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(468, 65);
            this.groupBox1.TabIndex = 73;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chase Filters";
            // 
            // btnShowAll
            // 
            this.btnShowAll.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnShowAll.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnShowAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowAll.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowAll.ForeColor = System.Drawing.Color.White;
            this.btnShowAll.Location = new System.Drawing.Point(322, 26);
            this.btnShowAll.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnShowAll.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Padding = new System.Windows.Forms.Padding(3);
            this.btnShowAll.Size = new System.Drawing.Size(82, 30);
            this.btnShowAll.TabIndex = 66;
            this.btnShowAll.Text = "Show All";
            this.btnShowAll.UseVisualStyleBackColor = false;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkboxSlimline);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmbCustomerSearch);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cmbStaffSearch);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.dteEnd);
            this.groupBox2.Controls.Add(this.dteStart);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.groupBox2.Location = new System.Drawing.Point(617, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(740, 65);
            this.groupBox2.TabIndex = 74;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Universal Filters";
            // 
            // chkboxSlimline
            // 
            this.chkboxSlimline.AutoSize = true;
            this.chkboxSlimline.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.chkboxSlimline.Location = new System.Drawing.Point(659, 36);
            this.chkboxSlimline.Name = "chkboxSlimline";
            this.chkboxSlimline.Size = new System.Drawing.Size(75, 21);
            this.chkboxSlimline.TabIndex = 75;
            this.chkboxSlimline.Text = "Slimline";
            this.chkboxSlimline.UseVisualStyleBackColor = true;
            this.chkboxSlimline.CheckedChanged += new System.EventHandler(this.chkboxSlimline_CheckedChanged);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label10.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label10.Location = new System.Drawing.Point(497, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 17);
            this.label10.TabIndex = 65;
            this.label10.Text = "to";
            this.label10.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblChaseCount
            // 
            this.lblChaseCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblChaseCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChaseCount.Location = new System.Drawing.Point(1557, 51);
            this.lblChaseCount.Name = "lblChaseCount";
            this.lblChaseCount.Size = new System.Drawing.Size(288, 20);
            this.lblChaseCount.TabIndex = 76;
            this.lblChaseCount.Text = "Unique Customers Chased: 0";
            this.lblChaseCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCorrespondenceCount
            // 
            this.lblCorrespondenceCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCorrespondenceCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorrespondenceCount.Location = new System.Drawing.Point(1412, 510);
            this.lblCorrespondenceCount.Name = "lblCorrespondenceCount";
            this.lblCorrespondenceCount.Size = new System.Drawing.Size(433, 20);
            this.lblCorrespondenceCount.TabIndex = 77;
            this.lblCorrespondenceCount.Text = "Unique Correspondence Customers: 0";
            this.lblCorrespondenceCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnLiveChart
            // 
            this.btnLiveChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLiveChart.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnLiveChart.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnLiveChart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLiveChart.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLiveChart.ForeColor = System.Drawing.Color.White;
            this.btnLiveChart.Location = new System.Drawing.Point(1414, 9);
            this.btnLiveChart.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnLiveChart.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnLiveChart.Name = "btnLiveChart";
            this.btnLiveChart.Padding = new System.Windows.Forms.Padding(3);
            this.btnLiveChart.Size = new System.Drawing.Size(110, 30);
            this.btnLiveChart.TabIndex = 75;
            this.btnLiveChart.Text = "Chase Chart";
            this.btnLiveChart.UseVisualStyleBackColor = false;
            this.btnLiveChart.Click += new System.EventHandler(this.btnLiveChart_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnExcel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.ForeColor = System.Drawing.Color.White;
            this.btnExcel.Location = new System.Drawing.Point(1609, 9);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnExcel.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Padding = new System.Windows.Forms.Padding(3);
            this.btnExcel.Size = new System.Drawing.Size(130, 30);
            this.btnExcel.TabIndex = 61;
            this.btnExcel.Text = "Export to Excel";
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // buttonFormatting1
            // 
            this.buttonFormatting1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFormatting1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonFormatting1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonFormatting1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFormatting1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFormatting1.ForeColor = System.Drawing.Color.White;
            this.buttonFormatting1.Location = new System.Drawing.Point(1744, 9);
            this.buttonFormatting1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.buttonFormatting1.MinimumSize = new System.Drawing.Size(75, 30);
            this.buttonFormatting1.Name = "buttonFormatting1";
            this.buttonFormatting1.Padding = new System.Windows.Forms.Padding(3);
            this.buttonFormatting1.Size = new System.Drawing.Size(101, 30);
            this.buttonFormatting1.TabIndex = 60;
            this.buttonFormatting1.Text = "Print Sheet";
            this.buttonFormatting1.UseVisualStyleBackColor = false;
            this.buttonFormatting1.Click += new System.EventHandler(this.buttonFormatting1_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(1530, 9);
            this.btnClear.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnClear.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnClear.Name = "btnClear";
            this.btnClear.Padding = new System.Windows.Forms.Padding(3);
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 59;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnWeekly
            // 
            this.btnWeekly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWeekly.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnWeekly.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnWeekly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWeekly.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWeekly.ForeColor = System.Drawing.Color.White;
            this.btnWeekly.Location = new System.Drawing.Point(1414, 44);
            this.btnWeekly.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnWeekly.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnWeekly.Name = "btnWeekly";
            this.btnWeekly.Padding = new System.Windows.Forms.Padding(3);
            this.btnWeekly.Size = new System.Drawing.Size(135, 30);
            this.btnWeekly.TabIndex = 78;
            this.btnWeekly.Text = "Weekly Targets";
            this.btnWeekly.UseVisualStyleBackColor = false;
            this.btnWeekly.Click += new System.EventHandler(this.btnWeekly_Click);
            // 
            // btnCorrespondenceExport
            // 
            this.btnCorrespondenceExport.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnCorrespondenceExport.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCorrespondenceExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCorrespondenceExport.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCorrespondenceExport.ForeColor = System.Drawing.Color.White;
            this.btnCorrespondenceExport.Location = new System.Drawing.Point(1331, 506);
            this.btnCorrespondenceExport.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnCorrespondenceExport.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnCorrespondenceExport.Name = "btnCorrespondenceExport";
            this.btnCorrespondenceExport.Padding = new System.Windows.Forms.Padding(3);
            this.btnCorrespondenceExport.Size = new System.Drawing.Size(194, 30);
            this.btnCorrespondenceExport.TabIndex = 79;
            this.btnCorrespondenceExport.Text = "Correspondence Export";
            this.btnCorrespondenceExport.UseVisualStyleBackColor = false;
            this.btnCorrespondenceExport.Click += new System.EventHandler(this.btnCorrespondenceExport_Click);
            // 
            // frmManagementView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1859, 613);
            this.Controls.Add(this.btnCorrespondenceExport);
            this.Controls.Add(this.btnWeekly);
            this.Controls.Add(this.lblCorrespondenceCount);
            this.Controls.Add(this.lblChaseCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnLiveChart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgvCorrespondence);
            this.Controls.Add(this.chkAllChases);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.buttonFormatting1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.dgvChase);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "frmManagementView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Outstanding Chases";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.frmSlimlineOutstandingChase_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCorrespondence)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvChase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCustomerSearch;
        private System.Windows.Forms.CheckBox chkFuture;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbStaffSearch;
        private buttonFormatting btnClear;
        private buttonFormatting buttonFormatting1;
        private buttonFormatting btnExcel;
        private System.Windows.Forms.DateTimePicker dteEnd;
        private System.Windows.Forms.DateTimePicker dteStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkAllChases;
        private buttonFormatting btnShowAll;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbChaseStatus;
        private System.Windows.Forms.DataGridView dgvCorrespondence;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkboxSlimline;
        private buttonFormatting btnLiveChart;
        private System.Windows.Forms.Label lblChaseCount;
        private System.Windows.Forms.Label lblCorrespondenceCount;
        private buttonFormatting btnWeekly;
        private buttonFormatting btnCorrespondenceExport;
    }
}