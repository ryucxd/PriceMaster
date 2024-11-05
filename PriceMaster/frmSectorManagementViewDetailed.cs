using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace PriceMaster
{
    public partial class frmSectorManagementViewDetailed : Form
    {

        public int _sector_id { get; set; }
        public int _staff_id { get; set; }

        public frmSectorManagementViewDetailed(int sector_id, int staff_id)
        {
            InitializeComponent();

            validate_tab_pages(sector_id, staff_id);

            load_grid(sector_id, staff_id);

            _sector_id = sector_id;
            _staff_id = staff_id;

        }

        private void validate_tab_pages(int sector_id, int staff_id)
        {

            tabControl.TabPages.Clear();

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                string sql_correspondence = "select q.id FROM [order_database].dbo.quotation_chase_customer q " +
                    "left join [order_database].dbo.sales_table s on q.sector_id = s.id " +
                    "where sector_id = " + sector_id + " and correspondence_by = " + staff_id;

                using (SqlCommand cmd = new SqlCommand(sql_correspondence, conn))
                {
                    var temp = cmd.ExecuteScalar();

                    if (temp != null)
                    {
                        TabPage tabPageCorrespondence = new TabPage
                        {
                            Name = "Correspondence",
                            Text = "Correspondence"
                        };
                        tabControl.TabPages.Add(tabPageCorrespondence);
                    }
                }

                //string sql_quotations = "select q.id " +
                //    "FROM [order_database].dbo.quotation_chase_log q " +
                //    "left join [order_database].dbo.sales_table s on q.sector_id = s.id " +
                //    "left join [order_database].dbo.solidworks_quotation_log sq on q.quote_id = sq.quote_id " +
                //    "where sector_id = " + sector_id + " AND chased_by = " + staff_id;

                string sql_quotations = "select q.id " +
                 "FROM [order_database].dbo.quotation_chase_log_slimline q " +
                 "left join [order_database].dbo.sales_table s on q.sector_id = s.id " +
                 "left join[price_master].dbo.[sl_quotation] sq on q.quote_id = sq.quote_id " +
                 "left join[dsl_fitting].dbo.sales_ledger sl on sq.customer_acc_ref = sl.ACCOUNT_REF " +
                 "where sector_id = " + sector_id + " AND chased_by = " + staff_id + " " +
                 "union all " +
                 "select q.id " +
                 "FROM [order_database].dbo.quotation_chase_log q " +
                 "left join [order_database].dbo.sales_table s on q.sector_id = s.id " +
                 "left join [order_database].dbo.solidworks_quotation_log sq on q.quote_id = sq.quote_id " +
                 "where sector_id = " + sector_id + " AND chased_by = " + staff_id;

                using (SqlCommand cmd = new SqlCommand(sql_quotations, conn))
                {
                    var temp = cmd.ExecuteScalar();

                    if (temp != null)
                    {
                        TabPage tabPageQuotation = new TabPage
                        {
                            Name = "Quotation Chasing",
                            Text = "Quotation Chasing"
                        };
                        tabControl.TabPages.Add(tabPageQuotation);
                    }
                }


                string sql_lead = "select s.id FROM .[order_database].dbo.sales_new_leads s " +
                    "left join [user_info].dbo.[user] u on s.allocated_to = u.id " +
                    "where sector_id = " + sector_id + " AND lead_by = " + staff_id;

                using (SqlCommand cmd = new SqlCommand(sql_lead, conn))
                {
                    var temp = cmd.ExecuteScalar();

                    if (temp != null)
                    {
                        TabPage tabPageLead = new TabPage
                        {
                            Name = "Leads",
                            Text = "Leads"
                        };
                        tabControl.TabPages.Add(tabPageLead);
                    }
                }


                conn.Close();
            }

        }

        private void load_grid(int sector_id, int staff)
        {
            if (tabControl.SelectedIndex < 0)
                return;

            string sql_correspondence = "select q.id,date_created [Correspondence Date], rtrim(customer_name) as [Customer],Contact,body as [Notes]," +
                "CASE WHEN issue_with_leadtime = 0 THEN CAST(0 AS BIT) WHEN issue_with_leadtime IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Leadtime Issue]," +
                "CASE WHEN issue_with_quote_turnaround_time = 0 THEN CAST(0 AS BIT) WHEN issue_with_quote_turnaround_time IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Quote Turnaround Issue]," +
                "CASE WHEN issue_with_product = 0 THEN CAST(0 AS BIT) WHEN issue_with_product IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Product Issue]," +
                "CASE WHEN issue_with_installation = 0 THEN CAST(0 AS BIT) WHEN issue_with_installation IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Installation Issue]," +
                "CASE WHEN issue_with_service = 0 THEN CAST(0 AS BIT) WHEN issue_with_service IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Service Issue]," +
                "next_correspondence_date [Next Correspondence], Sector ,slimline,failed_contact " +
                "FROM [order_database].dbo.quotation_chase_customer q " +
                "left join [order_database].dbo.sales_table s on q.sector_id = s.id " +
                "where sector_id = " + sector_id + " and correspondence_by = " + staff + " AND " +
                "body LIKE '%" + txtFilter.Text + "%' " +
                "ORDER BY date_created desc";


            //string sql_quotations = "select q.id,chase_date,q.quote_id,customer,chase_description, " +
            //    "CASE WHEN phone = 0 THEN CAST(0 AS BIT) WHEN phone IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS phone, " +
            //    "CASE WHEN email = 0 THEN CAST(0 AS BIT) WHEN email IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS email, " +
            //    "CASE WHEN chase_complete = 0 THEN CAST(0 AS BIT) WHEN chase_complete IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS chase_complete, " +
            //    "sector " +
            //    "FROM [order_database].dbo.quotation_chase_log q " +
            //    "left join [order_database].dbo.sales_table s on q.sector_id = s.id " +
            //    "left join [order_database].dbo.solidworks_quotation_log sq on q.quote_id = sq.quote_id " +
            //    "where sector_id = " + sector_id + " AND chased_by = " + staff;


            string sql_quotations = "select q.id,chase_date as [Chase Date],Name as Customer,'SL' + CAST(q.quote_id as nvarchar(max)) as [Quote ID],coalesce(sq.price,0) as [Value],chase_description as [Chase Notes]," +
                "CASE WHEN phone = 0 THEN CAST(0 AS BIT) WHEN phone IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS Phone, " +
                "CASE WHEN email = 0 THEN CAST(0 AS BIT) WHEN email IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS Email, " +
                "CASE WHEN chase_complete = 0 THEN CAST(0 AS BIT) WHEN chase_complete IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END as [Chase Complete], " +
                "Sector,failed_contact " +
                "FROM [order_database].dbo.quotation_chase_log_slimline q " +
                "left join [order_database].dbo.sales_table s on q.sector_id = s.id " +
                "left join [price_master].dbo.[sl_quotation] sq on q.quote_id = sq.quote_id " +
                "left join [dsl_fitting].dbo.sales_ledger sl on sq.customer_acc_ref = sl.ACCOUNT_REF " +
                "where sector_id = " + sector_id + " AND chased_by = " + staff + " AND sq.highest_issue = -1 AND " +
                "chase_description LIKE '%" + txtFilter.Text + "%'" +
                "union all " +
                "select q.id,chase_date as [Chase Date],Customer,CAST(q.quote_id as nvarchar(max)) as [Quote ID],coalesce(total_quotation_value,0) as [Value],chase_description as [Chase Notes], " +
                "CASE WHEN phone = 0 THEN CAST(0 AS BIT) WHEN phone IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS Phone, " +
                "CASE WHEN email = 0 THEN CAST(0 AS BIT) WHEN email IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS Email, " +
                "CASE WHEN chase_complete = 0 THEN CAST(0 AS BIT) WHEN chase_complete IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END as [Chase Complete], " +
                "Sector,failed_contact " +
                "FROM [order_database].dbo.quotation_chase_log q " +
                "left join [order_database].dbo.sales_table s on q.sector_id = s.id " +
                "left join (select q.quote_id,q.customer,total_quotation_value FROM [order_database].dbo.solidworks_quotation_log q " +
                        "right join [order_database].dbo.view_solidworks_max_rev r on q.quote_id = r.quote_id AND q.revision_number = r.revision_number) sq on q.quote_id = sq.quote_id " +
                "where sector_id = " + sector_id + " AND chased_by = " + staff + " AND " +
                "chase_description LIKE '%" + txtFilter.Text + "%' " +
                "order by chase_date desc";

            string sql_lead = "select s.id,lead_date as [Lead Date],Customer,contact_name as [Contact Name],contact_details as [Contact Details]," +
                "u.forename + ' ' + u.surname as [Allocated to],sector,notes as [Lead Notes]" +
                "FROM [order_database].dbo.sales_new_leads s " +
                "left join [user_info].dbo.[user] u on s.allocated_to = u.id " +
                "left join [order_database].dbo.sales_table st on s.sector_id = st.id " +
                "where sector_id = " + sector_id + " AND lead_by = " + staff + " AND " +
                "customer LIKE '%" + txtFilter.Text + "%' " +
                "order by lead_date desc";


            string sql = "";
            //pick the sql string based on which tab is selected
            if (tabControl.TabPages[tabControl.SelectedIndex].Text == "Correspondence")
            {
                sql = sql_correspondence;
            }
            else if (tabControl.TabPages[tabControl.SelectedIndex].Text == "Quotation Chasing")
            {
                sql = sql_quotations;
            }
            else if (tabControl.TabPages[tabControl.SelectedIndex].Text == "Leads")
            {
                sql = sql_lead;
            }

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvSector.DataSource = dt;
                }
            }

            format_grid();
        }



        private void format_grid()
        {
            if (dgvSector.Rows.Count == 0)
                return;

            if (tabControl.SelectedIndex == -1)
                return;
            foreach (DataGridViewColumn col in dgvSector.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                col.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            dgvSector.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            foreach (DataGridViewRow row in dgvSector.Rows)
            {
                if (tabControl.TabPages[tabControl.SelectedIndex].Text == "Correspondence")
                {
                    if (row.Cells[13].Value.ToString() == "-1")
                        row.DefaultCellStyle.BackColor = Color.PaleVioletRed;
                }
                else if (tabControl.TabPages[tabControl.SelectedIndex].Text == "Quotation Chasing")
                {
                    if (row.Cells[10].Value.ToString() == "-1")
                        row.DefaultCellStyle.BackColor = Color.PaleVioletRed;
                }
            }

            //distinct formatting
            if (tabControl.TabPages[tabControl.SelectedIndex].Text == "Correspondence")
            {
                lblSector.Text = "Sector: " + dgvSector.Rows[0].Cells[11].Value.ToString();

                dgvSector.Columns[0].Visible = false;
                dgvSector.Columns[11].Visible = false;
                dgvSector.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvSector.Columns[12].Visible = false;
                dgvSector.Columns[13].Visible = false; //failed contact
            }
            else if (tabControl.TabPages[tabControl.SelectedIndex].Text == "Quotation Chasing")
            {
                lblSector.Text = "Sector: " + dgvSector.Rows[0].Cells[9].Value.ToString();

                dgvSector.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvSector.Columns[0].Visible = false;
                dgvSector.Columns[9].Visible = false;
                dgvSector.Columns[10].Visible = false; //failed_contact
                dgvSector.Columns[4].DefaultCellStyle.Format = "c";
            }
            else if (tabControl.TabPages[tabControl.SelectedIndex].Text == "Leads")
            {
                lblSector.Text = "Sector: " + dgvSector.Rows[0].Cells[6].Value.ToString();

                dgvSector.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvSector.Columns[0].Visible = false;
                dgvSector.Columns[6].Visible = false;

            }
            dgvSector.ClearSelection();
        }


        private void frmSectorManagementViewDetailed_Shown(object sender, EventArgs e)
        {
            format_grid();
            dgvSector.ClearSelection();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_grid(_sector_id, _staff_id);
            format_grid();
        }

        private void dgvSector_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int correspondence = 0;
            int slimline = 0;

            if (tabControl.TabPages[tabControl.SelectedIndex].Text == "Correspondence")
            {
                correspondence = -1;
                slimline = Convert.ToInt32(dgvSector.Rows[e.RowIndex].Cells[12].Value.ToString());
            }
            else if (tabControl.TabPages[tabControl.SelectedIndex].Text == "Quotation Chasing")
            {
                correspondence = 0;
                if (dgvSector.Rows[e.RowIndex].Cells[3].Value.ToString().ToUpper().Contains("SL"))
                    slimline = -1;
            }
            else
                return;




            frmSectorChaseCorrespondenceHistory frm = new frmSectorChaseCorrespondenceHistory(correspondence, dgvSector.Rows[e.RowIndex].Cells[2].Value.ToString(), _staff_id, dgvSector.Rows[e.RowIndex].Cells[0].Value.ToString(), slimline);
            frm.ShowDialog();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {

            if (txtFilter.Text.Length == 0)
                load_grid(_sector_id, _staff_id);

        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                load_grid(_sector_id, _staff_id);
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            //export 



            int excel_row = 1;
            string file = @"C:\temp\sector_" + DateTime.Now.ToString("mss") + ".xlsx";

            //opening method 
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Add();
            Excel.Worksheet xlWorksheet = xlWorkbook.Worksheets[1];



            xlApp.Visible = false; //make it visible
            //xlApp.WindowState = Excel.XlWindowState.xlMaximized;
            //get the users name
            string user = "select forename + ' ' + surname FROM [user_info].dbo.[user] where id = " + _staff_id;
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(user, conn))
                    user = cmd.ExecuteScalar().ToString();

                conn.Close();
            }

            xlWorksheet.Cells[1][excel_row].Value2 = user + " - " + lblSector.Text;
            //make the header blue
            xlWorksheet.Cells[1][excel_row].Interior.Color = Excel.XlRgbColor.rgbLightSkyBlue;
            //font formats
            xlWorksheet.Cells[1][excel_row].Font.Size = 15;

            xlWorksheet.Cells[1][excel_row].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            //merge this ^^^
            xlWorksheet.Range[xlWorksheet.Cells[1, 1], xlWorksheet.Cells[1, dgvSector.Columns.Count]].Merge();



            //main body of changes and stuff goes here 

            //first row needs to sector label + person


            excel_row++;

            //fill the first row with the dt headers
            for (int column_index = 0; column_index < dgvSector.Columns.Count; column_index++)
            {
                xlWorksheet.Cells[column_index + 1][excel_row].Value2 = dgvSector.Columns[column_index].HeaderText.ToString();

                //make the header blue
                xlWorksheet.Cells[column_index + 1][excel_row].Interior.Color = Excel.XlRgbColor.rgbLightSkyBlue;
                //font formats
                xlWorksheet.Cells[column_index + 1][excel_row].Font.Size = 12;
            }

            //add the filter
            // xlWorksheet.Cells[2][excel_row].Autofilter(1);


            //int contact_name_index = dgvSector.Columns["Contact Name"].Index + 1;
            //int allocated_to_index = dgvSector.Columns["Allocated to"].Index + 1;
            //int sector_index = dgvSector.Columns["Sector"].Index + 1;
            //int customer_added_by_index = dgvSector.Columns["Customer Added By"].Index + 1;
            //int customer_added_date_index = dgvSector.Columns["Customer Added Date"].Index + 1;
            //int correspondence_date_index = dgvSector.Columns["Correspondence Date"].Index + 1;

            excel_row++;

            //fill the sheet with the data from the datatable
            for (int row_index = 0; row_index < dgvSector.Rows.Count; row_index++)
            {

                for (int col_index = 0; col_index < dgvSector.Columns.Count; col_index++)
                {
                    xlWorksheet.Cells[col_index + 1][excel_row].Value2 = dgvSector.Rows[row_index].Cells[col_index].Value.ToString();
                    if (dgvSector.Rows[row_index].DefaultCellStyle.BackColor != Color.Empty)
                        xlWorksheet.Cells[col_index + 1][excel_row].Interior.Color = dgvSector.Rows[row_index].DefaultCellStyle.BackColor;

                }

                excel_row++;
            }

            //vv change cell values 



            //formatting examples 

            //xlWorkSheet.Range["H2:H300"].NumberFormat = "£#,###,###.00"; < formats into currency 

            //xlWorksheet.Range["A1:D1"].Merge(); merging cells 

            //xlWorksheet.Range["A1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft; < alignment 

            //xlWorksheet.Range["A1"].Cells.Font.Size = 22; < font size 



            ////auto fit and rows  
            //Microsoft.Office.Interop.Excel.Worksheet ws = xlApp.ActiveWorkbook.Worksheets[1]; 
            Microsoft.Office.Interop.Excel.Range range = xlWorksheet.UsedRange;

            //xlWorksheet.Columns.ClearFormats(); 
            //xlWorksheet.Rows.ClearFormats(); 

            xlWorksheet.Columns.AutoFit();
            xlWorksheet.Rows.AutoFit();

            //get the index of
            if (tabControl.TabPages[tabControl.SelectedIndex].Text == "Correspondence")
            {
                int notes_index = dgvSector.Columns["Notes"].Index + 1;
                xlWorksheet.Columns[notes_index].ColumnWidth = 50;
                xlWorksheet.Columns[notes_index].WrapText = true;
            }
            else if (tabControl.TabPages[tabControl.SelectedIndex].Text == "Quotation Chasing")
            {
                int chase_notes_index = dgvSector.Columns["Chase Notes"].Index + 1;
                xlWorksheet.Columns[chase_notes_index].ColumnWidth = 50;
                xlWorksheet.Columns[chase_notes_index].WrapText = true;

                int value_index = dgvSector.Columns["Value"].Index + 1;
                xlWorksheet.Columns[value_index].Style = "Currency";



            }



            //colours and other formatting
            //reset excel row for the formatting


            //border active cells 
            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            range.Borders.Color = ColorTranslator.ToOle(Color.Black);



            xlWorksheet.Activate();
            xlWorksheet.Application.ActiveSheet.Rows[3].Select();
            xlWorksheet.Application.ActiveWindow.FreezePanes = true;


            //Set print margins 
            Excel.PageSetup xlPageSetUp = xlWorksheet.PageSetup;
            xlPageSetUp.Zoom = false;
            xlPageSetUp.FitToPagesWide = 1;
            xlPageSetUp.FitToPagesTall = false;
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




        //release objects void 

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
