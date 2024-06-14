namespace PriceMaster.TraditionalChasing
{
    partial class frmTurnOverDecline
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTurnOverDecline));
            this.dgvTurnOver = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCustomerSearch = new System.Windows.Forms.ComboBox();
            this.chkSlimline = new System.Windows.Forms.CheckBox();
            this.btnClear = new PriceMaster.buttonFormatting();
            this.btnExcel = new PriceMaster.buttonFormatting();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnOver)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTurnOver
            // 
            this.dgvTurnOver.AllowUserToAddRows = false;
            this.dgvTurnOver.AllowUserToDeleteRows = false;
            this.dgvTurnOver.AllowUserToResizeColumns = false;
            this.dgvTurnOver.AllowUserToResizeRows = false;
            this.dgvTurnOver.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTurnOver.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTurnOver.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTurnOver.Location = new System.Drawing.Point(12, 62);
            this.dgvTurnOver.Name = "dgvTurnOver";
            this.dgvTurnOver.ReadOnly = true;
            this.dgvTurnOver.RowHeadersVisible = false;
            this.dgvTurnOver.Size = new System.Drawing.Size(1264, 492);
            this.dgvTurnOver.TabIndex = 2;
            this.dgvTurnOver.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNonReturningCustomers_CellClick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1264, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Turn Over Decline";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label2.Location = new System.Drawing.Point(453, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 17);
            this.label2.TabIndex = 53;
            this.label2.Text = "Customer Search:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cmbCustomerSearch
            // 
            this.cmbCustomerSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbCustomerSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCustomerSearch.FormattingEnabled = true;
            this.cmbCustomerSearch.Location = new System.Drawing.Point(580, 35);
            this.cmbCustomerSearch.Name = "cmbCustomerSearch";
            this.cmbCustomerSearch.Size = new System.Drawing.Size(188, 21);
            this.cmbCustomerSearch.Sorted = true;
            this.cmbCustomerSearch.TabIndex = 52;
            this.cmbCustomerSearch.SelectedIndexChanged += new System.EventHandler(this.cmbCustomerSearch_SelectedIndexChanged);
            this.cmbCustomerSearch.TextChanged += new System.EventHandler(this.cmbCustomerSearch_TextChanged);
            // 
            // chkSlimline
            // 
            this.chkSlimline.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkSlimline.AutoSize = true;
            this.chkSlimline.Location = new System.Drawing.Point(778, 37);
            this.chkSlimline.Name = "chkSlimline";
            this.chkSlimline.Size = new System.Drawing.Size(61, 17);
            this.chkSlimline.TabIndex = 60;
            this.chkSlimline.Text = "Slimline";
            this.chkSlimline.UseVisualStyleBackColor = true;
            this.chkSlimline.CheckedChanged += new System.EventHandler(this.chkSlimline_CheckedChanged);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnClear.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(847, 26);
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
            // frmTurnOverDecline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1288, 566);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.chkSlimline);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbCustomerSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvTurnOver);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "frmTurnOverDecline";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Turn Over Decline";
            this.Shown += new System.EventHandler(this.frmTurnOverDecline_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnOver)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTurnOver;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCustomerSearch;
        private buttonFormatting btnExcel;
        private System.Windows.Forms.CheckBox chkSlimline;
        private buttonFormatting btnClear;
    }
}