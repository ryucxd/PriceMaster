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
using System.Diagnostics;
using System.IO;
using System.Drawing.Printing;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace PriceMaster
{
    public partial class frmManagementViewHistory : Form
    {
        public int slimline { get; set; }
        public int quote_chase_id { get; set; }
        public frmManagementViewHistory(int quote_id, int _slimline, string customer)
        {
            InitializeComponent();
            LblCustomer.Text = customer;
            slimline = _slimline;

            if (slimline == -1)
                btnDrawings.Visible = false;
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

                //check if this has been management alerted -- this is defaulted to the first selection here
                sql = "select alert_time,sent_to FROM [order_database].dbo.[quotation_chase_alert] q where chase_id = " + dataGridView1.Rows[0].Cells[0].Value.ToString();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);


                    if (dt.Rows.Count > 0)
                    {

                        txtManagementDate.Text = dt.Rows[0][0].ToString();
                        txtManagementDate.Visible = true;
                        chkManagementAlerted.Checked = true;
                        chkManagementAlerted.Visible = true;
                        lblSentTo.Visible = true;
                        txtSentTo.Text = dt.Rows[0][1].ToString();
                        txtSentTo.Visible = true;
                    }
                    else
                    {

                        txtManagementDate.Visible = false;
                        chkManagementAlerted.Checked = false;
                        chkManagementAlerted.Visible = false;
                        lblSentTo.Visible = false;
                        txtSentTo.Visible = false;
                    }
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
            quote_chase_id = chase_id;
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

                //check if this has been management alerted -- this is defaulted to the first selection here
                sql = "select alert_time,sent_to FROM [order_database].dbo.[quotation_chase_alert] q where chase_id = " + chase_id.ToString();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    
                    if (dt.Rows.Count > 0)
                    {

                        txtManagementDate.Text = dt.Rows[0][0].ToString();
                        txtManagementDate.Visible = true;
                        chkManagementAlerted.Checked = true;
                        chkManagementAlerted.Visible = true;
                        lblSentTo.Visible = true;
                        txtSentTo.Text = dt.Rows[0][1].ToString();
                        txtSentTo.Visible = true;
                    }
                    else
                    {
                        
                        txtManagementDate.Visible = false;
                        chkManagementAlerted.Checked = false;
                        chkManagementAlerted.Visible = false;
                        lblSentTo.Visible = false;
                        txtSentTo.Visible = false;
                    }
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

        private void btnQuote_Click(object sender, EventArgs e)
        {
            if (slimline == -1)
            {
                string sql = "select s.quote_id,issue_id from [order_database].dbo.quotation_chase_log_slimline q " +
                    "left join dbo.sl_quotation s on q.quote_id = s.quote_id where q.id = " + quote_chase_id.ToString();

                string quote_id = "", revision_number = "";

                using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        quote_id = dt.Rows[0][0].ToString();
                        revision_number = dt.Rows[0][1].ToString();
                    }

                    conn.Close();
                }

                string filePath = @"S:\SLIMLINE QUOTES\SL" + quote_id;

                if (Convert.ToInt32(revision_number) > 1) //issue has some extra stuff
                    filePath = filePath + "I" + revision_number;

                filePath = filePath + ".rtf";

                //check if file exists 
                if (File.Exists(filePath))
                    Process.Start(filePath);
                else
                    MessageBox.Show("The quotation for " + quote_id + " does not exist!", "Missing File", MessageBoxButtons.OK);

            }
            else
            {
                //get the info we need to open this quote
                string sql = "select s.quote_id,revision_number from [order_database].dbo.quotation_chase_log q " +
                    "left join [order_database].dbo.solidworks_quotation_log s on q.quote_id = s.quote_id " +
                    "where q.id = " + quote_chase_id.ToString();
                string quote_id = "", revision_number = "";

                using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        quote_id = dt.Rows[0][0].ToString();
                        revision_number = dt.Rows[0][1].ToString();
                    }

                    conn.Close();
                }

                try
                {
                    string path = @"\\designsvr1\SOLIDWORKS\Door Designer\Specifications\Project " + quote_id + @"\Quotations\Revision " + revision_number + @"\FullQuotation-" + quote_id + "-" + revision_number + ".pdf";
                    System.Diagnostics.Process.Start(path);
                }
                catch
                {
                    MessageBox.Show("The full quotation does not yet exist for this number.", "No File Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnDrawings_Click(object sender, EventArgs e)
        {
            string sql = "select s.quote_id,revision_number from [order_database].dbo.quotation_chase_log q " +
                   "left join [order_database].dbo.solidworks_quotation_log s on q.quote_id = s.quote_id " +
                   "where q.id = " + quote_chase_id.ToString();
            string quote_id = "", revision_number = "";

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    quote_id = dt.Rows[0][0].ToString();
                    revision_number = dt.Rows[0][1].ToString();
                }

                conn.Close();
            }

            try
            {
                string path = @"\\designsvr1\SOLIDWORKS\Door Designer\Specifications\Project " + quote_id.ToString();
                System.Diagnostics.Process.Start(path);
            }
            catch
            {
                MessageBox.Show("The full quotation does not yet exist for this number.", "No File Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            btnPrint.Visible = false;
            btnEmail.Visible = false;
            System.Threading.Thread.Sleep(200);
            printImage();

            System.Threading.Thread.Sleep(200);
            btnPrint.Visible = true;
            btnEmail.Visible = true;
        }

        private void printImage()
        {
            try
            {
                Image bit = new Bitmap(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);

                Graphics gs = Graphics.FromImage(bit);

                gs.CopyFromScreen(new Point(0, 0), new Point(0, 0), bit.Size);

                //bit.Save(@"C:\temp\temp.jpg");


                Rectangle bounds = this.Bounds;
                using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
                    }
                    bitmap.Save(@"C:\temp\chase_" + quote_chase_id.ToString() + ".jpg");
                }


                //var frm = Form.ActiveForm;
                //using (var bmp = new Bitmap(frm.Width, frm.Height))
                //{
                //    frm.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                //    bmp.Save(@"C:\temp\temp.jpg");
                //}



                PrintDocument pd = new PrintDocument();
                pd.PrintPage += (sender, args) =>
                {
                    Image i = Image.FromFile(@"C:\temp\chase_" + quote_chase_id.ToString() + ".jpg");
                    Rectangle m = args.MarginBounds;
                    if ((double)i.Width / (double)i.Height > (double)m.Width / (double)m.Height) // image is wider
                    {
                        m.Height = (int)((double)i.Height / (double)i.Width * (double)m.Width);
                        //m.Height = 700;
                        //m.Width = 650;
                    }
                    else
                    {
                        m.Width = (int)((double)i.Width / (double)i.Height * (double)m.Height);
                    }
                    args.Graphics.DrawImage(i, m);
                };

                pd.DefaultPageSettings.Landscape = false;
                Margins margins = new Margins(50, 50, 50, 50);
                pd.DefaultPageSettings.Margins = margins;
                pd.Print();
            }
            catch
            { }
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            try
            {
                Image bit = new Bitmap(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);

                Graphics gs = Graphics.FromImage(bit);

                gs.CopyFromScreen(new Point(0, 0), new Point(0, 0), bit.Size);


                Rectangle bounds = this.Bounds;
                using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
                    }
                    bitmap.Save(@"C:\temp\email_chase_" + quote_chase_id.ToString() + ".jpg");
                }

                Outlook.Application outlookApp = new Outlook.Application();
                Outlook.MailItem mailItem = outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
                mailItem.Subject = "";
                mailItem.To = "";
                string imageSrc = @"C:\temp\email_chase_" + quote_chase_id.ToString() + ".jpg";

                var attachments = mailItem.Attachments;
                var attachment = attachments.Add(imageSrc);
                attachment.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/proptag/0x370E001F", "image/jpeg");
                attachment.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/proptag/0x3712001F", "myident"); // Image identifier found in the HTML code right after cid. Can be anything.
                mailItem.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/id/{00062008-0000-0000-C000-000000000046}/8514000B", true);

                // Set body format to HTML

                mailItem.BodyFormat = Outlook.OlBodyFormat.olFormatHTML;
                mailItem.Attachments.Add(imageSrc);
                string msgHTMLBody = "";
                mailItem.HTMLBody = msgHTMLBody;
                mailItem.Display(true);
            
            
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}
