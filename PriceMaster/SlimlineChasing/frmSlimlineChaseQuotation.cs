using PriceMaster.SlimlineChasing;
using PriceMaster.SlimlinelChasing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PriceMaster
{
    public partial class frmSlimlineChaseQuotation : Form
    {
        public int quote_id { get; set; }
        public string customer { get; set; }
        public int skip_loss_check { get; set; }
        public frmSlimlineChaseQuotation(int _quote_id, string _customer)
        {
            InitializeComponent();
            quote_id = _quote_id;
            customer = _customer + " - " + quote_id.ToString() ;
            lblCustomer.Text = customer;
            skip_loss_check = 0;
            load_data();
        }

        private void sql_update(string sql)
        {
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        private void load_data()
        {
            //get the max rev and fill the combobox << this is all the normal data
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                string sql = "select CAST(issue_id as nvarchar(max)) from [price_master].dbo.sl_quotation where quote_id = " + quote_id.ToString() + " Order by issue_id ";
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                        cmbRev.Items.Add(reader.GetString(0));
                    reader.Close();
                    //select the max one 
                    sql = "SELECT max(issue_id) FROM [price_master].dbo.sl_quotation WHERE quote_id = " + quote_id.ToString();
                    using (SqlCommand cmdMax = new SqlCommand(sql, conn))
                        cmbRev.Text = cmdMax.ExecuteScalar().ToString();


                    //if the current status is not pending then we remove it so it cannot be added back
                    sql = "SELECT [status] ,[custom_feedback] ,[too_expensive] ,[lead_time_too_long] ,[quote_took_too_long] ,[unable_to_meet_spec],[non_responsive_customer],priority_chase " +
                        "FROM [order_database].[dbo].[quotation_feed_back_slimline] WHERE quote_id = " + quote_id.ToString();
                    using (SqlCommand cmdData = new SqlCommand(sql, conn))
                    {

                        SqlDataAdapter da = new SqlDataAdapter(cmdData);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        cmbStatus.Text = dt.Rows[0][0].ToString();
                        txtCustom.Text = dt.Rows[0][1].ToString();
                        int reason_for_loss = 0;
                        if (dt.Rows[0][2].ToString() == "-1")
                        {
                            chkTooExpensive.Checked = true;
                            reason_for_loss = -1;
                        }
                        if (dt.Rows[0][3].ToString() == "-1")
                        {
                            chkLeadTimeTooLong.Checked = true;
                            reason_for_loss = -1;
                        }
                        if (dt.Rows[0][4].ToString() == "-1")
                        {
                            chkQuoteTookTooLong.Checked = true;
                            reason_for_loss = -1;
                        }
                        if (dt.Rows[0][5].ToString() == "-1")
                        {
                            chkUnableToMeetSpec.Checked = true;
                            reason_for_loss = -1;
                        }
                        if (dt.Rows[0][6].ToString() == "-1")
                        {
                            chkNonResponsive.Checked = true;
                            reason_for_loss = -1;
                        }
                        if (dt.Rows[0][7].ToString() == "-1")
                        {
                            chkPriority.Checked = true;
                            reason_for_loss = -1;
                        }

                        //change label text
                        if (reason_for_loss == -1)
                            lblLost.Text = "Loss Reasons:";

                        if (string.IsNullOrEmpty(cmbStatus.Text))
                            cmbStatus.Items.Add("Pending");
                        cmbStatus.Items.Add("Chasing");
                        cmbStatus.Items.Add("Won");
                        cmbStatus.Items.Add("Lost");

                        if (cmbStatus.Text == "Lost")
                        {
                            lblLost.Visible = true;
                            chkLeadTimeTooLong.Visible = true;
                            chkQuoteTookTooLong.Visible = true;
                            chkTooExpensive.Visible = true;
                            chkUnableToMeetSpec.Visible = true;
                            chkNonResponsive.Visible = true;
                        }

                        if (cmbStatus.Text != "Chasing")
                            btnChase.Visible = false;
                        else
                            btnChase.Visible = true;

                    }


                }
                conn.Close();
            }


            //get the recent chase data
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                //check if there is a existing chase~

                string sql = "select top 1 id FROM [order_database].dbo.quotation_chase_log_slimline where quote_id = " + quote_id + " order by id desc";
                int chase_exists = 0;
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    var data = cmd.ExecuteScalar();
                    if (data != null)
                        chase_exists = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                }

                if (chase_exists == 0) //small size = 1013,530
                {
                    this.Size = new Size(1013, 530);
                }
                else //large size = 1427,530
                {
                    this.Size = new Size(1427, 530);

                    //populate data with the latest chase information

                    sql = "select chase_date,chase_description,next_chase_date, dont_chase,phone,email from [order_database].dbo.quotation_chase_log_slimline where id = " + chase_exists.ToString();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        txtChaseDate.Text = Convert.ToDateTime(dt.Rows[0][0].ToString()).ToString();
                        txtDescription.Text = dt.Rows[0][1].ToString();
                        txtNextDate.Text = Convert.ToDateTime(dt.Rows[0][2].ToString()).ToString("dd/MM/yyyy");
                        if (dt.Rows[0][3].ToString() == "-1")
                        {
                            txtNextDate.Visible = false;
                            lblNext.Visible = false;
                            chkHiddenFollowup.Visible = true;
                            chkHiddenFollowup.Checked = true;
                            chkHiddenFollowup.AutoCheck = false;
                        }
                        else
                        {
                            
                        }
                        if (dt.Rows[0][4].ToString() == "-1")
                            chkPhone.Checked = true;
                        if (dt.Rows[0][5].ToString() == "-1")
                            chkEmail.Checked = true;
                    }
                }

                    

                
               
                conn.Close();
            }

            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                          (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);

        }

        private void btnQuote_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = @"S:\SLIMLINE QUOTES\SL" + quote_id.ToString();

                if (Convert.ToInt32(cmbRev.Text) > 1) //issue has some extra stuff
                    filePath = filePath + "I" + cmbRev.Text.ToString();

                filePath = filePath + ".rtf";

                System.Diagnostics.Process.Start(filePath);
            }
            catch
            {
                MessageBox.Show("The full quotation does not yet exist for this number.", "No File Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAttachments_Click(object sender, EventArgs e)
        {
            string filePath = @"\\designsvr1\public\Slimline Chase Log\" + quote_id.ToString();
            Directory.CreateDirectory(filePath);
            Process.Start(filePath);
        }

        private void btnRelatedEnquiries_Click(object sender, EventArgs e)
        {
            string sql = "select enquiry_id,issue_id from [price_master].dbo.[sl_quotation]  where quote_id = " + quote_id.ToString() + " AND issue_id = " + cmbRev.Text + " ";
            int enquiry_id = 0;

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("There is no linked enquiry for this quote + issue.", "Missing data.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (string.IsNullOrEmpty(dt.Rows[0][0].ToString()))
                    {
                        MessageBox.Show("There is no linked enquiry for this quote + issue.", "Missing data.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                        enquiry_id = Convert.ToInt32(dt.Rows[0][0].ToString());
                }
                conn.Close();
            }

            frmSlimlineEnquiryHistory frm = new frmSlimlineEnquiryHistory(enquiry_id);

            frm.ShowDialog();
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "";
            //are you sureeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee
            if (skip_loss_check == 0)
            {
                if (cmbStatus.Text == "Lost")
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to mark this chase as lost?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.No)
                    {
                        //revert it back to whatever it was
                        sql = "select [status] from [order_database].dbo.quotation_feed_back_slimline WHERE quote_id = " + quote_id.ToString();

                        using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                        {
                            conn.Open();

                            using (SqlCommand cmd = new SqlCommand(sql, conn))
                            {
                                var temp = cmd.ExecuteScalar();
                                if (temp == null || string.IsNullOrEmpty(temp.ToString()) == true)
                                    cmbStatus.Text = "Chasing";
                                else
                                    cmbStatus.Text = temp.ToString();
                            }

                            conn.Close();
                            return;
                        }
                    }
                }
            }

            if (cmbStatus.Text == "Lost")
            {
                lblLost.Visible = true;
                chkLeadTimeTooLong.Visible = true;
                chkQuoteTookTooLong.Visible = true;
                chkTooExpensive.Visible = true;
                chkUnableToMeetSpec.Visible = true;
                chkNonResponsive.Visible = true;
            }
            else
            {
                lblLost.Visible = false;
                chkLeadTimeTooLong.Visible = false;
                chkQuoteTookTooLong.Visible = false;
                chkTooExpensive.Visible = false;
                chkUnableToMeetSpec.Visible = false;
                chkNonResponsive.Visible = false;
            }
            if (cmbStatus.Text != "Chasing")
                btnChase.Visible = false;
            else
                btnChase.Visible = true;

            if (cmbStatus.Items.Contains("Pending"))
                if (cmbStatus.Text != "Pending")
                    cmbStatus.Items.RemoveAt(cmbStatus.Items.IndexOf("Pending"));

            sql = "UPDATE [order_database].dbo.quotation_feed_back_slimline SET status = '" + cmbStatus.Text + "',too_expensive = 0,lead_time_too_long = 0,quote_took_too_long = 0,unable_to_meet_spec = 0,non_responsive_customer = 0 WHERE quote_id = " + quote_id.ToString();
            sql_update(sql);

            chkLeadTimeTooLong.Checked = false;
            chkQuoteTookTooLong.Checked = false;
            chkTooExpensive.Checked = false;
            chkUnableToMeetSpec.Checked = false;
            chkNonResponsive.Checked = false;

        }

        private void chkTooExpensive_CheckedChanged(object sender, EventArgs e)
        {
            int value = 0;
            if (chkTooExpensive.Checked == true)
                value = -1;
            string sql = "UPDATE [order_database].dbo.quotation_feed_back_slimline SET too_expensive = " + value + " WHERE quote_id = " + quote_id.ToString();
            sql_update(sql);
            lblLost.Text = "Loss Reasons:";
        }

        private void chkLeadTimeTooLong_CheckedChanged(object sender, EventArgs e)
        {
            int value = 0;
            if (chkLeadTimeTooLong.Checked == true)
                value = -1;
            string sql = "UPDATE [order_database].dbo.quotation_feed_back_slimline SET lead_time_too_long = " + value + " WHERE quote_id = " + quote_id.ToString();
            sql_update(sql);
            lblLost.Text = "Loss Reasons:";
        }

        private void chkQuoteTookTooLong_CheckedChanged(object sender, EventArgs e)
        {
            int value = 0;
            if (chkQuoteTookTooLong.Checked == true)
                value = -1;
            string sql = "UPDATE [order_database].dbo.quotation_feed_back_slimline SET quote_took_too_long = " + value + " WHERE quote_id = " + quote_id.ToString();
            sql_update(sql);
            lblLost.Text = "Loss Reasons:";
        }

        private void chkUnableToMeetSpec_CheckedChanged(object sender, EventArgs e)
        {
            int value = 0;
            if (chkUnableToMeetSpec.Checked == true)
                value = -1;
            string sql = "UPDATE [order_database].dbo.quotation_feed_back_slimline SET unable_to_meet_spec = " + value + " WHERE quote_id = " + quote_id.ToString();
            sql_update(sql);
            lblLost.Text = "Loss Reasons:";
        }

        private void chkNonResponsive_CheckedChanged(object sender, EventArgs e)
        {
            int value = 0;
            if (chkNonResponsive.Checked == true)
                value = -1;
            string sql = "UPDATE [order_database].dbo.quotation_feed_back_slimline SET non_responsive_customer = " + value + " WHERE quote_id = " + quote_id.ToString();
            sql_update(sql);
            lblLost.Text = "Loss Reasons:";
        }

        private void btnInsertNote_Click(object sender, EventArgs e)
        {
            //opens a form to enter a note
            frmSlimlineInsertNote frm = new frmSlimlineInsertNote(quote_id);
            frm.ShowDialog();


            //if the current status is not pending then we remove it so it cannot be added back
            string sql = "SELECT [custom_feedback] FROM [order_database].[dbo].[quotation_feed_back_slimline] WHERE quote_id = " + quote_id.ToString();
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmdData = new SqlCommand(sql, conn))
                {

                    SqlDataAdapter da = new SqlDataAdapter(cmdData);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    txtCustom.Text = dt.Rows[0][0].ToString();
                }
                conn.Close();
            }
        }

        private void btnChaseHistory_Click(object sender, EventArgs e)
        {
            frmSlimlineChaseHistoryNew frm = new frmSlimlineChaseHistoryNew(quote_id);
            frm.ShowDialog();
        }

        private void btnChase_Click(object sender, EventArgs e)
        {
            frmSlimlineChase frm = new frmSlimlineChase(quote_id, 0, 0);
            frm.ShowDialog();
            skip_loss_check = -1;
            //update most recent chase
            load_data();
        }

        private void frmSlimlineChaseQuotation_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cmbStatus.Text == "Lost")
            {
                int cancel_close = -1;

                if (chkLeadTimeTooLong.Checked == true)
                    cancel_close = 0;
                if (chkQuoteTookTooLong.Checked == true)
                    cancel_close = 0;
                if (chkTooExpensive.Checked == true)
                    cancel_close = 0;
                if (chkUnableToMeetSpec.Checked == true)
                    cancel_close = 0;
                if (chkNonResponsive.Checked == true)
                    cancel_close = 0;

                if (cancel_close == -1)
                {
                    MessageBox.Show("You must select a reason for loss (check box) before closing this form.", "Reason for loss missing.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void chkPriority_CheckedChanged(object sender, EventArgs e)
        {
            int value = 0;
            if (chkPriority.Checked == true)
                value = -1;
            string sql = "UPDATE [order_database].dbo.quotation_feed_back_slimline SET priority_chase = " + value + " WHERE quote_id = " + quote_id.ToString();
            sql_update(sql);
        }
    }
}
