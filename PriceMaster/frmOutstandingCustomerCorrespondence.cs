using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PriceMaster
{
    public partial class frmOutstandingCustomerCorrespondence : Form
    {

        public int id_index { get; set; }
        public int customer_index { get; set; }
        public int date_created_index { get; set; }
        public int email_index { get; set; }
        public int phone_index { get; set; }
        public int in_person_index { get; set; }
        public int contact_index { get; set; }
        public int body_index { get; set; }
        public int next_correspondence_index { get; set; }
        public int complete_index { get; set; }

        public int slimline { get; set; }
        public int future_selected { get; set; }
        public frmOutstandingCustomerCorrespondence(int _slimline)
        {
            InitializeComponent();
            load_data();
            fillCombo();
            slimline = _slimline;
            future_selected = 0;
        }

        private void load_data()
        {
            string sql = "SELECT id,customer_name,date_created," +
                "CASE WHEN email = 0 THEN CAST(0 AS BIT) WHEN email IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Email] ," +
                "CASE WHEN phone = 0 THEN CAST(0 AS BIT) WHEN phone IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Phone] ," +
                "CASE WHEN inPerson = 0 THEN CAST(0 AS BIT) WHEN inPerson IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [inPerson]," +
                "contact,body, next_correspondence_date, " +
                "CASE WHEN complete = 0 THEN CAST(0 AS BIT) WHEN complete IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Complete]" +
                "FROM [order_database].dbo.quotation_chase_customer " +
                "where no_follow_up = 0 AND (complete = 0 or complete is null) AND " +
                "slimline = " + slimline + " AND " +
                "correspondence_by = " + CONNECT.staffID.ToString() + " AND next_correspondence_date ";


            if (future_selected == -1)
                sql = sql + " > ";
            else
                sql = sql + " <= ";
            sql = sql + "GETDATE() ";

            if (cmbCustomerSearch.Text.Length > 0)
                sql = sql + " AND customer_name = '" + cmbCustomerSearch.Text + "' ";

            sql = sql + " ORDER BY next_correspondence_date desc,date_created desc";

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvCorrespondence.DataSource = dt;
                }
                column_index();
                format();

                conn.Close();
            }
        }

        private void column_index()
        {
            id_index = dgvCorrespondence.Columns["id"].Index;
            customer_index = dgvCorrespondence.Columns["customer_name"].Index;
            date_created_index = dgvCorrespondence.Columns["date_created"].Index;
            email_index = dgvCorrespondence.Columns["Email"].Index;
            phone_index = dgvCorrespondence.Columns["Phone"].Index;
            in_person_index = dgvCorrespondence.Columns["inPerson"].Index;
            contact_index = dgvCorrespondence.Columns["contact"].Index;
            body_index = dgvCorrespondence.Columns["body"].Index;
            next_correspondence_index = dgvCorrespondence.Columns["next_correspondence_date"].Index;
            complete_index = dgvCorrespondence.Columns["complete"].Index;
        }

        private void format()
        {
            dgvCorrespondence.Columns[id_index].Visible = false;
            dgvCorrespondence.Columns[customer_index].HeaderText = "Customer";
            dgvCorrespondence.Columns[date_created_index].HeaderText = "Date Created";
            //email / phone already has decent header texts
            dgvCorrespondence.Columns[in_person_index].HeaderText = "In Person";
            dgvCorrespondence.Columns[contact_index].HeaderText = "Contact";
            dgvCorrespondence.Columns[body_index].HeaderText = "Body";
            dgvCorrespondence.Columns[next_correspondence_index].HeaderText = "Next Corresponednce";

            foreach (DataGridViewColumn col in dgvCorrespondence.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dgvCorrespondence.Columns[body_index].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void dgvCorrespondence_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmChaseCorrespondenceView frm = new frmChaseCorrespondenceView(Convert.ToInt32(dgvCorrespondence.Rows[e.RowIndex].Cells[id_index].Value), slimline, 0);
            frm.ShowDialog();

            load_data();
        }

        private void fillCombo()
        {

            //load all the data into the customers
            foreach (DataGridViewRow row in dgvCorrespondence.Rows)
            {
                if (cmbCustomerSearch.Items.Contains(row.Cells[customer_index].Value.ToString()))
                { } //nothing
                else
                    cmbCustomerSearch.Items.Add(row.Cells[customer_index].Value.ToString());
            }
        }

        private void cmbCustomerSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_data();
        }

        private void cmbCustomerSearch_TextChanged(object sender, EventArgs e)
        {
            load_data();
        }

        private void chkFuture_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFuture.Checked == true)
                future_selected = -1;
            else
                future_selected = 0;

            cmbCustomerSearch.Text = "";
            load_data();
            cmbCustomerSearch.Items.Clear();
            fillCombo();
        }
    }
}
