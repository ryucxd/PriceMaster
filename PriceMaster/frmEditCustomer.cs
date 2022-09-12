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
    public partial class frmEditCustomer : Form
    {
        public string _name { get; set; }
        public frmEditCustomer(string name,int account_ref)
        {
            InitializeComponent();
            _name = name;
            lblTitle.Text = _name + " Details";
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                string sql = "SELECT rtrim(ACCOUNT_REF),NAME,ADDRESS_1,ADDRESS_2,ADDRESS_3,ADDRESS_4,ADDRESS_5,TELEPHONE,TELEPHONE_2,FAX,E_MAIL,type FROM [dsl_fitting].dbo.[SALES_LEDGER] ";
                if (account_ref == 0)
                    sql = sql + " WHERE [NAME] = ";
                else
                    sql = sql + " WHERE [ACCOUNT_REF] = ";

                sql = sql + " '" + name + "' ";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //use this dt to fill out all the  boxes
                    txtAccRef.Text = dt.Rows[0][0].ToString();
                    txtCustName.Text = dt.Rows[0][1].ToString();
                    txtAddress1.Text = dt.Rows[0][2].ToString();
                    txtAddress2.Text = dt.Rows[0][3].ToString();
                    txtAddress3.Text = dt.Rows[0][4].ToString();
                    txtAddress4.Text = dt.Rows[0][5].ToString();
                    txtPostCode.Text = dt.Rows[0][6].ToString();
                    txtTelephone.Text = dt.Rows[0][7].ToString();
                    txtTelephone2.Text = dt.Rows[0][8].ToString();
                    txtFax.Text = dt.Rows[0][9].ToString();
                    txtEmail.Text = dt.Rows[0][10].ToString();
                    cmbType.Text = dt.Rows[0][11].ToString();
                }
                conn.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to update these details?", "Update " + _name, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                {
                    conn.Open();
                    //update each field
                    string sql = "UPDATE [dsl_fitting].dbo.[SALES_LEDGER] SET  NAME = '" + txtCustName.Text + "'," +
                        " ADDRESS_1 = '" + txtAddress1.Text + "', ADDRESS_2 = '" + txtAddress2.Text + "', ADDRESS_3 = '" + txtAddress3.Text + "'," +
                        " ADDRESS_4 = '" + txtAddress4.Text + "', ADDRESS_5 = '" + txtPostCode.Text + "', TELEPHONE = '" + txtTelephone.Text + "'," +
                        " TELEPHONE_2 = '" + txtTelephone2.Text + "', FAX = '" + txtFax.Text + "', E_MAIL = '" + txtEmail.Text + "', type = '" + cmbType.Text + "'  WHERE ACCOUNT_REF = '" + txtAccRef.Text + "'";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    conn.Close();
                }
                this.Close();
            }
        }
    }
}
