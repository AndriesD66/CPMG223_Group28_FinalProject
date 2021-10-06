using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMPG_Group28_FinalProject
{
    public partial class Clients : Form
    {
        public Clients()
        {
            InitializeComponent();
        }

        private void cbEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEdit.Checked)
            {
                lblID.Enabled = true;
                tbID.Enabled = true;
            }
            else if (!cbEdit.Checked)
            {
                lblID.Enabled = false;
                tbID.Enabled = false ;
            }
        }

        private void Clients_Load(object sender, EventArgs e)
        {
            if (cbEdit.Checked)
            {
                lblID.Enabled = true;
                tbID.Enabled = true;
            }
            else if (!cbEdit.Checked)
            {
                lblID.Enabled = false;
                tbID.Enabled = false;
            }
        }
    }
}
