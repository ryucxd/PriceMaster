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
            this.dgvNonReturningCustomers = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
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
            this.dgvNonReturningCustomers.Location = new System.Drawing.Point(12, 46);
            this.dgvNonReturningCustomers.Name = "dgvNonReturningCustomers";
            this.dgvNonReturningCustomers.ReadOnly = true;
            this.dgvNonReturningCustomers.RowHeadersVisible = false;
            this.dgvNonReturningCustomers.Size = new System.Drawing.Size(770, 456);
            this.dgvNonReturningCustomers.TabIndex = 2;
            this.dgvNonReturningCustomers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNonReturningCustomers_CellClick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(770, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Non Returning Customers";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmNonReturningCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 514);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvNonReturningCustomers);
            this.Name = "frmNonReturningCustomers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Non Returning Customers";
            ((System.ComponentModel.ISupportInitialize)(this.dgvNonReturningCustomers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvNonReturningCustomers;
        private System.Windows.Forms.Label label1;
    }
}