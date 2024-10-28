namespace PriceMaster
{
    partial class frmLeadReport
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.chkAddedLeads = new System.Windows.Forms.CheckBox();
            this.dteStart = new System.Windows.Forms.DateTimePicker();
            this.dteEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbProspectAddedBy = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAdded = new System.Windows.Forms.Label();
            this.lblCorrespondence = new System.Windows.Forms.Label();
            this.btnExport = new PriceMaster.buttonFormatting();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.dataGridView1.Location = new System.Drawing.Point(12, 59);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1303, 674);
            this.dataGridView1.TabIndex = 0;
            // 
            // chkAddedLeads
            // 
            this.chkAddedLeads.AutoSize = true;
            this.chkAddedLeads.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.chkAddedLeads.Location = new System.Drawing.Point(391, 33);
            this.chkAddedLeads.Name = "chkAddedLeads";
            this.chkAddedLeads.Size = new System.Drawing.Size(173, 21);
            this.chkAddedLeads.TabIndex = 1;
            this.chkAddedLeads.Text = "Show only added leads";
            this.chkAddedLeads.UseVisualStyleBackColor = true;
            this.chkAddedLeads.CheckedChanged += new System.EventHandler(this.chkAddedLeads_CheckedChanged);
            // 
            // dteStart
            // 
            this.dteStart.Location = new System.Drawing.Point(12, 33);
            this.dteStart.Name = "dteStart";
            this.dteStart.Size = new System.Drawing.Size(163, 20);
            this.dteStart.TabIndex = 2;
            this.dteStart.CloseUp += new System.EventHandler(this.dteStart_CloseUp);
            // 
            // dteEnd
            // 
            this.dteEnd.Location = new System.Drawing.Point(207, 33);
            this.dteEnd.Name = "dteEnd";
            this.dteEnd.Size = new System.Drawing.Size(163, 20);
            this.dteEnd.TabIndex = 3;
            this.dteEnd.CloseUp += new System.EventHandler(this.dteEnd_CloseUp);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Lead Added Date";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.Location = new System.Drawing.Point(181, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "to";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbProspectAddedBy
            // 
            this.cmbProspectAddedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.cmbProspectAddedBy.FormattingEnabled = true;
            this.cmbProspectAddedBy.Location = new System.Drawing.Point(592, 31);
            this.cmbProspectAddedBy.Name = "cmbProspectAddedBy";
            this.cmbProspectAddedBy.Size = new System.Drawing.Size(210, 25);
            this.cmbProspectAddedBy.TabIndex = 6;
            this.cmbProspectAddedBy.SelectedIndexChanged += new System.EventHandler(this.cmbProspectAddedBy_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label3.Location = new System.Drawing.Point(592, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(210, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Prospect Added By";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAdded
            // 
            this.lblAdded.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lblAdded.Location = new System.Drawing.Point(825, 9);
            this.lblAdded.Name = "lblAdded";
            this.lblAdded.Size = new System.Drawing.Size(287, 21);
            this.lblAdded.TabIndex = 8;
            this.lblAdded.Text = "Leads added: 0%";
            this.lblAdded.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCorrespondence
            // 
            this.lblCorrespondence.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lblCorrespondence.Location = new System.Drawing.Point(825, 35);
            this.lblCorrespondence.Name = "lblCorrespondence";
            this.lblCorrespondence.Size = new System.Drawing.Size(287, 21);
            this.lblCorrespondence.TabIndex = 9;
            this.lblCorrespondence.Text = "Leads added and contacted: 0%";
            this.lblCorrespondence.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnExport.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(1240, 23);
            this.btnExport.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnExport.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnExport.Name = "btnExport";
            this.btnExport.Padding = new System.Windows.Forms.Padding(3);
            this.btnExport.Size = new System.Drawing.Size(75, 30);
            this.btnExport.TabIndex = 10;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // frmLeadReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1327, 745);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lblCorrespondence);
            this.Controls.Add(this.lblAdded);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbProspectAddedBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dteEnd);
            this.Controls.Add(this.dteStart);
            this.Controls.Add(this.chkAddedLeads);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmLeadReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Leads";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox chkAddedLeads;
        private System.Windows.Forms.DateTimePicker dteStart;
        private System.Windows.Forms.DateTimePicker dteEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbProspectAddedBy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblAdded;
        private System.Windows.Forms.Label lblCorrespondence;
        private buttonFormatting btnExport;
    }
}