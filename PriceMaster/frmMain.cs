using System;
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
using Excel = Microsoft.Office.Interop.Excel;
using PriceMaster.TraditionalChasing;

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
        public int chase_button_index { get; set; }
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
        public int type_index { get; set; }
        public int chasing_status_index { get; set; }
        public int last_chased_date_index { get; set; }
        public int last_chased_by_index { get; set; }
        public int chase_priority_index { get; set; }

        //date stuffs
        public int dateFilter { get; set; }
        public int ChaseDateFilter { get; set; }
        public int isLewis { get; set; }
        public frmMain()
        {
            InitializeComponent();
            dateFilter = 0;
            loadData();
        }


        private void loadData()
        {
            string sql = "SELECT top 150 a.quote_id,q.status,last_chase.chase_date,last_chase.chased_by,'View' as [view_temp],'Email' as email_temp,issue_id,CASE WHEN highest_issue = 0 THEN CAST(0 AS BIT) WHEN highest_issue IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [current] ,p.priority_description as priority_id,st.description,m.material_description, " +
                                "COALESCE(slimline_systems_1.system_name, '') + ' - ' + COALESCE(slimline_systems_2.system_name, '') + ' - ' + COALESCE(slimline_systems_3.system_name, '') + ' - ' + " +
                                "COALESCE(slimline_systems_4.system_name, '') + ' - ' + COALESCE(slimline_systems_5.system_name, '') as [system_row] , rtrim(s.[NAME]) as customer,s.type,u_2.forename + ' ' + u_2.surname as  email_sent_by,email_sent_date,quotation_ref,COALESCE(price,0) as price," +
                                "u.forename + ' ' + u.surname as [quoted_by],quote_date,CASE WHEN is_lewis = 0 THEN CAST(0 AS BIT) WHEN is_lewis IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [with_lewis] ,last_chase.priority_chase FROM dbo.sl_quotation a " +
                                "LEFT merge JOIN[dsl_fitting].dbo.[SALES_LEDGER] s on s.ACCOUNT_REF = a.customer_acc_ref " +
                                "left merge join[user_info].dbo.[user] u on u.id = a.created_by_id " +
                                "left merge join[user_info].dbo.[user] u_2 on u_2.id = a.email_sent_by " +
                                "left merge join dbo.sl_status st on st.id = a.status_id " +
                                "left merge join dbo.sl_material m on m.id = a.material_type_id " +
                                "left merge join dbo.sl_priority p on p.id = a.priority_id " +
                                "left merge join [order_database].dbo.quotation_feed_back_slimline q on a.quote_id = q.quote_id " +
                                "LEFT merge JOIN dbo.slimline_systems as slimline_systems_1 ON a.system_id_1 = slimline_systems_1.id " +
                                "LEFT merge JOIN dbo.slimline_systems AS slimline_systems_2 ON a.system_id_2 = slimline_systems_2.id " +
                                "LEFT merge JOIN dbo.slimline_systems AS slimline_systems_3 ON a.system_id_3 = slimline_systems_3.id " +
                                "LEFT merge JOIN dbo.slimline_systems AS slimline_systems_4 ON a.system_id_4 = slimline_systems_4.id " +
                                "LEFT merge JOIN dbo.slimline_systems AS slimline_systems_5 ON a.system_id_5 = slimline_systems_5.id " +
                                "left merge join (SELECT a.quote_id,chase_date,u.forename + ' ' + u.surname as chased_by,c.priority_chase from [order_database].dbo.quotation_chase_log_slimline a " +
                                "right merge join(select max(id) as id,quote_id from[order_database].dbo.quotation_chase_log_slimline " +
                                " " +
                                "group by quote_id) b on a.quote_id = b.quote_id AND a.id = b.id left join[user_info].dbo.[user] u on a.chased_by = u.id " +
                                " left merge join [order_database].dbo.quotation_feed_back_slimline c on a.quote_id = c.quote_id  ) as last_chase on a.quote_id = last_chase.quote_id ";


            sql = sql + " WHERE highest_issue = -1 ";

            if (txtQuoteID.Text.Length > 0)
                sql = sql + " AND a.quote_id like '%" + txtQuoteID.Text + "%' ";

            if (cmbChasingStatus.Text.Length > 0)
                sql = sql + " AND q.status LIKE '%" + cmbChasingStatus.Text + "%'";


            if (cmbMaterial.Text.Length > 0)
                sql = sql + " AND m.material_description = '" + cmbMaterial.Text + "'";
            if (cmbSystem.Text.Length > 0)
                sql = sql + " AND (slimline_systems_1.system_name LIKE '%" + cmbSystem.Text + "%' or slimline_systems_2.system_name LIKE '%" + cmbSystem.Text + "%' or slimline_systems_3.system_name LIKE '%" + cmbSystem.Text + "%' or slimline_systems_4.system_name LIKE '%" + cmbSystem.Text + "%' )";
            if (cmbCustomer.Text.Length > 0)
                sql = sql + " AND s.[NAME] LIKE '%" + cmbCustomer.Text.Replace("'", "") + "%'";

            if (txtQuoteRef.Text.Length > 0)
                sql = sql + " AND quotation_ref LIKE '%" + txtQuoteRef.Text + "%'";
            if (txtPrice.Text.Length > 0)
                sql = sql + " AND price >= " + txtPrice.Text + " ";
            if (cmbQuotedBy.Text.Length > 0)
                sql = sql + " AND u.forename + ' ' + u.surname LIKE '%" + cmbQuotedBy.Text + "%'";

            if (cmbType.Text.Length > 0)
                sql = sql + " AND s.type = '" + cmbType.Text + "'";

            if (dateFilter == -1)
                sql = sql + " AND quote_date >= '" + dteStart.Value.ToString("yyyyMMdd") + "' AND quote_date <= '" + dteEnd.Value.ToString("yyyyMMdd") + "' ";

            if (ChaseDateFilter == -1)
                sql = sql + " AND last_chase.chase_date >= '" + dteChaseStart.Value.ToString("yyyyMMdd") + "' AND last_chase.chase_date <= '" + dteChaseEnd.Value.ToString("yyyyMMdd") + "' ";

            if (cmbChasedBy.Text.Length > 0)
                sql = sql + " AND last_chase.chased_by = '" + cmbChasedBy.Text + "' ";

            if (chkChasePriority.Checked == true)
                sql = sql + " AND last_chase.priority_chase = -1 ";

            sql_where = sql.Substring(sql.LastIndexOf("-1") + 2);


            //  AND quote_date >= '20220701 00:00' AND quote_date <= '20220731' ORDER BY quote_id DESC, issue_id";

            sql = sql + " order by quote_id DESC, issue_id";
            //sql = sql.Replace("'", "");

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

            if (dataGridView1.Columns.Contains("Chase") == true)
                chase_button_index = dataGridView1.Columns["Chase"].Index;

            chasing_status_index = dataGridView1.Columns["status"].Index;
            last_chased_date_index = dataGridView1.Columns["chase_date"].Index;
            last_chased_by_index = dataGridView1.Columns["chased_by"].Index;

            isLewis = dataGridView1.Columns["with_lewis"].Index;

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
            type_index = dataGridView1.Columns["type"].Index;
            chase_priority_index = dataGridView1.Columns["priority_chase"].Index;


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

            column_index = email_button_index + 1;
            DataGridViewButtonColumn chase_button = new DataGridViewButtonColumn();
            chase_button.Name = "Chase";
            chase_button.Text = "Chase";
            chase_button.UseColumnTextForButtonValue = true;
            if (dataGridView1.Columns["Chase"] == null)
            {
                dataGridView1.Columns.Insert(column_index, chase_button);
            }

        }

        private void format()
        {

            //before changing the formatting - count the total value
            double total_cost = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                total_cost = total_cost + Convert.ToDouble(row.Cells[price_index].Value);
                //also copy the status if the chase is null
                if (row.Cells[chasing_status_index].Value.ToString() == "")
                    row.Cells[chasing_status_index].Value = row.Cells[description_index].Value;
                if (row.Cells[chase_priority_index].Value.ToString() == "-1")
                    row.DefaultCellStyle.BackColor = Color.Goldenrod;

                if (row.Cells[chasing_status_index].Value.ToString() == "Won")
                    row.DefaultCellStyle.BackColor = Color.LightSeaGreen;

                if (row.Cells[chasing_status_index].Value.ToString() == "Lost")
                    row.DefaultCellStyle.BackColor = Color.PaleVioletRed;


                // MessageBox.Show(row.Cells[chasing_status_index].Value.ToString());

            }
            lblTotalCost.Text = total_cost.ToString("C");
            //get rid of these
            dataGridView1.Columns[view_index].Visible = false;
            dataGridView1.Columns[email_index].Visible = false;
            dataGridView1.Columns[description_index].Visible = false;
            dataGridView1.Columns[chase_priority_index].Visible = false;

            //headertext stuff
            dataGridView1.Columns[quote_id_index].HeaderText = "Quote ID";
            dataGridView1.Columns[chasing_status_index].HeaderText = "Chasing Status";
            dataGridView1.Columns[last_chased_date_index].HeaderText = "Last Chase Date";
            dataGridView1.Columns[last_chased_by_index].HeaderText = "Last Chased By";
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
            dataGridView1.Columns[quoted_by_index].HeaderText = "Quoted By";
            dataGridView1.Columns[quote_date_index].HeaderText = "Quote Date";
            dataGridView1.Columns[type_index].HeaderText = "Type";
            dataGridView1.Columns[isLewis].HeaderText = "With Lewis";

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

            foreach (DataGridViewColumn col in dataGridView1.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;

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
                    //string sql = "Select description FROM dbo.sl_status ";
                    //using (SqlCommand cmd = new SqlCommand(sql, conn))
                    //{
                    //    SqlDataReader reader = cmd.ExecuteReader();
                    //    while (reader.Read())
                    //        cmbStatus.Items.Add(reader.GetString(0));
                    //    reader.Close();
                    //}
                    string sql = "Select material_description FROM dbo.sl_material ";
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
                    sql = "SELECT DISTINCT u_2.forename + ' ' + u_2.surname as email_sent_by FROM dbo.sl_quotation a left join[user_info].dbo.[user] u_2 on u_2.id = a.created_by_id where u_2.forename is not null";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                            cmbQuotedBy.Items.Add(reader.GetString(0));
                        reader.Close();
                    }
                    sql = "SELECT distinct u.forename + ' ' + u.surname as chased_by from [order_database].dbo.quotation_chase_log_slimline a " +
                             "left join[user_info].dbo.[user] u on a.chased_by = u.id order by chased_by asc";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                            cmbChasedBy.Items.Add(reader.GetString(0));
                        reader.Close();
                    }
                    conn.Close();
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex == -1)
                return;
            string sql = "";
            column_index_refresh();
            ////if (e.ColumnIndex == quote_id_index)
            ////{
            ////    frmQuotation frm = new frmQuotation(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()));
            ////    frm.ShowDialog();
            ////}  //opens quotation screen

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
            else if (e.ColumnIndex == chase_button_index)
            {

                //if there is no entry in quotation_feed_back then make one
                sql = "select cast(quote_id as nvarchar(max)) FROM [order_database].dbo.quotation_feed_back_slimline WHERE quote_id = " + dataGridView1.Rows[e.RowIndex].Cells[quote_id_index].Value.ToString();
                using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        string data = (string)cmd.ExecuteScalar();
                        if (data == null)
                        {
                            sql = "INSERT INTO [order_database].dbo.quotation_feed_back_slimline (quote_id) VALUES (" + dataGridView1.Rows[e.RowIndex].Cells[quote_id_index].Value.ToString() + ")";
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    conn.Close();
                }

                //frmSlimlineQuotation frm = new frmSlimlineQuotation(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[quote_id_index].Value.ToString()), dataGridView1.Rows[e.RowIndex].Cells[customer_index].Value.ToString());
                frmSlimlineChaseQuotation frm = new frmSlimlineChaseQuotation(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[quote_id_index].Value.ToString()), dataGridView1.Rows[e.RowIndex].Cells[customer_index].Value.ToString());
                frm.ShowDialog();
                loadData();
            }
            else
            {
                //if (e.ColumnIndex == quote_id_index)
                //{
                frmQuotation frm = new frmQuotation(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[quote_id_index].Value.ToString()));
                frm.ShowDialog();
                //}
            }
        }

        private void txtQuoteID_TextChanged(object sender, EventArgs e)
        {
            //            loadData();
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

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

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
            cmbMaterial.Text = "";
            cmbSystem.Text = "";
            cmbCustomer.Text = "";
            txtQuoteRef.Text = "";
            txtPrice.Text = "";
            cmbQuotedBy.Text = "";
            cmbChasingStatus.Text = "";
            cmbType.Text = "";
            cmbChasedBy.Text = "";
            dteStart.Value = DateTime.Now;
            dteEnd.Value = DateTime.Now;
            dteChaseStart.Value = DateTime.Now;
            dteChaseEnd.Value = DateTime.Now;
            dateFilter = 0;
            ChaseDateFilter = 0;
            loadData();

        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            string temp = "";
            string sql = "select top 150 a.quote_id,rtrim(s.[NAME]) as customer,a.quotation_ref,a.customer_contact,s.TELEPHONE,enquiry_id,e.sender_email_address,e.priority as [priority_class],q.status,last_chase.chase_date,last_chase.chased_by,chase_description as [lase_chase_note], '                                                           ' as notes " +
                ",COALESCE(price,0) as price from dbo.sl_quotation a " +
                "left join [dsl_fitting].dbo.SALES_LEDGER s on a.customer_acc_ref = s.ACCOUNT_REF " +
                "left join[EnquiryLog].dbo.[Enquiry_Log] e on e.id = a.enquiry_id " +
                "left join[user_info].dbo.[user] u on u.id = a.created_by_id " +
                //"LEFT JOIN[dsl_fitting].dbo.[SALES_LEDGER] s on s.ACCOUNT_REF = a.customer_acc_ref " +
                "left join[user_info].dbo.[user] u_2 on u_2.id = a.email_sent_by " +
                "left join dbo.sl_status st on st.id = a.status_id " +
                "left join dbo.sl_material m on m.id = a.material_type_id " +
                "left join dbo.sl_priority p on p.id = a.priority_id " +
                "LEFT JOIN dbo.slimline_systems as slimline_systems_1 ON a.system_id_1 = slimline_systems_1.id " +
                "LEFT JOIN dbo.slimline_systems AS slimline_systems_2 ON a.system_id_2 = slimline_systems_2.id " +
                "LEFT JOIN dbo.slimline_systems AS slimline_systems_3 ON a.system_id_3 = slimline_systems_3.id " +
                "LEFT JOIN dbo.slimline_systems AS slimline_systems_4 ON a.system_id_4 = slimline_systems_4.id " +
                "LEFT JOIN dbo.slimline_systems AS slimline_systems_5 ON a.system_id_5 = slimline_systems_5.id " +
                "left join [order_database].dbo.quotation_feed_back_slimline q on a.quote_id = q.quote_id " +
                "left join (SELECT a.quote_id,chase_description,chase_date,u.forename + ' ' + u.surname as chased_by from [order_database].dbo.quotation_chase_log_slimline a " +
                "right join(select max(id) as id,quote_id from[order_database].dbo.quotation_chase_log_slimline " +
                "group by quote_id) b on a.quote_id = b.quote_id AND a.id = b.id left join[user_info].dbo.[user] u on a.chased_by = u.id ) as last_chase on a.quote_id = last_chase.quote_id " +
                "WHERE highest_issue = -1 ";




            //"SELECT top 150 a.quote_id,q.status,'View' as [view_temp],'Email' as email_temp,issue_id,CASE WHEN highest_issue = 0 THEN CAST(0 AS BIT) WHEN highest_issue IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [current] ,p.priority_description as priority_id,st.description,m.material_description, " +
            //"COALESCE(slimline_systems_1.system_name, '') + ' - ' + COALESCE(slimline_systems_2.system_name, '') + ' - ' + COALESCE(slimline_systems_3.system_name, '') + ' - ' + " +
            //"COALESCE(slimline_systems_4.system_name, '') + ' - ' + COALESCE(slimline_systems_5.system_name, '') as [system_row] , rtrim(s.[NAME]) as customer,s.type,u_2.forename + ' ' + u_2.surname as  email_sent_by,email_sent_date,quotation_ref,COALESCE(price,0) as price," +
            //"u.forename + ' ' + u.surname as [quoted_by],quote_date FROM dbo.sl_quotation a " +
            //"LEFT JOIN[dsl_fitting].dbo.[SALES_LEDGER] s on s.ACCOUNT_REF = a.customer_acc_ref " +
            //"left join[user_info].dbo.[user] u on u.id = a.created_by_id " +
            //"left join[user_info].dbo.[user] u_2 on u_2.id = a.email_sent_by " +
            //"left join dbo.sl_status st on st.id = a.status_id " +
            //"left join dbo.sl_material m on m.id = a.material_type_id " +
            //"left join dbo.sl_priority p on p.id = a.priority_id " +
            //"left join [order_database].dbo.quotation_feed_back_slimline q on a.quote_id = q.quote_id " +
            //"LEFT JOIN dbo.slimline_systems as slimline_systems_1 ON a.system_id_1 = slimline_systems_1.id " +
            //"LEFT JOIN dbo.slimline_systems AS slimline_systems_2 ON a.system_id_2 = slimline_systems_2.id " +
            //"LEFT JOIN dbo.slimline_systems AS slimline_systems_3 ON a.system_id_3 = slimline_systems_3.id " +
            //"LEFT JOIN dbo.slimline_systems AS slimline_systems_4 ON a.system_id_4 = slimline_systems_4.id " +
            //"LEFT JOIN dbo.slimline_systems AS slimline_systems_5 ON a.system_id_5 = slimline_systems_5.id ";




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

            sql = sql + sql_where;

            //get it into a datatable
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
                        if (row[6].ToString().Contains("EXCHANGELABS/OU=EXCHANGE"))
                        {
                            //remove all the clutter
                            string temp_string = row[6].ToString();
                            row[6] = temp_string.Substring(temp_string.IndexOf("-") + 1);
                        }
                    }

                    //dataGridView1.DataSource = dt;
                    //open the excel doc here and start inserting 
                    // Store the Excel processes before opening.
                    Process[] processesBefore = Process.GetProcessesByName("excel");
                    // Open the file in Excel.

                    System.IO.Directory.CreateDirectory(@"C:\temp");

                    temp = @"\\designsvr1\apps\Design and Supply CSharp\price_log_template.xlsx";
                    System.IO.File.Copy(temp, @"C:\temp\price_log.xlsx", true);

                    temp = @"C:\temp\price_log.xlsx";

                    var xlApp = new Excel.Application();
                    var xlWorkbooks = xlApp.Workbooks;
                    var xlWorkbook = xlWorkbooks.Open(temp);
                    var xlWorksheet = xlWorkbook.Sheets[1]; // assume it is the first sheet
                                                            // Get Excel processes after opening the file.
                    Process[] processesAfter = Process.GetProcessesByName("excel");

                    int excel_row = 2;
                    foreach (DataRow row in dt.Rows)
                    {
                        xlWorksheet.Cells[1][excel_row].Value2 = row[0].ToString();
                        xlWorksheet.Cells[2][excel_row].Value2 = row[1].ToString();
                        xlWorksheet.Cells[3][excel_row].Value2 = row[2].ToString();
                        xlWorksheet.Cells[4][excel_row].Value2 = row[3].ToString();
                        xlWorksheet.Cells[5][excel_row].Value2 = row[4].ToString();
                        xlWorksheet.Cells[6][excel_row].Value2 = row[5].ToString();
                        xlWorksheet.Cells[7][excel_row].Value2 = row[6].ToString();
                        xlWorksheet.Cells[8][excel_row].Value2 = row[7].ToString();
                        xlWorksheet.Cells[9][excel_row].Value2 = row[8].ToString();
                        xlWorksheet.Cells[10][excel_row].Value2 = row[9].ToString();
                        xlWorksheet.Cells[11][excel_row].Value2 = row[10].ToString();
                        xlWorksheet.Cells[12][excel_row].Value2 = row[11].ToString();
                        xlWorksheet.Cells[13][excel_row].Value2 = row[12].ToString();
                        xlWorksheet.Cells[14][excel_row].Value2 = row[13].ToString();
                        excel_row++;
                    }

                    //border them all
                    Excel.Range xlRange = xlWorksheet.UsedRange;
                    xlRange.Cells.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                    //autosize 
                    xlWorksheet.Columns.AutoFit();

                    //print it
                    //xlWorksheet.PrintOut(Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                    xlWorkbook.Close(true); //close the excel sheet without saving
                                            // xlApp.Quit();


                    // Manual disposal because of COM
                    xlApp.Quit();

                    // Now find the process id that was created, and store it.
                    int processID = 0;
                    foreach (Process process in processesAfter)
                    {
                        if (!processesBefore.Select(p => p.Id).Contains(process.Id))
                        {
                            processID = process.Id;
                        }
                    }
                    // And now kill the process.
                    if (processID != 0)
                    {
                        Process process = Process.GetProcessById(processID);
                        process.Kill();
                    }

                }
                conn.Close();
            }

            Process.Start(temp);

            //vvv old code for access report
            ////if (sql_where == " ")
            ////{
            ////    MessageBox.Show("Please filter the grid before clicking [Email Report] - Currently there are too many records to email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            ////    return;
            ////}
            ////if (dataGridView1.Rows.Count < 1)
            ////{
            ////    MessageBox.Show("There is currently no data to email - Please filter the report to show records before attempting to email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            ////    return;
            ////}
            //////first we need to store the where statement
            //////replace all the ' with something more friendly (gets reverted back on the access side)
            ////sql_where = sql_where.Replace("'", "replaceme");
            ////string sql = "UPDATE dbo.sl_sql SET sql = '" + sql_where + "' where id = 1";

            ////using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            ////{
            ////    conn.Open();
            ////    using (SqlCommand cmd = new SqlCommand(sql, conn))
            ////        cmd.ExecuteNonQuery();
            ////    conn.Close();
            ////}

            ////string price_master_email = @"\\designsvr1\apps\Design and Supply MS ACCESS\Frontend\Price_Log_Program\price_master_report.accdb";
            ////Process.Start(price_master_email);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            column_index_refresh();
            format();
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


                    sql = "insert into dbo.sl_quotation (quote_id,issue_id," + /*quote_date,*/  "highest_issue,created_by_id,status_id) VALUES (" + max_id.ToString() + ",1," + /*getdate(),*/  "-1," + CONNECT.staffID.ToString() + ",8)";
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

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnTraditional_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmTraditional frm = new frmTraditional();
            frm.ShowDialog();
            this.Show();


        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            //check if there is any outstanding chases ----
            //string sql = "SELECT CAST(quote_id as nvarchar(max)) FROM [order_database].dbo.quotation_chase_log_slimline where next_chase_date <= CAST(GETDATE() as date) and " +
            //    "dont_chase = 0 and(chase_followed_up is null or chase_followed_up = 0) AND chased_by =  " + CONNECT.staffID.ToString();

            string sql = "SELECT CAST(a.quote_id as nvarchar(max)) " +
                                "FROM [order_database].dbo.quotation_chase_log_slimline a " +
                                "left join [order_database].dbo.quotation_feed_back_slimline b on a.quote_id = b.quote_id " +
                                "left join [user_info].dbo.[user] u on a.chased_by = u.id " +
                                "right join (select max(id) as id,quote_id FROM [order_database].dbo.quotation_chase_log_slimline group by quote_id) as z on z.id = a.id " +
                                "where next_chase_date <= CAST(GETDATE() as date) and b.[status] = 'Chasing' and (dont_chase = 0 or dont_chase is null) and (chase_complete = 0 or chase_complete is null) and u.id = " + CONNECT.staffID;

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    string temp = (string)cmd.ExecuteScalar();
                    if (temp != null)
                    {
                        DialogResult result = MessageBox.Show("You have current outstanding chases, would you like to view them?", "Outstanding Chases", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (result == DialogResult.Yes)
                        {
                            frmSlimlineOutstandingChase frm = new frmSlimlineOutstandingChase(0);
                            frm.ShowDialog();
                        }
                    }
                }

                //also check outstanding correspondence
                sql = "SELECT cast(id as nvarchar(max)) FROM [order_database].dbo.quotation_chase_customer " +
                      "where no_follow_up = 0 AND (complete = 0 or complete is null) AND " +
                      "slimline = -1 AND correspondence_by = " + CONNECT.staffID.ToString() + " AND next_correspondence_date <= CAST(GETDATE()  as date)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    string temp = (string)(cmd.ExecuteScalar());
                    if (temp != null)
                    {
                        DialogResult result = MessageBox.Show("You have current outstanding correspondences, would you like to view them?", "Outstanding correspondences", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (result == DialogResult.Yes)
                        {
                            frmOutstandingCustomerCorrespondence frm = new frmOutstandingCustomerCorrespondence(-1);
                            frm.ShowDialog();
                        }
                    }
                }
                conn.Close();
            }
            column_index_refresh();
            format();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            frmSlimlineOutstandingChase frm = new frmSlimlineOutstandingChase(-1);
            frm.ShowDialog();
        }

        private void btnOutstanding_Click(object sender, EventArgs e)
        {
            frmSlimlineOutstandingChase frm = new frmSlimlineOutstandingChase(0);
            frm.ShowDialog();
        }

        private void cmbChasingStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void dteChaseStart_ValueChanged(object sender, EventArgs e)
        {
            ChaseDateFilter = -1;
            loadData();
        }

        private void dteChaseEnd_ValueChanged(object sender, EventArgs e)
        {
            ChaseDateFilter = -1;
            loadData();
        }

        private void cmbChasedBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnManagementView_Click(object sender, EventArgs e)
        {
            frmManagementView frm = new frmManagementView(-1);
            frm.ShowDialog();
        }

        private void chkChasePriority_CheckedChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void txtQuoteID_Leave(object sender, EventArgs e)
        {
            loadData();
        }

        private void txtQuoteID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loadData();
            }
        }

        private void txtQuoteRef_Leave(object sender, EventArgs e)
        {
            loadData();
        }

        private void txtQuoteRef_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loadData();
            }
        }

        private void txtPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loadData();
            }
        }

        private void txtPrice_Leave(object sender, EventArgs e)
        {
            loadData();
        }

        private void buttonFormatting1_Click(object sender, EventArgs e)
        {
            frmChaseCustomerList frm = new frmChaseCustomerList(-1, "");
            frm.ShowDialog();
        }

        private void btnAlert_Click(object sender, EventArgs e)
        {
            frmManagementAlert frm = new frmManagementAlert(-1);
            frm.ShowDialog();
        }

        private void buttonFormatting2_Click(object sender, EventArgs e)
        {
            frmOutstandingCustomerCorrespondence frm = new frmOutstandingCustomerCorrespondence(-1);
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnCalendar_Click(object sender, EventArgs e)
        {
            frmCalendar frm = new frmCalendar();
            frm.ShowDialog();
        }

        private void btnNonReturningCustomers_Click(object sender, EventArgs e)
        {
            frmNonReturningCustomers frm = new frmNonReturningCustomers(-1);
            frm.ShowDialog();
        }

        private void btnTurnoverDecline_Click(object sender, EventArgs e)
        {
            frmTurnOverDecline frm = new frmTurnOverDecline(-1);
            frm.ShowDialog();
        }

        private void btnNonReturningEnquiries_Click(object sender, EventArgs e)
        {
            frmLastCustomerEnquiry frm = new frmLastCustomerEnquiry(-1);
            frm.ShowDialog();
        }

        private void btnNewCustomers_Click(object sender, EventArgs e)
        {
            frmNewCustomersTraditional frm = new frmNewCustomersTraditional(0);
            frm.ShowDialog();
        }

        private void btnLeads_Click(object sender, EventArgs e)
        {
            frmLeadList frm = new frmLeadList();
            frm.ShowDialog();
        }

        private void btnryucxd_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            frmMultipleChase frm = new frmMultipleChase(87266, "STRONGDOR LIMITED", dt, "aaa", -1, -1, -1, "", "", -1);
            frm.ShowDialog();

        }
    }
}
