namespace PriceMaster
{
    partial class frmSectorManagementView
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
            this.dgvSalesMemberOne = new System.Windows.Forms.DataGridView();
            this.dgvSalesMemberTwo = new System.Windows.Forms.DataGridView();
            this.dgvSalesMemberThree = new System.Windows.Forms.DataGridView();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dteStart = new System.Windows.Forms.DateTimePicker();
            this.dteEnd = new System.Windows.Forms.DateTimePicker();
            this.pieChartOne = new System.Windows.Forms.Integration.ElementHost();
            this.pieChart1 = new LiveCharts.Wpf.PieChart();
            this.pieChartTwo = new System.Windows.Forms.Integration.ElementHost();
            this.pieChart2 = new LiveCharts.Wpf.PieChart();
            this.pieChartThree = new System.Windows.Forms.Integration.ElementHost();
            this.pieChart3 = new LiveCharts.Wpf.PieChart();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSalesMemberOne = new System.Windows.Forms.Label();
            this.lblSalesMemberTwo = new System.Windows.Forms.Label();
            this.lblSalesMemberThree = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesMemberOne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesMemberTwo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesMemberThree)).BeginInit();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSalesMemberOne
            // 
            this.dgvSalesMemberOne.AllowUserToAddRows = false;
            this.dgvSalesMemberOne.AllowUserToDeleteRows = false;
            this.dgvSalesMemberOne.AllowUserToResizeColumns = false;
            this.dgvSalesMemberOne.AllowUserToResizeRows = false;
            this.dgvSalesMemberOne.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesMemberOne.Location = new System.Drawing.Point(12, 113);
            this.dgvSalesMemberOne.Name = "dgvSalesMemberOne";
            this.dgvSalesMemberOne.RowHeadersVisible = false;
            this.dgvSalesMemberOne.Size = new System.Drawing.Size(444, 486);
            this.dgvSalesMemberOne.TabIndex = 0;
            // 
            // dgvSalesMemberTwo
            // 
            this.dgvSalesMemberTwo.AllowUserToAddRows = false;
            this.dgvSalesMemberTwo.AllowUserToDeleteRows = false;
            this.dgvSalesMemberTwo.AllowUserToResizeColumns = false;
            this.dgvSalesMemberTwo.AllowUserToResizeRows = false;
            this.dgvSalesMemberTwo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesMemberTwo.Location = new System.Drawing.Point(480, 113);
            this.dgvSalesMemberTwo.Name = "dgvSalesMemberTwo";
            this.dgvSalesMemberTwo.RowHeadersVisible = false;
            this.dgvSalesMemberTwo.Size = new System.Drawing.Size(444, 486);
            this.dgvSalesMemberTwo.TabIndex = 1;
            // 
            // dgvSalesMemberThree
            // 
            this.dgvSalesMemberThree.AllowUserToAddRows = false;
            this.dgvSalesMemberThree.AllowUserToDeleteRows = false;
            this.dgvSalesMemberThree.AllowUserToResizeColumns = false;
            this.dgvSalesMemberThree.AllowUserToResizeRows = false;
            this.dgvSalesMemberThree.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesMemberThree.Location = new System.Drawing.Point(951, 113);
            this.dgvSalesMemberThree.Name = "dgvSalesMemberThree";
            this.dgvSalesMemberThree.RowHeadersVisible = false;
            this.dgvSalesMemberThree.Size = new System.Drawing.Size(444, 486);
            this.dgvSalesMemberThree.TabIndex = 2;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.tabControl.Location = new System.Drawing.Point(11, 58);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1383, 29);
            this.tabControl.TabIndex = 3;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1375, 0);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dteStart
            // 
            this.dteStart.Location = new System.Drawing.Point(502, 35);
            this.dteStart.Name = "dteStart";
            this.dteStart.Size = new System.Drawing.Size(200, 20);
            this.dteStart.TabIndex = 4;
            this.dteStart.CloseUp += new System.EventHandler(this.dteStart_CloseUp);
            // 
            // dteEnd
            // 
            this.dteEnd.Location = new System.Drawing.Point(708, 35);
            this.dteEnd.Name = "dteEnd";
            this.dteEnd.Size = new System.Drawing.Size(200, 20);
            this.dteEnd.TabIndex = 5;
            this.dteEnd.CloseUp += new System.EventHandler(this.dteEnd_CloseUp);
            // 
            // pieChartOne
            // 
            this.pieChartOne.Location = new System.Drawing.Point(12, 605);
            this.pieChartOne.Name = "pieChartOne";
            this.pieChartOne.Size = new System.Drawing.Size(444, 323);
            this.pieChartOne.TabIndex = 55;
            this.pieChartOne.Text = "elementHost2";
            this.pieChartOne.Child = this.pieChart1;
            // 
            // pieChartTwo
            // 
            this.pieChartTwo.Location = new System.Drawing.Point(480, 605);
            this.pieChartTwo.Name = "pieChartTwo";
            this.pieChartTwo.Size = new System.Drawing.Size(444, 323);
            this.pieChartTwo.TabIndex = 56;
            this.pieChartTwo.Text = "elementHost1";
            this.pieChartTwo.Child = this.pieChart2;
            // 
            // pieChartThree
            // 
            this.pieChartThree.Location = new System.Drawing.Point(951, 605);
            this.pieChartThree.Name = "pieChartThree";
            this.pieChartThree.Size = new System.Drawing.Size(444, 323);
            this.pieChartThree.TabIndex = 57;
            this.pieChartThree.Text = "elementHost3";
            this.pieChartThree.Child = this.pieChart3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.label1.Location = new System.Drawing.Point(651, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 22);
            this.label1.TabIndex = 58;
            this.label1.Text = "Weekly Targets";
            // 
            // lblSalesMemberOne
            // 
            this.lblSalesMemberOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.lblSalesMemberOne.Location = new System.Drawing.Point(15, 83);
            this.lblSalesMemberOne.Name = "lblSalesMemberOne";
            this.lblSalesMemberOne.Size = new System.Drawing.Size(441, 27);
            this.lblSalesMemberOne.TabIndex = 59;
            this.lblSalesMemberOne.Text = " ";
            this.lblSalesMemberOne.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSalesMemberTwo
            // 
            this.lblSalesMemberTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.lblSalesMemberTwo.Location = new System.Drawing.Point(483, 83);
            this.lblSalesMemberTwo.Name = "lblSalesMemberTwo";
            this.lblSalesMemberTwo.Size = new System.Drawing.Size(441, 27);
            this.lblSalesMemberTwo.TabIndex = 60;
            this.lblSalesMemberTwo.Text = " ";
            this.lblSalesMemberTwo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSalesMemberThree
            // 
            this.lblSalesMemberThree.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.lblSalesMemberThree.Location = new System.Drawing.Point(953, 83);
            this.lblSalesMemberThree.Name = "lblSalesMemberThree";
            this.lblSalesMemberThree.Size = new System.Drawing.Size(441, 27);
            this.lblSalesMemberThree.TabIndex = 61;
            this.lblSalesMemberThree.Text = "  ";
            this.lblSalesMemberThree.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmSectorManagementView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1410, 938);
            this.Controls.Add(this.lblSalesMemberThree);
            this.Controls.Add(this.lblSalesMemberTwo);
            this.Controls.Add(this.lblSalesMemberOne);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pieChartThree);
            this.Controls.Add(this.pieChartTwo);
            this.Controls.Add(this.pieChartOne);
            this.Controls.Add(this.dteEnd);
            this.Controls.Add(this.dteStart);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.dgvSalesMemberThree);
            this.Controls.Add(this.dgvSalesMemberTwo);
            this.Controls.Add(this.dgvSalesMemberOne);
            this.Name = "frmSectorManagementView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSectorManagementView";
            this.Shown += new System.EventHandler(this.frmSectorManagementView_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesMemberOne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesMemberTwo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesMemberThree)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSalesMemberOne;
        private System.Windows.Forms.DataGridView dgvSalesMemberTwo;
        private System.Windows.Forms.DataGridView dgvSalesMemberThree;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DateTimePicker dteStart;
        private System.Windows.Forms.DateTimePicker dteEnd;
        private System.Windows.Forms.Integration.ElementHost pieChartOne;
        private LiveCharts.Wpf.PieChart pieChart1;
        private System.Windows.Forms.Integration.ElementHost pieChartTwo;
        private System.Windows.Forms.Integration.ElementHost pieChartThree;
        private LiveCharts.Wpf.PieChart pieChart3;
        private LiveCharts.Wpf.PieChart pieChart2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSalesMemberOne;
        private System.Windows.Forms.Label lblSalesMemberTwo;
        private System.Windows.Forms.Label lblSalesMemberThree;
    }
}