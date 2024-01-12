namespace PriceMaster
{
    partial class frmSlimlineChaseQuotation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSlimlineChaseQuotation));
            this.lblCustomer = new System.Windows.Forms.Label();
            this.txtCustom = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkPriority = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbRev = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkTooExpensive = new System.Windows.Forms.CheckBox();
            this.chkUnableToMeetSpec = new System.Windows.Forms.CheckBox();
            this.chkQuoteTookTooLong = new System.Windows.Forms.CheckBox();
            this.chkLeadTimeTooLong = new System.Windows.Forms.CheckBox();
            this.lblLost = new System.Windows.Forms.Label();
            this.chkNonResponsive = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chkPhone = new System.Windows.Forms.CheckBox();
            this.chkEmail = new System.Windows.Forms.CheckBox();
            this.chkHiddenFollowup = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.lblNext = new System.Windows.Forms.Label();
            this.lblChase = new System.Windows.Forms.Label();
            this.txtChaseDate = new System.Windows.Forms.TextBox();
            this.txtNextDate = new System.Windows.Forms.TextBox();
            this.chkCustomerLostTheOrder = new System.Windows.Forms.CheckBox();
            this.btnInsertNote = new PriceMaster.buttonFormatting();
            this.btnAttachments = new PriceMaster.buttonFormatting();
            this.btnRelatedEnquiries = new PriceMaster.buttonFormatting();
            this.btnChaseHistory = new PriceMaster.buttonFormatting();
            this.btnQuote = new PriceMaster.buttonFormatting();
            this.btnChase = new PriceMaster.buttonFormatting();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCustomer
            // 
            this.lblCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.lblCustomer.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblCustomer.Location = new System.Drawing.Point(12, 9);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(989, 29);
            this.lblCustomer.TabIndex = 44;
            this.lblCustomer.Text = "Customer Name";
            this.lblCustomer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // txtCustom
            // 
            this.txtCustom.Location = new System.Drawing.Point(17, 241);
            this.txtCustom.Name = "txtCustom";
            this.txtCustom.ReadOnly = true;
            this.txtCustom.Size = new System.Drawing.Size(959, 226);
            this.txtCustom.TabIndex = 50;
            this.txtCustom.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label3.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label3.Location = new System.Drawing.Point(666, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 63;
            this.label3.Text = "Status:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(724, 70);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(157, 21);
            this.cmbStatus.TabIndex = 62;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.InfoText;
            this.richTextBox1.Location = new System.Drawing.Point(1000, 9);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1, 474);
            this.richTextBox1.TabIndex = 71;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label1.Location = new System.Drawing.Point(1012, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(387, 29);
            this.label1.TabIndex = 72;
            this.label1.Text = "Most Recent Chase";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // chkPriority
            // 
            this.chkPriority.AutoSize = true;
            this.chkPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.chkPriority.Location = new System.Drawing.Point(767, 28);
            this.chkPriority.Name = "chkPriority";
            this.chkPriority.Size = new System.Drawing.Size(134, 24);
            this.chkPriority.TabIndex = 76;
            this.chkPriority.Text = "Priority Chase";
            this.chkPriority.UseVisualStyleBackColor = true;
            this.chkPriority.CheckedChanged += new System.EventHandler(this.chkPriority_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label4.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label4.Location = new System.Drawing.Point(448, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.TabIndex = 79;
            this.label4.Text = "Issue:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cmbRev
            // 
            this.cmbRev.FormattingEnabled = true;
            this.cmbRev.Location = new System.Drawing.Point(507, 57);
            this.cmbRev.Name = "cmbRev";
            this.cmbRev.Size = new System.Drawing.Size(49, 21);
            this.cmbRev.TabIndex = 78;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label2.Location = new System.Drawing.Point(13, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(963, 20);
            this.label2.TabIndex = 51;
            this.label2.Text = "Internal Notes:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // chkTooExpensive
            // 
            this.chkTooExpensive.AutoSize = true;
            this.chkTooExpensive.Location = new System.Drawing.Point(671, 128);
            this.chkTooExpensive.Name = "chkTooExpensive";
            this.chkTooExpensive.Size = new System.Drawing.Size(99, 17);
            this.chkTooExpensive.TabIndex = 64;
            this.chkTooExpensive.Text = "Too expensive.";
            this.chkTooExpensive.UseVisualStyleBackColor = true;
            this.chkTooExpensive.Visible = false;
            this.chkTooExpensive.CheckedChanged += new System.EventHandler(this.chkTooExpensive_CheckedChanged);
            // 
            // chkUnableToMeetSpec
            // 
            this.chkUnableToMeetSpec.AutoSize = true;
            this.chkUnableToMeetSpec.Location = new System.Drawing.Point(825, 155);
            this.chkUnableToMeetSpec.Name = "chkUnableToMeetSpec";
            this.chkUnableToMeetSpec.Size = new System.Drawing.Size(127, 17);
            this.chkUnableToMeetSpec.TabIndex = 65;
            this.chkUnableToMeetSpec.Text = "Unable to meet spec.";
            this.chkUnableToMeetSpec.UseVisualStyleBackColor = true;
            this.chkUnableToMeetSpec.Visible = false;
            this.chkUnableToMeetSpec.CheckedChanged += new System.EventHandler(this.chkUnableToMeetSpec_CheckedChanged);
            // 
            // chkQuoteTookTooLong
            // 
            this.chkQuoteTookTooLong.AutoSize = true;
            this.chkQuoteTookTooLong.Location = new System.Drawing.Point(671, 155);
            this.chkQuoteTookTooLong.Name = "chkQuoteTookTooLong";
            this.chkQuoteTookTooLong.Size = new System.Drawing.Size(123, 17);
            this.chkQuoteTookTooLong.TabIndex = 66;
            this.chkQuoteTookTooLong.Text = "Quote took too long.";
            this.chkQuoteTookTooLong.UseVisualStyleBackColor = true;
            this.chkQuoteTookTooLong.Visible = false;
            this.chkQuoteTookTooLong.CheckedChanged += new System.EventHandler(this.chkQuoteTookTooLong_CheckedChanged);
            // 
            // chkLeadTimeTooLong
            // 
            this.chkLeadTimeTooLong.AutoSize = true;
            this.chkLeadTimeTooLong.Location = new System.Drawing.Point(825, 128);
            this.chkLeadTimeTooLong.Name = "chkLeadTimeTooLong";
            this.chkLeadTimeTooLong.Size = new System.Drawing.Size(116, 17);
            this.chkLeadTimeTooLong.TabIndex = 67;
            this.chkLeadTimeTooLong.Text = "Lead time too long.";
            this.chkLeadTimeTooLong.UseVisualStyleBackColor = true;
            this.chkLeadTimeTooLong.Visible = false;
            this.chkLeadTimeTooLong.CheckedChanged += new System.EventHandler(this.chkLeadTimeTooLong_CheckedChanged);
            // 
            // lblLost
            // 
            this.lblLost.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblLost.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblLost.Location = new System.Drawing.Point(694, 99);
            this.lblLost.Name = "lblLost";
            this.lblLost.Size = new System.Drawing.Size(247, 17);
            this.lblLost.TabIndex = 68;
            this.lblLost.Text = "Please select why this was lost.";
            this.lblLost.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblLost.Visible = false;
            // 
            // chkNonResponsive
            // 
            this.chkNonResponsive.AutoSize = true;
            this.chkNonResponsive.Location = new System.Drawing.Point(671, 181);
            this.chkNonResponsive.Name = "chkNonResponsive";
            this.chkNonResponsive.Size = new System.Drawing.Size(152, 17);
            this.chkNonResponsive.TabIndex = 70;
            this.chkNonResponsive.Text = "Non Responsive Customer";
            this.chkNonResponsive.UseVisualStyleBackColor = true;
            this.chkNonResponsive.Visible = false;
            this.chkNonResponsive.CheckedChanged += new System.EventHandler(this.chkNonResponsive_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(-18, -28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(299, 173);
            this.pictureBox1.TabIndex = 80;
            this.pictureBox1.TabStop = false;
            // 
            // chkPhone
            // 
            this.chkPhone.AutoSize = true;
            this.chkPhone.Enabled = false;
            this.chkPhone.Location = new System.Drawing.Point(1151, 81);
            this.chkPhone.Name = "chkPhone";
            this.chkPhone.Size = new System.Drawing.Size(57, 17);
            this.chkPhone.TabIndex = 90;
            this.chkPhone.Text = "Phone";
            this.chkPhone.UseVisualStyleBackColor = true;
            // 
            // chkEmail
            // 
            this.chkEmail.AutoSize = true;
            this.chkEmail.Enabled = false;
            this.chkEmail.Location = new System.Drawing.Point(1214, 81);
            this.chkEmail.Name = "chkEmail";
            this.chkEmail.Size = new System.Drawing.Size(51, 17);
            this.chkEmail.TabIndex = 89;
            this.chkEmail.Text = "Email";
            this.chkEmail.UseVisualStyleBackColor = true;
            // 
            // chkHiddenFollowup
            // 
            this.chkHiddenFollowup.AutoSize = true;
            this.chkHiddenFollowup.Location = new System.Drawing.Point(1165, 422);
            this.chkHiddenFollowup.Name = "chkHiddenFollowup";
            this.chkHiddenFollowup.Size = new System.Drawing.Size(123, 17);
            this.chkHiddenFollowup.TabIndex = 88;
            this.chkHiddenFollowup.Text = "No followup required";
            this.chkHiddenFollowup.UseVisualStyleBackColor = true;
            this.chkHiddenFollowup.Visible = false;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label5.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label5.Location = new System.Drawing.Point(1012, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(387, 17);
            this.label5.TabIndex = 86;
            this.label5.Text = "Quotation Chase Description";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(1012, 123);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(387, 278);
            this.txtDescription.TabIndex = 85;
            this.txtDescription.Text = "";
            // 
            // lblNext
            // 
            this.lblNext.AutoSize = true;
            this.lblNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblNext.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblNext.Location = new System.Drawing.Point(1091, 420);
            this.lblNext.Name = "lblNext";
            this.lblNext.Size = new System.Drawing.Size(127, 17);
            this.lblNext.TabIndex = 84;
            this.lblNext.Text = "NEXT Chase Date:";
            this.lblNext.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblChase
            // 
            this.lblChase.AutoSize = true;
            this.lblChase.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblChase.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblChase.Location = new System.Drawing.Point(1043, 55);
            this.lblChase.Name = "lblChase";
            this.lblChase.Size = new System.Drawing.Size(152, 17);
            this.lblChase.TabIndex = 83;
            this.lblChase.Text = "Quotation Chase Date:";
            this.lblChase.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // txtChaseDate
            // 
            this.txtChaseDate.Location = new System.Drawing.Point(1193, 55);
            this.txtChaseDate.Name = "txtChaseDate";
            this.txtChaseDate.ReadOnly = true;
            this.txtChaseDate.Size = new System.Drawing.Size(128, 20);
            this.txtChaseDate.TabIndex = 92;
            // 
            // txtNextDate
            // 
            this.txtNextDate.Location = new System.Drawing.Point(1216, 420);
            this.txtNextDate.Name = "txtNextDate";
            this.txtNextDate.ReadOnly = true;
            this.txtNextDate.Size = new System.Drawing.Size(72, 20);
            this.txtNextDate.TabIndex = 93;
            // 
            // chkCustomerLostTheOrder
            // 
            this.chkCustomerLostTheOrder.AutoSize = true;
            this.chkCustomerLostTheOrder.Location = new System.Drawing.Point(825, 181);
            this.chkCustomerLostTheOrder.Name = "chkCustomerLostTheOrder";
            this.chkCustomerLostTheOrder.Size = new System.Drawing.Size(140, 17);
            this.chkCustomerLostTheOrder.TabIndex = 94;
            this.chkCustomerLostTheOrder.Text = "Customer Lost the Order";
            this.chkCustomerLostTheOrder.UseVisualStyleBackColor = true;
            this.chkCustomerLostTheOrder.Visible = false;
            this.chkCustomerLostTheOrder.CheckedChanged += new System.EventHandler(this.chkCustomerLostTheOrder_CheckedChanged);
            // 
            // btnInsertNote
            // 
            this.btnInsertNote.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnInsertNote.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnInsertNote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsertNote.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsertNote.ForeColor = System.Drawing.Color.White;
            this.btnInsertNote.Location = new System.Drawing.Point(852, 208);
            this.btnInsertNote.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnInsertNote.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnInsertNote.Name = "btnInsertNote";
            this.btnInsertNote.Padding = new System.Windows.Forms.Padding(3);
            this.btnInsertNote.Size = new System.Drawing.Size(124, 30);
            this.btnInsertNote.TabIndex = 91;
            this.btnInsertNote.Text = "Internal Notes";
            this.btnInsertNote.UseVisualStyleBackColor = false;
            this.btnInsertNote.Click += new System.EventHandler(this.btnInsertNote_Click);
            // 
            // btnAttachments
            // 
            this.btnAttachments.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnAttachments.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAttachments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAttachments.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnAttachments.ForeColor = System.Drawing.Color.White;
            this.btnAttachments.Location = new System.Drawing.Point(47, 153);
            this.btnAttachments.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnAttachments.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnAttachments.Name = "btnAttachments";
            this.btnAttachments.Padding = new System.Windows.Forms.Padding(3);
            this.btnAttachments.Size = new System.Drawing.Size(158, 30);
            this.btnAttachments.TabIndex = 77;
            this.btnAttachments.Text = "Chase Attachments";
            this.btnAttachments.UseVisualStyleBackColor = false;
            this.btnAttachments.Click += new System.EventHandler(this.btnAttachments_Click);
            // 
            // btnRelatedEnquiries
            // 
            this.btnRelatedEnquiries.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnRelatedEnquiries.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnRelatedEnquiries.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRelatedEnquiries.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelatedEnquiries.ForeColor = System.Drawing.Color.White;
            this.btnRelatedEnquiries.Location = new System.Drawing.Point(47, 193);
            this.btnRelatedEnquiries.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnRelatedEnquiries.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnRelatedEnquiries.Name = "btnRelatedEnquiries";
            this.btnRelatedEnquiries.Padding = new System.Windows.Forms.Padding(3);
            this.btnRelatedEnquiries.Size = new System.Drawing.Size(158, 30);
            this.btnRelatedEnquiries.TabIndex = 75;
            this.btnRelatedEnquiries.Text = "Related Enquiries";
            this.btnRelatedEnquiries.UseVisualStyleBackColor = false;
            this.btnRelatedEnquiries.Click += new System.EventHandler(this.btnRelatedEnquiries_Click);
            // 
            // btnChaseHistory
            // 
            this.btnChaseHistory.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnChaseHistory.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnChaseHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChaseHistory.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChaseHistory.ForeColor = System.Drawing.Color.White;
            this.btnChaseHistory.Location = new System.Drawing.Point(1149, 451);
            this.btnChaseHistory.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnChaseHistory.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnChaseHistory.Name = "btnChaseHistory";
            this.btnChaseHistory.Padding = new System.Windows.Forms.Padding(3);
            this.btnChaseHistory.Size = new System.Drawing.Size(152, 30);
            this.btnChaseHistory.TabIndex = 74;
            this.btnChaseHistory.Text = "Chase History";
            this.btnChaseHistory.UseVisualStyleBackColor = false;
            this.btnChaseHistory.Click += new System.EventHandler(this.btnChaseHistory_Click);
            // 
            // btnQuote
            // 
            this.btnQuote.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnQuote.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnQuote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuote.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuote.ForeColor = System.Drawing.Color.White;
            this.btnQuote.Location = new System.Drawing.Point(47, 117);
            this.btnQuote.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnQuote.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnQuote.Name = "btnQuote";
            this.btnQuote.Padding = new System.Windows.Forms.Padding(3);
            this.btnQuote.Size = new System.Drawing.Size(158, 30);
            this.btnQuote.TabIndex = 73;
            this.btnQuote.Text = "View Quote";
            this.btnQuote.UseVisualStyleBackColor = false;
            this.btnQuote.Click += new System.EventHandler(this.btnQuote_Click);
            // 
            // btnChase
            // 
            this.btnChase.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnChase.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnChase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChase.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChase.ForeColor = System.Drawing.Color.White;
            this.btnChase.Location = new System.Drawing.Point(889, 68);
            this.btnChase.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnChase.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnChase.Name = "btnChase";
            this.btnChase.Padding = new System.Windows.Forms.Padding(3);
            this.btnChase.Size = new System.Drawing.Size(101, 30);
            this.btnChase.TabIndex = 69;
            this.btnChase.Text = "Add Chase";
            this.btnChase.UseVisualStyleBackColor = false;
            this.btnChase.Click += new System.EventHandler(this.btnChase_Click);
            // 
            // frmSlimlineChaseQuotation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1411, 491);
            this.Controls.Add(this.chkCustomerLostTheOrder);
            this.Controls.Add(this.chkHiddenFollowup);
            this.Controls.Add(this.txtNextDate);
            this.Controls.Add(this.txtChaseDate);
            this.Controls.Add(this.btnInsertNote);
            this.Controls.Add(this.chkPhone);
            this.Controls.Add(this.chkEmail);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblNext);
            this.Controls.Add(this.lblChase);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbRev);
            this.Controls.Add(this.btnAttachments);
            this.Controls.Add(this.chkPriority);
            this.Controls.Add(this.btnRelatedEnquiries);
            this.Controls.Add(this.btnChaseHistory);
            this.Controls.Add(this.btnQuote);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.chkNonResponsive);
            this.Controls.Add(this.btnChase);
            this.Controls.Add(this.lblLost);
            this.Controls.Add(this.chkLeadTimeTooLong);
            this.Controls.Add(this.chkQuoteTookTooLong);
            this.Controls.Add(this.chkUnableToMeetSpec);
            this.Controls.Add(this.chkTooExpensive);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCustom);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblCustomer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSlimlineChaseQuotation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Slimline Chase";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSlimlineChaseQuotation_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.RichTextBox txtCustom;
        private buttonFormatting btnChase;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private buttonFormatting btnAttachments;
        private System.Windows.Forms.CheckBox chkPriority;
        private buttonFormatting btnRelatedEnquiries;
        private buttonFormatting btnChaseHistory;
        private buttonFormatting btnQuote;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbRev;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkTooExpensive;
        private System.Windows.Forms.CheckBox chkUnableToMeetSpec;
        private System.Windows.Forms.CheckBox chkQuoteTookTooLong;
        private System.Windows.Forms.CheckBox chkLeadTimeTooLong;
        private System.Windows.Forms.Label lblLost;
        private System.Windows.Forms.CheckBox chkNonResponsive;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox chkPhone;
        private System.Windows.Forms.CheckBox chkEmail;
        private System.Windows.Forms.CheckBox chkHiddenFollowup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.Label lblNext;
        private System.Windows.Forms.Label lblChase;
        private buttonFormatting btnInsertNote;
        private System.Windows.Forms.TextBox txtChaseDate;
        private System.Windows.Forms.TextBox txtNextDate;
        private System.Windows.Forms.CheckBox chkCustomerLostTheOrder;
    }
}