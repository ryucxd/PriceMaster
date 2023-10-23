namespace PriceMaster.TraditionalChasing
{
    partial class frmNonReturningCustomers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNonReturningCustomers));
            this.dgvNonReturningCustomers = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCustomerSearch = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dteFilter = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.chkSlimline = new System.Windows.Forms.CheckBox();
            this.btnExcel = new PriceMaster.buttonFormatting();
            this.btnOrder = new PriceMaster.buttonFormatting();
            this.btnValue = new PriceMaster.buttonFormatting();
            this.btnClear = new PriceMaster.buttonFormatting();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNonReturningCustomers)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvNonReturningCustomers
            // 
            this.dgvNonReturningCustomers.AllowUserToAddRows = false;
            this.dgvNonReturningCustomers.AllowUserToDeleteRows = false;
            this.dgvNonReturningCustomers.AllowUserToResizeColumns = false;
            this.dgvNonReturningCustomers.AllowUserToResizeRows = false;
            this.dgvNonReturningCustomers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvNonReturningCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNonReturningCustomers.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNonReturningCustomers.Location = new System.Drawing.Point(12, 62);
            this.dgvNonReturningCustomers.Name = "dgvNonReturningCustomers";
            this.dgvNonReturningCustomers.ReadOnly = true;
            this.dgvNonReturningCustomers.RowHeadersVisible = false;
            this.dgvNonReturningCustomers.Size = new System.Drawing.Size(1395, 492);
            this.dgvNonReturningCustomers.TabIndex = 2;
            this.dgvNonReturningCustomers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNonReturningCustomers_CellClick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1395, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Non Returning Customers";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label2.Location = new System.Drawing.Point(396, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 17);
            this.label2.TabIndex = 53;
            this.label2.Text = "Customer Search:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cmbCustomerSearch
            // 
            this.cmbCustomerSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbCustomerSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbCustomerSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCustomerSearch.FormattingEnabled = true;
            this.cmbCustomerSearch.Location = new System.Drawing.Point(523, 35);
            this.cmbCustomerSearch.Name = "cmbCustomerSearch";
            this.cmbCustomerSearch.Size = new System.Drawing.Size(188, 21);
            this.cmbCustomerSearch.TabIndex = 52;
            this.cmbCustomerSearch.SelectedIndexChanged += new System.EventHandler(this.cmbCustomerSearch_SelectedIndexChanged);
            this.cmbCustomerSearch.TextChanged += new System.EventHandler(this.cmbCustomerSearch_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label3.Location = new System.Drawing.Point(1170, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(214, 23);
            this.label3.TabIndex = 56;
            this.label3.Text = "Order By";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dteFilter
            // 
            this.dteFilter.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dteFilter.Location = new System.Drawing.Point(810, 36);
            this.dteFilter.Name = "dteFilter";
            this.dteFilter.Size = new System.Drawing.Size(143, 20);
            this.dteFilter.TabIndex = 58;
            this.dteFilter.CloseUp += new System.EventHandler(this.dteFilter_CloseUp);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label4.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label4.Location = new System.Drawing.Point(717, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 17);
            this.label4.TabIndex = 59;
            this.label4.Text = "Date Search:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // chkSlimline
            // 
            this.chkSlimline.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkSlimline.AutoSize = true;
            this.chkSlimline.Location = new System.Drawing.Point(977, 38);
            this.chkSlimline.Name = "chkSlimline";
            this.chkSlimline.Size = new System.Drawing.Size(61, 17);
            this.chkSlimline.TabIndex = 60;
            this.chkSlimline.Text = "Slimline";
            this.chkSlimline.UseVisualStyleBackColor = true;
            this.chkSlimline.CheckedChanged += new System.EventHandler(this.chkSlimline_CheckedChanged);
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnExcel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.ForeColor = System.Drawing.Color.White;
            this.btnExcel.Location = new System.Drawing.Point(12, 26);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnExcel.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Padding = new System.Windows.Forms.Padding(3);
            this.btnExcel.Size = new System.Drawing.Size(138, 30);
            this.btnExcel.TabIndex = 57;
            this.btnExcel.Text = "Export to Excel";
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOrder.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnOrder.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrder.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrder.ForeColor = System.Drawing.Color.White;
            this.btnOrder.Location = new System.Drawing.Point(1174, 24);
            this.btnOrder.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnOrder.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Padding = new System.Windows.Forms.Padding(3);
            this.btnOrder.Size = new System.Drawing.Size(100, 30);
            this.btnOrder.TabIndex = 54;
            this.btnOrder.Text = "Last Order";
            this.btnOrder.UseVisualStyleBackColor = false;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnValue
            // 
            this.btnValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnValue.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnValue.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValue.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValue.ForeColor = System.Drawing.Color.White;
            this.btnValue.Location = new System.Drawing.Point(1284, 24);
            this.btnValue.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnValue.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnValue.Name = "btnValue";
            this.btnValue.Padding = new System.Windows.Forms.Padding(3);
            this.btnValue.Size = new System.Drawing.Size(100, 30);
            this.btnValue.TabIndex = 55;
            this.btnValue.Text = "Total Value";
            this.btnValue.UseVisualStyleBackColor = false;
            this.btnValue.Click += new System.EventHandler(this.btnValue_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnClear.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(1046, 24);
            this.btnClear.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnClear.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnClear.Name = "btnClear";
            this.btnClear.Padding = new System.Windows.Forms.Padding(3);
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 61;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frmNonReturningCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1419, 566);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.chkSlimline);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dteFilter);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.btnValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbCustomerSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvNonReturningCustomers);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "frmNonReturningCustomers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Non Returning Customers";
            ((System.ComponentModel.ISupportInitialize)(this.dgvNonReturningCustomers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvNonReturningCustomers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCustomerSearch;
        private buttonFormatting btnOrder;
        private buttonFormatting btnValue;
        private System.Windows.Forms.Label label3;
        private buttonFormatting btnExcel;
        private System.Windows.Forms.DateTimePicker dteFilter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkSlimline;
        private buttonFormatting btnClear;
    }
}