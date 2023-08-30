using Microsoft.Office.Interop.Outlook;
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
using System.Windows.Controls;
using System.Windows.Forms;

namespace PriceMaster
{
    public partial class frmCalendar : Form
    {
        public frmCalendar()
        {
            InitializeComponent();

            fillCalendar();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MMMM yyyy";

        }

        private void fillCalendar()
        {

            DateTime selectedMonth = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, 1); //force it to be the first of the month

            DataTable dt = new DataTable();

            dt.Columns.Add("Mo", typeof(string));   //0
            dt.Columns.Add("Tu", typeof(string));   //1
            dt.Columns.Add("We", typeof(string));   //2
            dt.Columns.Add("Th", typeof(string));   //3
            dt.Columns.Add("Fr", typeof(string));   //4
            dt.Columns.Add("Sa", typeof(string));   //5
            dt.Columns.Add("Su", typeof(string));   //6

            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);//this will add the row at the end of the datatable

            //loop for each day in the selected month
            int total_days = DateTime.DaysInMonth(selectedMonth.Year, selectedMonth.Month);

            for (int i = 0; i < total_days; i++)
            {
                string day_name = selectedMonth.DayOfWeek.ToString();

                switch (day_name)
                {
                    case "Monday":
                        dt.Rows[dt.Rows.Count - 1][0] = selectedMonth.Day.ToString();
                        break;

                    case "Tuesday":
                        dt.Rows[dt.Rows.Count - 1][1] = selectedMonth.Day.ToString();
                        break;

                    case "Wednesday":
                        dt.Rows[dt.Rows.Count - 1][2] = selectedMonth.Day.ToString();
                        break;

                    case "Thursday":
                        dt.Rows[dt.Rows.Count - 1][3] = selectedMonth.Day.ToString();
                        break;

                    case "Friday":
                        dt.Rows[dt.Rows.Count - 1][4] = selectedMonth.Day.ToString();
                        break;

                    case "Saturday":
                        dt.Rows[dt.Rows.Count - 1][5] = selectedMonth.Day.ToString();
                        break;

                    case "Sunday":
                        dt.Rows[dt.Rows.Count - 1][6] = selectedMonth.Day.ToString();
                        break;

                }


                //if the current day is a sunday then we need to add a new row
                if (day_name == "Sunday")
                {
                    DataRow dr2 = dt.NewRow();
                    dt.Rows.Add(dr2);//this will add the row at the end of the datatable
                }


                selectedMonth = selectedMonth.AddDays(1);
            }



            dgvDate.DataSource = dt;

            format();
        }

        private void fillChases()
        {

            dataGridView1.DataSource = null;
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                foreach (DataGridViewRow row in dgvDate.Rows)
                {
                    foreach (DataGridViewColumn col in dgvDate.Columns)
                    {
                        if (string.IsNullOrEmpty(row.Cells[col.Index].Value.ToString()))
                            break;

                        DateTime selectedDate = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, Convert.ToInt32(row.Cells[col.Index].Value));

                        string sql = "SELECT a.id " +
                            "FROM [order_database].dbo.quotation_chase_log_slimline a " +
                            "left join [order_database].dbo.quotation_feed_back_slimline b on a.quote_id = b.quote_id " +
                            "left join[user_info].dbo.[user] u on a.chased_by = u.id " +
                            "left join (SELECT * FROM [price_master].dbo.[sl_quotation] where highest_issue = -1 ) sl on sl.quote_id = a.quote_id " +
                            "left join[EnquiryLog].dbo.[Enquiry_Log] e on sl.enquiry_id = e.id " +
                            "left join[dsl_fitting].dbo.SALES_LEDGER s on sl.customer_acc_ref = s.ACCOUNT_REF " +
                            "right join (select max(id) as id,quote_id FROM [order_database].dbo.quotation_chase_log_slimline group by quote_id) as z on z.id = a.id " +
                            "where next_chase_date  =  CAST('" + selectedDate.ToString("yyyyMMdd") + "' as date) and (dont_chase = 0 or dont_chase is null) AND " +
                            "(chase_complete = 0 or chase_complete is null) AND " +
                            "chased_by = " + CONNECT.staffID.ToString();


                        using  (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            var data = cmd.ExecuteScalar();

                            if (data != null)
                                row.Cells[col.Index].Style = new DataGridViewCellStyle { ForeColor = Color.Red };

                        }
                    }
                }
                conn.Close();
            }




            //.Style = new DataGridViewCellStyle { ForeColor = Color.Yellow };
        }

        private void format()
        {
            foreach (DataGridViewColumn col in dgvDate.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }



            dgvDate.Columns[5].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold); //Microsoft Sans Serif, 8.25pt
            dgvDate.Columns[6].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);


            DataGridViewElementStates states = DataGridViewElementStates.None;
            dgvDate.ScrollBars = ScrollBars.None;
            var totalHeight = dgvDate.Rows.GetRowsHeight(states) + dgvDate.ColumnHeadersHeight;
            // totalHeight += dgv.Rows.Count * 4  // a correction I need
            var totalWidth = dgvDate.Columns.GetColumnsWidth(states) + dgvDate.RowHeadersWidth;
            dgvDate.ClientSize = new Size(totalWidth - 38, totalHeight);


            if (CONNECT.staffID == 480) //dion wanted it to have a pink background
            {
                foreach (DataGridViewRow row in dgvDate.Rows)
                {
                    row.DefaultCellStyle.BackColor = Color.Plum;
                }
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.DefaultCellStyle.BackColor = Color.Plum;
                }
            }

            //foreach (DataGridViewColumn col in dgvDate.Columns)
            //{
            //    col.SortMode = DataGridViewColumnSortMode.NotSortable;
            //}

            //get the data (its here because it colours the cell text)
            fillChases();

            

        }

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            fillCalendar();
        }

        private void frmCalendar_Shown(object sender, EventArgs e)
        {
            format();
            dgvDate.ClearSelection();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            string current_month = dateTimePicker1.Value.ToString("MMMM");
            if (current_month == "January")
                dateTimePicker1.Value = new DateTime(dateTimePicker1.Value.AddYears(-1).Year, dateTimePicker1.Value.AddMonths(-1).Month, 1);
            else
                dateTimePicker1.Value = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.AddMonths(-1).Month, 1);
            fillCalendar();
            dgvDate.ClearSelection();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            string current_month = dateTimePicker1.Value.ToString("MMMM");
            if (current_month == "December")
                dateTimePicker1.Value = new DateTime(dateTimePicker1.Value.AddYears(1).Year, dateTimePicker1.Value.AddMonths(1).Month, 1);
            else
                dateTimePicker1.Value = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.AddMonths(1).Month, 1);
            fillCalendar();
            dgvDate.ClearSelection();
        }

        private void dgvDate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }

            if (string.IsNullOrEmpty(dgvDate.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                return;


            DateTime selectedDate = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, 
                            Convert.ToInt32(dgvDate.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));

            string sql = "SELECT a.id,a.quote_id,chase_date,chase_description " +
                            "FROM [order_database].dbo.quotation_chase_log_slimline a " +
                            "left join [order_database].dbo.quotation_feed_back_slimline b on a.quote_id = b.quote_id " +
                            "left join[user_info].dbo.[user] u on a.chased_by = u.id " +
                            "left join (SELECT * FROM [price_master].dbo.[sl_quotation] where highest_issue = -1 ) sl on sl.quote_id = a.quote_id " +
                            "left join[EnquiryLog].dbo.[Enquiry_Log] e on sl.enquiry_id = e.id " +
                            "left join[dsl_fitting].dbo.SALES_LEDGER s on sl.customer_acc_ref = s.ACCOUNT_REF " +
                            "right join (select max(id) as id,quote_id FROM [order_database].dbo.quotation_chase_log_slimline group by quote_id) as z on z.id = a.id " +
                            "where next_chase_date  =  CAST('" + selectedDate.ToString("yyyyMMdd") + "' as date) and (dont_chase = 0 or dont_chase is null) AND " +
                            "(chase_complete = 0 or chase_complete is null) AND " +
                            "chased_by = " + CONNECT.staffID.ToString() + " order by priority_chase desc,chase_date desc,rtrim(s.[NAME]), quote_id ";

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql,conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;

                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].HeaderText = "Quote ID";
                    dataGridView1.Columns[2].HeaderText = "Chase Date";
                    dataGridView1.Columns[3].HeaderText = "Description";

                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                conn.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }

            string customer = "";
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                string sql = "select  rtrim(b.[NAME]) from [price_master].dbo.sl_quotation a " +
                    "left join[dsl_fitting].dbo.[SALES_LEDGER] b on a.customer_acc_ref = b.ACCOUNT_REF where quote_id = " + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    customer = cmd.ExecuteScalar().ToString();

                conn.Close();
            }

            //frmSlimlineQuotation frm = new frmSlimlineQuotation(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[quote_index].Value.ToString()), customer);
            frmSlimlineChaseQuotation frm = new frmSlimlineChaseQuotation(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()), customer);
            frm.ShowDialog();

            fillCalendar();
        }
    }
}
