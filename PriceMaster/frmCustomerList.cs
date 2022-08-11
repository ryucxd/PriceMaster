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

namespace PriceMaster
{
    public partial class frmCustomerList : Form
    {
        public frmCustomerList()
        {
            InitializeComponent();


            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                string sql = "SELECT rtrim([NAME]) FROM [dsl_fitting].dbo.SALES_LEDGER where [NAME] is not null order by [NAME] ASC ";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                        cmbCustomer.Items.Add(reader.GetString(0));
                    reader.Close();
                }
                conn.Close();
            }
        }

        private void buttonFormatting2_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmEditCustomer frm = new frmEditCustomer(cmbCustomer.Text,0);
            frm.ShowDialog();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //open form asking for an acc ref
            frmNewCustomer frm = new frmNewCustomer();
            frm.ShowDialog();

            cmbCustomer.Items.Clear();
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                string sql = "SELECT rtrim([NAME]) FROM [dsl_fitting].dbo.SALES_LEDGER where [NAME] is not null order by [NAME] ASC ";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                        cmbCustomer.Items.Add(reader.GetString(0));
                    reader.Close();
                }
                conn.Close();
            }

        }
    }
}
