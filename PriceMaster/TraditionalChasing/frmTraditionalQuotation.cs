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

        public int quote_id { get; set; }
        public frmTraditionalQuotation(int _quote_id, string customer)
        {
            InitializeComponent();
            quote_id = _quote_id;
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
                    sql = "SELECT [status] ,[custom_feedback] ,[too_expensive] ,[lead_time_too_long] ,[quote_took_too_long] ,[unable_to_meet_spec],[non_responsive_customer] " +
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

            fillGrid();
        }

        private void fillGrid()
        {
            string sql = "select CAST(parent_spec as nvarchar(max)) + '-' + cast(row_index as nvarchar(max)) + '-' + cast(rev_num as nvarchar(max)) as [Parent Spec], item_ref as [Item Ref], " +
                "item_type as [Item Type], single_double as [Single / Double], width as [Width], height as [Height], threshold as [Threshold], hardware as [Hardware], qty_same as [Quantity Same],cost as [Cost]" +
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
            if (CONNECT.skipLoss == -1)
                CONNECT.skipLoss = 0;
            else
            {
                string sql = "";
                if (cmbStatus.Text != "Lost")
                {
                    sql = "UPDATE [order_database].dbo.quotation_feed_back SET status = '" + cmbStatus.Text + "',too_expensive = 0,lead_time_too_long = 0,quote_took_too_long = 0,unable_to_meet_spec = 0,non_responsive_customer = 0 WHERE quote_id = " + quote_id.ToString();
                    sql_update(sql);
                }
                else
                {
                    sql = "UPDATE [order_database].dbo.quotation_feed_back SET status = '" + cmbStatus.Text + "' WHERE quote_id = " + quote_id.ToString();
                    sql_update(sql);
                    frmTraditionalLossReason frm = new frmTraditionalLossReason(quote_id);
                    frm.ShowDialog();
                    sql = "UPDATE [order_database].dbo.quotation_feed_back SET status = '" + cmbStatus.Text + "',too_expensive = 0,lead_time_too_long = 0,quote_took_too_long = 0,unable_to_meet_spec = 0,non_responsive_customer = 0 WHERE quote_id = " + quote_id.ToString();
                    using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                    {
                        sql = "SELECT [status] ,[custom_feedback] ,[too_expensive] ,[lead_time_too_long] ,[quote_took_too_long] ,[unable_to_meet_spec],[non_responsive_customer] " +
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
                            sql_update(sql);
                        }
                    }
                }
            }
        }

        private void btnChase_Click(object sender, EventArgs e)
        {


            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                string sql = "select count(id) from [order_database].[dbo].quotation_chase_log where quote_id = " + quote_id.ToString();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    var temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    if (temp == null)
                        temp = 0;

                    if (temp >= 3)
                    {
                        DialogResult result = MessageBox.Show("This project has already been chased " + temp.ToString() + " times. Are you sure you want to add a chase?", "Non Responsive Customer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.No)
                        {
                            //mark customer as non responsive and cancel out the chase
                            DialogResult lossResult = MessageBox.Show("Would you like to mark this project as lost?", "Project update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (lossResult == DialogResult.Yes)
                            {
                                frmTraditionalMultipleChaseLoss frmTraditional = new frmTraditionalMultipleChaseLoss(quote_id);
                                frmTraditional.ShowDialog();
                                this.Close();
                            }

                            return;
                        }

                    }

                }

                conn.Close();
            }

            frmTraditionalChase frm = new frmTraditionalChase(quote_id, 0, 0);
            frm.ShowDialog();
            //if the current status is not pending then we remove it so it cannot be added back
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                string sql = "SELECT [status] ,[custom_feedback] ,[too_expensive] ,[lead_time_too_long] ,[quote_took_too_long] ,[unable_to_meet_spec],non_responsive_customer " +
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
        }

        private void btnChaseHistory_Click(object sender, EventArgs e)
        {
            string sql = "select l.id from [order_database].dbo.quotation_chase_log  l " +
          "left join[user_info].dbo.[user] u on l.chased_by = u.id " +
          "where quote_id = " + quote_id.ToString();

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("There is no chase history for this quote!", "Missing Chase", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    conn.Close();
                }
            }

            frmChaseHistory frm = new frmChaseHistory(quote_id);
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
            txtCustom.Text = txtCustom.Text.Replace("'", "");
            string sql = "UPDATE [order_database].dbo.quotation_feed_back SET custom_feedback = '" + txtCustom.Text + "' WHERE quote_id = " + quote_id.ToString();
            sql_update(sql);
        }

        private void txtCustom_LostFocus(object sender, EventArgs e)
        {
            txtCustom.Text = txtCustom.Text.Replace("'", "");
            string sql = "UPDATE [order_database].dbo.quotation_feed_back SET custom_feedback = '" + txtCustom.Text + "' WHERE quote_id = " + quote_id.ToString();
            sql_update(sql);
        }

        private void frmTraditionalQuotation_FormClosing(object sender, FormClosingEventArgs e)
        {
            txtCustom.Text = txtCustom.Text.Replace("'", "");
            string sql = "UPDATE [order_database].dbo.quotation_feed_back SET custom_feedback = '" + txtCustom.Text + "' WHERE quote_id = " + quote_id.ToString();
            sql_update(sql);


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

        private void btnRelatedEnquiries_Click(object sender, EventArgs e)
        {
            string sql = "select id,subject,sender_email_address from [EnquiryLog].dbo.[Enquiry_Log] where related_quote = '" + quote_id.ToString() + "-" + cmbRev.Text + "'";

            frmTraditionalEnquiryHistory frm = new frmTraditionalEnquiryHistory(quote_id.ToString() + "-" + cmbRev.Text);

            frm.ShowDialog();
        }

        private void chkNonResponsive_CheckedChanged(object sender, EventArgs e)
        {
            int value = 0;
            if (chkNonResponsive.Checked == true)
                value = -1;
            string sql = "UPDATE [order_database].dbo.quotation_feed_back SET non_responsive_customer = " + value + " WHERE quote_id = " + quote_id.ToString();
            sql_update(sql);
        }
    }
}
