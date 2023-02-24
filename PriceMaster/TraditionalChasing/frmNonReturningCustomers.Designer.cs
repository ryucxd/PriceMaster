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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvNonReturningCustomers = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCustomerSearch = new System.Windows.Forms.ComboBox();
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNonReturningCustomers.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvNonReturningCustomers.Location = new System.Drawing.Point(12, 59);
            this.dgvNonReturningCustomers.Name = "dgvNonReturningCustomers";
            this.dgvNonReturningCustomers.ReadOnly = true;
            this.dgvNonReturningCustomers.RowHeadersVisible = false;
            this.dgvNonReturningCustomers.Size = new System.Drawing.Size(770, 443);
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
            this.label1.Size = new System.Drawing.Size(770, 23);
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
            this.label2.Location = new System.Drawing.Point(240, 37);
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
            this.cmbCustomerSearch.Location = new System.Drawing.Point(367, 35);
            this.cmbCustomerSearch.Name = "cmbCustomerSearch";
            this.cmbCustomerSearch.Size = new System.Drawing.Size(188, 21);
            this.cmbCustomerSearch.TabIndex = 52;
            this.cmbCustomerSearch.SelectedIndexChanged += new System.EventHandler(this.cmbCustomerSearch_SelectedIndexChanged);
            this.cmbCustomerSearch.TextChanged += new System.EventHandler(this.cmbCustomerSearch_TextChanged);
            // 
            // frmNonReturningCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 514);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbCustomerSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvNonReturningCustomers);
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
    }
}