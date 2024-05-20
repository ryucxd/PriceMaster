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
        public int first_enquiry { get; set; }
        public frmLastCustomerEnquiry(int slimline)
        {
            InitializeComponent();

            first_enquiry = 0;
            if (first_enquiry == 0) //set it to the first enquiry filter
            {
                label1.Text = "Non Returning Customers";
                btnToggle.Text = "Change to First Enquiry";
                btnEnquiry.Text = "Last Enquiry";
                orderBy = "max_recieved_time";
            }
            else
            {
                label1.Text = "New Customers";
                btnToggle.Text = "Change to Last Enquiry";
                btnEnquiry.Text = "First Enquiry";
                orderBy = "recieved_time";

            }

            dteStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);


            if (slimline == -1)
                chkSlimline.Checked = true;



            load_grid();
            this.first_enquiry = first_enquiry;
        }



        private void load_grid()
        {
            string sql = "";
            string slimline_string = "";
            if (chkSlimline.Checked == true)
                slimline_string = " slimline_request = -1 ";
            else
                slimline_string = " (slimline_request = 0 or slimline_request  is null) ";
            if (first_enquiry == 0)
            {
                sql = "SELECT enquiry_id as [Enquiry ID],sender_email_address as [Email Address], subject as [Subject],items as [Quantity],max_recieved_time as [Recieved Time] FROM (" +
                   "select max(enquiry_id) as enquiry_id,email_address,max(recieved_time) as max_recieved_time,SUM(price_qty_required) as items FROM (" +
                   "select id as enquiry_id,SUBSTRING(sender_email_address,CHARINDEX('@',sender_email_address)+1,LEN(sender_email_address)) as email_address,sender_email_address,recieved_time,price_qty_required " +
                   "FROM [EnquiryLog].dbo.Enquiry_Log  " +
                   "WHERE sender_email_address NOT LIKE '%/O=EXCHANGELABS/OU=EXCHANGE ADMINISTRATIVE GROUP%' and " + slimline_string +
                   ") as email_substring group by email_address ) as email_grouped " +
                   "left join [EnquiryLog].dbo.Enquiry_Log e on email_grouped.enquiry_id = e.id " +
                   "where max_recieved_time >= '" + dteStart.Value.ToString("yyyyMMdd") + "' and  max_recieved_time <= '" + dteDate.Value.ToString("yyyyMMdd") + "' " +
                   "order by " + orderBy + " desc";
            }
            else
            {
                sql = "SELECT min_id as [Enquiry ID],REPLACE((REPLACE(customer,'.co.uk','')),'.com','') as [Email Address], " +
                    "subject as [Subject],price_qty_required as [Quantity], " +
                    "recieved_time as [Recieved Time] FROM [EnquiryLog].dbo.Enquiry_Log e " +
                    "right join (select min(id) min_id,right(sender_email_address, " +
                    "charindex('@', reverse(sender_email_address)) -1 ) as customer " +
                    "FROM [EnquiryLog].dbo.Enquiry_Log " +
                    "where sender_email_address LIKE '%@%'  and " + slimline_string +
                    " group by right(sender_email_address, charindex('@', reverse(sender_email_address)) -1 ) ) as grouped on e.id = grouped.min_id " +
                    "where recieved_time >= '" + dteStart.Value.ToString("yyyyMMdd") + "' and recieved_time <= '" + dteDate.Value.ToString("yyyyMMdd") + "' " +
                    "order by " + orderBy + " desc";
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
                }

                conn.Close();
                format();
            }
        }

        private void format()
        {
            foreach (DataGridViewColumn col in dataGridView1.Columns)
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
            if (first_enquiry == 0)
                orderBy = "max_recieved_time";
            else
                orderBy = "recieved_time";
            load_grid();
        }

        private void btnItems_Click(object sender, EventArgs e)
        {
            if (first_enquiry == 0)
                orderBy = "items";
            else
                orderBy = "price_qty_required";
            load_grid();
        }

        private void btnToggle_Click(object sender, EventArgs e)
        {
            if (first_enquiry == 0) //set it to the first enquiry filter
            {
                first_enquiry = -1;
                label1.Text = "New Customers";
                btnToggle.Text = "Change to Last Enquiry";
                btnEnquiry.Text = "First Enquiry";
                orderBy = "recieved_time";
            }
            else
            {
                first_enquiry = 0;
                btnToggle.Text = "Change to First Enquiry";
                btnEnquiry.Text = "Last Enquiry";
                orderBy = "max_recieved_time";
                label1.Text = "Non Returning Customers";
            }
            load_grid();
        }

        private void dteStart_CloseUp(object sender, EventArgs e)
        {
            load_grid();
        }
    }
}
