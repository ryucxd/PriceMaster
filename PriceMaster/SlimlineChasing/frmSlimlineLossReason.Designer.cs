namespace PriceMaster
{
    partial class frmSlimlineLossReason
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
            this.txtReason = new System.Windows.Forms.RichTextBox();
            this.lblLost = new System.Windows.Forms.Label();
            this.btnSave = new PriceMaster.buttonFormatting();
            this.SuspendLayout();
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(12, 29);
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(576, 271);
            this.txtReason.TabIndex = 0;
            this.txtReason.Text = "";
            // 
            // lblLost
            // 
            this.lblLost.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblLost.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblLost.Location = new System.Drawing.Point(12, 9);
            this.lblLost.Name = "lblLost";
            this.lblLost.Size = new System.Drawing.Size(575, 17);
            this.lblLost.TabIndex = 65;
            this.lblLost.Text = "Please enter why this was lost.";
            this.lblLost.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(262, 303);
            this.btnSave.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnSave.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(3);
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 66;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmTraditionalLossReason
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 342);
            this.ControlBox = false;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblLost);
            this.Controls.Add(this.txtReason);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmTraditionalLossReason";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reason for loss";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtReason;
        private System.Windows.Forms.Label lblLost;
        private buttonFormatting btnSave;
    }
}