﻿
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
using System.Windows.Forms;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;

namespace PriceMaster
{
    public partial class frmSectorHistory : Form
    {

        public int clear_tabs { get; set; }

        public frmSectorHistory()
        {
            InitializeComponent();

            clear_tabs = 0;

            fill_sector();


        }

        private void fill_sector()
        {
            //string sql = "select distinct sector FROM [order_database].dbo.sales_table " +
            //    "where (sales_member_one = " + CONNECT.staffID + " or sales_member_two = " + CONNECT.staffID + " or sales_member_three = " + CONNECT.staffID + ")";

            string sql = "select distinct sector FROM [order_database].dbo.view_sales_table_grouped  where sales_member_id = " + CONNECT.staffID + " AND achieved > 0";


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
                        cmbSector.Items.Add(row[0].ToString());
                    }


                }


                conn.Close();
            }

        }

        private void validate_tab_pages()
        {

            if (clear_tabs == -1)
            {
                tabControl.TabPages.Clear();

                using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                {
                    conn.Open();

                    int staff_id = CONNECT.staffID;

                    string sql_correspondence = "select q.id FROM [order_database].dbo.quotation_chase_customer q " +
                        "left join [order_database].dbo.sales_table s on q.sector_id = s.id " +
                        "where sector = '" + cmbSector.Text + "' and correspondence_by = " + staff_id;

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
                     "where sector = '" + cmbSector.Text + "' AND chased_by = " + staff_id + " " +
                     "union all " +
                     "select q.id " +
                     "FROM [order_database].dbo.quotation_chase_log q " +
                     "left join [order_database].dbo.sales_table s on q.sector_id = s.id " +
                     "left join [order_database].dbo.solidworks_quotation_log sq on q.quote_id = sq.quote_id " +
                     "where sector = '" + cmbSector.Text + "' AND chased_by = " + staff_id;

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
                        "left join [order_database].dbo.sales_table st on s.sector_id = st.id " +
                        "where sector = '" + cmbSector.Text + "' AND lead_by = " + staff_id;

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
                    clear_tabs = 0;
                }
            }
        }

        private void load_grid()
        {
            if (tabControl.SelectedIndex < 0)
                return;

            int staff = CONNECT.staffID;

            string sql_correspondence = "select q.id,date_created [Correspondence Date], rtrim(customer_name) as [Customer],Contact,body as [Notes]," +
                //"CASE WHEN issue_with_leadtime = 0 THEN CAST(0 AS BIT) WHEN issue_with_leadtime IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Leadtime Issue]," +
                //"CASE WHEN issue_with_quote_turnaround_time = 0 THEN CAST(0 AS BIT) WHEN issue_with_quote_turnaround_time IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Quote Turnaround Issue]," +
                //"CASE WHEN issue_with_product = 0 THEN CAST(0 AS BIT) WHEN issue_with_product IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Product Issue]," +
                //"CASE WHEN issue_with_installation = 0 THEN CAST(0 AS BIT) WHEN issue_with_installation IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Installation Issue]," +
                //"CASE WHEN issue_with_service = 0 THEN CAST(0 AS BIT) WHEN issue_with_service IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Service Issue]," +
                "next_correspondence_date [Next Correspondence], Sector " +
                "FROM [order_database].dbo.quotation_chase_customer q " +
                "left join [order_database].dbo.sales_table s on q.sector_id = s.id " +
                "where sector = '" + cmbSector.Text + "' and correspondence_by = " + staff;


            string sql_quotations = "select q.id,chase_date as [Chase Date],'SL' + CAST(q.quote_id as nvarchar(max)) as [Quote ID],Name as Customer,chase_description as [Chase Notes]," +
                "CASE WHEN phone = 0 THEN CAST(0 AS BIT) WHEN phone IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS Phone, " +
                "CASE WHEN email = 0 THEN CAST(0 AS BIT) WHEN email IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS Email, " +
                "CASE WHEN chase_complete = 0 THEN CAST(0 AS BIT) WHEN chase_complete IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END as [Chase Complete], " +
                "Sector " +
                "FROM [order_database].dbo.quotation_chase_log_slimline q " +
                "left join [order_database].dbo.sales_table s on q.sector_id = s.id " +
                "left join[price_master].dbo.[sl_quotation] sq on q.quote_id = sq.quote_id " +
                "left join[dsl_fitting].dbo.sales_ledger sl on sq.customer_acc_ref = sl.ACCOUNT_REF " +
                "where sector = '" + cmbSector.Text + "' AND chased_by = " + staff + " AND sq.highest_issue = -1" +
                "union all " +
                "select q.id,chase_date as [Chase Date],CAST(q.quote_id as nvarchar(max)) as [Quote ID],Customer,chase_description as [Chase Notes], " +
                "CASE WHEN phone = 0 THEN CAST(0 AS BIT) WHEN phone IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS Phone, " +
                "CASE WHEN email = 0 THEN CAST(0 AS BIT) WHEN email IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS Email, " +
                "CASE WHEN chase_complete = 0 THEN CAST(0 AS BIT) WHEN chase_complete IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END as [Chase Complete], " +
                "Sector " +
                "FROM [order_database].dbo.quotation_chase_log q " +
                "left join [order_database].dbo.sales_table s on q.sector_id = s.id " +
                "left join (select q.quote_id,q.customer FROM [order_database].dbo.solidworks_quotation_log q " +
                        "right join [order_database].dbo.view_solidworks_max_rev r on q.quote_id = r.quote_id AND q.revision_number = r.revision_number) sq on q.quote_id = sq.quote_id " +
                "where sector = '" + cmbSector.Text + "' AND chased_by = " + staff;

            string sql_lead = "select s.id,lead_date as [Lead Date],Customer,contact_name as [Contact Name],contact_details as [Contact Details]," +
                "u.forename + ' ' + u.surname as [Allocated to],sector,notes as [Lead Notes]" +
                "FROM [order_database].dbo.sales_new_leads s " +
                "left join [user_info].dbo.[user] u on s.allocated_to = u.id " +
                "left join [order_database].dbo.sales_table st on s.sector_id = st.id " +
                "where sector = '" + cmbSector.Text + "' AND lead_by = " + staff;


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

            }

            //distinct formatting
            if (tabControl.TabPages[tabControl.SelectedIndex].Text == "Correspondence")
            {
                dgvSector.Columns[0].Visible = false;
                dgvSector.Columns[6].Visible = false;
                dgvSector.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else if (tabControl.TabPages[tabControl.SelectedIndex].Text == "Quotation Chasing")
            {
                dgvSector.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvSector.Columns[0].Visible = false;
                dgvSector.Columns[8].Visible = false;
            }
            else if (tabControl.TabPages[tabControl.SelectedIndex].Text == "Leads")
            {
                dgvSector.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvSector.Columns[0].Visible = false;
                dgvSector.Columns[6].Visible = false;

            }
            dgvSector.ClearSelection();
        }

        private void cmbSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            clear_tabs = -1;
            validate_tab_pages();
            load_grid();

        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            //clear_tabs = -1;
            // validate_tab_pages();
            load_grid();
            format_grid();
        }

        private void dgvSector_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tabControl.TabPages[tabControl.SelectedIndex].Text == "Correspondence")
            {
                //customer name / slimline

                //get the cust acc ref

                DialogResult result = MessageBox.Show("Is this a slimline correspondence?", "SLIMLINE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                int slimline = 0;

                if (result == DialogResult.Yes)
                    slimline = -1;

                frmChaseInsertCorrespondence frm = new frmChaseInsertCorrespondence(dgvSector.Rows[e.RowIndex].Cells[2].Value.ToString(), slimline);
                frm.ShowDialog();
                //Convert.ToInt32(dgvSector.Rows[e.RowIndex].Cells[0].Value.ToString()), dgvSector.Rows[e.RowIndex].Cells[2].Value.ToString());

            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            if (dgvSector.Rows.Count == 0)
                return;


            string file = @"C:\temp\jacks_customers" + DateTime.Now.ToString("mm_ss") + ".xlsx";

            int currentExcelRow = 0;


            //opening method 

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Add(); //xlApp.Workbooks.Open(GT_input_filepath, 0, false); //< to open an already existing file 
            Excel.Worksheet xlWorksheet = xlWorkbook.Worksheets[1];



            xlApp.Visible = true; //make it visible for now 

            xlApp.WindowState = Excel.XlWindowState.xlMaximized;

            //xlWorksheet.Range["A1"].Value2 = "Target"; 

            //xlWorksheet.Cells[1][excel_row].Value2 = 22; 

            currentExcelRow++;
            for (int i = 0; i < dgvSector.Columns.Count; i++)
            {
                xlWorksheet.Cells[currentExcelRow, i + 1] = dgvSector.Columns[i].HeaderText;

                xlWorksheet.Cells[currentExcelRow, i + 1].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                xlWorksheet.Cells[currentExcelRow, i + 1].Font.Size = 15;
                xlWorksheet.Cells[currentExcelRow, i + 1] .Interior.Color = Color.LightSkyBlue;

            }

            currentExcelRow++;

            for (int row_loop = 0; row_loop < dgvSector.Rows.Count; row_loop++)
            {
                for (int column_loop = 0; column_loop < dgvSector.Columns.Count; column_loop++)
                {

                    xlWorksheet.Cells[currentExcelRow, column_loop + 1] = dgvSector.Rows[row_loop].Cells[column_loop].Value.ToString();

                }
                currentExcelRow++;
            }


            //formatting examples 



            //xlWorkSheet.Range["H2:H300"].NumberFormat = "£#,###,###.00"; < formats into currency 

            //xlWorksheet.Range["A1:D1"].Merge(); merging cells 

            //xlWorksheet.Range["A1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft; < alignment 

            //xlWorksheet.Range["A1"].Cells.Font.Size = 22; < font size 



            //auto fit and rows  

            //Microsoft.Office.Interop.Excel.Worksheet ws = xlApp.ActiveWorkbook.Worksheets[1]; 

            Microsoft.Office.Interop.Excel.Range range = xlWorksheet.UsedRange;

            //xlWorksheet.Columns.ClearFormats(); 

            //xlWorksheet.Rows.ClearFormats(); 

            xlWorksheet.Columns.AutoFit();

            xlWorksheet.Rows.AutoFit();


            if (tabControl.TabPages[tabControl.SelectedIndex].Text == "Correspondence")
            {
                xlWorksheet.Columns[5].ColumnWidth = 98.14; //size and wrap columns 
                xlWorksheet.Columns[5].WrapText = true;
            }
            else if (tabControl.TabPages[tabControl.SelectedIndex].Text == "Quotation Chasing")
            {
                xlWorksheet.Columns[4].ColumnWidth = 98.14; //size and wrap columns 
                xlWorksheet.Columns[4].WrapText = true;
            }
            else if (tabControl.TabPages[tabControl.SelectedIndex].Text == "Leads")
            {
                xlWorksheet.Columns[5].ColumnWidth = 98.14; //size and wrap columns 
                xlWorksheet.Columns[5].WrapText = true;
            }


            //border active cells 

            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous; 

            range.Borders.Color = ColorTranslator.ToOle(Color.Black);

            Microsoft.Office.Interop.Excel.Range columnA = xlWorksheet.Columns["A"];
            // Delete the column and shift cells to the left
            columnA.Delete(Microsoft.Office.Interop.Excel.XlDeleteShiftDirection.xlShiftToLeft);

            //xlWorkSheet.Columns[3].ColumnWidth = 98.14; //size and wrap columns 

            //xlWorkSheet.Columns[3].WrapText = true; 



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
