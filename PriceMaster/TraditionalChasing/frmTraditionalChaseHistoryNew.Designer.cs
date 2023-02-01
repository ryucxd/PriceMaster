namespace PriceMaster
{
    partial class frmTraditionalChaseHistoryNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTraditionalChaseHistoryNew));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.chkPhone = new System.Windows.Forms.CheckBox();
            this.chkEmail = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNext = new System.Windows.Forms.Label();
            this.lblChase = new System.Windows.Forms.Label();
            this.dteNextDate = new System.Windows.Forms.DateTimePicker();
            this.dteChaseDate = new System.Windows.Forms.DateTimePicker();
            this.chkNoFollowup = new System.Windows.Forms.CheckBox();
            this.btnChaseComplete = new PriceMaster.buttonFormatting();
            this.chkChaseComplete = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
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
            this.dataGridView1.Location = new System.Drawing.Point(562, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(240, 369);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(12, 98);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(529, 218);
            this.txtDescription.TabIndex = 61;
            this.txtDescription.Text = "";
            // 
            // chkPhone
            // 
            this.chkPhone.AutoSize = true;
            this.chkPhone.Location = new System.Drawing.Point(217, 45);
            this.chkPhone.Name = "chkPhone";
            this.chkPhone.Size = new System.Drawing.Size(57, 17);
            this.chkPhone.TabIndex = 78;
            this.chkPhone.Text = "Phone";
            this.chkPhone.UseVisualStyleBackColor = true;
            // 
            // chkEmail
            // 
            this.chkEmail.AutoSize = true;
            this.chkEmail.Location = new System.Drawing.Point(280, 45);
            this.chkEmail.Name = "chkEmail";
            this.chkEmail.Size = new System.Drawing.Size(51, 17);
            this.chkEmail.TabIndex = 77;
            this.chkEmail.Text = "Email";
            this.chkEmail.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label2.Location = new System.Drawing.Point(14, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(529, 17);
            this.label2.TabIndex = 74;
            this.label2.Text = "Quotation Chase Description";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblNext
            // 
            this.lblNext.AutoSize = true;
            this.lblNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblNext.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblNext.Location = new System.Drawing.Point(112, 329);
            this.lblNext.Name = "lblNext";
            this.lblNext.Size = new System.Drawing.Size(127, 17);
            this.lblNext.TabIndex = 73;
            this.lblNext.Text = "NEXT Chase Date:";
            this.lblNext.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblChase
            // 
            this.lblChase.AutoSize = true;
            this.lblChase.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblChase.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblChase.Location = new System.Drawing.Point(50, 19);
            this.lblChase.Name = "lblChase";
            this.lblChase.Size = new System.Drawing.Size(152, 17);
            this.lblChase.TabIndex = 72;
            this.lblChase.Text = "Quotation Chase Date:";
            this.lblChase.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // dteNextDate
            // 
            this.dteNextDate.Location = new System.Drawing.Point(243, 329);
            this.dteNextDate.Name = "dteNextDate";
            this.dteNextDate.Size = new System.Drawing.Size(145, 20);
            this.dteNextDate.TabIndex = 71;
            // 
            // dteChaseDate
            // 
            this.dteChaseDate.Enabled = false;
            this.dteChaseDate.Location = new System.Drawing.Point(206, 19);
            this.dteChaseDate.Name = "dteChaseDate";
            this.dteChaseDate.Size = new System.Drawing.Size(145, 20);
            this.dteChaseDate.TabIndex = 70;
            // 
            // chkNoFollowup
            // 
            this.chkNoFollowup.AutoSize = true;
            this.chkNoFollowup.Location = new System.Drawing.Point(217, 330);
            this.chkNoFollowup.Name = "chkNoFollowup";
            this.chkNoFollowup.Size = new System.Drawing.Size(123, 17);
            this.chkNoFollowup.TabIndex = 76;
            this.chkNoFollowup.Text = "No followup required";
            this.chkNoFollowup.UseVisualStyleBackColor = true;
            this.chkNoFollowup.Visible = false;
            // 
            // btnChaseComplete
            // 
            this.btnChaseComplete.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnChaseComplete.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnChaseComplete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChaseComplete.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChaseComplete.ForeColor = System.Drawing.Color.White;
            this.btnChaseComplete.Location = new System.Drawing.Point(186, 354);
            this.btnChaseComplete.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnChaseComplete.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnChaseComplete.Name = "btnChaseComplete";
            this.btnChaseComplete.Padding = new System.Windows.Forms.Padding(3);
            this.btnChaseComplete.Size = new System.Drawing.Size(202, 30);
            this.btnChaseComplete.TabIndex = 79;
            this.btnChaseComplete.Text = "Mark Chase as Complete";
            this.btnChaseComplete.UseVisualStyleBackColor = false;
            this.btnChaseComplete.Click += new System.EventHandler(this.btnChaseComplete_Click);
            // 
            // chkChaseComplete
            // 
            this.chkChaseComplete.AutoSize = true;
            this.chkChaseComplete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.chkChaseComplete.Location = new System.Drawing.Point(217, 359);
            this.chkChaseComplete.Name = "chkChaseComplete";
            this.chkChaseComplete.Size = new System.Drawing.Size(128, 21);
            this.chkChaseComplete.TabIndex = 80;
            this.chkChaseComplete.Text = "Chase complete";
            this.chkChaseComplete.UseVisualStyleBackColor = true;
            this.chkChaseComplete.Visible = false;
            // 
            // frmSlimlineChaseHistoryNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 393);
            this.Controls.Add(this.chkChaseComplete);
            this.Controls.Add(this.btnChaseComplete);
            this.Controls.Add(this.chkPhone);
            this.Controls.Add(this.chkEmail);
            this.Controls.Add(this.chkNoFollowup);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblNext);
            this.Controls.Add(this.lblChase);
            this.Controls.Add(this.dteNextDate);
            this.Controls.Add(this.dteChaseDate);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSlimlineChaseHistoryNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chase History";
            this.Shown += new System.EventHandler(this.frmChaseHistory_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.CheckBox chkPhone;
        private System.Windows.Forms.CheckBox chkEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNext;
        private System.Windows.Forms.Label lblChase;
        private System.Windows.Forms.DateTimePicker dteNextDate;
        private System.Windows.Forms.DateTimePicker dteChaseDate;
        private System.Windows.Forms.CheckBox chkNoFollowup;
        private buttonFormatting btnChaseComplete;
        private System.Windows.Forms.CheckBox chkChaseComplete;
    }
}