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
    public partial class frmLeadInsert : Form
    {
        public frmLeadInsert()
        {
            InitializeComponent();

            fill_sector();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string sql = "";
            //ERROR checking

            txtCustomer.Text = txtCustomer.Text.Replace("'", "");
            txtContactName.Text = txtContactName.Text.Replace("'", "");
            txtContactDetails.Text = txtContactDetails.Text.Replace("'", "");
            txtCustomerAddress.Text = txtCustomerAddress.Text.Replace("'", "");
            txtNotes.Text = txtNotes.Text.Replace("'", "");



            if (txtCustomer.Text.Length < 1)
            {
                MessageBox.Show("Please enter a customer before clicking insert", "Missing Customer information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtContactName.Text.Length < 1)
            {
                MessageBox.Show("Please enter the contacts name before clicking insert", "Missing Customer information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtContactDetails.Text.Length < 1)
            {
                MessageBox.Show("Please enter the customer details before clicking insert", "Missing Customer information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtCustomerAddress.Text.Length < 1)
            {
                MessageBox.Show("Please enter the customer's address before clicking insert", "Missing Customer information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtNotes.Text.Length < 1)
            {
                MessageBox.Show("Please enter a note before clicking insert", "Missing Customer information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbAllocatedTo.SelectedIndex < 0)
            {
                MessageBox.Show("Please enter a person for this to be allocated to before clicking insert", "Missing Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //check if this has been added before! 
            sql = "select id FROM [order_database].dbo.sales_new_leads where customer = '" + txtCustomer.Text + "' AND contact_name = '" + txtContactName.Text + "'";

            using (SqlConnection connDouble = new SqlConnection(CONNECT.ConnectionString))
            {
                connDouble.Open();

                using (SqlCommand cmdDouble = new SqlCommand(sql, connDouble))
                {
                    var temp = cmdDouble.ExecuteScalar();

                    if (temp != null)
                    {
                        MessageBox.Show("You have already added this contact for this customer!", "Duplicate Entry", MessageBoxButtons.OK);
                        return;
                    }

                }


                    connDouble.Close();
            }



                //get the sector (if the box is visible!!!!)
                int sectorID = 0;
            if (cmbSector.Visible == true)
            {
                if (cmbSector.Text.Length < 1)
                {
                    MessageBox.Show("Please select a sector before clicking save! If there is no relevant sector please select 'General Correspondence'", "Missing Sector", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string sector_sql = "select id FROM [order_database].dbo.sales_table " +
                    "where sector_date = CAST(DATEADD(wk, DATEDIFF(wk,0,GETDATE()), 0) as date) and " +
                    "(sales_member_one = " + CONNECT.staffID + " or sales_member_two = " + CONNECT.staffID + " or sales_member_three = " + CONNECT.staffID + ") " +
                    "and sector = '" + cmbSector.Text + "'";

                using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sector_sql, conn))
                    {
                        var temp = cmd.ExecuteScalar();

                        if (temp != null)
                            sectorID = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                        else
                            sectorID = 0;
                    }

                    conn.Close();
                }
            }


            //get the allocated user 
            int allocated_to = 0;

            sql = "select id FROM [user_info].dbo.[user] where forename + ' ' + surname = '" + cmbAllocatedTo.Text + "'";
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    allocated_to = Convert.ToInt32(cmd.ExecuteScalar());
                }

                conn.Close();
            }


            //insert the new lead

            int rotec = 0;

            if (chkRotec.Checked == true)
                rotec = -1;

            sql = "INSERT INTO [order_database].dbo.sales_new_leads (lead_date,lead_by,customer,contact_name,customer_address,contact_details,allocated_to,sector_id,notes,rotec_customer) " +
                "VALUES ( GETDATE()," + CONNECT.staffID + ",'" + txtCustomer.Text + "','" + txtContactName.Text + "','" + txtCustomerAddress.Text + "'," +
                "'" + txtContactDetails.Text + "','" + allocated_to + "'," + sectorID + ",'" + txtNotes.Text + "'," + rotec + " )";

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }

            this.Close();

        }


        private void fill_sector()
        {
            string sql = "select sector FROM [order_database].dbo.sales_table " +
                "where sector_date = CAST(DATEADD(wk, DATEDIFF(wk,0,GETDATE()), 0) as date) and " +
                "(sales_member_one = " + CONNECT.staffID + " or sales_member_two = " + CONNECT.staffID + " or sales_member_three = " + CONNECT.staffID + ")";

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
                        cmbSector.Items.Add(row[0].ToString());
                    }

                    if (cmbSector.Items.Count == 0)
                    {
                        cmbSector.Visible = false;
                        label5.Visible = false;
                    }


                }


                conn.Close();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
