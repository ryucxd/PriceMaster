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
using Excel = Microsoft.Office.Interop.Excel;

namespace PriceMaster
{
    public partial class frmLeadReport : Form
    {
        public frmLeadReport()
        {
            InitializeComponent();

            dteStart.Value = dteStart.Value.AddMonths(-1);

            fillGrid();


            string sql = " SELECT distinct forename + ' ' + surname FROM [order_database].dbo.sales_new_leads s " +
                "left join [user_info].dbo.[user] u on s.prospect_added_by = u.id " +
                "where forename + ' ' + surname is not null ";

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
                        cmbProspectAddedBy.Items.Add(row[0].ToString());
                    }
                }

                conn.Close();
            }


        }


        public void fillGrid()
        {

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                string sql = "select lead_date as [Lead Date]," +
                "case when s.name is null then sl.customer else s.NAME end as [Lead Customer]," +
                "sl.contact_name as [Contact Name]," +
                "u_allocated.forename + ' ' + u_allocated.surname as [Allocated to]," +
                "v.Sector," +
                "u_added_by.forename + ' ' + u_added_by.surname as [Customer Added By]," +
                "prospect_added_date as [Customer Added Date], " +
                "correspondence_date as [Correspondence Date]" +
                "FROM [order_database].dbo.sales_new_leads sl " +
                "left join [order_database].dbo.[SALES_LEDGER_PROSPECT] s on sl.prospect_acc_ref = s.ACCOUNT_REF " +
                "left join [order_database].dbo.[view_sales_table] v on sl.sector_id = v.id " +
                "left join [user_info].dbo.[user] u_allocated on sl.allocated_to = u_allocated.id " +
                "left join [user_info].dbo.[user] u_added_by on sl.prospect_added_by = u_added_by.id " +
                "left join (select customer_name, min(date_created) as correspondence_date FROM [order_database].dbo.[quotation_chase_customer] q " +
                "           group by customer_name) as q on s.NAME = q.customer_name " +
                "WHERE (sl.prospect_acc_ref is null or sl.prospect_acc_ref <> 'corey') and " +
                "lead_date >= '" + dteStart.Value.ToString("yyyyMMdd") + "' AND lead_date <= '" + dteEnd.Value.ToString("yyyyMMdd") + "' ";


                if (chkAddedLeads.Checked)
                {
                    sql += " AND prospect_added_by is not null ";
                }


                if (cmbProspectAddedBy.Text.Length > 0)
                {
                    string sql_user = "select id FROM [user_info].dbo.[user] where forename + ' ' + surname = '" + cmbProspectAddedBy.Text + "'";
                    using (SqlCommand cmd = new SqlCommand(sql_user, conn))
                    {
                        sql += " AND prospect_added_by = " + cmd.ExecuteScalar().ToString();
                    }

                }


                sql += " ORDER by lead_date desc";




                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;

                    //get the % of added leads + leads corresponded with

                    double percent_added = 0;
                    double percent_contacted = 0;

                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["Customer Added By"].ToString().Length > 0)
                            percent_added++;
                        if (dr["Correspondence Date"].ToString().Length > 0)
                            percent_contacted++;

                    }

                    if (percent_added > 0)
                        percent_added = Math.Round(((percent_added / dt.Rows.Count) * 100), 2);
                    if (percent_contacted > 0)
                        percent_contacted = Math.Round(((percent_contacted / dt.Rows.Count) * 100), 2);

                    //labels
                    lblAdded.Text = "Leads added: " + percent_added.ToString() + "%";
                    lblCorrespondence.Text = "Leads added and contacted: " + percent_contacted.ToString() + "%";
                }

                conn.Close();
            }

            format();
        }

        public void format()
        {

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            dataGridView1.Columns["Lead Customer"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void dteStart_CloseUp(object sender, EventArgs e)
        {
            fillGrid();
        }

        private void dteEnd_CloseUp(object sender, EventArgs e)
        {
            fillGrid();
        }

        private void chkAddedLeads_CheckedChanged(object sender, EventArgs e)
        {
            fillGrid();
        }

        private void cmbProspectAddedBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillGrid();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

            int excel_row = 1;
            string file = @"C:\temp\correspondence_" + DateTime.Now.ToString("mss") + ".xlsx";

            //opening method 
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Add();
            Excel.Worksheet xlWorksheet = xlWorkbook.Worksheets[1];



            xlApp.Visible = false; //make it visible
            //xlApp.WindowState = Excel.XlWindowState.xlMaximized;



            //main body of changes and stuff goes here 

            //fill the first row with the dt headers
            for (int column_index = 0; column_index < dataGridView1.Columns.Count; column_index++)
            {
                xlWorksheet.Cells[column_index + 1][excel_row].Value2 = dataGridView1.Columns[column_index].HeaderText.ToString();

                //make the header blue
                xlWorksheet.Cells[column_index + 1][excel_row].Interior.Color = Excel.XlRgbColor.rgbLightSkyBlue;
                //font formats
                xlWorksheet.Cells[column_index + 1][excel_row].Font.Size = 12;
            }

            //add the filter
            xlWorksheet.Cells[1 ][excel_row].Autofilter(1);

            //get the index of
            int lead_date_index = dataGridView1.Columns["Lead Date"].Index + 1;
            int lead_customer_index = dataGridView1.Columns["Lead Customer"].Index + 1;
            int contact_name_index = dataGridView1.Columns["Contact Name"].Index + 1;
            int allocated_to_index = dataGridView1.Columns["Allocated to"].Index + 1;
            int sector_index = dataGridView1.Columns["Sector"].Index + 1;
            int customer_added_by_index = dataGridView1.Columns["Customer Added By"].Index + 1;
            int customer_added_date_index = dataGridView1.Columns["Customer Added Date"].Index + 1;
            int correspondence_date_index = dataGridView1.Columns["Correspondence Date"].Index + 1;

            excel_row++;

            //fill the sheet with the data from the datatable
            for (int row_index = 0; row_index < dataGridView1.Rows.Count; row_index++)
            {

                for (int col_index = 0; col_index < dataGridView1.Columns.Count; col_index++)
                {
                    xlWorksheet.Cells[col_index + 1][excel_row].Value2 = dataGridView1.Rows[row_index].Cells[col_index].Value.ToString();
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


            //specific sizing
            //xlWorksheet.Columns[customer_index].ColumnWidth = 17.71; //size and wrap columns 
            //xlWorksheet.Columns[customer_index].WrapText = true;


            //xlWorksheet.Columns[coresspondence_by_index].ColumnWidth = 17.71; //size and wrap columns 
            //xlWorksheet.Columns[coresspondence_by_index].WrapText = true;


            //xlWorksheet.Columns[correspondence_notes_index].ColumnWidth = 75; //size and wrap columns 
            //xlWorksheet.Columns[correspondence_notes_index].WrapText = true;


            //xlWorksheet.Columns[lead_time_index].ColumnWidth = 9.14; //size and wrap columns 
            //xlWorksheet.Columns[lead_time_index].WrapText = true;


            //xlWorksheet.Columns[quote_turnaround_index].ColumnWidth = 14.71; //size and wrap columns 
            //xlWorksheet.Columns[quote_turnaround_index].WrapText = true;


            //xlWorksheet.Columns[product_index].ColumnWidth = 9.14; //size and wrap columns 
            //xlWorksheet.Columns[product_index].WrapText = true;


            //xlWorksheet.Columns[installation_index].ColumnWidth = 10.43; //size and wrap columns 
            //xlWorksheet.Columns[installation_index].WrapText = true;


            //xlWorksheet.Columns[service_index].ColumnWidth = 9.14; //size and wrap columns 
            //xlWorksheet.Columns[service_index].WrapText = true;



            //colours and other formatting
            //reset excel row for the formatting
            excel_row = 1;

            //headers formatting
            for (int column_index = 0; column_index < dataGridView1.Columns.Count; column_index++)
            {
                xlWorksheet.Cells[column_index + 1][excel_row].Value2 = dataGridView1.Columns[column_index].HeaderText.ToString();
            }


            //border active cells 
            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            range.Borders.Color = ColorTranslator.ToOle(Color.Black);



            xlWorksheet.Activate();
            xlWorksheet.Application.ActiveWindow.SplitRow = 1;
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
