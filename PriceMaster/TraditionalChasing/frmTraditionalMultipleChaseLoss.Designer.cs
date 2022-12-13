namespace PriceMaster.TraditionalChasing
{
    partial class frmTraditionalMultipleChaseLoss
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
            this.btnUpdateProject = new PriceMaster.buttonFormatting();
            this.label1 = new System.Windows.Forms.Label();
            this.chkNonResponsive = new System.Windows.Forms.CheckBox();
            this.chkLeadTimeTooLong = new System.Windows.Forms.CheckBox();
            this.chkQuoteTookTooLong = new System.Windows.Forms.CheckBox();
            this.chkUnableToMeetSpec = new System.Windows.Forms.CheckBox();
            this.chkTooExpensive = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnUpdateProject
            // 
            this.btnUpdateProject.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnUpdateProject.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnUpdateProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateProject.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateProject.ForeColor = System.Drawing.Color.White;
            this.btnUpdateProject.Location = new System.Drawing.Point(81, 121);
            this.btnUpdateProject.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnUpdateProject.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnUpdateProject.Name = "btnUpdateProject";
            this.btnUpdateProject.Padding = new System.Windows.Forms.Padding(3);
            this.btnUpdateProject.Size = new System.Drawing.Size(128, 30);
            this.btnUpdateProject.TabIndex = 80;
            this.btnUpdateProject.Text = "Update Project";
            this.btnUpdateProject.UseVisualStyleBackColor = false;
            this.btnUpdateProject.Click += new System.EventHandler(this.btnUpdateProject_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 13);
            this.label1.TabIndex = 79;
            this.label1.Text = "Please select a reason for losing this project";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkNonResponsive
            // 
            this.chkNonResponsive.AutoSize = true;
            this.chkNonResponsive.Location = new System.Drawing.Point(20, 88);
            this.chkNonResponsive.Name = "chkNonResponsive";
            this.chkNonResponsive.Size = new System.Drawing.Size(152, 17);
            this.chkNonResponsive.TabIndex = 78;
            this.chkNonResponsive.Text = "Non Responsive Customer";
            this.chkNonResponsive.UseVisualStyleBackColor = true;
            // 
            // chkLeadTimeTooLong
            // 
            this.chkLeadTimeTooLong.AutoSize = true;
            this.chkLeadTimeTooLong.Location = new System.Drawing.Point(151, 36);
            this.chkLeadTimeTooLong.Name = "chkLeadTimeTooLong";
            this.chkLeadTimeTooLong.Size = new System.Drawing.Size(116, 17);
            this.chkLeadTimeTooLong.TabIndex = 77;
            this.chkLeadTimeTooLong.Text = "Lead time too long.";
            this.chkLeadTimeTooLong.UseVisualStyleBackColor = true;
            // 
            // chkQuoteTookTooLong
            // 
            this.chkQuoteTookTooLong.AutoSize = true;
            this.chkQuoteTookTooLong.Location = new System.Drawing.Point(20, 63);
            this.chkQuoteTookTooLong.Name = "chkQuoteTookTooLong";
            this.chkQuoteTookTooLong.Size = new System.Drawing.Size(123, 17);
            this.chkQuoteTookTooLong.TabIndex = 76;
            this.chkQuoteTookTooLong.Text = "Quote took too long.";
            this.chkQuoteTookTooLong.UseVisualStyleBackColor = true;
            // 
            // chkUnableToMeetSpec
            // 
            this.chkUnableToMeetSpec.AutoSize = true;
            this.chkUnableToMeetSpec.Location = new System.Drawing.Point(151, 63);
            this.chkUnableToMeetSpec.Name = "chkUnableToMeetSpec";
            this.chkUnableToMeetSpec.Size = new System.Drawing.Size(127, 17);
            this.chkUnableToMeetSpec.TabIndex = 75;
            this.chkUnableToMeetSpec.Text = "Unable to meet spec.";
            this.chkUnableToMeetSpec.UseVisualStyleBackColor = true;
            // 
            // chkTooExpensive
            // 
            this.chkTooExpensive.AutoSize = true;
            this.chkTooExpensive.Location = new System.Drawing.Point(20, 36);
            this.chkTooExpensive.Name = "chkTooExpensive";
            this.chkTooExpensive.Size = new System.Drawing.Size(99, 17);
            this.chkTooExpensive.TabIndex = 74;
            this.chkTooExpensive.Text = "Too expensive.";
            this.chkTooExpensive.UseVisualStyleBackColor = true;
            // 
            // frmTraditionalMultipleChaseLoss
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 162);
            this.ControlBox = false;
            this.Controls.Add(this.btnUpdateProject);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkNonResponsive);
            this.Controls.Add(this.chkLeadTimeTooLong);
            this.Controls.Add(this.chkQuoteTookTooLong);
            this.Controls.Add(this.chkUnableToMeetSpec);
            this.Controls.Add(this.chkTooExpensive);
            this.Name = "frmTraditionalMultipleChaseLoss";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Traditional Loss Reason";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private buttonFormatting btnUpdateProject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkNonResponsive;
        private System.Windows.Forms.CheckBox chkLeadTimeTooLong;
        private System.Windows.Forms.CheckBox chkQuoteTookTooLong;
        private System.Windows.Forms.CheckBox chkUnableToMeetSpec;
        private System.Windows.Forms.CheckBox chkTooExpensive;
    }
}