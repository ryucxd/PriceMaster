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
    public partial class frmAddCustomerToSalesProspect : Form
    {
        public frmAddCustomerToSalesProspect()
        {
            InitializeComponent();
        }

        private void btnSAve_Click(object sender, EventArgs e)
        {
            string sql = "";

            txtAccountRef.Text = txtAccountRef.Text.Replace("'", "");
            txtName.Text = txtName.Text.Replace("'", "");
            txtAddress1.Text = txtAddress1.Text.Replace("'", "");
            txtAddress2.Text = txtAddress2.Text.Replace("'", "");
            txtAddress3.Text = txtAddress3.Text.Replace("'", "");
            txtAddress4.Text = txtAddress4.Text.Replace("'", "");
            txtAddress5.Text = txtAddress5.Text.Replace("'", "");
            txtTelephone.Text = txtTelephone.Text.Replace("'", "");

            //verification 

            //account ref
            if (txtAccountRef.Text.Length <= 1)
            {
                MessageBox.Show("Please enter an account reference before saving", "Account Ref", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtAccountRef.Text.Length > 8)
            {
                MessageBox.Show("This account reference is too long, please enter 8 or less characters!", "Account Ref", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //name
            if (txtName.Text.Length <= 2)
            {
                MessageBox.Show("Please enter a customer name before saving", "Customer Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtName.Text.Length > 60)
            {
                MessageBox.Show("This customer name is too long, please enter 60 or less characters", "Customer Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                //check if this account reference already exists
                sql = "SELECT Account_ref FROM [order_database].dbo.sales_ledger_prospect WHERE account_ref = '" + txtAccountRef.Text + "'";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    var account_ref = cmd.ExecuteScalar();
                    if (account_ref != null)
                    {
                        MessageBox.Show("This account reference is already being used, please enter another!", "Invalid Account Reference", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtAccountRef.Text = "";
                        return;
                    }
                }
                //name
                sql = "SELECT RTRIM(NAME) FROM [order_database].dbo.sales_ledger_prospect WHERE RTRIM(NAME) = '" + txtName.Text + "'";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    var name = cmd.ExecuteScalar();
                    if (name != null)
                    {
                        MessageBox.Show("This customer name is already being used, please enter another!", "Invalid Customer Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtName.Text = "";
                        return;
                    }
                }

                string telephone = "";

                if (txtTelephone.Text.Length > 0)
                    telephone = (txtTelephone.Text);


                sql = "insert into [order_database].dbo.SALES_LEDGER_PROSPECT (ACCOUNT_REF,NAME,ADDRESS_1,ADDRESS_2,ADDRESS_3,ADDRESS_4,ADDRESS_5,TELEPHONE) " +
                    "values ('" + txtAccountRef.Text + "','" + txtName.Text + "','" + txtAddress1.Text + "','" + txtAddress2.Text + "'," +
                    "'" + txtAddress3.Text + "','" + txtAddress4.Text + "','" + txtAddress5.Text + "','" + telephone.ToString() + "')";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                    conn.Close();
            }
            this.Close();

        }

        private void txtTelephone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
        }
    }
}
