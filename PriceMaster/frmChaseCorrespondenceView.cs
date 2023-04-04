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
    public partial class frmChaseCorrespondenceView : Form
    {
        public int correspondence_id { get; set; }
        public int slimline { get; set; }
        public int view_mode { get; set; }
        public string customer { get; set; }
        public frmChaseCorrespondenceView(int id, int _slimline, int _view_mode)
        {
            InitializeComponent();
            correspondence_id = id;
            slimline = _slimline;
            view_mode = _view_mode;
            load_data();
            load_history();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
        }

        private void load_history()
        {
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                string sql = "SELECT c.id,date_created,u.forename + ' ' + u.surname as fullname, " +
                    "CASE WHEN complete = 0 THEN CAST(0 AS BIT) WHEN complete IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Complete] " +
                    "FROM [order_database].dbo.quotation_chase_customer c " +
                    "left join [user_info].dbo.[user] u on c.correspondence_by = u.id " +
                    "where " + /*next_correspondence_date <= GETDATE() and no_follow_up = 0 "  AND " +*/
                    "c.slimline = " + slimline + " AND c.customer_name = '" + customer + "' ORDER BY next_correspondence_date desc,date_created desc"; //AND  correspondence_by = " + CONNECT.staffID.ToString() + " " +


                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;

                    foreach (DataGridViewColumn col in dataGridView1.Columns)
                    {
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        col.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].HeaderText = "Date Created";
                    dataGridView1.Columns[2].HeaderText = "Correspondence by";
                }




                conn.Close();
            }
        }


        private void load_data()
        {

            string sql = "SELECT " +
                "[customer_name],[date_created],[body],[email],[phone],[inPerson],[contact],[issue_with_leadtime],[issue_with_quote_turnaround_time]" +
                ",[issue_with_product],[issue_with_installation],[issue_with_service],correspondence_by,next_correspondence_date,no_follow_up,COMPLETE FROM  [order_database].[dbo].[quotation_chase_customer] " +
                "WHERE id = " + correspondence_id.ToString();

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    lblTitle.Text = dt.Rows[0][0].ToString() + " - " + dt.Rows[0][1].ToString();
                    customer = dt.Rows[0][0].ToString();
                    txtDescription.Text = dt.Rows[0][2].ToString();
                    //phone email in person checkboxes
                    if (dt.Rows[0][3].ToString() == "-1")
                        chkPhone.Checked = true;
                    if (dt.Rows[0][4].ToString() == "-1")
                        chkEmail.Checked = true;
                    if (dt.Rows[0][5].ToString() == "-1")
                        chkInPerson.Checked = true;
                    txtContact.Text = dt.Rows[0][6].ToString();
                    //issues with etc
                    if (dt.Rows[0][7].ToString() == "-1")
                        chkLeadtime.Checked = true;
                    if (dt.Rows[0][8].ToString() == "-1")
                        chkTurnaround.Checked = true;
                    if (dt.Rows[0][9].ToString() == "-1")
                        chkProduct.Checked = true;
                    if (dt.Rows[0][10].ToString() == "-1")
                        chkInstallation.Checked = true;
                    if (dt.Rows[0][11].ToString() == "-1")
                        chkService.Checked = true;

                    if (dt.Rows[0][14].ToString() == "-1")
                    {
                        chkFollowUp.Checked = true;
                        dteNextDate.Visible = false;
                    }
                    else
                    {
                        chkFollowUp.Visible = false;
                        if (string.IsNullOrEmpty(dt.Rows[0][13].ToString()) == false)
                            dteNextDate.Value = Convert.ToDateTime(Convert.ToDateTime(dt.Rows[0][13].ToString()));
                    }



                    //here we need to check IF its complete, and if it is then we need to enable the complete button
                    if (view_mode == 0)
                    {
                        if (dt.Rows[0][15].ToString() == "-1")
                        {
                            ///this correspondence IS complete
                            btnComplete.Visible = false;
                            btnCancel.Location = new Point(237, 464);
                        }
                        else
                        {
                            ///this correspondence IS NOT complete
                            btnComplete.Visible = true;
                            btnCancel.Location = new Point(145, 464);
                        }
                    }
                    else
                    {
                        btnComplete.Visible = false;
                        btnCancel.Location = new Point(237, 464);
                    }
                }
            }
        }

        private void frmChaseCorrespondenceView_Shown(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            //quickly loop through history grid and then highlight the one that matches the id
            foreach (DataGridViewRow row in dataGridView1.Rows)
                if (Convert.ToInt32(row.Cells[0].Value) == correspondence_id)
                    row.Selected = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            correspondence_id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            load_data();
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            //update this corresponence to complete

            string sql = "UPDATE [order_database].[dbo].[quotation_chase_customer] SET complete = -1 WHERE id = " + correspondence_id;

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    cmd.ExecuteNonQuery();

                conn.Close();
            }

            load_history();

            dataGridView1.ClearSelection();
            foreach (DataGridViewRow row in dataGridView1.Rows)
                if (Convert.ToInt32(row.Cells[0].Value) == correspondence_id)
                    row.Selected = true;

            btnComplete.Visible = false;
            btnCancel.Location = new Point(237, 464);
        }
    }
}
