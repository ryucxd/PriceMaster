﻿namespace PriceMaster
{
    partial class frmTraditionalChase
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
            this.dteChaseDate = new System.Windows.Forms.DateTimePicker();
            this.dteNextDate = new System.Windows.Forms.DateTimePicker();
            this.lblChase = new System.Windows.Forms.Label();
            this.lblNext = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.chkNoFollowup = new System.Windows.Forms.CheckBox();
            this.chkHiddenFollowup = new System.Windows.Forms.CheckBox();
            this.chkPhone = new System.Windows.Forms.CheckBox();
            this.chkEmail = new System.Windows.Forms.CheckBox();
            this.chkMultipleChase = new System.Windows.Forms.CheckBox();
            this.chkFailed = new System.Windows.Forms.CheckBox();
            this.chkSlimlineQuote = new System.Windows.Forms.CheckBox();
            this.btnSaveManagement = new PriceMaster.buttonFormatting();
            this.btnCancel = new PriceMaster.buttonFormatting();
            this.btnSave = new PriceMaster.buttonFormatting();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dteChaseDate
            // 
            this.dteChaseDate.Enabled = false;
            this.dteChaseDate.Location = new System.Drawing.Point(204, 9);
            this.dteChaseDate.Name = "dteChaseDate";
            this.dteChaseDate.Size = new System.Drawing.Size(145, 20);
            this.dteChaseDate.TabIndex = 0;
            // 
            // dteNextDate
            // 
            this.dteNextDate.Location = new System.Drawing.Point(204, 301);
            this.dteNextDate.Name = "dteNextDate";
            this.dteNextDate.Size = new System.Drawing.Size(145, 20);
            this.dteNextDate.TabIndex = 1;
            // 
            // lblChase
            // 
            this.lblChase.AutoSize = true;
            this.lblChase.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblChase.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblChase.Location = new System.Drawing.Point(48, 9);
            this.lblChase.Name = "lblChase";
            this.lblChase.Size = new System.Drawing.Size(152, 17);
            this.lblChase.TabIndex = 58;
            this.lblChase.Text = "Quotation Chase Date:";
            this.lblChase.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblNext
            // 
            this.lblNext.AutoSize = true;
            this.lblNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblNext.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblNext.Location = new System.Drawing.Point(73, 301);
            this.lblNext.Name = "lblNext";
            this.lblNext.Size = new System.Drawing.Size(127, 17);
            this.lblNext.TabIndex = 59;
            this.lblNext.Text = "NEXT Chase Date:";
            this.lblNext.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(12, 77);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(529, 218);
            this.txtDescription.TabIndex = 60;
            this.txtDescription.Text = "";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(529, 17);
            this.label2.TabIndex = 61;
            this.label2.Text = "Quotation Chase Description";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(553, 22);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(240, 381);
            this.dataGridView1.TabIndex = 64;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label3.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label3.Location = new System.Drawing.Point(547, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(240, 17);
            this.label3.TabIndex = 65;
            this.label3.Text = "Quotation Chase History:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // chkNoFollowup
            // 
            this.chkNoFollowup.AutoSize = true;
            this.chkNoFollowup.Location = new System.Drawing.Point(356, 303);
            this.chkNoFollowup.Name = "chkNoFollowup";
            this.chkNoFollowup.Size = new System.Drawing.Size(123, 17);
            this.chkNoFollowup.TabIndex = 66;
            this.chkNoFollowup.Text = "No followup required";
            this.chkNoFollowup.UseVisualStyleBackColor = true;
            this.chkNoFollowup.CheckedChanged += new System.EventHandler(this.chkNoFollowup_CheckedChanged);
            // 
            // chkHiddenFollowup
            // 
            this.chkHiddenFollowup.AutoSize = true;
            this.chkHiddenFollowup.Location = new System.Drawing.Point(226, 301);
            this.chkHiddenFollowup.Name = "chkHiddenFollowup";
            this.chkHiddenFollowup.Size = new System.Drawing.Size(123, 17);
            this.chkHiddenFollowup.TabIndex = 67;
            this.chkHiddenFollowup.Text = "No followup required";
            this.chkHiddenFollowup.UseVisualStyleBackColor = true;
            this.chkHiddenFollowup.Visible = false;
            // 
            // chkPhone
            // 
            this.chkPhone.AutoSize = true;
            this.chkPhone.Location = new System.Drawing.Point(214, 35);
            this.chkPhone.Name = "chkPhone";
            this.chkPhone.Size = new System.Drawing.Size(57, 17);
            this.chkPhone.TabIndex = 71;
            this.chkPhone.Text = "Phone";
            this.chkPhone.UseVisualStyleBackColor = true;
            // 
            // chkEmail
            // 
            this.chkEmail.AutoSize = true;
            this.chkEmail.Location = new System.Drawing.Point(277, 35);
            this.chkEmail.Name = "chkEmail";
            this.chkEmail.Size = new System.Drawing.Size(51, 17);
            this.chkEmail.TabIndex = 70;
            this.chkEmail.Text = "Email";
            this.chkEmail.UseVisualStyleBackColor = true;
            // 
            // chkMultipleChase
            // 
            this.chkMultipleChase.AutoSize = true;
            this.chkMultipleChase.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.chkMultipleChase.Location = new System.Drawing.Point(85, 329);
            this.chkMultipleChase.Name = "chkMultipleChase";
            this.chkMultipleChase.Size = new System.Drawing.Size(394, 21);
            this.chkMultipleChase.TabIndex = 101;
            this.chkMultipleChase.Text = "ADD THIS CHASE TO MULTIPLE TRADITIONAL QUOTES";
            this.chkMultipleChase.UseVisualStyleBackColor = true;
            // 
            // chkFailed
            // 
            this.chkFailed.AutoSize = true;
            this.chkFailed.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.chkFailed.Location = new System.Drawing.Point(377, 30);
            this.chkFailed.Name = "chkFailed";
            this.chkFailed.Size = new System.Drawing.Size(153, 22);
            this.chkFailed.TabIndex = 102;
            this.chkFailed.Text = "FAILED CONTACT";
            this.chkFailed.UseVisualStyleBackColor = true;
            // 
            // chkSlimlineQuote
            // 
            this.chkSlimlineQuote.AutoSize = true;
            this.chkSlimlineQuote.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.chkSlimlineQuote.Location = new System.Drawing.Point(124, 356);
            this.chkSlimlineQuote.Name = "chkSlimlineQuote";
            this.chkSlimlineQuote.Size = new System.Drawing.Size(297, 21);
            this.chkSlimlineQuote.TabIndex = 103;
            this.chkSlimlineQuote.Text = "ADD THIS CHASE TO A SLIMLINE QUOTE";
            this.chkSlimlineQuote.UseVisualStyleBackColor = true;
            // 
            // btnSaveManagement
            // 
            this.btnSaveManagement.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSaveManagement.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSaveManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveManagement.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveManagement.ForeColor = System.Drawing.Color.White;
            this.btnSaveManagement.Location = new System.Drawing.Point(293, 380);
            this.btnSaveManagement.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnSaveManagement.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnSaveManagement.Name = "btnSaveManagement";
            this.btnSaveManagement.Padding = new System.Windows.Forms.Padding(3);
            this.btnSaveManagement.Size = new System.Drawing.Size(222, 30);
            this.btnSaveManagement.TabIndex = 100;
            this.btnSaveManagement.Text = "Save AND alert management";
            this.btnSaveManagement.UseVisualStyleBackColor = false;
            this.btnSaveManagement.Click += new System.EventHandler(this.btnSaveManagement_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(33, 380);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnCancel.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(3);
            this.btnCancel.Size = new System.Drawing.Size(120, 30);
            this.btnCancel.TabIndex = 63;
            this.btnCancel.Text = "Cancel Chase";
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
            this.btnSave.Location = new System.Drawing.Point(163, 380);
            this.btnSave.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnSave.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(3);
            this.btnSave.Size = new System.Drawing.Size(120, 30);
            this.btnSave.TabIndex = 62;
            this.btnSave.Text = "Save Chase";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmTraditionalChase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 415);
            this.ControlBox = false;
            this.Controls.Add(this.chkSlimlineQuote);
            this.Controls.Add(this.chkFailed);
            this.Controls.Add(this.chkMultipleChase);
            this.Controls.Add(this.btnSaveManagement);
            this.Controls.Add(this.chkPhone);
            this.Controls.Add(this.chkEmail);
            this.Controls.Add(this.chkHiddenFollowup);
            this.Controls.Add(this.chkNoFollowup);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblNext);
            this.Controls.Add(this.lblChase);
            this.Controls.Add(this.dteNextDate);
            this.Controls.Add(this.dteChaseDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmTraditionalChase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Traditional Quotation Chasing";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dteChaseDate;
        private System.Windows.Forms.DateTimePicker dteNextDate;
        private System.Windows.Forms.Label lblChase;
        private System.Windows.Forms.Label lblNext;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.Label label2;
        private buttonFormatting btnSave;
        private buttonFormatting btnCancel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkNoFollowup;
        private System.Windows.Forms.CheckBox chkHiddenFollowup;
        private System.Windows.Forms.CheckBox chkPhone;
        private System.Windows.Forms.CheckBox chkEmail;
        private buttonFormatting btnSaveManagement;
        private System.Windows.Forms.CheckBox chkMultipleChase;
        private System.Windows.Forms.CheckBox chkFailed;
        private System.Windows.Forms.CheckBox chkSlimlineQuote;
    }
}