namespace PriceMaster
{
    partial class frmTraditionalQuotation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTraditionalQuotation));
            this.cmbRev = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalCost = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnQuote = new PriceMaster.buttonFormatting();
            this.btnDrawings = new PriceMaster.buttonFormatting();
            this.txtCustom = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkTooExpensive = new System.Windows.Forms.CheckBox();
            this.chkUnableToMeetSpec = new System.Windows.Forms.CheckBox();
            this.chkQuoteTookTooLong = new System.Windows.Forms.CheckBox();
            this.chkLeadTimeTooLong = new System.Windows.Forms.CheckBox();
            this.lblLost = new System.Windows.Forms.Label();
            this.btnChase = new PriceMaster.buttonFormatting();
            this.btnChaseHistory = new PriceMaster.buttonFormatting();
            this.btnRelatedEnquiries = new PriceMaster.buttonFormatting();
            this.chkNonResponsive = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbRev
            // 
            this.cmbRev.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbRev.FormattingEnabled = true;
            this.cmbRev.Location = new System.Drawing.Point(588, 50);
            this.cmbRev.Name = "cmbRev";
            this.cmbRev.Size = new System.Drawing.Size(49, 21);
            this.cmbRev.TabIndex = 0;
            this.cmbRev.SelectedIndexChanged += new System.EventHandler(this.cmbRev_SelectedIndexChanged);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(12, 91);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1200, 335);
            this.dataGridView1.TabIndex = 42;
            // 
            // lblCustomer
            // 
            this.lblCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.lblCustomer.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblCustomer.Location = new System.Drawing.Point(12, 9);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(1200, 29);
            this.lblCustomer.TabIndex = 43;
            this.lblCustomer.Text = "label1";
            this.lblCustomer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label1.Location = new System.Drawing.Point(504, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 44;
            this.label1.Text = "Revision:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblTotalCost
            // 
            this.lblTotalCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblTotalCost.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblTotalCost.Location = new System.Drawing.Point(855, 65);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(357, 23);
            this.lblTotalCost.TabIndex = 45;
            this.lblTotalCost.Text = "label1";
            this.lblTotalCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblCount.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblCount.Location = new System.Drawing.Point(14, 65);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(272, 23);
            this.lblCount.TabIndex = 46;
            this.lblCount.Text = "label1";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnQuote
            // 
            this.btnQuote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuote.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnQuote.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnQuote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuote.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuote.ForeColor = System.Drawing.Color.White;
            this.btnQuote.Location = new System.Drawing.Point(1123, 515);
            this.btnQuote.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnQuote.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnQuote.Name = "btnQuote";
            this.btnQuote.Padding = new System.Windows.Forms.Padding(3);
            this.btnQuote.Size = new System.Drawing.Size(89, 33);
            this.btnQuote.TabIndex = 47;
            this.btnQuote.Text = "Quote";
            this.btnQuote.UseVisualStyleBackColor = false;
            this.btnQuote.Click += new System.EventHandler(this.btnQuote_Click);
            // 
            // btnDrawings
            // 
            this.btnDrawings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDrawings.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnDrawings.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnDrawings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDrawings.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDrawings.ForeColor = System.Drawing.Color.White;
            this.btnDrawings.Location = new System.Drawing.Point(1123, 557);
            this.btnDrawings.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnDrawings.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnDrawings.Name = "btnDrawings";
            this.btnDrawings.Padding = new System.Windows.Forms.Padding(3);
            this.btnDrawings.Size = new System.Drawing.Size(89, 33);
            this.btnDrawings.TabIndex = 48;
            this.btnDrawings.Text = "Drawings";
            this.btnDrawings.UseVisualStyleBackColor = false;
            this.btnDrawings.Click += new System.EventHandler(this.btnDrawings_Click);
            // 
            // txtCustom
            // 
            this.txtCustom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustom.Location = new System.Drawing.Point(424, 451);
            this.txtCustom.Name = "txtCustom";
            this.txtCustom.Size = new System.Drawing.Size(691, 139);
            this.txtCustom.TabIndex = 49;
            this.txtCustom.Text = "";
            this.txtCustom.Leave += new System.EventHandler(this.txtCustom_Leave);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label2.Location = new System.Drawing.Point(424, 429);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(691, 20);
            this.label2.TabIndex = 50;
            this.label2.Text = "Custom Feedback:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cmbStatus
            // 
            this.cmbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(129, 451);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(157, 21);
            this.cmbStatus.TabIndex = 51;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label3.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label3.Location = new System.Drawing.Point(71, 451);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 52;
            this.label3.Text = "Status:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkTooExpensive
            // 
            this.chkTooExpensive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkTooExpensive.AutoSize = true;
            this.chkTooExpensive.Location = new System.Drawing.Point(74, 529);
            this.chkTooExpensive.Name = "chkTooExpensive";
            this.chkTooExpensive.Size = new System.Drawing.Size(99, 17);
            this.chkTooExpensive.TabIndex = 53;
            this.chkTooExpensive.Text = "Too expensive.";
            this.chkTooExpensive.UseVisualStyleBackColor = true;
            this.chkTooExpensive.Visible = false;
            this.chkTooExpensive.CheckedChanged += new System.EventHandler(this.chkTooExpensive_CheckedChanged);
            // 
            // chkUnableToMeetSpec
            // 
            this.chkUnableToMeetSpec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkUnableToMeetSpec.AutoSize = true;
            this.chkUnableToMeetSpec.Location = new System.Drawing.Point(205, 554);
            this.chkUnableToMeetSpec.Name = "chkUnableToMeetSpec";
            this.chkUnableToMeetSpec.Size = new System.Drawing.Size(127, 17);
            this.chkUnableToMeetSpec.TabIndex = 54;
            this.chkUnableToMeetSpec.Text = "Unable to meet spec.";
            this.chkUnableToMeetSpec.UseVisualStyleBackColor = true;
            this.chkUnableToMeetSpec.Visible = false;
            this.chkUnableToMeetSpec.CheckedChanged += new System.EventHandler(this.chkUnableToMeetSpec_CheckedChanged);
            // 
            // chkQuoteTookTooLong
            // 
            this.chkQuoteTookTooLong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkQuoteTookTooLong.AutoSize = true;
            this.chkQuoteTookTooLong.Location = new System.Drawing.Point(74, 554);
            this.chkQuoteTookTooLong.Name = "chkQuoteTookTooLong";
            this.chkQuoteTookTooLong.Size = new System.Drawing.Size(123, 17);
            this.chkQuoteTookTooLong.TabIndex = 55;
            this.chkQuoteTookTooLong.Text = "Quote took too long.";
            this.chkQuoteTookTooLong.UseVisualStyleBackColor = true;
            this.chkQuoteTookTooLong.Visible = false;
            this.chkQuoteTookTooLong.CheckedChanged += new System.EventHandler(this.chkQuoteTookTooLong_CheckedChanged);
            // 
            // chkLeadTimeTooLong
            // 
            this.chkLeadTimeTooLong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkLeadTimeTooLong.AutoSize = true;
            this.chkLeadTimeTooLong.Location = new System.Drawing.Point(205, 529);
            this.chkLeadTimeTooLong.Name = "chkLeadTimeTooLong";
            this.chkLeadTimeTooLong.Size = new System.Drawing.Size(116, 17);
            this.chkLeadTimeTooLong.TabIndex = 56;
            this.chkLeadTimeTooLong.Text = "Lead time too long.";
            this.chkLeadTimeTooLong.UseVisualStyleBackColor = true;
            this.chkLeadTimeTooLong.Visible = false;
            this.chkLeadTimeTooLong.CheckedChanged += new System.EventHandler(this.chkLeadTimeTooLong_CheckedChanged);
            // 
            // lblLost
            // 
            this.lblLost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLost.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblLost.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblLost.Location = new System.Drawing.Point(74, 493);
            this.lblLost.Name = "lblLost";
            this.lblLost.Size = new System.Drawing.Size(247, 17);
            this.lblLost.TabIndex = 57;
            this.lblLost.Text = "Please select why this was lost.";
            this.lblLost.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblLost.Visible = false;
            // 
            // btnChase
            // 
            this.btnChase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnChase.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnChase.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnChase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChase.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChase.ForeColor = System.Drawing.Color.White;
            this.btnChase.Location = new System.Drawing.Point(294, 449);
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
            // btnChaseHistory
            // 
            this.btnChaseHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChaseHistory.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnChaseHistory.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnChaseHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChaseHistory.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChaseHistory.ForeColor = System.Drawing.Color.White;
            this.btnChaseHistory.Location = new System.Drawing.Point(1123, 454);
            this.btnChaseHistory.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnChaseHistory.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnChaseHistory.Name = "btnChaseHistory";
            this.btnChaseHistory.Padding = new System.Windows.Forms.Padding(3);
            this.btnChaseHistory.Size = new System.Drawing.Size(89, 50);
            this.btnChaseHistory.TabIndex = 59;
            this.btnChaseHistory.Text = "Chase History";
            this.btnChaseHistory.UseVisualStyleBackColor = false;
            this.btnChaseHistory.Click += new System.EventHandler(this.btnChaseHistory_Click);
            // 
            // btnRelatedEnquiries
            // 
            this.btnRelatedEnquiries.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRelatedEnquiries.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnRelatedEnquiries.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnRelatedEnquiries.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRelatedEnquiries.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelatedEnquiries.ForeColor = System.Drawing.Color.White;
            this.btnRelatedEnquiries.Location = new System.Drawing.Point(1061, 12);
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
            // chkNonResponsive
            // 
            this.chkNonResponsive.AutoSize = true;
            this.chkNonResponsive.Location = new System.Drawing.Point(74, 579);
            this.chkNonResponsive.Name = "chkNonResponsive";
            this.chkNonResponsive.Size = new System.Drawing.Size(152, 17);
            this.chkNonResponsive.TabIndex = 68;
            this.chkNonResponsive.Text = "Non Responsive Customer";
            this.chkNonResponsive.UseVisualStyleBackColor = true;
            this.chkNonResponsive.Visible = false;
            this.chkNonResponsive.CheckedChanged += new System.EventHandler(this.chkNonResponsive_CheckedChanged);
            // 
            // frmTraditionalQuotation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 599);
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
            this.Controls.Add(this.btnDrawings);
            this.Controls.Add(this.btnQuote);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.lblTotalCost);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cmbRev);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "frmTraditionalQuotation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Traditional Quote";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTraditionalQuotation_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbRev;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalCost;
        private System.Windows.Forms.Label lblCount;
        private buttonFormatting btnQuote;
        private buttonFormatting btnDrawings;
        private System.Windows.Forms.RichTextBox txtCustom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkTooExpensive;
        private System.Windows.Forms.CheckBox chkUnableToMeetSpec;
        private System.Windows.Forms.CheckBox chkQuoteTookTooLong;
        private System.Windows.Forms.CheckBox chkLeadTimeTooLong;
        private System.Windows.Forms.Label lblLost;
        private buttonFormatting btnChase;
        private buttonFormatting btnChaseHistory;
        private buttonFormatting btnRelatedEnquiries;
        private System.Windows.Forms.CheckBox chkNonResponsive;
    }
}