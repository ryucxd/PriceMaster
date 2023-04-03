namespace PriceMaster
{
    partial class frmOutstandingCustomerCorrespondence
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOutstandingCustomerCorrespondence));
            this.dgvCorrespondence = new System.Windows.Forms.DataGridView();
            this.chkFuture = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCustomerSearch = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCorrespondence)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCorrespondence
            // 
            this.dgvCorrespondence.AllowUserToAddRows = false;
            this.dgvCorrespondence.AllowUserToDeleteRows = false;
            this.dgvCorrespondence.AllowUserToResizeColumns = false;
            this.dgvCorrespondence.AllowUserToResizeRows = false;
            this.dgvCorrespondence.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCorrespondence.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCorrespondence.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCorrespondence.Location = new System.Drawing.Point(12, 90);
            this.dgvCorrespondence.Name = "dgvCorrespondence";
            this.dgvCorrespondence.ReadOnly = true;
            this.dgvCorrespondence.RowHeadersVisible = false;
            this.dgvCorrespondence.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCorrespondence.Size = new System.Drawing.Size(1226, 588);
            this.dgvCorrespondence.TabIndex = 44;
            this.dgvCorrespondence.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCorrespondence_CellClick);
            // 
            // chkFuture
            // 
            this.chkFuture.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkFuture.AutoSize = true;
            this.chkFuture.Location = new System.Drawing.Point(739, 65);
            this.chkFuture.Name = "chkFuture";
            this.chkFuture.Size = new System.Drawing.Size(137, 17);
            this.chkFuture.TabIndex = 62;
            this.chkFuture.Text = "Future Correspondence";
            this.chkFuture.UseVisualStyleBackColor = true;
            this.chkFuture.CheckedChanged += new System.EventHandler(this.chkFuture_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label2.Location = new System.Drawing.Point(418, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 17);
            this.label2.TabIndex = 61;
            this.label2.Text = "Customer Search:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cmbCustomerSearch
            // 
            this.cmbCustomerSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbCustomerSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbCustomerSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCustomerSearch.FormattingEnabled = true;
            this.cmbCustomerSearch.Location = new System.Drawing.Point(545, 63);
            this.cmbCustomerSearch.Name = "cmbCustomerSearch";
            this.cmbCustomerSearch.Size = new System.Drawing.Size(188, 21);
            this.cmbCustomerSearch.Sorted = true;
            this.cmbCustomerSearch.TabIndex = 60;
            this.cmbCustomerSearch.SelectedIndexChanged += new System.EventHandler(this.cmbCustomerSearch_SelectedIndexChanged);
            this.cmbCustomerSearch.TextChanged += new System.EventHandler(this.cmbCustomerSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1226, 34);
            this.label1.TabIndex = 63;
            this.label1.Text = "Outstanding Customer Correspondence";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmOutstandingCustomerCorrespondence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 689);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkFuture);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbCustomerSearch);
            this.Controls.Add(this.dgvCorrespondence);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "frmOutstandingCustomerCorrespondence";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Outstanding Customer Correspondence";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCorrespondence)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCorrespondence;
        private System.Windows.Forms.CheckBox chkFuture;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCustomerSearch;
        private System.Windows.Forms.Label label1;
    }
}