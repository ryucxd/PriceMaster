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
    public partial class frmSalesUpdate : Form
    {

        public int sector_id { get; set; }
        public int insert { get; set; }

        public frmSalesUpdate(int id, List<string> salesMembers)
        {
            InitializeComponent();

            sector_id = id;


            if (sector_id == -1)
                btnDelete.Visible = false;

            foreach (var item in salesMembers)
            {
                cmbSalesOne.Items.Add(item);
                cmbSalesTwo.Items.Add(item);
                cmbSalesThree.Items.Add(item);
            }


            if (sector_id > -1)
            {
                //load the note and who is in each spot
                string sql = "select sector," +
                    "u_one.forename + ' ' + u_one.surname as sales_member_one,sales_member_one_target," +
                    "u_two.forename + ' ' + u_two.surname as sales_member_two,sales_member_two_target," +
                    "u_three.forename + ' ' + u_three.surname as sales_member_three,sales_member_three_target " +
                    "FROM [order_database].dbo.sales_master_table s " +
                    "left join [user_info].dbo.[user] u_one on s.sales_member_one = u_one.id " +
                    "left join [user_info].dbo.[user] u_two on s.sales_member_two = u_two.id " +
                    "left join [user_info].dbo.[user] u_three on s.sales_member_three = u_three.id " +
                    "where s.id = " + sector_id.ToString();

                using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        txtSectorNote.Text = dt.Rows[0][0].ToString();
                        cmbSalesOne.Text = dt.Rows[0][1].ToString();
                        txtTargetOne.Text = dt.Rows[0][2].ToString();

                        cmbSalesTwo.Text = dt.Rows[0][3].ToString();
                        txtTargetTwo.Text = dt.Rows[0][4].ToString();

                        cmbSalesThree.Text = dt.Rows[0][5].ToString();
                        txtTargetThree.Text = dt.Rows[0][6].ToString();
                    }


                    //if this is a permanent sector dont delete (quotation_chasing)
                    sql = "select permanent_sector FROM [order_database].dbo.[sales_master_table] where id = " + sector_id;
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        var temp = cmd.ExecuteScalar();
                        if (temp != null)
                            if (temp.ToString() == "-1")
                            {
                                btnDelete.Visible = false;
                                txtSectorNote.ReadOnly = true;
                            }
                    }


                        conn.Close();
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            //error checking 
            txtSectorNote.Text = txtSectorNote.Text.Replace("'", "");

            //combobox
            if (cmbSalesOne.SelectedIndex > -1)
            {
                if (isNumber(txtTargetOne.Text, "One") == 0)
                    return;
            }
            if (cmbSalesTwo.SelectedIndex > -1)
            {
                if (isNumber(txtTargetTwo.Text, "Two") == 0)
                    return;
            }
            if (cmbSalesThree.SelectedIndex > -1)
            {
                if (isNumber(txtTargetThree.Text, "Three") == 0)
                    return;
            }

            //textbox
            if (txtSectorNote.Text.Length < 3)
            {
                MessageBox.Show("Please enter a sector before clicking save!", "Missing Sector", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (check_existing_sector() == 0)
                return;


            //update OR insert 
            string sql = "";
            string sql_start = "";
            string sql_end = "";

            if (sector_id == -1) //insert
            {
                sql_start = "insert into [order_database].dbo.[sales_master_table] (sector";
                sql_end = " VALUES ('" + txtSectorNote.Text + "' ";
                //one
                if (cmbSalesOne.SelectedIndex > -1)
                {
                    sql_start += ",sales_member_one,sales_member_one_target";
                    sql_end += "," + staff_id(cmbSalesOne.Text) + "," + txtTargetOne.Text;
                }
                //two
                if (cmbSalesTwo.SelectedIndex > -1)
                {
                    sql_start += ",sales_member_two,sales_member_two_target";
                    sql_end += "," + staff_id(cmbSalesTwo.Text) + "," + txtTargetTwo.Text;
                }
                //three
                if (cmbSalesThree.SelectedIndex > -1)
                {
                    sql_start += ",sales_member_three,sales_member_three_target";
                    sql_end += "," + staff_id(cmbSalesThree.Text) + "," + txtTargetThree.Text;
                }

                sql_start += ")";
                sql_end += ")";
                sql = sql_start + " " + sql_end;
            }
            else
            {
                sql = "update [order_database].dbo.[sales_master_table] SET sector = '" + txtSectorNote.Text + "' ";

                //one
                if (cmbSalesOne.SelectedIndex > -1)
                    sql += ",sales_member_one = " + staff_id(cmbSalesOne.Text) + ",sales_member_one_target = " + txtTargetOne.Text + " ";
                else
                    sql += ",sales_member_one = NULL ,sales_member_one_target = NULL ";

                //two
                if (cmbSalesTwo.SelectedIndex > -1)
                    sql += ",sales_member_two = " + staff_id(cmbSalesTwo.Text) + ",sales_member_two_target = " + txtTargetTwo.Text + " ";
                else
                    sql += ",sales_member_two = NULL,sales_member_two_target = NULL ";

                //three
                if (cmbSalesThree.SelectedIndex > -1)
                    sql += ",sales_member_three = " + staff_id(cmbSalesThree.Text) + ",sales_member_three_target = " + txtTargetThree.Text + " ";
                else
                    sql += ",sales_member_three = NULL, sales_member_three_target = NULL ";



                sql += " WHERE id = " + sector_id.ToString();
            }

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    cmd.ExecuteNonQuery();

                conn.Close();
            }

            this.Close();


        }

        private int staff_id(string fullName)
        {
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                string sql = "SELECT id FROM [user_info].dbo.[user] WHERE forename + ' ' + surname = '" + fullName + "'";



                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
                conn.Close();

            }
        }

        private int check_existing_sector()
        {

            string sql = "SELECT sector FROM [order_database].dbo.sales_master_table where sector = '" + txtSectorNote.Text + "'";

            if (sector_id != -1)
                sql += "and id <> " + sector_id.ToString();

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    var temp = cmd.ExecuteScalar();
                    conn.Close();
                    if (temp != null)
                    {
                        MessageBox.Show("This sector already exists, please enter something else!", "Sector Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return 0;
                    }
                    else
                        return -1;
                }


            }

        }


        private int isNumber(string text, string comboboxNumber)
        {

            if (text == null || text.Length == 0)
            {
                MessageBox.Show("Please enter a target for Sales Member " + comboboxNumber + " before clicking save.", "Missing Sales Target", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            try
            {
                int number = Convert.ToInt32(text);
                return -1;
            }
            catch
            {
                MessageBox.Show("Please enter a target for Sales Member " + comboboxNumber + " before clicking save.", "Missing Sales Target", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }



        }



        private void txtTargetOne_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTargetTwo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTargetThree_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnClearOne_Click(object sender, EventArgs e)
        {
            cmbSalesOne.SelectedIndex = -1;
            txtTargetOne.Text = "";
        }

        private void btnClearTwo_Click(object sender, EventArgs e)
        {
            cmbSalesTwo.SelectedIndex = -1;
            txtTargetTwo.Text = "";
        }

        private void btnClearThree_Click(object sender, EventArgs e)
        {
            cmbSalesThree.SelectedIndex = -1;
            txtTargetThree.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("ARE YOU SURE YOU WANT TO DELETE THIS SECTOR? THIS IS CAN NOT BE UNDONE", "Delete Sector", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
            if (result == DialogResult.Yes)
            {
                string sql = " delete from [order_database].dbo.sales_master_table where id = " + sector_id;

                using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                        cmd.ExecuteNonQuery();
                    conn.Close();

                    this.Close();
                }
            }
        }
    }
}
