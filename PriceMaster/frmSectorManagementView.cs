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

namespace PriceMaster
{
    public partial class frmSectorManagementView : Form
    {
        public int remove_tabs { get; set; }
        public frmSectorManagementView()
        {
            InitializeComponent();

            //monday
            int temp = DayOfWeek.Monday - DateTime.Now.DayOfWeek;
            DateTime monday = DateTime.Now.AddDays(temp);

            dteStart.Value = monday;
            dteEnd.Value = monday.AddDays(5);
            remove_tabs = -1;
            fill_tabcontrol();
            fill_grids();

        }


        private void fill_tabcontrol()
        {
            if (remove_tabs == -1)
            {
                //tabControl.TabPages.Remove()
                tabControl.TabPages.Clear();

                string sql = "select distinct Convert(varchar,cast(sector_date  as date),103) FROM [order_database].dbo.view_sales_table_grouped " +
                "where sector_date >= '" + dteStart.Value.ToString("yyyyMMdd") + "' AND sector_date <= '" + dteEnd.Value.ToString("yyyyMMdd") + "'";

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
                            Text = dt.Rows[i][0].ToString()
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
                "where sector_date >= '" + dteStart.Value.ToString("yyyyMMdd") + "' AND sector_date <= '" + dteEnd.Value.ToString("yyyyMMdd") + "'";

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                DataTable dt = new DataTable();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    sectorDate = Convert.ToDateTime(dt.Rows[tabControl.SelectedIndex][0].ToString());
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

                if (sales_member_count > 0)
                {
                    dgvSalesMemberOne.DataSource = salesMemberData(sales_members[0], sectorDate);
                    lblSalesMemberOne.Text = dgvSalesMemberOne.Rows[0].Cells[3].Value.ToString() ?? "";
                    //format
                    format_dgv(dgvSalesMemberOne,pieChart1);
                    //piechart

                    sales_member_count--;
                }
                if (sales_member_count > 0)
                {
                    dgvSalesMemberTwo.DataSource = salesMemberData(sales_members[1], sectorDate);
                    lblSalesMemberTwo.Text = dgvSalesMemberTwo.Rows[0].Cells[3].Value.ToString() ?? "";
                    //format
                    format_dgv(dgvSalesMemberTwo,pieChart2);
                    //piechart

                    sales_member_count--;
                }
                if (sales_member_count > 0)
                {
                    dgvSalesMemberThree.DataSource = salesMemberData(sales_members[2], sectorDate);
                    lblSalesMemberThree.Text = dgvSalesMemberThree.Rows[0].Cells[3].Value.ToString() ?? "";
                    format_dgv(dgvSalesMemberThree, pieChart3);
                    //piechart

                    sales_member_count--;
                }



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
                    achieved += Convert.ToInt32(dgv.Rows[i].Cells[4].Value.ToString());

                    if (Convert.ToInt32(dgv.Rows[i].Cells[4].Value.ToString()) > 0)
                    {
                        sectorList.Add(dgv.Rows[i].Cells[2].Value.ToString());
                        achievedlist.Add(Convert.ToInt32(dgv.Rows[i].Cells[4].Value.ToString()));
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
                    Title = "Target",
                    Values = new ChartValues<double> { target },
                    DataLabels = true,
                    Foreground = System.Windows.Media.Brushes.Black,

                };
                // Add the target to the SeriesCollection
                seriesCollection.Add(ps2);
            }



            pie.Series = seriesCollection;

            pie.LegendLocation = LegendLocation.Bottom;

        }

        private DataTable salesMemberData(int staff_id,DateTime sector_date)
        {
            DataTable dt = new DataTable();

            string sql = "select id,sector_date as [Sector Date],Sector,sales_member as [Sales Member],Achieved,[Target] " +
                "FROM [order_database].dbo.view_sales_table_grouped " +
                "where sales_member_id = " + staff_id + " AND sector_date = '" + sector_date.ToString("yyyyMMdd") + "'";

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql,conn))
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
    }
}
