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
    public partial class frmOutstandingChase : Form
    {
        public int id_index { get; set; }
        public int quote_index { get; set; }
        public int chase_date_index { get; set; }
        public int chase_description_index { get; set; }
        public int next_chase_date_index { get; set; }
        public int chased_by_index { get; set; }
        public int button_index { get; set; }
        public int admin { get; set; }
        public int customer_index { get; set; }
        public int sender_email_address_index { get; set; }
        public frmOutstandingChase(int _admin)
        {
            InitializeComponent();
            admin = _admin;
            load_data();
            if (admin == -1)
                this.Text = "Admin Outstanding Chases";

            //load all the data into the customers
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (cmbCustomerSearch.Items.Contains(row.Cells[6].Value.ToString()))
                { } //nothing
                else
                    cmbCustomerSearch.Items.Add(row.Cells[6].Value.ToString());
            }

        }

        private void format()
        {
            dataGridView1.Columns[id_index].Visible = false;
            dataGridView1.Columns[quote_index].HeaderText = "Quote ID";
            dataGridView1.Columns[chase_date_index].HeaderText = "Chase Date";
            dataGridView1.Columns[chase_description_index].HeaderText = "Chase Description";
            dataGridView1.Columns[next_chase_date_index].HeaderText = "Next Chase Date";
            dataGridView1.Columns[customer_index].HeaderText = "Customer";
            dataGridView1.Columns[sender_email_address_index].HeaderText = "Sender Email Address";


            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[sender_email_address_index].Value.ToString().Contains("EXCHANGELABS/OU=EXCHANGE"))
                {
                    //remove all the clutter
                    string temp = row.Cells[sender_email_address_index].Value.ToString();
                    row.Cells[sender_email_address_index].Value = temp.Substring(temp.IndexOf("-") + 1);
                }
            }


            if (admin == 0)
                dataGridView1.Columns[chased_by_index].Visible = false;
            else
                dataGridView1.Columns[chased_by_index].HeaderText = "Chased by";

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dataGridView1.Columns[chase_description_index].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void load_data()
        {
            dataGridView1.DataSource = null;
            string sql = "SELECT a.id,a.quote_id,chase_date,chase_description,next_chase_date,u.forename + ' ' + u.surname as  [Chased by],rtrim(q.customer) as customer,e.sender_email_address " +
                "FROM [order_database].dbo.quotation_chase_log a " +
                "left join [order_database].dbo.quotation_feed_back b on a.quote_id = b.quote_id " +
                "left join[user_info].dbo.[user] u on a.chased_by = u.id " +
                "left join (select quote_id,max(revision_number) as revision_number from [order_database].dbo.solidworks_quotation_log group by quote_id) sw on a.quote_id = sw.quote_id " +
                "left join [order_database].dbo.solidworks_quotation_log q on sw.quote_id = q.quote_id and sw.revision_number = q.revision_number " +
                "left join (select max(id) as enquiry_id, left(related_quote, CHARINDEX('-', related_quote) - 1) as related_quote from [EnquiryLog].dbo.[Enquiry_Log] WHERE related_quote<> 'No Related Quote' group by LEFT(related_quote, CHARINDEX('-', related_quote) - 1)) el on el.related_quote like '%' + cast(q.quote_id as nvarchar) + '%' " +
                "left join [EnquiryLog].dbo.[Enquiry_Log] e on el.enquiry_id = e.id " +
                "where next_chase_date <= CAST(GETDATE() as date) and b.[status] = 'Chasing' and (dont_chase = 0 or dont_chase is null) ";

            if (string.IsNullOrEmpty(cmbCustomerSearch.Text) == false)
                sql = sql + " AND rtrim(q.customer) = '" + cmbCustomerSearch.Text + "'  ";

            if (admin == 0)
                sql = sql + "AND chased_by = " + CONNECT.staffID.ToString();

            sql = sql + " order by rtrim(q.customer) ,next_chase_date asc, quote_id ";
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
            column_index();
            add_button();
            column_index();
            format();
            column_index();
        }
        private void add_button()
        {

            //if (dataGridView1.Columns.Contains("Complete") == true)
            //    dataGridView1.Columns.Remove("Complete");

            //column_index();
            //DataGridViewButtonColumn view_button = new DataGridViewButtonColumn();
            //view_button.Name = "Complete";
            //view_button.Text = "Mark Complete";
            //view_button.UseColumnTextForButtonValue = true;
            //if (dataGridView1.Columns["Complete"] == null)
            //{
            //    dataGridView1.Columns.Insert(next_chase_date_index + 1, view_button);
            //}

        }

        private void column_index()
        {
            id_index = dataGridView1.Columns["id"].Index;
            quote_index = dataGridView1.Columns["quote_id"].Index;
            chase_date_index = dataGridView1.Columns["chase_date"].Index;
            chase_description_index = dataGridView1.Columns["chase_description"].Index;
            next_chase_date_index = dataGridView1.Columns["next_chase_date"].Index;
            chased_by_index = dataGridView1.Columns["Chased by"].Index;
            customer_index = dataGridView1.Columns["customer"].Index;
            sender_email_address_index = dataGridView1.Columns["sender_email_address"].Index;

            if (dataGridView1.Columns.Contains("Complete") == true)
                button_index = dataGridView1.Columns["Complete"].Index;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            column_index();
            //if (e.ColumnIndex == button_index)
            //{
            //    DialogResult result = MessageBox.Show("Are you sure you want to mark this chase as completed?", "Completed Chase Entry", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            //    if (result == DialogResult.Yes)
            //    {
            //        string sql = "UPDATE [order_database].dbo.[quotation_chase_log] SET chase_followed_up = -1,chase_followed_up_date = GETDATE() WHERE id = " + dataGridView1.Rows[e.RowIndex].Cells[id_index].Value.ToString();
            //        using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            //        {
            //            conn.Open();
            //            using (SqlCommand cmd = new SqlCommand(sql, conn))
            //                cmd.ExecuteNonQuery();
            //            conn.Close();
            //            load_data();
            //        }
            //    }
            //}
            //else
            //{
            //try
            //{

            //get the customer
            string customer = "";
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                string sql = "select customer from [order_database].dbo.solidworks_quotation_log where quote_id = " + dataGridView1.Rows[e.RowIndex].Cells[quote_index].Value.ToString();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    customer = cmd.ExecuteScalar().ToString();

                conn.Close();
            }

            frmTraditionalQuotation frm = new frmTraditionalQuotation(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[quote_index].Value.ToString()), customer);
            frm.ShowDialog();
            load_data();
            //apply_filter();
            //}
            //    catch { }
            //}
        }

        private void cmbCustomerSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_data();
        }
    }
}
