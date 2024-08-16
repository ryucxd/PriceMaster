using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Data.SqlTypes;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Windows.Forms.Integration;

namespace PriceMaster
{
    public partial class frmSectorManagementView : Form
    {
        public int remove_tabs { get; set; }

        public int salesMemberOne { get; set; }
        public int salesMemberTwo { get; set; }
        public int salesMemberThree { get; set; }
        public DataTable excel_headers { get; set; }


        public frmSectorManagementView()
        {
            InitializeComponent();

            tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl.DrawItem += new DrawItemEventHandler(tabControl_DrawItem);

            //monday
            int temp = DayOfWeek.Monday - DateTime.Now.DayOfWeek;
            DateTime monday = DateTime.Now.AddDays(temp);

            //dteStart.Value = monday;
            dteStart.Value = monday.AddMonths(-1);
            dteEnd.Value = monday; 
            
            remove_tabs = -1;

            fill_tabcontrol();
            tabControl.SelectedIndex = tabControl.TabPages.Count -1;
            fill_grids();
        }



        private void tabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tabControl = sender as TabControl;
            TabPage tabPage = tabControl.TabPages[e.Index];

            // Set the background color of the tab (optional)
            Color tabColor = Color.LightSkyBlue; // Customize this color as needed
            using (SolidBrush brush = new SolidBrush(tabColor))
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
            }

            // Draw the tab's text
            TextRenderer.DrawText(e.Graphics, tabPage.Text, tabPage.Font, e.Bounds, tabPage.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);

            // Draw a black border around the tab
            using (Pen pen = new Pen(Color.Black))
            {
                Rectangle rect = e.Bounds;
                rect.Inflate(-1, -1); // Adjust the rectangle to fit inside the tab area
                e.Graphics.DrawRectangle(pen, rect);
            }

            // Optional: Draw focus rectangle (if needed)
            e.DrawFocusRectangle();
        }



        private void fill_tabcontrol()
        {
            if (remove_tabs == -1)
            {
                //tabControl.TabPages.Remove()
                tabControl.TabPages.Clear();

                //string sql = "select distinct Convert(varchar,cast(sector_date  as date),103) FROM [order_database].dbo.view_sales_table_grouped " +
                //"where sector_date >= '" + dteStart.Value.ToString("yyyyMMdd") + "' AND sector_date <= '" + dteEnd.Value.ToString("yyyyMMdd") + "' " +
                //"ORDER BY sector_date desc";

                string sql = "select distinct sector_date  FROM [order_database].dbo.view_sales_table_grouped " +
                             "where sector_date >= '" + dteStart.Value.ToString("yyyyMMdd") + "' AND sector_date <= '" + dteEnd.Value.ToString("yyyyMMdd") + "' " +
                             "ORDER BY sector_date asc";

                using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                {

                    conn.Open();

                    DataTable dt = new DataTable();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }

                    //loop max warning and insert a tab page for each one
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TabPage tabPageLoop = new TabPage
                        {
                            Name = dt.Rows[i][0].ToString(),
                            Text = Convert.ToDateTime(dt.Rows[i][0].ToString()).ToString("dd/MM/yyyy")   ,
                            BackColor = Color.LightBlue
                        };
                        tabControl.TabPages.Add(tabPageLoop);
                    }
                    remove_tabs = 0;

                    conn.Close();
                }
                fill_grids();
            }
        }

        private void fill_grids()
        {
            if (tabControl.SelectedIndex < 0)
                return;

            DateTime sectorDate = DateTime.Now;
            //get the date from the tabcontrol
            string sql = "select distinct sector_date  FROM [order_database].dbo.view_sales_table_grouped " +
                "where sector_date >= '" + dteStart.Value.ToString("yyyyMMdd") + "' AND sector_date <= '" + dteEnd.Value.ToString("yyyyMMdd") + "' ";

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                DataTable dt = new DataTable();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    sectorDate = Convert.ToDateTime(dt.Rows[tabControl.SelectedIndex][0].ToString());

                    lblWeekCommencing.Text = "Data for Week Commencing: " + Convert.ToDateTime(dt.Rows[tabControl.SelectedIndex][0].ToString()).ToString("dd/MM/yyyy");
                }

                //get a list of each person that has a target for that date
                List<int> sales_members = new List<int>();

                sql = "select distinct sales_member_id FROM [order_database].dbo.view_sales_table_grouped where sector_date = '" + sectorDate.ToString("yyyyMMdd") + "' ";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dtStaff = new DataTable();
                    da.Fill(dtStaff);

                    for (int i = 0; i < dtStaff.Rows.Count; i++)
                    {
                        // MessageBox.Show(dt.Rows[i][0].ToString());
                        sales_members.Add(Convert.ToInt32(dtStaff.Rows[i][0].ToString()));
                    }


                }

                // load the grids here
                int sales_member_count = sales_members.Count();

                salesMemberOne = 0;
                salesMemberTwo = 0;
                salesMemberThree = 0;

                if (sales_member_count > 0)
                {
                    dgvSalesMemberOne.DataSource = salesMemberData(sales_members[0], sectorDate);
                    lblSalesMemberOne.Text = dgvSalesMemberOne.Rows[0].Cells[3].Value.ToString() ?? "";
                    percent(sales_members[0], sectorDate, lblSalesMemberOnePercent);
                    //format
                    format_dgv(dgvSalesMemberOne, pieChart1);

                    salesMemberOne = sales_members[0];

                    sales_member_count--;
                }
                if (sales_member_count > 0)
                {
                    dgvSalesMemberTwo.DataSource = salesMemberData(sales_members[1], sectorDate);
                    lblSalesMemberTwo.Text = dgvSalesMemberTwo.Rows[0].Cells[3].Value.ToString() ?? "";
                    percent(sales_members[1], sectorDate, lblSalesMemberTwoPercent);
                    //format
                    format_dgv(dgvSalesMemberTwo, pieChart2);

                    salesMemberTwo = sales_members[1];

                    sales_member_count--;
                }
                if (sales_member_count > 0)
                {
                    dgvSalesMemberThree.DataSource = salesMemberData(sales_members[2], sectorDate);
                    lblSalesMemberThree.Text = dgvSalesMemberThree.Rows[0].Cells[3].Value.ToString() ?? "";
                    percent(sales_members[2], sectorDate, lblSalesMemberThreePercent);
                    format_dgv(dgvSalesMemberThree, pieChart3);

                    salesMemberThree = sales_members[2];

                    sales_member_count--;
                }



            }

        }

        private void percent(int staff_id, DateTime sector_date, Label lbl)
        {
            string temp = "SELECT [target_percent] FROM [order_database].[dbo].[view_sales_target_percent] " +
                "WHERE sales_member_id = " + staff_id + " AND [sector_date] = '" + sector_date.ToString("yyyyMMdd") + "'";

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(temp, conn))
                {
                    var data = cmd.ExecuteScalar();

                    if (data != null)
                        lbl.Text = "Achieved: " + cmd.ExecuteScalar().ToString() + "%";

                    //work out the colours
                    if (Convert.ToDouble(cmd.ExecuteScalar()) >= 100)
                        lbl.BackColor = Color.PaleGreen;
                    else
                        lbl.BackColor = Color.PaleVioletRed;
                }

                conn.Close();
            }


        }


        private void format_dgv(DataGridView dgv, PieChart pie)
        {

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            dgv.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns[0].Visible = false;
            dgv.Columns[1].Visible = false;
            dgv.Columns[3].Visible = false;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (Convert.ToInt32(row.Cells[4].Value.ToString()) >= Convert.ToInt32(row.Cells[5].Value.ToString()))
                    row.DefaultCellStyle.BackColor = Color.PaleGreen;
                else
                    row.DefaultCellStyle.BackColor = Color.PaleVioletRed;
            }

            dgv.ClearSelection();


            //piechart setup
            //chart
            pieChart1.AxisY.Clear();
            pieChart1.AxisX.Clear();

            int target = 0, achieved = 0;

            List<string> sectorList = new List<string>();
            List<int> achievedlist = new List<int>();

            for (int i = 0; i < dgv.Rows.Count; i++)
            {

                //if achieved > the target
                if (Convert.ToInt32(dgv.Rows[i].Cells[4].Value.ToString()) >= Convert.ToInt32(dgv.Rows[i].Cells[5].Value.ToString()))
                {
                    if (Convert.ToInt32(dgv.Rows[i].Cells[4].Value.ToString()) == Convert.ToInt32(dgv.Rows[i].Cells[5].Value.ToString()))
                        achieved += Convert.ToInt32(dgv.Rows[i].Cells[4].Value.ToString());
                    else
                        achieved += Convert.ToInt32(dgv.Rows[i].Cells[5].Value.ToString());

                    if (Convert.ToInt32(dgv.Rows[i].Cells[4].Value.ToString()) > 0)
                    {
                        sectorList.Add(dgv.Rows[i].Cells[2].Value.ToString());
                        if (Convert.ToInt32(dgv.Rows[i].Cells[4].Value.ToString()) == Convert.ToInt32(dgv.Rows[i].Cells[5].Value.ToString()))
                            achievedlist.Add(Convert.ToInt32(dgv.Rows[i].Cells[4].Value.ToString()));
                        else
                            achievedlist.Add(Convert.ToInt32(dgv.Rows[i].Cells[5].Value.ToString()));
                    }
                }
                else
                {
                    achieved += Convert.ToInt32(dgv.Rows[i].Cells[4].Value.ToString());

                    if (Convert.ToInt32(dgv.Rows[i].Cells[4].Value.ToString()) > 0)
                    {
                        sectorList.Add(dgv.Rows[i].Cells[2].Value.ToString());
                        achievedlist.Add(Convert.ToInt32(dgv.Rows[i].Cells[4].Value.ToString()));
                    }
                }
                target += Convert.ToInt32(dgv.Rows[i].Cells[5].Value.ToString());

            }

            //clean up the target 
            if (achieved >= target)
                target = 0;
            else
                target = target - achieved;


            //string[] datearray = datelist.ToArray();
            string[] sectorArray = sectorList.ToArray();
            int[] achievedArray = achievedlist.ToArray();



            //Values = new ChartValues<int>(itemarray)



            var seriesCollection = new SeriesCollection();

            for (int i = 0; i < sectorArray.Length; i++)
            {
                Func<ChartPoint, string> labelPoint = chartPoint =>
                  string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation); //this is for a percentage


                PieSeries ps = new PieSeries
                {
                    Title = sectorArray[i],
                    Values = new ChartValues<double> { achievedArray[i] },
                    DataLabels = true,
                    // LabelPoint = labelPoint,
                    Foreground = System.Windows.Media.Brushes.Black,
                    PushOut = 15,

                };

                // add this slice to the others
                seriesCollection.Add(ps);
            }

            if (target > 0)
            {
                PieSeries ps2 = new PieSeries
                {
                    Title = "Remaining Target",
                    Values = new ChartValues<double> { target },
                    DataLabels = true,
                    Foreground = System.Windows.Media.Brushes.Black,
                    Fill = System.Windows.Media.Brushes.PaleVioletRed,

                };
                // Add the target to the SeriesCollection
                seriesCollection.Add(ps2);
            }

            pie.Series = seriesCollection;

            pie.LegendLocation = LegendLocation.Bottom;

        }

        private DataTable salesMemberData(int staff_id, DateTime sector_date)
        {
            DataTable dt = new DataTable();

            string sql = "select id,sector_date as [Sector Date],Sector,sales_member as [Sales Member],Achieved,[Target] " +
                "FROM [order_database].dbo.view_sales_table_grouped " +
                "where sales_member_id = " + staff_id + " AND sector_date = '" + sector_date.ToString("yyyyMMdd") + "'";

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                }

                conn.Close();
            }


            return dt;
        }


        private void dteStart_CloseUp(object sender, EventArgs e)
        {
            remove_tabs = -1;
            fill_tabcontrol();
        }

        private void dteEnd_CloseUp(object sender, EventArgs e)
        {
            remove_tabs = -1;
            fill_tabcontrol();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill_grids();
        }

        private void frmSectorManagementView_Shown(object sender, EventArgs e)
        {
            format_dgv(dgvSalesMemberOne, pieChart1);
            format_dgv(dgvSalesMemberTwo, pieChart2);
            format_dgv(dgvSalesMemberThree, pieChart3);
        }


        private void open_sector(int sector_id, string staff)
        {
            //get staff id here
            int staff_id = 0;
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("Select id FROM [user_info].dbo.[user] WHERE forename + ' ' + surname = '" + staff + "'", conn))
                    staff_id = Convert.ToInt32(cmd.ExecuteScalar().ToString());


                conn.Close();
            }

            frmSectorManagementViewDetailed frm = new frmSectorManagementViewDetailed(sector_id, staff_id);
            frm.ShowDialog();

        }

        private void dgvSalesMemberOne_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSalesMemberOne.Rows[e.RowIndex].Cells[4].Value.ToString() == "0")
                return;

            open_sector(Convert.ToInt32(dgvSalesMemberOne.Rows[e.RowIndex].Cells[0].Value.ToString()), dgvSalesMemberOne.Rows[e.RowIndex].Cells[3].Value.ToString());

        }

        private void dgvSalesMemberTwo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSalesMemberTwo.Rows[e.RowIndex].Cells[4].Value.ToString() == "0")
                return;

            open_sector(Convert.ToInt32(dgvSalesMemberTwo.Rows[e.RowIndex].Cells[0].Value.ToString()), dgvSalesMemberTwo.Rows[e.RowIndex].Cells[3].Value.ToString());

        }

        private void dgvSalesMemberThree_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSalesMemberThree.Rows[e.RowIndex].Cells[4].Value.ToString() == "0")
                return;

            open_sector(Convert.ToInt32(dgvSalesMemberThree.Rows[e.RowIndex].Cells[0].Value.ToString()), dgvSalesMemberThree.Rows[e.RowIndex].Cells[3].Value.ToString());

        }

        private void btnDetailed_Click(object sender, EventArgs e)
        {

            if (salesMemberOne == 0)
                return;

            frmSectorPowerBi frm = new frmSectorPowerBi(salesMemberOne);
            frm.ShowDialog();
        }


        private void PieChartOne_MouseClick(object sender, MouseEventArgs e)
        {
            frmSectorManagementViewDetailed frm = new frmSectorManagementViewDetailed(1, 2);
            frm.ShowDialog();


        }

        private void btnSalesMemberTwoHistoric_Click(object sender, EventArgs e)
        {
            if (salesMemberTwo == 0)
                return;

            frmSectorPowerBi frm = new frmSectorPowerBi(salesMemberTwo);
            frm.ShowDialog();
        }

        private void btnSalesMemberThreeHistoric_Click(object sender, EventArgs e)
        {
            if (salesMemberThree == 0)
                return;

            frmSectorPowerBi frm = new frmSectorPowerBi(salesMemberThree);
            frm.ShowDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            int currentExcelRow = 1;
            DataGridView dgv = new DataGridView();
            string file = @"C:\temp\sectors_" + DateTime.Now.ToString("dd-MM-yyyy mm_ss") + ".xlsx";
            //opening method 

            Excel.Application xlApp = new Excel.Application();

            int skipSheetIncrement = -1;
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Add();
            Excel.Worksheet xlWorksheet = xlWorkbook.Worksheets[1];

            xlApp.Visible = true; //make it visible for now 
            xlApp.WindowState = Excel.XlWindowState.xlMaximized;

            for (int staff_loop = 1; staff_loop <= 3; staff_loop++)
            {
                int staff_id = 0;

                if (staff_loop == 1)
                {
                    //salesMemberOne
                    if (salesMemberOne == 0)
                        continue;
                    else
                    {
                        staff_id = salesMemberOne;
                        dgv = dgvSalesMemberOne;
                    }
                }
                else if (staff_loop == 2)
                {
                    //salesMemberOne
                    if (salesMemberTwo == 0)
                        continue;
                    else
                    {
                        staff_id = salesMemberTwo;
                        dgv = dgvSalesMemberTwo;
                    }
                }
                else if (staff_loop == 3)
                {
                    //salesMemberOne
                    if (salesMemberThree == 0)
                        continue;
                    else
                    {
                        staff_id = salesMemberThree;
                        dgv = dgvSalesMemberThree;
                    }
                }

                if (skipSheetIncrement == 0)
                {
                    currentExcelRow = 1;
                    Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkbook.Worksheets.Add
                        (System.Reflection.Missing.Value, xlWorkbook.Worksheets[xlWorkbook.Worksheets.Count],
                        System.Reflection.Missing.Value, System.Reflection.Missing.Value);

                    xlWorksheet = xlWorkbook.Sheets[staff_loop];

                    ////// Get the range of the column you want to format
                    ////Excel.Range range2 = xlWorksheet.Columns[5];
                    ////// Apply percentage format to the range
                    ////range2.NumberFormat = "0.00%";

                }

                //get the staff member we are working on 
                xlWorksheet.Name = get_staff_name(staff_id);
                xlWorksheet.Range["A" + currentExcelRow].Value2 = get_staff_name(staff_id) + " Sectors";
                xlWorksheet.Range["A" + currentExcelRow + ":E" + currentExcelRow].Merge();
                
                xlWorksheet.Range["A" + currentExcelRow + ":E" + currentExcelRow].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter; 
                xlWorksheet.Range["A" + currentExcelRow + ":E" + currentExcelRow].Cells.Font.Size = 22; 


                currentExcelRow++;

                // go through each sector
                for (int sector_loop = 0; sector_loop < dgv.Rows.Count; sector_loop++)
                {

                    if (get_staff_id(dgv.Rows[sector_loop].Cells[3].Value.ToString()) == 0)
                        continue;

                    if (Convert.ToInt32(dgv.Rows[sector_loop].Cells[4].Value.ToString()) == 0)
                        continue;

                    //sector header
                    xlWorksheet.Range["A" + currentExcelRow].Value2 = dgv.Rows[sector_loop].Cells[2].Value.ToString();
                    xlWorksheet.Range["A" + currentExcelRow + ":E" + currentExcelRow].Merge();
                    xlWorksheet.Range["A" + currentExcelRow + ":E" + currentExcelRow].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    xlWorksheet.Range["A" + currentExcelRow + ":E" + currentExcelRow].Cells.Font.Size = 15;
                    xlWorksheet.Range["A" + currentExcelRow + ":E" + currentExcelRow].Interior.Color = Color.LightSkyBlue;

                   currentExcelRow++;
                    //now we go through each of the items logged for this sector
                    DataTable items_logged_dt = fill_sector_dt(Convert.ToInt32(dgv.Rows[sector_loop].Cells[0].Value.ToString()), staff_id);

                    if (items_logged_dt.Rows.Count == 0)
                        continue;


                    //add all of the headers to the sheet
                    List<string> sector_headers = get_sector_headers(Convert.ToInt32(dgv.Rows[sector_loop].Cells[0].Value.ToString()), staff_id);

                    for (int sector_header_count = 0;sector_header_count < sector_headers.Count;sector_header_count++)
                    {
                        xlWorksheet.Cells[currentExcelRow, sector_header_count + 1] = sector_headers[sector_header_count];
                    }
                    xlWorksheet.Range["A" + currentExcelRow + ":E" + currentExcelRow].Cells.Font.Bold = true;
                    currentExcelRow++;


                    //add the items in here

                    for (int items_logged_count = 0; items_logged_count < items_logged_dt.Rows.Count; items_logged_count++) //row loop
                    {

                        for (int sector_header_count = 0; sector_header_count < sector_headers.Count; sector_header_count++) //column loop
                        {
                            xlWorksheet.Cells[currentExcelRow, sector_header_count + 1] = items_logged_dt.Rows[items_logged_count][sector_header_count].ToString();
                        }

                        currentExcelRow++;

                    }

                    
                    xlWorksheet.Range["A" + currentExcelRow].Value2 = " ";
                    xlWorksheet.Range["A" + currentExcelRow + ":E" + currentExcelRow].Merge();
                    currentExcelRow++;

                }




                //xlWorksheet.Range["A1"].Value2 = "Target"; 

                //xlWorksheet.Cells[1][excel_row].Value2 = 22; 





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



                xlWorksheet.Columns[4].ColumnWidth = 98.14; //size and wrap columns
                xlWorksheet.Columns[4].WrapText = true;



                //border active cells 

                range.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                range.Borders.Color = ColorTranslator.ToOle(Color.Black);

                skipSheetIncrement = 0;

                Excel.PageSetup xlPageSetUp = xlWorksheet.PageSetup;
                xlPageSetUp.Zoom = false;
                xlPageSetUp.FitToPagesWide = 1;
                xlPageSetUp.FitToPagesTall = 2;
                xlPageSetUp.Orientation = Excel.XlPageOrientation.xlPortrait;

            }

            //Set print margins 
            //Excel.PageSetup xlPageSetUp = xlWorksheet.PageSetup; 
            //xlPageSetUp.Zoom = false; 
            //xlPageSetUp.FitToPagesWide = 1; 
            //xlPageSetUp.Orientation = Excel.XlPageOrientation.xlPortrait; 



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


        private DataTable fill_sector_dt(int sector_id, int staff)
        {

            string sql_correspondence = "select date_created [Correspondence Date], rtrim(customer_name) as [Customer],Contact,body as [Notes], " +
               // "CASE WHEN issue_with_leadtime = 0 THEN CAST(0 AS BIT) WHEN issue_with_leadtime IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Leadtime Issue]," +
               //"CASE WHEN issue_with_quote_turnaround_time = 0 THEN CAST(0 AS BIT) WHEN issue_with_quote_turnaround_time IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Quote Turnaround Issue]," +
               // "CASE WHEN issue_with_product = 0 THEN CAST(0 AS BIT) WHEN issue_with_product IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Product Issue]," +
               //"CASE WHEN issue_with_installation = 0 THEN CAST(0 AS BIT) WHEN issue_with_installation IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Installation Issue]," +
               //"CASE WHEN issue_with_service = 0 THEN CAST(0 AS BIT) WHEN issue_with_service IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Service Issue]," +
               "case when no_follow_up = -1 then 'No follow up' else Convert(varchar,cast(next_correspondence_date as date),103)   end  as [Next Correspondence], Sector " +
               "FROM [order_database].dbo.quotation_chase_customer q " +
               "left join [order_database].dbo.sales_table s on q.sector_id = s.id " +
                "where sector_id = " + sector_id + " and correspondence_by = " + staff;



            string sql_quotations = "select chase_date as [Chase Date],'SL' + CAST(q.quote_id as nvarchar(max)) as [Quote ID],Name as Customer,chase_description as [Chase Notes]," +
                //"CASE WHEN phone = 0 THEN CAST(0 AS BIT) WHEN phone IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS Phone, " +
                //"CASE WHEN email = 0 THEN CAST(0 AS BIT) WHEN email IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS Email, " +
                "CASE WHEN chase_complete = 0 THEN CAST(0 AS BIT) WHEN chase_complete IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END as [Chase Complete], " +
                "Sector " +
                "FROM [order_database].dbo.quotation_chase_log_slimline q " +
                "left join [order_database].dbo.sales_table s on q.sector_id = s.id " +
                "left join[price_master].dbo.[sl_quotation] sq on q.quote_id = sq.quote_id " +
                "left join[dsl_fitting].dbo.sales_ledger sl on sq.customer_acc_ref = sl.ACCOUNT_REF " +
                "where sector_id = " + sector_id + " AND chased_by = " + staff + " AND sq.highest_issue = -1" +
                "union all " +
                "select chase_date as [Chase Date],CAST(q.quote_id as nvarchar(max)) as [Quote ID],Customer,chase_description as [Chase Notes], " +
                //"CASE WHEN phone = 0 THEN CAST(0 AS BIT) WHEN phone IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS Phone, " +
                //"CASE WHEN email = 0 THEN CAST(0 AS BIT) WHEN email IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS Email, " +
                "CASE WHEN chase_complete = 0 THEN CAST(0 AS BIT) WHEN chase_complete IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END as [Chase Complete], " +
                "Sector " +
                "FROM [order_database].dbo.quotation_chase_log q " +
                "left join [order_database].dbo.sales_table s on q.sector_id = s.id " +
                "left join (select q.quote_id,q.customer FROM [order_database].dbo.solidworks_quotation_log q " +
                        "right join [order_database].dbo.view_solidworks_max_rev r on q.quote_id = r.quote_id AND q.revision_number = r.revision_number) sq on q.quote_id = sq.quote_id " +
                "where sector_id = " + sector_id + " AND chased_by = " + staff;

            string sql_lead = "select lead_date as [Lead Date],Customer,contact_name as [Contact Name]," +
                "notes as [Lead Notes], u.forename + ' ' + u.surname as [Allocated to]" +
                "FROM [order_database].dbo.sales_new_leads s " +
                "left join [user_info].dbo.[user] u on s.allocated_to = u.id " +
                "left join [order_database].dbo.sales_table st on s.sector_id = st.id " +
                "where sector_id = " + sector_id + " AND lead_by = " + staff;



            if ("Correspondence" == "Correspondence")
            {
                using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql_correspondence, conn))
                    {

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                            return dt;

                    }
                }
            }

            if ("Quotation" == "Quotation")
            {
                using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql_quotations, conn))
                    {

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                            return dt;

                    }
                }
            }

            if ("Leads" == "Leads")
            {
                using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql_lead, conn))
                    {

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                            return dt;

                    }
                }
            }

            DataTable dtEnd = new DataTable();
            return dtEnd;

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


        private string get_staff_name(int staff) //staff number == salesMemberONE // TWO // THREE
        {

            string sql = "SELECT forename + ' ' + surname FROM [user_info].dbo.[user] WHERE id = " + staff;

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    return cmd.ExecuteScalar().ToString();
                }

                conn.Close();
            }
        }

        private int get_staff_id(string staff) //staff number == salesMemberONE // TWO // THREE
        {

            string sql = "SELECT id FROM [user_info].dbo.[user] WHERE forename + ' ' + surname = '" + staff + "'";

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar().ToString());
                }

                conn.Close();
            }
        }




        private static List<string> get_sector_headers (int sector_id, int staff)
        {
            //headers for each table
            List<string> correspondence_headers = new List<string>()
            {
                "Correspondence Date","Customer","Contact","Notes",
                //"Leadtime Issue","Quote Turnaround", "Product Issue", "Installation Issue","Service Issue",
                "Next Correspondence"
            };
            List<string> quotation_headers = new List<string>()
            {
                "Chase Date","Quote ID", "Customer","Chase Notes",//"Phone","Email",
                "Chase Complete"
            };
            List<string> lead_headers = new List<string>()
            {
                "Lead Date","Customer","Contact Details","Allocated to","Lead Notes"
            };


            string sql_correspondence = "select q.id,date_created [Correspondence Date], rtrim(customer_name) as [Customer],Contact,body as [Notes]," +
            "CASE WHEN issue_with_leadtime = 0 THEN CAST(0 AS BIT) WHEN issue_with_leadtime IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Leadtime Issue]," +
            "CASE WHEN issue_with_quote_turnaround_time = 0 THEN CAST(0 AS BIT) WHEN issue_with_quote_turnaround_time IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Quote Turnaround Issue]," +
            "CASE WHEN issue_with_product = 0 THEN CAST(0 AS BIT) WHEN issue_with_product IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Product Issue]," +
            "CASE WHEN issue_with_installation = 0 THEN CAST(0 AS BIT) WHEN issue_with_installation IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Installation Issue]," +
            "CASE WHEN issue_with_service = 0 THEN CAST(0 AS BIT) WHEN issue_with_service IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Service Issue]," +
            "next_correspondence_date [Next Correspondence], Sector " +
            "FROM [order_database].dbo.quotation_chase_customer q " +
            "left join [order_database].dbo.sales_table s on q.sector_id = s.id " +
            "where sector_id = " + sector_id + " and correspondence_by = " + staff;



            string sql_quotations = "select q.id,chase_date as [Chase Date],'SL' + CAST(q.quote_id as nvarchar(max)) as [Quote ID],Name as Customer,chase_description as [Chase Notes]," +
                "CASE WHEN phone = 0 THEN CAST(0 AS BIT) WHEN phone IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS Phone, " +
                "CASE WHEN email = 0 THEN CAST(0 AS BIT) WHEN email IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS Email, " +
                "CASE WHEN chase_complete = 0 THEN CAST(0 AS BIT) WHEN chase_complete IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END as [Chase Complete], " +
                "Sector " +
                "FROM [order_database].dbo.quotation_chase_log_slimline q " +
                "left join [order_database].dbo.sales_table s on q.sector_id = s.id " +
                "left join[price_master].dbo.[sl_quotation] sq on q.quote_id = sq.quote_id " +
                "left join[dsl_fitting].dbo.sales_ledger sl on sq.customer_acc_ref = sl.ACCOUNT_REF " +
                "where sector_id = " + sector_id + " AND chased_by = " + staff + " AND sq.highest_issue = -1" +
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
                "where sector_id = " + sector_id + " AND chased_by = " + staff;

            string sql_lead = "select s.id,lead_date as [Lead Date],Customer,contact_name as [Contact Name],contact_details as [Contact Details]," +
                "u.forename + ' ' + u.surname as [Allocated to],sector,notes as [Lead Notes]" +
                "FROM [order_database].dbo.sales_new_leads s " +
                "left join [user_info].dbo.[user] u on s.allocated_to = u.id " +
                "left join [order_database].dbo.sales_table st on s.sector_id = st.id " +
                "where sector_id = " + sector_id + " AND lead_by = " + staff;



            if ("Correspondence" == "Correspondence")
            {
                using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql_correspondence, conn))
                    {

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                            return correspondence_headers;

                    }
                }
            }

            if ("Quotation" == "Quotation")
            {
                using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql_quotations, conn))
                    {

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                            return quotation_headers;

                    }
                }
            }

            if ("Leads" == "Leads")
            {
                using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql_lead, conn))
                    {

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                            return lead_headers;

                    }
                }
            }



            return correspondence_headers; //probably return something else


        }

        private void buttonFormatting1_Click(object sender, EventArgs e)
        {
            printImage();
        }


        private void printImage()
        {

            string path = @"C:\temp\temp_" + DateTime.Now.ToString("hh_ss") + ".jpg";

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
                    bitmap.Save(path);
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
                    Image i = Image.FromFile(path);
                    Rectangle m = args.MarginBounds;
                    if ((double)i.Width / (double)i.Height > (double)m.Width / (double)m.Height) // image is wider
                    {
                        m.Height = (int)((double)i.Height / (double)i.Width * (double)m.Width);
                        m.Height = 700;
                        m.Width = 650;
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

    }
}
