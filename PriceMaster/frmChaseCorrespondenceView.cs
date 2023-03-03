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
    public partial class frmChaseCorrespondenceView : Form
    {
        public int correspondence_id { get; set; }
        public frmChaseCorrespondenceView(int id)
        {
            InitializeComponent();
            correspondence_id = id;
            load_data();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
        }

        private void load_data()
        {

            string sql = "SELECT " +
                "[customer_name],[date_created],[body],[email],[phone],[inPerson],[contact],[issue_with_leadtime],[issue_with_quote_turnaround_time]" +
                ",[issue_with_product],[issue_with_installation],[issue_with_service],correspondence_by,next_correspondence_date,no_follow_up FROM  [order_database].[dbo].[quotation_chase_customer] " +
                "WHERE id = " + correspondence_id.ToString();

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    lblTitle.Text = dt.Rows[0][0].ToString() + " - " + dt.Rows[0][1].ToString();
                    txtDescription.Text = dt.Rows[0][2].ToString();
                    //phone email in person checkboxes
                    if (dt.Rows[0][3].ToString() == "-1")
                        chkPhone.Checked = true;
                    if (dt.Rows[0][4].ToString() == "-1")
                        chkEmail.Checked = true;
                    if (dt.Rows[0][5].ToString() == "-1")
                        chkInPerson.Checked = true;
                    txtContact.Text = dt.Rows[0][6].ToString();
                    //issues with etc
                    if (dt.Rows[0][7].ToString() == "-1")
                        chkLeadtime.Checked = true;
                    if (dt.Rows[0][8].ToString() == "-1")
                        chkTurnaround.Checked = true;
                    if (dt.Rows[0][9].ToString() == "-1")
                        chkProduct.Checked = true;
                    if (dt.Rows[0][10].ToString() == "-1")
                        chkInstallation.Checked = true;
                    if (dt.Rows[0][11].ToString() == "-1")
                        chkService.Checked = true;

                    if (dt.Rows[0][14].ToString() == "-1")
                    {
                        chkFollowUp.Checked = true;
                        dteNextDate.Visible = false;
                    }
                    else
                    {
                        chkFollowUp.Visible = false;
                        if (string.IsNullOrEmpty(dt.Rows[0][13].ToString()) == false)
                            dteNextDate.Value = Convert.ToDateTime(Convert.ToDateTime(dt.Rows[0][13].ToString()));
                    }


                }
            }
        }
    }
}
