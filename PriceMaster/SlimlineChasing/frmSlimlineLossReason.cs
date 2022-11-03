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

namespace PriceMaster
{
    public partial class frmSlimlineLossReason : Form
    {
        public int quote_id { get; set; }
        public frmSlimlineLossReason(int _quote_id)
        {
            InitializeComponent();
            quote_id = _quote_id;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (txtReason.Text.Length < 3)
            {
                MessageBox.Show("Please enter a more detailed description before saving.", "More information required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtReason.Text = txtReason.Text.Replace("'", "");
            string note = "";
            sql = "SELECT custom_feedback FROM [order_database].dbo.quotation_feed_back_slimline WHERE quote_id = " + quote_id;
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                //get the current data if there is any
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    string temp = (string)cmd.ExecuteScalar().ToString();
                    if (temp != "")
                        note = temp + Environment.NewLine + "REASON FOR LOSS: " + txtReason.Text;
                    else
                        note = "REASON FOR LOSS: " + txtReason.Text;
                }
                sql = "UPDATE [order_database].dbo.quotation_feed_back_slimline SET custom_feedback =  '" + note + "' WHERE quote_id = " + quote_id;
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    cmd.ExecuteNonQuery();

                conn.Close();
                this.Close();
            }

        }
    }
}
