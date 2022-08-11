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
    public partial class frmNewCustomer : Form
    {
        public frmNewCustomer()
        {
            InitializeComponent();
            txtAccRef.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtAccRef.Text.Length > 8)
            {
                MessageBox.Show("Account Reference is too long! Maximum characters allowed is 8", "Unable to create new customer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string sql = "SELECT ACCOUNT_REF FROM [dsl_fitting].dbo.[SALES_LEDGER] WHERE ACCOUNT_REF = '" + txtAccRef.Text + "'";
            using(SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    var data = cmd.ExecuteScalar();
                    if (data == null)
                    {
                        //here we create the new cust ref
                        sql = " INSERT INTO [dsl_fitting].[dbo].[SALES_LEDGER] (ACCOUNT_REF) VALUES ('" + txtAccRef.Text + "')";
                        using (SqlCommand cmdInsert = new SqlCommand(sql, conn))
                            cmdInsert.ExecuteNonQuery();
                        //open the new account 
                        frmEditCustomer frm = new frmEditCustomer(txtAccRef.Text,-1);
                        frm.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(txtAccRef.Text + " Already exists as an account reference! Please enter a new one", "Unable to create new customer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                    conn.Close();
            }
        }

        private void txtAccRef_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd.PerformClick();
            }
        }
    }
}
