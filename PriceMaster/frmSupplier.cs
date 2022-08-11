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
    public partial class frmSupplier : Form
    {
        public frmSupplier()
        {
            InitializeComponent();
            loadData();
        }

        private void loadData()
        {
            //get suppliers
            string sql = "SELECT company_name as [Company Name],company_email as [Company Email],company_contact as [Company Contact],CASE WHEN exclude_yn = 0 THEN CAST(0 AS BIT) WHEN exclude_yn IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS Exclude  FROM dbo.sl_material_suppliers";
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = null;
                    dataGridView1.Rows.Clear();
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.ClearSelection();
                }
                conn.Close();
            }
        }

        private void frmSupplier_Shown(object sender, EventArgs e)
        {

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int value = 0;
            if (Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[3].Value) == false)
                value = -1;
            else
                value = 0;

            if (e.ColumnIndex == 3)
            {
                using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                {
                    conn.Open();
                    string sql = "UPDATE dbo.sl_material_suppliers SET exclude_yn = " + value + " WHERE company_name = '" + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() + "'";
                    using (SqlCommand cmd = new SqlCommand(sql,conn))
                    {
                        //MessageBox.Show(sql);
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                    loadData();
                    
                }
            }
        }
    }
}
