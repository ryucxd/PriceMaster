namespace PriceMaster
{
    partial class frmCorrespondenceMassInsert
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnImportList = new PriceMaster.buttonFormatting();
            this.buttonFormatting1 = new PriceMaster.buttonFormatting();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(15, 127);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(788, 379);
            this.dataGridView1.TabIndex = 1;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.richTextBox1.Location = new System.Drawing.Point(12, 528);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(788, 313);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.dateTimePicker1.Location = new System.Drawing.Point(330, 84);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(153, 21);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label1.Location = new System.Drawing.Point(12, 509);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Body";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label2.Location = new System.Drawing.Point(15, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Customer List";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label3.Location = new System.Drawing.Point(330, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Follow up date";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtFile
            // 
            this.txtFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtFile.Location = new System.Drawing.Point(282, 25);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(248, 21);
            this.txtFile.TabIndex = 8;
            // 
            // btnImportList
            // 
            this.btnImportList.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnImportList.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnImportList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportList.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportList.ForeColor = System.Drawing.Color.White;
            this.btnImportList.Location = new System.Drawing.Point(538, 21);
            this.btnImportList.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnImportList.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnImportList.Name = "btnImportList";
            this.btnImportList.Padding = new System.Windows.Forms.Padding(3);
            this.btnImportList.Size = new System.Drawing.Size(75, 30);
            this.btnImportList.TabIndex = 3;
            this.btnImportList.Text = "Import";
            this.btnImportList.UseVisualStyleBackColor = false;
            this.btnImportList.Click += new System.EventHandler(this.btnImportList_Click);
            // 
            // buttonFormatting1
            // 
            this.buttonFormatting1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonFormatting1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonFormatting1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFormatting1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFormatting1.ForeColor = System.Drawing.Color.White;
            this.buttonFormatting1.Location = new System.Drawing.Point(611, 844);
            this.buttonFormatting1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.buttonFormatting1.MinimumSize = new System.Drawing.Size(75, 30);
            this.buttonFormatting1.Name = "buttonFormatting1";
            this.buttonFormatting1.Padding = new System.Windows.Forms.Padding(3);
            this.buttonFormatting1.Size = new System.Drawing.Size(187, 30);
            this.buttonFormatting1.TabIndex = 9;
            this.buttonFormatting1.Text = "Insert correspondence";
            this.buttonFormatting1.UseVisualStyleBackColor = false;
            // 
            // frmCorrespondenceMassInsert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 879);
            this.Controls.Add(this.buttonFormatting1);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnImportList);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmCorrespondenceMassInsert";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Correspondence Mass Insert";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private buttonFormatting btnImportList;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFile;
        private buttonFormatting buttonFormatting1;
    }
}