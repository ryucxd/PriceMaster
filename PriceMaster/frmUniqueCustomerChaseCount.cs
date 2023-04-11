using LiveCharts;
using LiveCharts.Wpf;
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
    public partial class frmUniqueCustomerChaseCount : Form
    {
        public frmUniqueCustomerChaseCount()
        {
            InitializeComponent();
            fillCombo();
            load_chart();
        }

        private void fillCombo()
        {
            string sql = "SELECT distinct u.forename + ' ' + u.surname as chased_by FROM [order_database].dbo.quotation_chase_log a " +
                       "left join[user_info].dbo.[user] u on a.chased_by = u.id ";

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader dr2 = cmd.ExecuteReader();
                    while (dr2.Read())
                    {
                        cmbStaffSelection.Items.Add(dr2[0]);
                    }
                }
                conn.Close();
            }
        }

        private void load_chart()
        {

            List<string> Customer = new List<string>();
            List<int> Count = new List<int>();

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                string sql = "[order_database].[dbo].usp_quotation_unique_customer_chase_count";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@startDate", SqlDbType.NVarChar).Value = dteStart.Value.ToString("yyyyMMdd");
                    cmd.Parameters.Add("@endDate", SqlDbType.NVarChar).Value = dteEnd.Value.ToString("yyyyMMdd");
                    cmd.Parameters.Add("@staff", SqlDbType.NVarChar).Value = cmbStaffSelection.Text;
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Customer.Add(dr[0].ToString());
                        Count.Add(dr.GetInt32(1));
                    }
                }

                cartesianChart1.AxisX.Clear();
                cartesianChart1.AxisY.Clear();

                cartesianChart1.Series = new LiveCharts.SeriesCollection
                {
                    new ColumnSeries
                    {
                        Title = "Customer Chases",
                        FontSize = 12,
                        DataLabels = true,

                        Fill = System.Windows.Media.Brushes.PowderBlue,

                        Values = new ChartValues<int>(Count)

                    }
            };
                cartesianChart1.AxisX.Add(new Axis
                {
                    Title = "Customer",
                    FontSize = 10,
                    Labels = Customer
                });

                conn.Close();
            }
        }

        private void dteStart_CloseUp(object sender, EventArgs e)
        {
            load_chart();
        }

        private void dteEnd_CloseUp(object sender, EventArgs e)
        {
            load_chart();
        }

        private void cmbStaffSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_chart();
        }
    }
}
