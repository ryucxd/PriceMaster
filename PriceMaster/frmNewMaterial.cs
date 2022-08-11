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
    public partial class frmNewMaterial : Form
    {
        public frmNewMaterial()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtMaterial.Text.Replace("'", "");
            if (txtMaterial.Text.Length < 1)
            {
                MessageBox.Show("Please enter a material first", "No data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                CONNECT.materialType = txtMaterial.Text;
                this.Close();
            }
        }

        private void frmNewMaterial_FormClosing(object sender, FormClosingEventArgs e)
        {
          //  CONNECT.materialType = null;
        }
    }
}
