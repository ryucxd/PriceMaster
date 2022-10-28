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
        public frmOutstandingChase(int _admin)
        {
            InitializeComponent();
            admin = _admin;
            load_data();
            if (admin == -1)
                this.Text = "Admin Outstanding Chases";
        }

        private void format()
        {
            dataGridView1.Columns[id_index].Visible = false;
            dataGridView1.Columns[quote_index].HeaderText = "Quote ID";
            dataGridView1.Columns[chase_date_index].HeaderText = "Chase Date";
            dataGridView1.Columns[chase_description_index].HeaderText = "Chase Description";
            dataGridView1.Columns[next_chase_date_index].HeaderText = "Next Chase Date";

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
            string sql = "SELECT a.id,quote_id,chase_date,chase_description,next_chase_date,u.forename + ' ' + u.surname as chased_by " +
                "FROM[order_database].dbo.quotation_chase_log a " +
                "left join[user_info].dbo.[user] u on a.chased_by = u.id " +
                "where next_chase_date <= CAST(GETDATE() as date) ";

            if (admin == 0)
                sql = sql + "AND chased_by = " + CONNECT.staffID.ToString();

            sql = sql + " order by next_chase_date asc, quote_id ";
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
            chased_by_index = dataGridView1.Columns["chased_by"].Index;

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
    }
}
