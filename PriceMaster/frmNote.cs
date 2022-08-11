using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PriceMaster
{
    public partial class frmNote : Form
    {
        public frmNote()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CONNECT.note = "cancel clicked";
            this.Close();
        }

        private void btnAddNote_Click(object sender, EventArgs e)
        {
            txtNote.Text = txtNote.Text.Replace("'", "");
            if (txtNote.Text.Length < 5)
            {
                MessageBox.Show("Please enter a more detailed note before clicking 'Add Note'");
                return;
            }
            else
            {
                txtNote.Text = txtNote.Text + " - " + CONNECT.staffFullName + " - " + DateTime.Now.ToString();
                CONNECT.note = txtNote.Text;
                this.Close();
            }
        }
    }
}
