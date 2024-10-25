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
    public partial class frmLeadReport : Form
    {
        public frmLeadReport()
        {
            InitializeComponent();

            dteStart.Value = dteStart.Value.AddMonths(-1);

            fillGrid();


            string sql = " SELECT distinct forename + ' ' + surname FROM [order_database].dbo.sales_new_leads s " +
                "left join [user_info].dbo.[user] u on s.prospect_added_by = u.id " +
                "where forename + ' ' + surname is not null ";

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        cmbProspectAddedBy.Items.Add(row[0].ToString());
                    }
                }

                conn.Close();
            }


        }


        public void fillGrid()
        {

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                string sql = "select lead_date," +
                "case when s.name is null then sl.customer else s.NAME end as lead_customer," +
                "sl.contact_name as lead_contact_name," +
                "u_allocated.forename + ' ' + u_allocated.surname as allocated_to," +
                "v.sector," +
                "u_added_by.forename + ' ' + u_added_by.surname as prospect_added_by," +
                "prospect_added_date, " +
                "correspondence_date " +
                "FROM [order_database].dbo.sales_new_leads sl " +
                "left join [order_database].dbo.[SALES_LEDGER_PROSPECT] s on sl.prospect_acc_ref = s.ACCOUNT_REF " +
                "left join [order_database].dbo.[view_sales_table] v on sl.sector_id = v.id " +
                "left join [user_info].dbo.[user] u_allocated on sl.allocated_to = u_allocated.id " +
                "left join [user_info].dbo.[user] u_added_by on sl.prospect_added_by = u_added_by.id " +
                "left join (select customer_name, min(date_created) as correspondence_date FROM [order_database].dbo.[quotation_chase_customer] q " +
                "           group by customer_name) as q on s.NAME = q.customer_name " +
                "WHERE (sl.prospect_acc_ref is null or sl.prospect_acc_ref <> 'corey') and " +
                "lead_date >= '" + dteStart.Value.ToString("yyyyMMdd") + "' AND lead_date <= '" + dteEnd.Value.ToString("yyyyMMdd") + "' ";


                if (chkAddedLeads.Checked)
                {
                    sql += " AND prospect_added_by is not null ";
                }


                if (cmbProspectAddedBy.Text.Length > 0)
                {
                    string sql_user = "select id FROM [user_info].dbo.[user] where forename + ' ' + surname = '" + cmbProspectAddedBy.Text + "'";
                    using (SqlCommand cmd = new SqlCommand(sql_user, conn))
                    {
                        sql += " AND prospect_added_by = " + cmd.ExecuteScalar().ToString();
                    }

                }



                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                }

                conn.Close();
            }

            format();
        }

        public void format()
        {

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

        }

        private void dteStart_CloseUp(object sender, EventArgs e)
        {
            fillGrid();
        }

        private void dteEnd_CloseUp(object sender, EventArgs e)
        {
            fillGrid();
        }

        private void chkAddedLeads_CheckedChanged(object sender, EventArgs e)
        {
            fillGrid();
        }

        private void cmbProspectAddedBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillGrid();
        }
    }
}
