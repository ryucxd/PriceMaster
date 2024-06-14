using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace PriceMaster
{
    public partial class frmManagementAlert : Form
    {
        public int slimline { get; set; }
        public int date_filter { get; set; }

        //indexes
        public int id_index { get; set; }
        public int alert_time_index { get; set; }
        public int sent_by_index { get; set; }
        public int sent_to_index { get; set; }
        public int quote_id_index { get; set; }
        public int customer_index { get; set; }
        public int chase_date_index { get; set; }
        public int chase_description_index { get; set; }
        public int alert_description_index { get; set; }
        public int alert_complete_index { get; set; }

        public frmManagementAlert(int _slimline)
        {
            InitializeComponent();

            slimline = _slimline;

            if (slimline == -1)
                chkboxSlimline.Checked = true;
            else
                chkboxSlimline.Checked = false;

            load_grid();

            fill_combo();


        }

        private void fill_combo()
        {
            cmbCustomer.Items.Clear();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (cmbCustomer.Items.Contains(row.Cells[customer_index].Value.ToString()))
                { } //nothing
                else
                    cmbCustomer.Items.Add(row.Cells[customer_index].Value.ToString());
            }
        }

        private void load_grid()
        {
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                string sql = "";

                if (slimline == -1)
                {
                    sql = "select a.id,alert_time,u.forename + ' ' + u.surname as  sent_by,sent_to,q.quote_id,s.customer,q.chase_date,q.chase_description,alert_description, " +
                        "CASE WHEN alert_complete = 0 THEN CAST(0 AS BIT) WHEN alert_complete IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS alert_complete " +
                        "from [order_database].dbo.quotation_chase_alert a " +
                        "left join [order_database].dbo.quotation_chase_log_slimline  q on a.chase_id = q.id " +
                        "left join [user_info].dbo.[user] u on a.sent_by = u.id " +
                        "left join (select quote_id,s.[NAME] as customer from dbo.sl_quotation a " +
                        "LEFT JOIN [dsl_fitting].dbo.[SALES_LEDGER] s on s.ACCOUNT_REF = a.customer_acc_ref  " +
                        "where highest_issue = -1) s on s.quote_id = q.quote_id ";
                }
                else
                {
                    sql = "select a.id,alert_time,u.forename + ' ' + u.surname as  sent_by,sent_to,q.quote_id,s.customer,q.chase_date,q.chase_description," +
                        "alert_description, " +
                        "CASE WHEN alert_complete = 0 THEN CAST(0 AS BIT) WHEN alert_complete IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS alert_complete  " +
                        "from [order_database].dbo.quotation_chase_alert a " +
                        "left join [order_database].dbo.quotation_chase_log  q on a.chase_id = q.id " +
                        "left join [user_info].dbo.[user] u on a.sent_by = u.id " +
                        "left join [order_database].dbo.solidworks_quotation_log s on s.quote_id = q.quote_id " +
                        "right join (select quote_id, max(revision_number) revision_number  FROM [order_database].dbo.solidworks_quotation_log group by quote_id) s2 " +
                        "on s.quote_id = s2.quote_id AND s.revision_number = s2.revision_number ";
                }  
                
                //both strings include this 
                sql = sql + "where a.slimline = " + slimline.ToString() + " ";

                //where filters

                if (date_filter == -1)
                    sql = sql + " AND  CAST(alert_time as date) >= '" + dteStart.Value.ToString("yyyyMMdd") + "'  AND CAST(alert_time as date) <= '" + dteEnd.Value.ToString("yyyyMMdd") + "' ";

                if (cmbCustomer.Text.Length > 0)
                    sql = sql + " AND customer = '" + cmbCustomer.Text + "' ";

                sql = sql + "Order by alert_time desc";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                    column_index();
                    format();
                }

                conn.Close();
            }
        }

        private void column_index()
        {
            id_index = dataGridView1.Columns["id"].Index;
            alert_time_index = dataGridView1.Columns["alert_time"].Index;
            sent_by_index = dataGridView1.Columns["sent_by"].Index;
            sent_to_index = dataGridView1.Columns["sent_to"].Index;
            quote_id_index = dataGridView1.Columns["quote_id"].Index;
            customer_index = dataGridView1.Columns["customer"].Index;
            chase_date_index = dataGridView1.Columns["chase_date"].Index;
            chase_description_index = dataGridView1.Columns["chase_description"].Index;
            alert_description_index = dataGridView1.Columns["alert_description"].Index;
            alert_complete_index = dataGridView1.Columns["alert_complete"].Index;

        }

        private void format()
        {

            dataGridView1.Columns[id_index].Visible = false;
            dataGridView1.Columns[alert_time_index].HeaderText = "Alert Time";
            dataGridView1.Columns[sent_by_index].HeaderText = "Sent By";
            dataGridView1.Columns[sent_to_index].HeaderText = "Sent To";
            dataGridView1.Columns[quote_id_index].HeaderText = "Quote ID";
            dataGridView1.Columns[customer_index].HeaderText = "Customer";
            dataGridView1.Columns[chase_date_index].HeaderText = "Chase Date";
            dataGridView1.Columns[chase_description_index].HeaderText = "Chase Description";
            dataGridView1.Columns[alert_description_index].HeaderText = "Resolution";
            dataGridView1.Columns[alert_complete_index].HeaderText = "Alert Complete";

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dataGridView1.Columns[chase_description_index].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[alert_description_index].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            foreach (DataGridViewRow row in dataGridView1.Rows)
                if (Convert.ToBoolean(row.Cells[alert_complete_index].Value) == true)
                    row.DefaultCellStyle.BackColor = Color.LightSkyBlue;

            dataGridView1.ClearSelection();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmManagementAlert_Shown(object sender, EventArgs e)
        {
            format();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            column_index();

            //frmManagementAlertView frm = new frmManagementAlertView(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[id_index].Value.ToString()), slimline, 0);
            //frm.ShowDialog();

            frmManagementViewDetailed frm = new frmManagementViewDetailed(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[id_index].Value.ToString()), slimline);
            frm.ShowDialog();

            //check if this row is completeeeee
            //int alert_comp = 0;
            //if (dataGridView1.Rows[e.RowIndex].Cells[alert_complete_index].Value.ToString() == "1")
            //    alert_comp = -1;
            //else
            //    alert_comp = 0;

            //frmManagementAlertAction frm = new frmManagementAlertAction(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[id_index].Value.ToString()), alert_comp);
            //frm.ShowDialog();
            load_grid();
        }

        private void dteStart_CloseUp(object sender, EventArgs e)
        {
            date_filter = -1;
            load_grid();
        }

        private void dteEnd_CloseUp(object sender, EventArgs e)
        {
            date_filter = -1;
            load_grid();
        }

        private void chkboxSlimline_CheckedChanged(object sender, EventArgs e)
        {
            date_filter = 0;
            cmbCustomer.Text = "";

            if (chkboxSlimline.Checked == true)
                slimline = -1;
            else
                slimline = 0;

            load_grid();
            fill_combo();

        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_grid();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            date_filter = 0;
            cmbCustomer.Text = "";
            load_grid();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            print_sheet();
        }
        private void print_sheet()
        {
            string file_name = @"C:\temp\temp" + DateTime.Now.ToString("mmss") + ".jpg";
            try
            {
                Image bit = new Bitmap(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);

                Graphics gs = Graphics.FromImage(bit);

                gs.CopyFromScreen(new Point(0, 0), new Point(0, 0), bit.Size);

                //bit.Save(@"C:\temp\temp.jpg");


                Rectangle bounds = this.Bounds;
                using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
                    }
                    bitmap.Save(file_name);
                }


                //var frm = Form.ActiveForm;
                //using (var bmp = new Bitmap(frm.Width, frm.Height))
                //{
                //    frm.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                //    bmp.Save(@"C:\temp\temp.jpg");
                //}

                PrintDocument pd = new PrintDocument();
                pd.PrintPage += (sender, args) =>
                {
                    Image i = Image.FromFile(file_name);
                    Rectangle m = args.MarginBounds;
                    if ((double)i.Width / (double)i.Height > (double)m.Width / (double)m.Height) // image is wider
                    {
                        m.Height = (int)((double)i.Height / (double)i.Width * (double)m.Width);
                    }
                    else
                    {
                        m.Width = (int)((double)i.Width / (double)i.Height * (double)m.Height);
                    }
                    args.Graphics.DrawImage(i, m);
                };

                pd.DefaultPageSettings.Landscape = true;
                //Margins margins = new Margins(50, 50, 50, 50);
                //pd.DefaultPageSettings.Margins = margins;
                pd.Print();
            }
            catch
            { }
        }

        private string excel()
        {
            string search_dates ="- From: " + dteStart.Value.ToString("dd/MM/yyyy") + " to: " + dteEnd.Value.ToString("dd/MM/yyyy");


            Process[] processesBefore = Process.GetProcessesByName("excel");

            //
            int customer_index = 0;
            customer_index = dataGridView1.Columns["Customer"].Index;

            string FileName = @"C:\temp\Management_alert" + DateTime.Now.ToString("mmss") + ".xls";


            //adjust the chase description
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                //string temp =  row.Cells[3].Value.ToString();
                row.Cells[chase_description_index].Value = row.Cells[chase_description_index].Value.ToString().Replace("\n", " ").Replace("\r", " - ");
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                //string temp =  row.Cells[3].Value.ToString();
                row.Cells[alert_description_index].Value = row.Cells[alert_description_index].Value.ToString().Replace("\n", " ").Replace("\r", " - ");
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                //string temp =  row.Cells[3].Value.ToString();
                row.Cells[sent_to_index].Value = row.Cells[sent_to_index].Value.ToString().Replace(";", " ");
            }

            object misValue = System.Reflection.Missing.Value;
            Microsoft.Office.Interop.Excel.Application xlexcel = new Microsoft.Office.Interop.Excel.Application();

            xlexcel.DisplayAlerts = false; // Without this you will get two confirm overwrite prompts
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook = xlexcel.Workbooks.Add(misValue);

            Process[] processesAfter = Process.GetProcessesByName("excel");

                //if there are rows in chaseing

                // Copy DataGridView results to clipboard
                dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
                dataGridView1.SelectAll();

                //delete all of the first row


                DataObject dataObj = dataGridView1.GetClipboardContent();
                if (dataObj != null)
                    Clipboard.SetDataObject(dataObj);


                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                xlWorkSheet.Name = "Chases";

                // Get Excel processes after opening the file. 



                // Paste clipboard results to worksheet range
                Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[3, 1];
                CR.Select();
                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

                //delete the first row
                ((Excel.Range)xlWorkSheet.Rows[1, Missing.Value]).Delete(Excel.XlDeleteShiftDirection.xlShiftUp);



                xlWorkSheet.get_Range("A3").Select();

                Microsoft.Office.Interop.Excel.Worksheet ws = xlexcel.ActiveWorkbook.Worksheets[1];
                Microsoft.Office.Interop.Excel.Range range = ws.UsedRange;



                //ws.Columns.AutoFit();
                //ws.Rows.AutoFit();


                xlWorkSheet.Cells[1, 1].Value = "Management Alerts " + search_dates;
                xlWorkSheet.Range["A1:I1"].Cells.Font.Size = 20;
                xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[1, 8]].Merge();
                //Make all top/left align
                xlWorkSheet.get_Range("A2", "I1000").Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignGeneral;
                xlWorkSheet.get_Range("A2", "I1000").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                //change the entire top row to center align (AND BOTH DATE COLUMNS)
                xlWorkSheet.get_Range("A1", "I2").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                //xlWorkSheet.Columns[2].Style.HorizontalAlignment = HorizontalAlignment.Center;
                //xlWorkSheet.Columns[4].Style.HorizontalAlignment = HorizontalAlignment.Center;


                xlWorkSheet.Range["A2:I2"].Interior.Color = System.Drawing.Color.LightSkyBlue;
                xlWorkSheet.Range["A2:I2"].AutoFilter(1);
                xlWorkSheet.Range["A2:I2"].Cells.Font.Size = 12;

                ws.Columns.AutoFit();
                ws.Rows.AutoFit();

            //adjust the description conversation to fit and look nicer
            xlWorkSheet.Columns[3].ColumnWidth = 28;
            xlWorkSheet.Columns[3].WrapText = true;

            xlWorkSheet.Columns[7].ColumnWidth = 60;
            xlWorkSheet.Columns[7].WrapText = true;
            xlWorkSheet.Columns[8].ColumnWidth = 60;
            xlWorkSheet.Columns[8].WrapText = true;

            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                range.Borders.Color = ColorTranslator.ToOle(Color.Black);

                var chase_pagesetup = xlWorkSheet.PageSetup;
                chase_pagesetup.FitToPagesWide = 1;
                chase_pagesetup.FitToPagesTall = false;
                chase_pagesetup.Zoom = false;
                chase_pagesetup.Orientation = Excel.XlPageOrientation.xlLandscape;
            
           

            // Save the excel file under the captured location from the SaveFileDialog
            xlWorkBook.SaveAs(FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlexcel.DisplayAlerts = true;
            xlWorkBook.Close(true, misValue, misValue);
            xlexcel.Quit();

            //releaseObject(xlWorkSheet);
            //releaseObject(xlWorkBook);
            //releaseObject(xlexcel);

            // Clear Clipboard and DataGridView selection
            Clipboard.Clear();
            dataGridView1.ClearSelection();

            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks workbooks;
            Microsoft.Office.Interop.Excel.Workbook excelBook;

            //app = null;
            //app = new Excel.Application(); // create a new instance
            excelApp.DisplayAlerts = false; //turn off annoying alerts that make me want to cryyyy

            workbooks = excelApp.Workbooks;
            excelBook = workbooks.Add(FileName);
            Microsoft.Office.Interop.Excel.Sheets sheets = excelBook.Worksheets;
            Microsoft.Office.Interop.Excel.Worksheet excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)(sheets[1]);

            //Range.Rows.AutoFit();
            //Range.Columns.AutoFit();

            excelApp.Quit();
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
            return FileName;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count < 1)
                return;

            string temp = excel();

            // Open the newly saved excel file
            if (File.Exists(temp))
                System.Diagnostics.Process.Start(temp);
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count < 1)
                return;
            try
            {

                Outlook.Application outlookApp = new Outlook.Application();
                Outlook.MailItem mailItem = outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
                mailItem.Subject = "";
                mailItem.To = "";
                string imageSrc = excel();

                var attachments = mailItem.Attachments;
                var attachment = attachments.Add(imageSrc);
                attachment.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/proptag/0x370E001F", "image/jpeg");
                attachment.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/proptag/0x3712001F", "myident"); // Image identifier found in the HTML code right after cid. Can be anything.
                mailItem.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/id/{00062008-0000-0000-C000-000000000046}/8514000B", true);

                // Set body format to HTML

                mailItem.BodyFormat = Outlook.OlBodyFormat.olFormatHTML;
                mailItem.Attachments.Add(imageSrc);
                string msgHTMLBody = "";
                mailItem.HTMLBody = msgHTMLBody;
                mailItem.Display(false);


            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}
