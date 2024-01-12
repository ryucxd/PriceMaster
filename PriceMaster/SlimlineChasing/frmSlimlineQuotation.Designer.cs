namespace PriceMaster
{
    partial class frmSlimlineQuotation
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
            this.cmbRev = new System.Windows.Forms.ComboBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCustom = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkPriority = new System.Windows.Forms.CheckBox();
            this.btnAttachments = new PriceMaster.buttonFormatting();
            this.btnInsertNote = new PriceMaster.buttonFormatting();
            this.btnRelatedEnquiries = new PriceMaster.buttonFormatting();
            this.btnChaseHistory = new PriceMaster.buttonFormatting();
            this.btnQuote = new PriceMaster.buttonFormatting();
            this.chkNonResponsive = new System.Windows.Forms.CheckBox();
            this.btnChase = new PriceMaster.buttonFormatting();
            this.lblLost = new System.Windows.Forms.Label();
            this.chkLeadTimeTooLong = new System.Windows.Forms.CheckBox();
            this.chkQuoteTookTooLong = new System.Windows.Forms.CheckBox();
            this.chkUnableToMeetSpec = new System.Windows.Forms.CheckBox();
            this.chkTooExpensive = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cmbRev
            // 
            this.cmbRev.FormattingEnabled = true;
            this.cmbRev.Location = new System.Drawing.Point(578, 50);
            this.cmbRev.Name = "cmbRev";
            this.cmbRev.Size = new System.Drawing.Size(49, 21);
            this.cmbRev.TabIndex = 0;
            this.cmbRev.SelectedIndexChanged += new System.EventHandler(this.cmbRev_SelectedIndexChanged);
            // 
            // lblCustomer
            // 
            this.lblCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.lblCustomer.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblCustomer.Location = new System.Drawing.Point(12, 9);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(1120, 29);
            this.lblCustomer.TabIndex = 43;
            this.lblCustomer.Text = "label1";
            this.lblCustomer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label1.Location = new System.Drawing.Point(518, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 44;
            this.label1.Text = "Issue:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // txtCustom
            // 
            this.txtCustom.Location = new System.Drawing.Point(330, 99);
            this.txtCustom.Name = "txtCustom";
            this.txtCustom.ReadOnly = true;
            this.txtCustom.Size = new System.Drawing.Size(692, 139);
            this.txtCustom.TabIndex = 49;
            this.txtCustom.Text = "";
            this.txtCustom.Leave += new System.EventHandler(this.txtCustom_Leave);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label2.Location = new System.Drawing.Point(344, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(691, 20);
            this.label2.TabIndex = 50;
            this.label2.Text = "Internal Feedback:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // chkPriority
            // 
            this.chkPriority.AutoSize = true;
            this.chkPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.chkPriority.Location = new System.Drawing.Point(998, 50);
            this.chkPriority.Name = "chkPriority";
            this.chkPriority.Size = new System.Drawing.Size(134, 24);
            this.chkPriority.TabIndex = 63;
            this.chkPriority.Text = "Priority Chase";
            this.chkPriority.UseVisualStyleBackColor = true;
            this.chkPriority.CheckedChanged += new System.EventHandler(this.chkPriority_CheckedChanged);
            // 
            // btnAttachments
            // 
            this.btnAttachments.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnAttachments.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAttachments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAttachments.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnAttachments.ForeColor = System.Drawing.Color.White;
            this.btnAttachments.Location = new System.Drawing.Point(1030, 95);
            this.btnAttachments.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnAttachments.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnAttachments.Name = "btnAttachments";
            this.btnAttachments.Padding = new System.Windows.Forms.Padding(3);
            this.btnAttachments.Size = new System.Drawing.Size(102, 49);
            this.btnAttachments.TabIndex = 64;
            this.btnAttachments.Text = "Chase Attachments";
            this.btnAttachments.UseVisualStyleBackColor = false;
            this.btnAttachments.Click += new System.EventHandler(this.btnAttachments_Click);
            // 
            // btnInsertNote
            // 
            this.btnInsertNote.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnInsertNote.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnInsertNote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsertNote.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsertNote.ForeColor = System.Drawing.Color.White;
            this.btnInsertNote.Location = new System.Drawing.Point(330, 66);
            this.btnInsertNote.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnInsertNote.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnInsertNote.Name = "btnInsertNote";
            this.btnInsertNote.Padding = new System.Windows.Forms.Padding(3);
            this.btnInsertNote.Size = new System.Drawing.Size(153, 30);
            this.btnInsertNote.TabIndex = 62;
            this.btnInsertNote.Text = "Internal Feedback";
            this.btnInsertNote.UseVisualStyleBackColor = false;
            this.btnInsertNote.Click += new System.EventHandler(this.btnInsertNote_Click);
            // 
            // btnRelatedEnquiries
            // 
            this.btnRelatedEnquiries.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnRelatedEnquiries.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnRelatedEnquiries.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRelatedEnquiries.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelatedEnquiries.ForeColor = System.Drawing.Color.White;
            this.btnRelatedEnquiries.Location = new System.Drawing.Point(981, 12);
            this.btnRelatedEnquiries.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnRelatedEnquiries.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnRelatedEnquiries.Name = "btnRelatedEnquiries";
            this.btnRelatedEnquiries.Padding = new System.Windows.Forms.Padding(3);
            this.btnRelatedEnquiries.Size = new System.Drawing.Size(151, 30);
            this.btnRelatedEnquiries.TabIndex = 60;
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
            this.btnChaseHistory.Location = new System.Drawing.Point(1030, 149);
            this.btnChaseHistory.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnChaseHistory.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnChaseHistory.Name = "btnChaseHistory";
            this.btnChaseHistory.Padding = new System.Windows.Forms.Padding(3);
            this.btnChaseHistory.Size = new System.Drawing.Size(102, 50);
            this.btnChaseHistory.TabIndex = 59;
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
            this.btnQuote.Location = new System.Drawing.Point(1030, 205);
            this.btnQuote.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnQuote.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnQuote.Name = "btnQuote";
            this.btnQuote.Padding = new System.Windows.Forms.Padding(3);
            this.btnQuote.Size = new System.Drawing.Size(102, 33);
            this.btnQuote.TabIndex = 47;
            this.btnQuote.Text = "Quote";
            this.btnQuote.UseVisualStyleBackColor = false;
            this.btnQuote.Click += new System.EventHandler(this.btnQuote_Click);
            // 
            // chkNonResponsive
            // 
            this.chkNonResponsive.AutoSize = true;
            this.chkNonResponsive.Location = new System.Drawing.Point(26, 220);
            this.chkNonResponsive.Name = "chkNonResponsive";
            this.chkNonResponsive.Size = new System.Drawing.Size(152, 17);
            this.chkNonResponsive.TabIndex = 61;
            this.chkNonResponsive.Text = "Non Responsive Customer";
            this.chkNonResponsive.UseVisualStyleBackColor = true;
            this.chkNonResponsive.Visible = false;
            this.chkNonResponsive.CheckedChanged += new System.EventHandler(this.chkNonResponsive_CheckedChanged);
            // 
            // btnChase
            // 
            this.btnChase.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnChase.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnChase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChase.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChase.ForeColor = System.Drawing.Color.White;
            this.btnChase.Location = new System.Drawing.Point(221, 97);
            this.btnChase.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnChase.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnChase.Name = "btnChase";
            this.btnChase.Padding = new System.Windows.Forms.Padding(3);
            this.btnChase.Size = new System.Drawing.Size(101, 30);
            this.btnChase.TabIndex = 58;
            this.btnChase.Text = "Add Chase";
            this.btnChase.UseVisualStyleBackColor = false;
            this.btnChase.Click += new System.EventHandler(this.btnChase_Click);
            // 
            // lblLost
            // 
            this.lblLost.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblLost.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblLost.Location = new System.Drawing.Point(26, 131);
            this.lblLost.Name = "lblLost";
            this.lblLost.Size = new System.Drawing.Size(247, 17);
            this.lblLost.TabIndex = 57;
            this.lblLost.Text = "Please select why this was lost.";
            this.lblLost.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblLost.Visible = false;
            // 
            // chkLeadTimeTooLong
            // 
            this.chkLeadTimeTooLong.AutoSize = true;
            this.chkLeadTimeTooLong.Location = new System.Drawing.Point(157, 167);
            this.chkLeadTimeTooLong.Name = "chkLeadTimeTooLong";
            this.chkLeadTimeTooLong.Size = new System.Drawing.Size(116, 17);
            this.chkLeadTimeTooLong.TabIndex = 56;
            this.chkLeadTimeTooLong.Text = "Lead time too long.";
            this.chkLeadTimeTooLong.UseVisualStyleBackColor = true;
            this.chkLeadTimeTooLong.Visible = false;
            this.chkLeadTimeTooLong.CheckedChanged += new System.EventHandler(this.chkLeadTimeTooLong_CheckedChanged);
            // 
            // chkQuoteTookTooLong
            // 
            this.chkQuoteTookTooLong.AutoSize = true;
            this.chkQuoteTookTooLong.Location = new System.Drawing.Point(26, 194);
            this.chkQuoteTookTooLong.Name = "chkQuoteTookTooLong";
            this.chkQuoteTookTooLong.Size = new System.Drawing.Size(123, 17);
            this.chkQuoteTookTooLong.TabIndex = 55;
            this.chkQuoteTookTooLong.Text = "Quote took too long.";
            this.chkQuoteTookTooLong.UseVisualStyleBackColor = true;
            this.chkQuoteTookTooLong.Visible = false;
            this.chkQuoteTookTooLong.CheckedChanged += new System.EventHandler(this.chkQuoteTookTooLong_CheckedChanged);
            // 
            // chkUnableToMeetSpec
            // 
            this.chkUnableToMeetSpec.AutoSize = true;
            this.chkUnableToMeetSpec.Location = new System.Drawing.Point(157, 194);
            this.chkUnableToMeetSpec.Name = "chkUnableToMeetSpec";
            this.chkUnableToMeetSpec.Size = new System.Drawing.Size(127, 17);
            this.chkUnableToMeetSpec.TabIndex = 54;
            this.chkUnableToMeetSpec.Text = "Unable to meet spec.";
            this.chkUnableToMeetSpec.UseVisualStyleBackColor = true;
            this.chkUnableToMeetSpec.Visible = false;
            this.chkUnableToMeetSpec.CheckedChanged += new System.EventHandler(this.chkUnableToMeetSpec_CheckedChanged);
            // 
            // chkTooExpensive
            // 
            this.chkTooExpensive.AutoSize = true;
            this.chkTooExpensive.Location = new System.Drawing.Point(26, 167);
            this.chkTooExpensive.Name = "chkTooExpensive";
            this.chkTooExpensive.Size = new System.Drawing.Size(99, 17);
            this.chkTooExpensive.TabIndex = 53;
            this.chkTooExpensive.Text = "Too expensive.";
            this.chkTooExpensive.UseVisualStyleBackColor = true;
            this.chkTooExpensive.Visible = false;
            this.chkTooExpensive.CheckedChanged += new System.EventHandler(this.chkTooExpensive_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label3.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label3.Location = new System.Drawing.Point(-2, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 52;
            this.label3.Text = "Status:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(56, 99);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(157, 21);
            this.cmbStatus.TabIndex = 51;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // frmSlimlineQuotation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 246);
            this.Controls.Add(this.btnAttachments);
            this.Controls.Add(this.chkPriority);
            this.Controls.Add(this.btnInsertNote);
            this.Controls.Add(this.chkNonResponsive);
            this.Controls.Add(this.btnRelatedEnquiries);
            this.Controls.Add(this.btnChaseHistory);
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
            this.Controls.Add(this.btnQuote);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.cmbRev);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSlimlineQuotation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Traditional Quote";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSlimlineQuotation_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbRev;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label label1;
        private buttonFormatting btnQuote;
        private System.Windows.Forms.RichTextBox txtCustom;
        private System.Windows.Forms.Label label2;
        private buttonFormatting btnChaseHistory;
        private buttonFormatting btnRelatedEnquiries;
        private buttonFormatting btnInsertNote;
        private System.Windows.Forms.CheckBox chkPriority;
        private buttonFormatting btnAttachments;
        private System.Windows.Forms.CheckBox chkNonResponsive;
        private buttonFormatting btnChase;
        private System.Windows.Forms.Label lblLost;
        private System.Windows.Forms.CheckBox chkLeadTimeTooLong;
        private System.Windows.Forms.CheckBox chkQuoteTookTooLong;
        private System.Windows.Forms.CheckBox chkUnableToMeetSpec;
        private System.Windows.Forms.CheckBox chkTooExpensive;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbStatus;
    }
}