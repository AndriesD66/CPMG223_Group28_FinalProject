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
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }
            public static bool LoggedIn=false;
        private void frmHome_Load(object sender, EventArgs e)
        {
            Login newLogForm = new Login(LoggedIn);
            if (!LoggedIn)
            {
                newLogForm.MdiParent = this;
                newLogForm.Show();
                newLogForm.Activate();
            }
            button1.Enabled = LoggedIn;
        }
    }
}
