namespace PriceMaster
{
    partial class frmMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblTotalCost = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtQuoteID = new System.Windows.Forms.TextBox();
            this.cmbSystem = new System.Windows.Forms.ComboBox();
            this.cmbMaterial = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtQuoteRef = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbQuotedBy = new System.Windows.Forms.ComboBox();
            this.dteEnd = new System.Windows.Forms.DateTimePicker();
            this.dteStart = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbChasingStatus = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbChasedBy = new System.Windows.Forms.ComboBox();
            this.dteChaseEnd = new System.Windows.Forms.DateTimePicker();
            this.dteChaseStart = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.chkChasePriority = new System.Windows.Forms.CheckBox();
            this.btnNewCustomers = new PriceMaster.buttonFormatting();
            this.btnNonReturningEnquiries = new PriceMaster.buttonFormatting();
            this.btnTurnoverDecline = new PriceMaster.buttonFormatting();
            this.btnNonReturningCustomers = new PriceMaster.buttonFormatting();
            this.btnCalendar = new PriceMaster.buttonFormatting();
            this.buttonFormatting2 = new PriceMaster.buttonFormatting();
            this.btnAlert = new PriceMaster.buttonFormatting();
            this.buttonFormatting1 = new PriceMaster.buttonFormatting();
            this.btnManagementView = new PriceMaster.buttonFormatting();
            this.btnOutstanding = new PriceMaster.buttonFormatting();
            this.btnAdmin = new PriceMaster.buttonFormatting();
            this.btnTraditional = new PriceMaster.buttonFormatting();
            this.btnNewQuote = new PriceMaster.buttonFormatting();
            this.btnCustomer = new PriceMaster.buttonFormatting();
            this.btnMaterial = new PriceMaster.buttonFormatting();
            this.btnSupplier = new PriceMaster.buttonFormatting();
            this.btnEmail = new PriceMaster.buttonFormatting();
            this.btnClear = new PriceMaster.buttonFormatting();
            this.btnLeads = new PriceMaster.buttonFormatting();
            this.btnryucxd = new PriceMaster.buttonFormatting();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(12, 143);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1877, 499);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // lblTotalCost
            // 
            this.lblTotalCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblTotalCost.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblTotalCost.Location = new System.Drawing.Point(1225, 645);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(664, 23);
            this.lblTotalCost.TabIndex = 1;
            this.lblTotalCost.Text = "label1";
            this.lblTotalCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(-26, -49);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(347, 240);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // txtQuoteID
            // 
            this.txtQuoteID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtQuoteID.Location = new System.Drawing.Point(216, 110);
            this.txtQuoteID.Name = "txtQuoteID";
            this.txtQuoteID.Size = new System.Drawing.Size(84, 21);
            this.txtQuoteID.TabIndex = 3;
            this.txtQuoteID.TextChanged += new System.EventHandler(this.txtQuoteID_TextChanged);
            this.txtQuoteID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuoteID_KeyDown);
            this.txtQuoteID.Leave += new System.EventHandler(this.txtQuoteID_Leave);
            // 
            // cmbSystem
            // 
            this.cmbSystem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbSystem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSystem.FormattingEnabled = true;
            this.cmbSystem.Location = new System.Drawing.Point(786, 112);
            this.cmbSystem.Name = "cmbSystem";
            this.cmbSystem.Size = new System.Drawing.Size(121, 21);
            this.cmbSystem.TabIndex = 7;
            this.cmbSystem.SelectedIndexChanged += new System.EventHandler(this.cmbSystem_SelectedIndexChanged);
            // 
            // cmbMaterial
            // 
            this.cmbMaterial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbMaterial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMaterial.FormattingEnabled = true;
            this.cmbMaterial.Location = new System.Drawing.Point(659, 112);
            this.cmbMaterial.Name = "cmbMaterial";
            this.cmbMaterial.Size = new System.Drawing.Size(121, 21);
            this.cmbMaterial.TabIndex = 8;
            this.cmbMaterial.SelectedIndexChanged += new System.EventHandler(this.cmbMaterial_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label1.Location = new System.Drawing.Point(216, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 23);
            this.label1.TabIndex = 9;
            this.label1.Text = "Quote ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label4.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label4.Location = new System.Drawing.Point(656, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 23);
            this.label4.TabIndex = 12;
            this.label4.Text = "Material";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label5.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label5.Location = new System.Drawing.Point(783, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 23);
            this.label5.TabIndex = 13;
            this.label5.Text = "System";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label6.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label6.Location = new System.Drawing.Point(910, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(178, 23);
            this.label6.TabIndex = 15;
            this.label6.Text = "Customer";
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(913, 112);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(175, 21);
            this.cmbCustomer.TabIndex = 14;
            this.cmbCustomer.SelectedIndexChanged += new System.EventHandler(this.cmbCustomer_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label10.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label10.Location = new System.Drawing.Point(1094, 87);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 23);
            this.label10.TabIndex = 24;
            this.label10.Text = "Quotation Ref";
            this.label10.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // txtQuoteRef
            // 
            this.txtQuoteRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtQuoteRef.Location = new System.Drawing.Point(1094, 114);
            this.txtQuoteRef.Name = "txtQuoteRef";
            this.txtQuoteRef.Size = new System.Drawing.Size(100, 21);
            this.txtQuoteRef.TabIndex = 23;
            this.txtQuoteRef.TextChanged += new System.EventHandler(this.txtQuoteRef_TextChanged);
            this.txtQuoteRef.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuoteRef_KeyDown);
            this.txtQuoteRef.Leave += new System.EventHandler(this.txtQuoteRef_Leave);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label11.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label11.Location = new System.Drawing.Point(1200, 87);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(109, 23);
            this.label11.TabIndex = 26;
            this.label11.Text = "Price";
            this.label11.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // txtPrice
            // 
            this.txtPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtPrice.Location = new System.Drawing.Point(1200, 114);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(112, 21);
            this.txtPrice.TabIndex = 25;
            this.txtPrice.TextChanged += new System.EventHandler(this.txtPrice_TextChanged);
            this.txtPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPrice_KeyDown);
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            this.txtPrice.Leave += new System.EventHandler(this.txtPrice_Leave);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label12.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label12.Location = new System.Drawing.Point(1315, 88);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(124, 23);
            this.label12.TabIndex = 28;
            this.label12.Text = "Quoted By";
            this.label12.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cmbQuotedBy
            // 
            this.cmbQuotedBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbQuotedBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbQuotedBy.FormattingEnabled = true;
            this.cmbQuotedBy.Location = new System.Drawing.Point(1318, 114);
            this.cmbQuotedBy.Name = "cmbQuotedBy";
            this.cmbQuotedBy.Size = new System.Drawing.Size(121, 21);
            this.cmbQuotedBy.TabIndex = 27;
            this.cmbQuotedBy.SelectedIndexChanged += new System.EventHandler(this.txtQuotedBy_SelectedIndexChanged);
            // 
            // dteEnd
            // 
            this.dteEnd.Location = new System.Drawing.Point(1557, 116);
            this.dteEnd.Name = "dteEnd";
            this.dteEnd.Size = new System.Drawing.Size(121, 20);
            this.dteEnd.TabIndex = 31;
            this.dteEnd.ValueChanged += new System.EventHandler(this.dteEnd_ValueChanged);
            // 
            // dteStart
            // 
            this.dteStart.Location = new System.Drawing.Point(1557, 80);
            this.dteStart.Name = "dteStart";
            this.dteStart.Size = new System.Drawing.Size(121, 20);
            this.dteStart.TabIndex = 30;
            this.dteStart.ValueChanged += new System.EventHandler(this.dteStart_ValueChanged);
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label13.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label13.Location = new System.Drawing.Point(1555, 50);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(124, 23);
            this.label13.TabIndex = 29;
            this.label13.Text = "Quote Date";
            this.label13.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label14.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label14.Location = new System.Drawing.Point(1553, 90);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(124, 23);
            this.label14.TabIndex = 32;
            this.label14.Text = "to";
            this.label14.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label2.Location = new System.Drawing.Point(1441, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 23);
            this.label2.TabIndex = 40;
            this.label2.Text = "Customer Type";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cmbType
            // 
            this.cmbType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "Main Contractor",
            "Trade"});
            this.cmbType.Location = new System.Drawing.Point(1444, 114);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(107, 21);
            this.cmbType.TabIndex = 39;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label7.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label7.Location = new System.Drawing.Point(306, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 23);
            this.label7.TabIndex = 88;
            this.label7.Text = "Chase Status";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cmbChasingStatus
            // 
            this.cmbChasingStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbChasingStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbChasingStatus.FormattingEnabled = true;
            this.cmbChasingStatus.Items.AddRange(new object[] {
            "Pending",
            "Chasing",
            "Won",
            "Lost"});
            this.cmbChasingStatus.Location = new System.Drawing.Point(306, 110);
            this.cmbChasingStatus.Name = "cmbChasingStatus";
            this.cmbChasingStatus.Size = new System.Drawing.Size(93, 21);
            this.cmbChasingStatus.TabIndex = 87;
            this.cmbChasingStatus.SelectedIndexChanged += new System.EventHandler(this.cmbChasingStatus_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label9.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label9.Location = new System.Drawing.Point(532, 85);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 23);
            this.label9.TabIndex = 92;
            this.label9.Text = "Last Chased By";
            this.label9.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cmbChasedBy
            // 
            this.cmbChasedBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbChasedBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbChasedBy.FormattingEnabled = true;
            this.cmbChasedBy.Location = new System.Drawing.Point(532, 111);
            this.cmbChasedBy.Name = "cmbChasedBy";
            this.cmbChasedBy.Size = new System.Drawing.Size(121, 21);
            this.cmbChasedBy.TabIndex = 91;
            this.cmbChasedBy.SelectedIndexChanged += new System.EventHandler(this.cmbChasedBy_SelectedIndexChanged);
            // 
            // dteChaseEnd
            // 
            this.dteChaseEnd.Location = new System.Drawing.Point(405, 111);
            this.dteChaseEnd.Name = "dteChaseEnd";
            this.dteChaseEnd.Size = new System.Drawing.Size(121, 20);
            this.dteChaseEnd.TabIndex = 95;
            this.dteChaseEnd.ValueChanged += new System.EventHandler(this.dteChaseEnd_ValueChanged);
            // 
            // dteChaseStart
            // 
            this.dteChaseStart.Location = new System.Drawing.Point(405, 75);
            this.dteChaseStart.Name = "dteChaseStart";
            this.dteChaseStart.Size = new System.Drawing.Size(121, 20);
            this.dteChaseStart.TabIndex = 94;
            this.dteChaseStart.ValueChanged += new System.EventHandler(this.dteChaseStart_ValueChanged);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label8.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label8.Location = new System.Drawing.Point(403, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 23);
            this.label8.TabIndex = 93;
            this.label8.Text = "Last Chase Date";
            this.label8.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label15.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label15.Location = new System.Drawing.Point(401, 85);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(124, 23);
            this.label15.TabIndex = 96;
            this.label15.Text = "to";
            this.label15.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // chkChasePriority
            // 
            this.chkChasePriority.AutoSize = true;
            this.chkChasePriority.BackColor = System.Drawing.Color.LightSkyBlue;
            this.chkChasePriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.chkChasePriority.Location = new System.Drawing.Point(293, 63);
            this.chkChasePriority.Name = "chkChasePriority";
            this.chkChasePriority.Size = new System.Drawing.Size(109, 20);
            this.chkChasePriority.TabIndex = 98;
            this.chkChasePriority.Text = "Priority Chase";
            this.chkChasePriority.UseVisualStyleBackColor = false;
            this.chkChasePriority.CheckedChanged += new System.EventHandler(this.chkChasePriority_CheckedChanged);
            // 
            // btnNewCustomers
            // 
            this.btnNewCustomers.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnNewCustomers.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnNewCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewCustomers.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewCustomers.ForeColor = System.Drawing.Color.White;
            this.btnNewCustomers.Location = new System.Drawing.Point(1691, 72);
            this.btnNewCustomers.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnNewCustomers.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnNewCustomers.Name = "btnNewCustomers";
            this.btnNewCustomers.Padding = new System.Windows.Forms.Padding(3);
            this.btnNewCustomers.Size = new System.Drawing.Size(208, 30);
            this.btnNewCustomers.TabIndex = 117;
            this.btnNewCustomers.Text = "New Customers";
            this.btnNewCustomers.UseVisualStyleBackColor = false;
            this.btnNewCustomers.Click += new System.EventHandler(this.btnNewCustomers_Click);
            // 
            // btnNonReturningEnquiries
            // 
            this.btnNonReturningEnquiries.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnNonReturningEnquiries.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnNonReturningEnquiries.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNonReturningEnquiries.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNonReturningEnquiries.ForeColor = System.Drawing.Color.White;
            this.btnNonReturningEnquiries.Location = new System.Drawing.Point(1691, 40);
            this.btnNonReturningEnquiries.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnNonReturningEnquiries.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnNonReturningEnquiries.Name = "btnNonReturningEnquiries";
            this.btnNonReturningEnquiries.Padding = new System.Windows.Forms.Padding(3);
            this.btnNonReturningEnquiries.Size = new System.Drawing.Size(208, 30);
            this.btnNonReturningEnquiries.TabIndex = 116;
            this.btnNonReturningEnquiries.Text = "Non Returning Enquiries";
            this.btnNonReturningEnquiries.UseVisualStyleBackColor = false;
            this.btnNonReturningEnquiries.Click += new System.EventHandler(this.btnNonReturningEnquiries_Click);
            // 
            // btnTurnoverDecline
            // 
            this.btnTurnoverDecline.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnTurnoverDecline.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnTurnoverDecline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTurnoverDecline.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTurnoverDecline.ForeColor = System.Drawing.Color.White;
            this.btnTurnoverDecline.Location = new System.Drawing.Point(1420, 45);
            this.btnTurnoverDecline.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnTurnoverDecline.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnTurnoverDecline.Name = "btnTurnoverDecline";
            this.btnTurnoverDecline.Padding = new System.Windows.Forms.Padding(3);
            this.btnTurnoverDecline.Size = new System.Drawing.Size(145, 30);
            this.btnTurnoverDecline.TabIndex = 115;
            this.btnTurnoverDecline.Text = "Turnover Decline";
            this.btnTurnoverDecline.UseVisualStyleBackColor = false;
            this.btnTurnoverDecline.Click += new System.EventHandler(this.btnTurnoverDecline_Click);
            // 
            // btnNonReturningCustomers
            // 
            this.btnNonReturningCustomers.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnNonReturningCustomers.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnNonReturningCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNonReturningCustomers.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNonReturningCustomers.ForeColor = System.Drawing.Color.White;
            this.btnNonReturningCustomers.Location = new System.Drawing.Point(1691, 9);
            this.btnNonReturningCustomers.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnNonReturningCustomers.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnNonReturningCustomers.Name = "btnNonReturningCustomers";
            this.btnNonReturningCustomers.Padding = new System.Windows.Forms.Padding(3);
            this.btnNonReturningCustomers.Size = new System.Drawing.Size(208, 30);
            this.btnNonReturningCustomers.TabIndex = 114;
            this.btnNonReturningCustomers.Text = "Non Returning Customers";
            this.btnNonReturningCustomers.UseVisualStyleBackColor = false;
            this.btnNonReturningCustomers.Click += new System.EventHandler(this.btnNonReturningCustomers_Click);
            // 
            // btnCalendar
            // 
            this.btnCalendar.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnCalendar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCalendar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalendar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalendar.ForeColor = System.Drawing.Color.White;
            this.btnCalendar.Location = new System.Drawing.Point(269, 9);
            this.btnCalendar.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnCalendar.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnCalendar.Name = "btnCalendar";
            this.btnCalendar.Padding = new System.Windows.Forms.Padding(3);
            this.btnCalendar.Size = new System.Drawing.Size(130, 30);
            this.btnCalendar.TabIndex = 113;
            this.btnCalendar.Text = "CALENDAR";
            this.btnCalendar.UseVisualStyleBackColor = false;
            this.btnCalendar.Click += new System.EventHandler(this.btnCalendar_Click);
            // 
            // buttonFormatting2
            // 
            this.buttonFormatting2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonFormatting2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonFormatting2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFormatting2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFormatting2.ForeColor = System.Drawing.Color.White;
            this.buttonFormatting2.Location = new System.Drawing.Point(1167, 45);
            this.buttonFormatting2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.buttonFormatting2.MinimumSize = new System.Drawing.Size(75, 30);
            this.buttonFormatting2.Name = "buttonFormatting2";
            this.buttonFormatting2.Padding = new System.Windows.Forms.Padding(3);
            this.buttonFormatting2.Size = new System.Drawing.Size(243, 30);
            this.buttonFormatting2.TabIndex = 111;
            this.buttonFormatting2.Text = "Outstanding Correspondence";
            this.buttonFormatting2.UseVisualStyleBackColor = false;
            this.buttonFormatting2.Click += new System.EventHandler(this.buttonFormatting2_Click);
            // 
            // btnAlert
            // 
            this.btnAlert.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnAlert.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAlert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlert.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlert.ForeColor = System.Drawing.Color.White;
            this.btnAlert.Location = new System.Drawing.Point(571, 44);
            this.btnAlert.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnAlert.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnAlert.Name = "btnAlert";
            this.btnAlert.Padding = new System.Windows.Forms.Padding(3);
            this.btnAlert.Size = new System.Drawing.Size(154, 30);
            this.btnAlert.TabIndex = 110;
            this.btnAlert.Text = "Management Alert";
            this.btnAlert.UseVisualStyleBackColor = false;
            this.btnAlert.Click += new System.EventHandler(this.btnAlert_Click);
            // 
            // buttonFormatting1
            // 
            this.buttonFormatting1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonFormatting1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonFormatting1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFormatting1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFormatting1.ForeColor = System.Drawing.Color.White;
            this.buttonFormatting1.Location = new System.Drawing.Point(936, 45);
            this.buttonFormatting1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.buttonFormatting1.MinimumSize = new System.Drawing.Size(75, 30);
            this.buttonFormatting1.Name = "buttonFormatting1";
            this.buttonFormatting1.Padding = new System.Windows.Forms.Padding(3);
            this.buttonFormatting1.Size = new System.Drawing.Size(221, 30);
            this.buttonFormatting1.TabIndex = 109;
            this.buttonFormatting1.Text = "Customer Correspondence";
            this.buttonFormatting1.UseVisualStyleBackColor = false;
            this.buttonFormatting1.Click += new System.EventHandler(this.buttonFormatting1_Click);
            // 
            // btnManagementView
            // 
            this.btnManagementView.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnManagementView.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnManagementView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManagementView.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManagementView.ForeColor = System.Drawing.Color.White;
            this.btnManagementView.Location = new System.Drawing.Point(571, 9);
            this.btnManagementView.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnManagementView.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnManagementView.Name = "btnManagementView";
            this.btnManagementView.Padding = new System.Windows.Forms.Padding(3);
            this.btnManagementView.Size = new System.Drawing.Size(154, 30);
            this.btnManagementView.TabIndex = 97;
            this.btnManagementView.Text = "Management View";
            this.btnManagementView.UseVisualStyleBackColor = false;
            this.btnManagementView.Click += new System.EventHandler(this.btnManagementView_Click);
            // 
            // btnOutstanding
            // 
            this.btnOutstanding.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnOutstanding.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnOutstanding.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOutstanding.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOutstanding.ForeColor = System.Drawing.Color.White;
            this.btnOutstanding.Location = new System.Drawing.Point(747, 44);
            this.btnOutstanding.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnOutstanding.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnOutstanding.Name = "btnOutstanding";
            this.btnOutstanding.Padding = new System.Windows.Forms.Padding(3);
            this.btnOutstanding.Size = new System.Drawing.Size(179, 30);
            this.btnOutstanding.TabIndex = 86;
            this.btnOutstanding.Text = "Outstanding Chases";
            this.btnOutstanding.UseVisualStyleBackColor = false;
            this.btnOutstanding.Click += new System.EventHandler(this.btnOutstanding_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnAdmin.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdmin.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdmin.ForeColor = System.Drawing.Color.White;
            this.btnAdmin.Location = new System.Drawing.Point(1691, 9);
            this.btnAdmin.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnAdmin.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Padding = new System.Windows.Forms.Padding(3);
            this.btnAdmin.Size = new System.Drawing.Size(213, 30);
            this.btnAdmin.TabIndex = 85;
            this.btnAdmin.Text = "All Outstanding Chases";
            this.btnAdmin.UseVisualStyleBackColor = false;
            this.btnAdmin.Visible = false;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // btnTraditional
            // 
            this.btnTraditional.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnTraditional.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnTraditional.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTraditional.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTraditional.ForeColor = System.Drawing.Color.White;
            this.btnTraditional.Location = new System.Drawing.Point(747, 9);
            this.btnTraditional.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnTraditional.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnTraditional.Name = "btnTraditional";
            this.btnTraditional.Padding = new System.Windows.Forms.Padding(3);
            this.btnTraditional.Size = new System.Drawing.Size(146, 30);
            this.btnTraditional.TabIndex = 41;
            this.btnTraditional.Text = "Traditional Log";
            this.btnTraditional.UseVisualStyleBackColor = false;
            this.btnTraditional.Click += new System.EventHandler(this.btnTraditional_Click);
            // 
            // btnNewQuote
            // 
            this.btnNewQuote.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnNewQuote.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnNewQuote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewQuote.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewQuote.ForeColor = System.Drawing.Color.White;
            this.btnNewQuote.Location = new System.Drawing.Point(1535, 9);
            this.btnNewQuote.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnNewQuote.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnNewQuote.Name = "btnNewQuote";
            this.btnNewQuote.Padding = new System.Windows.Forms.Padding(3);
            this.btnNewQuote.Size = new System.Drawing.Size(146, 30);
            this.btnNewQuote.TabIndex = 38;
            this.btnNewQuote.Text = "New Quote";
            this.btnNewQuote.UseVisualStyleBackColor = false;
            this.btnNewQuote.Click += new System.EventHandler(this.btnNewQuote_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnCustomer.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomer.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomer.ForeColor = System.Drawing.Color.White;
            this.btnCustomer.Location = new System.Drawing.Point(1379, 9);
            this.btnCustomer.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnCustomer.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Padding = new System.Windows.Forms.Padding(3);
            this.btnCustomer.Size = new System.Drawing.Size(146, 30);
            this.btnCustomer.TabIndex = 37;
            this.btnCustomer.Text = "Customer";
            this.btnCustomer.UseVisualStyleBackColor = false;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnMaterial
            // 
            this.btnMaterial.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnMaterial.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnMaterial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaterial.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaterial.ForeColor = System.Drawing.Color.White;
            this.btnMaterial.Location = new System.Drawing.Point(1223, 9);
            this.btnMaterial.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnMaterial.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnMaterial.Name = "btnMaterial";
            this.btnMaterial.Padding = new System.Windows.Forms.Padding(3);
            this.btnMaterial.Size = new System.Drawing.Size(146, 30);
            this.btnMaterial.TabIndex = 36;
            this.btnMaterial.Text = "Material Settings";
            this.btnMaterial.UseVisualStyleBackColor = false;
            this.btnMaterial.Click += new System.EventHandler(this.btnMaterial_Click);
            // 
            // btnSupplier
            // 
            this.btnSupplier.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSupplier.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupplier.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupplier.ForeColor = System.Drawing.Color.White;
            this.btnSupplier.Location = new System.Drawing.Point(1059, 9);
            this.btnSupplier.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnSupplier.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Padding = new System.Windows.Forms.Padding(3);
            this.btnSupplier.Size = new System.Drawing.Size(154, 30);
            this.btnSupplier.TabIndex = 35;
            this.btnSupplier.Text = "Material Suppliers";
            this.btnSupplier.UseVisualStyleBackColor = false;
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // btnEmail
            // 
            this.btnEmail.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnEmail.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmail.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmail.ForeColor = System.Drawing.Color.White;
            this.btnEmail.Location = new System.Drawing.Point(903, 9);
            this.btnEmail.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnEmail.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Padding = new System.Windows.Forms.Padding(3);
            this.btnEmail.Size = new System.Drawing.Size(146, 30);
            this.btnEmail.TabIndex = 34;
            this.btnEmail.Text = "Excel Report";
            this.btnEmail.UseVisualStyleBackColor = false;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(1685, 106);
            this.btnClear.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnClear.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnClear.Name = "btnClear";
            this.btnClear.Padding = new System.Windows.Forms.Padding(3);
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 33;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnLeads
            // 
            this.btnLeads.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnLeads.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnLeads.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeads.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeads.ForeColor = System.Drawing.Color.White;
            this.btnLeads.Location = new System.Drawing.Point(409, 9);
            this.btnLeads.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnLeads.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnLeads.Name = "btnLeads";
            this.btnLeads.Padding = new System.Windows.Forms.Padding(3);
            this.btnLeads.Size = new System.Drawing.Size(130, 30);
            this.btnLeads.TabIndex = 118;
            this.btnLeads.Text = "Leads";
            this.btnLeads.UseVisualStyleBackColor = false;
            this.btnLeads.Click += new System.EventHandler(this.btnLeads_Click);
            // 
            // btnryucxd
            // 
            this.btnryucxd.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnryucxd.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnryucxd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnryucxd.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnryucxd.ForeColor = System.Drawing.Color.White;
            this.btnryucxd.Location = new System.Drawing.Point(12, 645);
            this.btnryucxd.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnryucxd.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnryucxd.Name = "btnryucxd";
            this.btnryucxd.Padding = new System.Windows.Forms.Padding(3);
            this.btnryucxd.Size = new System.Drawing.Size(154, 30);
            this.btnryucxd.TabIndex = 119;
            this.btnryucxd.Text = "testing button";
            this.btnryucxd.UseVisualStyleBackColor = false;
            this.btnryucxd.Visible = false;
            this.btnryucxd.Click += new System.EventHandler(this.btnryucxd_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1901, 673);
            this.Controls.Add(this.btnryucxd);
            this.Controls.Add(this.btnLeads);
            this.Controls.Add(this.btnNewCustomers);
            this.Controls.Add(this.btnNonReturningEnquiries);
            this.Controls.Add(this.btnTurnoverDecline);
            this.Controls.Add(this.btnNonReturningCustomers);
            this.Controls.Add(this.btnCalendar);
            this.Controls.Add(this.buttonFormatting2);
            this.Controls.Add(this.btnAlert);
            this.Controls.Add(this.buttonFormatting1);
            this.Controls.Add(this.chkChasePriority);
            this.Controls.Add(this.btnManagementView);
            this.Controls.Add(this.dteChaseEnd);
            this.Controls.Add(this.dteChaseStart);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbChasedBy);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbChasingStatus);
            this.Controls.Add(this.btnOutstanding);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.btnTraditional);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.btnNewQuote);
            this.Controls.Add(this.btnCustomer);
            this.Controls.Add(this.btnMaterial);
            this.Controls.Add(this.btnSupplier);
            this.Controls.Add(this.btnEmail);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.dteEnd);
            this.Controls.Add(this.dteStart);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmbQuotedBy);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtQuoteRef);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbMaterial);
            this.Controls.Add(this.cmbSystem);
            this.Controls.Add(this.txtQuoteID);
            this.Controls.Add(this.lblTotalCost);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Price Log";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblTotalCost;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtQuoteID;
        private System.Windows.Forms.ComboBox cmbSystem;
        private System.Windows.Forms.ComboBox cmbMaterial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtQuoteRef;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbQuotedBy;
        private System.Windows.Forms.DateTimePicker dteEnd;
        private System.Windows.Forms.DateTimePicker dteStart;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private buttonFormatting btnClear;
        private buttonFormatting btnEmail;
        private buttonFormatting btnSupplier;
        private buttonFormatting btnMaterial;
        private buttonFormatting btnCustomer;
        private buttonFormatting btnNewQuote;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbType;
        private buttonFormatting btnTraditional;
        private buttonFormatting btnAdmin;
        private buttonFormatting btnOutstanding;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbChasingStatus;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbChasedBy;
        private System.Windows.Forms.DateTimePicker dteChaseEnd;
        private System.Windows.Forms.DateTimePicker dteChaseStart;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label15;
        private buttonFormatting btnManagementView;
        private System.Windows.Forms.CheckBox chkChasePriority;
        private buttonFormatting buttonFormatting1;
        private buttonFormatting btnAlert;
        private buttonFormatting buttonFormatting2;
        private buttonFormatting btnCalendar;
        private buttonFormatting btnNonReturningCustomers;
        private buttonFormatting btnTurnoverDecline;
        private buttonFormatting btnNonReturningEnquiries;
        private buttonFormatting btnNewCustomers;
        private buttonFormatting btnLeads;
        private buttonFormatting btnryucxd;
    }
}

