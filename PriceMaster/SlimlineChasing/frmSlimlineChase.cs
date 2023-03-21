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
            chkEmail.Enabled = false;
            chkPhone.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Text = "Close";

            //load data that was passed over
            string sql = "select chase_date,chase_description,next_chase_date, dont_chase,phone,email from [order_database].dbo.quotation_chase_log_slimline where id = " + id.ToString();

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
                    else
                    {
                        chkNoFollowup.Visible = false;
                    }
                    if (dt.Rows[0][4].ToString() == "-1")
                        chkPhone.Checked = true;
                    if (dt.Rows[0][5].ToString() == "-1")
                        chkEmail.Checked = true;   
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

            int validation = 0;
            int phone = 0;
            int email = 0;
            if (chkEmail.Checked == true)
            {
                validation = -1;
                email = -1;
            }
            if (chkPhone.Checked == true)
            {
                validation = -1;
                phone = -1; 
            }

            if (validation == 0)
            {
                MessageBox.Show("Please select either email or phone before saving this chase.","Chase Method",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtDescription.Text = txtDescription.Text.Replace("'", "");

            int dont_chase = 0;
            if (chkNoFollowup.Checked == true)
                dont_chase = -1;


            //also mark all previous chases as complete - toms idea
            string sql = "UPDATE [order_database].dbo.quotation_chase_log_slimline SET chase_complete = -1 where quote_id = " + quote_id.ToString();
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    cmd.ExecuteNonQuery();

                sql = "INSERT INTO [order_database].dbo.quotation_chase_log_slimline (quote_id,chase_date,chase_description,next_chase_date,chased_by,dont_chase,email,phone,chase_complete) " +
                "VALUES (" + quote_id + ",GETDATE(),'" + txtDescription.Text + "','" + dteNextDate.Value.ToString("yyyyMMdd") + "'," + CONNECT.staffID + "," + dont_chase.ToString() + "," + email.ToString() + "," + phone.ToString() + "," + dont_chase.ToString() + ")";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    cmd.ExecuteNonQuery();

                conn.Close();

                //also update the status to chasing >> incase they forgot 
                frmSlimlineChaseUpdate frm = new frmSlimlineChaseUpdate(quote_id);
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
            frmSlimlineChase frm = new frmSlimlineChase(0, -1, Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()));
            frm.ShowDialog();
        }

        private void chkNoFollowup_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNoFollowup.Checked == true)
                dteNextDate.Enabled = false;
            else
                dteNextDate.Enabled = true;
        }

        private void btnSaveManagement_Click(object sender, EventArgs e)
        {
            if (txtDescription.Text.Length < 2)
            {
                MessageBox.Show("Please enter a full description before saving the chase!");
                return;
            }

            int validation = 0;
            int phone = 0;
            int email = 0;
            if (chkEmail.Checked == true)
            {
                validation = -1;
                email = -1;
            }
            if (chkPhone.Checked == true)
            {
                validation = -1;
                phone = -1;
            }

            if (validation == 0)
            {
                MessageBox.Show("Please select either email or phone before saving this chase.", "Chase Method", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtDescription.Text = txtDescription.Text.Replace("'", "");

            int dont_chase = 0;
            if (chkNoFollowup.Checked == true)
                dont_chase = -1;


            //also mark all previous chases as complete - toms idea
            string sql = "UPDATE [order_database].dbo.quotation_chase_log_slimline SET chase_complete = -1 where quote_id = " + quote_id.ToString();
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    cmd.ExecuteNonQuery();

                sql = "INSERT INTO [order_database].dbo.quotation_chase_log_slimline (quote_id,chase_date,chase_description,next_chase_date,chased_by,dont_chase,email,phone,chase_complete) " +
                "VALUES (" + quote_id + ",GETDATE(),'" + txtDescription.Text + "','" + dteNextDate.Value.ToString("yyyyMMdd") + "'," + CONNECT.staffID + "," + dont_chase.ToString() + "," + email.ToString() + "," + phone.ToString() + "," + dont_chase.ToString() + ")";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    cmd.ExecuteNonQuery();


                //now we alert the manager
                using (SqlCommand cmd = new SqlCommand("[order_database].dbo.usp_quotation_chase_alert", conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@quote_id", SqlDbType.Int).Value = (quote_id);
                    cmd.Parameters.AddWithValue("@slimline", SqlDbType.Int).Value = (-1);
                    cmd.ExecuteNonQuery();
                }



                conn.Close();

                //also update the status to chasing >> incase they forgot 
                frmSlimlineChaseUpdate frm = new frmSlimlineChaseUpdate(quote_id);
                frm.ShowDialog();
                MessageBox.Show("Chase updated!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
