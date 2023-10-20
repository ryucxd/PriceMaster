namespace PriceMaster
{
    partial class frmChaseCustomerList
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
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.lblChase = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.dgvChase = new System.Windows.Forms.DataGridView();
            this.dgvOther = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.btnExcel = new PriceMaster.buttonFormatting();
            this.txtInsert = new PriceMaster.buttonFormatting();
            this.btnImport = new PriceMaster.buttonFormatting();
            this.btnLastOrder = new PriceMaster.buttonFormatting();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOther)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(40, 131);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(371, 28);
            this.cmbCustomer.TabIndex = 0;
            this.cmbCustomer.SelectedIndexChanged += new System.EventHandler(this.cmbCustomer_SelectedIndexChanged);
            // 
            // lblChase
            // 
            this.lblChase.AutoSize = true;
            this.lblChase.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.lblChase.Location = new System.Drawing.Point(458, 9);
            this.lblChase.Name = "lblChase";
            this.lblChase.Size = new System.Drawing.Size(161, 22);
            this.lblChase.TabIndex = 5;
            this.lblChase.Text = "Traditional Chases";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.label3.Location = new System.Drawing.Point(458, 499);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 22);
            this.label3.TabIndex = 6;
            this.label3.Text = "Other Correspondence";
            // 
            // lblCustomer
            // 
            this.lblCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.lblCustomer.Location = new System.Drawing.Point(40, 106);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(371, 22);
            this.lblCustomer.TabIndex = 9;
            this.lblCustomer.Text = "Customer";
            this.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvChase
            // 
            this.dgvChase.AllowUserToAddRows = false;
            this.dgvChase.AllowUserToDeleteRows = false;
            this.dgvChase.AllowUserToResizeColumns = false;
            this.dgvChase.AllowUserToResizeRows = false;
            this.dgvChase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChase.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvChase.Location = new System.Drawing.Point(462, 34);
            this.dgvChase.Name = "dgvChase";
            this.dgvChase.ReadOnly = true;
            this.dgvChase.RowHeadersVisible = false;
            this.dgvChase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChase.Size = new System.Drawing.Size(806, 454);
            this.dgvChase.TabIndex = 42;
            this.dgvChase.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChase_CellClick);
            // 
            // dgvOther
            // 
            this.dgvOther.AllowUserToAddRows = false;
            this.dgvOther.AllowUserToDeleteRows = false;
            this.dgvOther.AllowUserToResizeColumns = false;
            this.dgvOther.AllowUserToResizeRows = false;
            this.dgvOther.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOther.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOther.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOther.Location = new System.Drawing.Point(462, 524);
            this.dgvOther.Name = "dgvOther";
            this.dgvOther.ReadOnly = true;
            this.dgvOther.RowHeadersVisible = false;
            this.dgvOther.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOther.Size = new System.Drawing.Size(806, 454);
            this.dgvOther.TabIndex = 43;
            this.dgvOther.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOther_CellClick);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.label4.Location = new System.Drawing.Point(40, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(371, 22);
            this.label4.TabIndex = 46;
            this.label4.Text = "Traditional / Slimline";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbType
            // 
            this.cmbType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(40, 56);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(371, 28);
            this.cmbType.TabIndex = 45;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnExcel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.ForeColor = System.Drawing.Color.White;
            this.btnExcel.Location = new System.Drawing.Point(776, 491);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnExcel.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Padding = new System.Windows.Forms.Padding(3);
            this.btnExcel.Size = new System.Drawing.Size(260, 30);
            this.btnExcel.TabIndex = 47;
            this.btnExcel.Text = "Export Correspondence to Excel";
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // txtInsert
            // 
            this.txtInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInsert.BackColor = System.Drawing.Color.LightSkyBlue;
            this.txtInsert.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.txtInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtInsert.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInsert.ForeColor = System.Drawing.Color.White;
            this.txtInsert.Location = new System.Drawing.Point(1046, 491);
            this.txtInsert.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.txtInsert.MinimumSize = new System.Drawing.Size(75, 30);
            this.txtInsert.Name = "txtInsert";
            this.txtInsert.Padding = new System.Windows.Forms.Padding(3);
            this.txtInsert.Size = new System.Drawing.Size(222, 30);
            this.txtInsert.TabIndex = 44;
            this.txtInsert.Text = "Insert New Correspondence";
            this.txtInsert.UseVisualStyleBackColor = false;
            this.txtInsert.Click += new System.EventHandler(this.txtInsert_Click);
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnImport.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.ForeColor = System.Drawing.Color.White;
            this.btnImport.Location = new System.Drawing.Point(150, 192);
            this.btnImport.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnImport.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnImport.Name = "btnImport";
            this.btnImport.Padding = new System.Windows.Forms.Padding(3);
            this.btnImport.Size = new System.Drawing.Size(131, 30);
            this.btnImport.TabIndex = 48;
            this.btnImport.Text = "Mass Import";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnLastOrder
            // 
            this.btnLastOrder.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnLastOrder.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnLastOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLastOrder.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLastOrder.ForeColor = System.Drawing.Color.White;
            this.btnLastOrder.Location = new System.Drawing.Point(122, 248);
            this.btnLastOrder.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnLastOrder.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnLastOrder.Name = "btnLastOrder";
            this.btnLastOrder.Padding = new System.Windows.Forms.Padding(3);
            this.btnLastOrder.Size = new System.Drawing.Size(187, 30);
            this.btnLastOrder.TabIndex = 49;
            this.btnLastOrder.Text = "Last Order Details";
            this.btnLastOrder.UseVisualStyleBackColor = false;
            this.btnLastOrder.Click += new System.EventHandler(this.btnLastOrder_Click);
            // 
            // frmChaseCustomerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 990);
            this.Controls.Add(this.btnLastOrder);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.txtInsert);
            this.Controls.Add(this.dgvOther);
            this.Controls.Add(this.dgvChase);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.lblChase);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmChaseCustomerList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Customer List";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvChase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOther)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Label lblChase;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.DataGridView dgvChase;
        private System.Windows.Forms.DataGridView dgvOther;
        private buttonFormatting txtInsert;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbType;
        private buttonFormatting btnExcel;
        private buttonFormatting btnImport;
        private buttonFormatting btnLastOrder;
    }
}