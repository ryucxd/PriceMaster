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

namespace PriceMaster.TraditionalChasing
{
    public partial class frmNonReturningCustomers : Form
    {
        public int customer_index { get; set; }
        public int last_date_ordered_index { get; set; }
        public int last_door_ordered_index { get; set; }
        public int slimline_index { get; set; }
        public frmNonReturningCustomers()
        {
            InitializeComponent();

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
            string sql = "select rtrim(Customer) as customer,cast([Last Date Ordered] as date) as last_date_ordered,[Last Door Ordered] as [last_Door_Ordered]," +
                "[Slimline Customer] as slimline from [order_database].dbo.POWERBI_non_returning_customers where [Slimline Customer] = 'No' ";

            if (string.IsNullOrEmpty(cmbCustomerSearch.Text) == false)
                sql = sql + "AND customer = '" + cmbCustomerSearch.Text + "' ";

            sql = sql + "order by last_date_ordered desc";

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                
                using (SqlCommand cmd = new SqlCommand(sql,conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvNonReturningCustomers.DataSource = dt;
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
        }
        private void format()
        {
            dgvNonReturningCustomers.Columns[slimline_index].Visible = false;
            dgvNonReturningCustomers.Columns[customer_index].HeaderText = "Customer";
            dgvNonReturningCustomers.Columns[customer_index].HeaderText = "Last Date Ordered";
            dgvNonReturningCustomers.Columns[customer_index].HeaderText = "Last Door Ordered";

            foreach (DataGridViewColumn col in dgvNonReturningCustomers.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgvNonReturningCustomers.Columns[customer_index].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void dgvNonReturningCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmTraditionalNonReturningCustomerEmail frm = new frmTraditionalNonReturningCustomerEmail(Convert.ToInt32(dgvNonReturningCustomers.Rows[e.RowIndex].Cells[last_door_ordered_index].Value.ToString()));
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
    }
}
