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
using System.Web;

namespace PriceMaster
{
    public partial class frmManagementViewHistory : Form
    {
        public int slimline { get; set; }
        public frmManagementViewHistory(int quote_id,int _slimline,string customer)
        {
            InitializeComponent();
            LblCustomer.Text = customer;
            slimline = _slimline;
            string sql = "";
            if (slimline == -1)
            {
                sql = "select l.id,l.chase_date as [Chase Date],u.forename + ' ' + u.surname as [Full Name],CASE WHEN chase_complete = 0 THEN CAST(0 AS BIT) WHEN chase_complete IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Complete]  from [order_database].dbo.quotation_chase_log_slimline  l " +
                    "left join[user_info].dbo.[user] u on l.chased_by = u.id " +
                    "where quote_id = " + quote_id.ToString() + " ORDER BY l.id desc";
            }
            else
            {
                sql = "select l.id,l.chase_date as [Chase Date],u.forename + ' ' + u.surname as [Full Name],CASE WHEN chase_complete = 0 THEN CAST(0 AS BIT) WHEN chase_complete IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Complete]  from [order_database].dbo.quotation_chase_log  l " +
                    "left join[user_info].dbo.[user] u on l.chased_by = u.id " +
                    "where quote_id = " + quote_id.ToString() + " ORDER BY l.id desc";
            }

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
                    dataGridView1.Columns[3].ReadOnly = true;
                }
                conn.Close();
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            foreach (DataGridViewRow row in dataGridView1.Rows)
                row.DefaultCellStyle.BackColor = Color.Empty;

            dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSkyBlue;

            dataGridView1.ClearSelection();

            //chase id - Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            fillChase(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()));
            

        }

        
        private void fillChase(int chase_id)
        {
            dteChaseDate.Format = DateTimePickerFormat.Custom;
            dteChaseDate.CustomFormat = "dd/MM/yyyy hh:mm:ss";
            txtDescription.ReadOnly = true;
            dteNextDate.Enabled = false;
            chkEmail.Enabled = false;
            chkPhone.Enabled = false;

            //load data that was passed over
            string sql = "";

            if (slimline == -1)
                sql = "select chase_date,chase_description,next_chase_date, dont_chase,phone,email from [order_database].dbo.quotation_chase_log_slimline where id = " + chase_id.ToString();
            else
                sql = "select chase_date,chase_description,next_chase_date, dont_chase,phone,email from [order_database].dbo.quotation_chase_log where id = " + chase_id.ToString();

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dteChaseDate.Value = Convert.ToDateTime(dt.Rows[0][0].ToString());
                    txtDescription.Text = dt.Rows[0][1].ToString();
                    dteNextDate.Value = Convert.ToDateTime(dt.Rows[0][2].ToString());
                    if (dt.Rows[0][3].ToString() == "-1")
                    {
                        dteNextDate.Visible = false;
                        lblNext.Visible = false;
                        chkNoFollowup.Visible = true;
                        chkNoFollowup.Checked = true;
                        chkNoFollowup.AutoCheck = false;
                    }
                    else
                    {
                        chkNoFollowup.Visible = false;
                        dteNextDate.Visible = true;
                        lblNext.Visible = true;
                    }
                    if (dt.Rows[0][4].ToString() == "-1")
                        chkPhone.Checked = true;
                    if (dt.Rows[0][5].ToString() == "-1")
                        chkEmail.Checked = true;
                }

                conn.Close();
            }
        }

        private void frmChaseHistory_Shown(object sender, EventArgs e)
        {
            dataGridView1.Rows[0].DefaultCellStyle.BackColor = Color.LightSkyBlue;
            fillChase(Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value.ToString()));
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.ClearSelection();
        }
    }
}
