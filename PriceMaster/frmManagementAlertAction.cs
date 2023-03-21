using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PriceMaster
{
    public partial class frmManagementAlertAction : Form
    {
        public int alert_id { get; set; }
        public frmManagementAlertAction(int _alert_id, int alert_complete)
        {
            InitializeComponent();

            alert_id = _alert_id;

            if (alert_complete == -1)
            {
                //load the description and lock/hide the controls

                btnCancel.Text = "Close";  //used to close the new form
                btnCancel.Location = new Point(244, 365);

                btnComplete.Visible = false;

                chkComplete.Visible = true;
                chkComplete.Checked = true;

                txtDescription.ReadOnly = true;
                lblTitle.Text = "Resolution";

                //get the description
                using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                {
                    conn.Open();
                    string sql = "select alert_description from [order_database].dbo.quotation_chase_alert where id = " + alert_id.ToString();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        txtDescription.Text = cmd.ExecuteScalar().ToString();
                    }

                    conn.Close();
                }

            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            //check if the description has text
            txtDescription.Text = txtDescription.Text.Replace("'", "");
            if (txtDescription.Text.Length < 5)
            {
                MessageBox.Show("Please enter a more detailed note before completing this note");
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to save this alert description?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string sql = "update [order_database].dbo.quotation_chase_alert " +
                    "SET alert_description = '" + txtDescription.Text + "',alert_complete = -1," +
                    " alert_complete_by = " + CONNECT.staffID + ",alert_complete_date = GETDATE() WHERE id =  " + alert_id;

                using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                        cmd.ExecuteNonQuery();


                    conn.Close();
                }

                this.Close();
            }




        }
    }
}
