using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace PriceMaster
{
    public partial class frmCorrespondenceMassInsert : Form
    {
        public frmCorrespondenceMassInsert()
        {
            InitializeComponent();
        }

        private void btnImportList_Click(object sender, EventArgs e)
        {
            string filePath = "";
            OpenFileDialog of = new OpenFileDialog();
            of.FilterIndex = 1;
            of.RestoreDirectory = true;

            if (of.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    txtFile.Text = of.FileName;
                    importList(of.FileName); 
                }
                catch
                {
                    MessageBox.Show("There was an error loading this file.");
                    return;
                }
            }

        }
        private void importList(string file)
        {
            //check if the file exists - read it and insert into datatable
            if (System.IO.File.Exists(file))
            {

                // Store the Excel processes before opening.
                Process[] processesBefore = Process.GetProcessesByName("excel");

                var xlApp = new Excel.Application();
                var xlWorkbooks = xlApp.Workbooks;
                var xlWorkbook = xlWorkbooks.Open(file);
                var xlWorksheet = xlWorkbook.Sheets[1];
                var xlRange = xlWorksheet.UsedRange;

                // Get Excel processes after opening the file.
                Process[] processesAfter = Process.GetProcessesByName("excel");

                int rows = xlRange.Rows.Count;

                //make the datatable
                DataTable dt = new System.Data.DataTable();
                dt.Columns.Add("Customer");
                dt.Columns.Add("Email");
                dt.Columns.Add("Forename");
                dt.Columns.Add("Surname");

                //prompt for headers
                DialogResult result = MessageBox.Show("Does this document have column headers?", "Column headers", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                int start_number = 0;
                if (result == DialogResult.Yes)
                    start_number = 2;
                else
                    start_number = 1;

                for (int i = start_number; i < rows; i++)
                {
                    DataRow dr = dt.NewRow();

                    dr["Customer"] = xlRange.Cells[i, 1].Value2.ToString();
                    dr["Email"] = xlRange.Cells[i, 2].Value2.ToString();
                    dr["Forename"] = xlRange.Cells[i, 3].Value2.ToString();
                    dr["Surname"] = xlRange.Cells[i, 4].Value2.ToString();
                    dt.Rows.Add(dr);
                }

                dataGridView1.DataSource = dt;

                foreach (DataGridViewColumn col in dataGridView1.Columns)
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; 

                xlApp.Quit();

                // Now find the process id that was created, and store it.
                int processID = 0;
                foreach (Process process in processesAfter)
                {
                    if (!processesBefore.Select(p => p.Id).Contains(process.Id))
                    {
                        processID = process.Id;
                    }
                }
                // And now kill the process.
                if (processID != 0)
                {
                    Process process = Process.GetProcessById(processID);
                    process.Kill();
                }

            }
        }
    }
}
