namespace PriceMaster
{
    partial class frmChaseInsertCorrespondence
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
            this.chkPhone = new System.Windows.Forms.CheckBox();
            this.chkEmail = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkTurnaround = new System.Windows.Forms.CheckBox();
            this.chkProduct = new System.Windows.Forms.CheckBox();
            this.chkInstallation = new System.Windows.Forms.CheckBox();
            this.chkLeadtime = new System.Windows.Forms.CheckBox();
            this.chkService = new System.Windows.Forms.CheckBox();
            this.chkInPerson = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.btnCancel = new PriceMaster.buttonFormatting();
            this.btnSave = new PriceMaster.buttonFormatting();
            this.label4 = new System.Windows.Forms.Label();
            this.dteNextDate = new System.Windows.Forms.DateTimePicker();
            this.chkFollowUp = new System.Windows.Forms.CheckBox();
            this.btnSaveManagement = new PriceMaster.buttonFormatting();
            this.cmbSector = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEmailCustomer = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chkPhone
            // 
            this.chkPhone.AutoSize = true;
            this.chkPhone.Location = new System.Drawing.Point(182, 36);
            this.chkPhone.Name = "chkPhone";
            this.chkPhone.Size = new System.Drawing.Size(57, 17);
            this.chkPhone.TabIndex = 83;
            this.chkPhone.Text = "Phone";
            this.chkPhone.UseVisualStyleBackColor = true;
            // 
            // chkEmail
            // 
            this.chkEmail.AutoSize = true;
            this.chkEmail.Location = new System.Drawing.Point(245, 36);
            this.chkEmail.Name = "chkEmail";
            this.chkEmail.Size = new System.Drawing.Size(51, 17);
            this.chkEmail.TabIndex = 82;
            this.chkEmail.Text = "Email";
            this.chkEmail.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label2.Location = new System.Drawing.Point(13, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(529, 17);
            this.label2.TabIndex = 77;
            this.label2.Text = "Correspondence Description";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(13, 218);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(529, 218);
            this.txtDescription.TabIndex = 76;
            this.txtDescription.Text = "";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(529, 17);
            this.label1.TabIndex = 84;
            this.label1.Text = "CUSTOMER Correspondence";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // chkTurnaround
            // 
            this.chkTurnaround.AutoSize = true;
            this.chkTurnaround.Location = new System.Drawing.Point(280, 453);
            this.chkTurnaround.Name = "chkTurnaround";
            this.chkTurnaround.Size = new System.Drawing.Size(179, 17);
            this.chkTurnaround.TabIndex = 88;
            this.chkTurnaround.Text = "Issue with quote turnaround time";
            this.chkTurnaround.UseVisualStyleBackColor = true;
            // 
            // chkProduct
            // 
            this.chkProduct.AutoSize = true;
            this.chkProduct.Location = new System.Drawing.Point(149, 478);
            this.chkProduct.Name = "chkProduct";
            this.chkProduct.Size = new System.Drawing.Size(112, 17);
            this.chkProduct.TabIndex = 87;
            this.chkProduct.Text = "Issue with product";
            this.chkProduct.UseVisualStyleBackColor = true;
            // 
            // chkInstallation
            // 
            this.chkInstallation.AutoSize = true;
            this.chkInstallation.Location = new System.Drawing.Point(280, 478);
            this.chkInstallation.Name = "chkInstallation";
            this.chkInstallation.Size = new System.Drawing.Size(125, 17);
            this.chkInstallation.TabIndex = 86;
            this.chkInstallation.Text = "Issue with installation";
            this.chkInstallation.UseVisualStyleBackColor = true;
            // 
            // chkLeadtime
            // 
            this.chkLeadtime.AutoSize = true;
            this.chkLeadtime.Location = new System.Drawing.Point(149, 453);
            this.chkLeadtime.Name = "chkLeadtime";
            this.chkLeadtime.Size = new System.Drawing.Size(115, 17);
            this.chkLeadtime.TabIndex = 85;
            this.chkLeadtime.Text = "Issue with leadtime";
            this.chkLeadtime.UseVisualStyleBackColor = true;
            // 
            // chkService
            // 
            this.chkService.AutoSize = true;
            this.chkService.Location = new System.Drawing.Point(222, 501);
            this.chkService.Name = "chkService";
            this.chkService.Size = new System.Drawing.Size(110, 17);
            this.chkService.TabIndex = 89;
            this.chkService.Text = "Issue with service";
            this.chkService.UseVisualStyleBackColor = true;
            // 
            // chkInPerson
            // 
            this.chkInPerson.AutoSize = true;
            this.chkInPerson.Location = new System.Drawing.Point(302, 36);
            this.chkInPerson.Name = "chkInPerson";
            this.chkInPerson.Size = new System.Drawing.Size(71, 17);
            this.chkInPerson.TabIndex = 90;
            this.chkInPerson.Text = "In Person";
            this.chkInPerson.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label3.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label3.Location = new System.Drawing.Point(177, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 92;
            this.label3.Text = "Contact:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // txtContact
            // 
            this.txtContact.Location = new System.Drawing.Point(237, 63);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(141, 20);
            this.txtContact.TabIndex = 93;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(71, 574);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnCancel.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(3);
            this.btnCancel.Size = new System.Drawing.Size(85, 30);
            this.btnCancel.TabIndex = 79;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(166, 574);
            this.btnSave.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnSave.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(3);
            this.btnSave.Size = new System.Drawing.Size(85, 30);
            this.btnSave.TabIndex = 78;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label4.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label4.Location = new System.Drawing.Point(186, 524);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(183, 17);
            this.label4.TabIndex = 97;
            this.label4.Text = "Next Correspondence Date:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dteNextDate
            // 
            this.dteNextDate.Location = new System.Drawing.Point(143, 545);
            this.dteNextDate.Name = "dteNextDate";
            this.dteNextDate.Size = new System.Drawing.Size(139, 20);
            this.dteNextDate.TabIndex = 96;
            // 
            // chkFollowUp
            // 
            this.chkFollowUp.AutoSize = true;
            this.chkFollowUp.Location = new System.Drawing.Point(288, 548);
            this.chkFollowUp.Name = "chkFollowUp";
            this.chkFollowUp.Size = new System.Drawing.Size(124, 17);
            this.chkFollowUp.TabIndex = 98;
            this.chkFollowUp.Text = "No follow up needed";
            this.chkFollowUp.UseVisualStyleBackColor = true;
            this.chkFollowUp.CheckedChanged += new System.EventHandler(this.chkFollowUp_CheckedChanged);
            // 
            // btnSaveManagement
            // 
            this.btnSaveManagement.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSaveManagement.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSaveManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveManagement.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveManagement.ForeColor = System.Drawing.Color.White;
            this.btnSaveManagement.Location = new System.Drawing.Point(261, 574);
            this.btnSaveManagement.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnSaveManagement.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnSaveManagement.Name = "btnSaveManagement";
            this.btnSaveManagement.Padding = new System.Windows.Forms.Padding(3);
            this.btnSaveManagement.Size = new System.Drawing.Size(222, 30);
            this.btnSaveManagement.TabIndex = 99;
            this.btnSaveManagement.Text = "Save AND alert management";
            this.btnSaveManagement.UseVisualStyleBackColor = false;
            this.btnSaveManagement.Click += new System.EventHandler(this.btnSaveManagement_Click);
            // 
            // cmbSector
            // 
            this.cmbSector.FormattingEnabled = true;
            this.cmbSector.Location = new System.Drawing.Point(103, 109);
            this.cmbSector.Name = "cmbSector";
            this.cmbSector.Size = new System.Drawing.Size(348, 21);
            this.cmbSector.TabIndex = 100;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label5.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label5.Location = new System.Drawing.Point(105, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(346, 17);
            this.label5.TabIndex = 101;
            this.label5.Text = "Sector:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtEmailCustomer
            // 
            this.txtEmailCustomer.Location = new System.Drawing.Point(103, 160);
            this.txtEmailCustomer.Name = "txtEmailCustomer";
            this.txtEmailCustomer.Size = new System.Drawing.Size(348, 20);
            this.txtEmailCustomer.TabIndex = 102;
            // 
            // lblEmail
            // 
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblEmail.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblEmail.Location = new System.Drawing.Point(78, 140);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(399, 17);
            this.lblEmail.TabIndex = 103;
            this.lblEmail.Text = "Customer Email Domain: (Example: \'@designandsupply\')";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmChaseInsertCorrespondence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 613);
            this.ControlBox = false;
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmailCustomer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbSector);
            this.Controls.Add(this.btnSaveManagement);
            this.Controls.Add(this.chkFollowUp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dteNextDate);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkInPerson);
            this.Controls.Add(this.chkService);
            this.Controls.Add(this.chkTurnaround);
            this.Controls.Add(this.chkProduct);
            this.Controls.Add(this.chkInstallation);
            this.Controls.Add(this.chkLeadtime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkPhone);
            this.Controls.Add(this.chkEmail);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDescription);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmChaseInsertCorrespondence";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Correspondence";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkPhone;
        private System.Windows.Forms.CheckBox chkEmail;
        private buttonFormatting btnCancel;
        private buttonFormatting btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkTurnaround;
        private System.Windows.Forms.CheckBox chkProduct;
        private System.Windows.Forms.CheckBox chkInstallation;
        private System.Windows.Forms.CheckBox chkLeadtime;
        private System.Windows.Forms.CheckBox chkService;
        private System.Windows.Forms.CheckBox chkInPerson;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dteNextDate;
        private System.Windows.Forms.CheckBox chkFollowUp;
        private buttonFormatting btnSaveManagement;
        private System.Windows.Forms.ComboBox cmbSector;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEmailCustomer;
        private System.Windows.Forms.Label lblEmail;
    }
}