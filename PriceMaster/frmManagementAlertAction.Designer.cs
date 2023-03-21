namespace PriceMaster
{
    partial class frmManagementAlertAction
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
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.chkComplete = new System.Windows.Forms.CheckBox();
            this.btnCancel = new PriceMaster.buttonFormatting();
            this.btnComplete = new PriceMaster.buttonFormatting();
            this.SuspendLayout();
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(12, 44);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(627, 310);
            this.txtDescription.TabIndex = 0;
            this.txtDescription.Text = "";
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(627, 23);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Enter Resolution";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkComplete
            // 
            this.chkComplete.AutoSize = true;
            this.chkComplete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.chkComplete.Location = new System.Drawing.Point(329, 369);
            this.chkComplete.Name = "chkComplete";
            this.chkComplete.Size = new System.Drawing.Size(91, 22);
            this.chkComplete.TabIndex = 4;
            this.chkComplete.Text = "Complete";
            this.chkComplete.UseVisualStyleBackColor = true;
            this.chkComplete.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(178, 365);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnCancel.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(3);
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnComplete
            // 
            this.btnComplete.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnComplete.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnComplete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComplete.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComplete.ForeColor = System.Drawing.Color.White;
            this.btnComplete.Location = new System.Drawing.Point(263, 365);
            this.btnComplete.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnComplete.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Padding = new System.Windows.Forms.Padding(3);
            this.btnComplete.Size = new System.Drawing.Size(223, 30);
            this.btnComplete.TabIndex = 1;
            this.btnComplete.Text = "Save and mark as complete";
            this.btnComplete.UseVisualStyleBackColor = false;
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // frmManagementAlertAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 408);
            this.ControlBox = false;
            this.Controls.Add(this.chkComplete);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnComplete);
            this.Controls.Add(this.txtDescription);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManagementAlertAction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Management Alert";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtDescription;
        private buttonFormatting btnComplete;
        private buttonFormatting btnCancel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.CheckBox chkComplete;
    }
}