using Microsoft.Office.Interop.Excel;
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
    public partial class frmSlimlineMultipleChaseLoss : Form
    {
        public int validation { get; set; }
        public int quote_id { get; set; }
        public frmSlimlineMultipleChaseLoss(int _quote_id)
        {
            InitializeComponent();
            quote_id = _quote_id;
        }

        private void btnUpdateProject_Click(object sender, EventArgs e)
        {
            int lead = 0, quote = 0, expensive = 0, unable = 0, non_responsive = 0;
            if (chkLeadTimeTooLong.Checked == true)
            {
                validation = -1;
                lead = -1;
            }
            if (chkQuoteTookTooLong.Checked == true)
            {
                validation = -1;
                quote = -1;
            }
            if (chkTooExpensive.Checked == true)
            {
                validation = -1;
                expensive = -1;
            }
            if (chkUnableToMeetSpec.Checked == true)
            {
                validation = -1;
                unable = -1;
            }
            if (chkNonResponsive.Checked == true)
            {
                validation = -1;
                non_responsive = -1;
            }

            if (validation != -1)
            {
                MessageBox.Show("Please at least one reason why this quote was lost before saving.", "No reason for loss.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string sql = "UPDATE [order_database].dbo.quotation_feed_back_slimline SET status = 'Lost', too_expensive = " + expensive + ",lead_time_too_long = " + lead + ",quote_took_too_long = " + quote + ",unable_to_meet_spec = " + unable + ",non_responsive_customer = " + non_responsive + " WHERE quote_id = " + quote_id.ToString();
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    cmd.ExecuteNonQuery();

                conn.Close();
            }
            this.Close();
        }
    }
}
