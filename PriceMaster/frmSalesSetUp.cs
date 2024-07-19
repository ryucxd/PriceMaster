using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PriceMaster
{
    public partial class frmSalesSetUp : Form
    {

        public List<string> salesMemberList { get; set; }
        public frmSalesSetUp()
        {
            InitializeComponent();

            salesMemberList = new List<string>();
            load_grid();

        }


        private void load_grid()
        {

            string sql = "select forename + ' ' + surname FROM [user_info].dbo.[user] " +
                "where [current] = 1 and (actual_department like '%Estimating%' or job_title = 'DSL') and (non_user = 0 or non_user is null)" +
                "order by forename";

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                        salesMemberList.Add(row[0].ToString());
                }


                sql = "select s.id,Sector," +
                      "u_one.forename + ' ' + u_one.surname as [Sales Member One],sales_member_one_target as [Target]," +
                      "u_two.forename + ' ' + u_two.surname as [Sales Member Two],sales_member_two_target as [Target ]," +
                      "u_three.forename + ' ' + u_three.surname as [Sales Member Three],sales_member_three_target as [ Target] " +
                      "FROM[order_database].dbo.sales_master_table s " +
                      "left join[user_info].dbo.[user] u_one on s.sales_member_one = u_one.id " +
                      "left join[user_info].dbo.[user] u_two on s.sales_member_two = u_two.id " +
                      "left join[user_info].dbo.[user] u_three on s.sales_member_three = u_three.id " +
                      "order by u_one.forename + ' ' + u_one.surname";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dgvSalesSetUp.DataSource = dt;



                    format_sales();

                   


                }



                conn.Close();
            }

        }

        private void format_sales()
        {

            foreach(DataGridViewColumn col in dgvSalesSetUp.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgvSalesSetUp.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvSalesSetUp.Columns[0].Visible = false;

            dgvSalesSetUp.Columns[3].Width = 35;
            dgvSalesSetUp.Columns[5].Width = 35;
            dgvSalesSetUp.Columns[7].Width = 35;

        }

        private void dgvSalesSetUp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            frmSalesUpdate frm = new frmSalesUpdate(Convert.ToInt32(dgvSalesSetUp.Rows[e.RowIndex].Cells[0].Value),salesMemberList);
            frm.ShowDialog();

            load_grid();


        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmSalesUpdate frm = new frmSalesUpdate(-1, salesMemberList);
            frm.ShowDialog();

           load_grid();
        }
    }
}
