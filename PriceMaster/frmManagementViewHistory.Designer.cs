namespace PriceMaster
{
    partial class frmManagementViewHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManagementViewHistory));
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
            this.LblCustomer = new System.Windows.Forms.Label();
            this.btnDrawings = new PriceMaster.buttonFormatting();
            this.btnQuote = new PriceMaster.buttonFormatting();
            this.btnPrint = new PriceMaster.buttonFormatting();
            this.btnEmail = new PriceMaster.buttonFormatting();
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
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(240, 445);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(273, 142);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(529, 218);
            this.txtDescription.TabIndex = 61;
            this.txtDescription.Text = "";
            // 
            // chkPhone
            // 
            this.chkPhone.AutoSize = true;
            this.chkPhone.Location = new System.Drawing.Point(478, 89);
            this.chkPhone.Name = "chkPhone";
            this.chkPhone.Size = new System.Drawing.Size(57, 17);
            this.chkPhone.TabIndex = 78;
            this.chkPhone.Text = "Phone";
            this.chkPhone.UseVisualStyleBackColor = true;
            // 
            // chkEmail
            // 
            this.chkEmail.AutoSize = true;
            this.chkEmail.Location = new System.Drawing.Point(541, 89);
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
            this.label2.Location = new System.Drawing.Point(275, 121);
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
            this.lblNext.Location = new System.Drawing.Point(373, 403);
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
            this.lblChase.Location = new System.Drawing.Point(311, 63);
            this.lblChase.Name = "lblChase";
            this.lblChase.Size = new System.Drawing.Size(152, 17);
            this.lblChase.TabIndex = 72;
            this.lblChase.Text = "Quotation Chase Date:";
            this.lblChase.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // dteNextDate
            // 
            this.dteNextDate.Location = new System.Drawing.Point(504, 403);
            this.dteNextDate.Name = "dteNextDate";
            this.dteNextDate.Size = new System.Drawing.Size(145, 20);
            this.dteNextDate.TabIndex = 71;
            // 
            // dteChaseDate
            // 
            this.dteChaseDate.Enabled = false;
            this.dteChaseDate.Location = new System.Drawing.Point(467, 63);
            this.dteChaseDate.Name = "dteChaseDate";
            this.dteChaseDate.Size = new System.Drawing.Size(145, 20);
            this.dteChaseDate.TabIndex = 70;
            // 
            // chkNoFollowup
            // 
            this.chkNoFollowup.AutoSize = true;
            this.chkNoFollowup.Location = new System.Drawing.Point(469, 403);
            this.chkNoFollowup.Name = "chkNoFollowup";
            this.chkNoFollowup.Size = new System.Drawing.Size(123, 17);
            this.chkNoFollowup.TabIndex = 76;
            this.chkNoFollowup.Text = "No followup required";
            this.chkNoFollowup.UseVisualStyleBackColor = true;
            this.chkNoFollowup.Visible = false;
            // 
            // LblCustomer
            // 
            this.LblCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.LblCustomer.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.LblCustomer.Location = new System.Drawing.Point(275, 12);
            this.LblCustomer.Name = "LblCustomer";
            this.LblCustomer.Size = new System.Drawing.Size(527, 30);
            this.LblCustomer.TabIndex = 79;
            this.LblCustomer.Text = "CUSTOMER";
            this.LblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDrawings
            // 
            this.btnDrawings.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnDrawings.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnDrawings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDrawings.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDrawings.ForeColor = System.Drawing.Color.White;
            this.btnDrawings.Location = new System.Drawing.Point(710, 466);
            this.btnDrawings.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnDrawings.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnDrawings.Name = "btnDrawings";
            this.btnDrawings.Padding = new System.Windows.Forms.Padding(3);
            this.btnDrawings.Size = new System.Drawing.Size(92, 30);
            this.btnDrawings.TabIndex = 81;
            this.btnDrawings.Text = "Drawings";
            this.btnDrawings.UseVisualStyleBackColor = false;
            this.btnDrawings.Click += new System.EventHandler(this.btnDrawings_Click);
            // 
            // btnQuote
            // 
            this.btnQuote.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnQuote.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnQuote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuote.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuote.ForeColor = System.Drawing.Color.White;
            this.btnQuote.Location = new System.Drawing.Point(710, 431);
            this.btnQuote.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnQuote.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnQuote.Name = "btnQuote";
            this.btnQuote.Padding = new System.Windows.Forms.Padding(3);
            this.btnQuote.Size = new System.Drawing.Size(92, 30);
            this.btnQuote.TabIndex = 80;
            this.btnQuote.Text = "Quote";
            this.btnQuote.UseVisualStyleBackColor = false;
            this.btnQuote.Click += new System.EventHandler(this.btnQuote_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(710, 396);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnPrint.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Padding = new System.Windows.Forms.Padding(3);
            this.btnPrint.Size = new System.Drawing.Size(92, 30);
            this.btnPrint.TabIndex = 82;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnEmail
            // 
            this.btnEmail.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnEmail.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmail.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmail.ForeColor = System.Drawing.Color.White;
            this.btnEmail.Location = new System.Drawing.Point(710, 361);
            this.btnEmail.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnEmail.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Padding = new System.Windows.Forms.Padding(3);
            this.btnEmail.Size = new System.Drawing.Size(92, 30);
            this.btnEmail.TabIndex = 83;
            this.btnEmail.Text = "Email";
            this.btnEmail.UseVisualStyleBackColor = false;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // frmManagementViewHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 500);
            this.Controls.Add(this.btnEmail);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnDrawings);
            this.Controls.Add(this.btnQuote);
            this.Controls.Add(this.LblCustomer);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManagementViewHistory";
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
        private System.Windows.Forms.Label LblCustomer;
        private buttonFormatting btnQuote;
        private buttonFormatting btnDrawings;
        private buttonFormatting btnPrint;
        private buttonFormatting btnEmail;
    }
}