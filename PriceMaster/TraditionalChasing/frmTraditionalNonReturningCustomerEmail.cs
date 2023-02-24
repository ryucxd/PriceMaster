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
    public partial class frmTraditionalNonReturningCustomerEmail : Form
    {
        public int enquiry_id { get; set; }
        public int door_id { get; set; }
        public string sender_email { get; set; }
        public frmTraditionalNonReturningCustomerEmail(int _door_id)
        {
            InitializeComponent();
            door_id = _door_id;
            loadData();
        }

     

        private void loadData()
        {
            string sent_by = "";
            string order_email_id = "";
            string sql = "select o.Body,o.sender_name,o.id,o.sender_email_address from [order_database].dbo.door d " +
                "left join [order_database].dbo.door_container dc on d.order_id = dc.order_id " +
                "left join [order_database].dbo.order_Log o on dc.email_order_id = o.id " +
                "where d.id = " + door_id.ToString();

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
                    order_email_id = dt.Rows[0][2].ToString();
                    sender_email = dt.Rows[0][3].ToString();
                }
                try
                {
                    //load the attachements
                    sql = "SELECT full_file_path  as [File Location] FROM [order_database].dbo.order_Attachment_Log WHERE email_id = " + order_email_id.ToString();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvAttachments.DataSource = dt;
                    }
                    dgvAttachments.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                catch { }
                conn.Close();
            }

            lblSentBy.Text = "Email Body  -  Sent by: " + sent_by;
            lblEmail.Text = "Email address: " + sender_email;

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
           // loadData(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()),dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
        }

        private void lblEmail_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(sender_email);

            MessageBox.Show("Email Address Copied","Copied to Clipboard",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);

        }
    }
}
