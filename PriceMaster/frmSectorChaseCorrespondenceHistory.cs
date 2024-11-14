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
    public partial class frmSectorChaseCorrespondenceHistory : Form
    {

        public int correspondence { get; set; }
        public string customer { get; set; }
        public int staff_id { get; set; }
        public int slimline { get; set; }
        public string default_quote_id { get; set; }
        public frmSectorChaseCorrespondenceHistory(int correspondence, string customer, int staff_id, string default_quote_id, int slimline)
        {
            InitializeComponent();

            this.correspondence = correspondence;
            this.customer = customer;
            //if the passed over staff_id = 0 then we need to find out who made the correspondence/chase and make it them
            if (staff_id > 0)
                this.staff_id = staff_id;
            else
            {
                string sql = "";

                if (correspondence == -1)
                    sql = "select correspondence_by FROM [order_database].dbo.quotation_chase_customer where id = " + default_quote_id;
                else
                    sql = "select chased_by FROM [order_database].dbo.quotation_chase_log where id = " + default_quote_id;

                using (SqlConnection conn = new SqlConnection (CONNECT.ConnectionString))
                {
                    conn.Open ();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        this.staff_id = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    conn.Close();
                
                }

            }
            this.default_quote_id = default_quote_id;
            this.slimline = slimline;
            fillHistory();
        }


        private void fillDetails(string quote_id)
        {

            string sql = "";

            if (correspondence == -1)
            {
                sql = "select customer_name,body," +
                    "case when next_correspondence_date is null then 'No follow up' else Convert(varchar,cast(next_correspondence_date as date),103) end as next_correspondence," +
                    "CASE WHEN complete = 0 THEN CAST(0 AS BIT) WHEN complete IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Complete] " +
                    "FROM [order_database].dbo.quotation_chase_customer " +
                    "WHERE slimline = " + slimline + " AND id = " + quote_id;
            }
            else //chases
            {
                if (slimline == 0)
                {
                    //traditional
                    sql = "select " +
                       "s.customer,chase_description," +
                       "case when next_chase_date is null then 'No follow up' else Convert(varchar,cast(next_chase_date as date),103) end as next_correspondence," +
                       "CASE WHEN chase_complete = 0 THEN CAST(0 AS BIT) WHEN chase_complete IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Complete] " +
                       "FROM [order_database].dbo.quotation_chase_log q " +
                       "left join [order_database].dbo.solidworks_quotation_log s on q.quote_id = s.quote_id " +
                       "right join [order_database].dbo.view_solidworks_max_rev m on m.quote_id = s.quote_id AND m.revision_number = s.revision_number " +
                       "where q.id = " + quote_id;
                }
                else
                {

                    //slimline
                    sql = "select " +
                       "s.name,chase_description," +
                       "case when next_chase_date is null then 'No follow up' else Convert(varchar,cast(next_chase_date as date),103) end as next_correspondence," +
                       "CASE WHEN chase_complete = 0 THEN CAST(0 AS BIT) WHEN chase_complete IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Complete] " +
                       "FROM [order_database].dbo.quotation_chase_log_slimline q " +
                       "left join[price_master].dbo.sl_quotation sl on q.quote_id = sl.quote_id " +
                       "left join[dsl_fitting].dbo.[SALES_LEDGER] s on sl.customer_acc_ref = s.ACCOUNT_REF " +
                       "where q.id = " + quote_id + " and sl.highest_issue = -1";
                }
            }

            //load the data here

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    lblCustomer.Text = dt.Rows[0][0].ToString().Trim();
                    txtDescription.Text = dt.Rows[0][1].ToString();
                    txtFollowUp.Text = dt.Rows[0][2].ToString();
                }

                conn.Close();
            }

        }

        public void fillHistory()
        {
            string sql = "";
            if (correspondence == -1)
            {
                sql = "select id,date_created as [Correspondence Date],'a' as [Quote ID], " +
                    "CASE WHEN complete = 0 THEN CAST(0 AS BIT) WHEN complete IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Complete] " +
                    "FROM [order_database].dbo.quotation_chase_customer " +
                    "where correspondence_by = " + staff_id + " and customer_name = '" + customer + "' AND slimline = " + slimline + " " +
                    "ORDER BY date_created desc";
            }
            else //chases
            {

                //traditional
                string sql_traditional = "select q.id,chase_date as [Chase Date],q.quote_id as [Quote ID], " +
                     "CASE WHEN chase_complete = 0 THEN CAST(0 AS BIT) WHEN chase_complete IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Complete] " +
                     "FROM [order_database].dbo.quotation_chase_log q " +
                     "left join [order_database].dbo.solidworks_quotation_log s on q.quote_id = s.quote_id " +
                     "right join [order_database].dbo.view_solidworks_max_rev m on m.quote_id = s.quote_id AND m.revision_number = s.revision_number " +
                     "where chased_by = " + staff_id + " AND s.customer = '" + customer + "' " +
                     "ORDER BY chase_date desc";

                //slimline
                string sql_slimline = "select q.id,chase_date [Chase Date],q.quote_id as [Quote ID]," +
                     "CASE WHEN chase_complete = 0 THEN CAST(0 AS BIT) WHEN chase_complete IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Complete] " +
                     "FROM [order_database].dbo.quotation_chase_log_slimline q " +
                     "left join[price_master].dbo.sl_quotation sl on q.quote_id = sl.quote_id " +
                     "left join[dsl_fitting].dbo.[SALES_LEDGER] s on sl.customer_acc_ref = s.ACCOUNT_REF " +
                     "where chased_by = " + staff_id + " AND s.NAME = '" + customer + "' AND highest_issue = -1 " +
                     "ORDER BY chase_date desc";



                if (slimline == -1)
                    sql = sql_slimline;
                else
                    sql = sql_traditional;
            }


            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvHistory.DataSource = dt;

                    foreach (DataGridViewColumn col in dgvHistory.Columns)
                    {
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        col.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                    dgvHistory.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvHistory.Columns[0].Visible = false;
                    dgvHistory.Columns[0].ReadOnly = true;
                    dgvHistory.Columns[1].ReadOnly = true;
                    dgvHistory.Columns[2].ReadOnly = true;
                    dgvHistory.Columns[3].ReadOnly = true;

                    if (correspondence == -1)
                        dgvHistory.Columns[2].Visible = false;


                }

                conn.Close();
            }

        }

        private void frmSectorChaseCorrespondenceHistory_Shown(object sender, EventArgs e)
        {

            //colour the datagridview
            foreach (DataGridViewRow row in dgvHistory.Rows)
            {
                if (row.Cells[0].Value.ToString() == default_quote_id.ToString())
                    row.DefaultCellStyle.BackColor = Color.LightSkyBlue;
            }

            fillDetails(default_quote_id);


            dgvHistory.ClearSelection();

        }

        private void dgvHistory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


            //colour the datagridview
            foreach (DataGridViewRow row in dgvHistory.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.Empty;
            }

            dgvHistory.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSkyBlue;

            fillDetails(dgvHistory.Rows[e.RowIndex].Cells[0].Value.ToString());

            dgvHistory.ClearSelection();

        }
    }
}
