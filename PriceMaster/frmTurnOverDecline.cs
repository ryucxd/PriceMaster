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
using System.Data.Common;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.IO;

namespace PriceMaster.TraditionalChasing
{
    public partial class frmTurnOverDecline : Form
    {
        public int customer_index { get; set; }
        public int two_years_ago_index { get; set; } //named like this because they will undoubtably change over the years
        public int one_years_ago_index { get; set; }
        public int current_year_index { get; set; }
        public int value_decline_index { get; set; }

        public int last_order { get; set; }
        public int total_value { get; set; }
        public int slimline { get; set; }
        public frmTurnOverDecline(int _slimline)
        {
            InitializeComponent();

            last_order = -1;
            total_value = 0;
            slimline = _slimline;
            if (slimline == 0)
                chkSlimline.Checked = false;
            else
                chkSlimline.Checked = true;

            load_grid();
            fill_combo();
        }

        private void fill_combo()
        {
            foreach (DataGridViewRow row in dgvTurnOver.Rows)
            {
                if (cmbCustomerSearch.Items.Contains(row.Cells[0].Value.ToString()))
                { } //nothing
                else
                    cmbCustomerSearch.Items.Add(row.Cells[0].Value.ToString());
            }
        }

        private void load_grid()
        {
            string sql = "[order_database].dbo.[usp_sales_over_years]";

            string customer = cmbCustomerSearch.Text;

            



            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@slimline_y_n", SqlDbType.Int).Value = slimline;
                    cmd.Parameters.AddWithValue("@customer", SqlDbType.NVarChar).Value = customer;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    try
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvTurnOver.DataSource = dt;
                    }
                    catch
                    { }
                    
                }

                conn.Close();
            }
            column_index();
            format();
        }
        private void column_index()
        {
            customer_index = dgvTurnOver.Columns["NAME"].Index;
            two_years_ago_index = dgvTurnOver.Columns["two_years_ago"].Index;
            one_years_ago_index = dgvTurnOver.Columns["one_years_ago"].Index;
            current_year_index = dgvTurnOver.Columns["current_year"].Index;
            value_decline_index = dgvTurnOver.Columns["ValueDecline"].Index;
        }
        private void format()
        {
            dgvTurnOver.Columns[customer_index].HeaderText = "Customer";
            dgvTurnOver.Columns[two_years_ago_index].HeaderText = DateTime.Now.AddYears(-2).Year.ToString();
            dgvTurnOver.Columns[one_years_ago_index].HeaderText = DateTime.Now.AddYears(-1).Year.ToString();
            dgvTurnOver.Columns[current_year_index].HeaderText = DateTime.Now.Year.ToString();

            dgvTurnOver.Columns[two_years_ago_index].DefaultCellStyle.Format = "c";
            dgvTurnOver.Columns[one_years_ago_index].DefaultCellStyle.Format = "c";
            dgvTurnOver.Columns[current_year_index].DefaultCellStyle.Format = "c";
            dgvTurnOver.Columns[value_decline_index].DefaultCellStyle.Format = "c";

            foreach (DataGridViewColumn col in dgvTurnOver.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgvTurnOver.Columns[customer_index].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void dgvNonReturningCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //frmTraditionalNonReturningCustomerEmail frm = new frmTraditionalNonReturningCustomerEmail(Convert.ToInt32(dgvNonReturningCustomers.Rows[e.RowIndex].Cells[last_door_ordered_index].Value.ToString()));
            if (e.RowIndex < 0)
                return;

            frmChaseCustomerList frm = new frmChaseCustomerList(slimline, dgvTurnOver.Rows[e.RowIndex].Cells[customer_index].Value.ToString());
            frm.ShowDialog();
        }

        private void cmbCustomerSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_grid();
        }

        private void cmbCustomerSearch_TextChanged(object sender, EventArgs e)
        {
           // load_grid();
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


            dgvTurnOver.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dgvTurnOver.SelectAll();

            DataObject dataObj = dgvTurnOver.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);

            // Paste clipboard results to worksheet range
            Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorksheet.Cells[2, 1];
            CR.Select();
            xlWorksheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);


            //headers
            xlWorksheet.Cells[1, 1].Value2 = "Turn Over Decline";
            xlWorksheet.Range["A1:E1"].Cells.Font.Size = 20;



            //xlWorksheet.Cells[2, 1].Value2 = "Customer";
            //xlWorksheet.Cells[2, 2].Value2 = "Last Date Ordered";
            //xlWorksheet.Cells[2, 3].Value2 = "Last Door Ordered";
            //xlWorksheet.Cells[2, 4].Value2 = "Historic Order Book Value";
            xlWorksheet.Range["A2:E2"].Interior.Color = System.Drawing.Color.LightSkyBlue;
            xlWorksheet.Range["A2:E2"].AutoFilter(1);
            xlWorksheet.Range["A2:E2"].Cells.Font.Size = 12;

            //formatting
            Microsoft.Office.Interop.Excel.Worksheet ws = xlApp.ActiveWorkbook.Worksheets[1];
            Microsoft.Office.Interop.Excel.Range range = ws.UsedRange;

            ws.Columns.AutoFit();
            ws.Rows.AutoFit();

            ws.Rows.Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignGeneral;
            ws.Rows.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            range.Borders.Color = ColorTranslator.ToOle(Color.Black);


            xlWorksheet.Range[xlWorksheet.Cells[1, 1], xlWorksheet.Cells[1, 5]].Merge();
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
            dgvTurnOver.ClearSelection();

        }

        private void dteFilter_CloseUp(object sender, EventArgs e)
        {
            load_grid();
        }

        private void chkSlimline_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSlimline.Checked == true)
                slimline = -1;
            else
                slimline = 0;

            load_grid();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbCustomerSearch.Text = "";
            load_grid();
        }
    }
}
