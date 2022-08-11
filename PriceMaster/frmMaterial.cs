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
    public partial class frmMaterial : Form
    {
        public frmMaterial()
        {
            InitializeComponent();
            loadData();
        }

        private void loadData()
        {
            //get suppliers
            string sql = "select material_description as [Material Description] from dbo.sl_material";
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
                    dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.ClearSelection();
                }
                conn.Close();
            }
        }

        private void frmMaterial_Shown(object sender, EventArgs e)
        {

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void buttonFormatting1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmNewMaterial frm = new frmNewMaterial();
            frm.ShowDialog();

            if (CONNECT.materialType == null)
            {

            }
            else
            {
                using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                {
                    conn.Open();
                    string sql = "INSERT INTO dbo.sl_material (material_description) VALUES ('" + CONNECT.materialType + "')";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        //MessageBox.Show(sql);
                        cmd.ExecuteNonQuery();
                        CONNECT.materialType = null;
                    }
                    conn.Close();
                    loadData();

                }
            }
        }
    }
}
