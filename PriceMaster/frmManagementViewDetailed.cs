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

namespace PriceMaster
{
    public partial class frmManagementViewDetailed : Form
    {
        public int correspondence_id { get; set; }
        public int slimline { get; set; }
        public int alert_complete { get; set; }
        public frmManagementViewDetailed(int id, int slimline)
        {
            InitializeComponent();

            this.slimline = slimline;
            correspondence_id = id;

            load_data();
        }

        private void load_data()
        {
            string sql = "";
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                if (slimline == -1)
                {
                    sql = "select a.id,alert_time,u.forename + ' ' + u.surname as  sent_by,sent_to,q.quote_id,s.customer,q.chase_date,q.chase_description,alert_description, " +
                        "CASE WHEN alert_complete = 0 THEN CAST(0 AS BIT) WHEN alert_complete IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS alert_complete " +
                        "from [order_database].dbo.quotation_chase_alert a " +
                        "left join [order_database].dbo.quotation_chase_log_slimline  q on a.chase_id = q.id " +
                        "left join [user_info].dbo.[user] u on a.sent_by = u.id " +
                        "left join (select quote_id,s.[NAME] as customer from dbo.sl_quotation a " +
                        "LEFT JOIN [dsl_fitting].dbo.[SALES_LEDGER] s on s.ACCOUNT_REF = a.customer_acc_ref  " +
                        "where highest_issue = -1) s on s.quote_id = q.quote_id ";
                }
                else
                {
                    sql = "select a.id,alert_time,u.forename + ' ' + u.surname as  sent_by,sent_to,q.quote_id,s.customer,q.chase_date,q.chase_description," +
                        "alert_description, " +
                        "CASE WHEN alert_complete = 0 THEN CAST(0 AS BIT) WHEN alert_complete IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS alert_complete  " +
                        "from [order_database].dbo.quotation_chase_alert a " +
                        "left join [order_database].dbo.quotation_chase_log  q on a.chase_id = q.id " +
                        "left join [user_info].dbo.[user] u on a.sent_by = u.id " +
                        "left join [order_database].dbo.solidworks_quotation_log s on s.quote_id = q.quote_id " +
                        "right join (select quote_id, max(revision_number) revision_number  FROM [order_database].dbo.solidworks_quotation_log group by quote_id) s2 " +
                        "on s.quote_id = s2.quote_id AND s.revision_number = s2.revision_number ";
                }

                //both strings include this 
                sql = sql + "where a.slimline = " + slimline.ToString() + " AND a.id = " + correspondence_id.ToString();


                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    txtCorrespondenceBy.Text = dt.Rows[0][2].ToString();
                    txtCorrespondenceDate.Text = dt.Rows[0][6].ToString();
                    txtQuoteId.Text = dt.Rows[0][4].ToString();
                    txtDescription.Text = dt.Rows[0][7].ToString();
                    txtResolution.Text = dt.Rows[0][8].ToString();
                    if (dt.Rows[0][9].ToString() == "True")
                        alert_complete = -1;
                    else
                        alert_complete = 0;

                }

                //lock based on complete
                if (alert_complete == -1)
                {
                    btnComplete.Visible = false;
                    txtResolution.ReadOnly = true;
                    btnClose.Location = new Point(245, 626);
                }
                else
                {
                    btnComplete.Visible = true;
                    txtResolution.Enabled = true;

                }

                conn.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            //check if the description has text
            txtResolution.Text = txtResolution.Text.Replace("'", "");
            if (txtResolution.Text.Length < 5)
            {
                MessageBox.Show("Please enter a more detailed note before completing this note");
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to save this alert description?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string sql = "update [order_database].dbo.quotation_chase_alert " +
                    "SET alert_description = '" + txtResolution.Text + "',alert_complete = -1," +
                    " alert_complete_by = " + CONNECT.staffID + ",alert_complete_date = GETDATE() WHERE id =  " + correspondence_id.ToString();

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
}
