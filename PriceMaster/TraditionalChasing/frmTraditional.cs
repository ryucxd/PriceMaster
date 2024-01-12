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
using System.Globalization;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;
using PriceMaster.TraditionalChasing;

namespace PriceMaster
{
    public partial class frmTraditional : Form
    {
        public int quote_index { get; set; }
        public int date_output_index { get; set; }
        public int rev_number_index { get; set; }
        public int item_count_index { get; set; }
        public int customer_index { get; set; }
        public int customer_reference_index { get; set; }
        public int quoted_by_index { get; set; }
        public int delivery_address_index { get; set; }
        public int value_index { get; set; }
        public int dateFilter { get; set; }
        public int quote_button_index { get; set; }
        public int status_index { get; set; }
        public string sql_report { get; set; }
        public int prioritY_chase_index { get; set; }
        public int enquiry_id_index { get; set; }
        public int reason_for_loss_index { get; set; }

        public frmTraditional()
        {
            InitializeComponent();
            apply_filter();
            fillCombo();



        }

        private void apply_filter()
        {
            string sql = "select top 300 s.quote_id,date_output,s.revision_number,item_count,customer,customer_ref,emailed_to as quoted_by,deliveryAddress,total_quotation_value,coalesce(q.status,'') as status,priority_chase," +
                "STUFF((CASE WHEN q.too_expensive = -1 then ', Too Expensive' ELSE '' end + " +
                "CASE WHEN q.lead_time_too_long = -1 then ', Lead time too long' ELSE '' end + " +
                "CASE WHEN q.quote_took_too_long = -1 then ', Quote took too long' ELSE '' end + " +
                "CASE WHEN q.unable_to_meet_spec = -1 then ', Unable to meet spec' ELSE '' end + " +
                "CASE WHEN q.customer_lost_the_quote = -1 then ', Customer Lost the order' ELSE '' end + " +
                "CASE WHEN q.non_responsive_customer = -1 then ', Non Responsive Customer' ELSE '' end) ,1,2,'') as reason_for_loss, " +
                "case when e.id is null then 'No Related Enquiry' else cast(e.id as nvarchar) end as enquiry_id " +
                "from [order_database].dbo.solidworks_quotation_log s " +
                "inner join (select quote_id,max(revision_number) as revision_number from [order_database].dbo.solidworks_quotation_log group by quote_id) as b on s.quote_id = b.quote_id AND s.revision_number = b.revision_number " +
                "left join [order_database].dbo.quotation_feed_back q on s.quote_id = q.quote_id " +
                "left join (SELECT max(id) as id,related_quote FROM [EnquiryLog].dbo.[enquiry_log] group by related_quote) e " +
                "on e.related_quote = cast(s.quote_id as nvarchar(max)) + '-' + cast(s.revision_number as nvarchar(max))  " +
                "WHERE ";

            if (txtQuoteID.Text.Length > 0)
                sql = sql + "  s.quote_id like '%" + txtQuoteID.Text + "%'    AND ";

            if (dateFilter == -1)
                sql = sql + "  date_output >= '" + dteStart.Value.ToString("yyyyMMdd") + "' AND date_output <= '" + dteEnd.Value.ToString("yyyyMMdd") + "'   AND ";

            if (txtItemCount.Text.Length > 0)
                sql = sql + "  item_count > " + txtItemCount.Text + "   AND ";

            if (cmbCustomer.Text.Length > 0)
                sql = sql + "  customer = '" + cmbCustomer.Text + "'   AND ";


            if (txtCustomerReference.Text.Length > 0)
                sql = sql + "  customer_ref LIKE '%" + txtCustomerReference.Text + "%'    AND ";

            if (txtQuotedBy.Text.Length > 0)
                sql = sql + "  emailed_to LIKE '%" + txtQuotedBy.Text + "%'    AND ";

            if (txtDeliveryAddress.Text.Length > 0)
                sql = sql + "  deliveryAddress LIKE '%" + txtDeliveryAddress.Text + "%'   AND ";

            if (txtValue.Text.Length > 0)
                sql = sql + "  total_quotation_value >= " + txtValue.Text + "   AND ";

            if (cmbStatus.Text.Length > 0)
                sql = sql + "  status = '" + cmbStatus.Text + "'   AND ";

            if (txtEnquiry.Text.Length > 0)
                sql = sql + "  e.id = '" + txtEnquiry.Text + "'   AND ";

            //priority_chase
            if (chkChasePriority.Checked == true)
                sql = sql + "  priority_chase = -1    AND ";

            if (chkTooExpensive.Checked == true)
                sql = sql + "  q.too_expensive = -1    AND ";
            if (chkLeadTimeTooLong.Checked == true)
                sql = sql + "  q.lead_time_too_long = -1    AND ";
            if (chkQuoteTookTooLong.Checked == true)
                sql = sql + "  q.quote_took_too_long = -1    AND ";
            if (chkUnableToMeetSpec.Checked == true)
                sql = sql + "  q.unable_to_meet_spec = -1    AND ";
            if (chkNonResponsive.Checked == true)
                sql = sql + "  q.non_responsive_customer = -1    AND ";
            if (chkCustomerLostQuote.Checked == true)
                sql = sql + "  q.customer_lost_the_quote = -1    AND ";

            sql = sql.Substring(0, sql.Length - 6);

            sql = sql + " order by quote_id desc";

            sql_report = sql;

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    column_index();
                    addButtons();
                    format();
                    conn.Close();
                }
            }
        }

        private void addButtons()
        {

            if (dataGridView1.Columns.Contains("View Quote") == true)
                dataGridView1.Columns.Remove("View Quote");
            column_index();


            DataGridViewButtonColumn view_button = new DataGridViewButtonColumn();
            view_button.Name = "View Quote";
            view_button.Text = "View Quote";
            view_button.UseColumnTextForButtonValue = true;
            if (dataGridView1.Columns["view_column"] == null)
            {
                dataGridView1.Columns.Insert(quote_index + 1, view_button);
            }
            column_index();
        }

        public void fillCombo()
        {
            string sql = "select distinct customer FROM [order_database].dbo.solidworks_quotation_log WHERE customer is not null order by customer asc";
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                        cmbCustomer.Items.Add(reader.GetString(0));
                    reader.Close();
                    conn.Close();
                }
            }
        }
        private void format()
        {
            //hide prio chase column
            dataGridView1.Columns[prioritY_chase_index].Visible = false;


            //remove >@designandsupply.co.uk< if it exists

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[quoted_by_index].Value.ToString().Contains("@designandsupply.co.uk"))
                    row.Cells[quoted_by_index].Value = row.Cells[quoted_by_index].Value.ToString().Replace("@designandsupply.co.uk", "");
                if (row.Cells[quoted_by_index].Value.ToString().Contains("sales@sealantonline.co.uk"))
                    row.Cells[quoted_by_index].Value = row.Cells[quoted_by_index].Value.ToString().Replace("sales@sealantonline.co.uk", "tomasz");

                //sales@sealantonline.co.uk
            }
            //label at the bottom right
            double total_cost = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                total_cost = total_cost + Convert.ToDouble(row.Cells[value_index].Value);
                //while we are here also we need to highlight any rows lightblue if they are prio chase
                if (row.Cells[prioritY_chase_index].Value.ToString() == "-1")
                    row.DefaultCellStyle.BackColor = Color.Goldenrod;

                if (row.Cells[status_index].Value.ToString() == "Won")
                    row.DefaultCellStyle.BackColor = Color.LightSeaGreen;

                if (row.Cells[status_index].Value.ToString() == "Lost")
                    row.DefaultCellStyle.BackColor = Color.PaleVioletRed;
            }
            lblTotalCost.Text = total_cost.ToString("C");

            //headertext stuff
            dataGridView1.Columns[quote_index].HeaderText = "Quote ID";
            dataGridView1.Columns[date_output_index].HeaderText = "Date Output";
            dataGridView1.Columns[rev_number_index].HeaderText = "Revision Number";
            dataGridView1.Columns[item_count_index].HeaderText = "Item Count";
            dataGridView1.Columns[customer_index].HeaderText = "Customer";
            dataGridView1.Columns[customer_reference_index].HeaderText = "Customer Ref";
            dataGridView1.Columns[quoted_by_index].HeaderText = "Quoted by";
            dataGridView1.Columns[delivery_address_index].HeaderText = "Delivery Address";
            dataGridView1.Columns[value_index].HeaderText = "Value";
            dataGridView1.Columns[status_index].HeaderText = "Status";
            dataGridView1.Columns[reason_for_loss_index].HeaderText = "Reason for loss";
            dataGridView1.Columns[enquiry_id_index].HeaderText = "Enquiry ID";

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }


            //////////quote ref is far too big sometimes so we need to force this to be less -- same for sys
            ////////dataGridView1.Columns[quotation_ref_index].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ////////dataGridView1.Columns[quotation_ref_index].Width = 250;

            //////////button sizes
            ////////dataGridView1.Columns[view_button_index].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ////////dataGridView1.Columns[email_button_index].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ////////dataGridView1.Columns[view_button_index].Width = 100;
            ////////dataGridView1.Columns[email_button_index].Width = 100;


            dataGridView1.Columns[value_index].DefaultCellStyle.Format = "c2";
            dataGridView1.Columns[value_index].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-GB");

            dataGridView1.Columns[customer_reference_index].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void column_index()
        {
            quote_index = dataGridView1.Columns["quote_id"].Index;
            if (dataGridView1.Columns.Contains("View Quote") == true)
                quote_button_index = dataGridView1.Columns["View Quote"].Index;
            date_output_index = dataGridView1.Columns["date_output"].Index;
            rev_number_index = dataGridView1.Columns["revision_number"].Index;
            item_count_index = dataGridView1.Columns["item_count"].Index;
            customer_index = dataGridView1.Columns["customer"].Index;
            customer_reference_index = dataGridView1.Columns["customer_ref"].Index;
            quoted_by_index = dataGridView1.Columns["quoted_by"].Index;
            delivery_address_index = dataGridView1.Columns["deliveryAddress"].Index;
            value_index = dataGridView1.Columns["total_quotation_value"].Index;
            status_index = dataGridView1.Columns["status"].Index;
            prioritY_chase_index = dataGridView1.Columns["priority_chase"].Index;
            enquiry_id_index = dataGridView1.Columns["enquiry_id"].Index;
            reason_for_loss_index = dataGridView1.Columns["reason_for_loss"].Index;
        }

        private void dteStart_ValueChanged(object sender, EventArgs e)
        {
            //dateFilter = -1;
            //apply_filter();
        }

        private void dteEnd_ValueChanged(object sender, EventArgs e)
        {
            //dateFilter = -1;
            //apply_filter();
        }



        private void btnClear_Click(object sender, EventArgs e)
        {
            txtQuoteID.Text = "";
            cmbStatus.Text = "";
            txtQuotedBy.Text = "";
            dateFilter = 0;
            txtItemCount.Text = "";
            cmbCustomer.Text = "";
            txtCustomerReference.Text = "";
            txtDeliveryAddress.Text = "";
            txtValue.Text = "";
            apply_filter();
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string sql = "";
            column_index();
            if (e.ColumnIndex == quote_button_index)
            {
                try
                {
                    string path = @"\\designsvr1\SOLIDWORKS\Door Designer\Specifications\Project " + dataGridView1.Rows[e.RowIndex].Cells[quote_index].Value.ToString() + @"\Quotations\Revision " + dataGridView1.Rows[e.RowIndex].Cells[rev_number_index].Value.ToString() + @"\FullQuotation-" + dataGridView1.Rows[e.RowIndex].Cells[quote_index].Value.ToString() + "-" + dataGridView1.Rows[e.RowIndex].Cells[rev_number_index].Value.ToString() + ".pdf";
                    System.Diagnostics.Process.Start(path);
                }
                catch
                {
                    MessageBox.Show("The full quotation does not yet exist for this number.", "No File Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }  //opens the quote doc <<<< needs to be looked at

            if (e.ColumnIndex == quote_index)
            {
                //if there is no entry in quotation_feed_back then make one
                sql = "select cast(quote_id as nvarchar(max)) FROM [order_database].dbo.quotation_feed_back WHERE quote_id = " + dataGridView1.Rows[e.RowIndex].Cells[quote_index].Value.ToString();
                using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        string data = (string)cmd.ExecuteScalar();
                        if (data == null)
                        {
                            sql = "INSERT INTO [order_database].dbo.quotation_feed_back (quote_id) VALUES (" + dataGridView1.Rows[e.RowIndex].Cells[quote_index].Value.ToString() + ")";
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    conn.Close();
                }

                frmTraditionalQuotation frm = new frmTraditionalQuotation(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[quote_index].Value.ToString()), dataGridView1.Rows[e.RowIndex].Cells[customer_index].Value.ToString());
                frm.ShowDialog();
                apply_filter();
            }  //opens quotation screen
        }

        private void txtQuoteID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                apply_filter();
        }

        private void txtQuoteID_Leave(object sender, EventArgs e)
        {
            apply_filter();
        }

        private void txtItemCount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                apply_filter();
        }

        private void txtItemCount_Leave(object sender, EventArgs e)
        {
            apply_filter();
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            apply_filter();
        }

        private void txtCustomerReference_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                apply_filter();
        }

        private void txtCustomerReference_Leave(object sender, EventArgs e)
        {
            apply_filter();
        }

        private void txtQuotedBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                apply_filter();
        }

        private void txtQuotedBy_Leave(object sender, EventArgs e)
        {
            apply_filter();
        }

        private void txtDeliveryAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                apply_filter();
        }

        private void txtDeliveryAddress_Leave(object sender, EventArgs e)
        {
            apply_filter();
        }

        private void txtValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                apply_filter();
        }

        private void txtValue_Leave(object sender, EventArgs e)
        {
            apply_filter();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStatus.Text == "Lost")
            {
                lblLossReasons.Visible = true;
                chkTooExpensive.Visible = true;
                chkLeadTimeTooLong.Visible = true;
                chkQuoteTookTooLong.Visible = true;
                chkUnableToMeetSpec.Visible = true;
                chkNonResponsive.Visible = true;
            }
            else
            {
                lblLossReasons.Visible = false;
                chkTooExpensive.Visible = false;
                chkLeadTimeTooLong.Visible = false;
                chkQuoteTookTooLong.Visible = false;
                chkUnableToMeetSpec.Visible = false;
                chkNonResponsive.Visible = false;

                
                chkTooExpensive.Checked = false;
                chkLeadTimeTooLong.Checked = false;
                chkQuoteTookTooLong.Checked = false;
                chkUnableToMeetSpec.Checked = false;
                chkNonResponsive.Checked = false;

            }
            apply_filter();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            string temp = "";
            string sql = sql_report;
            //get all processes before opening the sheet
            Process[] processesBefore = Process.GetProcessesByName("excel");

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
                        if (row[6].ToString().Contains("@designandsupply.co.uk"))
                            row[6] = row[6].ToString().Replace("@designandsupply.co.uk", "");
                        if (row[6].ToString().Contains("sales@sealantonline.co.uk"))
                            row[6] = row[6].ToString().Replace("sales@sealantonline.co.uk", "tomasz");


                    }

                    //dataGridView1.DataSource = dt;
                    //open the excel doc here and start inserting 
                    // Store the Excel processes before opening.
                    
                    // Open the file in Excel.

                    System.IO.Directory.CreateDirectory(@"C:\temp");

                    temp = @"\\designsvr1\apps\Design and Supply CSharp\price_log_template_traditional.xlsx";
                    System.IO.File.Copy(temp, @"C:\temp\price_log_traditional.xlsx", true);

                    temp = @"C:\temp\price_log_traditional.xlsx";

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
        }

        private void btnOutstanding_Click(object sender, EventArgs e)
        {
            frmOutstandingChase frm = new frmOutstandingChase(0);
            frm.ShowDialog();
        }

        private void frmTraditional_Shown(object sender, EventArgs e)
        {
            //check if there is any outstanding chases ----
            string sql = "SELECT CAST(a.quote_id as nvarchar(max)) " +
               "FROM [order_database].dbo.quotation_chase_log a " +
               "left join [order_database].dbo.quotation_feed_back b on a.quote_id = b.quote_id " +
               "left join[user_info].dbo.[user] u on a.chased_by = u.id " +
               "where next_chase_date <= CAST(GETDATE() as date) and b.[status] = 'Chasing' and (dont_chase = 0 or dont_chase is null) and (chase_complete = 0 or chase_complete is null) and u.id = " + CONNECT.staffID;

            //sql = "SELECT CAST(a.quote_id as nvarchar(max)) FROM [order_database].dbo.quotation_chase_log where next_chase_date <= CAST(GETDATE() as date) and " +
            //"dont_chase = 0 and(chase_followed_up is null or chase_followed_up = 0) AND chased_by =  " + CONNECT.staffID.ToString();



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
                            frmOutstandingChase frm = new frmOutstandingChase(0);
                            frm.ShowDialog();
                        }
                    }
                }

                //also check outstanding correspondence
                sql = "SELECT cast(id as nvarchar(max)) FROM [order_database].dbo.quotation_chase_customer " +
                      "where no_follow_up = 0 AND (complete = 0 or complete is null) AND " +
                      "slimline = 0 AND correspondence_by = " + CONNECT.staffID.ToString() + " AND next_correspondence_date <= CAST(GETDATE()  as date)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    string temp = (string)(cmd.ExecuteScalar());
                    if (temp != null)
                    {
                        DialogResult result = MessageBox.Show("You have current outstanding correspondences, would you like to view them?", "Outstanding correspondences", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (result == DialogResult.Yes)
                        {
                            frmOutstandingCustomerCorrespondence frm = new frmOutstandingCustomerCorrespondence(0);
                            frm.ShowDialog();
                        }
                    }
                }

                conn.Close();

                column_index();
                format();
            }
        }

        private void buttonFormatting1_Click(object sender, EventArgs e)
        {
            frmOutstandingChase frm = new frmOutstandingChase(-1);
            frm.ShowDialog();
        }

        private void btnManagementView_Click(object sender, EventArgs e)
        {
            frmManagementView frm = new frmManagementView(0);
            frm.ShowDialog();
        }

        private void chkChasePriority_CheckedChanged(object sender, EventArgs e)
        {
            apply_filter();
        }

        private void txtEnquiry_Leave(object sender, EventArgs e)
        {
            apply_filter();
        }

        private void txtEnquiry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                apply_filter();
        }

        private void txtEnquiry_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkTooExpensive_CheckedChanged(object sender, EventArgs e)
        {
            apply_filter();
        }

        private void chkLeadTimeTooLong_CheckedChanged(object sender, EventArgs e)
        {
            apply_filter();
        }

        private void chkQuoteTookTooLong_CheckedChanged(object sender, EventArgs e)
        {
            apply_filter();
        }

        private void chkUnableToMeetSpec_CheckedChanged(object sender, EventArgs e)
        {
            apply_filter();
        }

        private void chkNonResponsive_CheckedChanged(object sender, EventArgs e)
        {
            apply_filter();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            frmChaseCustomerList frm = new frmChaseCustomerList(0,"");
            frm.ShowDialog();
        }

        private void btnNonReturningCustomers_Click(object sender, EventArgs e)
        {
            frmNonReturningCustomers frm = new frmNonReturningCustomers(0);
            frm.ShowDialog();
        }

        private void btnAlert_Click(object sender, EventArgs e)
        {
            frmManagementAlert frm = new frmManagementAlert(0);
            frm.ShowDialog();
        }

        private void btnOutstandingCorrespondence_Click(object sender, EventArgs e)
        {
            frmOutstandingCustomerCorrespondence frm = new frmOutstandingCustomerCorrespondence(0);
            frm.ShowDialog();
        }

        private void btnTurnoverDecline_Click(object sender, EventArgs e)
        {
            frmTurnOverDecline frm = new frmTurnOverDecline(0);
            frm.ShowDialog();
        }

        private void dteStart_CloseUp(object sender, EventArgs e)
        {
            dateFilter = -1;
            apply_filter();
        }

        private void dteEnd_CloseUp(object sender, EventArgs e)
        {
            dateFilter = -1;
            apply_filter();
        }

        private void btnCalendar_Click(object sender, EventArgs e)
        {
            frmCalendar frm = new frmCalendar();
            frm.ShowDialog();
        }

        private void chkCustomerLostQuote_CheckedChanged(object sender, EventArgs e)
        {
            apply_filter();
        }
    }
}
