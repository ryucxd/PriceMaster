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
    public partial class frmLeadList : Form
    {
        public frmLeadList()
        {
            InitializeComponent();

            fill_leads();
            fill_targets();
        }

        private void fill_leads()
        {

            try
            {
                dataGridView1.Columns.Remove("Add Prospect");
            }
            catch { }


            string sql = "select lead_date as [Lead Time],Customer,contact_name as [Contact Name],customer_address as [Customer Address], " +
                "contact_details as [Contact Details],u.forename + ' ' + u.surname as [Allocated to],Sector,Notes,prospect_acc_ref " +
                "FROM [order_database].dbo.sales_new_leads s " +
                "left join [user_info].dbo.[user] u on s.allocated_to = u.id " +
                "left join [order_database].dbo.sales_table st on s.sector_id = st.id " +
                "where lead_by = " + CONNECT.staffID;


            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;

                }

                    conn.Close();
            }

            DataGridViewButtonColumn prospectButton = new DataGridViewButtonColumn();
            prospectButton.Name = "Add Prospect";
            prospectButton.Text = "Add Prospect";
            prospectButton.UseColumnTextForButtonValue = true;
            int columnIndex = (dataGridView1.Columns.Count);
            if (dataGridView1.Columns["Add Prospect"] == null)
            {
                dataGridView1.Columns.Insert(columnIndex, prospectButton);
            }

        }


        private void fill_targets()
        {

            string sql = "select Sector,Achieved,Target FROM [order_database].dbo.view_sales_table_grouped " +
                "where sector_date = CAST(DATEADD(wk, DATEDIFF(wk,0,GETDATE()), 0) as date) AND sales_member_id = " + CONNECT.staffID;

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {

                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvTarget.DataSource = dt;



                }

                conn.Close();



                format_targets();

            }
        }

        private void format_targets()
        {
            foreach (DataGridViewColumn col in dgvTarget.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dgvTarget.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            //colours
            for (int i = 0; i < dgvTarget.Rows.Count; i++)
            {
                //if achieved is >= target
                if (Convert.ToInt32(dgvTarget.Rows[i].Cells[1].Value.ToString()) >= Convert.ToInt32(dgvTarget.Rows[i].Cells[2].Value.ToString()))
                    dgvTarget.Rows[i].DefaultCellStyle.BackColor = Color.PaleGreen;
                else
                    dgvTarget.Rows[i].DefaultCellStyle.BackColor = Color.PaleVioletRed;

            }





            dgvTarget.ClearSelection();

            //chart
            pieChart1.AxisY.Clear();
            pieChart1.AxisX.Clear();

            int target = 0, achieved = 0;

            List<string> sectorList = new List<string>();
            List<int> achievedlist = new List<int>();

            for (int i = 0; i < dgvTarget.Rows.Count; i++)
            {

                //if achieved > the target
                if (Convert.ToInt32(dgvTarget.Rows[i].Cells[1].Value.ToString()) >= Convert.ToInt32(dgvTarget.Rows[i].Cells[2].Value.ToString()))
                {
                    achieved += Convert.ToInt32(dgvTarget.Rows[i].Cells[2].Value.ToString());

                    if (Convert.ToInt32(dgvTarget.Rows[i].Cells[1].Value.ToString()) > 0)
                    {
                        sectorList.Add(dgvTarget.Rows[i].Cells[0].Value.ToString());
                        achievedlist.Add(Convert.ToInt32(dgvTarget.Rows[i].Cells[2].Value.ToString()));
                    }
                }
                else
                {
                    achieved += Convert.ToInt32(dgvTarget.Rows[i].Cells[1].Value.ToString());

                    if (Convert.ToInt32(dgvTarget.Rows[i].Cells[1].Value.ToString()) > 0)
                    {
                        sectorList.Add(dgvTarget.Rows[i].Cells[0].Value.ToString());
                        achievedlist.Add(Convert.ToInt32(dgvTarget.Rows[i].Cells[1].Value.ToString()));
                    }
                }


                target += Convert.ToInt32(dgvTarget.Rows[i].Cells[2].Value.ToString());

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



            pieChart1.Series = seriesCollection;

            pieChart1.LegendLocation = LegendLocation.Bottom;




            //also format the lead history dgv here

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvTarget.ClearSelection();
            dataGridView1.ClearSelection();
        }

        private void frmLeadList_Shown(object sender, EventArgs e)
        {
            format_targets();
        }

        private void btnLead_Click(object sender, EventArgs e)
        {
            //insert new leadtime

            frmLeadInsert frm = new frmLeadInsert();
            frm.ShowDialog();

            fill_leads();
            fill_targets();
        }
    }
}
