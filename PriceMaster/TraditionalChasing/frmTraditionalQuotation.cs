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
using System.Globalization;
using PriceMaster.TraditionalChasing;
using PriceMaster.SlimlineChasing;

namespace PriceMaster
{
    public partial class frmTraditionalQuotation : Form
    {
        public int skip_loss_check { get; set; }
        public int quote_id { get; set; }
        public frmTraditionalQuotation(int _quote_id, string customer)
        {
            InitializeComponent();
            quote_id = _quote_id;
            skip_loss_check = 0;
            lblCustomer.Text = customer + " - " + quote_id.ToString();
            //get the max rev and fill the combobox
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                string sql = "SELECT distinct cast(rev_num as nvarchar(max)),rev_num from [order_database].dbo.solidworks_quotation_log_details WHERE parent_spec = " + quote_id.ToString() + " Order by rev_num ";
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                        cmbRev.Items.Add(reader.GetString(0));
                    reader.Close();
                    //select the max one 
                    sql = "SELECT max(rev_num) FROM [order_database].dbo.solidworks_quotation_log_details WHERE parent_spec = " + quote_id.ToString();
                    using (SqlCommand cmdMax = new SqlCommand(sql, conn))
                        cmbRev.Text = cmdMax.ExecuteScalar().ToString();


                    //if the current status is not pending then we remove it so it cannot be added back
                    sql = "SELECT [status] ,[custom_feedback] ,[too_expensive] ,[lead_time_too_long] ,[quote_took_too_long] ,[unable_to_meet_spec],[non_responsive_customer],priority_chase,customer_lost_the_quote " +
                        "FROM [order_database].[dbo].[quotation_feed_back] WHERE quote_id = " + quote_id.ToString();
                    using (SqlCommand cmdData = new SqlCommand(sql, conn))
                    {

                        SqlDataAdapter da = new SqlDataAdapter(cmdData);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        cmbStatus.Text = dt.Rows[0][0].ToString();
                        txtCustom.Text = dt.Rows[0][1].ToString();
                        if (dt.Rows[0][2].ToString() == "-1")
                            chkTooExpensive.Checked = true;
                        if (dt.Rows[0][3].ToString() == "-1")
                            chkLeadTimeTooLong.Checked = true;
                        if (dt.Rows[0][4].ToString() == "-1")
                            chkQuoteTookTooLong.Checked = true;
                        if (dt.Rows[0][5].ToString() == "-1")
                            chkUnableToMeetSpec.Checked = true;
                        if (dt.Rows[0][6].ToString() == "-1")
                            chkNonResponsive.Checked = true;
                        if (dt.Rows[0][7].ToString() == "-1")
                            chkPriority.Checked = true;
                        if (dt.Rows[0][8].ToString() == "-1")
                            chkCustomerLostQuote.Checked = true;

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
                            chkCustomerLostQuote.Visible = true;
                        }

                        if (cmbStatus.Text != "Chasing")
                            btnChase.Visible = false;
                        else
                            btnChase.Visible = true;

                    }


                }
                conn.Close();
            }

            fillGrid();
        }

        private void fillGrid()
        {
            string sql = "select CAST(parent_spec as nvarchar(max)) + '-' + cast(row_index as nvarchar(max)) + '-' + cast(rev_num as nvarchar(max)) as [Parent Spec], item_ref as [Item Ref], " +
                "item_type as [Item Type], single_double as [Single / Double], width as [Width], height as [Height], threshold as [Threshold], hardware as [Hardware], qty_same as [Quantity Same],cost as [Cost] " +
                "from [order_database].dbo.solidworks_quotation_log_details " +
                "WHERE parent_spec = '" + quote_id.ToString() + "' and rev_num = " + cmbRev.Text + " Order by CAST(parent_spec as nvarchar(max)) + '-' + cast(row_index as nvarchar(max)) + '-' + cast(rev_num as nvarchar(max))";

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
            //format
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.Columns[9].DefaultCellStyle.Format = "c2";
            dataGridView1.Columns[9].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-GB");

            double total_cost = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
                total_cost = total_cost + Convert.ToDouble(row.Cells[9].Value);
            lblTotalCost.Text = total_cost.ToString("C");

            lblCount.Text = dataGridView1.Rows.Count.ToString() + " Items";

            recent_chase();
        }

        private void cmbRev_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillGrid();
        }

        private void btnQuote_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"\\designsvr1\SOLIDWORKS\Door Designer\Specifications\Project " + quote_id.ToString() + @"\Quotations\Revision " + cmbRev.Text + @"\FullQuotation-" + quote_id.ToString() + "-" + cmbRev.Text + ".pdf";
                System.Diagnostics.Process.Start(path);
            }
            catch
            {
                MessageBox.Show("The full quotation does not yet exist for this number.", "No File Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDrawings_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"\\designsvr1\SOLIDWORKS\Door Designer\Specifications\Project " + quote_id.ToString() + @"\Quotations\Revision " + cmbRev.Text + @"\DrawingsSimple";
                System.Diagnostics.Process.Start(path);
            }
            catch
            {
                MessageBox.Show("The drawings do not yet exist for this number.", "No Files Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

            //are you sureeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee
            if (skip_loss_check == 0)
            {
                if (cmbStatus.Text == "Lost")
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to mark this chase as lost?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.No)
                    {
                        //revert it back to whatever it was
                        string sql = "select [status] from [order_database].dbo.quotation_feed_back WHERE quote_id = " + quote_id.ToString();

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
            skip_loss_check = 0;

            if (cmbStatus.Text == "Lost")
            {
                lblLost.Visible = true;
                chkLeadTimeTooLong.Visible = true;
                chkQuoteTookTooLong.Visible = true;
                chkTooExpensive.Visible = true;
                chkUnableToMeetSpec.Visible = true;
                chkNonResponsive.Visible = true;
                chkCustomerLostQuote.Visible = true;

                DialogResult result = MessageBox.Show("Would you like to add a chase?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    frmTraditionalChase frm = new frmTraditionalChase(quote_id, 0, 0);
                    frm.ShowDialog();
                    recent_chase();
                }

                
            }
            else
            {
                lblLost.Visible = false;
                chkLeadTimeTooLong.Visible = false;
                chkQuoteTookTooLong.Visible = false;
                chkTooExpensive.Visible = false;
                chkUnableToMeetSpec.Visible = false;
                chkNonResponsive.Visible = false;
                chkCustomerLostQuote.Visible = false;
            }

            if (cmbStatus.Text != "Chasing")
                btnChase.Visible = false;
            else
                btnChase.Visible = true;

            if (cmbStatus.Items.Contains("Pending"))
                if (cmbStatus.Text != "Pending")
                    cmbStatus.Items.RemoveAt(cmbStatus.Items.IndexOf("Pending"));
            if (CONNECT.skipLoss == -1)
                CONNECT.skipLoss = 0;
            else
            {
                string sql = "";
                if (cmbStatus.Text != "Lost")
                {
                    sql = "UPDATE [order_database].dbo.quotation_feed_back SET status = '" + cmbStatus.Text + "',too_expensive = 0,lead_time_too_long = 0,quote_took_too_long = 0,unable_to_meet_spec = 0,non_responsive_customer = 0,customer_lost_the_quote = 0 WHERE quote_id = " + quote_id.ToString();
                    sql_update(sql);
                }
                else
                {
                    sql = "UPDATE [order_database].dbo.quotation_feed_back SET status = '" + cmbStatus.Text + "' WHERE quote_id = " + quote_id.ToString();
                    sql_update(sql);
                    //frmTraditionalLossReason frm = new frmTraditionalLossReason(quote_id);
                    //frm.ShowDialog();
                    sql = "UPDATE [order_database].dbo.quotation_feed_back SET status = '" + cmbStatus.Text + "',too_expensive = 0,lead_time_too_long = 0,quote_took_too_long = 0,unable_to_meet_spec = 0,non_responsive_customer = 0,customer_lost_the_quote = 0 WHERE quote_id = " + quote_id.ToString();
                    using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                    {
                        sql = "SELECT [status] ,[custom_feedback] ,[too_expensive] ,[lead_time_too_long] ,[quote_took_too_long] ,[unable_to_meet_spec],[non_responsive_customer],[customer_lost_the_quote] " +
                           "FROM [order_database].[dbo].[quotation_feed_back] WHERE quote_id = " + quote_id.ToString();
                        using (SqlCommand cmdData = new SqlCommand(sql, conn))
                        {

                            SqlDataAdapter da = new SqlDataAdapter(cmdData);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            cmbStatus.Text = dt.Rows[0][0].ToString();
                            txtCustom.Text = dt.Rows[0][1].ToString();
                            if (dt.Rows[0][2].ToString() == "-1")
                                chkTooExpensive.Checked = true;
                            if (dt.Rows[0][3].ToString() == "-1")
                                chkLeadTimeTooLong.Checked = true;
                            if (dt.Rows[0][4].ToString() == "-1")
                                chkQuoteTookTooLong.Checked = true;
                            if (dt.Rows[0][5].ToString() == "-1")
                                chkUnableToMeetSpec.Checked = true;
                            if (dt.Rows[0][6].ToString() == "-1")
                                chkNonResponsive.Checked = true;
                            if (dt.Rows[0][7].ToString() == "-1")
                                chkCustomerLostQuote.Checked = true;

                            if (cmbStatus.Text == "Lost")
                            {
                                lblLost.Visible = true;
                                chkLeadTimeTooLong.Visible = true;
                                chkQuoteTookTooLong.Visible = true;
                                chkTooExpensive.Visible = true;
                                chkUnableToMeetSpec.Visible = true;
                                chkNonResponsive.Visible = true;
                                chkCustomerLostQuote.Visible = true;

                                //prompt the user if they want to mark all chases for this customer as complete!

                                string sql_chase_complete = "";

                                DialogResult result = MessageBox.Show("Would you like to mark all chases as complete for this customer?", "Lost Customer", MessageBoxButtons.YesNo);
                                
                                if (result == DialogResult.Yes)
                                {
                                    sql_chase_complete = "update [order_database].[dbo].[quotation_chase_log] SET chase_complete = -1 where quote_id = " + quote_id.ToString();
                                    sql_update(sql_chase_complete);
                                }


                            }
                            if (cmbStatus.Text != "Chasing")
                                btnChase.Visible = false;
                            else
                                btnChase.Visible = true;
                            sql_update(sql);



                        }
                    }
                }
            }
        }

        private void btnChase_Click(object sender, EventArgs e)
        {

            skip_loss_check = -1;



            //im taking this out because we removed the "multiple loss" form so theres no point running it from here

            //////using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            //////{
            //////    conn.Open();
            //////    string sql = "select count(id) from [order_database].[dbo].quotation_chase_log where quote_id = " + quote_id.ToString();
            //////    using (SqlCommand cmd = new SqlCommand(sql, conn))
            //////    {
            //////        var temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            //////        if (temp == null)
            //////            temp = 0;

            //////        //if (temp >= 3)
            //////        //{
            //////        //    DialogResult result = MessageBox.Show("This project has already been chased " + temp.ToString() + " times. Are you sure you want to add a chase?", "Non Responsive Customer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //////        //    if (result == DialogResult.No)
            //////        //    {
            //////        //        //mark customer as non responsive and cancel out the chase
            //////        //        DialogResult lossResult = MessageBox.Show("Would you like to mark this project as lost?", "Project update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //////        //        if (lossResult == DialogResult.Yes)
            //////        //        {
            //////        //            frmTraditionalMultipleChaseLoss frmTraditional = new frmTraditionalMultipleChaseLoss(quote_id);
            //////        //            frmTraditional.ShowDialog();
            //////        //            this.Close();
            //////        //        }

            //////        //        return;
            //////        //    }

            //////        //}

            //////    }

            //////    conn.Close();
            //////}

            frmTraditionalChase frm = new frmTraditionalChase(quote_id, 0, 0);
            frm.ShowDialog();
            //if the current status is not pending then we remove it so it cannot be added back
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                string sql = "SELECT [status] ,[custom_feedback] ,[too_expensive] ,[lead_time_too_long] ,[quote_took_too_long] ,[unable_to_meet_spec],non_responsive_customer,[customer_lost_the_quote]  " +
                    "FROM [order_database].[dbo].[quotation_feed_back] WHERE quote_id = " + quote_id.ToString();
                using (SqlCommand cmdData = new SqlCommand(sql, conn))
                {

                    SqlDataAdapter da = new SqlDataAdapter(cmdData);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbStatus.Text = dt.Rows[0][0].ToString();
                    txtCustom.Text = dt.Rows[0][1].ToString();
                    if (dt.Rows[0][2].ToString() == "-1")
                        chkTooExpensive.Checked = true;
                    if (dt.Rows[0][3].ToString() == "-1")
                        chkLeadTimeTooLong.Checked = true;
                    if (dt.Rows[0][4].ToString() == "-1")
                        chkQuoteTookTooLong.Checked = true;
                    if (dt.Rows[0][5].ToString() == "-1")
                        chkUnableToMeetSpec.Checked = true;
                    if (dt.Rows[0][6].ToString() == "-1")
                        chkNonResponsive.Checked = true;
                    if (dt.Rows[0][7].ToString() == "-1")
                        chkCustomerLostQuote.Checked = true;

                    if (cmbStatus.Text == "Lost")
                    {
                        lblLost.Visible = true;
                        chkLeadTimeTooLong.Visible = true;
                        chkQuoteTookTooLong.Visible = true;
                        chkTooExpensive.Visible = true;
                        chkUnableToMeetSpec.Visible = true;
                        chkNonResponsive.Visible = true;
                        chkCustomerLostQuote.Visible = true;
                    }
                    if (cmbStatus.Text != "Chasing")
                        btnChase.Visible = false;
                    else
                        btnChase.Visible = true;

                }
            }
            
            recent_chase();
        }

        private void btnChaseHistory_Click(object sender, EventArgs e)
        {
            ////  string sql = "select l.id from [order_database].dbo.quotation_chase_log  l " +
            ////"left join[user_info].dbo.[user] u on l.chased_by = u.id " +
            ////"where quote_id = " + quote_id.ToString();

            ////  using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            ////  {
            ////      using (SqlCommand cmd = new SqlCommand(sql, conn))
            ////      {
            ////          conn.Open();
            ////          SqlDataAdapter da = new SqlDataAdapter(cmd);
            ////          DataTable dt = new DataTable();
            ////          da.Fill(dt);
            ////          if (dt.Rows.Count == 0)
            ////          {
            ////              MessageBox.Show("There is no chase history for this quote!", "Missing Chase", MessageBoxButtons.OK, MessageBoxIcon.Error);
            ////              return;
            ////          }
            ////          conn.Close();
            ////      }
            ////  }


            //old code ^^

            frmTraditionalChaseHistoryNew frm = new frmTraditionalChaseHistoryNew(quote_id);
            frm.ShowDialog();
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

        private void chkTooExpensive_CheckedChanged(object sender, EventArgs e)
        {
            int value = 0;
            if (chkTooExpensive.Checked == true)
                value = -1;
            string sql = "UPDATE [order_database].dbo.quotation_feed_back SET too_expensive = " + value + " WHERE quote_id = " + quote_id.ToString();
            sql_update(sql);
        }

        private void chkLeadTimeTooLong_CheckedChanged(object sender, EventArgs e)
        {
            int value = 0;
            if (chkLeadTimeTooLong.Checked == true)
                value = -1;
            string sql = "UPDATE [order_database].dbo.quotation_feed_back SET lead_time_too_long = " + value + " WHERE quote_id = " + quote_id.ToString();
            sql_update(sql);
        }

        private void chkQuoteTookTooLong_CheckedChanged(object sender, EventArgs e)
        {
            int value = 0;
            if (chkQuoteTookTooLong.Checked == true)
                value = -1;
            string sql = "UPDATE [order_database].dbo.quotation_feed_back SET quote_took_too_long = " + value + " WHERE quote_id = " + quote_id.ToString();
            sql_update(sql);
        }

        private void chkUnableToMeetSpec_CheckedChanged(object sender, EventArgs e)
        {
            int value = 0;
            if (chkUnableToMeetSpec.Checked == true)
                value = -1;
            string sql = "UPDATE [order_database].dbo.quotation_feed_back SET unable_to_meet_spec = " + value + " WHERE quote_id = " + quote_id.ToString();
            sql_update(sql);
        }

        private void txtCustom_Leave(object sender, EventArgs e)
        {
            //txtCustom.Text = txtCustom.Text.Replace("'", "");
            //string sql = "UPDATE [order_database].dbo.quotation_feed_back SET custom_feedback = '" + txtCustom.Text + "' WHERE quote_id = " + quote_id.ToString();
            //sql_update(sql);
            //dont need this anymore as there is an insert button


        }

        private void txtCustom_LostFocus(object sender, EventArgs e)
        {
            txtCustom.Text = txtCustom.Text.Replace("'", "");
            string sql = "UPDATE [order_database].dbo.quotation_feed_back SET custom_feedback = '" + txtCustom.Text + "' WHERE quote_id = " + quote_id.ToString();
            sql_update(sql);
        }

        private void frmTraditionalQuotation_FormClosing(object sender, FormClosingEventArgs e)
        {
            //txtCustom.Text = txtCustom.Text.Replace("'", "");
            //string sql = "UPDATE [order_database].dbo.quotation_feed_back SET custom_feedback = '" + txtCustom.Text + "' WHERE quote_id = " + quote_id.ToString();
            //sql_update(sql);


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
                if (chkCustomerLostQuote.Checked == true)
                    cancel_close = 0;

                if (cancel_close == -1)
                {
                    MessageBox.Show("You must select a reason for loss (check box) before closing this form.", "Reason for loss missing.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void btnRelatedEnquiries_Click(object sender, EventArgs e)
        {
            string sql = "select id from [EnquiryLog].dbo.[Enquiry_Log] where related_quote = '" + quote_id.ToString() + "-" + cmbRev.Text + "'";
            //if there is no enquiry - prompt the user if they want to add a link!

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    var validation = cmd.ExecuteScalar();
                    if (validation == null)
                    {
                        DialogResult result = MessageBox.Show("There is no enquiry related to this quote, would you like to add a related enquiry?","No Related Enquiry",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
                        if (result == DialogResult.Yes)
                        {
                            frmTraditionalLinkEnquiry frm = new frmTraditionalLinkEnquiry(quote_id.ToString() + "-" + cmbRev.Text);
                            frm.ShowDialog();
                        }
                    }
                    else
                    {
                        frmTraditionalEnquiryHistory frm = new frmTraditionalEnquiryHistory(quote_id.ToString() + "-" + cmbRev.Text);
                        frm.ShowDialog();
                    }
                }
                conn.Close();
            }



            
        }

        private void chkNonResponsive_CheckedChanged(object sender, EventArgs e)
        {
            int value = 0;
            if (chkNonResponsive.Checked == true)
                value = -1;
            string sql = "UPDATE [order_database].dbo.quotation_feed_back SET non_responsive_customer = " + value + " WHERE quote_id = " + quote_id.ToString();
            sql_update(sql);
        }

        private void chkPriority_CheckedChanged(object sender, EventArgs e)
        {
            int value = 0;
            if (chkPriority.Checked == true)
                value = -1;
            string sql = "UPDATE [order_database].dbo.quotation_feed_back SET priority_chase = " + value + " WHERE quote_id = " + quote_id.ToString();
            sql_update(sql);
        }

        private void recent_chase()
        {
            //get the recent chase data
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                //check if there is a existing chase~

                string sql = "select top 1 id FROM [order_database].dbo.quotation_chase_log  where quote_id = " + quote_id + " order by id desc";
                int chase_exists = 0;
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    var data = cmd.ExecuteScalar();
                    if (data != null)
                        chase_exists = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                }

                if (chase_exists == 0) //small size = 1240, 638
                {
                    this.Size = new Size(1240, 638);
                }
                else //large size = 1656, 638
                {
                    this.Size = new Size(1656, 638);

                    //populate data with the latest chase information

                    sql = "select chase_date,chase_description,next_chase_date, dont_chase,phone,email from [order_database].dbo.quotation_chase_log  where id = " + chase_exists.ToString();

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



                this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                          (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);

                conn.Close();
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            //opens a form to enter a note
            frmTraditionalInsertNote frm = new frmTraditionalInsertNote(quote_id);
            frm.ShowDialog();


            //if the current status is not pending then we remove it so it cannot be added back
            string sql = "SELECT [custom_feedback] FROM [order_database].[dbo].[quotation_feed_back] WHERE quote_id = " + quote_id.ToString();
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

        private void chkCustomerLostQuote_CheckedChanged(object sender, EventArgs e)
        {
            int value = 0;
            if (chkCustomerLostQuote.Checked == true)
                value = -1;
            string sql = "UPDATE [order_database].dbo.quotation_feed_back SET customer_lost_the_quote = " + value + " WHERE quote_id = " + quote_id.ToString();
            sql_update(sql);
        }
    }
}
