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

namespace PriceMaster.TraditionalChasing
{
    public partial class frmTraditionalLinkEnquiry : Form
    {
        public string quote_id { get; set; }
        public frmTraditionalLinkEnquiry(string _quote_id)
        {
            InitializeComponent();
            quote_id = _quote_id;
            lblTitle.Text = "Please enter the enquiry number that is related to quote: " + _quote_id;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //check if this is a legit enquiry
            string sql = "select id from EnquiryLog.dbo.[Enquiry_Log] where id = " + txtEnquiryID.Text;
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    var validation = cmd.ExecuteScalar();
                    if (validation == null)
                    {
                        MessageBox.Show("This enquiry ID does not exist.", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                //check if this enquiry already has a related quote
                sql = "select related_quote from EnquiryLog.dbo.[Enquiry_Log] where id = " + quote_id;
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    var validation = cmd.ExecuteScalar();
                    if (validation != null)
                    {
                        DialogResult result = MessageBox.Show("This enquiry is already linked to quote: " + validation.ToString() + ". Would you like to overwrite this?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.No)
                            return;
                    }
                }

                //update the enquiry
                sql = "UPDATE [EnquiryLog].dbo.enquiry_log SET related_quote = '" + quote_id + "',related_quote_by = " + CONNECT.staffID + ",related_quote_stamp = GETDATE() WHERE id = " + txtEnquiryID.Text;
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    cmd.ExecuteNonQuery();

                frmTraditionalEnquiryHistory frm = new frmTraditionalEnquiryHistory(quote_id);
                frm.ShowDialog();

                conn.Close();
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
