using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace PriceMaster.TraditionalChasing
{
    public partial class frmMultipleChase : Form
    {
        public int quote_id { get; set; }
        public string customer { get; set; }
        public DataTable quote_dt { get; set; }
        public string description { get; set; }
        public int dont_chase { get; set; }
        public int email { get; set; }
        public int phone { get; set; }
        public string dteNextDate { get; set; }
        public string chase_status { get; set; }
        public int failed_contact { get; set; }

        public DataTable selected_dt { get; set; }

        public frmMultipleChase(int _quote_id, string _customer, DataTable _quote_dt, string _description, int _dont_chase, int _email, int _phone, string _dteNextDate, string _chase_status, int failed_contact)
        {
            InitializeComponent();

            quote_id = _quote_id;
            customer = _customer;
            quote_dt = _quote_dt;
            description = _description;
            dont_chase = _dont_chase;
            email = _email;
            phone = _phone;
            dteNextDate = _dteNextDate;
            chase_status = _chase_status;
            lblCustomer.Text = customer;

            this.failed_contact = failed_contact;

            dgvSelectedQuotes.Columns.Add("selected_quote", "Quote ID");
            dgvSelectedQuotes.Columns.Add("selected_ref", "Customer Ref");

            loadData();

        }

        private void loadData()
        {

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                string sql = "select top 250 s.quote_id,customer_ref,customer " +
                        "from [order_database].dbo.solidworks_quotation_log s  " +
                        "inner join (select quote_id,max(revision_number) as revision_number  " +
                        "from [order_database].dbo.solidworks_quotation_log group by quote_id) as b on s.quote_id = b.quote_id AND s.revision_number = b.revision_number " +
                        "WHERE customer = '" + customer + "' AND s.quote_id <> " + quote_id.ToString() + " AND s.quote_id like '%" + txtQuote.Text + "%' " +
                        " ORDER BY s.quote_id desc";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    da.Fill(dt);
                    dataGridView1.DataSource = dt;

                }

                conn.Close();
            }


            dataGridView1.Columns[2].Visible = false;

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.Columns[0].HeaderText = "Quote ID";
            dataGridView1.Columns[1].HeaderText = "Customer Ref";



            dgvSelectedQuotes.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvSelectedQuotes.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            dgvSelectedQuotes.DataSource = selected_dt;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor == Color.Empty)
            //    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSkyBlue;
            //else
            //    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Empty;

            int validation = -1;
            foreach (DataGridViewRow row in dgvSelectedQuotes.Rows)
            {

                if (dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() == row.Cells[0].Value.ToString())
                    validation = 0;


            }


            if (validation == -1)
                dgvSelectedQuotes.Rows.Add(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());

            dataGridView1.ClearSelection();
            dgvSelectedQuotes.ClearSelection();

        }

        private void btnAddChase_Click(object sender, EventArgs e)
        {
            int validation = 0;
            //check if any of the chases are marked as blue
               if (dgvSelectedQuotes.Rows.Count > 0)
                    validation++;
            

            if (validation == 0)
            {
                MessageBox.Show("Please select a quote before clicking add chase!", "Missing Quote", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //add the chase for each of these 
            for (int i = 0; i < dgvSelectedQuotes.Rows.Count; i++)
            {

                    //same as below
                    ///////// string sql = "SELECT CAST(quote_id as nvarchar(max)) FROM [order_database].dbo.quotation_feed_back WHERE quote_id = " + quote_dt.Rows[i][0].ToString();

                    using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand("[order_database].dbo.usp_quotation_chase_log_multiple_chase", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@quote_id", SqlDbType.Int).Value = Convert.ToInt32(quote_dt.Rows[i][0].ToString());
                            cmd.Parameters.AddWithValue("@description", SqlDbType.NVarChar).Value = description;
                            cmd.Parameters.AddWithValue("@date_next", SqlDbType.NVarChar).Value = dteNextDate;
                            cmd.Parameters.AddWithValue("@staff_id", SqlDbType.Int).Value = CONNECT.staffID;
                            cmd.Parameters.AddWithValue("@dont_chase", SqlDbType.Int).Value = dont_chase;
                            cmd.Parameters.AddWithValue("@email", SqlDbType.Int).Value = email;
                            cmd.Parameters.AddWithValue("@phone", SqlDbType.Int).Value = phone;
                            cmd.Parameters.AddWithValue("@chase_complete", SqlDbType.Int).Value = dont_chase;
                            cmd.Parameters.AddWithValue("@status", SqlDbType.NVarChar).Value = chase_status;
                            cmd.Parameters.AddWithValue("@failed_contact", SqlDbType.NVarChar).Value = failed_contact;
                            cmd.ExecuteNonQuery();
                        }

                        //old code that works for me and not jenny
                        ////////check if this already exists in quotation_feed_back (this is the main base table)
                        ////////using (SqlCommand cmd = new SqlCommand(sql, conn))
                        ////////{
                        ////////    string temp = (string)cmd.ExecuteScalar() ?? "0";

                        ////////    if (temp == "0")
                        ////////    {
                        ////////        //need to insert into dbo.quotation_feed_back
                        ////////        sql = "INSERT INTO [order_database].dbo.quotation_feed_back (quote_id,status) VALUES (" + quote_dt.Rows[i][0].ToString() + ",'Chasing')";
                        ////////        using (SqlCommand cmdInsert = new SqlCommand(sql, conn))
                        ////////        {
                        ////////            cmdInsert.ExecuteNonQuery();
                        ////////        }
                        ////////    }
                        ////////}

                        //////////now we insert the main string 
                        ////////sql = "INSERT INTO [order_database].dbo.quotation_chase_log (quote_id,chase_date,chase_description,next_chase_date,chased_by,dont_chase,email,phone,chase_complete) " +
                        ////////      "VALUES (" + quote_dt.Rows[i][0].ToString() + ",GETDATE(),'" + description + "','" + dteNextDate + "'," + CONNECT.staffID + ","
                        ////////      + dont_chase.ToString() + "," + email.ToString() + "," + phone.ToString() + "," + dont_chase.ToString() + ")";

                        ////////using (SqlCommand cmd = new SqlCommand(sql, conn))
                        ////////{
                        ////////    cmd.ExecuteNonQuery();
                        ////////}

                        conn.Close();
                    }
                
            }
            this.Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtQuote_TextChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void dgvSelectedQuotes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvSelectedQuotes.Rows.RemoveAt(e.RowIndex);
        }
    }
}
