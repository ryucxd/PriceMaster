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
    public partial class frmNonReturningCustomers : Form
    {
        public int customer_index { get; set; }
        public int last_date_ordered_index { get; set; }
        public int last_door_ordered_index { get; set; }
        public int slimline_index { get; set; }
        public int total_value_index { get; set; }

        public int last_order { get; set; }
        public int total_value { get; set; }
        public int slimline { get; set; }
        public int dateFilter { get; set; }
        public frmNonReturningCustomers(int _slimline)
        {
            InitializeComponent();
            dateFilter = 0;
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
            foreach (DataGridViewRow row in dgvNonReturningCustomers.Rows)
            {
                if (cmbCustomerSearch.Items.Contains(row.Cells[0].Value.ToString()))
                { } //nothing
                else
                    cmbCustomerSearch.Items.Add(row.Cells[0].Value.ToString());
            }
        }

        private void load_grid()
        {
            //old code
            //string sql = "select rtrim(a.Customer) as customer,cast([Last Date Ordered] as date) as last_date_ordered,[Last Door Ordered] as [last_Door_Ordered]," +
            //    "[Slimline Customer] as slimline,round(b.[value],2) as total_custoemr_value " +
            //    "from [order_database].dbo.POWERBI_non_returning_customers a " +
            //    "left join (select sum(v.line_total) as [value],[NAME] as customer  from [order_database].dbo.door d " +
            //    "left join [order_database].dbo.view_door_value v on d.id = v.id " +
            //    "left join [order_database].dbo.SALES_LEDGER s  on d.customer_acc_ref = s.ACCOUNT_REF " +
            //    "where (status_id = 1 or status_id = 2 or status_id = 3) " +
            //    "group by [NAME]) b on a.Customer = b.customer " +
            //    "where [Slimline Customer] = 'No' AND cast([Last Date Ordered] as date) <=  '" + dteFilter.Value.ToString("yyyyMMdd") + "' ";

            string sql = "";

            //if (cmbCustomerSearch.Text.Length > 0)
            //{
            //    sql = "select rtrim(a.Customer) as customer,max(cast([Last Date Ordered] as date)) as last_date_ordered, " +
            //       "max([Last Door Ordered]) as [last_Door_Ordered], " +
            //       "max([Slimline Customer]) as slimline,max(round(b.[value],2)) as total_custoemr_value " +
            //       "from [order_database].dbo.POWERBI_non_returning_customers a " +
            //       "left  join (select sum(v.line_total) as [value],[NAME] as customer " +
            //       "	from [order_database].dbo.door d " +
            //       "	left  join [order_database].dbo.view_door_value v on d.id = v.id " +
            //       "	left  join [order_database].dbo.SALES_LEDGER s  on d.customer_acc_ref = s.ACCOUNT_REF " +
            //       "	where (status_id = 1 or status_id = 2 or status_id = 3) group by [NAME]) b on a.Customer = b.customer " +
            //       "where cast([Last Date Ordered] as date) <= '" + dteFilter.Value.ToString("yyyyMMdd") + "' " +
            //       "AND [Slimline Customer] = ";
            //}
            //else
            //{
            //    sql = "select rtrim(a.Customer) as customer,max(cast([Last Date Ordered] as date)) as last_date_ordered, " +
            //       "max([Last Door Ordered]) as [last_Door_Ordered], " +
            //       "max([Slimline Customer]) as slimline,max(round(b.[value],2)) as total_custoemr_value " +
            //       "from [order_database].dbo.POWERBI_non_returning_customers a " +
            //       "left merge join (select sum(v.line_total) as [value],[NAME] as customer " +
            //       "	from [order_database].dbo.door d " +
            //       "	left merge join [order_database].dbo.view_door_value v on d.id = v.id " +
            //       "	left merge join [order_database].dbo.SALES_LEDGER s  on d.customer_acc_ref = s.ACCOUNT_REF " +
            //       "	where (status_id = 1 or status_id = 2 or status_id = 3) group by [NAME]) b on a.Customer = b.customer " +
            //       "where cast([Last Date Ordered] as date) <= '" + dteFilter.Value.ToString("yyyyMMdd") + "' " +
            //       "AND [Slimline Customer] = ";
            //}

            // new string
            sql = "SELECT * from (SELECT s.[NAME] Customer, max(date_order) as [last_date_ordered],max(d.id) as [last_Door_Ordered],'No' as slimline, " +
                "sum(v.line_total) as total_custoemr_value from [order_database].dbo.door d " +
                "INNER JOIN [order_database].DBO.SALES_LEDGER s on d.customer_acc_ref = s.ACCOUNT_REF " +
                "INNER JOIN [order_database].dbo.view_door_value v on d.id = v.id " +
                "INNER JOIN [order_database].dbo.door_type dt on d.door_type_id = dt.id " +
                "WHERE (dt.slimline_y_n = 0 or dt.slimline_y_n is null) and (status_id = 1 or status_id = 2 or status_id = 3) " +
                "group by s.[NAME] " +
                "union " +
                "SELECT s.[NAME] as customer, max(date_order) as [last_date_ordered], max(d.id) as [last_Door_Ordered],'Yes' as slimline, sum(v.line_total) from [order_database].dbo.door d " +
                "INNER JOIN [order_database].DBO.SALES_LEDGER s on d.customer_acc_ref = s.ACCOUNT_REF " +
                "INNER JOIN [order_database].dbo.view_door_value v on d.id = v.id " +
                "INNER JOIN [order_database].dbo.door_type dt on d.door_type_id = dt.id " +
                "WHERE dt.slimline_y_n = -1 and (status_id = 1 or status_id = 2 or status_id = 3) " +
                "group by s.[NAME]) as inside " +
                "where slimline = ";

            if (slimline == -1)
                sql = sql + "'Yes' ";
            else
                sql = sql + "'No' ";

            if (dateFilter == -1)
            {
                sql = sql + " AND inside.last_date_ordered >= '" + dteFilterStart.Value.ToString("yyyyMMdd") + "'" +
                            " AND inside.last_date_ordered <= '" + dteFilterEnd.Value.ToString("yyyyMMdd") + "'  ";
            }
            else
                sql = sql + " AND inside.last_date_ordered <= GETDATE()  ";

            if (string.IsNullOrEmpty(cmbCustomerSearch.Text) == false)
                sql = sql + "AND customer = '" + cmbCustomerSearch.Text + "' ";


            //sql = sql + " group by rtrim(Customer),[Slimline] ";


            if (last_order == -1)
                sql = sql + "order by last_date_ordered desc";

            if (total_value == -1)
                sql = sql + "order by total_custoemr_value desc";

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
            customer_index = dgvNonReturningCustomers.Columns["Customer"].Index;
            last_date_ordered_index = dgvNonReturningCustomers.Columns["last_date_ordered"].Index;
            last_door_ordered_index = dgvNonReturningCustomers.Columns["last_door_ordered"].Index;
            slimline_index = dgvNonReturningCustomers.Columns["slimline"].Index;
            total_value_index = dgvNonReturningCustomers.Columns["total_custoemr_value"].Index;
        }
        private void format()
        {
            dgvNonReturningCustomers.Columns[slimline_index].Visible = false;
            dgvNonReturningCustomers.Columns[customer_index].HeaderText = "Customer";
            dgvNonReturningCustomers.Columns[last_date_ordered_index].HeaderText = "Last Date Ordered";
            dgvNonReturningCustomers.Columns[last_door_ordered_index].HeaderText = "Last Door Ordered";
            dgvNonReturningCustomers.Columns[total_value_index].HeaderText = "Historic Order Book Value";

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
            dateFilter = -1;
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
            dateFilter = 0;
            load_grid();
        }

        private void dteFilterEnd_CloseUp(object sender, EventArgs e)
        {
            dateFilter = -1;
            load_grid();
        }
    }
}
