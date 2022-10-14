﻿using System;
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

namespace PriceMaster
{
    public partial class frmTraditional : Form
    {
        public int quote_index { get; set; }
        public int date_output_index { get; set; }
        public int rev_number_index { get; set; }
        public int item_count_index { get; set; }
        public int customer_index { get; set; }
        public int customer_reference_index { get; set; }
        public int quoted_by_index { get; set; }
        public int delivery_address_index { get; set; }
        public int value_index { get; set; }
        public int dateFilter { get; set; }
        public int quote_button_index { get; set; }
        public int status_index { get; set; }

        public frmTraditional()
        {
            InitializeComponent();
            apply_filter();
            fillCombo();
        }

        private void apply_filter()
        {
            string sql = "select top 300 s.quote_id,date_output,s.revision_number,item_count,customer,customer_ref,emailed_to as quoted_by,deliveryAddress,total_quotation_value,coalesce(q.status,'') as status " +
                "from [order_database].dbo.solidworks_quotation_log s " +
                "inner join (select quote_id,max(revision_number) as revision_number from [order_database].dbo.solidworks_quotation_log group by quote_id) as b on s.quote_id = b.quote_id AND s.revision_number = b.revision_number " +
                "left join [order_database].dbo.quotation_feed_back q on s.quote_id = q.quote_id " +
                "WHERE ";

            if (txtQuoteID.Text.Length > 0)
                sql = sql + "  s.quote_id like '%" + txtQuoteID.Text + "%'    AND ";

            if (dateFilter == -1)
                sql = sql + "  date_output >= '" + dteStart.Value.ToString("yyyyMMdd") + "' AND date_output <= '" + dteEnd.Value.ToString("yyyyMMdd") + "'   AND ";

            if (txtItemCount.Text.Length > 0)
                sql = sql + "  item_count > " + txtItemCount.Text + "   AND ";

            if (cmbCustomer.Text.Length > 0)
                sql = sql + "  customer = '" + cmbCustomer.Text + "'   AND ";

            if (txtCustomerReference.Text.Length > 0)
                sql = sql + "  customer_ref LIKE '%" + txtCustomerReference.Text + "%'    AND ";

            if (txtQuotedBy.Text.Length > 0)
                sql = sql + "  emailed_to LIKE '%" + txtQuotedBy.Text + "%'    AND ";

            if (txtDeliveryAddress.Text.Length > 0)
                sql = sql + "  deliveryAddress LIKE '%" + txtDeliveryAddress.Text + "%'   AND ";

            if (txtValue.Text.Length > 0)
                sql = sql + "  total_quotation_value >= " + txtValue.Text + "   AND ";

            if (cmbStatus.Text.Length > 0)
                sql = sql + "  status = '" + cmbStatus.Text + "'   AND ";



            sql = sql.Substring(0, sql.Length - 6);

            sql = sql + " order by quote_id desc";

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    column_index();
                    addButtons();
                    format();
                    conn.Close();
                }
            }
        }

        private void addButtons()
        {

            if (dataGridView1.Columns.Contains("View Quote") == true)
                dataGridView1.Columns.Remove("View Quote");
            column_index();


            DataGridViewButtonColumn view_button = new DataGridViewButtonColumn();
            view_button.Name = "View Quote";
            view_button.Text = "View Quote";
            view_button.UseColumnTextForButtonValue = true;
            if (dataGridView1.Columns["view_column"] == null)
            {
                dataGridView1.Columns.Insert(quote_index + 1, view_button);
            }
            column_index();
        }

        public void fillCombo()
        {
            string sql = "select distinct customer FROM [order_database].dbo.solidworks_quotation_log WHERE customer is not null order by customer asc";
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                        cmbCustomer.Items.Add(reader.GetString(0));
                    reader.Close();
                    conn.Close();
                }
            }
        }
        private void format()
        {
            //remove >@designandsupply.co.uk< if it exists

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[quoted_by_index].Value.ToString().Contains("@designandsupply.co.uk"))
                    row.Cells[quoted_by_index].Value = row.Cells[quoted_by_index].Value.ToString().Replace("@designandsupply.co.uk", "");
                if (row.Cells[quoted_by_index].Value.ToString().Contains("sales@sealantonline.co.uk"))
                    row.Cells[quoted_by_index].Value = row.Cells[quoted_by_index].Value.ToString().Replace("sales@sealantonline.co.uk", "tomasz");

                //sales@sealantonline.co.uk
            }
            //label at the bottom right
            double total_cost = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
                total_cost = total_cost + Convert.ToDouble(row.Cells[value_index].Value);
            lblTotalCost.Text = total_cost.ToString("C");

            //headertext stuff
            dataGridView1.Columns[quote_index].HeaderText = "Quote ID";
            dataGridView1.Columns[date_output_index].HeaderText = "Date Output";
            dataGridView1.Columns[rev_number_index].HeaderText = "Revision Number";
            dataGridView1.Columns[item_count_index].HeaderText = "Item Count";
            dataGridView1.Columns[customer_index].HeaderText = "Customer";
            dataGridView1.Columns[customer_reference_index].HeaderText = "Customer Ref";
            dataGridView1.Columns[quoted_by_index].HeaderText = "Quoted by";
            dataGridView1.Columns[delivery_address_index].HeaderText = "Delivery Address";
            dataGridView1.Columns[value_index].HeaderText = "Value";
            dataGridView1.Columns[status_index].HeaderText = "Status";

            foreach (DataGridViewColumn col in dataGridView1.Columns)
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            //////////quote ref is far too big sometimes so we need to force this to be less -- same for sys
            ////////dataGridView1.Columns[quotation_ref_index].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ////////dataGridView1.Columns[quotation_ref_index].Width = 250;

            //////////button sizes
            ////////dataGridView1.Columns[view_button_index].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ////////dataGridView1.Columns[email_button_index].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ////////dataGridView1.Columns[view_button_index].Width = 100;
            ////////dataGridView1.Columns[email_button_index].Width = 100;


            dataGridView1.Columns[value_index].DefaultCellStyle.Format = "c2";
            dataGridView1.Columns[value_index].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-GB");

            dataGridView1.Columns[customer_reference_index].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void column_index()
        {
            quote_index = dataGridView1.Columns["quote_id"].Index;
            if (dataGridView1.Columns.Contains("View Quote") == true)
                quote_button_index = dataGridView1.Columns["View Quote"].Index;
            date_output_index = dataGridView1.Columns["date_output"].Index;
            rev_number_index = dataGridView1.Columns["revision_number"].Index;
            item_count_index = dataGridView1.Columns["item_count"].Index;
            customer_index = dataGridView1.Columns["customer"].Index;
            customer_reference_index = dataGridView1.Columns["customer_ref"].Index;
            quoted_by_index = dataGridView1.Columns["quoted_by"].Index;
            delivery_address_index = dataGridView1.Columns["deliveryAddress"].Index;
            value_index = dataGridView1.Columns["total_quotation_value"].Index;
            status_index = dataGridView1.Columns["status"].Index;
        }

        private void dteStart_ValueChanged(object sender, EventArgs e)
        {
            dateFilter = -1;
            apply_filter();
        }

        private void dteEnd_ValueChanged(object sender, EventArgs e)
        {
            dateFilter = -1;
            apply_filter();
        }



        private void btnClear_Click(object sender, EventArgs e)
        {
            txtQuoteID.Text = "";
            dateFilter = 0;
            txtItemCount.Text = "";
            cmbCustomer.Text = "";
            txtCustomerReference.Text = "";
            txtDeliveryAddress.Text = "";
            txtValue.Text = "";
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string sql = "";
            column_index();
            if (e.ColumnIndex == quote_button_index)
            {
                try
                {
                    string path = @"\\designsvr1\SOLIDWORKS\Door Designer\Specifications\Project " + dataGridView1.Rows[e.RowIndex].Cells[quote_index].Value.ToString() + @"\Quotations\Revision " + dataGridView1.Rows[e.RowIndex].Cells[rev_number_index].Value.ToString() + @"\FullQuotation-" + dataGridView1.Rows[e.RowIndex].Cells[quote_index].Value.ToString() + "-" + dataGridView1.Rows[e.RowIndex].Cells[rev_number_index].Value.ToString() + ".pdf";
                    System.Diagnostics.Process.Start(path);
                }
                catch
                {
                    MessageBox.Show("The full quotation does not yet exist for this number.", "No File Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }  //opens the quote doc <<<< needs to be looked at

            if (e.ColumnIndex == quote_index)
            {
                //if there is no entry in quotation_feed_back then make one
                sql = "select cast(quote_id as nvarchar(max)) FROM [order_database].dbo.quotation_feed_back WHERE quote_id = " + dataGridView1.Rows[e.RowIndex].Cells[quote_index].Value.ToString();
                using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        string data = (string)cmd.ExecuteScalar();
                        if (data == null)
                        {
                            sql = "INSERT INTO [order_database].dbo.quotation_feed_back (quote_id) VALUES (" + dataGridView1.Rows[e.RowIndex].Cells[quote_index].Value.ToString() + ")";
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    conn.Close();
                }

                frmTraditionalQuotation frm = new frmTraditionalQuotation(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[quote_index].Value.ToString()), dataGridView1.Rows[e.RowIndex].Cells[customer_index].Value.ToString());
                frm.ShowDialog();
            }  //opens quotation screen
        }

        private void txtQuoteID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                apply_filter();
        }

        private void txtQuoteID_Leave(object sender, EventArgs e)
        {
            apply_filter();
        }

        private void txtItemCount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                apply_filter();
        }

        private void txtItemCount_Leave(object sender, EventArgs e)
        {
            apply_filter();
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            apply_filter();
        }

        private void txtCustomerReference_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                apply_filter();
        }

        private void txtCustomerReference_Leave(object sender, EventArgs e)
        {
            apply_filter();
        }

        private void txtQuotedBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                apply_filter();
        }

        private void txtQuotedBy_Leave(object sender, EventArgs e)
        {
            apply_filter();
        }

        private void txtDeliveryAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                apply_filter();
        }

        private void txtDeliveryAddress_Leave(object sender, EventArgs e)
        {
            apply_filter();
        }

        private void txtValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                apply_filter();
        }

        private void txtValue_Leave(object sender, EventArgs e)
        {
            apply_filter();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            apply_filter();
        }
    }
}