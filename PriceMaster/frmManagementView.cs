﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms.VisualStyles;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Drawing.Printing;

namespace PriceMaster
{
    public partial class frmManagementView : Form
    {
        //chase datagrid
        public int slimline { get; set; }
        public int chase_id_index { get; set; }
        public int quote_index { get; set; }
        public int chase_date_index { get; set; }
        public int chase_description_index { get; set; }
        public int next_chase_date_index { get; set; }
        public int chased_by_index { get; set; }
        public int button_index { get; set; }
        public int customer_index { get; set; }
        public int sender_email_address_index { get; set; }
        public int priority_chase_index { get; set; }
        public int date_filter { get; set; }
        public int chase_complete_index { get; set; }
        public int chase_status_index { get; set; }
        public int staff_index { get; set; }

        //correspondence datagrid
        public int correspondence_id_index { get; set; }
        public int customer_name_index { get; set; }
        public int slimline_index { get; set; }
        public int date_created_index { get; set; }
        public int body_index { get; set; }
        public int next_correspondence_index { get; set; }
        public int email_index { get; set; }
        public int phone_index { get; set; }
        public int in_person_index { get; set; }
        public int contact_index { get; set; }
        public int issue_with_leadtime_index { get; set; }
        public int issue_with_quote_turnaround_time_index { get; set; }
        public int issue_with_product_index { get; set; }
        public int issue_with_installation_index { get; set; }
        public int issue_with_service_index { get; set; }
        public int correspondence_by_index { get; set; }
        public int complete_index { get; set; }
        public frmManagementView(int _slimline)
        {
            InitializeComponent();
            slimline = _slimline;
            if (slimline == 0)
                chkboxSlimline.Checked = false;
            else
                chkboxSlimline.Checked = true;

            dteStart.Value = dteEnd.Value.AddDays(-30);
            date_filter = -1;

            load_data();
            load_correspondence();
            fillCombo();



            //dteEnd.Value = DateTime.Now.AddDays(1);
        }

        private void format()
        {
            dgvChase.Columns[chase_id_index].Visible = false;
            dgvChase.Columns[quote_index].HeaderText = "Quote ID";
            dgvChase.Columns[chase_date_index].HeaderText = "Chase Date";
            dgvChase.Columns[chase_description_index].HeaderText = "Chase Description";
            dgvChase.Columns[next_chase_date_index].HeaderText = "Next Chase Date";
            dgvChase.Columns[customer_index].HeaderText = "Customer";
            dgvChase.Columns[sender_email_address_index].Visible = false; //.HeaderText = "Sender Email Address";
            dgvChase.Columns[chase_status_index].HeaderText = "Chase Status";
            dgvChase.Columns[priority_chase_index].Visible = false;
            dgvChase.Columns[chase_complete_index].Visible = false;

            foreach (DataGridViewRow row in dgvChase.Rows)
            {
                if (row.Cells[sender_email_address_index].Value.ToString().Contains("EXCHANGELABS/OU=EXCHANGE"))
                {
                    //remove all the clutter
                    string temp = row.Cells[sender_email_address_index].Value.ToString();
                    row.Cells[sender_email_address_index].Value = temp.Substring(temp.IndexOf("-") + 1);
                }
                if (row.Cells[priority_chase_index].Value.ToString() == "-1")
                    row.DefaultCellStyle.BackColor = Color.LightSkyBlue;
                //if (row.Cells[chase_complete_index].Value.ToString() == "-1")
                //    row.DefaultCellStyle.BackColor = Color.DarkGray;
            }

            dgvChase.Columns[chased_by_index].HeaderText = "Chased by";

            foreach (DataGridViewColumn col in dgvChase.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgvChase.Columns[chase_description_index].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void fillCombo()
        {
            string sql = "";
            cmbCustomerSearch.Items.Clear();
            cmbStaffSearch.Items.Clear();
            //fill combobox with ALL data instead of whats showing
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                if (slimline == -1)
                    sql = "SELECT distinct rtrim(s.[NAME]) as [customer] " +
                        "FROM[order_database].dbo.quotation_chase_log_slimline a " +
                        "left join (SELECT * FROM[price_master].dbo.[sl_quotation] where highest_issue = -1)  sl on sl.quote_id = a.quote_id " +
                        "left join[EnquiryLog].dbo.[Enquiry_Log] e on sl.enquiry_id = e.id left join[dsl_fitting].dbo.SALES_LEDGER s on sl.customer_acc_ref = s.ACCOUNT_REF";
                else
                    sql = "SELECT distinct rtrim(q.customer) as customer " +
                        "FROM[order_database].dbo.quotation_chase_log a " +
                        "left join[order_database].dbo.view_solidworks_max_rev q on a.quote_id = q.quote_id";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        cmbCustomerSearch.Items.Add(dr[0]);
                    }
                    dr.Close();
                }


                if (slimline == -1)
                    sql = "SELECT distinct u.forename + ' ' + u.surname as chased_by FROM [order_database].dbo.quotation_chase_log_slimline a " +
                        "left join[user_info].dbo.[user] u on a.chased_by = u.id ";
                else
                    sql = "SELECT distinct u.forename + ' ' + u.surname as chased_by FROM [order_database].dbo.quotation_chase_log a " +
                        "left join[user_info].dbo.[user] u on a.chased_by = u.id ";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader dr2 = cmd.ExecuteReader();
                    while (dr2.Read())
                    {
                        cmbStaffSearch.Items.Add(dr2[0]);
                    }
                }


                conn.Close();
            }

            //cmbCustomerSearch.Items.Clear();
            //foreach (DataGridViewRow row in dgvChase.Rows)
            //{
            //    if (cmbCustomerSearch.Items.Contains(row.Cells[customer_index].Value.ToString()))
            //    { } //nothing
            //    else
            //        cmbCustomerSearch.Items.Add(row.Cells[customer_index].Value.ToString());
            //}


            foreach (DataGridViewRow row in dgvCorrespondence.Rows)
            {
                if (cmbCustomerSearch.Items.Contains(row.Cells[customer_name_index].Value.ToString()))
                { } //nothing
                else
                    cmbCustomerSearch.Items.Add(row.Cells[customer_name_index].Value.ToString());
            }

            //cmbStaffSearch.Items.Clear();
            //foreach (DataGridViewRow row in dgvChase.Rows)
            //{
            //    if (cmbStaffSearch.Items.Contains(row.Cells[chased_by_index].Value.ToString()))
            //    { } //nothing
            //    else
            //        cmbStaffSearch.Items.Add(row.Cells[chased_by_index].Value.ToString());
            //}
            foreach (DataGridViewRow row in dgvCorrespondence.Rows)
            {
                if (cmbStaffSearch.Items.Contains(row.Cells[correspondence_by_index].Value.ToString()))
                { } //nothing
                else
                    cmbStaffSearch.Items.Add(row.Cells[correspondence_by_index].Value.ToString());
            }

        }

        private void load_data()
        {

            if (chkboxSlimline.Checked == true)
                slimline = -1;
            else
                slimline = 0;

            dgvChase.DataSource = null;
            string sql = "";
            string sqlCount = "";


            if (slimline == -1)
            {
                sql = "SELECT a.id,a.quote_id,b.[status],chase_date,chase_description,next_chase_date,u.forename + ' ' + u.surname as chased_by,rtrim(s.[NAME]) as [customer] ,e.sender_email_address,priority_chase " +
                    ",chase_complete FROM [order_database].dbo.quotation_chase_log_slimline a " +
                    "left join [order_database].dbo.quotation_feed_back_slimline b on a.quote_id = b.quote_id " +
                    "left join[user_info].dbo.[user] u on a.chased_by = u.id " +
                    "left join (SELECT * FROM [price_master].dbo.[sl_quotation] where highest_issue = -1 )  sl on sl.quote_id = a.quote_id " +
                    "left join[EnquiryLog].dbo.[Enquiry_Log] e on sl.enquiry_id = e.id " +
                    "left join[dsl_fitting].dbo.SALES_LEDGER s on sl.customer_acc_ref = s.ACCOUNT_REF " +
                    //"right join (select max(id) as id,quote_id FROM [order_database].dbo.quotation_chase_log_slimline group by quote_id) as z on z.id = a.id " +
                    "where  ";

                sqlCount = "SELECT count(distinct s.[NAME])  " +
                    "FROM [order_database].dbo.quotation_chase_log_slimline a " +
                    "left join [order_database].dbo.quotation_feed_back_slimline b on a.quote_id = b.quote_id " +
                    "left join[user_info].dbo.[user] u on a.chased_by = u.id " +
                    "left join (SELECT * FROM [price_master].dbo.[sl_quotation] where highest_issue = -1 )  sl on sl.quote_id = a.quote_id " +
                    "left join[EnquiryLog].dbo.[Enquiry_Log] e on sl.enquiry_id = e.id " +
                    "left join[dsl_fitting].dbo.SALES_LEDGER s on sl.customer_acc_ref = s.ACCOUNT_REF " +
                    //"right join (select max(id) as id,quote_id FROM [order_database].dbo.quotation_chase_log_slimline group by quote_id) as z on z.id = a.id " +
                    "where  ";

                if (chkFuture.Checked == true)
                {
                    sql = sql + " next_chase_date > ";
                    sqlCount = sqlCount + " next_chase_date > ";
                }
                else
                {
                    sql = sql + " cast(chase_date as date) <= ";
                    sqlCount = sqlCount + " cast(chase_date as date) <= ";
                }

                sql = sql + " CAST(GETDATE() as date)   "; // and (dont_chase = 0 or dont_chase is null) and b.[status] = 'Chasing'
                sqlCount = sqlCount + " CAST(GETDATE() as date)   ";

                if (string.IsNullOrEmpty(cmbChaseStatus.Text) == false)
                {
                    sql = sql + " and b.[status] = '" + cmbChaseStatus.Text + "'    ";
                    sqlCount = sqlCount + " and b.[status] = '" + cmbChaseStatus.Text + "'    ";
                }

                if (string.IsNullOrEmpty(cmbCustomerSearch.Text) == false)
                {
                    sql = sql + " AND rtrim(s.NAME) = '" + cmbCustomerSearch.Text + "'  ";
                    sqlCount = sqlCount + " AND rtrim(s.NAME) = '" + cmbCustomerSearch.Text + "'  ";
                }
                if (string.IsNullOrEmpty(cmbStaffSearch.Text) == false)
                {
                    sql = sql + " AND u.forename + ' ' + u.surname = '" + cmbStaffSearch.Text + "'  ";
                    sqlCount = sqlCount + " AND u.forename + ' ' + u.surname = '" + cmbStaffSearch.Text + "'  ";
                }


                if (chkAllChases.Checked == true)
                {
                    sql = sql + "";//"and  (chase_complete = -1)  ";   -- no filter
                }
                else
                {
                    sql = sql + "and  (chase_complete = 0 or chase_complete is null)  ";
                    sqlCount = sqlCount + "and  (chase_complete = 0 or chase_complete is null)  ";
                }

                if (date_filter == -1)
                {
                    if (chkFuture.Checked == true)
                    {
                        sql = sql + "and next_chase_date >= '" + dteStart.Value.ToString("yyyyMMdd") + "' AND next_chase_date  <= [order_database].dbo.func_work_days_plus('" + dteEnd.Value.ToString("yyyyMMdd") + "',1)";
                        sqlCount = sqlCount + "and next_chase_date >= '" + dteStart.Value.ToString("yyyyMMdd") + "' AND next_chase_date  <= [order_database].dbo.func_work_days_plus('" + dteEnd.Value.ToString("yyyyMMdd") + "',1)";
                    }
                    else
                    {
                        sql = sql + "and chase_date >= '" + dteStart.Value.ToString("yyyyMMdd") + "' AND chase_date  <= [order_database].dbo.func_work_days_plus('" + dteEnd.Value.ToString("yyyyMMdd") + "',1)";
                        sqlCount = sqlCount + "and chase_date >= '" + dteStart.Value.ToString("yyyyMMdd") + "' AND chase_date  <= [order_database].dbo.func_work_days_plus('" + dteEnd.Value.ToString("yyyyMMdd") + "',1)";
                    }

                }


                //if (chkAllChases.Checked == true)
                //    sql = sql + " order by quote_id desc,chase_date desc";
                //else
                sql = sql + " order by chase_date desc,rtrim(s.[NAME]), quote_id ";

            }
            else
            {
                sql = "SELECT TOP 500 a.id,a.quote_id,b.[status],chase_date,chase_description,next_chase_date,u.forename + ' ' + u.surname as chased_by," +
                    "rtrim(q.customer) as customer,'e.' as sender_email_address,priority_chase,chase_complete FROM[order_database].dbo.quotation_chase_log a " +
                    "left merge join[order_database].dbo.quotation_feed_back b on a.quote_id = b.quote_id " +
                    "left merge join[user_info].dbo.[user] u on a.chased_by = u.id " +
                    ////"left join(select quote_id, max(revision_number) as revision_number from[order_database].dbo.solidworks_quotation_log group by quote_id) sw on a.quote_id = sw.quote_id " +
                    ////"left join[order_database].dbo.solidworks_quotation_log q on sw.quote_id = q.quote_id and sw.revision_number = q.revision_number " +
                    "left merge join [order_database].dbo.view_solidworks_max_rev q on a.quote_id = q.quote_id " +
                    //"left join(select max(id) as enquiry_id, left(related_quote, CHARINDEX('-', related_quote) - 1) as related_quote from[EnquiryLog].dbo.[Enquiry_Log] " +
                    //"WHERE related_quote<> 'No Related Quote' group by LEFT(related_quote, CHARINDEX('-', related_quote) - 1)) el on el.related_quote like '%' + cast(q.quote_id as nvarchar) + '%' " +
                    //"left merge join (SELECT top 500 * FROM [EnquiryLog].dbo.[Enquiry_Log]) e on el.enquiry_id = e.id " +
                    "where  ";
                
                sqlCount = "SELECT count (distinct q.customer) " +
                    "FROM[order_database].dbo.quotation_chase_log a " +
                    "left merge join[order_database].dbo.quotation_feed_back b on a.quote_id = b.quote_id " +
                    "left merge join[user_info].dbo.[user] u on a.chased_by = u.id " +
                    ////"left join(select quote_id, max(revision_number) as revision_number from[order_database].dbo.solidworks_quotation_log group by quote_id) sw on a.quote_id = sw.quote_id " +
                    ////"left join[order_database].dbo.solidworks_quotation_log q on sw.quote_id = q.quote_id and sw.revision_number = q.revision_number " +
                    "left merge join [order_database].dbo.view_solidworks_max_rev q on a.quote_id = q.quote_id " +
                    //"left join(select max(id) as enquiry_id, left(related_quote, CHARINDEX('-', related_quote) - 1) as related_quote from [EnquiryLog].dbo.[Enquiry_Log] " +
                    //"WHERE related_quote<> 'No Related Quote' group by LEFT(related_quote, CHARINDEX('-', related_quote) - 1)) el on el.related_quote like '%' + cast(q.quote_id as nvarchar) + '%' " +
                    //"left merge join (SELECT top 500 * FROM [EnquiryLog].dbo.[Enquiry_Log]) e on el.enquiry_id = e.id  " +
                    "where  ";

                if (chkFuture.Checked == true)
                {
                    sql = sql + "next_chase_date > ";
                    sqlCount = sqlCount + "next_chase_date > ";
                }
                else
                {
                    sql = sql + "cast(chase_date as date) <= ";
                    sqlCount = sqlCount + "cast(chase_date as date) <= ";
                }

                sql = sql + " CAST(GETDATE() as date)    ";//and (dont_chase = 0 or dont_chase is null) and b.[status] = 'Chasing'
                sqlCount = sqlCount + " CAST(GETDATE() as date)    ";//and (dont_chase = 0 or dont_chase is null) and b.[status] = 'Chasing'

                if (string.IsNullOrEmpty(cmbChaseStatus.Text) == false)
                {
                    sql = sql + " and b.[status] = '" + cmbChaseStatus.Text + "'    ";
                    sqlCount = sqlCount + " and b.[status] = '" + cmbChaseStatus.Text + "'    ";
                }



                if (string.IsNullOrEmpty(cmbCustomerSearch.Text) == false)
                {
                    sql = sql + " AND replace(rtrim(q.customer),'''','') = '" + cmbCustomerSearch.Text.Replace("'","") + "'  ";
                    sqlCount = sqlCount + " AND replace(rtrim(q.customer),'''','') = '" + cmbCustomerSearch.Text.Replace("'", "") + "'  ";
                }
                if (string.IsNullOrEmpty(cmbStaffSearch.Text) == false)
                {
                    sql = sql + " AND u.forename + ' ' + u.surname = '" + cmbStaffSearch.Text + "'  ";
                    sqlCount = sqlCount + " AND u.forename + ' ' + u.surname = '" + cmbStaffSearch.Text + "'  ";
                }

                if (chkAllChases.Checked == true)
                {
                    sql = sql + "";//"and  (chase_complete = -1)  ";   -- no filter
                }
                else
                {
                    sql = sql + "and  (chase_complete = 0 or chase_complete is null)  ";
                    sqlCount = sqlCount + "and  (chase_complete = 0 or chase_complete is null)  ";
                }

                if (date_filter == -1)
                {
                    if (chkFuture.Checked == true)
                    {
                        sql = sql + "and next_chase_date >= '" + dteStart.Value.ToString("yyyyMMdd") + "' AND next_chase_date  <= [order_database].dbo.func_work_days_plus('" + dteEnd.Value.ToString("yyyyMMdd") + "',1)";
                        sqlCount = sqlCount + "and next_chase_date >= '" + dteStart.Value.ToString("yyyyMMdd") + "' AND next_chase_date  <= [order_database].dbo.func_work_days_plus('" + dteEnd.Value.ToString("yyyyMMdd") + "',1)";

                    }
                    else
                    {
                        sql = sql + "and chase_date >= '" + dteStart.Value.ToString("yyyyMMdd") + "' AND chase_date  <= [order_database].dbo.func_work_days_plus('" + dteEnd.Value.ToString("yyyyMMdd") + "',1)";
                        sqlCount = sqlCount + "and chase_date >= '" + dteStart.Value.ToString("yyyyMMdd") + "' AND chase_date  <= [order_database].dbo.func_work_days_plus('" + dteEnd.Value.ToString("yyyyMMdd") + "',1)";

                    }

                }


                //if (chkAllChases.Checked == true)
                //    sql = sql + " order by quote_id desc,chase_date desc";
                //else
                sql = sql + " order by chase_date desc, quote_id ";

            }


            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    System.Data.DataTable dt = new System.Data.DataTable();
                    da.Fill(dt);
                    dgvChase.DataSource = dt;
                }

                using (SqlCommand cmd = new SqlCommand(sqlCount, conn))
                {
                    lblChaseCount.Text = "Unique Customers Chased: " + cmd.ExecuteScalar().ToString() ?? "0";
                }


                conn.Close();
            }
            column_index();
            add_button();
            column_index();
            format();
            column_index();

        }

        private void load_correspondence()
        {

            string sql = "";

            //load the correspondence 
            sql = "select q.id,rtrim(customer_name) as customer_name,u.forename + ' ' + u.surname as fullname,q.slimline,date_created,body," +
                "CASE WHEN no_follow_up = 0 then convert(varchar(10),next_correspondence_date , 103)  else 'No follow Up'end as next_correspondence," +
                "CASE WHEN q.email = 0 THEN CAST(0 AS BIT) WHEN q.email IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Email] ," +
                "CASE WHEN phone = 0 THEN CAST(0 AS BIT) WHEN phone IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Phone] ," +
                "CASE WHEN inPerson = 0 THEN CAST(0 AS BIT) WHEN inPerson IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [inPerson] ," +
                "contact," +
                "CASE WHEN issue_with_leadtime = 0 THEN CAST(0 AS BIT) WHEN issue_with_leadtime IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Issue with leadtime] ," +
                "CASE WHEN issue_with_quote_turnaround_time = 0 THEN CAST(0 AS BIT) WHEN issue_with_quote_turnaround_time IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Issue with quote turnaround time] ," +
                "CASE WHEN issue_with_product = 0 THEN CAST(0 AS BIT) WHEN issue_with_product IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Issue with product]," +
                "CASE WHEN issue_with_installation = 0 THEN CAST(0 AS BIT) WHEN issue_with_installation IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Issue with installation] ," +
                "CASE WHEN issue_with_service = 0 THEN CAST(0 AS BIT) WHEN issue_with_service IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Issue with service] , " +
                "CASE WHEN complete = 0 THEN CAST(0 AS BIT) WHEN complete IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Complete] " +
                "from [order_database].dbo.quotation_chase_customer q " +
                "left join [user_info].dbo.[user] u on q.correspondence_by = u.id " +
                "where q.slimline = ";

            string sqlCount = "select count(distinct customer_name) " +
                "from [order_database].dbo.quotation_chase_customer q " +
                "left join [user_info].dbo.[user] u on q.correspondence_by = u.id " +
                "where q.slimline = ";

            if (slimline == -1)
            {
                sql = sql + "-1 ";
                sqlCount = sqlCount + "-1 ";
            }
            else
            {
                sql = sql + "0 ";
                sqlCount = sqlCount + "0 ";
            }

            if (string.IsNullOrWhiteSpace(cmbCustomerSearch.Text) == false)
            {
                sql = sql + " AND REPLACE(customer_name,'''','') = '" + cmbCustomerSearch.Text.Replace("'","") + "' ";
                sqlCount = sqlCount + " AND REPLACE(customer_name,'''','') = '" + cmbCustomerSearch.Text.Replace("'", "") + "' ";
            }

            if (string.IsNullOrWhiteSpace(cmbStaffSearch.Text) == false)
            {
                sql = sql + " AND u.forename + ' ' + u.surname = '" + cmbStaffSearch.Text + "' ";
                sqlCount = sqlCount + " AND u.forename + ' ' + u.surname = '" + cmbStaffSearch.Text + "' ";
            }


            if (date_filter == -1)
            {
                sql = sql + "AND date_created >= '" + dteStart.Value.ToString("yyyyMMdd") + "' AND date_created  <= [order_database].dbo.func_work_days_plus('" + dteEnd.Value.ToString("yyyyMMdd") + "',1) ";
                sqlCount = sqlCount + "AND date_created >= '" + dteStart.Value.ToString("yyyyMMdd") + "' AND date_created  <= [order_database].dbo.func_work_days_plus('" + dteEnd.Value.ToString("yyyyMMdd") + "',1) ";
            }


            sql = sql + " order by date_created desc";

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvCorrespondence.DataSource = dt;
                }

                using (SqlCommand cmd = new SqlCommand(sqlCount, conn))
                {
                    lblCorrespondenceCount.Text = "Unique Correspondence Customers: " + cmd.ExecuteScalar().ToString() ?? "0";
                }

                    conn.Close();
            }
            column_index_correspondence();
            format_correspondence();
        }

        private void format_correspondence()
        {
            //correspondence formatting
            dgvCorrespondence.Columns[correspondence_id_index].HeaderText = "ID";
            dgvCorrespondence.Columns[customer_name_index].HeaderText = "Customer Name";
            dgvCorrespondence.Columns[slimline_index].HeaderText = "Slimline";
            dgvCorrespondence.Columns[date_created_index].HeaderText = "Date Created";
            dgvCorrespondence.Columns[body_index].HeaderText = "Body";
            dgvCorrespondence.Columns[next_correspondence_index].HeaderText = "Next Correspondence";
            dgvCorrespondence.Columns[email_index].HeaderText = "Email";
            dgvCorrespondence.Columns[phone_index].HeaderText = "Phone";
            dgvCorrespondence.Columns[in_person_index].HeaderText = "In-Person";
            dgvCorrespondence.Columns[contact_index].HeaderText = "Contact";
            dgvCorrespondence.Columns[correspondence_by_index].HeaderText = "Correspondence By";

            dgvCorrespondence.Columns[correspondence_id_index].Visible = false;
            dgvCorrespondence.Columns[slimline_index].Visible = false;

            foreach (DataGridViewColumn col in dgvCorrespondence.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgvCorrespondence.Columns[body_index].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void column_index_correspondence()
        {
            chase_id_index = dgvCorrespondence.Columns["id"].Index;
            customer_name_index = dgvCorrespondence.Columns["customer_name"].Index;
            slimline_index = dgvCorrespondence.Columns["slimline"].Index;
            date_created_index = dgvCorrespondence.Columns["date_created"].Index;
            body_index = dgvCorrespondence.Columns["body"].Index;
            next_correspondence_index = dgvCorrespondence.Columns["next_correspondence"].Index;
            email_index = dgvCorrespondence.Columns["email"].Index;
            phone_index = dgvCorrespondence.Columns["phone"].Index;
            in_person_index = dgvCorrespondence.Columns["inPerson"].Index;
            contact_index = dgvCorrespondence.Columns["contact"].Index;
            correspondence_by_index = dgvCorrespondence.Columns["fullName"].Index;

            issue_with_leadtime_index = dgvCorrespondence.Columns["Issue with leadtime"].Index;
            issue_with_quote_turnaround_time_index = dgvCorrespondence.Columns["Issue with quote turnaround time"].Index;
            issue_with_product_index = dgvCorrespondence.Columns["Issue with product"].Index;
            issue_with_installation_index = dgvCorrespondence.Columns["Issue with installation"].Index;
            issue_with_service_index = dgvCorrespondence.Columns["Issue with service"].Index;

            complete_index = dgvCorrespondence.Columns["Complete"].Index;
        }
        private void add_button()
        {
            //if (dataGridView1.Columns.Contains("Complete") == true)
            //    dataGridView1.Columns.Remove("Complete");

            //column_index();
            //DataGridViewButtonColumn view_button = new DataGridViewButtonColumn();
            //view_button.Name = "Complete";
            //view_button.Text = "Mark Complete";
            //view_button.UseColumnTextForButtonValue = true;
            //if (dataGridView1.Columns["Complete"] == null)
            //{
            //    dataGridView1.Columns.Insert(next_chase_date_index + 1, view_button);
            //}

        }

        private void column_index()
        {
            chase_id_index = dgvChase.Columns["id"].Index;
            quote_index = dgvChase.Columns["quote_id"].Index;
            chase_date_index = dgvChase.Columns["chase_date"].Index;
            chase_description_index = dgvChase.Columns["chase_description"].Index;
            next_chase_date_index = dgvChase.Columns["next_chase_date"].Index;
            chased_by_index = dgvChase.Columns["chased_by"].Index;
            customer_index = dgvChase.Columns["customer"].Index;
            sender_email_address_index = dgvChase.Columns["sender_email_address"].Index;
            priority_chase_index = dgvChase.Columns["priority_chase"].Index;
            chase_complete_index = dgvChase.Columns["chase_complete"].Index;
            chase_status_index = dgvChase.Columns["status"].Index;

            if (dgvChase.Columns.Contains("Complete") == true)
                button_index = dgvChase.Columns["Complete"].Index;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            column_index();


            //get the customer
            string customer = "";
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                string sql = "";
                if (slimline == -1)//no idea what this does tbh
                {
                    sql = "select  rtrim(b.[NAME]) from [price_master].dbo.sl_quotation a " +
                        "left join[dsl_fitting].dbo.[SALES_LEDGER] b on a.customer_acc_ref = b.ACCOUNT_REF where quote_id = " + dgvChase.Rows[e.RowIndex].Cells[quote_index].Value.ToString();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                        customer = cmd.ExecuteScalar().ToString();
                }
                else
                {

                }


                conn.Close();
            }

            // dataGridView1.ClearSelection();
            frmManagementViewHistory frm = new frmManagementViewHistory(Convert.ToInt32(dgvChase.Rows[e.RowIndex].Cells[quote_index].Value.ToString()), slimline, dgvChase.Rows[e.RowIndex].Cells[customer_index].Value.ToString());
            frm.ShowDialog();
            //apply_filter();
            //}
            //    catch { }
            //}
        }

        private void cmbCustomerSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_data();
            load_correspondence();
        }

        private void chkFuture_CheckedChanged(object sender, EventArgs e)
        {
            cmbCustomerSearch.Text = "";
            cmbStaffSearch.Text = "";

            load_data();
            load_correspondence();
            fillCombo();
        }

        private void frmSlimlineOutstandingChase_Shown(object sender, EventArgs e)
        {
            btnShowAll.PerformClick();
            format();
        }

        private void cmbStaffSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_data();
            load_correspondence();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // chkFuture.Checked = false;
            cmbStaffSearch.Text = "";
            cmbCustomerSearch.Text = "";
            cmbChaseStatus.Text = "";
            date_filter = 0;
            dteStart.Value = dteEnd.Value.AddDays(-30);
            date_filter = -1;
            load_data();
            load_correspondence();
            fillCombo();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string search_dates = "";
            if (date_filter == -1)
                search_dates = "- From: " + dteStart.Value.ToString("dd/MM/yyyy") + " to: " + dteEnd.Value.ToString("dd/MM/yyyy");


            Process[] processesBefore = Process.GetProcessesByName("excel");

            //
            int customer_index = 0;
            customer_index = dgvChase.Columns["Customer"].Index;

            string FileName = @"C:\temp\Management_chase_list" + DateTime.Now.ToString("mmss") + ".xls";


            //adjust the chase description
            foreach (DataGridViewRow row in dgvChase.Rows)
            {
                //string temp =  row.Cells[3].Value.ToString();
                row.Cells[chase_description_index].Value = row.Cells[chase_description_index].Value.ToString().Replace("\n", " ").Replace("\r", " - ");
            }

            foreach (DataGridViewRow row in dgvCorrespondence.Rows)
            {
                //string temp =  row.Cells[3].Value.ToString();
                row.Cells[body_index].Value = row.Cells[body_index].Value.ToString().Replace("\n", " ").Replace("\r", " - ");
            }

            object misValue = System.Reflection.Missing.Value;
            Microsoft.Office.Interop.Excel.Application xlexcel = new Microsoft.Office.Interop.Excel.Application();

            xlexcel.DisplayAlerts = false; // Without this you will get two confirm overwrite prompts
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook = xlexcel.Workbooks.Add(misValue);

            Process[] processesAfter = Process.GetProcessesByName("excel");

            int chasing_added = 2;
            if (dgvChase.Rows.Count > 0)
            {
                //if there are rows in chaseing

                // Copy DataGridView results to clipboard
                dgvChase.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
                dgvChase.SelectAll();

                //delete all of the first row


                DataObject dataObj = dgvChase.GetClipboardContent();
                if (dataObj != null)
                    Clipboard.SetDataObject(dataObj);


                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                xlWorkSheet.Name = "Chases";

                // Get Excel processes after opening the file. 



                // Paste clipboard results to worksheet range
                Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[3, 1];
                CR.Select();
                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

                //delete the first row
                ((Excel.Range)xlWorkSheet.Rows[1, Missing.Value]).Delete(Excel.XlDeleteShiftDirection.xlShiftUp);



                xlWorkSheet.get_Range("A3").Select();

                Microsoft.Office.Interop.Excel.Worksheet ws = xlexcel.ActiveWorkbook.Worksheets[1];
                Microsoft.Office.Interop.Excel.Range range = ws.UsedRange;



                //ws.Columns.AutoFit();
                //ws.Rows.AutoFit();


                xlWorkSheet.Cells[1, 1].Value = "Total Chases: " + dgvChase.Rows.Count.ToString() + " / " + lblChaseCount.Text + " " + search_dates;
                xlWorkSheet.Range["A1:H1"].Cells.Font.Size = 20;
                xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[1, 8]].Merge();
                //Make all top/left align
                xlWorkSheet.get_Range("A2", "H1000").Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignGeneral;
                xlWorkSheet.get_Range("A2", "H1000").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                //change the entire top row to center align (AND BOTH DATE COLUMNS)
                xlWorkSheet.get_Range("A1", "H2").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                //xlWorkSheet.Columns[2].Style.HorizontalAlignment = HorizontalAlignment.Center;
                //xlWorkSheet.Columns[4].Style.HorizontalAlignment = HorizontalAlignment.Center;


                xlWorkSheet.Range["A2:H2"].Interior.Color = System.Drawing.Color.LightSkyBlue;
                xlWorkSheet.Range["A2:H2"].AutoFilter(1);
                xlWorkSheet.Range["A2:H2"].Cells.Font.Size = 12;

                ws.Columns.AutoFit();
                ws.Rows.AutoFit();

                //adjust the description conversation to fit and look nicer
                xlWorkSheet.Columns[4].ColumnWidth = 100;
                xlWorkSheet.Columns[4].WrapText = true;

                range.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                range.Borders.Color = ColorTranslator.ToOle(Color.Black);

                var chase_pagesetup = xlWorkSheet.PageSetup;
                chase_pagesetup.FitToPagesWide = 1;
                chase_pagesetup.FitToPagesTall = false;
                chase_pagesetup.Zoom = false;
                chase_pagesetup.Orientation = Excel.XlPageOrientation.xlLandscape;
            }
            else
                chasing_added = 1;
            // ADD THE CORRESPONDENCE TO TAB 2 HERE
            //IF THERE ARE ROWS
            if (dgvCorrespondence.Rows.Count > 0)
            {



                dgvCorrespondence.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
                dgvCorrespondence.SelectAll();

                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.Add
                    (System.Reflection.Missing.Value, xlWorkBook.Worksheets[xlWorkBook.Worksheets.Count],
                    System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                xlWorkSheet.Name = "Correspondence";

                DataObject dataObj = dgvCorrespondence.GetClipboardContent();
                if (dataObj != null)
                    Clipboard.SetDataObject(dataObj);

                // Paste clipboard results to worksheet range
                Microsoft.Office.Interop.Excel.Range CR2 = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[3, 1];
                CR2.Select();
                xlWorkSheet.PasteSpecial(CR2, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

                //delete the first row
                //((Excel.Range)xlWorkSheet.Rows[1, Missing.Value]).Delete(Excel.XlDeleteShiftDirection.xlShiftUp);

                xlWorkSheet.Range["A3:N3"].Interior.Color = System.Drawing.Color.LightSkyBlue;
                xlWorkSheet.Range["A3:N3"].AutoFilter(1);
                xlWorkSheet.Range["A3:N3"].Cells.Font.Size = 11;




                xlWorkSheet.Cells[1, 1].Value = "Total Correspondence: " + dgvCorrespondence.Rows.Count.ToString() + " / " + lblCorrespondenceCount.Text + " " + search_dates;
                xlWorkSheet.Range["A1:N1"].Cells.Font.Size = 20;
                xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[1, 14]].Merge();

                //issue with header
                xlWorkSheet.Cells[2, 10].Value = "Issue With";
                xlWorkSheet.Range["J2"].Cells.Font.Size = 12;
                xlWorkSheet.Range[xlWorkSheet.Cells[2, 1], xlWorkSheet.Cells[2, 9]].Merge();
                xlWorkSheet.Range[xlWorkSheet.Cells[2, 10], xlWorkSheet.Cells[2, 14]].Merge();

                //change all of the headers that have [Issue with] in them
                xlWorkSheet.Cells[3, 5].Value = "Follow Up";
                xlWorkSheet.Cells[3, 10].Value = "Leadtime";
                xlWorkSheet.Cells[3, 11].Value = "Quote Turnaround";
                xlWorkSheet.Cells[3, 12].Value = "Product";
                xlWorkSheet.Cells[3, 13].Value = "Installation";
                xlWorkSheet.Cells[3, 14].Value = "Service";

                Microsoft.Office.Interop.Excel.Worksheet ws = xlexcel.ActiveWorkbook.Worksheets[chasing_added];
                Microsoft.Office.Interop.Excel.Range range = ws.UsedRange;

                ws.Columns.AutoFit();
                ws.Rows.AutoFit();

                //adjust the description conversation to fit and look nicer
                xlWorkSheet.Columns[4].ColumnWidth = 70;
                xlWorkSheet.Columns[4].WrapText = true;

                xlWorkSheet.Columns[1].ColumnWidth = 20;
                xlWorkSheet.Columns[1].WrapText = true;

                ws = xlexcel.ActiveWorkbook.Worksheets[2];
                range = ws.UsedRange;
                //Make all top/left align
                ws.Rows.Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignGeneral;
                ws.Rows.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                //change the entire top row to center align (AND BOTH DATE COLUMNS)
                xlWorkSheet.get_Range("A1", "J3").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                xlWorkSheet.get_Range("F4", "N3000").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;



                ws.Columns.AutoFit();
                ws.Rows.AutoFit();

                range.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                range.Borders.Color = ColorTranslator.ToOle(Color.Black);

                var correspondence_pagesetup = xlWorkSheet.PageSetup;
                correspondence_pagesetup.FitToPagesWide = 1;
                correspondence_pagesetup.FitToPagesTall = false;
                correspondence_pagesetup.Zoom = false;
                correspondence_pagesetup.Orientation = Excel.XlPageOrientation.xlLandscape;


            }//END OF CORRESPONDENCE


            if (chasing_added == 1)
            {
                try
                {
                    xlWorkBook.Sheets[1].Delete();
                }
                catch { }
            }

            xlWorkBook.Sheets[1].Select();





            // Save the excel file under the captured location from the SaveFileDialog
            xlWorkBook.SaveAs(FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlexcel.DisplayAlerts = true;
            xlWorkBook.Close(true, misValue, misValue);
            xlexcel.Quit();

            //releaseObject(xlWorkSheet);
            //releaseObject(xlWorkBook);
            //releaseObject(xlexcel);

            // Clear Clipboard and DataGridView selection
            Clipboard.Clear();
            dgvChase.ClearSelection();
            dgvCorrespondence.ClearSelection();

            // Open the newly saved excel file
            if (File.Exists(FileName))
                System.Diagnostics.Process.Start(FileName);

            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks workbooks;
            Microsoft.Office.Interop.Excel.Workbook excelBook;

            //app = null;
            //app = new Excel.Application(); // create a new instance
            excelApp.DisplayAlerts = false; //turn off annoying alerts that make me want to cryyyy

            workbooks = excelApp.Workbooks;
            excelBook = workbooks.Add(FileName);
            Microsoft.Office.Interop.Excel.Sheets sheets = excelBook.Worksheets;
            Microsoft.Office.Interop.Excel.Worksheet excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)(sheets[1]);

            //Range.Rows.AutoFit();
            //Range.Columns.AutoFit();

            excelApp.Quit();
            // Now find the process id that was created, and store it. 
            int processID = 0;
            foreach (Process process in processesAfter)
            {
                if (!processesBefore.Select(p => p.Id).Contains(process.Id))
                {
                    processID = process.Id;
                    // And now kill the process. 
                    if (processID != 0)
                    {
                        Process process2 = Process.GetProcessById(processID);
                        process2.Kill();
                    }
                }
            }
        }

        private void buttonFormatting1_Click(object sender, EventArgs e)
        {
            print_sheet();
        }

        private void print_sheet()
        {
            string file_name = @"C:\temp\temp" + DateTime.Now.ToString("mmss") + ".jpg";
            try
            {
                Image bit = new Bitmap(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);

                Graphics gs = Graphics.FromImage(bit);

                gs.CopyFromScreen(new Point(0, 0), new Point(0, 0), bit.Size);

                //bit.Save(@"C:\temp\temp.jpg");


                Rectangle bounds = this.Bounds;
                using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
                    }
                    bitmap.Save(file_name);
                }


                //var frm = Form.ActiveForm;
                //using (var bmp = new Bitmap(frm.Width, frm.Height))
                //{
                //    frm.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                //    bmp.Save(@"C:\temp\temp.jpg");
                //}

                PrintDocument pd = new PrintDocument();
                pd.PrintPage += (sender, args) =>
                {
                    Image i = Image.FromFile(file_name);
                    Rectangle m = args.MarginBounds;
                    if ((double)i.Width / (double)i.Height > (double)m.Width / (double)m.Height) // image is wider
                    {
                        m.Height = (int)((double)i.Height / (double)i.Width * (double)m.Width);
                    }
                    else
                    {
                        m.Width = (int)((double)i.Width / (double)i.Height * (double)m.Height);
                    }
                    args.Graphics.DrawImage(i, m);
                };

                pd.DefaultPageSettings.Landscape = true;
                //Margins margins = new Margins(50, 50, 50, 50);
                //pd.DefaultPageSettings.Margins = margins;
                pd.Print();
            }
            catch
            { }
        }

        private void chkCompleted_CheckedChanged(object sender, EventArgs e)
        {
            cmbCustomerSearch.Text = "";
            cmbStaffSearch.Text = "";

            if (chkAllChases.Checked == true)
                btnShowAll.Text = "Show Only Latest";
            else
                btnShowAll.Text = "Show All";


            load_data();
            load_correspondence();
            fillCombo();
        }

        private void dteStart_CloseUp(object sender, EventArgs e)
        {
            date_filter = -1;
            load_data();
            load_correspondence();
        }

        private void dteEnd_CloseUp(object sender, EventArgs e)
        {
            date_filter = -1;
            load_data();
            load_correspondence();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            if (chkAllChases.Checked == true)
            {
                chkAllChases.Checked = false;
                btnShowAll.Size = new System.Drawing.Size(82, 30);

            }
            else
            {
                chkAllChases.Checked = true;
                btnShowAll.Size = new System.Drawing.Size(145, 30);
            }
        }

        private void cmbChaseStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_correspondence();
        }

        private void chkboxSlimline_CheckedChanged(object sender, EventArgs e)
        {
            cmbStaffSearch.Text = "";
            cmbCustomerSearch.Text = "";
            cmbChaseStatus.Text = "";
            date_filter = 0;

            if (chkboxSlimline.Checked == true)
                slimline = -1;
            else
                slimline = 0;
            load_data();
            load_correspondence();
            fillCombo();
        }

        private void dgvCorrespondence_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCorrespondence_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            frmChaseCorrespondenceView frm = new frmChaseCorrespondenceView(Convert.ToInt32(dgvCorrespondence.Rows[e.RowIndex].Cells[correspondence_id_index].Value.ToString()), slimline, -1);
            frm.ShowDialog();
        }

        private void btnLiveChart_Click(object sender, EventArgs e)
        {
            frmUniqueCustomerChaseCount frm = new frmUniqueCustomerChaseCount();
            frm.ShowDialog();
        }

        private void btnWeekly_Click(object sender, EventArgs e)
        {
            frmSectorManagementView frm = new frmSectorManagementView();
            frm.ShowDialog();
        }

        private void btnCorrespondenceExport_Click(object sender, EventArgs e)
        {

            frmCorrespondenceExport frm = new frmCorrespondenceExport();
            frm.ShowDialog();

        }

        private void btnLeads_Click(object sender, EventArgs e)
        {
            frmLeadReport frm = new frmLeadReport();
            frm.ShowDialog();
        }
    }
}
