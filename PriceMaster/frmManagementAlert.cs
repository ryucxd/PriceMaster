using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PriceMaster
{
    public partial class frmManagementAlert : Form
    {
        public int slimline { get; set; }
        public int date_filter { get; set; }

        //indexes
        public int id_index { get; set; }
        public int alert_time_index { get; set; }
        public int sent_by_index { get; set; }
        public int sent_to_index { get; set; }
        public int quote_id_index { get; set; }
        public int customer_index { get; set; }
        public int chase_date_index { get; set; }
        public int chase_description_index { get; set; }
        public int alert_description_index { get; set; }
        public int alert_complete_index { get; set; }

        public frmManagementAlert(int _slimline)
        {
            InitializeComponent();

            slimline = _slimline;

            if (slimline == -1)
                chkboxSlimline.Checked = true;
            else
                chkboxSlimline.Checked = false;

            load_grid();

            fill_combo();


        }

        private void fill_combo()
        {
            cmbCustomer.Items.Clear();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (cmbCustomer.Items.Contains(row.Cells[customer_index].Value.ToString()))
                { } //nothing
                else
                    cmbCustomer.Items.Add(row.Cells[customer_index].Value.ToString());
            }
        }

        private void load_grid()
        {
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                string sql = "";

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
                sql = sql + "where a.slimline = " + slimline.ToString() + " ";

                //where filters

                if (date_filter == -1)
                    sql = sql + " AND  CAST(alert_time as date) >= '" + dteStart.Value.ToString("yyyyMMdd") + "'  AND CAST(alert_time as date) <= '" + dteEnd.Value.ToString("yyyyMMdd") + "' ";

                if (cmbCustomer.Text.Length > 0)
                    sql = sql + " AND customer = '" + cmbCustomer.Text + "' ";

                sql = sql + "Order by alert_time desc";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                    column_index();
                    format();
                }

                conn.Close();
            }
        }

        private void column_index()
        {
            id_index = dataGridView1.Columns["id"].Index;
            alert_time_index = dataGridView1.Columns["alert_time"].Index;
            sent_by_index = dataGridView1.Columns["sent_by"].Index;
            sent_to_index = dataGridView1.Columns["sent_to"].Index;
            quote_id_index = dataGridView1.Columns["quote_id"].Index;
            customer_index = dataGridView1.Columns["customer"].Index;
            chase_date_index = dataGridView1.Columns["chase_date"].Index;
            chase_description_index = dataGridView1.Columns["chase_description"].Index;
            alert_description_index = dataGridView1.Columns["alert_description"].Index;
            alert_complete_index = dataGridView1.Columns["alert_complete"].Index;

        }

        private void format()
        {

            dataGridView1.Columns[id_index].Visible = false;
            dataGridView1.Columns[alert_time_index].HeaderText = "Alert Time";
            dataGridView1.Columns[sent_by_index].HeaderText = "Sent By";
            dataGridView1.Columns[sent_to_index].HeaderText = "Sent To";
            dataGridView1.Columns[quote_id_index].HeaderText = "Quote ID";
            dataGridView1.Columns[customer_index].HeaderText = "Customer";
            dataGridView1.Columns[chase_date_index].HeaderText = "Chase Date";
            dataGridView1.Columns[chase_description_index].HeaderText = "Chase Description";
            dataGridView1.Columns[alert_description_index].HeaderText = "Resolution";
            dataGridView1.Columns[alert_complete_index].HeaderText = "Alert Complete";

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dataGridView1.Columns[chase_description_index].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[alert_description_index].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            foreach (DataGridViewRow row in dataGridView1.Rows)
                if (Convert.ToBoolean(row.Cells[alert_complete_index].Value) == true)
                    row.DefaultCellStyle.BackColor = Color.LightSkyBlue;

            dataGridView1.ClearSelection();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmManagementAlert_Shown(object sender, EventArgs e)
        {
            format();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            //check if this row is completeeeee
            int alert_comp = 0;
            if (dataGridView1.Rows[e.RowIndex].Cells[id_index].Value.ToString() == "1")
                alert_comp = -1;
            else
                alert_comp = 0;

            frmManagementAlertAction frm = new frmManagementAlertAction(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[id_index].Value.ToString()), alert_comp);
            frm.ShowDialog();
            load_grid();
        }

        private void dteStart_CloseUp(object sender, EventArgs e)
        {
            date_filter = -1;
            load_grid();
        }

        private void dteEnd_CloseUp(object sender, EventArgs e)
        {
            date_filter = -1;
            load_grid();
        }

        private void chkboxSlimline_CheckedChanged(object sender, EventArgs e)
        {
            date_filter = 0;
            cmbCustomer.Text = "";

            if (chkboxSlimline.Checked == true)
                slimline = -1;
            else
                slimline = 0;

            load_grid();
            fill_combo();

        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_grid();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            date_filter = 0;
            cmbCustomer.Text = "";
            load_grid();
        }
    }
}
