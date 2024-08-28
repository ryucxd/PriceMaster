using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PriceMaster
{
    public partial class frmOutOfOffice : Form
    {
        public frmOutOfOffice()
        {
            InitializeComponent();

            string sql = "select distinct sales_member FROM [order_database].dbo.view_sales_table_grouped where sector_date = CAST(DATEADD(wk, DATEDIFF(wk,0,GETDATE()), 0) as date) ";

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
                        cmbStaff.Items.Add(row[0].ToString());
                    }



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
            txtReason.Text = txtReason.Text.Replace("'", "");


            if (txtReason.Text.Length < 3)
            {
                MessageBox.Show("Please enter a reason before clicking save.", "Missing Reason", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtHours.Text.Length < 1)
            {
                MessageBox.Show("Please enter a duration before clicking save.", "Missing Duration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbStaff.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a staff member before clicking save.", "Missing Staff", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }




            // insert this into 

            int staff_id = 260;
            string sql = "select top 1 sales_member_id FROM [order_database].dbo.view_sales_table_grouped " +
                "where sector_date = CAST(DATEADD(wk, DATEDIFF(wk,0,GETDATE()), 0) as date) AND sales_member = '" + cmbStaff.Text + "'";

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    staff_id = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                

                sql = "insert into [order_database].dbo.sales_table_out_of_office " +
                    "(target_date," +
                    "out_of_office_date," +
                    "out_of_office_reason," +
                    "out_of_office_duration," +
                    "out_of_office_staff," +
                    "date_added," +
                    "added_by) " +
                    "VALUES (CAST(DATEADD(wk, DATEDIFF(wk,0,GETDATE()), 0) as date),'" + dteDate.Value.ToString("yyyyMMdd") + "'," +
                    "'" + txtReason.Text + "'," + txtHours.Text + "," + staff_id + ",GETDATE()," + CONNECT.staffID + ") ";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    cmd.ExecuteNonQuery();


                conn.Close();
            }
            this.Close();
        }

        private void txtHours_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
