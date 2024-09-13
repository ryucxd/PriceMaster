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
using System.Diagnostics.Eventing.Reader;

namespace PriceMaster
{
    public partial class frmChaseInsertCorrespondence : Form
    {
        public string customer { get; set; }
        public int slimline { get; set; }
        public frmChaseInsertCorrespondence(string _customer, int _slimline)
        {
            InitializeComponent();
            customer = _customer;
            slimline = _slimline;


            fill_sector();


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


                    cmbSector.Items.Add("General Correspondence");

                }


                conn.Close();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //int validation = 0;


            //int phone = 0, email = 0, in_person = 0;

            //int lead_time = 0, turnaround = 0, product = 0, installation = 0, service = 0;

            //if (chkPhone.Checked == true)
            //{
            //    phone = -1;
            //    validation = -1;
            //}
            //if (chkEmail.Checked == true)
            //{
            //    email = -1;
            //    validation = -1;
            //}
            //if (chkInPerson.Checked == true)
            //{
            //    in_person = -1;
            //    validation = -1;
            //}

            //if (validation == 0)
            //{
            //    MessageBox.Show("Please select Phone/Email/In Person before saving.", "Missing information!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //txtDescription.Text = txtDescription.Text.Replace("'", "");

            //if (txtDescription.Text.Length < 5)
            //{
            //    MessageBox.Show("Please enter a better description before saivng.", "Missing information!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //txtContact.Text = txtContact.Text.Replace("'", "");

            //if (txtContact.Text.Length < 2)
            //{
            //    MessageBox.Show("Please enter a contact before saivng.", "Missing information!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}


            //if (chkLeadtime.Checked == true)
            //    lead_time = -1;
            //if (chkTurnaround.Checked == true)
            //    turnaround = -1;
            //if (chkProduct.Checked == true)
            //    product = -1;
            //if (chkInstallation.Checked == true)
            //    installation = -1;
            //if (chkService.Checked == true)
            //    service = -1;

            //string next_correspondence_date = "";
            //int no_follow_up = 0;

            //if (chkFollowUp.Checked == true)
            //{
            //    no_follow_up = -1;
            //    next_correspondence_date = "NULL";
            //}
            //else
            //{
            //    no_follow_up = 0;
            //    next_correspondence_date = "'" + dteNextDate.Value.ToString("yyyyMMdd") + "'";
            //}


            ////get the sector (if the box is visible!!!!)
            //int sectorID = 0;

            //if (cmbSector.Visible == true)
            //{
            //    string sector_sql = "select id FROM [order_database].dbo.sales_table " +
            //        "where sector_date = CAST(DATEADD(wk, DATEDIFF(wk,0,GETDATE()), 0) as date) and " +
            //        "(sales_member_one = " + CONNECT.staffID + " or sales_member_two = " + CONNECT.staffID + " or sales_member_three = " + CONNECT.staffID + ") " +
            //        "and sector = '" + cmbSector.Text + "'";

            //    using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            //    {
            //        conn.Open();

            //        using (SqlCommand cmd = new SqlCommand(sector_sql, conn))
            //        {
            //            var temp = cmd.ExecuteScalar();

            //            if (temp != null)
            //                sectorID = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            //            else
            //                sectorID = 0;
            //        }

            //        conn.Close();
            //    }
            //}


            ////insert 
            //string sql = "INSERT INTO [order_database].[dbo].[quotation_chase_customer] " +
            //    "([customer_name],[slimline],[date_created],[body],[email],[phone],[inPerson],[contact],[issue_with_leadtime],[issue_with_quote_turnaround_time]" +
            //    ",[issue_with_product],[issue_with_installation],[issue_with_service],correspondence_by,next_correspondence_date,no_follow_up,complete,sector_id) VALUES (" +
            //    "'" + customer + "'," + slimline + ",GETDATE(),'" + txtDescription.Text + "'," + email + "," + phone + "," + in_person + "," +
            //    "'" + txtContact.Text + "'," + lead_time + "," + turnaround + "," + product + "," + installation + "," + service + "," + CONNECT.staffID + "," +
            //    "" + next_correspondence_date + "," + no_follow_up + "," + no_follow_up + "," + sectorID + " )";

            //using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            //{
            //    conn.Open();
            //    using (SqlCommand cmd = new SqlCommand(sql, conn))
            //    {
            //        cmd.ExecuteNonQuery();
            //    }
            //    conn.Close();
            //}

            //this.Close();

            save(0);

        }

        private void chkFollowUp_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFollowUp.Checked == true)
                dteNextDate.Enabled = false;
            else
                dteNextDate.Enabled = true;
        }

        private void btnSaveManagement_Click(object sender, EventArgs e)
        {
            //same as save

            //int validation = 0;


            //int phone = 0, email = 0, in_person = 0;

            //int lead_time = 0, turnaround = 0, product = 0, installation = 0, service = 0;

            //if (chkPhone.Checked == true)
            //{
            //    phone = -1;
            //    validation = -1;
            //}
            //if (chkEmail.Checked == true)
            //{
            //    email = -1;
            //    validation = -1;
            //}
            //if (chkInPerson.Checked == true)
            //{
            //    in_person = -1;
            //    validation = -1;
            //}

            //if (validation == 0)
            //{
            //    MessageBox.Show("Please select Phone/Email/In Person before saving.", "Missing information!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //txtDescription.Text = txtDescription.Text.Replace("'", "");

            //if (txtDescription.Text.Length < 5)
            //{
            //    MessageBox.Show("Please enter a better description before saivng.", "Missing information!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //txtContact.Text = txtContact.Text.Replace("'", "");

            //if (txtContact.Text.Length < 2)
            //{
            //    MessageBox.Show("Please enter a contact before saivng.", "Missing information!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}


            //if (chkLeadtime.Checked == true)
            //    lead_time = -1;
            //if (chkTurnaround.Checked == true)
            //    turnaround = -1;
            //if (chkProduct.Checked == true)
            //    product = -1;
            //if (chkInstallation.Checked == true)
            //    installation = -1;
            //if (chkService.Checked == true)
            //    service = -1;

            //string next_correspondence_date = "";
            //int no_follow_up = 0;

            //if (chkFollowUp.Checked == true)
            //{
            //    no_follow_up = -1;
            //    next_correspondence_date = "NULL";
            //}
            //else
            //{
            //    no_follow_up = 0;
            //    next_correspondence_date = "'" + dteNextDate.Value.ToString("yyyyMMdd") + "'";
            //}



            ////insert 
            //string sql = "INSERT INTO [order_database].[dbo].[quotation_chase_customer] " +
            //    "([customer_name],[slimline],[date_created],[body],[email],[phone],[inPerson],[contact],[issue_with_leadtime],[issue_with_quote_turnaround_time]" +
            //    ",[issue_with_product],[issue_with_installation],[issue_with_service],correspondence_by,next_correspondence_date,no_follow_up,complete) VALUES (" +
            //    "'" + customer + "'," + slimline + ",GETDATE(),'" + txtDescription.Text + "'," + email + "," + phone + "," + in_person + "," +
            //    "'" + txtContact.Text + "'," + lead_time + "," + turnaround + "," + product + "," + installation + "," + service + "," + CONNECT.staffID + "," +
            //    "" + next_correspondence_date + "," + no_follow_up + "," + no_follow_up + " )";

            //using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            //{
            //    conn.Open();
            //    using (SqlCommand cmd = new SqlCommand(sql, conn))
            //    {
            //        cmd.ExecuteNonQuery();
            //    }
            //    //but we also alert management
            //    using (SqlCommand cmd = new SqlCommand("[order_database].dbo.usp_quotation_correspondence_alert", conn))
            //    {

            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Parameters.AddWithValue("@slimline", SqlDbType.Int).Value = slimline;
            //        cmd.Parameters.AddWithValue("@customer", SqlDbType.NVarChar).Value = (customer);
            //        cmd.Parameters.AddWithValue("@description", SqlDbType.NVarChar).Value = (txtDescription.Text);
            //        cmd.ExecuteNonQuery();
            //    }


            //    conn.Close();
            //}







            //this.Close();


            save(-1);
        }



        private void save(int management)
        {
            int validation = 0;


            int phone = 0, email = 0, in_person = 0, failed_contact = 0 ;

            int lead_time = 0, turnaround = 0, product = 0, installation = 0, service = 0;

            if (chkFailed.Checked == true)
                failed_contact = -1;

            if (chkPhone.Checked == true)
            {
                phone = -1;
                validation = -1;
            }
            if (chkEmail.Checked == true)
            {
                email = -1;
                validation = -1;
            }
            if (chkInPerson.Checked == true)
            {
                in_person = -1;
                validation = -1;
            }

            if (validation == 0)
            {
                MessageBox.Show("Please select Phone/Email/In Person before saving.", "Missing information!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtDescription.Text = txtDescription.Text.Replace("'", "");



            if (txtDescription.Text.Length < 5)
            {
                MessageBox.Show("Please enter a better description before saivng.", "Missing information!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtContact.Text = txtContact.Text.Replace("'", "");

            if (txtContact.Text.Length < 2)
            {
                MessageBox.Show("Please enter a contact before saivng.", "Missing information!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtEmailCustomer.Text = txtEmailCustomer.Text.Replace("'", "");
            if (txtEmailCustomer.Text.Length < 2)
            {
                MessageBox.Show("Please enter an email domain before saivng.", "Missing information!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (chkLeadtime.Checked == true)
                lead_time = -1;
            if (chkTurnaround.Checked == true)
                turnaround = -1;
            if (chkProduct.Checked == true)
                product = -1;
            if (chkInstallation.Checked == true)
                installation = -1;
            if (chkService.Checked == true)
                service = -1;

            string next_correspondence_date = "";
            int no_follow_up = 0;

            if (chkFollowUp.Checked == true)
            {
                no_follow_up = -1;
                next_correspondence_date = "NULL";
            }
            else
            {
                no_follow_up = 0;
                next_correspondence_date = "'" + dteNextDate.Value.ToString("yyyyMMdd") + "'";
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


            //insert 
            string sql = "INSERT INTO [order_database].[dbo].[quotation_chase_customer] " +
                "([customer_name],[slimline],[date_created],[body],[email],[phone],[inPerson],[contact],[issue_with_leadtime],[issue_with_quote_turnaround_time]" +
                ",[issue_with_product],[issue_with_installation],[issue_with_service],correspondence_by,next_correspondence_date,no_follow_up,complete,sector_id,email_domain,failed_contact) VALUES (" +
                "'" + customer + "'," + slimline + ",GETDATE(),'" + txtDescription.Text + "'," + email + "," + phone + "," + in_person + "," +
                "'" + txtContact.Text + "'," + lead_time + "," + turnaround + "," + product + "," + installation + "," + service + "," + CONNECT.staffID + "," +
                "" + next_correspondence_date + "," + no_follow_up + "," + no_follow_up + "," + sectorID + ",'" + txtEmailCustomer.Text + "'," + failed_contact + " )";

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();

                    if (management == -1)
                    {
                        //alert management
                        using (SqlCommand cmdManagement = new SqlCommand("[order_database].dbo.usp_quotation_correspondence_alert", conn))
                        {

                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@slimline", SqlDbType.Int).Value = slimline;
                            cmd.Parameters.AddWithValue("@customer", SqlDbType.NVarChar).Value = (customer);
                            cmd.Parameters.AddWithValue("@description", SqlDbType.NVarChar).Value = (txtDescription.Text);
                            cmd.ExecuteNonQuery();
                        }
                    }

                }
                conn.Close();
            }

            this.Close();
        }

    }
}
