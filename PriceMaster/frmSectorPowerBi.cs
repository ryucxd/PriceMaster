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
    public partial class frmSectorPowerBi : Form
    {
        public int staff_id { get; set; }
        public frmSectorPowerBi(int staff_id)
        {
            InitializeComponent();

            int temp = DayOfWeek.Monday - DateTime.Now.DayOfWeek;
            DateTime monday = DateTime.Now.AddDays(temp);

            dteStart.Value = monday.AddMonths(-1);
            dteEnd.Value = monday;

            load_chart(staff_id);

            this.staff_id = staff_id;
        }


        private void load_chart(int staff_id)
        {
            string sql = "SELECT Convert(varchar,cast([sector_date] as date),103),[target_percent] " +
                "FROM [order_database].[dbo].[view_sales_target_percent] " +
                "WHERE sales_member_id = " + staff_id + " and sector_date >= '" + dteStart.Value.ToString("yyyyMMdd") + "' AND sector_date <= '" + dteEnd.Value.ToString("yyyyMMdd") + "' ";



            List<string> sectorDate = new List<string>();
            List<double> sectorPercent = new List<double>();

            double averagePercent = 0;

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();


                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        sectorDate.Add(dt.Rows[i][0].ToString().Substring(0,10));
                        sectorPercent.Add(Convert.ToDouble(dt.Rows[i][1].ToString()));

                        averagePercent += Convert.ToDouble(dt.Rows[i][1].ToString());
                    }

                    lblPercent.Text = "Average Percent: " + Math.Round(averagePercent / sectorPercent.Count,2) + "%";
                }

                cartesianChart1.AxisX.Clear();
                cartesianChart1.AxisY.Clear();

                cartesianChart1.Series = new LiveCharts.SeriesCollection
                {
                    new ColumnSeries
                    {
                        Title = "Percentage",
                        FontSize = 12,
                        DataLabels = true,

                       //Fill = System.Windows.Media.Brushes.PowderBlue,
                       Foreground = System.Windows.Media.Brushes.Black,
                        Values = new ChartValues<double>(sectorPercent),
                        LabelPoint = point => $"{point.Y}%"

                    }
            };
                cartesianChart1.AxisX.Add(new Axis
                {
                    Title = "Week",
                    FontSize = 10,
                    Foreground = System.Windows.Media.Brushes.Black,
                    Labels = sectorDate
                });


                double minValue = sectorPercent.Min();
                double maxValue = sectorPercent.Max();

                // Ensure the range includes 100
                double yMin = Math.Min(minValue, 0); 
                double yMax = Math.Max(maxValue, 120);


                cartesianChart1.AxisY.Add(new Axis
                {
                    MinValue = yMin,
                    MaxValue = yMax,
                    Sections = new SectionsCollection
                    {
                        new AxisSection
                        {
                            Value = 100,
                            SectionWidth = 0,
                            Stroke = System.Windows.Media.Brushes.DarkGreen,
                            StrokeThickness = 2
                        }
                    }
                });

                conn.Close();
            }


        }

        private void dteStart_CloseUp(object sender, EventArgs e)
        {
            load_chart(staff_id);
        }

        private void dteEnd_CloseUp(object sender, EventArgs e)
        {
            load_chart(staff_id);
        }
    }
}
