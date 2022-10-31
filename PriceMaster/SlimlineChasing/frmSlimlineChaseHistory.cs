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
    public partial class frmSlimlineChaseHistory : Form
    {
        public frmSlimlineChaseHistory(int quote_id)
        {
            InitializeComponent();
            string sql = "select l.id,l.chase_date as [Chase Date],u.forename + ' ' + u.surname as [Full Name] from [order_database].dbo.quotation_chase_log_slimline  l " +
                "left join[user_info].dbo.[user] u on l.chased_by = u.id " +
                "where quote_id = " + quote_id.ToString() + " ORDER BY l.id desc";

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    foreach (DataGridViewColumn col in dataGridView1.Columns)
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[0].Visible = false;

                }
                conn.Close();
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmSlimlineChase frm = new frmSlimlineChase(0, -1, Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()));
            frm.ShowDialog();

        }

        private void frmChaseHistory_Shown(object sender, EventArgs e)
        {

        }
    }
}
