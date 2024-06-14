namespace PriceMaster
{
    partial class frmManagementViewDetailed
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManagementViewDetailed));
            this.txtCorrespondenceDate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnComplete = new PriceMaster.buttonFormatting();
            this.btnClose = new PriceMaster.buttonFormatting();
            this.txtQuoteId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCorrespondenceBy = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtResolution = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtCorrespondenceDate
            // 
            this.txtCorrespondenceDate.Location = new System.Drawing.Point(243, 66);
            this.txtCorrespondenceDate.Name = "txtCorrespondenceDate";
            this.txtCorrespondenceDate.ReadOnly = true;
            this.txtCorrespondenceDate.Size = new System.Drawing.Size(141, 20);
            this.txtCorrespondenceDate.TabIndex = 101;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label3.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label3.Location = new System.Drawing.Point(23, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(221, 17);
            this.label3.TabIndex = 100;
            this.label3.Text = "Correspondence Date:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblTitle.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(529, 17);
            this.lblTitle.TabIndex = 98;
            this.lblTitle.Text = "CUSTOMER Correspondence";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label2.Location = new System.Drawing.Point(11, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(529, 17);
            this.label2.TabIndex = 95;
            this.label2.Text = "Correspondence Description";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(12, 142);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(529, 218);
            this.txtDescription.TabIndex = 94;
            this.txtDescription.Text = "";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label1.Location = new System.Drawing.Point(15, 385);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(528, 17);
            this.label1.TabIndex = 103;
            this.label1.Text = "Correspondence Resolution";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnComplete
            // 
            this.btnComplete.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnComplete.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnComplete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComplete.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComplete.ForeColor = System.Drawing.Color.White;
            this.btnComplete.Location = new System.Drawing.Point(255, 627);
            this.btnComplete.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnComplete.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Padding = new System.Windows.Forms.Padding(3);
            this.btnComplete.Size = new System.Drawing.Size(155, 30);
            this.btnComplete.TabIndex = 104;
            this.btnComplete.Text = "Mark as Resolved";
            this.btnComplete.UseVisualStyleBackColor = false;
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(170, 627);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnClose.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(3);
            this.btnClose.Size = new System.Drawing.Size(75, 30);
            this.btnClose.TabIndex = 105;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtQuoteId
            // 
            this.txtQuoteId.Location = new System.Drawing.Point(243, 92);
            this.txtQuoteId.Name = "txtQuoteId";
            this.txtQuoteId.ReadOnly = true;
            this.txtQuoteId.Size = new System.Drawing.Size(141, 20);
            this.txtQuoteId.TabIndex = 107;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label4.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label4.Location = new System.Drawing.Point(23, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(221, 17);
            this.label4.TabIndex = 106;
            this.label4.Text = "Quote ID:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // txtCorrespondenceBy
            // 
            this.txtCorrespondenceBy.Location = new System.Drawing.Point(243, 40);
            this.txtCorrespondenceBy.Name = "txtCorrespondenceBy";
            this.txtCorrespondenceBy.ReadOnly = true;
            this.txtCorrespondenceBy.Size = new System.Drawing.Size(141, 20);
            this.txtCorrespondenceBy.TabIndex = 109;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label5.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label5.Location = new System.Drawing.Point(23, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(221, 17);
            this.label5.TabIndex = 108;
            this.label5.Text = "Correspondence By:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // txtResolution
            // 
            this.txtResolution.Location = new System.Drawing.Point(12, 405);
            this.txtResolution.Name = "txtResolution";
            this.txtResolution.Size = new System.Drawing.Size(526, 218);
            this.txtResolution.TabIndex = 110;
            this.txtResolution.Text = "";
            // 
            // frmManagementViewDetailed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 663);
            this.Controls.Add(this.txtResolution);
            this.Controls.Add(this.txtCorrespondenceBy);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtQuoteId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnComplete);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCorrespondenceDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDescription);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManagementViewDetailed";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Management Alert";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCorrespondenceDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.Label label1;
        private buttonFormatting btnComplete;
        private buttonFormatting btnClose;
        private System.Windows.Forms.TextBox txtQuoteId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCorrespondenceBy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox txtResolution;
    }
}