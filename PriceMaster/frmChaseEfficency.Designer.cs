namespace PriceMaster
{
    partial class frmChaseEfficency
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChaseEfficency));
            this.pieChartOne = new System.Windows.Forms.Integration.ElementHost();
            this.pieChart1 = new LiveCharts.Wpf.PieChart();
            this.cmbStaff = new System.Windows.Forms.ComboBox();
            this.dgvWon = new System.Windows.Forms.DataGridView();
            this.dgvLost = new System.Windows.Forms.DataGridView();
            this.dteStart = new System.Windows.Forms.DateTimePicker();
            this.dteEnd = new System.Windows.Forms.DateTimePicker();
            this.lblLost = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLost)).BeginInit();
            this.SuspendLayout();
            // 
            // pieChartOne
            // 
            this.pieChartOne.Location = new System.Drawing.Point(12, 247);
            this.pieChartOne.Name = "pieChartOne";
            this.pieChartOne.Size = new System.Drawing.Size(591, 450);
            this.pieChartOne.TabIndex = 56;
            this.pieChartOne.Text = "elementHost2";
            this.pieChartOne.Child = this.pieChart1;
            // 
            // cmbStaff
            // 
            this.cmbStaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.cmbStaff.FormattingEnabled = true;
            this.cmbStaff.Location = new System.Drawing.Point(147, 48);
            this.cmbStaff.Name = "cmbStaff";
            this.cmbStaff.Size = new System.Drawing.Size(321, 33);
            this.cmbStaff.TabIndex = 57;
            this.cmbStaff.SelectedIndexChanged += new System.EventHandler(this.cmbStaff_SelectedIndexChanged);
            // 
            // dgvWon
            // 
            this.dgvWon.AllowUserToAddRows = false;
            this.dgvWon.AllowUserToDeleteRows = false;
            this.dgvWon.AllowUserToResizeColumns = false;
            this.dgvWon.AllowUserToResizeRows = false;
            this.dgvWon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvWon.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvWon.Location = new System.Drawing.Point(632, 33);
            this.dgvWon.Name = "dgvWon";
            this.dgvWon.RowHeadersVisible = false;
            this.dgvWon.Size = new System.Drawing.Size(829, 414);
            this.dgvWon.TabIndex = 58;
            // 
            // dgvLost
            // 
            this.dgvLost.AllowUserToAddRows = false;
            this.dgvLost.AllowUserToDeleteRows = false;
            this.dgvLost.AllowUserToResizeColumns = false;
            this.dgvLost.AllowUserToResizeRows = false;
            this.dgvLost.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLost.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLost.Location = new System.Drawing.Point(632, 486);
            this.dgvLost.Name = "dgvLost";
            this.dgvLost.RowHeadersVisible = false;
            this.dgvLost.Size = new System.Drawing.Size(829, 414);
            this.dgvLost.TabIndex = 59;
            // 
            // dteStart
            // 
            this.dteStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.dteStart.Location = new System.Drawing.Point(131, 178);
            this.dteStart.Name = "dteStart";
            this.dteStart.Size = new System.Drawing.Size(160, 23);
            this.dteStart.TabIndex = 60;
            this.dteStart.CloseUp += new System.EventHandler(this.dteStart_CloseUp);
            // 
            // dteEnd
            // 
            this.dteEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.dteEnd.Location = new System.Drawing.Point(312, 178);
            this.dteEnd.Name = "dteEnd";
            this.dteEnd.Size = new System.Drawing.Size(160, 23);
            this.dteEnd.TabIndex = 61;
            this.dteEnd.CloseUp += new System.EventHandler(this.dteEnd_CloseUp);
            // 
            // lblLost
            // 
            this.lblLost.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.lblLost.Location = new System.Drawing.Point(632, 458);
            this.lblLost.Name = "lblLost";
            this.lblLost.Size = new System.Drawing.Size(829, 23);
            this.lblLost.TabIndex = 62;
            this.lblLost.Text = "Lost Chases";
            this.lblLost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label1.Location = new System.Drawing.Point(632, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(829, 25);
            this.label1.TabIndex = 63;
            this.label1.Text = "Won Chases";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label2.Location = new System.Drawing.Point(12, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(591, 25);
            this.label2.TabIndex = 64;
            this.label2.Text = "Won Chases";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label3.Location = new System.Drawing.Point(12, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(591, 25);
            this.label3.TabIndex = 65;
            this.label3.Text = "Chase Date";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.label4.Location = new System.Drawing.Point(278, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 25);
            this.label4.TabIndex = 66;
            this.label4.Text = "to";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmChaseEfficency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1473, 912);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblLost);
            this.Controls.Add(this.dteEnd);
            this.Controls.Add(this.dteStart);
            this.Controls.Add(this.dgvLost);
            this.Controls.Add(this.dgvWon);
            this.Controls.Add(this.cmbStaff);
            this.Controls.Add(this.pieChartOne);
            this.Controls.Add(this.label4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmChaseEfficency";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chase Efficency";
            ((System.ComponentModel.ISupportInitialize)(this.dgvWon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLost)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost pieChartOne;
        private LiveCharts.Wpf.PieChart pieChart1;
        private System.Windows.Forms.ComboBox cmbStaff;
        private System.Windows.Forms.DataGridView dgvWon;
        private System.Windows.Forms.DataGridView dgvLost;
        private System.Windows.Forms.DateTimePicker dteStart;
        private System.Windows.Forms.DateTimePicker dteEnd;
        private System.Windows.Forms.Label lblLost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}