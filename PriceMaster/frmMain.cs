﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using System.Diagnostics;

namespace PriceMaster
{
    public partial class frmMain : Form
    {
        public string sql_where { get; set; }
        //datagridview column variables
        public int quote_id_index { get; set; }
        public int view_index { get; set; }
        public int view_button_index { get; set; }
        public int email_index { get; set; }
        public int email_button_index { get; set; }
        public int issue_id_index { get; set; }
        public int current_index { get; set; }
        public int priority_id_index { get; set; }
        public int description_index { get; set; }
        public int material_index { get; set; }
        public int system_index { get; set; }
        public int customer_index { get; set; }
        public int email_sent_by_index { get; set; }
        public int email_sent_date_index { get; set; }
        public int quotation_ref_index { get; set; }
        public int price_index { get; set; }
        public int quoted_by_index { get; set; }
        public int quote_date_index { get; set; }

        //date stuffs
        public int dateFilter { get; set; }
        public frmMain()
        {
            InitializeComponent();
            dateFilter = 0;
            loadData();
        }


        private void loadData()
        {
            string sql = "SELECT top 150 quote_id,'View' as [view_temp],'Email' as email_temp,issue_id,CASE WHEN highest_issue = 0 THEN CAST(0 AS BIT) WHEN highest_issue IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [current] ,p.priority_description as priority_id,st.description,m.material_description, " +
                                "COALESCE(slimline_systems_1.system_name, '') + ' - ' + COALESCE(slimline_systems_2.system_name, '') + ' - ' + COALESCE(slimline_systems_3.system_name, '') + ' - ' + " +
                                "COALESCE(slimline_systems_4.system_name, '') + ' - ' + COALESCE(slimline_systems_5.system_name, '') as [system_row] , rtrim(s.[NAME]) as customer,u_2.forename + ' ' + u_2.surname as  email_sent_by,email_sent_date,quotation_ref,COALESCE(price,0) as price," +
                                "u.forename + ' ' + u.surname as [quoted_by],quote_date FROM dbo.sl_quotation a " +
                                "LEFT JOIN[dsl_fitting].dbo.[SALES_LEDGER] s on s.ACCOUNT_REF = a.customer_acc_ref " +
                                "left join[user_info].dbo.[user] u on u.id = a.created_by_id " +
                                "left join[user_info].dbo.[user] u_2 on u_2.id = a.email_sent_by " +
                                "left join dbo.sl_status st on st.id = a.status_id " +
                                "left join dbo.sl_material m on m.id = a.material_type_id " +
                                "left join dbo.sl_priority p on p.id = a.priority_id " +
                                "LEFT JOIN dbo.slimline_systems as slimline_systems_1 ON a.system_id_1 = slimline_systems_1.id " +
                                "LEFT JOIN dbo.slimline_systems AS slimline_systems_2 ON a.system_id_2 = slimline_systems_2.id " +
                                "LEFT JOIN dbo.slimline_systems AS slimline_systems_3 ON a.system_id_3 = slimline_systems_3.id " +
                                "LEFT JOIN dbo.slimline_systems AS slimline_systems_4 ON a.system_id_4 = slimline_systems_4.id " +
                                "LEFT JOIN dbo.slimline_systems AS slimline_systems_5 ON a.system_id_5 = slimline_systems_5.id ";


            sql = sql + " WHERE highest_issue = -1 ";

            if (txtQuoteID.Text.Length > 0)
                sql = sql + " AND quote_id like '%" + txtQuoteID.Text + "%' ";

            if (cmbStatus.Text.Length > 0)
                sql = sql + " AND st.description = '" + cmbStatus.Text + "' ";
            if (cmbMaterial.Text.Length > 0)
                sql = sql + " AND m.material_description = '" + cmbMaterial.Text + "'";
            if (cmbSystem.Text.Length > 0)
                sql = sql + " AND (slimline_systems_1.system_name LIKE '%" + cmbSystem.Text + "%' or slimline_systems_2.system_name LIKE '%" + cmbSystem.Text + "%' or slimline_systems_3.system_name LIKE '%" + cmbSystem.Text + "%' or slimline_systems_4.system_name LIKE '%" + cmbSystem.Text + "%' )";
            if (cmbCustomer.Text.Length > 0)
                sql = sql + " AND s.[NAME] LIKE '%" + cmbCustomer.Text + "%'";

            if (txtQuoteRef.Text.Length > 0)
                sql = sql + " AND quotation_ref LIKE '%" + txtQuoteRef.Text + "%'";
            if (txtPrice.Text.Length > 0)
                sql = sql + " AND price >= " + txtPrice.Text + " ";
            if (cmbQuotedBy.Text.Length > 0)
                sql = sql + " AND u.forename + ' ' + u.surname LIKE '%" + cmbQuotedBy.Text + "%'";

            if (dateFilter == -1)
                sql = sql + " AND quote_date >= '" + dteStart.Value.ToString("yyyyMMdd") + "' AND quote_date <= '" + dteEnd.Value.ToString("yyyyMMdd") + "' ";


            sql_where = sql.Substring(sql.LastIndexOf("-1") + 2);


            //  AND quote_date >= '20220701 00:00' AND quote_date <= '20220731'   ORDER BY quote_id DESC, issue_id";

            sql = sql + " order by quote_id DESC, issue_id";
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conn.Close();
                }
            }
            column_index_refresh();
            add_buttons();
            column_index_refresh();
            format();
            fillComboBox();
        }

        private void column_index_refresh()
        {
            quote_id_index = dataGridView1.Columns["quote_id"].Index;
            view_index = dataGridView1.Columns["view_temp"].Index;
            if (dataGridView1.Columns.Contains("View") == true)
                view_button_index = dataGridView1.Columns["View"].Index;

            email_index = dataGridView1.Columns["email_temp"].Index;

            if (dataGridView1.Columns.Contains("Email") == true)
                email_button_index = dataGridView1.Columns["Email"].Index;

            issue_id_index = dataGridView1.Columns["issue_id"].Index;
            current_index = dataGridView1.Columns["current"].Index;
            priority_id_index = dataGridView1.Columns["priority_id"].Index;
            description_index = dataGridView1.Columns["description"].Index;
            material_index = dataGridView1.Columns["material_description"].Index;
            system_index = dataGridView1.Columns["system_row"].Index;
            customer_index = dataGridView1.Columns["customer"].Index;
            email_sent_by_index = dataGridView1.Columns["email_sent_by"].Index;
            email_sent_date_index = dataGridView1.Columns["email_sent_date"].Index;
            quotation_ref_index = dataGridView1.Columns["quotation_ref"].Index;
            price_index = dataGridView1.Columns["price"].Index;
            quoted_by_index = dataGridView1.Columns["quoted_by"].Index;
            quote_date_index = dataGridView1.Columns["quote_date"].Index;


            ////checkbox for revision
            //if (dgvEnquiryLog.Columns.Contains("revision_checkbox") == true)
            //    revisionCheckboxIndex = dgvEnquiryLog.Columns["revision_checkbox"].Index;
        }

        private void add_buttons()
        {
            int column_index = 0;
            if (dataGridView1.Columns.Contains("View") == true)
                dataGridView1.Columns.Remove("View");
            column_index_refresh();
            if (dataGridView1.Columns.Contains("Email") == true)
                dataGridView1.Columns.Remove("Email");


            column_index = view_index;
            DataGridViewButtonColumn view_button = new DataGridViewButtonColumn();
            view_button.Name = "View";
            view_button.Text = "View";
            view_button.UseColumnTextForButtonValue = true;
            if (dataGridView1.Columns["view_column"] == null)
            {
                dataGridView1.Columns.Insert(column_index, view_button);
            }

            column_index = email_index;
            DataGridViewButtonColumn email_button = new DataGridViewButtonColumn();
            email_button.Name = "Email";
            email_button.Text = "Email";
            email_button.UseColumnTextForButtonValue = true;
            if (dataGridView1.Columns["email_column"] == null)
            {
                dataGridView1.Columns.Insert(column_index, email_button);
            }

        }

        private void format()
        {

            //before changing the formatting - count the total value
            double total_cost = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
                total_cost = total_cost + Convert.ToDouble(row.Cells[price_index].Value);
            lblTotalCost.Text = total_cost.ToString("C");
            //get rid of these
            dataGridView1.Columns[view_index].Visible = false;
            dataGridView1.Columns[email_index].Visible = false;

            //headertext stuff
            dataGridView1.Columns[quote_id_index].HeaderText = "Quote ID";
            dataGridView1.Columns[issue_id_index].HeaderText = "Issue";
            dataGridView1.Columns[current_index].HeaderText = "Current";
            dataGridView1.Columns[priority_id_index].HeaderText = "Priority";
            dataGridView1.Columns[description_index].HeaderText = "Description";
            dataGridView1.Columns[material_index].HeaderText = "Material";
            dataGridView1.Columns[system_index].HeaderText = "System";
            dataGridView1.Columns[customer_index].HeaderText = "Customer";
            dataGridView1.Columns[email_sent_by_index].HeaderText = "Email Sent By";
            dataGridView1.Columns[email_sent_date_index].HeaderText = "Email Sent Date";
            dataGridView1.Columns[quotation_ref_index].HeaderText = "Quotation Ref";
            dataGridView1.Columns[price_index].HeaderText = "Price";
            dataGridView1.Columns[quote_date_index].HeaderText = "Quote Date";

            foreach (DataGridViewColumn col in dataGridView1.Columns)
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            //quote ref is far too big sometimes so we need to force this to be less -- same for sys
            dataGridView1.Columns[quotation_ref_index].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[quotation_ref_index].Width = 250;
            dataGridView1.Columns[system_index].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[system_index].Width = 250;

            //button sizes
            dataGridView1.Columns[view_button_index].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[email_button_index].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[view_button_index].Width = 100;
            dataGridView1.Columns[email_button_index].Width = 100;


            dataGridView1.Columns[price_index].DefaultCellStyle.Format = "c2";
            dataGridView1.Columns[price_index].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-GB");

            dataGridView1.Columns[quotation_ref_index].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void fillComboBox()
        {
            if (cmbMaterial.Items.Count > 0)
            { }
            else
            {
                //gets all the data from the tables
                using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                {
                    conn.Open();
                    string sql = "Select description FROM dbo.sl_status ";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                            cmbStatus.Items.Add(reader.GetString(0));
                        reader.Close();
                    }
                    sql = "Select material_description FROM dbo.sl_material ";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                            cmbMaterial.Items.Add(reader.GetString(0));
                        reader.Close();
                    }
                    sql = "SELECT system_name from dbo.slimline_systems ";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                            cmbSystem.Items.Add(reader.GetString(0));
                        reader.Close();
                    }
                    sql = "SELECT rtrim([NAME]) FROM [dsl_fitting].dbo.SALES_LEDGER where [NAME] is not null order by [NAME] ASC ";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                            cmbCustomer.Items.Add(reader.GetString(0));
                        reader.Close();
                    }
                    sql = "SELECT DISTINCT u_2.forename + ' ' + u_2.surname as email_sent_by FROM dbo.sl_quotation a left join[user_info].dbo.[user] u_2 on u_2.id = a.email_sent_by where u_2.forename is not null";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                            cmbQuotedBy.Items.Add(reader.GetString(0));
                        reader.Close();
                    }
                    conn.Close();
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            column_index_refresh();
            if (e.ColumnIndex == quote_id_index)
            {
                frmQuotation frm = new frmQuotation(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()));
                frm.ShowDialog();
            }  //opens quotation screen

            if (e.ColumnIndex == view_button_index)
            {
                string filePath = @"S:\SLIMLINE QUOTES\SL" + dataGridView1.Rows[e.RowIndex].Cells[quote_id_index].Value.ToString();

                if (Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[issue_id_index].Value.ToString()) > 1) //issue has some extra stuff
                    filePath = filePath + "I" + dataGridView1.Rows[e.RowIndex].Cells[issue_id_index].Value.ToString();

                filePath = filePath + ".rtf";

                //check if file exists 
                if (File.Exists(filePath))
                    Process.Start(filePath);
                else
                    MessageBox.Show("The quotation for " + dataGridView1.Rows[e.RowIndex].Cells[quote_id_index].Value.ToString() + " does not exist!", "Missing File", MessageBoxButtons.OK);
            }

        }

        private void txtQuoteID_TextChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void cmbPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void cmbMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void cmbSystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void cmbEmailSentBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void txtQuoteRef_TextChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void txtQuotedBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void dteStart_ValueChanged(object sender, EventArgs e)
        {
            dateFilter = -1;
            loadData();
        }

        private void dteEnd_ValueChanged(object sender, EventArgs e)
        {
            dateFilter = -1;
            loadData();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtQuoteID.Text = "";
            cmbStatus.Text = "";
            cmbMaterial.Text = "";
            cmbSystem.Text = "";
            cmbCustomer.Text = "";
            txtQuoteRef.Text = "";
            txtPrice.Text = "";
            cmbQuotedBy.Text = "";
            dteStart.Value = DateTime.Now;
            dteEnd.Value = DateTime.Now;
            dateFilter = 0;
            loadData();

        }

        private void btnEmail_Click(object sender, EventArgs e)
        {

            if (sql_where == " ")
            {
                MessageBox.Show("Please filter the grid before clicking [Email Report] - Currently there are too many records to email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dataGridView1.Rows.Count < 1)
            {
                MessageBox.Show("There is currently no data to email - Please filter the report to show records before attempting to email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //first we need to store the where statement
            //replace all the ' with something more friendly (gets reverted back on the access side)
            sql_where = sql_where.Replace("'", "replaceme");
            string sql = "UPDATE dbo.sl_sql SET sql = '" + sql_where + "' where id = 1";

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    cmd.ExecuteNonQuery();
                conn.Close();
            }

            string price_master_email = @"\\designsvr1\apps\Design and Supply MS ACCESS\Frontend\Price_Log_Program\price_master_report.accdb";
            Process.Start(price_master_email);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            frmSupplier frm = new frmSupplier();
            frm.ShowDialog();
        }

        private void btnMaterial_Click(object sender, EventArgs e)
        {
            frmMaterial frm = new frmMaterial();
            frm.ShowDialog();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            frmCustomerList frm = new frmCustomerList();
            frm.ShowDialog();
        }

        private void btnNewQuote_Click(object sender, EventArgs e)
        {
            //insert a new quote and then open it
            DialogResult result = MessageBox.Show("Are you sure you want to create a new quote number?", "New Quote", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                string sql = "SELECT max(quote_id) + 1 FROM dbo.sl_quotation";

                using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                {
                    conn.Open();
                    int max_id = 0;
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                        max_id = Convert.ToInt32(cmd.ExecuteScalar());


                    sql = "insert into dbo.sl_quotation (quote_id,issue_id,quote_date,highest_issue,created_by_id,status_id) VALUES (" + max_id.ToString() + ",1,getdate(),-1," + CONNECT.staffID.ToString() + ",8)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    frmQuotation frm = new frmQuotation(max_id);
                    frm.ShowDialog();
                    loadData();
                }
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
