namespace PriceMaster.TraditionalChasing
{
    partial class frmTraditionalEnquiryHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTraditionalEnquiryHistory));
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvAttachments = new System.Windows.Forms.DataGridView();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.lblSentBy = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttachments)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Related Enquiries";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 32);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(185, 931);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(203, 760);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 15);
            this.label2.TabIndex = 29;
            this.label2.Text = "Email Attachments:";
            // 
            // dgvAttachments
            // 
            this.dgvAttachments.AllowUserToAddRows = false;
            this.dgvAttachments.AllowUserToDeleteRows = false;
            this.dgvAttachments.AllowUserToResizeColumns = false;
            this.dgvAttachments.AllowUserToResizeRows = false;
            this.dgvAttachments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAttachments.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAttachments.Location = new System.Drawing.Point(203, 778);
            this.dgvAttachments.Name = "dgvAttachments";
            this.dgvAttachments.RowHeadersVisible = false;
            this.dgvAttachments.Size = new System.Drawing.Size(898, 185);
            this.dgvAttachments.TabIndex = 28;
            this.dgvAttachments.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAttachments_CellMouseClick);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(203, 32);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(910, 718);
            this.webBrowser1.TabIndex = 27;
            // 
            // lblSentBy
            // 
            this.lblSentBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lblSentBy.Location = new System.Drawing.Point(206, 9);
            this.lblSentBy.Name = "lblSentBy";
            this.lblSentBy.Size = new System.Drawing.Size(907, 20);
            this.lblSentBy.TabIndex = 31;
            this.lblSentBy.Text = "Email Body";
            this.lblSentBy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmTraditionalEnquiryHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 979);
            this.Controls.Add(this.lblSentBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvAttachments);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTraditionalEnquiryHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Enquiry History";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttachments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvAttachments;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Label lblSentBy;
    }
}