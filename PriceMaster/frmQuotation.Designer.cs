namespace PriceMaster
{
    partial class frmQuotation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuotation));
            this.txtQuoteRef = new System.Windows.Forms.TextBox();
            this.txtCustomerContact = new System.Windows.Forms.TextBox();
            this.txtCustomerEmail = new System.Windows.Forms.TextBox();
            this.txtFittingQuote = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtSupplierRef = new System.Windows.Forms.TextBox();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.cmbPriority = new System.Windows.Forms.ComboBox();
            this.cmbQuotedBy = new System.Windows.Forms.ComboBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.cmbLoss = new System.Windows.Forms.ComboBox();
            this.cmbMatieralType = new System.Windows.Forms.ComboBox();
            this.cmbMatieralSupplier = new System.Windows.Forms.ComboBox();
            this.cmbSys1 = new System.Windows.Forms.ComboBox();
            this.cmbSys2 = new System.Windows.Forms.ComboBox();
            this.cmbSys3 = new System.Windows.Forms.ComboBox();
            this.cmbSys4 = new System.Windows.Forms.ComboBox();
            this.cmbSys5 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.chkFollowUp = new System.Windows.Forms.CheckBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.RichTextBox();
            this.dteFollowUp = new System.Windows.Forms.DateTimePicker();
            this.cmbIssue = new System.Windows.Forms.ComboBox();
            this.txtFollowUp = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label22 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dteQuoteDate = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtEnquiry = new System.Windows.Forms.TextBox();
            this.btnEnquiry = new PriceMaster.buttonFormatting();
            this.btnAttachments = new PriceMaster.buttonFormatting();
            this.btnAddNote = new PriceMaster.buttonFormatting();
            this.btnViewQuote = new PriceMaster.buttonFormatting();
            this.btnRevise = new PriceMaster.buttonFormatting();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtQuoteRef
            // 
            this.txtQuoteRef.Location = new System.Drawing.Point(97, 168);
            this.txtQuoteRef.Name = "txtQuoteRef";
            this.txtQuoteRef.Size = new System.Drawing.Size(206, 20);
            this.txtQuoteRef.TabIndex = 0;
            this.txtQuoteRef.TextChanged += new System.EventHandler(this.txtQuoteRef_TextChanged);
            this.txtQuoteRef.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuoteRef_KeyDown);
            this.txtQuoteRef.Leave += new System.EventHandler(this.txtQuoteRef_Leave);
            // 
            // txtCustomerContact
            // 
            this.txtCustomerContact.Location = new System.Drawing.Point(97, 201);
            this.txtCustomerContact.Name = "txtCustomerContact";
            this.txtCustomerContact.Size = new System.Drawing.Size(206, 20);
            this.txtCustomerContact.TabIndex = 1;
            this.txtCustomerContact.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomerContact_KeyDown);
            this.txtCustomerContact.Leave += new System.EventHandler(this.txtCustomerContact_Leave);
            // 
            // txtCustomerEmail
            // 
            this.txtCustomerEmail.Location = new System.Drawing.Point(97, 234);
            this.txtCustomerEmail.Name = "txtCustomerEmail";
            this.txtCustomerEmail.Size = new System.Drawing.Size(206, 20);
            this.txtCustomerEmail.TabIndex = 2;
            this.txtCustomerEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomerEmail_KeyDown);
            this.txtCustomerEmail.Leave += new System.EventHandler(this.txtCustomerEmail_Leave);
            // 
            // txtFittingQuote
            // 
            this.txtFittingQuote.Location = new System.Drawing.Point(97, 267);
            this.txtFittingQuote.Name = "txtFittingQuote";
            this.txtFittingQuote.Size = new System.Drawing.Size(206, 20);
            this.txtFittingQuote.TabIndex = 3;
            this.txtFittingQuote.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFittingQuote_KeyDown);
            this.txtFittingQuote.Leave += new System.EventHandler(this.txtFittingQuote_Leave);
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(97, 300);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(206, 20);
            this.txtPrice.TabIndex = 4;
            this.txtPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPrice_KeyDown);
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            this.txtPrice.Leave += new System.EventHandler(this.txtPrice_Leave);
            // 
            // txtSupplierRef
            // 
            this.txtSupplierRef.Location = new System.Drawing.Point(409, 296);
            this.txtSupplierRef.Name = "txtSupplierRef";
            this.txtSupplierRef.Size = new System.Drawing.Size(206, 20);
            this.txtSupplierRef.TabIndex = 7;
            this.txtSupplierRef.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSupplierRef_KeyDown);
            this.txtSupplierRef.Leave += new System.EventHandler(this.txtSupplierRef_Leave);
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(97, 134);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(206, 21);
            this.cmbCustomer.TabIndex = 8;
            this.cmbCustomer.SelectedIndexChanged += new System.EventHandler(this.cmbCustomer_SelectedIndexChanged);
            // 
            // cmbPriority
            // 
            this.cmbPriority.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbPriority.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPriority.FormattingEnabled = true;
            this.cmbPriority.Location = new System.Drawing.Point(97, 333);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(206, 21);
            this.cmbPriority.TabIndex = 9;
            this.cmbPriority.SelectedIndexChanged += new System.EventHandler(this.cmbPriority_SelectedIndexChanged);
            // 
            // cmbQuotedBy
            // 
            this.cmbQuotedBy.Enabled = false;
            this.cmbQuotedBy.FormattingEnabled = true;
            this.cmbQuotedBy.Location = new System.Drawing.Point(97, 367);
            this.cmbQuotedBy.Name = "cmbQuotedBy";
            this.cmbQuotedBy.Size = new System.Drawing.Size(206, 21);
            this.cmbQuotedBy.TabIndex = 10;
            this.cmbQuotedBy.SelectedIndexChanged += new System.EventHandler(this.cmbQuotedBy_SelectedIndexChanged);
            // 
            // cmbStatus
            // 
            this.cmbStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(409, 163);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(206, 21);
            this.cmbStatus.TabIndex = 11;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // cmbLoss
            // 
            this.cmbLoss.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbLoss.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbLoss.FormattingEnabled = true;
            this.cmbLoss.Location = new System.Drawing.Point(409, 196);
            this.cmbLoss.Name = "cmbLoss";
            this.cmbLoss.Size = new System.Drawing.Size(206, 21);
            this.cmbLoss.TabIndex = 12;
            this.cmbLoss.SelectedIndexChanged += new System.EventHandler(this.cmbLoss_SelectedIndexChanged);
            // 
            // cmbMatieralType
            // 
            this.cmbMatieralType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbMatieralType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMatieralType.FormattingEnabled = true;
            this.cmbMatieralType.Location = new System.Drawing.Point(409, 229);
            this.cmbMatieralType.Name = "cmbMatieralType";
            this.cmbMatieralType.Size = new System.Drawing.Size(206, 21);
            this.cmbMatieralType.TabIndex = 13;
            this.cmbMatieralType.SelectedIndexChanged += new System.EventHandler(this.cmbMatieralType_SelectedIndexChanged);
            // 
            // cmbMatieralSupplier
            // 
            this.cmbMatieralSupplier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbMatieralSupplier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMatieralSupplier.FormattingEnabled = true;
            this.cmbMatieralSupplier.Location = new System.Drawing.Point(409, 262);
            this.cmbMatieralSupplier.Name = "cmbMatieralSupplier";
            this.cmbMatieralSupplier.Size = new System.Drawing.Size(206, 21);
            this.cmbMatieralSupplier.TabIndex = 14;
            this.cmbMatieralSupplier.SelectedIndexChanged += new System.EventHandler(this.cmbMatieralSupplier_SelectedIndexChanged);
            // 
            // cmbSys1
            // 
            this.cmbSys1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbSys1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSys1.FormattingEnabled = true;
            this.cmbSys1.Location = new System.Drawing.Point(409, 328);
            this.cmbSys1.Name = "cmbSys1";
            this.cmbSys1.Size = new System.Drawing.Size(206, 21);
            this.cmbSys1.TabIndex = 15;
            this.cmbSys1.SelectedIndexChanged += new System.EventHandler(this.cmbSys1_SelectedIndexChanged);
            // 
            // cmbSys2
            // 
            this.cmbSys2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbSys2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSys2.FormattingEnabled = true;
            this.cmbSys2.Location = new System.Drawing.Point(409, 362);
            this.cmbSys2.Name = "cmbSys2";
            this.cmbSys2.Size = new System.Drawing.Size(206, 21);
            this.cmbSys2.TabIndex = 16;
            this.cmbSys2.SelectedIndexChanged += new System.EventHandler(this.cmbSys2_SelectedIndexChanged);
            // 
            // cmbSys3
            // 
            this.cmbSys3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbSys3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSys3.FormattingEnabled = true;
            this.cmbSys3.Location = new System.Drawing.Point(409, 396);
            this.cmbSys3.Name = "cmbSys3";
            this.cmbSys3.Size = new System.Drawing.Size(206, 21);
            this.cmbSys3.TabIndex = 17;
            this.cmbSys3.SelectedIndexChanged += new System.EventHandler(this.cmbSys3_SelectedIndexChanged);
            // 
            // cmbSys4
            // 
            this.cmbSys4.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbSys4.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSys4.FormattingEnabled = true;
            this.cmbSys4.Location = new System.Drawing.Point(409, 429);
            this.cmbSys4.Name = "cmbSys4";
            this.cmbSys4.Size = new System.Drawing.Size(206, 21);
            this.cmbSys4.TabIndex = 18;
            this.cmbSys4.SelectedIndexChanged += new System.EventHandler(this.cmbSys4_SelectedIndexChanged);
            // 
            // cmbSys5
            // 
            this.cmbSys5.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbSys5.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSys5.FormattingEnabled = true;
            this.cmbSys5.Location = new System.Drawing.Point(409, 462);
            this.cmbSys5.Name = "cmbSys5";
            this.cmbSys5.Size = new System.Drawing.Size(206, 21);
            this.cmbSys5.TabIndex = 19;
            this.cmbSys5.SelectedIndexChanged += new System.EventHandler(this.cmbSys5_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-15, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 21);
            this.label1.TabIndex = 20;
            this.label1.Text = "Customer:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(-15, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 21);
            this.label2.TabIndex = 21;
            this.label2.Text = "Quotation Ref:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(-15, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 21);
            this.label3.TabIndex = 22;
            this.label3.Text = "Customer Contact";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(-15, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 21);
            this.label4.TabIndex = 23;
            this.label4.Text = "Customer Email:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(-15, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 21);
            this.label5.TabIndex = 24;
            this.label5.Text = "Fitting Quote";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(-15, 300);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 21);
            this.label6.TabIndex = 25;
            this.label6.Text = "Price:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(-15, 333);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 21);
            this.label7.TabIndex = 26;
            this.label7.Text = "Priority:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(-15, 367);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 21);
            this.label8.TabIndex = 27;
            this.label8.Text = "Quoted By:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(-15, 462);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 21);
            this.label9.TabIndex = 28;
            this.label9.Text = "Follow up Date:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(-15, 400);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 21);
            this.label10.TabIndex = 29;
            this.label10.Text = "Quote Date:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(318, 163);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 21);
            this.label11.TabIndex = 30;
            this.label11.Text = "Status:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(310, 196);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 21);
            this.label12.TabIndex = 31;
            this.label12.Text = "Reason For Loss:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(310, 229);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(93, 21);
            this.label13.TabIndex = 32;
            this.label13.Text = "Material Type:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(310, 262);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(93, 21);
            this.label14.TabIndex = 33;
            this.label14.Text = "Material Supplier:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(310, 296);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(93, 21);
            this.label15.TabIndex = 34;
            this.label15.Text = "Supplier Ref:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(310, 328);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(93, 21);
            this.label16.TabIndex = 35;
            this.label16.Text = "System Type 1:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(310, 362);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(93, 21);
            this.label17.TabIndex = 36;
            this.label17.Text = "System Type 2:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(310, 396);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(93, 21);
            this.label18.TabIndex = 37;
            this.label18.Text = "System Type 3:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(310, 429);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(93, 21);
            this.label19.TabIndex = 38;
            this.label19.Text = "System Type 4:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(310, 462);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(93, 21);
            this.label20.TabIndex = 39;
            this.label20.Text = "System Type 5:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkFollowUp
            // 
            this.chkFollowUp.AutoSize = true;
            this.chkFollowUp.Location = new System.Drawing.Point(201, 433);
            this.chkFollowUp.Name = "chkFollowUp";
            this.chkFollowUp.Size = new System.Drawing.Size(15, 14);
            this.chkFollowUp.TabIndex = 40;
            this.chkFollowUp.UseVisualStyleBackColor = true;
            this.chkFollowUp.CheckedChanged += new System.EventHandler(this.chkFollowUp_CheckedChanged);
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(-15, 433);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(106, 21);
            this.label21.TabIndex = 41;
            this.label21.Text = "Chased/Followed up:";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNote
            // 
            this.txtNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtNote.Location = new System.Drawing.Point(12, 538);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(603, 207);
            this.txtNote.TabIndex = 42;
            this.txtNote.Text = "";
            // 
            // dteFollowUp
            // 
            this.dteFollowUp.Location = new System.Drawing.Point(280, 463);
            this.dteFollowUp.Name = "dteFollowUp";
            this.dteFollowUp.Size = new System.Drawing.Size(23, 20);
            this.dteFollowUp.TabIndex = 45;
            this.dteFollowUp.ValueChanged += new System.EventHandler(this.dteFollowUp_ValueChanged);
            // 
            // cmbIssue
            // 
            this.cmbIssue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.cmbIssue.FormattingEnabled = true;
            this.cmbIssue.Location = new System.Drawing.Point(320, 71);
            this.cmbIssue.Name = "cmbIssue";
            this.cmbIssue.Size = new System.Drawing.Size(52, 25);
            this.cmbIssue.TabIndex = 48;
            this.cmbIssue.SelectedIndexChanged += new System.EventHandler(this.cmbIssue_SelectedIndexChanged);
            // 
            // txtFollowUp
            // 
            this.txtFollowUp.Location = new System.Drawing.Point(97, 463);
            this.txtFollowUp.Name = "txtFollowUp";
            this.txtFollowUp.Size = new System.Drawing.Size(189, 20);
            this.txtFollowUp.TabIndex = 50;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(-6, -15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(228, 143);
            this.pictureBox1.TabIndex = 52;
            this.pictureBox1.TabStop = false;
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label22.Location = new System.Drawing.Point(208, 70);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(106, 21);
            this.label22.TabIndex = 53;
            this.label22.Text = "Issue:";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.lblTitle.Location = new System.Drawing.Point(211, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(208, 38);
            this.lblTitle.TabIndex = 54;
            this.lblTitle.Text = "Quote 7879";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dteQuoteDate
            // 
            this.dteQuoteDate.Enabled = false;
            this.dteQuoteDate.Location = new System.Drawing.Point(97, 400);
            this.dteQuoteDate.Name = "dteQuoteDate";
            this.dteQuoteDate.Size = new System.Drawing.Size(206, 20);
            this.dteQuoteDate.TabIndex = 56;
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(318, 134);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(85, 21);
            this.label23.TabIndex = 59;
            this.label23.Text = "EnquiryID:";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEnquiry
            // 
            this.txtEnquiry.Location = new System.Drawing.Point(409, 134);
            this.txtEnquiry.Name = "txtEnquiry";
            this.txtEnquiry.Size = new System.Drawing.Size(149, 20);
            this.txtEnquiry.TabIndex = 60;
            this.txtEnquiry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEnquiry_KeyDown);
            this.txtEnquiry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEnquiry_KeyPress);
            this.txtEnquiry.Leave += new System.EventHandler(this.txtEnquiry_Leave);
            // 
            // btnEnquiry
            // 
            this.btnEnquiry.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnEnquiry.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnEnquiry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnquiry.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnquiry.ForeColor = System.Drawing.Color.White;
            this.btnEnquiry.Location = new System.Drawing.Point(561, 130);
            this.btnEnquiry.Margin = new System.Windows.Forms.Padding(0);
            this.btnEnquiry.MinimumSize = new System.Drawing.Size(50, 25);
            this.btnEnquiry.Name = "btnEnquiry";
            this.btnEnquiry.Padding = new System.Windows.Forms.Padding(3);
            this.btnEnquiry.Size = new System.Drawing.Size(54, 28);
            this.btnEnquiry.TabIndex = 61;
            this.btnEnquiry.Text = "OPEN";
            this.btnEnquiry.UseVisualStyleBackColor = false;
            this.btnEnquiry.Click += new System.EventHandler(this.btnEnquiry_Click);
            // 
            // btnAttachments
            // 
            this.btnAttachments.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnAttachments.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAttachments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAttachments.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttachments.ForeColor = System.Drawing.Color.White;
            this.btnAttachments.Location = new System.Drawing.Point(461, 89);
            this.btnAttachments.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnAttachments.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnAttachments.Name = "btnAttachments";
            this.btnAttachments.Padding = new System.Windows.Forms.Padding(3);
            this.btnAttachments.Size = new System.Drawing.Size(123, 30);
            this.btnAttachments.TabIndex = 57;
            this.btnAttachments.Text = "Attachments";
            this.btnAttachments.UseVisualStyleBackColor = false;
            this.btnAttachments.Click += new System.EventHandler(this.btnAttachments_Click);
            // 
            // btnAddNote
            // 
            this.btnAddNote.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnAddNote.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAddNote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNote.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNote.ForeColor = System.Drawing.Color.White;
            this.btnAddNote.Location = new System.Drawing.Point(16, 505);
            this.btnAddNote.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnAddNote.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnAddNote.Name = "btnAddNote";
            this.btnAddNote.Padding = new System.Windows.Forms.Padding(3);
            this.btnAddNote.Size = new System.Drawing.Size(107, 30);
            this.btnAddNote.TabIndex = 55;
            this.btnAddNote.Text = "Add Note";
            this.btnAddNote.UseVisualStyleBackColor = false;
            this.btnAddNote.Click += new System.EventHandler(this.btnAddNote_Click);
            // 
            // btnViewQuote
            // 
            this.btnViewQuote.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnViewQuote.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnViewQuote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewQuote.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewQuote.ForeColor = System.Drawing.Color.White;
            this.btnViewQuote.Location = new System.Drawing.Point(461, 49);
            this.btnViewQuote.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnViewQuote.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnViewQuote.Name = "btnViewQuote";
            this.btnViewQuote.Padding = new System.Windows.Forms.Padding(3);
            this.btnViewQuote.Size = new System.Drawing.Size(123, 30);
            this.btnViewQuote.TabIndex = 47;
            this.btnViewQuote.Text = "View Quote";
            this.btnViewQuote.UseVisualStyleBackColor = false;
            this.btnViewQuote.Click += new System.EventHandler(this.btnViewQuote_Click);
            // 
            // btnRevise
            // 
            this.btnRevise.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnRevise.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnRevise.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRevise.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRevise.ForeColor = System.Drawing.Color.White;
            this.btnRevise.Location = new System.Drawing.Point(461, 9);
            this.btnRevise.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnRevise.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnRevise.Name = "btnRevise";
            this.btnRevise.Padding = new System.Windows.Forms.Padding(3);
            this.btnRevise.Size = new System.Drawing.Size(123, 30);
            this.btnRevise.TabIndex = 46;
            this.btnRevise.Text = "Revise Quote";
            this.btnRevise.UseVisualStyleBackColor = false;
            this.btnRevise.Click += new System.EventHandler(this.btnRevise_Click);
            // 
            // frmQuotation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 757);
            this.Controls.Add(this.btnEnquiry);
            this.Controls.Add(this.txtEnquiry);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.btnAttachments);
            this.Controls.Add(this.dteQuoteDate);
            this.Controls.Add(this.btnAddNote);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.txtFollowUp);
            this.Controls.Add(this.cmbIssue);
            this.Controls.Add(this.btnViewQuote);
            this.Controls.Add(this.btnRevise);
            this.Controls.Add(this.dteFollowUp);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.chkFollowUp);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbSys5);
            this.Controls.Add(this.cmbSys4);
            this.Controls.Add(this.cmbSys3);
            this.Controls.Add(this.cmbSys2);
            this.Controls.Add(this.cmbSys1);
            this.Controls.Add(this.cmbMatieralSupplier);
            this.Controls.Add(this.cmbMatieralType);
            this.Controls.Add(this.cmbLoss);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.cmbQuotedBy);
            this.Controls.Add(this.cmbPriority);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.txtSupplierRef);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtFittingQuote);
            this.Controls.Add(this.txtCustomerEmail);
            this.Controls.Add(this.txtCustomerContact);
            this.Controls.Add(this.txtQuoteRef);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQuotation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quotation";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtQuoteRef;
        private System.Windows.Forms.TextBox txtCustomerContact;
        private System.Windows.Forms.TextBox txtCustomerEmail;
        private System.Windows.Forms.TextBox txtFittingQuote;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtSupplierRef;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.ComboBox cmbPriority;
        private System.Windows.Forms.ComboBox cmbQuotedBy;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.ComboBox cmbLoss;
        private System.Windows.Forms.ComboBox cmbMatieralType;
        private System.Windows.Forms.ComboBox cmbMatieralSupplier;
        private System.Windows.Forms.ComboBox cmbSys1;
        private System.Windows.Forms.ComboBox cmbSys2;
        private System.Windows.Forms.ComboBox cmbSys3;
        private System.Windows.Forms.ComboBox cmbSys4;
        private System.Windows.Forms.ComboBox cmbSys5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.CheckBox chkFollowUp;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.RichTextBox txtNote;
        private System.Windows.Forms.DateTimePicker dteFollowUp;
        private buttonFormatting btnRevise;
        private buttonFormatting btnViewQuote;
        private System.Windows.Forms.ComboBox cmbIssue;
        private System.Windows.Forms.TextBox txtFollowUp;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblTitle;
        private buttonFormatting btnAddNote;
        private System.Windows.Forms.TextBox dteQuoteDate;
        private buttonFormatting btnAttachments;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtEnquiry;
        private buttonFormatting btnEnquiry;
    }
}