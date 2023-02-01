﻿namespace PriceMaster
{
    partial class frmManagementView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManagementView));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCustomerSearch = new System.Windows.Forms.ComboBox();
            this.chkFuture = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbStaffSearch = new System.Windows.Forms.ComboBox();
            this.btnClear = new PriceMaster.buttonFormatting();
            this.buttonFormatting1 = new PriceMaster.buttonFormatting();
            this.btnExcel = new PriceMaster.buttonFormatting();
            this.dteEnd = new System.Windows.Forms.DateTimePicker();
            this.dteStart = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.chkCompleted = new System.Windows.Forms.CheckBox();
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(12, 78);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1421, 497);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label2.Location = new System.Drawing.Point(460, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 17);
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
            this.cmbCustomerSearch.Location = new System.Drawing.Point(460, 51);
            this.cmbCustomerSearch.Name = "cmbCustomerSearch";
            this.cmbCustomerSearch.Size = new System.Drawing.Size(188, 21);
            this.cmbCustomerSearch.TabIndex = 52;
            this.cmbCustomerSearch.SelectedIndexChanged += new System.EventHandler(this.cmbCustomerSearch_SelectedIndexChanged);
            // 
            // chkFuture
            // 
            this.chkFuture.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkFuture.AutoSize = true;
            this.chkFuture.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.chkFuture.Location = new System.Drawing.Point(654, 51);
            this.chkFuture.Name = "chkFuture";
            this.chkFuture.Size = new System.Drawing.Size(119, 21);
            this.chkFuture.TabIndex = 54;
            this.chkFuture.Text = "Future Chases";
            this.chkFuture.UseVisualStyleBackColor = true;
            this.chkFuture.CheckedChanged += new System.EventHandler(this.chkFuture_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label3.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label3.Location = new System.Drawing.Point(54, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 55;
            this.label3.Text = "= Priority ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.LightSkyBlue;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label4.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label4.Location = new System.Drawing.Point(12, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 17);
            this.label4.TabIndex = 56;
            this.label4.Text = "       ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label5.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label5.Location = new System.Drawing.Point(266, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 17);
            this.label5.TabIndex = 58;
            this.label5.Text = "Staff Search:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cmbStaffSearch
            // 
            this.cmbStaffSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbStaffSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbStaffSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbStaffSearch.FormattingEnabled = true;
            this.cmbStaffSearch.Location = new System.Drawing.Point(266, 51);
            this.cmbStaffSearch.Name = "cmbStaffSearch";
            this.cmbStaffSearch.Size = new System.Drawing.Size(188, 21);
            this.cmbStaffSearch.TabIndex = 57;
            this.cmbStaffSearch.SelectedIndexChanged += new System.EventHandler(this.cmbStaffSearch_SelectedIndexChanged);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnClear.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(1118, 42);
            this.btnClear.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnClear.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnClear.Name = "btnClear";
            this.btnClear.Padding = new System.Windows.Forms.Padding(3);
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 59;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // buttonFormatting1
            // 
            this.buttonFormatting1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonFormatting1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonFormatting1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonFormatting1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFormatting1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFormatting1.ForeColor = System.Drawing.Color.White;
            this.buttonFormatting1.Location = new System.Drawing.Point(1332, 42);
            this.buttonFormatting1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.buttonFormatting1.MinimumSize = new System.Drawing.Size(75, 30);
            this.buttonFormatting1.Name = "buttonFormatting1";
            this.buttonFormatting1.Padding = new System.Windows.Forms.Padding(3);
            this.buttonFormatting1.Size = new System.Drawing.Size(101, 30);
            this.buttonFormatting1.TabIndex = 60;
            this.buttonFormatting1.Text = "Print Sheet";
            this.buttonFormatting1.UseVisualStyleBackColor = false;
            this.buttonFormatting1.Click += new System.EventHandler(this.buttonFormatting1_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnExcel.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnExcel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.ForeColor = System.Drawing.Color.White;
            this.btnExcel.Location = new System.Drawing.Point(1197, 42);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnExcel.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Padding = new System.Windows.Forms.Padding(3);
            this.btnExcel.Size = new System.Drawing.Size(130, 30);
            this.btnExcel.TabIndex = 61;
            this.btnExcel.Text = "Export to Excel";
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // dteEnd
            // 
            this.dteEnd.Location = new System.Drawing.Point(128, 52);
            this.dteEnd.Name = "dteEnd";
            this.dteEnd.Size = new System.Drawing.Size(132, 20);
            this.dteEnd.TabIndex = 62;
            this.dteEnd.CloseUp += new System.EventHandler(this.dteEnd_CloseUp);
            // 
            // dteStart
            // 
            this.dteStart.Location = new System.Drawing.Point(128, 27);
            this.dteStart.Name = "dteStart";
            this.dteStart.Size = new System.Drawing.Size(132, 20);
            this.dteStart.TabIndex = 63;
            this.dteStart.CloseUp += new System.EventHandler(this.dteStart_CloseUp);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label1.Location = new System.Drawing.Point(128, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 17);
            this.label1.TabIndex = 64;
            this.label1.Text = "Chase Date";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // chkCompleted
            // 
            this.chkCompleted.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkCompleted.AutoSize = true;
            this.chkCompleted.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.chkCompleted.Location = new System.Drawing.Point(779, 52);
            this.chkCompleted.Name = "chkCompleted";
            this.chkCompleted.Size = new System.Drawing.Size(216, 21);
            this.chkCompleted.TabIndex = 65;
            this.chkCompleted.Text = "Show Only Completed Chases";
            this.chkCompleted.UseVisualStyleBackColor = true;
            this.chkCompleted.CheckedChanged += new System.EventHandler(this.chkCompleted_CheckedChanged);
            // 
            // frmManagementView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1445, 587);
            this.Controls.Add(this.chkCompleted);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dteStart);
            this.Controls.Add(this.dteEnd);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.buttonFormatting1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbStaffSearch);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkFuture);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbCustomerSearch);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "frmManagementView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Outstanding Chases";
            this.Shown += new System.EventHandler(this.frmSlimlineOutstandingChase_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCustomerSearch;
        private System.Windows.Forms.CheckBox chkFuture;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbStaffSearch;
        private buttonFormatting btnClear;
        private buttonFormatting buttonFormatting1;
        private buttonFormatting btnExcel;
        private System.Windows.Forms.DateTimePicker dteEnd;
        private System.Windows.Forms.DateTimePicker dteStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkCompleted;
    }
}