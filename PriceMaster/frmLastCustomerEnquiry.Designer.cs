namespace PriceMaster
{
    partial class frmLastCustomerEnquiry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLastCustomerEnquiry));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.chkSlimline = new System.Windows.Forms.CheckBox();
            this.dteDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEnquiry = new PriceMaster.buttonFormatting();
            this.btnItems = new PriceMaster.buttonFormatting();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 100);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(960, 645);
            this.dataGridView1.TabIndex = 0;
            // 
            // chkSlimline
            // 
            this.chkSlimline.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkSlimline.AutoSize = true;
            this.chkSlimline.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.chkSlimline.Location = new System.Drawing.Point(571, 70);
            this.chkSlimline.Name = "chkSlimline";
            this.chkSlimline.Size = new System.Drawing.Size(78, 22);
            this.chkSlimline.TabIndex = 1;
            this.chkSlimline.Text = "Slimline";
            this.chkSlimline.UseVisualStyleBackColor = true;
            this.chkSlimline.CheckedChanged += new System.EventHandler(this.chkSlimline_CheckedChanged);
            // 
            // dteDate
            // 
            this.dteDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dteDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.dteDate.Location = new System.Drawing.Point(361, 70);
            this.dteDate.Name = "dteDate";
            this.dteDate.Size = new System.Drawing.Size(167, 24);
            this.dteDate.TabIndex = 2;
            this.dteDate.CloseUp += new System.EventHandler(this.dteDate_CloseUp);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(960, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "NON RETURNING ENQUIRIES";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label3.Location = new System.Drawing.Point(688, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(214, 23);
            this.label3.TabIndex = 59;
            this.label3.Text = "Order By";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnEnquiry
            // 
            this.btnEnquiry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnquiry.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnEnquiry.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnEnquiry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnquiry.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnquiry.ForeColor = System.Drawing.Color.White;
            this.btnEnquiry.Location = new System.Drawing.Point(677, 62);
            this.btnEnquiry.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnEnquiry.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnEnquiry.Name = "btnEnquiry";
            this.btnEnquiry.Padding = new System.Windows.Forms.Padding(3);
            this.btnEnquiry.Size = new System.Drawing.Size(115, 30);
            this.btnEnquiry.TabIndex = 57;
            this.btnEnquiry.Text = "Last Enquiry";
            this.btnEnquiry.UseVisualStyleBackColor = false;
            this.btnEnquiry.Click += new System.EventHandler(this.btnEnquiry_Click);
            // 
            // btnItems
            // 
            this.btnItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnItems.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnItems.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnItems.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItems.ForeColor = System.Drawing.Color.White;
            this.btnItems.Location = new System.Drawing.Point(802, 62);
            this.btnItems.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnItems.MinimumSize = new System.Drawing.Size(75, 30);
            this.btnItems.Name = "btnItems";
            this.btnItems.Padding = new System.Windows.Forms.Padding(3);
            this.btnItems.Size = new System.Drawing.Size(111, 30);
            this.btnItems.TabIndex = 58;
            this.btnItems.Text = "Total Items";
            this.btnItems.UseVisualStyleBackColor = false;
            this.btnItems.Click += new System.EventHandler(this.btnItems_Click);
            // 
            // frmLastCustomerEnquiry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 748);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnEnquiry);
            this.Controls.Add(this.btnItems);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dteDate);
            this.Controls.Add(this.chkSlimline);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "frmLastCustomerEnquiry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Non returning Enquiries";
            this.Shown += new System.EventHandler(this.frmLastCustomerEnquiry_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox chkSlimline;
        private System.Windows.Forms.DateTimePicker dteDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private buttonFormatting btnEnquiry;
        private buttonFormatting btnItems;
    }
}