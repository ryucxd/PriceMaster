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
    public partial class frmAutoChaseBanList : Form
    {
        public int customer_exists { get; set; }
        public frmAutoChaseBanList()
        {
            InitializeComponent();
            load_data();
            fill_combo();
        }

        private void fill_combo()
        {

            string sql = "select distinct customer from [order_database].dbo.solidworks_quotation_log where customer is not null and customer <> '' order by customer ";
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                   

                    foreach (DataRow row in dt.Rows)
                    {
                        if (cmbCustomer.Items.Contains(row[0].ToString()))
                        { } //nothing
                        else
                            cmbCustomer.Items.Add(row[0].ToString());
                    }
                }

                conn.Close();
            }
        }

        private void load_data()
        {
            string sql = "select customer from [order_database].dbo.quotation_chase_exclusion_list order by customer";
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
            dataGridView1.Columns[0].HeaderText = "Excluded Customers";
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            //check if this customer exists -- if it does rename button and set tempvars 
            string sql = "SELECT customer FROM [order_database].dbo.quotation_chase_exclusion_list where customer = '" + cmbCustomer.Text + "' ";

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    var temp = cmd.ExecuteScalar();
                    if (temp != null)
                        customer_exists = -1;
                    else
                        customer_exists = 0;
                }

                conn.Close();
            }

            //change the button and stuff
            change_button();

        }

        private void change_button()
        {
            if (customer_exists == 0)// doesnt exist
                btnExclude.Text = "Exclude Customer";
            else//does
                btnExclude.Text = "Include Customer";
        }

        private void btnExclude_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(cmbCustomer.Text))
            {
                MessageBox.Show("Please Select a customer first", "Missing customer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = "";

            if (customer_exists == 0)
            {
                sql = "INSERT INTO [order_database].dbo.quotation_chase_exclusion_list (customer) VALUES ('" + cmbCustomer.Text + "')";
                customer_exists = -1;
            }    
            else
            {
                sql = "DELETE FROM [order_database].dbo.quotation_chase_exclusion_list WHERE customer = '" + cmbCustomer.Text + "'";
                customer_exists = 0;
            }

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    cmd.ExecuteNonQuery();
                    conn.Close();
            }


            load_data();
            change_button();
        }
    }
}
