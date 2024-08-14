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
using System.Drawing.Printing;

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

                string fullname = "";
                using (SqlCommand cmd = new SqlCommand("SELECT forename + ' ' + surname FROM [user_info].dbo.[user] WHERE id = " + staff_id, conn))
                    fullname = cmd.ExecuteScalar().ToString();


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

                    lblPercent.Text = fullname + " Average Percent: " + Math.Round(averagePercent / sectorPercent.Count,2) + "%";
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

        private void btnPrint_Click(object sender, EventArgs e)
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
                        m.Width = 1000;
                    }
                    else
                    {
                        m.Width = (int)((double)i.Width / (double)i.Height * (double)m.Height);
                    }
                    args.Graphics.DrawImage(i, m);
                };

                pd.DefaultPageSettings.Landscape = true;
                Margins margins = new Margins(50, 50, 50, 50);
                pd.DefaultPageSettings.Margins = margins;
                pd.Print();
            }
            catch
            { }
        }
    }
}
