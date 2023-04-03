namespace PriceMaster
{
    partial class frmTraditional
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTraditional));
            this.dteEnd = new System.Windows.Forms.DateTimePicker();
            this.dteStart = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.txtQuoteID = new System.Windows.Forms.TextBox();
            this.lblTotalCost = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtItemCount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCustomerReference = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDeliveryAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtQuotedBy = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.chkChasePriority = new System.Windows.Forms.CheckBox();
            this.txtEnquiry = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.chkNonResponsive = new System.Windows.Forms.CheckBox();
            this.chkLeadTimeTooLong = new System.Windows.Forms.CheckBox();
            this.chkQuoteTookTooLong = new System.Windows.Forms.CheckBox();
            this.chkUnableToMeetSpec = new System.Windows.Forms.CheckBox();
            this.chkTooExpensive = new System.Windows.Forms.CheckBox();
            this.lblLossReasons = new System.Windows.Forms.Label();
            this.btnNonReturningCustomers = new PriceMaster.buttonFormatting();
            this.btnCustomer = new PriceMaster.buttonFormatting();
            this.btnManagementView = new PriceMaster.buttonFormatting();
            this.buttonFormatting1 = new PriceMaster.buttonFormatting();
            this.btnOutstanding = new PriceMaster.buttonFormatting();
            this.btnReport = new PriceMaster.buttonFormatting();
            this.btnClear = new PriceMaster.buttonFormatting();
            this.btnAlert = new PriceMaster.buttonFormatting();
            this.btnOutstandingCorrespondence = new PriceMaster.buttonFormatting();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dteEnd
            // 
            this.dteEnd.Location = new System.Drawing.Point(445, 118);
            this.dteEnd.Name = "dteEnd";
            this.dteEnd.Size = new System.Drawing.Size(121, 20);
            this.dteEnd.TabIndex = 62;
            this.dteEnd.ValueChanged += new System.EventHandler(this.dteEnd_ValueChanged);
            // 
            // dteStart
            // 
            this.dteStart.Location = new System.Drawing.Point(445, 82);
            this.dteStart.Name = "dteStart";
            this.dteStart.Size = new System.Drawing.Size(121, 20);
            this.dteStart.TabIndex = 61;
            this.dteStart.ValueChanged += new System.EventHandler(this.dteStart_ValueChanged);
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label13.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label13.Location = new System.Drawing.Point(442, 52);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(124, 23);
            this.label13.TabIndex = 60;
            this.label13.Text = "Quote Date";
            this.label13.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label14.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label14.Location = new System.Drawing.Point(441, 92);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(124, 23);
            this.label14.TabIndex = 63;
            this.label14.Text = "to";
            this.label14.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label3.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label3.Location = new System.Drawing.Point(690, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 23);
            this.label3.TabIndex = 49;
            this.label3.Text = "Customer";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label1.Location = new System.Drawing.Point(327, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 23);
            this.label1.TabIndex = 48;
            this.label1.Text = "Quote ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(690, 117);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(198, 21);
            this.cmbCustomer.TabIndex = 45;
            this.cmbCustomer.SelectedIndexChanged += new System.EventHandler(this.cmbCustomer_SelectedIndexChanged);
            // 
            // txtQuoteID
            // 
            this.txtQuoteID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtQuoteID.Location = new System.Drawing.Point(327, 117);
            this.txtQuoteID.Name = "txtQuoteID";
            this.txtQuoteID.Size = new System.Drawing.Size(112, 21);
            this.txtQuoteID.TabIndex = 44;
            this.txtQuoteID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuoteID_KeyDown);
            this.txtQuoteID.Leave += new System.EventHandler(this.txtQuoteID_Leave);
            // 
            // lblTotalCost
            // 
            this.lblTotalCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblTotalCost.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblTotalCost.Location = new System.Drawing.Point(1225, 645);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(664, 23);
            this.lblTotalCost.TabIndex = 42;
            this.lblTotalCost.Text = "label1";
            this.lblTotalCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.dataGridView1.Location = new System.Drawing.Point(12, 143);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1877, 499);
            this.dataGridView1.TabIndex = 41;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(284, 114);
            this.pictureBox1.TabIndex = 43;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label2.Location = new System.Drawing.Point(572, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 23);
            this.label2.TabIndex = 71;
            this.label2.Text = "Item Count";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // txtItemCount
            // 
            this.txtItemCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtItemCount.Location = new System.Drawing.Point(572, 117);
            this.txtItemCount.Name = "txtItemCount";
            this.txtItemCount.Size = new System.Drawing.Size(112, 21);
            this.txtItemCount.TabIndex = 70;
            this.txtItemCount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemCount_KeyDown);
            this.txtItemCount.Leave += new System.EventHandler(this.txtItemCount_Leave);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label4.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label4.Location = new System.Drawing.Point(894, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 23);
            this.label4.TabIndex = 73;
            this.label4.Text = "Customer Reference";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // txtCustomerReference
            // 
            this.txtCustomerReference.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtCustomerReference.Location = new System.Drawing.Point(894, 117);
            this.txtCustomerReference.Name = "txtCustomerReference";
            this.txtCustomerReference.Size = new System.Drawing.Size(163, 21);
            this.txtCustomerReference.TabIndex = 72;
            this.txtCustomerReference.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomerReference_KeyDown);
            this.txtCustomerReference.Leave += new System.EventHandler(this.txtCustomerReference_Leave);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label5.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label5.Location = new System.Drawing.Point(1196, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 23);
            this.label5.TabIndex = 75;
            this.label5.Text = "Delivery Address";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // txtDeliveryAddress
            // 
            this.txtDeliveryAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtDeliveryAddress.Location = new System.Drawing.Point(1196, 117);
            this.txtDeliveryAddress.Name = "txtDeliveryAddress";
            this.txtDeliveryAddress.Size = new System.Drawing.Size(126, 21);
            this.txtDeliveryAddress.TabIndex = 74;
            this.txtDeliveryAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDeliveryAddress_KeyDown);
            this.txtDeliveryAddress.Leave += new System.EventHandler(this.txtDeliveryAddress_Leave);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label6.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label6.Location = new System.Drawing.Point(1328, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 23);
            this.label6.TabIndex = 77;
            this.label6.Text = "Value";
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // txtValue
            // 
            this.txtValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtValue.Location = new System.Drawing.Point(1328, 117);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(126, 21);
            this.txtValue.TabIndex = 76;
            this.txtValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtValue_KeyDown);
            this.txtValue.Leave += new System.EventHandler(this.txtValue_Leave);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label7.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label7.Location = new System.Drawing.Point(1063, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 23);
            this.label7.TabIndex = 79;
            this.label7.Text = "Quoted by";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // txtQuotedBy
            // 
            this.txtQuotedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtQuotedBy.Location = new System.Drawing.Point(1063, 117);
            this.txtQuotedBy.Name = "txtQuotedBy";
            this.txtQuotedBy.Size = new System.Drawing.Size(126, 21);
            this.txtQuotedBy.TabIndex = 78;
            this.txtQuotedBy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuotedBy_KeyDown);
            this.txtQuotedBy.Leave += new System.EventHandler(this.txtQuotedBy_Leave);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label8.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label8.Location = new System.Drawing.Point(1460, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 23);
            this.label8.TabIndex = 82;
            this.label8.Text = "Status";
            this.label8.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cmbStatus
            // 
            this.cmbStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Pending",
            "Chasing",
            "Won",
            "Lost"});
            this.cmbStatus.Location = new System.Drawing.Point(1460, 116);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(133, 21);
            this.cmbStatus.TabIndex = 81;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // chkChasePriority
            // 
            this.chkChasePriority.AutoSize = true;
            this.chkChasePriority.BackColor = System.Drawing.Color.LightSkyBlue;
            this.chkChasePriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.chkChasePriority.Location = new System.Drawing.Point(327, 64);
            this.chkChasePriority.Name = "chkChasePriority";
            this.chkChasePriority.Size = new System.Drawing.Size(109, 20);
            this.chkChasePriority.TabIndex = 99;
            this.chkChasePriority.Text = "Priority Chase";
            this.chkChasePriority.UseVisualStyleBackColor = false;
            this.chkChasePriority.CheckedChanged += new System.EventHandler(this.chkChasePriority_CheckedChanged);
            // 
            // txtEnquiry
            // 
            this.txtEnquiry.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtEnquiry.Location = new System.Drawing.Point(1599, 116);
            this.txtEnquiry.Name = "txtEnquiry";
            this.txtEnquiry.Size = new System.Drawing.Size(126, 21);
            this.txtEnquiry.TabIndex = 100;
            this.txtEnquiry.TextChanged += new System.EventHandler(this.txtEnquiry_TextChanged);
            this.txtEnquiry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEnquiry_KeyDown);
            this.txtEnquiry.Leave += new System.EventHandler(this.txtEnquiry_Leave);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label9.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label9.Location = new System.Drawing.Point(1599, 89);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 23);
            this.label9.TabIndex = 101;
            this.label9.Text = "Enquiry ID";
            this.label9.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // chkNonResponsive
            // 
            this.chkNonResponsive.AutoSize = true;
            this.chkNonResponsive.Location = new System.Drawing.Point(1427, 80);
            this.chkNonResponsive.Name = "chkNonResponsive";
            this.chkNonResponsive.Size = new System.Drawing.Size(152, 17);
            this.chkNonResponsive.TabIndex = 106;
            this.chkNonResponsive.Text = "Non Responsive Customer";
            this.chkNonResponsive.UseVisualStyleBackColor = true;
            this.chkNonResponsive.Visible = false;
            this.chkNonResponsive.CheckedChanged += new System.EventHandler(this.chkNonResponsive_CheckedChanged);
            // 
            // chkLeadTimeTooLong
            // 
            this.chkLeadTimeTooLong.AutoSize = true;
            this.chkLeadTimeTooLong.Location = new System.Drawing.Point(1558, 30);
            this.chkLeadTimeTooLong.Name = "chkLeadTimeTooLong";
            this.chkLeadTimeTooLong.Size = new System.Drawing.Size(116, 17);
            this.chkLeadTimeTooLong.TabIndex = 105;
            this.chkLeadTimeTooLong.Text = "Lead time too long.";
            this.chkLeadTimeTooLong.UseVisualStyleBackColor = true;
            this.chkLeadTimeTooLong.Visible = false;
            this.chkLeadTimeTooLong.CheckedChanged += new System.EventHandler(this.chkLeadTimeTooLong_CheckedChanged);
            // 
            // chkQuoteTookTooLong
            // 
            this.chkQuoteTookTooLong.AutoSize = true;
            this.chkQuoteTookTooLong.Location = new System.Drawing.Point(1427, 55);
            this.chkQuoteTookTooLong.Name = "chkQuoteTookTooLong";
            this.chkQuoteTookTooLong.Size = new System.Drawing.Size(123, 17);
            this.chkQuoteTookTooLong.TabIndex = 104;
            this.chkQuoteTookTooLong.Text = "Quote took too long.";
            this.chkQuoteTookTooLong.UseVisualStyleBackColor = true;
            this.chkQuoteTookTooLong.Visible = false;
            this.chkQuoteTookTooLong.CheckedChanged += new System.EventHandler(this.chkQuoteTookTooLong_CheckedChanged);
            // 
            // chkUnableToMeetSpec
            // 
            this.chkUnableToMeetSpec.AutoSize = true;
            this.chkUnableToMeetSpec.Location = new System.Drawing.Point(1558, 55);
            this.chkUnableToMeetSpec.Name = "chkUnableToMeetSpec";
            this.chkUnableToMeetSpec.Size = new System.Drawing.Size(127, 17);
            this.chkUnableToMeetSpec.TabIndex = 103;
            this.chkUnableToMeetSpec.Text = "Unable to meet spec.";
            this.chkUnableToMeetSpec.UseVisualStyleBackColor = true;
            this.chkUnableToMeetSpec.Visible = false;
            this.chkUnableToMeetSpec.CheckedChanged += new System.EventHandler(this.chkUnableToMeetSpec_CheckedChanged);
            // 
            // chkTooExpensive
            // 
            this.chkTooExpensive.AutoSize = true;
            this.chkTooExpensive.Location = new System.Drawing.Point(1427, 30);
            this.chkTooExpensive.Name = "chkTooExpensive";
            this.chkTooExpensive.Size = new System.Drawing.Size(99, 17);
            this.chkTooExpensive.TabIndex = 102;
            this.chkTooExpensive.Text = "Too expensive.";
            this.chkTooExpensive.UseVisualStyleBackColor = true;
            this.chkTooExpensive.Visible = false;
            this.chkTooExpensive.CheckedChanged += new System.EventHandler(this.chkTooExpensive_CheckedChanged);
            // 
            // lblLossReasons
            // 
            this.lblLossReasons.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblLossReasons.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblLossReasons.Location = new System.Drawing.Point(1424, 4);
            this.lblLossReasons.Name = "lblLossReasons";
            this.lblLossReasons.Size = new System.Drawing.Size(250, 23);
            this.lblLossReasons.TabIndex = 107;
            this.lblLossReasons.Text = "Loss Reasons";
            this.lblLossReasons.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblLossReasons.Visible = false;
            // 
            // btnNonReturningCustomers
            // 
            this.btnNonReturningCustomers.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnNonReturningCustomers.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnNonReturningCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNonReturningCustomers.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNonReturningCustomers.ForeColor = System.Drawing.Color.White;
            this.btnNonReturningCustomers.Location = new System.Drawing.Point(1133, 9);
            this.btnNonReturningCustomers.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnNonReturningCustomers.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnNonReturningCustomers.Name = "btnNonReturningCustomers";
            this.btnNonReturningCustomers.Padding = new System.Windows.Forms.Padding(3);
            this.btnNonReturningCustomers.Size = new System.Drawing.Size(208, 30);
            this.btnNonReturningCustomers.TabIndex = 109;
            this.btnNonReturningCustomers.Text = "Non Returning Customers";
            this.btnNonReturningCustomers.UseVisualStyleBackColor = false;
            this.btnNonReturningCustomers.Click += new System.EventHandler(this.btnNonReturningCustomers_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnCustomer.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomer.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomer.ForeColor = System.Drawing.Color.White;
            this.btnCustomer.Location = new System.Drawing.Point(788, 45);
            this.btnCustomer.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnCustomer.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Padding = new System.Windows.Forms.Padding(3);
            this.btnCustomer.Size = new System.Drawing.Size(221, 30);
            this.btnCustomer.TabIndex = 108;
            this.btnCustomer.Text = "Customer Correspondence";
            this.btnCustomer.UseVisualStyleBackColor = false;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnManagementView
            // 
            this.btnManagementView.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnManagementView.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnManagementView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManagementView.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManagementView.ForeColor = System.Drawing.Color.White;
            this.btnManagementView.Location = new System.Drawing.Point(610, 12);
            this.btnManagementView.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnManagementView.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnManagementView.Name = "btnManagementView";
            this.btnManagementView.Padding = new System.Windows.Forms.Padding(3);
            this.btnManagementView.Size = new System.Drawing.Size(154, 30);
            this.btnManagementView.TabIndex = 98;
            this.btnManagementView.Text = "Management View";
            this.btnManagementView.UseVisualStyleBackColor = false;
            this.btnManagementView.Click += new System.EventHandler(this.btnManagementView_Click);
            // 
            // buttonFormatting1
            // 
            this.buttonFormatting1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonFormatting1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonFormatting1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFormatting1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFormatting1.ForeColor = System.Drawing.Color.White;
            this.buttonFormatting1.Location = new System.Drawing.Point(314, 9);
            this.buttonFormatting1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.buttonFormatting1.MinimumSize = new System.Drawing.Size(75, 30);
            this.buttonFormatting1.Name = "buttonFormatting1";
            this.buttonFormatting1.Padding = new System.Windows.Forms.Padding(3);
            this.buttonFormatting1.Size = new System.Drawing.Size(75, 30);
            this.buttonFormatting1.TabIndex = 84;
            this.buttonFormatting1.Text = "All Outstanding Chases";
            this.buttonFormatting1.UseVisualStyleBackColor = false;
            this.buttonFormatting1.Visible = false;
            this.buttonFormatting1.Click += new System.EventHandler(this.buttonFormatting1_Click);
            // 
            // btnOutstanding
            // 
            this.btnOutstanding.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnOutstanding.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnOutstanding.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOutstanding.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOutstanding.ForeColor = System.Drawing.Color.White;
            this.btnOutstanding.Location = new System.Drawing.Point(944, 9);
            this.btnOutstanding.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnOutstanding.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnOutstanding.Name = "btnOutstanding";
            this.btnOutstanding.Padding = new System.Windows.Forms.Padding(3);
            this.btnOutstanding.Size = new System.Drawing.Size(179, 30);
            this.btnOutstanding.TabIndex = 83;
            this.btnOutstanding.Text = "Outstanding Chases";
            this.btnOutstanding.UseVisualStyleBackColor = false;
            this.btnOutstanding.Click += new System.EventHandler(this.btnOutstanding_Click);
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnReport.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.ForeColor = System.Drawing.Color.White;
            this.btnReport.Location = new System.Drawing.Point(788, 9);
            this.btnReport.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnReport.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnReport.Name = "btnReport";
            this.btnReport.Padding = new System.Windows.Forms.Padding(3);
            this.btnReport.Size = new System.Drawing.Size(146, 30);
            this.btnReport.TabIndex = 80;
            this.btnReport.Text = "Export Report";
            this.btnReport.UseVisualStyleBackColor = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(1733, 107);
            this.btnClear.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnClear.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnClear.Name = "btnClear";
            this.btnClear.Padding = new System.Windows.Forms.Padding(3);
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 64;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAlert
            // 
            this.btnAlert.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnAlert.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAlert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlert.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlert.ForeColor = System.Drawing.Color.White;
            this.btnAlert.Location = new System.Drawing.Point(610, 45);
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
            // btnOutstandingCorrespondence
            // 
            this.btnOutstandingCorrespondence.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnOutstandingCorrespondence.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnOutstandingCorrespondence.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOutstandingCorrespondence.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOutstandingCorrespondence.ForeColor = System.Drawing.Color.White;
            this.btnOutstandingCorrespondence.Location = new System.Drawing.Point(1019, 45);
            this.btnOutstandingCorrespondence.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnOutstandingCorrespondence.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnOutstandingCorrespondence.Name = "btnOutstandingCorrespondence";
            this.btnOutstandingCorrespondence.Padding = new System.Windows.Forms.Padding(3);
            this.btnOutstandingCorrespondence.Size = new System.Drawing.Size(238, 30);
            this.btnOutstandingCorrespondence.TabIndex = 111;
            this.btnOutstandingCorrespondence.Text = "Outstanding  Correspondence";
            this.btnOutstandingCorrespondence.UseVisualStyleBackColor = false;
            this.btnOutstandingCorrespondence.Click += new System.EventHandler(this.btnOutstandingCorrespondence_Click);
            // 
            // frmTraditional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1901, 673);
            this.Controls.Add(this.btnOutstandingCorrespondence);
            this.Controls.Add(this.btnAlert);
            this.Controls.Add(this.btnNonReturningCustomers);
            this.Controls.Add(this.btnCustomer);
            this.Controls.Add(this.lblLossReasons);
            this.Controls.Add(this.chkNonResponsive);
            this.Controls.Add(this.chkLeadTimeTooLong);
            this.Controls.Add(this.chkQuoteTookTooLong);
            this.Controls.Add(this.chkUnableToMeetSpec);
            this.Controls.Add(this.chkTooExpensive);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtEnquiry);
            this.Controls.Add(this.chkChasePriority);
            this.Controls.Add(this.btnManagementView);
            this.Controls.Add(this.buttonFormatting1);
            this.Controls.Add(this.btnOutstanding);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtQuotedBy);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDeliveryAddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCustomerReference);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtItemCount);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.dteEnd);
            this.Controls.Add(this.dteStart);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.txtQuoteID);
            this.Controls.Add(this.lblTotalCost);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTraditional";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Traditional Quote Log";
            this.Shown += new System.EventHandler(this.frmTraditional_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private buttonFormatting btnClear;
        private System.Windows.Forms.DateTimePicker dteEnd;
        private System.Windows.Forms.DateTimePicker dteStart;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.TextBox txtQuoteID;
        private System.Windows.Forms.Label lblTotalCost;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtItemCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCustomerReference;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDeliveryAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtQuotedBy;
        private buttonFormatting btnReport;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbStatus;
        private buttonFormatting btnOutstanding;
        private buttonFormatting buttonFormatting1;
        private buttonFormatting btnManagementView;
        private System.Windows.Forms.CheckBox chkChasePriority;
        private System.Windows.Forms.TextBox txtEnquiry;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkNonResponsive;
        private System.Windows.Forms.CheckBox chkLeadTimeTooLong;
        private System.Windows.Forms.CheckBox chkQuoteTookTooLong;
        private System.Windows.Forms.CheckBox chkUnableToMeetSpec;
        private System.Windows.Forms.CheckBox chkTooExpensive;
        private System.Windows.Forms.Label lblLossReasons;
        private buttonFormatting btnCustomer;
        private buttonFormatting btnNonReturningCustomers;
        private buttonFormatting btnAlert;
        private buttonFormatting btnOutstandingCorrespondence;
    }
}