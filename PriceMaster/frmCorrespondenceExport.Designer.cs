namespace PriceMaster
{
    partial class frmCorrespondenceExport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCorrespondenceExport));
            this.label1 = new System.Windows.Forms.Label();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.chkEmail = new System.Windows.Forms.CheckBox();
            this.chkPhone = new System.Windows.Forms.CheckBox();
            this.chkPerson = new System.Windows.Forms.CheckBox();
            this.chkLeadTime = new System.Windows.Forms.CheckBox();
            this.chkQuoteTurnAround = new System.Windows.Forms.CheckBox();
            this.chkProduct = new System.Windows.Forms.CheckBox();
            this.chkInstallation = new System.Windows.Forms.CheckBox();
            this.chkService = new System.Windows.Forms.CheckBox();
            this.dteStart = new System.Windows.Forms.DateTimePicker();
            this.dteEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCorrespondence = new System.Windows.Forms.RichTextBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.btnCancel = new PriceMaster.buttonFormatting();
            this.btnExport = new PriceMaster.buttonFormatting();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label1.Location = new System.Drawing.Point(169, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Correspondence Filters";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtContact
            // 
            this.txtContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.txtContact.Location = new System.Drawing.Point(216, 176);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(143, 23);
            this.txtContact.TabIndex = 2;
            // 
            // chkEmail
            // 
            this.chkEmail.AutoSize = true;
            this.chkEmail.Location = new System.Drawing.Point(18, 24);
            this.chkEmail.Name = "chkEmail";
            this.chkEmail.Size = new System.Drawing.Size(61, 21);
            this.chkEmail.TabIndex = 3;
            this.chkEmail.Text = "Email";
            this.chkEmail.UseVisualStyleBackColor = true;
            // 
            // chkPhone
            // 
            this.chkPhone.AutoSize = true;
            this.chkPhone.Location = new System.Drawing.Point(106, 24);
            this.chkPhone.Name = "chkPhone";
            this.chkPhone.Size = new System.Drawing.Size(68, 21);
            this.chkPhone.TabIndex = 4;
            this.chkPhone.Text = "Phone";
            this.chkPhone.UseVisualStyleBackColor = true;
            // 
            // chkPerson
            // 
            this.chkPerson.AutoSize = true;
            this.chkPerson.Location = new System.Drawing.Point(202, 24);
            this.chkPerson.Name = "chkPerson";
            this.chkPerson.Size = new System.Drawing.Size(87, 21);
            this.chkPerson.TabIndex = 5;
            this.chkPerson.Text = "In Person";
            this.chkPerson.UseVisualStyleBackColor = true;
            // 
            // chkLeadTime
            // 
            this.chkLeadTime.AutoSize = true;
            this.chkLeadTime.Location = new System.Drawing.Point(16, 29);
            this.chkLeadTime.Name = "chkLeadTime";
            this.chkLeadTime.Size = new System.Drawing.Size(94, 21);
            this.chkLeadTime.TabIndex = 6;
            this.chkLeadTime.Text = "Lead Time";
            this.chkLeadTime.UseVisualStyleBackColor = true;
            // 
            // chkQuoteTurnAround
            // 
            this.chkQuoteTurnAround.AutoSize = true;
            this.chkQuoteTurnAround.Location = new System.Drawing.Point(120, 29);
            this.chkQuoteTurnAround.Name = "chkQuoteTurnAround";
            this.chkQuoteTurnAround.Size = new System.Drawing.Size(150, 21);
            this.chkQuoteTurnAround.TabIndex = 7;
            this.chkQuoteTurnAround.Text = "Quote Turn Around";
            this.chkQuoteTurnAround.UseVisualStyleBackColor = true;
            // 
            // chkProduct
            // 
            this.chkProduct.AutoSize = true;
            this.chkProduct.Location = new System.Drawing.Point(280, 29);
            this.chkProduct.Name = "chkProduct";
            this.chkProduct.Size = new System.Drawing.Size(76, 21);
            this.chkProduct.TabIndex = 8;
            this.chkProduct.Text = "Product";
            this.chkProduct.UseVisualStyleBackColor = true;
            // 
            // chkInstallation
            // 
            this.chkInstallation.AutoSize = true;
            this.chkInstallation.Location = new System.Drawing.Point(366, 29);
            this.chkInstallation.Name = "chkInstallation";
            this.chkInstallation.Size = new System.Drawing.Size(94, 21);
            this.chkInstallation.TabIndex = 9;
            this.chkInstallation.Text = "Installation";
            this.chkInstallation.UseVisualStyleBackColor = true;
            // 
            // chkService
            // 
            this.chkService.AutoSize = true;
            this.chkService.Location = new System.Drawing.Point(470, 29);
            this.chkService.Name = "chkService";
            this.chkService.Size = new System.Drawing.Size(74, 21);
            this.chkService.TabIndex = 10;
            this.chkService.Text = "Service";
            this.chkService.UseVisualStyleBackColor = true;
            // 
            // dteStart
            // 
            this.dteStart.Location = new System.Drawing.Point(121, 80);
            this.dteStart.Name = "dteStart";
            this.dteStart.Size = new System.Drawing.Size(148, 20);
            this.dteStart.TabIndex = 11;
            // 
            // dteEnd
            // 
            this.dteEnd.Location = new System.Drawing.Point(296, 80);
            this.dteEnd.Name = "dteEnd";
            this.dteEnd.Size = new System.Drawing.Size(148, 20);
            this.dteEnd.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label2.Location = new System.Drawing.Point(34, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "Customer Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label3.Location = new System.Drawing.Point(154, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "Contact:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label4.Location = new System.Drawing.Point(208, 408);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "Correspondence Notes:";
            // 
            // txtCorrespondence
            // 
            this.txtCorrespondence.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.txtCorrespondence.Location = new System.Drawing.Point(69, 428);
            this.txtCorrespondence.Name = "txtCorrespondence";
            this.txtCorrespondence.Size = new System.Drawing.Size(436, 116);
            this.txtCorrespondence.TabIndex = 18;
            this.txtCorrespondence.Text = "";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "Traditional",
            "Slimline",
            "Both"});
            this.cmbType.Location = new System.Drawing.Point(216, 220);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(143, 25);
            this.cmbType.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label5.Location = new System.Drawing.Point(83, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 17);
            this.label5.TabIndex = 20;
            this.label5.Text = "Traditional/Slimline:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkLeadTime);
            this.groupBox1.Controls.Add(this.chkQuoteTurnAround);
            this.groupBox1.Controls.Add(this.chkProduct);
            this.groupBox1.Controls.Add(this.chkInstallation);
            this.groupBox1.Controls.Add(this.chkService);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.groupBox1.Location = new System.Drawing.Point(12, 328);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(551, 65);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Issues";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkEmail);
            this.groupBox2.Controls.Add(this.chkPhone);
            this.groupBox2.Controls.Add(this.chkPerson);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.groupBox2.Location = new System.Drawing.Point(135, 267);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(304, 55);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Contact";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(275, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "to";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label7.Location = new System.Drawing.Point(121, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(323, 17);
            this.label7.TabIndex = 24;
            this.label7.Text = "Correspondence Date";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbUser
            // 
            this.cmbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Items.AddRange(new object[] {
            "ALL"});
            this.cmbUser.Location = new System.Drawing.Point(186, 576);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(182, 25);
            this.cmbUser.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label8.Location = new System.Drawing.Point(219, 556);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 17);
            this.label8.TabIndex = 28;
            this.label8.Text = "Correspondence By:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(578, 8);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(855, 634);
            this.dataGridView1.TabIndex = 29;
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Items.AddRange(new object[] {
            "ALL"});
            this.cmbCustomer.Location = new System.Drawing.Point(149, 131);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(323, 25);
            this.cmbCustomer.TabIndex = 30;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(200, 613);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnCancel.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(3);
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 26;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnExport.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(285, 613);
            this.btnExport.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnExport.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnExport.Name = "btnExport";
            this.btnExport.Padding = new System.Windows.Forms.Padding(3);
            this.btnExport.Size = new System.Drawing.Size(75, 30);
            this.btnExport.TabIndex = 25;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // frmCorrespondenceExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 654);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cmbUser);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.txtCorrespondence);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dteEnd);
            this.Controls.Add(this.dteStart);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCorrespondenceExport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Correspondence Export";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.CheckBox chkEmail;
        private System.Windows.Forms.CheckBox chkPhone;
        private System.Windows.Forms.CheckBox chkPerson;
        private System.Windows.Forms.CheckBox chkLeadTime;
        private System.Windows.Forms.CheckBox chkQuoteTurnAround;
        private System.Windows.Forms.CheckBox chkProduct;
        private System.Windows.Forms.CheckBox chkInstallation;
        private System.Windows.Forms.CheckBox chkService;
        private System.Windows.Forms.DateTimePicker dteStart;
        private System.Windows.Forms.DateTimePicker dteEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox txtCorrespondence;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private buttonFormatting btnExport;
        private buttonFormatting btnCancel;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmbCustomer;
    }
}