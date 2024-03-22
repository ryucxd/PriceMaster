namespace PriceMaster.TraditionalChasing
{
    partial class frmNewCustomersTraditional
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewCustomersTraditional));
            this.dgvNonReturningCustomers = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dteFilterStart = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dteFilterEnd = new System.Windows.Forms.DateTimePicker();
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
            this.dgvNonReturningCustomers.Size = new System.Drawing.Size(869, 492);
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
            this.label1.Size = new System.Drawing.Size(869, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "New Customers";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dteFilterStart
            // 
            this.dteFilterStart.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dteFilterStart.Location = new System.Drawing.Point(338, 36);
            this.dteFilterStart.Name = "dteFilterStart";
            this.dteFilterStart.Size = new System.Drawing.Size(143, 20);
            this.dteFilterStart.TabIndex = 58;
            this.dteFilterStart.CloseUp += new System.EventHandler(this.dteFilter_CloseUp);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label4.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label4.Location = new System.Drawing.Point(245, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 17);
            this.label4.TabIndex = 59;
            this.label4.Text = "Date Search:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label5.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label5.Location = new System.Drawing.Point(482, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 17);
            this.label5.TabIndex = 63;
            this.label5.Text = "to:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // dteFilterEnd
            // 
            this.dteFilterEnd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dteFilterEnd.Location = new System.Drawing.Point(504, 37);
            this.dteFilterEnd.Name = "dteFilterEnd";
            this.dteFilterEnd.Size = new System.Drawing.Size(143, 20);
            this.dteFilterEnd.TabIndex = 62;
            this.dteFilterEnd.CloseUp += new System.EventHandler(this.dteFilterEnd_CloseUp);
            // 
            // frmNewCustomersTraditional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 566);
            this.Controls.Add(this.dteFilterEnd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dteFilterStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvNonReturningCustomers);
            this.Controls.Add(this.label5);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "frmNewCustomersTraditional";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Customers";
            ((System.ComponentModel.ISupportInitialize)(this.dgvNonReturningCustomers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvNonReturningCustomers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dteFilterStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dteFilterEnd;
    }
}