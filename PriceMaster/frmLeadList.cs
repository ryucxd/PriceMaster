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
        public int id_index { get; set; }
        public int lead_time_index { get; set; }
        public int customer_index { get; set; }
        public int contact_name_index { get; set; }
        public int customer_address_index { get; set; }
        public int contact_details_index { get; set; }
        public int allocated_to_index { get; set; }
        public int sector_index { get; set; }
        public int notes_index { get; set; }
        public int contacted_index { get; set; }
        public int add_prospect_button_index { get; set; }
        public int delete_lead_index { get; set; }

        public int rotec_customer_index { get; set; }
        public frmLeadList()
        {
            InitializeComponent();

            fill_leads();
            fill_targets();
        }

        private void fill_leads()
        {

            if (dataGridView1.Columns.Contains("Add Prospect") == true)
                dataGridView1.Columns.Remove("Add Prospect");

            if (dataGridView1.Columns.Contains("Delete Lead") == true)
                dataGridView1.Columns.Remove("Delete Lead");

            if (dataGridView1.Columns.Contains("Contacted") == true)
                dataGridView1.Columns.Remove("Contacted");


            string sql = "select s.id,lead_date as [Lead Time],Customer,contact_name as [Contact Name],customer_address as [Customer Address], " +
                "contact_details as [Contact Details],u.forename + ' ' + u.surname as [Allocated to],Sector,Notes,contacted_on_linked_in,rotec_customer " +
                "FROM [order_database].dbo.sales_new_leads s " +
                "left join [user_info].dbo.[user] u on s.allocated_to = u.id " +
                "left join [order_database].dbo.sales_table st on s.sector_id = st.id " +
                "where prospect_added_by is null AND Customer LIKE '%" + txtCustomerSearch.Text + "%' " +
                " AND u.forename + ' ' + u.surname LIKE '%" + cmbStaff.Text + "%'" +
                " ORDER BY rotec_customer DESC,lead_date desc"; // lead_by = " + CONNECT.staffID;


            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // while we are here fill the combobox of all available staff members
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (cmbStaff.Items.Contains(dr[6].ToString()) == false)
                            cmbStaff.Items.Add(dr[6].ToString());

                    }

                    dataGridView1.DataSource = dt;
                }

                conn.Close();
            }

            column_index();

            DataGridViewButtonColumn prospectButton = new DataGridViewButtonColumn();
            prospectButton.Name = "Add Prospect";
            prospectButton.Text = "Add Prospect";
            prospectButton.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Insert(rotec_customer_index + 1, prospectButton);

            column_index();

            DataGridViewButtonColumn leadButton = new DataGridViewButtonColumn();
            leadButton.Name = "Delete Lead";
            leadButton.Text = "Delete Lead";
            leadButton.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Insert(rotec_customer_index + 2, leadButton);

            column_index();

            DataGridViewButtonColumn ContactedButton = new DataGridViewButtonColumn();
            ContactedButton.Name = "Contacted";
            ContactedButton.Text = "Contacted";
            ContactedButton.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Insert(rotec_customer_index + 3, ContactedButton);

            column_index();

            format_targets();
        }

        private void column_index()
        {
            if (dataGridView1.Columns.Contains("Add Prospect") == true)
                add_prospect_button_index = dataGridView1.Columns["Add Prospect"].Index;

            if (dataGridView1.Columns.Contains("Delete Lead") == true)
                delete_lead_index = dataGridView1.Columns["Delete Lead"].Index;

            if (dataGridView1.Columns.Contains("Contacted") == true)
                delete_lead_index = dataGridView1.Columns["Contacted"].Index;

            id_index = dataGridView1.Columns["id"].Index;
            lead_time_index = dataGridView1.Columns["Lead Time"].Index;
            customer_index = dataGridView1.Columns["Customer"].Index;
            contact_name_index = dataGridView1.Columns["Contact Name"].Index;
            customer_address_index = dataGridView1.Columns["Customer Address"].Index;
            contact_details_index = dataGridView1.Columns["Contact Details"].Index;
            allocated_to_index = dataGridView1.Columns["Allocated to"].Index;
            sector_index = dataGridView1.Columns["Sector"].Index;
            notes_index = dataGridView1.Columns["Notes"].Index;
            contacted_index = dataGridView1.Columns["contacted_on_linked_in"].Index;
            rotec_customer_index = dataGridView1.Columns["rotec_customer"].Index;

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

            if (dgvTarget.Rows.Count == 0 && dataGridView1.Rows.Count == 0)
                return;


            if (dgvTarget.Rows.Count > 0)
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

            }


            if (dataGridView1.Rows.Count > 0)
            {
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
                column_index();
                dataGridView1.Columns[customer_address_index].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[sector_index].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[notes_index].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataGridView1.Columns[id_index].Visible = false;

                dataGridView1.Columns[rotec_customer_index].Visible = false;

                dataGridView1.Columns[contacted_index].Visible = false;


                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[rotec_customer_index].Value.ToString() == "-1")
                        row.DefaultCellStyle.BackColor = Color.Orange;
                    else if (row.Cells[contacted_index].Value.ToString() == "-1")
                        row.DefaultCellStyle.BackColor = Color.LightSkyBlue;
                }
            }

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



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns["Add Prospect"].Index == e.ColumnIndex)
            {

                frmAddCustomerToSalesProspect frm = new frmAddCustomerToSalesProspect(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[id_index].Value.ToString()), dataGridView1.Rows[e.RowIndex].Cells[customer_index].Value.ToString());
                frm.ShowDialog();

                fill_leads();
                fill_targets();

                format_targets();

            }

            if (dataGridView1.Columns["Delete Lead"].Index == e.ColumnIndex)
            {

                //delete the prospect by adding 'corey' into the acc ref
                string sql = "UPDATE [order_database].dbo.sales_new_leads " +
                        "SET prospect_acc_ref = 'corey',prospect_added_by = " + CONNECT.staffID + ", prospect_added_date = GETDATE()  " +
                        "WHERE id = " + dataGridView1.Rows[e.RowIndex].Cells[id_index].Value.ToString();

                using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();

                }

                fill_leads();
                fill_targets();

                format_targets();

            }

            if (dataGridView1.Columns["Contacted"].Index == e.ColumnIndex)
            {
                //mark this as contacted
                int value = -1;

                if (dataGridView1.Rows[e.RowIndex].Cells[contacted_index].Value.ToString() == "-1")
                    value = 0;

                string sql = "UPDATE [order_database].dbo.[sales_new_leads] " +
                    "SET contacted_on_linked_in = " + value + " WHERE id = " + dataGridView1.Rows[e.RowIndex].Cells[id_index].Value.ToString();

                using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                        cmd.ExecuteNonQuery();

                    if (value == -1)
                        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                    else
                        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Empty;

                    conn.Close();
                }

            }

            
        }

        private void txtCustomerSearch_TextChanged(object sender, EventArgs e)
        {
            fill_leads();
        }

        private void cmbStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill_leads();
        }

        private void cmbStaff_TextChanged(object sender, EventArgs e)
        {
            fill_leads();
        }
    }
}
