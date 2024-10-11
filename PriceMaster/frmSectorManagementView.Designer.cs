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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.dgvSalesMemberOneOutOfOffice = new System.Windows.Forms.DataGridView();
            this.dgvSalesMemberTwoOutOfOffice = new System.Windows.Forms.DataGridView();
            this.dgvSalesMemberThreeOutOfOffice = new System.Windows.Forms.DataGridView();
            this.lblSalesMemberThreeOOO = new System.Windows.Forms.Label();
            this.lblSalesMemberTwoOOO = new System.Windows.Forms.Label();
            this.lblSalesMemberOneOOO = new System.Windows.Forms.Label();
            this.btnSalesMemberOneEfficency = new PriceMaster.buttonFormatting();
            this.btnSalesMemberTwoEfficency = new PriceMaster.buttonFormatting();
            this.btnSalesMemberThreeEfficency = new PriceMaster.buttonFormatting();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesMemberOne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesMemberTwo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesMemberThree)).BeginInit();
            this.tabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesMemberOneOutOfOffice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesMemberTwoOutOfOffice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesMemberThreeOutOfOffice)).BeginInit();
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
            this.dgvSalesMemberOne.Size = new System.Drawing.Size(444, 213);
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
            this.dgvSalesMemberTwo.Size = new System.Drawing.Size(444, 213);
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
            this.dgvSalesMemberThree.Size = new System.Drawing.Size(444, 213);
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
            this.pieChartOne.Location = new System.Drawing.Point(12, 642);
            this.pieChartOne.Name = "pieChartOne";
            this.pieChartOne.Size = new System.Drawing.Size(444, 323);
            this.pieChartOne.TabIndex = 55;
            this.pieChartOne.Text = "elementHost2";
            this.pieChartOne.Child = this.pieChart1;
            // 
            // pieChartTwo
            // 
            this.pieChartTwo.Location = new System.Drawing.Point(480, 642);
            this.pieChartTwo.Name = "pieChartTwo";
            this.pieChartTwo.Size = new System.Drawing.Size(444, 323);
            this.pieChartTwo.TabIndex = 56;
            this.pieChartTwo.Text = "elementHost1";
            this.pieChartTwo.Child = this.pieChart2;
            // 
            // pieChartThree
            // 
            this.pieChartThree.Location = new System.Drawing.Point(951, 642);
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
            // dgvSalesMemberOneOutOfOffice
            // 
            this.dgvSalesMemberOneOutOfOffice.AllowUserToAddRows = false;
            this.dgvSalesMemberOneOutOfOffice.AllowUserToDeleteRows = false;
            this.dgvSalesMemberOneOutOfOffice.AllowUserToResizeColumns = false;
            this.dgvSalesMemberOneOutOfOffice.AllowUserToResizeRows = false;
            this.dgvSalesMemberOneOutOfOffice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.PaleVioletRed;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSalesMemberOneOutOfOffice.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSalesMemberOneOutOfOffice.Location = new System.Drawing.Point(11, 401);
            this.dgvSalesMemberOneOutOfOffice.Name = "dgvSalesMemberOneOutOfOffice";
            this.dgvSalesMemberOneOutOfOffice.ReadOnly = true;
            this.dgvSalesMemberOneOutOfOffice.RowHeadersVisible = false;
            this.dgvSalesMemberOneOutOfOffice.Size = new System.Drawing.Size(444, 235);
            this.dgvSalesMemberOneOutOfOffice.TabIndex = 71;
            this.dgvSalesMemberOneOutOfOffice.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesMemberOneOutOfOffice_CellDoubleClick);
            // 
            // dgvSalesMemberTwoOutOfOffice
            // 
            this.dgvSalesMemberTwoOutOfOffice.AllowUserToAddRows = false;
            this.dgvSalesMemberTwoOutOfOffice.AllowUserToDeleteRows = false;
            this.dgvSalesMemberTwoOutOfOffice.AllowUserToResizeColumns = false;
            this.dgvSalesMemberTwoOutOfOffice.AllowUserToResizeRows = false;
            this.dgvSalesMemberTwoOutOfOffice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PaleVioletRed;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSalesMemberTwoOutOfOffice.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSalesMemberTwoOutOfOffice.Location = new System.Drawing.Point(480, 401);
            this.dgvSalesMemberTwoOutOfOffice.Name = "dgvSalesMemberTwoOutOfOffice";
            this.dgvSalesMemberTwoOutOfOffice.ReadOnly = true;
            this.dgvSalesMemberTwoOutOfOffice.RowHeadersVisible = false;
            this.dgvSalesMemberTwoOutOfOffice.Size = new System.Drawing.Size(444, 235);
            this.dgvSalesMemberTwoOutOfOffice.TabIndex = 72;
            this.dgvSalesMemberTwoOutOfOffice.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesMemberTwoOutOfOffice_CellDoubleClick);
            // 
            // dgvSalesMemberThreeOutOfOffice
            // 
            this.dgvSalesMemberThreeOutOfOffice.AllowUserToAddRows = false;
            this.dgvSalesMemberThreeOutOfOffice.AllowUserToDeleteRows = false;
            this.dgvSalesMemberThreeOutOfOffice.AllowUserToResizeColumns = false;
            this.dgvSalesMemberThreeOutOfOffice.AllowUserToResizeRows = false;
            this.dgvSalesMemberThreeOutOfOffice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.PaleVioletRed;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSalesMemberThreeOutOfOffice.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSalesMemberThreeOutOfOffice.Location = new System.Drawing.Point(952, 401);
            this.dgvSalesMemberThreeOutOfOffice.Name = "dgvSalesMemberThreeOutOfOffice";
            this.dgvSalesMemberThreeOutOfOffice.ReadOnly = true;
            this.dgvSalesMemberThreeOutOfOffice.RowHeadersVisible = false;
            this.dgvSalesMemberThreeOutOfOffice.Size = new System.Drawing.Size(444, 235);
            this.dgvSalesMemberThreeOutOfOffice.TabIndex = 73;
            this.dgvSalesMemberThreeOutOfOffice.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesMemberThreeOutOfOffice_CellDoubleClick);
            // 
            // lblSalesMemberThreeOOO
            // 
            this.lblSalesMemberThreeOOO.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.lblSalesMemberThreeOOO.Location = new System.Drawing.Point(955, 359);
            this.lblSalesMemberThreeOOO.Name = "lblSalesMemberThreeOOO";
            this.lblSalesMemberThreeOOO.Size = new System.Drawing.Size(441, 27);
            this.lblSalesMemberThreeOOO.TabIndex = 76;
            this.lblSalesMemberThreeOOO.Text = " ";
            this.lblSalesMemberThreeOOO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSalesMemberTwoOOO
            // 
            this.lblSalesMemberTwoOOO.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.lblSalesMemberTwoOOO.Location = new System.Drawing.Point(485, 362);
            this.lblSalesMemberTwoOOO.Name = "lblSalesMemberTwoOOO";
            this.lblSalesMemberTwoOOO.Size = new System.Drawing.Size(441, 27);
            this.lblSalesMemberTwoOOO.TabIndex = 75;
            this.lblSalesMemberTwoOOO.Text = " ";
            this.lblSalesMemberTwoOOO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSalesMemberOneOOO
            // 
            this.lblSalesMemberOneOOO.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.lblSalesMemberOneOOO.Location = new System.Drawing.Point(17, 362);
            this.lblSalesMemberOneOOO.Name = "lblSalesMemberOneOOO";
            this.lblSalesMemberOneOOO.Size = new System.Drawing.Size(441, 27);
            this.lblSalesMemberOneOOO.TabIndex = 74;
            this.lblSalesMemberOneOOO.Text = " ";
            this.lblSalesMemberOneOOO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSalesMemberOneEfficency
            // 
            this.btnSalesMemberOneEfficency.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSalesMemberOneEfficency.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSalesMemberOneEfficency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalesMemberOneEfficency.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalesMemberOneEfficency.ForeColor = System.Drawing.Color.White;
            this.btnSalesMemberOneEfficency.Location = new System.Drawing.Point(11, 80);
            this.btnSalesMemberOneEfficency.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnSalesMemberOneEfficency.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnSalesMemberOneEfficency.Name = "btnSalesMemberOneEfficency";
            this.btnSalesMemberOneEfficency.Padding = new System.Windows.Forms.Padding(3);
            this.btnSalesMemberOneEfficency.Size = new System.Drawing.Size(125, 30);
            this.btnSalesMemberOneEfficency.TabIndex = 77;
            this.btnSalesMemberOneEfficency.Text = "Chase Efficency";
            this.btnSalesMemberOneEfficency.UseVisualStyleBackColor = false;
            this.btnSalesMemberOneEfficency.Click += new System.EventHandler(this.btnSalesMemberOneEfficency_Click);
            // 
            // btnSalesMemberTwoEfficency
            // 
            this.btnSalesMemberTwoEfficency.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSalesMemberTwoEfficency.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSalesMemberTwoEfficency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalesMemberTwoEfficency.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalesMemberTwoEfficency.ForeColor = System.Drawing.Color.White;
            this.btnSalesMemberTwoEfficency.Location = new System.Drawing.Point(480, 79);
            this.btnSalesMemberTwoEfficency.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnSalesMemberTwoEfficency.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnSalesMemberTwoEfficency.Name = "btnSalesMemberTwoEfficency";
            this.btnSalesMemberTwoEfficency.Padding = new System.Windows.Forms.Padding(3);
            this.btnSalesMemberTwoEfficency.Size = new System.Drawing.Size(125, 30);
            this.btnSalesMemberTwoEfficency.TabIndex = 78;
            this.btnSalesMemberTwoEfficency.Text = "Chase Efficency";
            this.btnSalesMemberTwoEfficency.UseVisualStyleBackColor = false;
            this.btnSalesMemberTwoEfficency.Click += new System.EventHandler(this.btnSalesMemberTwoEfficency_Click);
            // 
            // btnSalesMemberThreeEfficency
            // 
            this.btnSalesMemberThreeEfficency.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSalesMemberThreeEfficency.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSalesMemberThreeEfficency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalesMemberThreeEfficency.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalesMemberThreeEfficency.ForeColor = System.Drawing.Color.White;
            this.btnSalesMemberThreeEfficency.Location = new System.Drawing.Point(952, 79);
            this.btnSalesMemberThreeEfficency.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnSalesMemberThreeEfficency.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnSalesMemberThreeEfficency.Name = "btnSalesMemberThreeEfficency";
            this.btnSalesMemberThreeEfficency.Padding = new System.Windows.Forms.Padding(3);
            this.btnSalesMemberThreeEfficency.Size = new System.Drawing.Size(125, 30);
            this.btnSalesMemberThreeEfficency.TabIndex = 79;
            this.btnSalesMemberThreeEfficency.Text = "Chase Efficency";
            this.btnSalesMemberThreeEfficency.UseVisualStyleBackColor = false;
            this.btnSalesMemberThreeEfficency.Click += new System.EventHandler(this.btnSalesMemberThreeEfficency_Click);
            // 
            // frmSectorManagementView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1410, 986);
            this.Controls.Add(this.btnSalesMemberThreeEfficency);
            this.Controls.Add(this.btnSalesMemberTwoEfficency);
            this.Controls.Add(this.btnSalesMemberOneEfficency);
            this.Controls.Add(this.lblSalesMemberThreeOOO);
            this.Controls.Add(this.lblSalesMemberTwoOOO);
            this.Controls.Add(this.lblSalesMemberOneOOO);
            this.Controls.Add(this.dgvSalesMemberThreeOutOfOffice);
            this.Controls.Add(this.dgvSalesMemberTwoOutOfOffice);
            this.Controls.Add(this.dgvSalesMemberOneOutOfOffice);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesMemberOneOutOfOffice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesMemberTwoOutOfOffice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesMemberThreeOutOfOffice)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvSalesMemberOneOutOfOffice;
        private System.Windows.Forms.DataGridView dgvSalesMemberTwoOutOfOffice;
        private System.Windows.Forms.DataGridView dgvSalesMemberThreeOutOfOffice;
        private System.Windows.Forms.Label lblSalesMemberThreeOOO;
        private System.Windows.Forms.Label lblSalesMemberTwoOOO;
        private System.Windows.Forms.Label lblSalesMemberOneOOO;
        private buttonFormatting btnSalesMemberOneEfficency;
        private buttonFormatting btnSalesMemberTwoEfficency;
        private buttonFormatting btnSalesMemberThreeEfficency;
    }
}