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
    public partial class frmLastCustomerEnquiry : Form
    {
        public string orderBy { get; set; }
        public frmLastCustomerEnquiry(int slimline)
        {
            InitializeComponent();

            orderBy = "max_recieved_time";

            if (slimline == -1)
                chkSlimline.Checked = true;

            

            load_grid();

        }



        private void load_grid()
        {
            string slimline_string = "";
            if (chkSlimline.Checked == true)
                slimline_string = " slimline_request = -1 ";
            else
                slimline_string = " (slimline_request = 0 or slimline_request  is null) ";

            string sql = "SELECT enquiry_id as [Enquiry ID],sender_email_address as [Email Address], subject as [Subject],items as [Quantity],max_recieved_time as [Recieved Time] FROM (" +
                "select max(enquiry_id) as enquiry_id,email_address,max(recieved_time) as max_recieved_time,SUM(price_qty_required) as items FROM (" +
                "select id as enquiry_id,SUBSTRING(sender_email_address,CHARINDEX('@',sender_email_address)+1,LEN(sender_email_address)) as email_address,sender_email_address,recieved_time,price_qty_required " +
                "FROM [EnquiryLog].dbo.Enquiry_Log  " +
                "WHERE sender_email_address NOT LIKE '%/O=EXCHANGELABS/OU=EXCHANGE ADMINISTRATIVE GROUP%' and " + slimline_string + 
                ") as email_substring group by email_address ) as email_grouped " +
                "left join [EnquiryLog].dbo.Enquiry_Log e on email_grouped.enquiry_id = e.id " +
                "where max_recieved_time < '" + dteDate.Value.ToString("yyyyMMdd") + "' " +
                "order by " + orderBy + " desc";

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql,conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }

                conn.Close();
                format();
            }
        }

        private void format()
        {
            foreach (DataGridViewColumn col in  dataGridView1.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.ClearSelection();
        }

        private void dteDate_CloseUp(object sender, EventArgs e)
        {
            load_grid();
        }

        private void chkSlimline_CheckedChanged(object sender, EventArgs e)
        {
            load_grid();
        }

        private void frmLastCustomerEnquiry_Shown(object sender, EventArgs e)
        {
            format();
        }

        private void btnEnquiry_Click(object sender, EventArgs e)
        {
            orderBy = "max_recieved_time";
            load_grid();
        }

        private void btnItems_Click(object sender, EventArgs e)
        {
            orderBy = "items";
            load_grid();
        }
    }
}
