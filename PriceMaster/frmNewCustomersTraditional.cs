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
using System.Data.Common;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.IO;

namespace PriceMaster.TraditionalChasing
{
    public partial class frmNewCustomersTraditional : Form
    {
        public int customer_index { get; set; }
        public int first_date_ordered_index { get; set; }
        public int first_door_ordered_index { get; set; }
        public int total_value_index { get; set; }

        public int last_order { get; set; }
        public int total_value { get; set; }
        public int slimline { get; set; }
        public int dateFilter { get; set; }
        public frmNewCustomersTraditional(int _slimline)
        {
            InitializeComponent();

            dteFilterStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            load_grid();
            fill_combo();
        }

        private void fill_combo()
        {

        }

        private void load_grid()
        {
            

            string sql = "SELECT s.NAME,min_date,min(door_id) as min_door_id,sum(v.line_total) as value from [order_database].dbo.door d " +
                "left join [order_database].dbo.SALES_LEDGER s on d.customer_acc_ref = s.ACCOUNT_REF " +
                "left join [order_database].dbo.view_door_value v on d.door_id = v.id " +
                "right join (select  MIN(date_order) min_date, [NAME] FROM [order_database].dbo.door d " +
                "left join [order_database].dbo.SALES_LEDGER s on d.customer_acc_ref = s.ACCOUNT_REF " +
                "group by [NAME] ) AS grouped on d.date_order = grouped.min_date AND s.NAME = grouped.NAME " +
                "where v.line_total is not null and door_id is not null " +
                "AND  min_date >= '" + dteFilterStart.Value.ToString("yyyyMMdd") + "' AND min_date <= '" + dteFilterEnd.Value.ToString("yyyyMMdd") + "' " +
                "group by s.NAME,min_date order by name";


            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    //try
                    //{
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvNonReturningCustomers.DataSource = dt;
                    //}
                    //catch
                    //{ }

                }

                conn.Close();
            }
            column_index();
            format();
        }
        private void column_index()
        {
            customer_index = dgvNonReturningCustomers.Columns["NAME"].Index;
            first_date_ordered_index = dgvNonReturningCustomers.Columns["min_date"].Index;
            first_door_ordered_index = dgvNonReturningCustomers.Columns["min_door_id"].Index;
            //slimline_index = dgvNonReturningCustomers.Columns["slimline"].Index;
            total_value_index = dgvNonReturningCustomers.Columns["value"].Index;
        }
        private void format()
        {
           // dgvNonReturningCustomers.Columns[slimline_index].Visible = false;
            dgvNonReturningCustomers.Columns[customer_index].HeaderText = "Customer";
            dgvNonReturningCustomers.Columns[first_date_ordered_index].HeaderText = "First Order Date";
            dgvNonReturningCustomers.Columns[first_door_ordered_index].HeaderText = "Last Door Ordered";
            dgvNonReturningCustomers.Columns[total_value_index].HeaderText = "First Order Value";

            dgvNonReturningCustomers.Columns[total_value_index].DefaultCellStyle.Format = "c";

            foreach (DataGridViewColumn col in dgvNonReturningCustomers.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgvNonReturningCustomers.Columns[customer_index].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void dgvNonReturningCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //frmTraditionalNonReturningCustomerEmail frm = new frmTraditionalNonReturningCustomerEmail(Convert.ToInt32(dgvNonReturningCustomers.Rows[e.RowIndex].Cells[last_door_ordered_index].Value.ToString()));
            if (e.RowIndex < 0)
                return;

            frmChaseCustomerList frm = new frmChaseCustomerList(slimline, dgvNonReturningCustomers.Rows[e.RowIndex].Cells[customer_index].Value.ToString());
            frm.ShowDialog();
        }

        private void cmbCustomerSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_grid();
        }

        private void cmbCustomerSearch_TextChanged(object sender, EventArgs e)
        {
            load_grid();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            last_order = -1;
            total_value = 0;
            load_grid();
        }

        private void btnValue_Click(object sender, EventArgs e)
        {
            total_value = -1;
            last_order = 0;
            load_grid();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

            Process[] processesBefore = Process.GetProcessesByName("excel");

            object misValue = System.Reflection.Missing.Value;
            var xlApp = new Excel.Application();
            var xlWorkbooks = xlApp.Workbooks;
            var xlWorkbook = xlWorkbooks.Add(Type.Missing);
            var xlWorksheet = xlWorkbook.Sheets[1];

            Process[] processesAfter = Process.GetProcessesByName("excel");


            dgvNonReturningCustomers.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dgvNonReturningCustomers.SelectAll();

            DataObject dataObj = dgvNonReturningCustomers.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);

            // Paste clipboard results to worksheet range
            Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorksheet.Cells[2, 1];
            CR.Select();
            xlWorksheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);


            //headers
            xlWorksheet.Cells[1, 1].Value2 = "Non Returning Customers";
            xlWorksheet.Range["A1:D1"].Cells.Font.Size = 20;



            //xlWorksheet.Cells[2, 1].Value2 = "Customer";
            //xlWorksheet.Cells[2, 2].Value2 = "Last Date Ordered";
            //xlWorksheet.Cells[2, 3].Value2 = "Last Door Ordered";
            //xlWorksheet.Cells[2, 4].Value2 = "Historic Order Book Value";
            xlWorksheet.Range["A2:D2"].Interior.Color = System.Drawing.Color.LightSkyBlue;
            xlWorksheet.Range["A2:D2"].AutoFilter(1);
            xlWorksheet.Range["A2:D2"].Cells.Font.Size = 12;

            //formatting
            Microsoft.Office.Interop.Excel.Worksheet ws = xlApp.ActiveWorkbook.Worksheets[1];
            Microsoft.Office.Interop.Excel.Range range = ws.UsedRange;

            ws.Columns.AutoFit();
            ws.Rows.AutoFit();

            ws.Rows.Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignGeneral;
            ws.Rows.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            range.Borders.Color = ColorTranslator.ToOle(Color.Black);


            xlWorksheet.Range[xlWorksheet.Cells[1, 1], xlWorksheet.Cells[1, 4]].Merge();
            xlWorksheet.Cells[1, 1].VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignGeneral;
            xlWorksheet.Cells[1, 1].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            //print stuff
            var chase_pagesetup = xlWorksheet.PageSetup;
            chase_pagesetup.FitToPagesWide = 1;
            chase_pagesetup.FitToPagesTall = false;
            chase_pagesetup.Zoom = false;
            chase_pagesetup.Orientation = Excel.XlPageOrientation.xlLandscape;

            //close and save
            string fileName = @"C:\temp\Non_Returning_Customers_" + DateTime.Now.ToString("mm_ss") + ".xlsx";
            xlWorkbook.SaveAs(fileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault,
                misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
                misValue, misValue, misValue, misValue, misValue);
            xlApp.DisplayAlerts = true;
            xlWorkbook.Close(true, misValue, misValue);
            xlApp.Quit();

            xlApp.Quit();
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

            if (File.Exists(fileName))
                System.Diagnostics.Process.Start(fileName);


            Clipboard.Clear();
            dgvNonReturningCustomers.ClearSelection();

        }

        private void dteFilter_CloseUp(object sender, EventArgs e)
        {
            load_grid();
        }

        private void chkSlimline_CheckedChanged(object sender, EventArgs e)
        {
            load_grid();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void dteFilterEnd_CloseUp(object sender, EventArgs e)
        {
            load_grid();
        }
    }
}
