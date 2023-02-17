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
using System.Diagnostics;
using System.IO;
using System.Windows.Forms.VisualStyles;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Drawing.Printing;

namespace PriceMaster
{
    public partial class frmManagementView : Form
    {
        public int slimline { get; set; }
        public int id_index { get; set; }
        public int quote_index { get; set; }
        public int chase_date_index { get; set; }
        public int chase_description_index { get; set; }
        public int next_chase_date_index { get; set; }
        public int chased_by_index { get; set; }
        public int button_index { get; set; }
        public int customer_index { get; set; }
        public int sender_email_address_index { get; set; }
        public int priority_chase_index { get; set; }
        public int date_filter { get; set; }
        public int chase_complete_index { get; set; }
        public int chase_status_index { get; set; }
        public int staff_index { get; set; }
        public frmManagementView(int _slimline)
        {
            InitializeComponent();
            slimline = _slimline;
            load_data();
            fillCombo();


        }

        private void format()
        {
            dataGridView1.Columns[id_index].Visible = false;
            dataGridView1.Columns[quote_index].HeaderText = "Quote ID";
            dataGridView1.Columns[chase_date_index].HeaderText = "Chase Date";
            dataGridView1.Columns[chase_description_index].HeaderText = "Chase Description";
            dataGridView1.Columns[next_chase_date_index].HeaderText = "Next Chase Date";
            dataGridView1.Columns[customer_index].HeaderText = "Customer";
            dataGridView1.Columns[sender_email_address_index].HeaderText = "Sender Email Address";
            dataGridView1.Columns[chase_status_index].HeaderText = "Chase Status";
            dataGridView1.Columns[priority_chase_index].Visible = false;
            dataGridView1.Columns[chase_complete_index].Visible = false;

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
                //if (row.Cells[chase_complete_index].Value.ToString() == "-1")
                //    row.DefaultCellStyle.BackColor = Color.DarkGray;
            }

            dataGridView1.Columns[chased_by_index].HeaderText = "Chased by";

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dataGridView1.Columns[chase_description_index].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void fillCombo()
        {

            cmbCustomerSearch.Items.Clear();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (cmbCustomerSearch.Items.Contains(row.Cells[customer_index].Value.ToString()))
                { } //nothing
                else
                    cmbCustomerSearch.Items.Add(row.Cells[customer_index].Value.ToString());
            }

            cmbStaffSearch.Items.Clear();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (cmbStaffSearch.Items.Contains(row.Cells[chased_by_index].Value.ToString()))
                { } //nothing
                else
                    cmbStaffSearch.Items.Add(row.Cells[chased_by_index].Value.ToString());
            }

        }

        private void load_data()
        {
            dataGridView1.DataSource = null;
            string sql = "";


            if (slimline == -1)
            {
                sql = "SELECT a.id,a.quote_id,b.[status],chase_date,chase_description,next_chase_date,u.forename + ' ' + u.surname as chased_by,rtrim(s.[NAME]) as [customer] ,e.sender_email_address,priority_chase " +
                    ",chase_complete FROM [order_database].dbo.quotation_chase_log_slimline a " +
                    "left join [order_database].dbo.quotation_feed_back_slimline b on a.quote_id = b.quote_id " +
                    "left join[user_info].dbo.[user] u on a.chased_by = u.id " +
                    "left join (SELECT * FROM [price_master].dbo.[sl_quotation] where highest_issue = -1 )  sl on sl.quote_id = a.quote_id " +
                    "left join[EnquiryLog].dbo.[Enquiry_Log] e on sl.enquiry_id = e.id " +
                    "left join[dsl_fitting].dbo.SALES_LEDGER s on sl.customer_acc_ref = s.ACCOUNT_REF " +
                    //"right join (select max(id) as id,quote_id FROM [order_database].dbo.quotation_chase_log_slimline group by quote_id) as z on z.id = a.id " +
                    "where  ";

                if (chkFuture.Checked == true)
                    sql = sql + " next_chase_date > ";
                else
                    sql = sql + " cast(chase_date as date) <= ";

                sql = sql + " CAST(GETDATE() as date)   "; // and (dont_chase = 0 or dont_chase is null) and b.[status] = 'Chasing'


                if (string.IsNullOrEmpty(cmbChaseStatus.Text) == false)
                    sql = sql + " and b.[status] = '" + cmbChaseStatus.Text + "'    ";

                if (string.IsNullOrEmpty(cmbCustomerSearch.Text) == false)
                    sql = sql + " AND rtrim(s.NAME) = '" + cmbCustomerSearch.Text + "'  ";
                if (string.IsNullOrEmpty(cmbStaffSearch.Text) == false)
                    sql = sql + " AND u.forename + ' ' + u.surname = '" + cmbStaffSearch.Text + "'  ";


                if (chkAllChases.Checked == true)
                    sql = sql + "";//"and  (chase_complete = -1)  ";   -- no filter
                else
                    sql = sql + "and  (chase_complete = 0 or chase_complete is null)  ";

                if (date_filter == -1)
                {
                    if (chkFuture.Checked == true)
                        sql = sql + "and next_chase_date >= '" + dteStart.Value.ToString("yyyyMMdd") + "' AND next_chase_date  <= '" + dteEnd.Value.ToString("yyyyMMdd") + "'";
                    else
                        sql = sql + "and chase_date >= '" + dteStart.Value.ToString("yyyyMMdd") + "' AND chase_date  <= '" + dteEnd.Value.ToString("yyyyMMdd") + "'";

                }


                //if (chkAllChases.Checked == true)
                //    sql = sql + " order by quote_id desc,chase_date desc";
                //else
                    sql = sql + " order by chase_date desc,rtrim(s.[NAME]), quote_id ";

            }
            else
            {
                sql = "SELECT a.id,a.quote_id,b.[status],chase_date,chase_description,next_chase_date,u.forename + ' ' + u.surname as chased_by," +
                    "rtrim(q.customer) as customer,e.sender_email_address,priority_chase,chase_complete FROM[order_database].dbo.quotation_chase_log a " +
                    "left join[order_database].dbo.quotation_feed_back b on a.quote_id = b.quote_id left join[user_info].dbo.[user] u on a.chased_by = u.id " +
                    "left join(select quote_id, max(revision_number) as revision_number from[order_database].dbo.solidworks_quotation_log group by quote_id) sw on a.quote_id = sw.quote_id " +
                    "left join[order_database].dbo.solidworks_quotation_log q on sw.quote_id = q.quote_id and sw.revision_number = q.revision_number " +
                    "left join(select max(id) as enquiry_id, left(related_quote, CHARINDEX('-', related_quote) - 1) as related_quote from[EnquiryLog].dbo.[Enquiry_Log] " +
                    "WHERE related_quote<> 'No Related Quote' group by LEFT(related_quote, CHARINDEX('-', related_quote) - 1)) el on el.related_quote like '%' + cast(q.quote_id as nvarchar) + '%' " +
                    "left join[EnquiryLog].dbo.[Enquiry_Log] e on el.enquiry_id = e.id " +
                    "where  ";

                if (chkFuture.Checked == true)
                    sql = sql + "next_chase_date > ";
                else
                    sql = sql + "cast(chase_date as date) <= ";

                sql = sql + " CAST(GETDATE() as date)    ";//and (dont_chase = 0 or dont_chase is null) and b.[status] = 'Chasing'

                if (string.IsNullOrEmpty(cmbChaseStatus.Text) == false)
                    sql = sql + " and b.[status] = '" + cmbChaseStatus.Text + "'    ";



                if (string.IsNullOrEmpty(cmbCustomerSearch.Text) == false)
                    sql = sql + " AND rtrim(q.customer) = '" + cmbCustomerSearch.Text + "'  ";
                if (string.IsNullOrEmpty(cmbStaffSearch.Text) == false)
                    sql = sql + " AND u.forename + ' ' + u.surname = '" + cmbStaffSearch.Text + "'  ";

                if (chkAllChases.Checked == true)
                    sql = sql + "";//"and  (chase_complete = -1)  ";   -- no filter
                else
                    sql = sql + "and  (chase_complete = 0 or chase_complete is null)  ";

                if (date_filter == -1)
                {
                    if (chkFuture.Checked == true)
                        sql = sql + "and next_chase_date >= '" + dteStart.Value.ToString("yyyyMMdd") + "' AND next_chase_date  <= '" + dteEnd.Value.ToString("yyyyMMdd") + "'";
                    else
                        sql = sql + "and chase_date >= '" + dteStart.Value.ToString("yyyyMMdd") + "' AND chase_date  <= '" + dteEnd.Value.ToString("yyyyMMdd") + "'";

                }


                //if (chkAllChases.Checked == true)
                //    sql = sql + " order by quote_id desc,chase_date desc";
                //else
                    sql = sql + " order by chase_date desc, quote_id ";

            }


            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    System.Data.DataTable dt = new System.Data.DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                conn.Close();
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

        }

        private void column_index()
        {
            id_index = dataGridView1.Columns["id"].Index;
            quote_index = dataGridView1.Columns["quote_id"].Index;
            chase_date_index = dataGridView1.Columns["chase_date"].Index;
            chase_description_index = dataGridView1.Columns["chase_description"].Index;
            next_chase_date_index = dataGridView1.Columns["next_chase_date"].Index;
            chased_by_index = dataGridView1.Columns["chased_by"].Index;
            customer_index = dataGridView1.Columns["customer"].Index;
            sender_email_address_index = dataGridView1.Columns["sender_email_address"].Index;
            priority_chase_index = dataGridView1.Columns["priority_chase"].Index;
            chase_complete_index = dataGridView1.Columns["chase_complete"].Index;
            chase_status_index = dataGridView1.Columns["status"].Index;

            if (dataGridView1.Columns.Contains("Complete") == true)
                button_index = dataGridView1.Columns["Complete"].Index;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            column_index();


            //get the customer
            string customer = "";
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                string sql = "";
                if (slimline == -1)//no idea what this does tbh
                {
                    sql = "select  rtrim(b.[NAME]) from [price_master].dbo.sl_quotation a " +
                        "left join[dsl_fitting].dbo.[SALES_LEDGER] b on a.customer_acc_ref = b.ACCOUNT_REF where quote_id = " + dataGridView1.Rows[e.RowIndex].Cells[quote_index].Value.ToString();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                        customer = cmd.ExecuteScalar().ToString();
                }
                else
                {

                }


                conn.Close();
            }

            // dataGridView1.ClearSelection();
            frmManagementViewHistory frm = new frmManagementViewHistory(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[quote_index].Value.ToString()), slimline);
            frm.ShowDialog();
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
            cmbCustomerSearch.Text = "";
            cmbStaffSearch.Text = "";

            load_data();
            fillCombo();
        }

        private void frmSlimlineOutstandingChase_Shown(object sender, EventArgs e)
        {
            btnShowAll.PerformClick();
            format();
        }

        private void cmbStaffSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_data();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // chkFuture.Checked = false;
            cmbStaffSearch.Text = "";
            cmbCustomerSearch.Text = "";
            cmbChaseStatus.Text = "";
            date_filter = 0;
            load_data();
            fillCombo();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

            Process[] processesBefore = Process.GetProcessesByName("excel");

            //
            int customer_index = 0;
            customer_index = dataGridView1.Columns["Customer"].Index;

            string FileName = @"C:\temp\Management_chase_list" + DateTime.Now.ToString("mmss") + ".xls";


            //adjust the chase description
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                //string temp =  row.Cells[3].Value.ToString();
                row.Cells[chase_description_index].Value = row.Cells[chase_description_index].Value.ToString().Replace("\n", " ").Replace("\r", " - ");
            }


            // Copy DataGridView results to clipboard
            dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridView1.SelectAll();

            //delete all of the first row


            DataObject dataObj = dataGridView1.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);

            object misValue = System.Reflection.Missing.Value;
            Microsoft.Office.Interop.Excel.Application xlexcel = new Microsoft.Office.Interop.Excel.Application();

            xlexcel.DisplayAlerts = false; // Without this you will get two confirm overwrite prompts
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook = xlexcel.Workbooks.Add(misValue);
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            // Get Excel processes after opening the file. 
            Process[] processesAfter = Process.GetProcessesByName("excel");


            // Paste clipboard results to worksheet range
            Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[2, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

            //delete the first row
            ((Excel.Range)xlWorkSheet.Rows[1, Missing.Value]).Delete(Excel.XlDeleteShiftDirection.xlShiftUp);



            xlWorkSheet.get_Range("A2").Select();

            Microsoft.Office.Interop.Excel.Worksheet ws = xlexcel.ActiveWorkbook.Worksheets[1];
            Microsoft.Office.Interop.Excel.Range range = ws.UsedRange;



            //ws.Columns.AutoFit();
            //ws.Rows.AutoFit();

            //adjust the description conversation to fit and look nicer
            xlWorkSheet.Columns[3].ColumnWidth = 100;
            xlWorkSheet.Columns[3].WrapText = true;

            //Make all top/left align
            xlWorkSheet.get_Range("A1", "H1000").Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignGeneral;
            xlWorkSheet.get_Range("A1", "H1000").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            //change the entire top row to center align (AND BOTH DATE COLUMNS)
            xlWorkSheet.get_Range("A1", "H1").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //xlWorkSheet.Columns[2].Style.HorizontalAlignment = HorizontalAlignment.Center;
            //xlWorkSheet.Columns[4].Style.HorizontalAlignment = HorizontalAlignment.Center;


            xlWorkSheet.Range["A1:H1"].Interior.Color = System.Drawing.Color.LightSkyBlue;
            xlWorkSheet.Range["A1:H1"].AutoFilter(1);
            xlWorkSheet.Range["A1:H1"].Cells.Font.Size = 12;

            ws.Columns.AutoFit();
            ws.Rows.AutoFit();


            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            range.Borders.Color = ColorTranslator.ToOle(Color.Black);

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

            // Open the newly saved excel file
            if (File.Exists(FileName))
                System.Diagnostics.Process.Start(FileName);

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
        }

        private void buttonFormatting1_Click(object sender, EventArgs e)
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

        private void chkCompleted_CheckedChanged(object sender, EventArgs e)
        {
            cmbCustomerSearch.Text = "";
            cmbStaffSearch.Text = "";

            if (chkAllChases.Checked == true)
                btnShowAll.Text = "Show Only Latest";
            else
                btnShowAll.Text = "Show All";


            load_data();
            fillCombo();
        }

        private void dteStart_CloseUp(object sender, EventArgs e)
        {
            date_filter = -1;
            load_data();
        }

        private void dteEnd_CloseUp(object sender, EventArgs e)
        {
            date_filter = -1;
            load_data();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            if (chkAllChases.Checked == true)
            {
                chkAllChases.Checked = false;
                btnShowAll.Size = new System.Drawing.Size(82, 30);

            }
            else
            {
                chkAllChases.Checked = true;
                btnShowAll.Size = new System.Drawing.Size(145, 30);
            }
        }

        private void cmbChaseStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_data();
        }
    }
}
