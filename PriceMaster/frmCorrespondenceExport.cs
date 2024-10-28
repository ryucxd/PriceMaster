

using stdole;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace PriceMaster
{
    public partial class frmCorrespondenceExport : Form
    {
        public frmCorrespondenceExport()
        {
            InitializeComponent();

            cmbType.SelectedIndex = 0;


            //fill the user combobox
            string sql = "select distinct forename + ' ' + surname as fullname FROM [order_database].dbo.quotation_chase_customer c " +
                "left join [user_info].dbo.[user] u on c.correspondence_by = u.id " +
                "where (u.id <> 138 AND u.id <> 389 and u.id <> 260) " +
                "order by forename + ' ' + surname";
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    foreach (DataRow dr in dt.Rows)
                    {
                        cmbUser.Items.Add(dr[0].ToString());
                    }
                }


                //fill the customer combobox
                sql = "select distinct customer_name FROM [order_database].dbo.quotation_chase_customer";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    foreach (DataRow dr in dt.Rows)
                    {
                        cmbCustomer.Items.Add(dr[0].ToString());
                    }
                }


                conn.Close();
            }


            dteStart.Value = dteStart.Value.AddMonths(-1);

            cmbCustomer.SelectedIndex = 0;
            cmbUser.SelectedIndex = 0;

        }

        public void export()
        {
            txtContact.Text = txtContact.Text.Replace("'", "");
            //txtCustomer.Text = txtCustomer.Text.Replace("'", "");
            txtCorrespondence.Text = txtCorrespondence.Text.Replace("'", "");


            //build the sql string
            string sql = "select RTRIM(customer_name) as [Customer],u.forename + ' ' + u.surname as [Correspondence By],date_created as [Correspondence Date],body as [Correspondence Notes]," +
                "CASE WHEN no_follow_up = 0 then convert(varchar(10),next_correspondence_date , 103)  else 'No follow Up'end as [Next Correspondence]," +
                "CASE WHEN q.email = 0 THEN CAST(0 AS BIT) WHEN q.email IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Email] ," +
                "CASE WHEN phone = 0 THEN CAST(0 AS BIT) WHEN phone IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Phone] ," +
                "CASE WHEN inPerson = 0 THEN CAST(0 AS BIT) WHEN inPerson IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [in Person] ," +
                "Contact," +
                "CASE WHEN issue_with_leadtime = 0 THEN CAST(0 AS BIT) WHEN issue_with_leadtime IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Issue with leadtime] ," +
                "CASE WHEN issue_with_quote_turnaround_time = 0 THEN CAST(0 AS BIT) WHEN issue_with_quote_turnaround_time IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Issue with quote turnaround time] ," +
                "CASE WHEN issue_with_product = 0 THEN CAST(0 AS BIT) WHEN issue_with_product IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Issue with product]," +
                "CASE WHEN issue_with_installation = 0 THEN CAST(0 AS BIT) WHEN issue_with_installation IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Issue with installation] ," +
                "CASE WHEN issue_with_service = 0 THEN CAST(0 AS BIT) WHEN issue_with_service IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Issue with service] , " +
                "CASE WHEN complete = 0 THEN CAST(0 AS BIT) WHEN complete IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Complete] " +
                ",q.Slimline from [order_database].dbo.quotation_chase_customer q " +
                "left join [user_info].dbo.[user] u on q.correspondence_by = u.id " +
                "where date_created >= '" + dteStart.Value.ToString("yyyyMMdd") + "' AND date_created <= '" + dteEnd.Value.ToString("yyyyMMdd") + "'   AND ";


            //start building the WHERE statement based on the selection
            if (cmbCustomer.Text != "ALL")
                if (cmbCustomer.Text.Length > 0)
                    sql += "customer_name = '" + cmbCustomer.Text + "'   AND ";

            if (txtContact.Text.Length > 0)
                sql += "contact LIKE '%" + txtContact.Text + "%'   AND ";

            if (cmbType.Text == "Traditional")
                sql += "q.slimline = 0   AND ";
            else if (cmbType.Text == "Slimline")
                sql += "q.slimline = -1   AND ";


            //contacts
            string contact_string = "";
            if (chkEmail.Checked)
                contact_string += "q.email = -1  OR ";
            if (chkPhone.Checked)
                contact_string += "q.phone = -1  OR ";
            if (chkPerson.Checked)
                contact_string += "q.inPerson = -1  OR ";

            if (contact_string.Length > 0)
            {
                contact_string = contact_string.Substring(0, contact_string.Length - 4);
                sql += "(" + contact_string + ")  AND ";
            }

            //issues
            string issues_string = "";
            if (chkLeadTime.Checked)
                issues_string += "issue_with_leadtime = -1  OR ";
            if (chkQuoteTurnAround.Checked)
                issues_string += "issue_with_quote_turnaround_time = -1  OR ";
            if (chkProduct.Checked)
                issues_string += "issue_with_product = -1  OR ";
            if (chkInstallation.Checked)
                issues_string += "issue_with_installation = -1  OR ";
            if (chkService.Checked)
                issues_string += "issue_with_service = -1  OR ";

            if (issues_string.Length > 0)
            {
                issues_string = issues_string.Substring(0, issues_string.Length - 4);
                sql += "(" + issues_string + ")  AND ";
            }

            if (txtCorrespondence.Text.Length > 0)
                sql += "body LIKE '%" + txtCorrespondence.Text + "%'   AND ";

            //correspondence by
            if (cmbUser.Text != "ALL")
                if (cmbUser.Text.Length > 0)
                {
                    //get the user 
                    string user_sql = "SELECT id FROM [user_info].dbo.[user] where forename + ' ' + surname = '" + cmbUser.Text + "'";

                    using (SqlConnection userCONN = new SqlConnection(CONNECT.ConnectionString))
                    {
                        userCONN.Open();

                        using (SqlCommand userCMD = new SqlCommand(user_sql, userCONN))
                        {
                            var fuga = userCMD.ExecuteScalar();

                            if (fuga != null)
                                sql += "q.correspondence_by = " + fuga + "   AND ";

                        }

                        userCONN.Close();
                    }
                }

            //REMOVE the last 6 characters
            sql = sql.Substring(0, sql.Length - 6);

            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }

                conn.Close();
            }

            //nasty excel stuff here using dt
            int excel_row = 1;
            string file = @"C:\temp\correspondence_" + DateTime.Now.ToString("mss") + ".xlsx";

            //opening method 
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Add();
            Excel.Worksheet xlWorksheet = xlWorkbook.Worksheets[1];

            //xlApp.Visible = true; //make it visible
            //xlApp.WindowState = Excel.XlWindowState.xlMaximized;



            //main body of changes and stuff goes here 

            //fill the first row with the dt headers
            for (int column_index = 0; column_index < dt.Columns.Count; column_index++)
            {
                xlWorksheet.Cells[column_index + 1][excel_row].Value2 = dt.Columns[column_index].ColumnName.ToString();

                //make the header blue
                xlWorksheet.Cells[column_index + 1][excel_row].Interior.Color = Excel.XlRgbColor.rgbLightSkyBlue;
                //font formats
                xlWorksheet.Cells[column_index + 1][excel_row].Font.Size = 12;
            }

            //add the filter
            xlWorksheet.Cells[1][excel_row].Autofilter(1);

            //get the index of
            int customer_index = dt.Columns.IndexOf("Customer") + 1;
            int coresspondence_by_index = dt.Columns.IndexOf("Correspondence By") + 1;
            int correspondence_notes_index = dt.Columns.IndexOf("Correspondence Notes") + 1;
            int lead_time_index = dt.Columns.IndexOf("Issue with leadtime") + 1;
            int quote_turnaround_index = dt.Columns.IndexOf("Issue with quote turnaround time") + 1;
            int product_index = dt.Columns.IndexOf("Issue with product") + 1;
            int installation_index = dt.Columns.IndexOf("Issue with installation") + 1;
            int service_index = dt.Columns.IndexOf("Issue with service") + 1;
            int contact_index = dt.Columns.IndexOf("Contact") + 1;

            excel_row++;

            //fill the sheet with the data from the DT
            for (int row_index = 0; row_index < dt.Rows.Count; row_index++)
            {

                for (int col_index = 0; col_index < dt.Columns.Count; col_index++)
                {
                    xlWorksheet.Cells[col_index + 1][excel_row].Value2 = dt.Rows[row_index][col_index].ToString();

                    if (col_index + 1 == lead_time_index || col_index + 1 == quote_turnaround_index ||
                       col_index + 1 == product_index || col_index + 1 == installation_index ||
                       col_index + 1 == service_index)
                    {
                        xlWorksheet.Cells[col_index + 1][excel_row].Interior.Color = getColour(dt.Rows[row_index][col_index].ToString());
                    }
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
            xlWorksheet.Columns[customer_index].ColumnWidth = 17.71; //size and wrap columns 
            xlWorksheet.Columns[customer_index].WrapText = true;


            xlWorksheet.Columns[coresspondence_by_index].ColumnWidth = 17.71; //size and wrap columns 
            xlWorksheet.Columns[coresspondence_by_index].WrapText = true;


            xlWorksheet.Columns[correspondence_notes_index].ColumnWidth = 60; //size and wrap columns 
            xlWorksheet.Columns[correspondence_notes_index].WrapText = true;


            xlWorksheet.Columns[lead_time_index].ColumnWidth = 9.14; //size and wrap columns 
            xlWorksheet.Columns[lead_time_index].WrapText = true;


            xlWorksheet.Columns[quote_turnaround_index].ColumnWidth = 14.71; //size and wrap columns 
            xlWorksheet.Columns[quote_turnaround_index].WrapText = true;


            xlWorksheet.Columns[product_index].ColumnWidth = 9.14; //size and wrap columns 
            xlWorksheet.Columns[product_index].WrapText = true;


            xlWorksheet.Columns[installation_index].ColumnWidth = 10.43; //size and wrap columns 
            xlWorksheet.Columns[installation_index].WrapText = true;


            xlWorksheet.Columns[service_index].ColumnWidth = 9.14; //size and wrap columns 
            xlWorksheet.Columns[service_index].WrapText = true;

            xlWorksheet.Columns[contact_index].ColumnWidth = 12.29; //size and wrap columns 
            xlWorksheet.Columns[contact_index].WrapText = true;



            //colours and other formatting
            //reset excel row for the formatting
            excel_row = 1;

            //headers formatting
            for (int column_index = 0; column_index < dt.Columns.Count; column_index++)
            {
                xlWorksheet.Cells[column_index + 1][excel_row].Value2 = dt.Columns[column_index].ColumnName.ToString();
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

        public Excel.XlRgbColor getColour(string piyo)
        {

            if (piyo == "True")
                return Excel.XlRgbColor.rgbPaleVioletRed;
            else
                return Excel.XlRgbColor.rgbLightGreen;


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

        private void btnExport_Click(object sender, EventArgs e)
        {
            export();
        }
    }
}
