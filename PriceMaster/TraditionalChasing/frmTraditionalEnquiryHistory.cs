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

namespace PriceMaster.TraditionalChasing
{
    public partial class frmTraditionalEnquiryHistory : Form
    {
        public int enquiry_id { get; set; }
        public frmTraditionalEnquiryHistory(string quote)
        {
            InitializeComponent();
            loadEnquiry(quote);

            if (dataGridView1.Rows.Count > 0)
                loadData(Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value.ToString()),dataGridView1.Rows[0].Cells[2].Value.ToString());
        }

        private void loadEnquiry(string quote)
        {
            string sql = "select id, recieved_time,sender_email_address from[EnquiryLog].dbo.[Enquiry_Log] where related_quote = '" + quote + "' order by recieved_time desc";
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[0].HeaderText = "Enquiry ID";
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[1].HeaderText = "Related Quote";
                    dataGridView1.Columns[2].Visible = false;

                    foreach (DataRow row in dt.Rows)
                    {
                        if (row[2].ToString().Contains("EXCHANGELABS/OU=EXCHANGE"))
                        {
                            //remove all the clutter
                            string temp_string = row[2].ToString();
                            row[2] = temp_string.Substring(temp_string.IndexOf("-") + 1);
                        }
                    }


                }
                conn.Close();
            }

        }

        private void loadData(int enquiry_id,string sent_by)
        {
            string sql = "select body from [EnquiryLog].dbo.Enquiry_Log where id = " + enquiry_id.ToString();

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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            loadData(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()),dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
        }
    }
}
