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
using System.IO;
using System.Diagnostics;

namespace PriceMaster
{
    public partial class frmQuotation : Form
    {
        public int _quote_id { get; set; }
        public string temp { get; set; }
        public int skipSQL { get; set; }
        public frmQuotation(int quote_id)
        {
            InitializeComponent();
            _quote_id = quote_id;
            skipSQL = -1;

            //get the max rev 
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                //very quickly get the max issue of this quote
                string sql = "select max(issue_id) FROM dbo.sl_quotation where quote_id = " + _quote_id;

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    cmbIssue.Text = cmd.ExecuteScalar().ToString();

                conn.Close();
            }
            loadData();
            fillCombo();
            lblTitle.Text = "Quote " + _quote_id.ToString();
            skipSQL = 0;
        }

        private void loadData()
        {
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                //very quickly get the max issue of this quote
                string sql = "select s.[NAME],quotation_ref,a.customer_contact,customer_email,fitting_quote_id,price,prio.priority_description,quoted_by.forename + ' ' + quoted_by.surname as created_by, " +
                    "quote_date,followed_up_yn,CAST(follow_up_date as date) as follow_up_date,sl_status.description as status,loss.description as reason_for_loss,material.material_description as material_Type, " +
                    "supplier.company_name,supplier_reference, sys_1.system_name,sys_2.system_name,sys_3.system_name,sys_4.system_name,sys_5.system_name,note,enquiry_id,s.type " +
                    "from dbo.sl_quotation a " +
                    "LEFT JOIN [dsl_fitting].dbo.[SALES_LEDGER] s on s.ACCOUNT_REF = a.customer_acc_ref " +
                    "left join dbo.sl_priority prio on prio.id = a.priority_id " +
                    "left join dbo.sl_material_suppliers supplier on supplier.id = a.material_supplier_id " +
                    "LEFT JOIN dbo.sl_material material on material.id = a.material_type_id " +
                    "LEFT JOIN dbo.sl_reason_for_loss loss on loss.id = a.reason_for_loss_id " +
                    "LEFT JOIN dbo.sl_status on sl_status.id = a.status_id " +
                    "LEFT JOIN[user_info].dbo.[user] as quoted_by on quoted_by.id = a.created_by_id " +
                    "LEFT JOIN dbo.slimline_systems as sys_1 ON a.system_id_1 = sys_1.id " +
                    "LEFT JOIN dbo.slimline_systems AS sys_2 ON a.system_id_2 = sys_2.id " +
                    "LEFT JOIN dbo.slimline_systems AS sys_3 ON a.system_id_3 = sys_3.id " +
                    "LEFT JOIN dbo.slimline_systems AS sys_4 ON a.system_id_4 = sys_4.id " +
                    "LEFT JOIN dbo.slimline_systems AS sys_5 ON a.system_id_5 = sys_5.id  " +
                    "where quote_id = " + _quote_id + " AND issue_id = " + cmbIssue.Text;

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //use this dt to fill out all the  boxes

                    cmbCustomer.Text = dt.Rows[0][0].ToString();
                    txtQuoteRef.Text = dt.Rows[0][1].ToString();
                    txtCustomerContact.Text = dt.Rows[0][2].ToString();
                    txtCustomerEmail.Text = dt.Rows[0][3].ToString();
                    txtFittingQuote.Text = dt.Rows[0][4].ToString();
                    txtPrice.Text = dt.Rows[0][5].ToString();
                    cmbPriority.Text = dt.Rows[0][6].ToString();
                    cmbQuotedBy.Text = dt.Rows[0][7].ToString();
                    dteQuoteDate.Text = dt.Rows[0][8].ToString();
                    if (dt.Rows[0][9].ToString() == "-1")
                        chkFollowUp.Checked = true;
                    else
                        chkFollowUp.Checked = false;
                    try { txtFollowUp.Text = Convert.ToDateTime(dt.Rows[0][10].ToString()).ToString("dd/MM/yyyy"); }
                    catch { }
                    cmbStatus.Text = dt.Rows[0][11].ToString();
                    cmbLoss.Text = dt.Rows[0][12].ToString();
                    cmbMatieralType.Text = dt.Rows[0][13].ToString();
                    cmbMatieralSupplier.Text = dt.Rows[0][14].ToString();
                    txtSupplierRef.Text = dt.Rows[0][15].ToString();
                    cmbSys1.Text = dt.Rows[0][16].ToString();
                    cmbSys2.Text = dt.Rows[0][17].ToString();
                    cmbSys3.Text = dt.Rows[0][18].ToString();
                    cmbSys4.Text = dt.Rows[0][19].ToString();
                    cmbSys5.Text = dt.Rows[0][20].ToString();
                    txtNote.Text = dt.Rows[0][21].ToString();
                    txtEnquiry.Text = dt.Rows[0][22].ToString();
                    cmbType.Text = dt.Rows[0][23].ToString();

                }
                conn.Close();
            }
        }

        private void fillCombo()
        {
            //gets all the data from the tables
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                string sql = "select priority_description from dbo.sl_priority ";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                        cmbPriority.Items.Add(reader.GetString(0));
                    reader.Close();
                }
                //sql = "Select description FROM dbo.sl_status ";
                //using (SqlCommand cmd = new SqlCommand(sql, conn))
                //{
                //    SqlDataReader reader = cmd.ExecuteReader();
                //    while (reader.Read())
                //        cmbStatus.Items.Add(reader.GetString(0));
                //    reader.Close();
                //}
                sql = "Select material_description FROM dbo.sl_material ";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                        cmbMatieralType.Items.Add(reader.GetString(0));
                    reader.Close();
                }
                sql = "SELECT system_name from dbo.slimline_systems ";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cmbSys1.Items.Add(reader.GetString(0));
                        cmbSys2.Items.Add(reader.GetString(0));
                        cmbSys3.Items.Add(reader.GetString(0));
                        cmbSys4.Items.Add(reader.GetString(0));
                        cmbSys5.Items.Add(reader.GetString(0));
                    }
                    reader.Close();
                }
                sql = "SELECT rtrim([NAME]) FROM [dsl_fitting].dbo.SALES_LEDGER where [NAME] is not null order by [NAME] ASC ";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                        cmbCustomer.Items.Add(reader.GetString(0));
                    reader.Close();
                }
                sql = "SELECT DISTINCT forename + ' ' + surname as email_sent_by FROM [user_info].dbo.[user] where slimline_staff = -1 and [current] = 1 and (ShopFloor = 0 or ShopFloor is null) order by forename + ' ' + surname";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                        cmbQuotedBy.Items.Add(reader.GetString(0));
                    reader.Close();
                }
                sql = "select company_name from dbo.sl_material_suppliers";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                        cmbMatieralSupplier.Items.Add(reader.GetString(0));
                    reader.Close();
                }
                sql = "select description from dbo.sl_reason_for_loss";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                        cmbLoss.Items.Add(reader.GetString(0));
                    reader.Close();
                }
                //fill issue box
                sql = "select cast(issue_id as nvarchar(max)) FROM dbo.sl_quotation where quote_id = " + _quote_id;
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                        cmbIssue.Items.Add(reader.GetString(0));
                    reader.Close();
                }
                conn.Close();
            }
        }

        private void runSQL(string sql, int return_param)
        {
            if (skipSQL != -1)
            {
                using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                {
                    conn.Open();
                    if (return_param == 0)
                    {
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                            cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            var data = cmd.ExecuteScalar();
                            if (data == null)
                                temp = "no record";
                            else
                                temp = data.ToString();
                        }
                    }

                    conn.Close();
                }
            }
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get the new cust acc ref
            string sql = "select ACCOUNT_REF from [dsl_fitting].dbo.SALES_LEDGER where [NAME] = '" + cmbCustomer.Text + "'";
            runSQL(sql, -1);


            if (temp != "no record")
            {
                sql = "UPDATE dbo.sl_quotation SET customer_acc_ref = '" + temp + "' WHERE quote_id = " + _quote_id.ToString() + " AND issue_id = " + cmbIssue.Text.ToString();
                runSQL(sql, 0);

                //get the new  type
                sql = "SELECT type FROM [dsl_fitting].dbo.SALES_LEDGER WHERE ACCOUNT_REF = '" + temp + "'";
                runSQL(sql, -1);
                cmbType.Text = temp;
            }
            
            temp = null;
        }



        private void cmbPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "SELECT id from dbo.sl_priority where [priority_description] = '" + cmbPriority.Text + "'";
            runSQL(sql, -1);


            if (temp != "no record")
            {
                sql = "UPDATE dbo.sl_quotation SET priority_id = " + temp + " WHERE quote_id = " + _quote_id.ToString() + " AND issue_id = " + cmbIssue.Text.ToString();
                runSQL(sql, 0);
            }
            temp = null;
        }

        private void cmbQuotedBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "SELECT id FROM [user_info].dbo.[user] where forename + ' ' + surname = '" + cmbQuotedBy.Text + "'";
            runSQL(sql, -1);

            if (temp != "no record")
            {
                sql = "UPDATE dbo.sl_quotation SET created_by_id = " + temp + " WHERE quote_id = " + _quote_id.ToString() + " AND issue_id = " + cmbIssue.Text.ToString();
                runSQL(sql, 0);
            }
            temp = null;
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "SELECT id FROM dbo.sl_status WHERE description =  '" + cmbStatus.Text + "'";
            runSQL(sql, -1);

            if (temp != "no record")
            {
                sql = "UPDATE dbo.sl_quotation SET status_id = " + temp + " WHERE quote_id = " + _quote_id.ToString() + " AND issue_id = " + cmbIssue.Text.ToString();
                runSQL(sql, 0);
            }
            temp = null;
        }

        private void cmbLoss_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "SELECT id FROM dbo.sl_reason_for_loss WHERE description =  '" + cmbLoss.Text + "'";
            runSQL(sql, -1);

            if (temp != "no record")
            {
                sql = "UPDATE dbo.sl_quotation SET reason_for_loss_id = " + temp + " WHERE quote_id = " + _quote_id.ToString() + " AND issue_id = " + cmbIssue.Text.ToString();
                runSQL(sql, 0);
            }
            temp = null;
        }

        private void cmbMatieralType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "SELECT id FROM dbo.sl_material WHERE material_description =  '" + cmbMatieralType.Text + "'";
            runSQL(sql, -1);

            if (temp != "no record")
            {
                sql = "UPDATE dbo.sl_quotation SET material_type_id = " + temp + " WHERE quote_id = " + _quote_id.ToString() + " AND issue_id = " + cmbIssue.Text.ToString();
                runSQL(sql, 0);
            }
            temp = null;
        }

        private void cmbMatieralSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "SELECT id FROM dbo.sl_material_suppliers WHERE company_name =  '" + cmbMatieralSupplier.Text + "'";
            runSQL(sql, -1);

            if (temp != "no record")
            {
                sql = "UPDATE dbo.sl_quotation SET material_supplier_id = " + temp + " WHERE quote_id = " + _quote_id.ToString() + " AND issue_id = " + cmbIssue.Text.ToString();
                runSQL(sql, 0);
            }
            temp = null;
        }

        private void cmbSys1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "SELECT id FROM dbo.slimline_systems WHERE system_name =  '" + cmbSys1.Text + "'";
            runSQL(sql, -1);

            if (temp != "no record")
            {
                sql = "UPDATE dbo.sl_quotation SET system_id_1 = " + temp + " WHERE quote_id = " + _quote_id.ToString() + " AND issue_id = " + cmbIssue.Text.ToString();
                runSQL(sql, 0);
            }
            temp = null;
        }

        private void cmbSys2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "SELECT id FROM dbo.slimline_systems WHERE system_name =  '" + cmbSys2.Text + "'";
            runSQL(sql, -1);

            if (temp != "no record")
            {
                sql = "UPDATE dbo.sl_quotation SET system_id_2 = " + temp + " WHERE quote_id = " + _quote_id.ToString() + " AND issue_id = " + cmbIssue.Text.ToString();
                runSQL(sql, 0);
            }
            temp = null;
        }

        private void cmbSys3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "SELECT id FROM dbo.slimline_systems WHERE system_name =  '" + cmbSys3.Text + "'";
            runSQL(sql, -1);

            if (temp != "no record")
            {
                sql = "UPDATE dbo.sl_quotation SET system_id_3 = " + temp + " WHERE quote_id = " + _quote_id.ToString() + " AND issue_id = " + cmbIssue.Text.ToString();
                runSQL(sql, 0);
            }
            temp = null;
        }

        private void cmbSys4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "SELECT id FROM dbo.slimline_systems WHERE system_name =  '" + cmbSys4.Text + "'";
            runSQL(sql, -1);

            if (temp != "no record")
            {
                sql = "UPDATE dbo.sl_quotation SET system_id_4 = " + temp + " WHERE quote_id = " + _quote_id.ToString() + " AND issue_id = " + cmbIssue.Text.ToString();
                runSQL(sql, 0);
            }
            temp = null;
        }

        private void cmbSys5_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "SELECT id FROM dbo.slimline_systems WHERE system_name =  '" + cmbSys5.Text + "'";
            runSQL(sql, -1);

            if (temp != "no record")
            {
                sql = "UPDATE dbo.sl_quotation SET system_id_5 = " + temp + " WHERE quote_id = " + _quote_id.ToString() + " AND issue_id = " + cmbIssue.Text.ToString();
                runSQL(sql, 0);
            }
            temp = null;
        }

        private void txtQuoteRef_Leave(object sender, EventArgs e)
        {
            //check length + remove '
            txtQuoteRef.Text = txtQuoteRef.Text.Replace("'", "");
            if (txtQuoteRef.Text.Length > 0)
            {
                string sql = "UPDATE dbo.sl_quotation SET quotation_ref = '" + txtQuoteRef.Text + "' WHERE quote_id = " + _quote_id.ToString() + " AND issue_id = " + cmbIssue.Text.ToString();
                runSQL(sql, 0);
            }
        }

        private void txtQuoteRef_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtQuoteRef.Text = txtQuoteRef.Text.Replace("'", "");
                if (txtQuoteRef.Text.Length > 0)
                {
                    string sql = "UPDATE dbo.sl_quotation SET quotation_ref = '" + txtQuoteRef.Text + "' WHERE quote_id = " + _quote_id.ToString() + " AND issue_id = " + cmbIssue.Text.ToString();
                    runSQL(sql, 0);
                }
            }
        }

        private void txtCustomerContact_Leave(object sender, EventArgs e)
        {
            txtCustomerContact.Text = txtCustomerContact.Text.Replace("'", "");
            if (txtCustomerContact.Text.Length > 0)
            {
                string sql = "UPDATE dbo.sl_quotation SET customer_contact = '" + txtCustomerContact.Text + "' WHERE quote_id = " + _quote_id.ToString() + " AND issue_id = " + cmbIssue.Text.ToString();
                runSQL(sql, 0);
            }
        }

        private void txtCustomerContact_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCustomerContact.Text = txtCustomerContact.Text.Replace("'", "");
                if (txtCustomerContact.Text.Length > 0)
                {
                    string sql = "UPDATE dbo.sl_quotation SET customer_contact = '" + txtCustomerContact.Text + "' WHERE quote_id = " + _quote_id.ToString() + " AND issue_id = " + cmbIssue.Text.ToString();
                    runSQL(sql, 0);
                }
            }
        }

        private void txtCustomerEmail_Leave(object sender, EventArgs e)
        {
            txtCustomerEmail.Text = txtCustomerEmail.Text.Replace("'", "");
            if (txtCustomerEmail.Text.Length > 0)
            {
                string sql = "UPDATE dbo.sl_quotation SET customer_email = '" + txtCustomerEmail.Text + "' WHERE quote_id = " + _quote_id.ToString() + " AND issue_id = " + cmbIssue.Text.ToString();
                runSQL(sql, 0);
            }
        }

        private void txtCustomerEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCustomerEmail.Text = txtCustomerEmail.Text.Replace("'", "");
                if (txtCustomerEmail.Text.Length > 0)
                {
                    string sql = "UPDATE dbo.sl_quotation SET customer_email = '" + txtCustomerEmail.Text + "' WHERE quote_id = " + _quote_id.ToString() + " AND issue_id = " + cmbIssue.Text.ToString();
                    runSQL(sql, 0);
                }
            }

        }

        private void txtFittingQuote_Leave(object sender, EventArgs e)
        {
            txtFittingQuote.Text = txtFittingQuote.Text.Replace("'", "");
            if (txtFittingQuote.Text.Length > 0)
            {
                string sql = "UPDATE dbo.sl_quotation SET fitting_quote_id = " + txtFittingQuote.Text + " WHERE quote_id = " + _quote_id.ToString() + " AND issue_id = " + cmbIssue.Text.ToString();
                runSQL(sql, 0);
            }
        }

        private void txtFittingQuote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtFittingQuote.Text = txtFittingQuote.Text.Replace("'", "");
                if (txtFittingQuote.Text.Length > 0)
                {
                    string sql = "UPDATE dbo.sl_quotation SET fitting_quote_id = " + txtFittingQuote.Text + " WHERE quote_id = " + _quote_id.ToString() + " AND issue_id = " + cmbIssue.Text.ToString();
                    runSQL(sql, 0);
                }
            }
        }

        private void txtPrice_Leave(object sender, EventArgs e)
        {
            txtPrice.Text = txtPrice.Text.Replace(",", "");
            txtPrice.Text = txtPrice.Text.Replace("'", "");
            if (txtPrice.Text.Length > 0)
            {
                string sql = "UPDATE dbo.sl_quotation SET price = " + txtPrice.Text + " WHERE quote_id = " + _quote_id.ToString() + " AND issue_id = " + cmbIssue.Text.ToString();
                runSQL(sql, 0);
            }
        }

        private void txtPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPrice.Text = txtPrice.Text.Replace(",", "");
                txtPrice.Text = txtPrice.Text.Replace("'", "");
                if (txtPrice.Text.Length > 0)
                {
                    string sql = "UPDATE dbo.sl_quotation SET price = " + txtPrice.Text + " WHERE quote_id = " + _quote_id.ToString() + " AND issue_id = " + cmbIssue.Text.ToString();
                    runSQL(sql, 0);
                }
            }
        }

        private void txtSupplierRef_Leave(object sender, EventArgs e)
        {
            txtSupplierRef.Text = txtSupplierRef.Text.Replace("'", "");
            if (txtSupplierRef.Text.Length > 0)
            {
                string sql = "UPDATE dbo.sl_quotation SET supplier_reference = " + txtSupplierRef.Text + " WHERE quote_id = " + _quote_id.ToString() + " AND issue_id = " + cmbIssue.Text.ToString();
                runSQL(sql, 0);
            }
        }

        private void txtSupplierRef_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSupplierRef.Text = txtSupplierRef.Text.Replace("'", "");
                if (txtSupplierRef.Text.Length > 0)
                {
                    string sql = "UPDATE dbo.sl_quotation SET supplier_reference = '" + txtSupplierRef.Text + "' WHERE quote_id = " + _quote_id.ToString() + " AND issue_id = " + cmbIssue.Text.ToString();
                    runSQL(sql, 0);
                }
            }
        }

        private void chkFollowUp_CheckedChanged(object sender, EventArgs e)
        {
            int value = 0;
            if (chkFollowUp.Checked == true)
                value = -1;
            else
                value = 0;
            string sql = "UPDATE dbo.sl_quotation SET followed_up_yn = " + value + " WHERE quote_id = " + _quote_id.ToString() + " AND issue_id = " + cmbIssue.Text.ToString();
            runSQL(sql, 0);
        }

        private void dteFollowUp_ValueChanged(object sender, EventArgs e)
        {
            txtFollowUp.Text = dteFollowUp.Value.ToString("dd/MM/yyyy");
            string sql = "UPDATE dbo.sl_quotation SET follow_up_date = '" + dteFollowUp.Value.ToString("yyyyMMdd") + "' WHERE quote_id = " + _quote_id.ToString() + " AND issue_id = " + cmbIssue.Text.ToString();
            runSQL(sql, 0);
        }

        private void txtQuoteRef_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbIssue_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnAddNote_Click(object sender, EventArgs e)
        {
            frmNote note = new frmNote();
            note.ShowDialog();
            if (CONNECT.note == "cancel clicked")
            { MessageBox.Show("Note Cancelled", "", MessageBoxButtons.OK); }
            else
            {
                //update the note then refresh the box
                if (txtNote.Text.Length < 1)
                    txtNote.Text = CONNECT.note;
                else
                    txtNote.Text = txtNote.Text + Environment.NewLine + CONNECT.note;
                string sql = "UPDATE dbo.sl_quotation SET note = '" + txtNote.Text + "'  WHERE quote_id = " + _quote_id.ToString() + " AND issue_id = " + cmbIssue.Text.ToString();
                runSQL(sql, 0);
            }
        }

        private void btnViewQuote_Click(object sender, EventArgs e)
        {
            string filePath = @"S:\SLIMLINE QUOTES\SL" + _quote_id.ToString();

            if (Convert.ToInt32(cmbIssue.Text) > 1) //issue has some extra stuff
                filePath = filePath + "I" + cmbIssue.Text;

            filePath = filePath + ".rtf";

            //check if file exists 
            if (File.Exists(filePath))
                Process.Start(filePath);
            else
                MessageBox.Show("The quotation for " + _quote_id.ToString() + " does not exist!", "Missing File", MessageBoxButtons.OK);
        }

        private void btnRevise_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to revise this quote?", "Revise Quote: " + _quote_id.ToString() + " issue: " + cmbIssue.Text, MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //run usp_revise_quote + quote id + issue_id
                SqlConnection conn = new SqlConnection(CONNECT.ConnectionString);
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_revise_quote", conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@quote_id", SqlDbType.Int).Value = _quote_id;
                    cmd.Parameters.AddWithValue("@issue_id", SqlDbType.Int).Value = Convert.ToInt32(cmbIssue.Text);
                    cmd.ExecuteNonQuery();
                }


                //very quickly get the max issue of this quote

                string sql = "select max(issue_id) FROM dbo.sl_quotation where quote_id = " + _quote_id;

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmbIssue.Text = cmd.ExecuteScalar().ToString();
                    cmbIssue.Items.Add(cmd.ExecuteScalar().ToString());
                }

                //update the quoted date + the quoted by
                sql = "UPDATE dbo.sl_quotation SET quote_date = GETDATE(),created_by_id = " + CONNECT.staffID.ToString() + " WHERE quote_id = " + _quote_id.ToString() + " AND issue_id = " + cmbIssue.Text.ToString();
                runSQL(sql, 0);
                loadData();
                conn.Close();
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnAttachments_Click(object sender, EventArgs e)
        {
            //creates a path for this quote so the users can store whatever they want
            string file_path = @"\\DESIGNSVR1\Public\Slimline_Price_Log\" + _quote_id.ToString();

            DirectoryInfo di = Directory.CreateDirectory(file_path);
            Process.Start(file_path);

            

        }

        private void txtEnquiry_Leave(object sender, EventArgs e)
        {
            if (txtEnquiry.Text.Length > 0)
            {
                string sql = "SELECT id FROM  [EnquiryLog].dbo.Enquiry_Log where id = " + txtEnquiry.Text;
                runSQL(sql, -1);
                if (temp == "no record")
                {
                    MessageBox.Show("The number you have entered does not match any enquiry. Please double check the number and try again", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEnquiry.Text = "";
                    return;
                }

                sql = "UPDATE dbo.sl_quotation SET enquiry_id = " + txtEnquiry.Text + " WHERE quote_id = " + _quote_id.ToString() + " AND issue_id = " + cmbIssue.Text.ToString();
                runSQL(sql, 0);
            }
        }

        private void txtEnquiry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtEnquiry.Text.Length > 0)
                {
                    string sql = "SELECT id FROM  [EnquiryLog].dbo.Enquiry_Log where id = " + txtEnquiry.Text;
                    runSQL(sql, -1);
                    if (temp == "no record")
                    {
                        MessageBox.Show("The number you have entered does not match any enquiry. Please double check the number and try again", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtEnquiry.Text = "";
                        return;
                    }

                    sql = "UPDATE dbo.sl_quotation SET enquiry_id = " + txtEnquiry.Text + " WHERE quote_id = " + _quote_id.ToString() + " AND issue_id = " + cmbIssue.Text.ToString();
                    runSQL(sql, 0);
                }
            }
        }

        private void btnEnquiry_Click(object sender, EventArgs e)
        {
            if (txtEnquiry.Text.Length < 1)
            {
                MessageBox.Show("Please enter an enquiry log ID before clicking the open button.", "No data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmEnquiry frm = new frmEnquiry(Convert.ToInt32(txtEnquiry.Text));
            frm.ShowDialog();
        }

        private void txtEnquiry_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }

}

