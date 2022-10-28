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
    public partial class frmTraditionalChaseUpdate : Form
    {
        public int validation { get; set; }
        public int quote_id { get; set; }
        public frmTraditionalChaseUpdate(int _quote_id)
        {
            InitializeComponent();
            validation = 0;
            quote_id = _quote_id;
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStatus.Text == "Lost")
            {
                lblLost.Visible = true;
                chkLeadTimeTooLong.Visible = true;
                chkQuoteTookTooLong.Visible = true;
                chkTooExpensive.Visible = true;
                chkUnableToMeetSpec.Visible = true;
            }
            else
            {
                lblLost.Visible = false;
                chkLeadTimeTooLong.Visible = false;
                chkQuoteTookTooLong.Visible = false;
                chkTooExpensive.Visible = false;
                chkUnableToMeetSpec.Visible = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int lead = 0, quote = 0, expensive = 0, unable = 0;
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

            if (cmbStatus.Text == "")
            {
                MessageBox.Show("Please select a status before saving.", "No Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cmbStatus.Text == "Lost" && validation != -1)
            {
                MessageBox.Show("Please at least one reason why this quote was lost before saving.", "No reason for loss.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string sql = "UPDATE [order_database].dbo.quotation_feed_back SET status = '" + cmbStatus.Text + "',too_expensive = " + expensive + ",lead_time_too_long = " + lead + ",quote_took_too_long = " + quote + ",unable_to_meet_spec = " + unable + " " +
                            "WHERE quote_id = " + quote_id.ToString();
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    cmd.ExecuteNonQuery();

                if (cmbStatus.Text == "Lost")
                {
                    frmTraditionalLossReason frm = new frmTraditionalLossReason(quote_id);
                    frm.ShowDialog();
                    CONNECT.skipLoss = -1;
                }

                conn.Close();
                this.Close();
            }

        }


    }
}
