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
using PriceMaster.TraditionalChasing;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;

namespace PriceMaster
{
    public partial class frmOutstandingChase : Form
    {
        //normal chase indexs
        public int id_index { get; set; }
        public int quote_index { get; set; }
        public int chase_date_index { get; set; }
        public int chase_description_index { get; set; }
        public int next_chase_date_index { get; set; }
        public int chased_by_index { get; set; }
        public int button_index { get; set; }
        public int admin { get; set; }
        public int customer_index { get; set; }
        public int sender_email_address_index { get; set; }
        public int priority_chase_index { get; set; }

        //auto chase index
        public int auto_customer_index { get; set; }
        public int auto_quote_id_index { get; set; }
        public int auto_customer_ref_index { get; set; }
        public int auto_total_quotation_value_index { get; set; }
        public int auto_quote_button { get; set; }
        public int auto_revision_index { get; set; }
        public int auto_item_count_index { get; set; }
        public frmOutstandingChase(int _admin)
        {
            InitializeComponent();
            admin = _admin;
            load_data();
            fill_combo();
            if (admin == -1)
                this.Text = "Admin Outstanding Chases";

        }

        private void format()
        {
            if (tabControl1.SelectedIndex == 0)
            {
                dataGridView1.Columns[id_index].Visible = false;
                dataGridView1.Columns[quote_index].HeaderText = "Quote ID";
                dataGridView1.Columns[chase_date_index].HeaderText = "Chase Date";
                dataGridView1.Columns[chase_description_index].HeaderText = "Chase Description";
                dataGridView1.Columns[next_chase_date_index].HeaderText = "Next Chase Date";
                dataGridView1.Columns[customer_index].HeaderText = "Customer";
                dataGridView1.Columns[sender_email_address_index].HeaderText = "Sender Email Address";
                dataGridView1.Columns[priority_chase_index].Visible = false;


                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[sender_email_address_index].Value.ToString().Contains("EXCHANGELABS/OU=EXCHANGE"))
                    {
                        //remove all the clutter
                        string temp = row.Cells[sender_email_address_index].Value.ToString();
                        row.Cells[sender_email_address_index].Value = temp.Substring(temp.IndexOf("-") + 1);
                    }
                    if (row.Cells[priority_chase_index].Value.ToString() == "-1")
                        row.DefaultCellStyle.BackColor = Color.LightSkyBlue;
                }


                if (admin == 0)
                    dataGridView1.Columns[chased_by_index].Visible = false;
                else
                    dataGridView1.Columns[chased_by_index].HeaderText = "Chased by";

                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                dataGridView1.Columns[chase_description_index].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            }
            else
            {

                dataGridView1.Columns[auto_customer_index].HeaderText = "Customer";
                dataGridView1.Columns[auto_quote_id_index].HeaderText = "Quote ID";
                dataGridView1.Columns[auto_customer_ref_index].HeaderText = "Customer Reference";
                dataGridView1.Columns[auto_total_quotation_value_index].HeaderText = "Quotation Value";

                dataGridView1.Columns[auto_revision_index].Visible = false;
                dataGridView1.Columns[auto_item_count_index].Visible = false;

                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                dataGridView1.Columns[auto_customer_ref_index].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;



                colourAutoChases();
            }
        }
        private void fill_combo()
        {
            //cmbCustomerSearch.Items.Clear();
            int column = 0;

            if (tabControl1.SelectedIndex == 0)
                column = 6;
            else
                column = 0;

            //load all the data into the customers
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (cmbCustomerSearch.Items.Contains(row.Cells[column].Value.ToString()))
                { } //nothing
                else
                    cmbCustomerSearch.Items.Add(row.Cells[column].Value.ToString());
            }
        }

        private void load_data()
        {
            string sql = "";
            dataGridView1.DataSource = null;

            if (tabControl1.SelectedIndex == 0)
            {
                sql = "SELECT a.id,a.quote_id,chase_date,chase_description,next_chase_date,u.forename + ' ' + u.surname as  [Chased by],rtrim(q.customer) as customer,e.sender_email_address,priority_chase " +
                    "FROM [order_database].dbo.quotation_chase_log a " +
                    "left join [order_database].dbo.quotation_feed_back b on a.quote_id = b.quote_id " +
                    "left join[user_info].dbo.[user] u on a.chased_by = u.id " +
                    "left join (select quote_id,max(revision_number) as revision_number from [order_database].dbo.solidworks_quotation_log group by quote_id) sw on a.quote_id = sw.quote_id " +
                    "left join [order_database].dbo.solidworks_quotation_log q on sw.quote_id = q.quote_id and sw.revision_number = q.revision_number " +
                    "left join (select max(id) as enquiry_id, left(related_quote, CHARINDEX('-', related_quote) - 1) as related_quote from [EnquiryLog].dbo.[Enquiry_Log] WHERE related_quote<> 'No Related Quote' group by LEFT(related_quote, CHARINDEX('-', related_quote) - 1)) el on el.related_quote like '%' + cast(q.quote_id as nvarchar) + '%' " +
                    "left join [EnquiryLog].dbo.[Enquiry_Log] e on el.enquiry_id = e.id " +
                    "where next_chase_date ";


                if (chkFuture.Checked == true)
                    sql = sql + " > ";
                else
                    sql = sql + " <= ";

                sql = sql + "CAST(GETDATE() as date) and b.[status] = 'Chasing' and (dont_chase = 0 or dont_chase is null) AND (chase_complete = 0 or chase_complete is null) ";

                if (string.IsNullOrEmpty(cmbCustomerSearch.Text) == false)
                    sql = sql + " AND rtrim(q.customer) = '" + cmbCustomerSearch.Text + "'  ";

                if (admin == 0)
                    sql = sql + "AND chased_by = " + CONNECT.staffID.ToString();

                sql = sql + " order by priority_chase desc,rtrim(q.customer) ,next_chase_date asc, quote_id ";
                using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                    conn.Close();
                }
            }
            else
            {
                sql = "select s.customer,cast(s.quote_id as nvarchar) as quote_id, " +
                      "s.customer_ref,'£' + CAST(round(s.total_quotation_value,2) as nvarchar(max)) as total_quotation_value,revision_number,item_count from [order_database].dbo.solidworks_quotation_log as s " +
                      // "left join [order_database].dbo.quotation_chase_log q on s.quote_id = q.quote_id " +
                      "left join [order_database].dbo.quotation_chase_exclusion_list a on s.customer = a.customer " +
                      "where cast(date_output as date) = cast([order_database].dbo.func_work_days(getdate(),2) as date) AND a.customer is null ";

                if (string.IsNullOrEmpty(cmbCustomerSearch.Text) == false)
                    sql = sql + " AND customer = '" + cmbCustomerSearch.Text + "' ";
                sql = sql + "order by customer"; // and q.quote_id is null";
                using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                    conn.Close();
                }
            }
            column_index();
            add_button();
            column_index();
            format();
            column_index();
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

            if (dataGridView1.Columns.Contains("Quote") == true)
                dataGridView1.Columns.Remove("Quote");
            if (tabControl1.SelectedIndex == 1)
            {
                //add a quote button on the end


                column_index();
                DataGridViewButtonColumn view_button = new DataGridViewButtonColumn();
                view_button.Name = "Quote";
                view_button.Text = "View Quote";
                view_button.UseColumnTextForButtonValue = true;
                if (dataGridView1.Columns["Quote"] == null)
                {
                    dataGridView1.Columns.Insert(auto_item_count_index + 1, view_button);
                }
            }
        }

        private void column_index()
        {
            if (tabControl1.SelectedIndex == 0)
            {
                id_index = dataGridView1.Columns["id"].Index;
                quote_index = dataGridView1.Columns["quote_id"].Index;
                chase_date_index = dataGridView1.Columns["chase_date"].Index;
                chase_description_index = dataGridView1.Columns["chase_description"].Index;
                next_chase_date_index = dataGridView1.Columns["next_chase_date"].Index;
                chased_by_index = dataGridView1.Columns["Chased by"].Index;
                customer_index = dataGridView1.Columns["customer"].Index;
                sender_email_address_index = dataGridView1.Columns["sender_email_address"].Index;
                priority_chase_index = dataGridView1.Columns["priority_chase"].Index;

                if (dataGridView1.Columns.Contains("Complete") == true)
                    button_index = dataGridView1.Columns["Complete"].Index;
            }
            else
            {
                auto_customer_index = dataGridView1.Columns["customer"].Index;
                auto_quote_id_index = dataGridView1.Columns["quote_id"].Index;
                auto_customer_ref_index = dataGridView1.Columns["customer_ref"].Index;
                auto_total_quotation_value_index = dataGridView1.Columns["total_quotation_value"].Index;
                auto_revision_index = dataGridView1.Columns["revision_number"].Index;
                auto_item_count_index = dataGridView1.Columns["item_count"].Index;
                if (dataGridView1.Columns.Contains("Quote") == true)
                    auto_quote_button = dataGridView1.Columns["Quote"].Index;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            column_index();
            //if (e.ColumnIndex == button_index)
            //{
            //    DialogResult result = MessageBox.Show("Are you sure you want to mark this chase as completed?", "Completed Chase Entry", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            //    if (result == DialogResult.Yes)
            //    {
            //        string sql = "UPDATE [order_database].dbo.[quotation_chase_log] SET chase_followed_up = -1,chase_followed_up_date = GETDATE() WHERE id = " + dataGridView1.Rows[e.RowIndex].Cells[id_index].Value.ToString();
            //        using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            //        {
            //            conn.Open();
            //            using (SqlCommand cmd = new SqlCommand(sql, conn))
            //                cmd.ExecuteNonQuery();
            //            conn.Close();
            //            load_data();
            //        }
            //    }
            //}
            //else
            //{
            //try
            //{

            if (e.ColumnIndex == auto_quote_button)
            {
                try
                {
                    string path = @"\\designsvr1\SOLIDWORKS\Door Designer\Specifications\Project " + dataGridView1.Rows[e.RowIndex].Cells[auto_quote_id_index].Value.ToString()
                        + @"\Quotations\Revision " + dataGridView1.Rows[e.RowIndex].Cells[auto_revision_index].Value.ToString() +
                        @"\FullQuotation-" + dataGridView1.Rows[e.RowIndex].Cells[quote_index].Value.ToString() + "-" +
                        dataGridView1.Rows[e.RowIndex].Cells[auto_revision_index].Value.ToString() + ".pdf";
                    System.Diagnostics.Process.Start(path);
                }
                catch
                {
                    MessageBox.Show("The full quotation does not yet exist for this number.", "No File Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {

                //get the customer
                string customer = "";
                using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                {
                    conn.Open();
                    string sql = "select customer from [order_database].dbo.solidworks_quotation_log where quote_id = " + dataGridView1.Rows[e.RowIndex].Cells[quote_index].Value.ToString();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                        customer = cmd.ExecuteScalar().ToString();

                    conn.Close();
                }

                if (tabControl1.SelectedIndex == 0)
                {
                    frmTraditionalQuotation frm = new frmTraditionalQuotation(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[quote_index].Value.ToString()), customer);
                    frm.ShowDialog();
                    load_data();
                }
                else
                {
                    string sql = "select cast(quote_id as nvarchar(max)) FROM [order_database].dbo.quotation_feed_back WHERE quote_id = " + dataGridView1.Rows[e.RowIndex].Cells[auto_quote_id_index].Value.ToString();
                    using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            string data = (string)cmd.ExecuteScalar();
                            if (data == null)
                            {
                                sql = "INSERT INTO [order_database].dbo.quotation_feed_back (quote_id) VALUES (" + dataGridView1.Rows[e.RowIndex].Cells[auto_quote_id_index].Value.ToString() + ")";
                                cmd.CommandText = sql;
                                cmd.ExecuteNonQuery();
                            }
                        }
                        conn.Close();
                    }

                    frmTraditionalQuotation frm = new frmTraditionalQuotation(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[auto_quote_id_index].Value.ToString()), dataGridView1.Rows[e.RowIndex].Cells[auto_customer_index].Value.ToString());
                    frm.ShowDialog();
                    colourAutoChases();
                }
            }

            //apply_filter();
            //}
            //    catch { }
            //}
        }

        private void cmbCustomerSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_data();
        }

        private void chkFuture_CheckedChanged(object sender, EventArgs e)
        {
            load_data();
        }

        private void frmOutstandingChase_Shown(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCustomerSearch.Items.Clear();
            load_data();
            fill_combo();
            if (tabControl1.SelectedIndex == 0)
            {
                lblTitle.Text = "The following entries are marked for a follow up and have not yet been completed.";
                lblPriority.Text = "= Priority ";
                chkFuture.Visible = true;
                this.Text = "Outstanding Chases";
            }
            else
            {
                lblTitle.Text = "The following entries are marked as potential chases.";
                lblPriority.Text = "= Chased ";
                chkFuture.Visible = false;
                this.Text = "Autochase List";
            }
        }

        private void colourAutoChases()
        {
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    //check the quoteid of each row > if there is a match for a chase mark the row as blue
                    string sql = "select id from [order_database].dbo.quotation_chase_log where quote_id = " + dataGridView1.Rows[i].Cells[auto_quote_id_index].Value.ToString();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        var temp = cmd.ExecuteScalar();
                        if (temp != null)
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                    }
                }
                conn.Close();
            }
        }

        private void btnBanList_Click(object sender, EventArgs e)
        {
            frmAutoChaseBanList frm = new frmAutoChaseBanList();
            frm.ShowDialog();
        }

        private void btnExportList_Click(object sender, EventArgs e)
        {
            string file = @"C:\temp\outstanding_chases.xlsx";

            //opening method
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Add(); //xlApp.Workbooks.Open(GT_input_filepath, 0, false); //< to open an already existing file
            Excel.Worksheet xlWorksheet = xlWorkbook.Worksheets[1];

            xlApp.Visible = true; //make it visible for now
            xlApp.WindowState = Excel.XlWindowState.xlMaximized;

            //main body of changes and stuff goes here

            xlWorksheet.Cells[1][1].Value2 = "Quote ID";
            xlWorksheet.Cells[2][1].Value2 = "Chase Date";
            xlWorksheet.Cells[3][1].Value2 = "Chase Description";
            xlWorksheet.Cells[4][1].Value2 = "Next Chase Date";
            xlWorksheet.Cells[5][1].Value2 = "Customer";
            xlWorksheet.Cells[6][1].Value2 = "Sender Email Address";

            Excel.Range columnRange = xlWorksheet.Columns[2];
            columnRange.NumberFormat = "dd-MM-yyyy";
            columnRange = xlWorksheet.Columns[4];
            columnRange.NumberFormat = "dd-MM-yyyy";

            int excel_row = 2;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                xlWorksheet.Cells[1][excel_row].Value2 = dataGridView1.Rows[i].Cells[quote_index].Value;
                xlWorksheet.Cells[2][excel_row].Value2 = dataGridView1.Rows[i].Cells[chase_date_index].Value;
                xlWorksheet.Cells[3][excel_row].Value2 = dataGridView1.Rows[i].Cells[chase_description_index].Value;
                xlWorksheet.Cells[4][excel_row].Value2 = dataGridView1.Rows[i].Cells[next_chase_date_index].Value;
                xlWorksheet.Cells[5][excel_row].Value2 = dataGridView1.Rows[i].Cells[customer_index].Value;
                xlWorksheet.Cells[6][excel_row].Value2 = dataGridView1.Rows[i].Cells[sender_email_address_index].Value;
                excel_row++;
            }


            //formatting examples

            //xlWorkSheet.Range["H2:H300"].NumberFormat = "£#,###,###.00"; < formats into currency
            //xlWorksheet.Range["A1:D1"].Merge(); merging cells
            xlWorksheet.Range["A1:F1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            xlWorksheet.Range["A1:F1"].Cells.Font.Size = 16;
            xlWorksheet.Range["A1:F1"].Interior.Color = Color.SkyBlue;
            //auto fit and rows 
            //Microsoft.Office.Interop.Excel.Worksheet ws = xlApp.ActiveWorkbook.Worksheets[1];
            Microsoft.Office.Interop.Excel.Range range = xlWorksheet.UsedRange;
            //xlWorksheet.Columns.ClearFormats();
            //xlWorksheet.Rows.ClearFormats();
            xlWorksheet.Columns.AutoFit();
            xlWorksheet.Rows.AutoFit();
            range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            xlWorksheet.Columns[3].ColumnWidth = 98.14; //size and wrap columns
            xlWorksheet.Columns[3].WrapText = true;

            //border active cells
            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            range.Borders.Color = ColorTranslator.ToOle(Color.Black);

            //Set print margins
            Excel.PageSetup xlPageSetUp = xlWorksheet.PageSetup;
            xlPageSetUp.Zoom = false;
            xlPageSetUp.FitToPagesWide = 1;
            xlPageSetUp.Orientation = Excel.XlPageOrientation.xlLandscape;

            //save the new file
            xlApp.DisplayAlerts = false;
            xlWorkbook.SaveAs(file);

            //close the workbook
            xlWorkbook.Close();
            xlApp.Quit();

            //release objects from memory
            releaseObject(xlWorksheet);
            releaseObject(xlWorkbook);
            releaseObject(xlApp);
            Process.Start(file);
        }
        private static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                Console.WriteLine("Error releasing object: " + ex.Message);
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
