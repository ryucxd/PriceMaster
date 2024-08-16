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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSectorManagementView));
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
            this.btnDetailed = new PriceMaster.buttonFormatting();
            this.lblSalesMemberOnePercent = new System.Windows.Forms.Label();
            this.lblSalesMemberTwoPercent = new System.Windows.Forms.Label();
            this.lblSalesMemberThreePercent = new System.Windows.Forms.Label();
            this.btnSalesMemberTwoHistoric = new PriceMaster.buttonFormatting();
            this.btnSalesMemberThreeHistoric = new PriceMaster.buttonFormatting();
            this.btnPrint = new PriceMaster.buttonFormatting();
            this.buttonFormatting1 = new PriceMaster.buttonFormatting();
            this.lblWeekCommencing = new System.Windows.Forms.Label();
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
            this.dgvSalesMemberOne.Location = new System.Drawing.Point(12, 143);
            this.dgvSalesMemberOne.Name = "dgvSalesMemberOne";
            this.dgvSalesMemberOne.ReadOnly = true;
            this.dgvSalesMemberOne.RowHeadersVisible = false;
            this.dgvSalesMemberOne.Size = new System.Drawing.Size(444, 456);
            this.dgvSalesMemberOne.TabIndex = 0;
            this.dgvSalesMemberOne.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesMemberOne_CellDoubleClick);
            // 
            // dgvSalesMemberTwo
            // 
            this.dgvSalesMemberTwo.AllowUserToAddRows = false;
            this.dgvSalesMemberTwo.AllowUserToDeleteRows = false;
            this.dgvSalesMemberTwo.AllowUserToResizeColumns = false;
            this.dgvSalesMemberTwo.AllowUserToResizeRows = false;
            this.dgvSalesMemberTwo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesMemberTwo.Location = new System.Drawing.Point(480, 143);
            this.dgvSalesMemberTwo.Name = "dgvSalesMemberTwo";
            this.dgvSalesMemberTwo.ReadOnly = true;
            this.dgvSalesMemberTwo.RowHeadersVisible = false;
            this.dgvSalesMemberTwo.Size = new System.Drawing.Size(444, 456);
            this.dgvSalesMemberTwo.TabIndex = 1;
            this.dgvSalesMemberTwo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesMemberTwo_CellDoubleClick);
            // 
            // dgvSalesMemberThree
            // 
            this.dgvSalesMemberThree.AllowUserToAddRows = false;
            this.dgvSalesMemberThree.AllowUserToDeleteRows = false;
            this.dgvSalesMemberThree.AllowUserToResizeColumns = false;
            this.dgvSalesMemberThree.AllowUserToResizeRows = false;
            this.dgvSalesMemberThree.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesMemberThree.Location = new System.Drawing.Point(951, 143);
            this.dgvSalesMemberThree.Name = "dgvSalesMemberThree";
            this.dgvSalesMemberThree.ReadOnly = true;
            this.dgvSalesMemberThree.RowHeadersVisible = false;
            this.dgvSalesMemberThree.Size = new System.Drawing.Size(444, 456);
            this.dgvSalesMemberThree.TabIndex = 2;
            this.dgvSalesMemberThree.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesMemberThree_CellDoubleClick);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.tabControl.Location = new System.Drawing.Point(11, 52);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1383, 29);
            this.tabControl.TabIndex = 3;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.tabPage1.BackgroundImage = global::PriceMaster.Properties.Resources.fire;
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1375, 0);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
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
            // btnDetailed
            // 
            this.btnDetailed.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnDetailed.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnDetailed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetailed.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetailed.ForeColor = System.Drawing.Color.White;
            this.btnDetailed.Location = new System.Drawing.Point(370, 80);
            this.btnDetailed.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnDetailed.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnDetailed.Name = "btnDetailed";
            this.btnDetailed.Padding = new System.Windows.Forms.Padding(3);
            this.btnDetailed.Size = new System.Drawing.Size(86, 30);
            this.btnDetailed.TabIndex = 62;
            this.btnDetailed.Text = "Historic";
            this.btnDetailed.UseVisualStyleBackColor = false;
            this.btnDetailed.Click += new System.EventHandler(this.btnDetailed_Click);
            // 
            // lblSalesMemberOnePercent
            // 
            this.lblSalesMemberOnePercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.lblSalesMemberOnePercent.Location = new System.Drawing.Point(15, 113);
            this.lblSalesMemberOnePercent.Name = "lblSalesMemberOnePercent";
            this.lblSalesMemberOnePercent.Size = new System.Drawing.Size(441, 27);
            this.lblSalesMemberOnePercent.TabIndex = 63;
            this.lblSalesMemberOnePercent.Text = " ";
            this.lblSalesMemberOnePercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSalesMemberTwoPercent
            // 
            this.lblSalesMemberTwoPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.lblSalesMemberTwoPercent.Location = new System.Drawing.Point(483, 113);
            this.lblSalesMemberTwoPercent.Name = "lblSalesMemberTwoPercent";
            this.lblSalesMemberTwoPercent.Size = new System.Drawing.Size(441, 27);
            this.lblSalesMemberTwoPercent.TabIndex = 64;
            this.lblSalesMemberTwoPercent.Text = " ";
            this.lblSalesMemberTwoPercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSalesMemberThreePercent
            // 
            this.lblSalesMemberThreePercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.lblSalesMemberThreePercent.Location = new System.Drawing.Point(953, 110);
            this.lblSalesMemberThreePercent.Name = "lblSalesMemberThreePercent";
            this.lblSalesMemberThreePercent.Size = new System.Drawing.Size(441, 27);
            this.lblSalesMemberThreePercent.TabIndex = 65;
            this.lblSalesMemberThreePercent.Text = " ";
            this.lblSalesMemberThreePercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSalesMemberTwoHistoric
            // 
            this.btnSalesMemberTwoHistoric.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSalesMemberTwoHistoric.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSalesMemberTwoHistoric.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalesMemberTwoHistoric.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalesMemberTwoHistoric.ForeColor = System.Drawing.Color.White;
            this.btnSalesMemberTwoHistoric.Location = new System.Drawing.Point(838, 80);
            this.btnSalesMemberTwoHistoric.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnSalesMemberTwoHistoric.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnSalesMemberTwoHistoric.Name = "btnSalesMemberTwoHistoric";
            this.btnSalesMemberTwoHistoric.Padding = new System.Windows.Forms.Padding(3);
            this.btnSalesMemberTwoHistoric.Size = new System.Drawing.Size(86, 30);
            this.btnSalesMemberTwoHistoric.TabIndex = 66;
            this.btnSalesMemberTwoHistoric.Text = "Historic";
            this.btnSalesMemberTwoHistoric.UseVisualStyleBackColor = false;
            this.btnSalesMemberTwoHistoric.Click += new System.EventHandler(this.btnSalesMemberTwoHistoric_Click);
            // 
            // btnSalesMemberThreeHistoric
            // 
            this.btnSalesMemberThreeHistoric.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSalesMemberThreeHistoric.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSalesMemberThreeHistoric.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalesMemberThreeHistoric.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalesMemberThreeHistoric.ForeColor = System.Drawing.Color.White;
            this.btnSalesMemberThreeHistoric.Location = new System.Drawing.Point(1308, 80);
            this.btnSalesMemberThreeHistoric.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnSalesMemberThreeHistoric.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnSalesMemberThreeHistoric.Name = "btnSalesMemberThreeHistoric";
            this.btnSalesMemberThreeHistoric.Padding = new System.Windows.Forms.Padding(3);
            this.btnSalesMemberThreeHistoric.Size = new System.Drawing.Size(86, 30);
            this.btnSalesMemberThreeHistoric.TabIndex = 67;
            this.btnSalesMemberThreeHistoric.Text = "Historic";
            this.btnSalesMemberThreeHistoric.UseVisualStyleBackColor = false;
            this.btnSalesMemberThreeHistoric.Click += new System.EventHandler(this.btnSalesMemberThreeHistoric_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(1297, 9);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnPrint.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Padding = new System.Windows.Forms.Padding(3);
            this.btnPrint.Size = new System.Drawing.Size(99, 36);
            this.btnPrint.TabIndex = 68;
            this.btnPrint.Text = "Export";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // buttonFormatting1
            // 
            this.buttonFormatting1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonFormatting1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonFormatting1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFormatting1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.buttonFormatting1.ForeColor = System.Drawing.Color.White;
            this.buttonFormatting1.Location = new System.Drawing.Point(1188, 9);
            this.buttonFormatting1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.buttonFormatting1.MinimumSize = new System.Drawing.Size(75, 30);
            this.buttonFormatting1.Name = "buttonFormatting1";
            this.buttonFormatting1.Padding = new System.Windows.Forms.Padding(3);
            this.buttonFormatting1.Size = new System.Drawing.Size(99, 36);
            this.buttonFormatting1.TabIndex = 69;
            this.buttonFormatting1.Text = "Print";
            this.buttonFormatting1.UseVisualStyleBackColor = false;
            this.buttonFormatting1.Click += new System.EventHandler(this.buttonFormatting1_Click);
            // 
            // lblWeekCommencing
            // 
            this.lblWeekCommencing.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.lblWeekCommencing.Location = new System.Drawing.Point(17, 9);
            this.lblWeekCommencing.Name = "lblWeekCommencing";
            this.lblWeekCommencing.Size = new System.Drawing.Size(487, 36);
            this.lblWeekCommencing.TabIndex = 70;
            this.lblWeekCommencing.Text = "Data for Week Commencing: 2024/08/15";
            this.lblWeekCommencing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmSectorManagementView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1410, 938);
            this.Controls.Add(this.lblWeekCommencing);
            this.Controls.Add(this.buttonFormatting1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnSalesMemberThreeHistoric);
            this.Controls.Add(this.btnSalesMemberTwoHistoric);
            this.Controls.Add(this.lblSalesMemberThreePercent);
            this.Controls.Add(this.lblSalesMemberTwoPercent);
            this.Controls.Add(this.lblSalesMemberOnePercent);
            this.Controls.Add(this.btnDetailed);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSectorManagementView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sector Management View";
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
        private buttonFormatting btnDetailed;
        private System.Windows.Forms.Label lblSalesMemberOnePercent;
        private System.Windows.Forms.Label lblSalesMemberTwoPercent;
        private System.Windows.Forms.Label lblSalesMemberThreePercent;
        private buttonFormatting btnSalesMemberTwoHistoric;
        private buttonFormatting btnSalesMemberThreeHistoric;
        private buttonFormatting btnPrint;
        private buttonFormatting buttonFormatting1;
        private System.Windows.Forms.Label lblWeekCommencing;
    }
}