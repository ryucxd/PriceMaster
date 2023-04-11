namespace PriceMaster
{
    partial class frmUniqueCustomerChaseCount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUniqueCustomerChaseCount));
            this.dteStart = new System.Windows.Forms.DateTimePicker();
            this.dteEnd = new System.Windows.Forms.DateTimePicker();
            this.lblStart = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbStaffSelection = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.cartesianChart1 = new LiveCharts.Wpf.CartesianChart();
            this.SuspendLayout();
            // 
            // dteStart
            // 
            this.dteStart.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dteStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.dteStart.Location = new System.Drawing.Point(542, 35);
            this.dteStart.Name = "dteStart";
            this.dteStart.Size = new System.Drawing.Size(183, 24);
            this.dteStart.TabIndex = 1;
            this.dteStart.CloseUp += new System.EventHandler(this.dteStart_CloseUp);
            // 
            // dteEnd
            // 
            this.dteEnd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dteEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.dteEnd.Location = new System.Drawing.Point(731, 35);
            this.dteEnd.Name = "dteEnd";
            this.dteEnd.Size = new System.Drawing.Size(183, 24);
            this.dteEnd.TabIndex = 2;
            this.dteEnd.CloseUp += new System.EventHandler(this.dteEnd_CloseUp);
            // 
            // lblStart
            // 
            this.lblStart.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lblStart.Location = new System.Drawing.Point(542, 9);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(183, 23);
            this.lblStart.TabIndex = 3;
            this.lblStart.Text = "Start Date";
            this.lblStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(731, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "End Date";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbStaffSelection
            // 
            this.cmbStaffSelection.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbStaffSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.cmbStaffSelection.FormattingEnabled = true;
            this.cmbStaffSelection.Location = new System.Drawing.Point(920, 34);
            this.cmbStaffSelection.Name = "cmbStaffSelection";
            this.cmbStaffSelection.Size = new System.Drawing.Size(192, 25);
            this.cmbStaffSelection.TabIndex = 5;
            this.cmbStaffSelection.SelectedIndexChanged += new System.EventHandler(this.cmbStaffSelection_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label2.Location = new System.Drawing.Point(920, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Staff Selection";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // elementHost1
            // 
            this.elementHost1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.elementHost1.Location = new System.Drawing.Point(12, 69);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(1630, 849);
            this.elementHost1.TabIndex = 7;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.cartesianChart1;
            // 
            // frmUniqueCustomerChaseCount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1654, 930);
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbStaffSelection);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.dteEnd);
            this.Controls.Add(this.dteStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "frmUniqueCustomerChaseCount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Unique Customer ";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dteStart;
        private System.Windows.Forms.DateTimePicker dteEnd;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbStaffSelection;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private LiveCharts.Wpf.CartesianChart cartesianChart1;
    }
}