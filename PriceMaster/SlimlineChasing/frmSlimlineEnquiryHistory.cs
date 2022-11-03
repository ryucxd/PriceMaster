 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;

namespace PriceMaster.SlimlinelChasing
{
    public partial class frmSlimlineEnquiryHistory : Form
    {
        public int enquiry_id { get; set; }
        public frmSlimlineEnquiryHistory(int quote)
        {
            InitializeComponent();
            loadData(quote);

        }

        private void loadData(int enquiry_id)
        {
            string sql = "select body,sender_email_address from [EnquiryLog].dbo.Enquiry_Log where id = " + enquiry_id.ToString();
            string sent_by = "";
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //use this dt to fill out all the  boxes
                    webBrowser1.DocumentText = dt.Rows[0][0].ToString();
                    sent_by = dt.Rows[0][1].ToString();
                }

                //load the attachements
                sql = "SELECT full_file_path  as [File Location] FROM [EnquiryLog].dbo.attachment_log WHERE email_id = " + enquiry_id.ToString();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvAttachments.DataSource = dt;
                }
                dgvAttachments.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                conn.Close();
            }

            if (sent_by.Contains("EXCHANGELABS/OU=EXCHANGE"))
            {
                //remove all the clutter
                string temp_string = sent_by;
                sent_by = temp_string.Substring(temp_string.IndexOf("-") + 1);
            }
            lblSentBy.Text = "Email Body  -  Sent by: " + sent_by;

        }

        private void dgvAttachments_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (File.Exists(dgvAttachments.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                {
                    Process.Start("explorer.exe", dgvAttachments.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                }
                else
                    MessageBox.Show("The file you are trying to open cannot be located. It is very likely it has been deleted or renamed.", "Unreachable file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            { }
        }


    }
}
