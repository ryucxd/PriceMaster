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

namespace PriceMaster.TraditionalChasing
{
    public partial class frmTraditionalEditChase : Form
    {
        public int chase_id { get; set; }
        public int MyProperty { get; set; }
        public frmTraditionalEditChase(int _chase_id,DateTime _next_chase)
        {
            InitializeComponent();
            chase_id = _chase_id;
            dteNextChase.Value = _next_chase;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //dont let them select a day before today
            if (dteNextChase.Value < DateTime.Today)
            {
                MessageBox.Show("You cannot select a 'Next Chase Date' that is in the past, please select another date.","Invalid chase date",MessageBoxButtons.OK,MessageBoxIcon.Question);
                return;
            }

            string sql = "UPDATE [order_database].dbo.quotation_chase_log SET next_chase_date = '" + dteNextChase.Value.ToString("yyyyMMdd") + "' where id =  " + chase_id.ToString();
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            this.Close();

        }
    }
}
