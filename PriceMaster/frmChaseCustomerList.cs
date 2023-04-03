﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace PriceMaster
{
    public partial class frmChaseCustomerList : Form
    {
        public int slimline { get; set; }

        //chase datagrid
        public int quote_id_index { get; set; }
        public int chase_date_index { get; set; }
        public int chase_description_index { get; set; }
        public int next_chase_index { get; set; }
        public int fullName_index { get; set; }
        public int chase_complete_index { get; set; }

        //correspondence datagrid
        public int id_index { get; set; }
        public int customer_name_index { get; set; }
        public int slimline_index { get; set; }
        public int date_created_index { get; set; }
        public int body_index { get; set; }
        public int next_correspondence_index { get; set; }
        public int email_index { get; set; }
        public int phone_index { get; set; }
        public int in_person_index { get; set; }
        public int contact_index { get; set; }
        public int issue_with_leadtime_index { get; set; }
        public int issue_with_quote_turnaround_time_index { get; set; }
        public int issue_with_product_index { get; set; }
        public int issue_with_installation_index { get; set; }
        public int issue_with_service_index { get; set; }
        public int correspondence_by_index { get; set; }

        public frmChaseCustomerList(int _slimline)
        {
            InitializeComponent();

            cmbType.Items.Add("Traditional");
            cmbType.Items.Add("Slimline");

            if (_slimline == -1)
            {
                cmbType.Text = "Slimline";
                lblChase.Text = "Slimline Chases";
                lblCustomer.Text = "Slimline Customers";
                slimline = -1;
            }
            else
            {
                cmbType.Text = "Traditional";
                lblChase.Text = "Traditional Chases";
                lblCustomer.Text = "Traditional Customers";
                slimline = 0;
            }


            fillCombo();
        }
        private void fillCombo()
        {
            string sql = "";
            cmbCustomer.Items.Clear();

            if (slimline == -1)
                sql = "select distinct rtrim([name]) as customer from dsl_fitting.dbo.SALES_LEDGER where [NAME] is not null and len([NAME])>1 order by rtrim([name]) asc ";
            else
                sql = "select distinct rtrim(customer) from [order_database].dbo.solidworks_quotation_log where customer is not null order by rtrim(customer) asc ";

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                        cmbCustomer.Items.Add(reader.GetString(0));
                    reader.Close();
                    conn.Close();
                }
            }

        }

        private void loadGrid()
        {

            dgvOther.DataSource = null;
            dgvChase.DataSource = null;
            string sql = "";

            //chase
            if (slimline == -1)
                sql = "select q.quote_id,chase_date,chase_description,next_chase_date,u.forename + ' ' + u.surname as fullName, " +
                    "CASE WHEN chase_complete = 0 THEN CAST(0 AS BIT) WHEN chase_complete IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Complete] " +
                    "from " +
                    "[order_database].dbo.quotation_chase_log_slimline q " +
                    "left join (SELECT * FROM [price_master].dbo.sl_quotation where highest_issue = -1 ) s on q.quote_id = s.quote_id " +
                    "left join [dsl_fitting].dbo.[SALES_LEDGER] c on s.customer_acc_ref = c.ACCOUNT_REF " +
                    "left join [user_info].dbo.[user] u on q.chased_by = u.id " +
                    "where c.[NAME] = '" + cmbCustomer.Text + "'";

            else
                sql = "select q.quote_id,chase_date,chase_description,next_chase_date,u.forename + ' ' + u.surname as fullName, " +
                    "CASE WHEN chase_complete = 0 THEN CAST(0 AS BIT) WHEN chase_complete IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Complete] " +
                    "from [order_database].dbo.quotation_chase_log q " +
                    "left join [order_database].dbo.solidworks_quotation_log s on q.quote_id = s.quote_id " +
                    "left join [user_info].dbo.[user] u on q.chased_by = u.id " +
                     "where customer = '" + cmbCustomer.Text + "'";

            sql = sql + " order by chase_date desc";

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvChase.DataSource = dt;
                }

                //load the correspondence stuff
                sql = "select q.id,customer_name,u.forename + ' ' + u.surname as fullname,q.slimline,date_created,body," +
                      "CASE WHEN no_follow_up = 0 then convert(varchar(10),next_correspondence_date , 103)  else 'No follow Up'end as next_correspondence, " +
                      "CASE WHEN q.email = 0 THEN CAST(0 AS BIT) WHEN q.email IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Email] ," +
                      "CASE WHEN phone = 0 THEN CAST(0 AS BIT) WHEN phone IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Phone] ," +
                      "CASE WHEN inPerson = 0 THEN CAST(0 AS BIT) WHEN inPerson IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [inPerson] ," +
                      "contact," +
                      "CASE WHEN issue_with_leadtime = 0 THEN CAST(0 AS BIT) WHEN issue_with_leadtime IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Issue with leadtime] ," +
                      "CASE WHEN issue_with_quote_turnaround_time = 0 THEN CAST(0 AS BIT) WHEN issue_with_quote_turnaround_time IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Issue with quote turnaround time] ," +
                      "CASE WHEN issue_with_product = 0 THEN CAST(0 AS BIT) WHEN issue_with_product IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Issue with product]," +
                      "CASE WHEN issue_with_installation = 0 THEN CAST(0 AS BIT) WHEN issue_with_installation IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Issue with installation] ," +
                      "CASE WHEN issue_with_service = 0 THEN CAST(0 AS BIT) WHEN issue_with_service IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS [Issue with service] " +
                      "from [order_database].dbo.quotation_chase_customer q " +
                      "left join [user_info].dbo.[user] u on q.correspondence_by = u.id " +
                      "where  customer_name = '" + cmbCustomer.Text + "' AND q.slimline = ";


                if (slimline == -1)
                    sql = sql + "-1";
                else
                    sql = sql + "0";

                sql = sql + " order by date_created desc";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvOther.DataSource = dt;
                }


                conn.Close();
            }
            column_index();
            format();
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadGrid();
            format();
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {

            dgvChase.DataSource = null;
            dgvOther.DataSource = null;
            cmbCustomer.Items.Clear();
            if (cmbType.Text == "Slimline")
            {
                cmbType.Text = "Slimline";
                lblChase.Text = "Slimline Chases";
                lblCustomer.Text = "Slimline Customers";
                slimline = -1;
            }
            else
            {
                cmbType.Text = "Traditional";
                lblChase.Text = "Traditional Chases";
                lblCustomer.Text = "Traditional Customers";
                slimline = 0;
            }

            fillCombo();
        }

        private void format()
        {
            //chase formatting
            foreach (DataGridViewColumn col in dgvChase.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            dgvChase.Columns[chase_description_index].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvChase.Columns[quote_id_index].HeaderText = "Quote ID";
            dgvChase.Columns[chase_date_index].HeaderText = "Chase Date";
            dgvChase.Columns[chase_description_index].HeaderText = "Chase Description";
            dgvChase.Columns[next_chase_index].HeaderText = "Next Chase Date";
            dgvChase.Columns[fullName_index].HeaderText = "Chased By";
            dgvChase.Columns[chase_complete_index].HeaderText = "Complete";

            foreach (DataGridViewColumn col in dgvChase.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;

            //correspondence formatting
            dgvOther.Columns[correspondence_by_index].HeaderText = "Correspondence By";
            dgvOther.Columns[id_index].HeaderText = "ID";
            dgvOther.Columns[customer_name_index].HeaderText = "Customer Name";
            dgvOther.Columns[slimline_index].HeaderText = "Slimline";
            dgvOther.Columns[date_created_index].HeaderText = "Date Created";
            dgvOther.Columns[body_index].HeaderText = "Body";
            dgvOther.Columns[next_correspondence_index].HeaderText = "Next Correspondence Date";
            dgvOther.Columns[email_index].HeaderText = "Email";
            dgvOther.Columns[phone_index].HeaderText = "Phone";
            dgvOther.Columns[in_person_index].HeaderText = "In-Person";
            dgvOther.Columns[contact_index].HeaderText = "Contact";

            dgvOther.Columns[id_index].Visible = false;
            dgvOther.Columns[slimline_index].Visible = false;

            foreach (DataGridViewColumn col in dgvOther.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgvOther.Columns[body_index].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void column_index()
        {
            //chase index
            quote_id_index = dgvChase.Columns["quote_id"].Index;
            chase_date_index = dgvChase.Columns["chase_date"].Index;
            chase_description_index = dgvChase.Columns["chase_description"].Index;
            next_chase_index = dgvChase.Columns["next_chase_date"].Index;
            fullName_index = dgvChase.Columns["fullName"].Index;
            chase_complete_index = dgvChase.Columns["Complete"].Index;

            //correspondence index
            id_index = dgvOther.Columns["id"].Index;
            customer_name_index = dgvOther.Columns["customer_name"].Index;
            slimline_index = dgvOther.Columns["slimline"].Index;
            date_created_index = dgvOther.Columns["date_created"].Index;
            body_index = dgvOther.Columns["body"].Index;
            next_correspondence_index = dgvOther.Columns["next_correspondence"].Index;
            email_index = dgvOther.Columns["email"].Index;
            phone_index = dgvOther.Columns["phone"].Index;
            in_person_index = dgvOther.Columns["inPerson"].Index;
            contact_index = dgvOther.Columns["contact"].Index;
            correspondence_by_index = dgvOther.Columns["fullName"].Index;

            issue_with_leadtime_index = dgvOther.Columns["Issue with leadtime"].Index;
            issue_with_quote_turnaround_time_index = dgvOther.Columns["Issue with quote turnaround time"].Index;
            issue_with_product_index = dgvOther.Columns["Issue with product"].Index;
            issue_with_installation_index = dgvOther.Columns["Issue with installation"].Index;
            issue_with_service_index = dgvOther.Columns["Issue with service"].Index;
        }

        private void dgvChase_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            frmManagementViewHistory frm = new frmManagementViewHistory(Convert.ToInt32(dgvChase.Rows[e.RowIndex].Cells[quote_id_index].Value), slimline, cmbCustomer.Text);
            frm.ShowDialog();
        }

        private void txtInsert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbCustomer.Text))
            {
                return;
            }
            frmChaseInsertCorrespondence frm = new frmChaseInsertCorrespondence(cmbCustomer.Text, slimline);
            frm.ShowDialog();

            loadGrid();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

            if (dgvOther.Rows.Count == 0)
                return;


            Process[] processesBefore = Process.GetProcessesByName("excel");

            //
            int customer_index = 0;
           // customer_index = dgvOther.Columns["Customer"].Index;

            string FileName = @"C:\temp\correspondence" + DateTime.Now.ToString("mmss") + ".xls";


            //adjust the chase description
            foreach (DataGridViewRow row in dgvOther.Rows)
            {
                //string temp =  row.Cells[3].Value.ToString();
                row.Cells[chase_description_index].Value = row.Cells[chase_description_index].Value.ToString().Replace("\n", " ").Replace("\r", " - ");
            }


            // Copy DataGridView results to clipboard
            dgvOther.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dgvOther.SelectAll();

            //delete all of the first row


            DataObject dataObj = dgvOther.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);

            object misValue = System.Reflection.Missing.Value;
            Microsoft.Office.Interop.Excel.Application xlexcel = new Microsoft.Office.Interop.Excel.Application();

            xlexcel.DisplayAlerts = false; // Without this you will get two confirm overwrite prompts
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook = xlexcel.Workbooks.Add(misValue);
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            // Get Excel processes after opening the file. 
            Process[] processesAfter = Process.GetProcessesByName("excel");


            // Paste clipboard results to worksheet range
            Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[2, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

            //delete the first row
            ((Excel.Range)xlWorkSheet.Rows[1, Missing.Value]).Delete(Excel.XlDeleteShiftDirection.xlShiftUp);



            xlWorkSheet.get_Range("A2").Select();

            Microsoft.Office.Interop.Excel.Worksheet ws = xlexcel.ActiveWorkbook.Worksheets[1];
            Microsoft.Office.Interop.Excel.Range range = ws.UsedRange;



            //ws.Columns.AutoFit();
            //ws.Rows.AutoFit();

            //adjust the description conversation to fit and look nicer
            xlWorkSheet.Columns[3].ColumnWidth = 100;
            xlWorkSheet.Columns[3].WrapText = true;

            //Make all top/left align
            xlWorkSheet.get_Range("A1", "L1000").Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignGeneral;
            xlWorkSheet.get_Range("A1", "L1000").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            //change the entire top row to center align (AND BOTH DATE COLUMNS)
            xlWorkSheet.get_Range("A1", "L1").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //xlWorkSheet.Columns[2].Style.HorizontalAlignment = HorizontalAlignment.Center;
            //xlWorkSheet.Columns[4].Style.HorizontalAlignment = HorizontalAlignment.Center;


            xlWorkSheet.Range["A1:L1"].Interior.Color = System.Drawing.Color.LightSkyBlue;
            xlWorkSheet.Range["A1:L1"].AutoFilter(1);
            xlWorkSheet.Range["A1:L1"].Cells.Font.Size = 12;

            ws.Columns.AutoFit();
            ws.Rows.AutoFit();


            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            range.Borders.Color = ColorTranslator.ToOle(Color.Black);

            // Save the excel file under the captured location from the SaveFileDialog
            xlWorkBook.SaveAs(FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlexcel.DisplayAlerts = true;
            xlWorkBook.Close(true, misValue, misValue);
            xlexcel.Quit();

            //releaseObject(xlWorkSheet);
            //releaseObject(xlWorkBook);
            //releaseObject(xlexcel);

            // Clear Clipboard and DataGridView selection
            Clipboard.Clear();
            dgvOther.ClearSelection();

            // Open the newly saved excel file
            if (File.Exists(FileName))
                System.Diagnostics.Process.Start(FileName);

            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks workbooks;
            Microsoft.Office.Interop.Excel.Workbook excelBook;

            //app = null;
            //app = new Excel.Application(); // create a new instance
            excelApp.DisplayAlerts = false; //turn off annoying alerts that make me want to cryyyy

            workbooks = excelApp.Workbooks;
            excelBook = workbooks.Add(FileName);
            Microsoft.Office.Interop.Excel.Sheets sheets = excelBook.Worksheets;
            Microsoft.Office.Interop.Excel.Worksheet excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)(sheets[1]);

            //Range.Rows.AutoFit();
            //Range.Columns.AutoFit();

            excelApp.Quit();
            // Now find the process id that was created, and store it. 
            int processID = 0;
            foreach (Process process in processesAfter)
            {
                if (!processesBefore.Select(p => p.Id).Contains(process.Id))
                {
                    processID = process.Id;
                    // And now kill the process. 
                    if (processID != 0)
                    {
                        Process process2 = Process.GetProcessById(processID);
                        process2.Kill();
                    }
                }
            }
        }

        private void dgvOther_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            frmChaseCorrespondenceView frm = new frmChaseCorrespondenceView(Convert.ToInt32(dgvOther.Rows[e.RowIndex].Cells[id_index].Value.ToString()),slimline,0);
            frm.ShowDialog();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            frmCorrespondenceMassInsert frm = new frmCorrespondenceMassInsert();
            frm.ShowDialog();
        }
    }
}
