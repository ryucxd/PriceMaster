namespace PriceMaster
{
    partial class frmLeadList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLeadList));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.elementHost2 = new System.Windows.Forms.Integration.ElementHost();
            this.pieChart1 = new LiveCharts.Wpf.PieChart();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvTarget = new System.Windows.Forms.DataGridView();
            this.btnLead = new PriceMaster.buttonFormatting();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTarget)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(463, 48);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(822, 701);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.label1.Location = new System.Drawing.Point(463, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(822, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lead History";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // elementHost2
            // 
            this.elementHost2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.elementHost2.Location = new System.Drawing.Point(12, 422);
            this.elementHost2.Name = "elementHost2";
            this.elementHost2.Size = new System.Drawing.Size(428, 323);
            this.elementHost2.TabIndex = 59;
            this.elementHost2.Text = "elementHost2";
            this.elementHost2.Child = this.pieChart1;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(428, 33);
            this.label2.TabIndex = 58;
            this.label2.Text = "Target";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvTarget
            // 
            this.dgvTarget.AllowUserToAddRows = false;
            this.dgvTarget.AllowUserToDeleteRows = false;
            this.dgvTarget.AllowUserToResizeColumns = false;
            this.dgvTarget.AllowUserToResizeRows = false;
            this.dgvTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvTarget.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTarget.Location = new System.Drawing.Point(12, 48);
            this.dgvTarget.Name = "dgvTarget";
            this.dgvTarget.RowHeadersVisible = false;
            this.dgvTarget.Size = new System.Drawing.Size(428, 356);
            this.dgvTarget.TabIndex = 57;
            // 
            // btnLead
            // 
            this.btnLead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLead.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnLead.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnLead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLead.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLead.ForeColor = System.Drawing.Color.White;
            this.btnLead.Location = new System.Drawing.Point(1186, 12);
            this.btnLead.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnLead.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnLead.Name = "btnLead";
            this.btnLead.Padding = new System.Windows.Forms.Padding(3);
            this.btnLead.Size = new System.Drawing.Size(97, 30);
            this.btnLead.TabIndex = 60;
            this.btnLead.Text = "New Lead";
            this.btnLead.UseVisualStyleBackColor = false;
            this.btnLead.Click += new System.EventHandler(this.btnLead_Click);
            // 
            // frmLeadList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1297, 761);
            this.Controls.Add(this.btnLead);
            this.Controls.Add(this.elementHost2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvTarget);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLeadList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lead Lists";
            this.Shown += new System.EventHandler(this.frmLeadList_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTarget)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Integration.ElementHost elementHost2;
        private LiveCharts.Wpf.PieChart pieChart1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvTarget;
        private buttonFormatting btnLead;
    }
}