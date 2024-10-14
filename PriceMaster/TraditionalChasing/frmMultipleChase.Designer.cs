namespace PriceMaster.TraditionalChasing
{
    partial class frmMultipleChase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMultipleChase));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.btnAddChase = new PriceMaster.buttonFormatting();
            this.btnCancel = new PriceMaster.buttonFormatting();
            this.dgvSelectedQuotes = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQuote = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedQuotes)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 98);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(335, 574);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.label1.Location = new System.Drawing.Point(12, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(335, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "DOUBLE CLICK TO SELECT A QUOTE";
            // 
            // lblCustomer
            // 
            this.lblCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.lblCustomer.Location = new System.Drawing.Point(12, 9);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(697, 31);
            this.lblCustomer.TabIndex = 2;
            this.lblCustomer.Text = "CUSTOMER";
            this.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAddChase
            // 
            this.btnAddChase.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnAddChase.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAddChase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddChase.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddChase.ForeColor = System.Drawing.Color.White;
            this.btnAddChase.Location = new System.Drawing.Point(357, 675);
            this.btnAddChase.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnAddChase.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnAddChase.Name = "btnAddChase";
            this.btnAddChase.Padding = new System.Windows.Forms.Padding(3);
            this.btnAddChase.Size = new System.Drawing.Size(108, 30);
            this.btnAddChase.TabIndex = 3;
            this.btnAddChase.Text = "Add Chases ";
            this.btnAddChase.UseVisualStyleBackColor = false;
            this.btnAddChase.Click += new System.EventHandler(this.btnAddChase_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(239, 675);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnCancel.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(3);
            this.btnCancel.Size = new System.Drawing.Size(108, 30);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dgvSelectedQuotes
            // 
            this.dgvSelectedQuotes.AllowUserToAddRows = false;
            this.dgvSelectedQuotes.AllowUserToDeleteRows = false;
            this.dgvSelectedQuotes.AllowUserToResizeColumns = false;
            this.dgvSelectedQuotes.AllowUserToResizeRows = false;
            this.dgvSelectedQuotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSelectedQuotes.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSelectedQuotes.Location = new System.Drawing.Point(374, 98);
            this.dgvSelectedQuotes.Name = "dgvSelectedQuotes";
            this.dgvSelectedQuotes.RowHeadersVisible = false;
            this.dgvSelectedQuotes.Size = new System.Drawing.Size(335, 574);
            this.dgvSelectedQuotes.TabIndex = 5;
            this.dgvSelectedQuotes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSelectedQuotes_CellDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.label2.Location = new System.Drawing.Point(447, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 22);
            this.label2.TabIndex = 6;
            this.label2.Text = "SELECTED QUOTES";
            // 
            // txtQuote
            // 
            this.txtQuote.Location = new System.Drawing.Point(156, 44);
            this.txtQuote.Name = "txtQuote";
            this.txtQuote.Size = new System.Drawing.Size(139, 20);
            this.txtQuote.TabIndex = 7;
            this.txtQuote.TextChanged += new System.EventHandler(this.txtQuote_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.label3.Location = new System.Drawing.Point(29, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 22);
            this.label3.TabIndex = 8;
            this.label3.Text = "Quote Search";
            // 
            // frmMultipleChase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 712);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtQuote);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvSelectedQuotes);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddChase);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMultipleChase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Multiple chase";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedQuotes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCustomer;
        private buttonFormatting btnAddChase;
        private buttonFormatting btnCancel;
        private System.Windows.Forms.DataGridView dgvSelectedQuotes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtQuote;
        private System.Windows.Forms.Label label3;
    }
}