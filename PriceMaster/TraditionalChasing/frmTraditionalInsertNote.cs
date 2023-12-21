using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PriceMaster.SlimlineChasing
{
    public partial class frmTraditionalInsertNote : Form
    {
        public int quote_id { get; set; }
        public frmTraditionalInsertNote(int _quote_id)
        {
            InitializeComponent();
            this.quote_id = _quote_id;
        }

        private void btnAddNote_Click(object sender, EventArgs e)
        {
            //remove any ' 

            txtCustom.Text = txtCustom.Text.Replace("'", "");

            if (txtCustom.Text.Length < 0)
            {
                MessageBox.Show("Please enter a detailed note before proceeding.", "Missing Note", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string sql = "SELECT custom_feedback FROM [order_database].dbo.quotation_feed_back WHERE quote_id = " + quote_id.ToString();
            string note = "";
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    note = (string)cmd.ExecuteScalar().ToString();
                }

                if (note.Length > 0)
                    note = note + Environment.NewLine;

                sql = "UPDATE [order_database].dbo.quotation_feed_back  SET custom_feedback = '" + note + txtCustom.Text + " - "
                + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + " - " + CONNECT.staffFullName + "' WHERE quote_id = " + quote_id.ToString();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    cmd.ExecuteNonQuery();

                conn.Close();
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
