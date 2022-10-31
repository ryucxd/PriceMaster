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
    public partial class frmSlimlineChase : Form
    {
        public int quote_id { get; set; }
        public frmSlimlineChase(int _quote_id, int view_mode, int chase_id)
        {
            InitializeComponent();
            quote_id = _quote_id;
            dteChaseDate.Format = DateTimePickerFormat.Custom;
            dteChaseDate.CustomFormat = "dd/MM/yyyy";
            dteNextDate.Format = DateTimePickerFormat.Custom;
            dteNextDate.CustomFormat = "dd/MM/yyyy";
            loadHistory();

            if (view_mode == -1)
                load_data(chase_id);
        }
        private void load_data(int id)
        {
            this.Size = new Size(565, 411);
            dteChaseDate.Format = DateTimePickerFormat.Custom;
            dteChaseDate.CustomFormat = "dd/MM/yyyy hh:mm:ss";
            txtDescription.ReadOnly = true;
            dteNextDate.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Text = "Close";

            //load data that was passed over
            string sql = "select chase_date,chase_description,next_chase_date, dont_chase from [order_database].dbo.quotation_chase_log_slimline where id = " + id.ToString();

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
                        chkNoFollowup.Visible = false;
                        chkHiddenFollowup.Visible = true;
                        chkHiddenFollowup.Checked = true;
                        chkHiddenFollowup.AutoCheck = false;
                    }
                    btnSave.Visible = false;
                    btnCancel.Location = new Point(215, 334);
                }

                conn.Close();
            }
        }


        private void loadHistory()
        {

            

           string  sql = "select l.id,l.chase_date as [Chase Date],u.forename + ' ' + u.surname as [Full Name] from [order_database].dbo.quotation_chase_log_slimline  l " +
                "left join[user_info].dbo.[user] u on l.chased_by = u.id " +
                "where quote_id = " + quote_id.ToString() + " ORDER BY l.id desc";

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    if (dataGridView1.Rows.Count > 0)
                    {
                        foreach (DataGridViewColumn col in dataGridView1.Columns)
                            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dataGridView1.Columns[0].Visible = false;
                    }
                    else
                        this.Size = new Size(565, 411);
                }
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDescription.Text.Length < 2)
            {
                MessageBox.Show("Please enter a full description before saving the chase!");
                return;
            }

            txtDescription.Text = txtDescription.Text.Replace("'", "");

            int dont_chase = 0;
            if (chkNoFollowup.Checked == true)
                dont_chase = -1;

            string sql = "INSERT INTO [order_database].dbo.quotation_chase_log_slimline (quote_id,chase_date,chase_description,next_chase_date,chased_by,dont_chase) " +
                "VALUES (" + quote_id + ",GETDATE(),'" + txtDescription.Text + "','" + dteNextDate.Value.ToString("yyyyMMdd") + "'," + CONNECT.staffID + "," + dont_chase.ToString() + ")";
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    cmd.ExecuteNonQuery();
                conn.Close();

                //also update the status to chasing >> incase they forgot 
                frmTraditionalChaseUpdate frm = new frmTraditionalChaseUpdate(quote_id);
                frm.ShowDialog();
                MessageBox.Show("Chase updated!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            frmTraditionalChase frm = new frmTraditionalChase(0, -1, Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()));
            frm.ShowDialog();
        }

        private void chkNoFollowup_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNoFollowup.Checked == true)
                dteNextDate.Enabled = false;
            else
                dteNextDate.Enabled = true;
        }
    }
}
