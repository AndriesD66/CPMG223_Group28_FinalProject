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
            Login newLogForm = new Login();
            Clients view = new Clients();
            Bookings book = new Bookings();
        private void frmHome_Load(object sender, EventArgs e)
        {
            
            if (!LoggedIn)
            {
                pnlHome.Visible = false; ;
                newLogForm.MdiParent = this;
                newLogForm.Show();
            }
            newLogForm.FormClosed += new FormClosedEventHandler(newLogForm_FromClosed);
            view.FormClosed += new FormClosedEventHandler(view_FormClosed);
            book.FormClosed += new FormClosedEventHandler(book_FormClosed);
            
        }
        private void newLogForm_FromClosed(object sender, FormClosedEventArgs e)
        {
            pnlHome.Visible = true;
        }
        private void view_FormClosed(object sender, FormClosedEventArgs e)
        {
            pnlHome.Visible = true;
        }
        private void book_FormClosed(object sender, FormClosedEventArgs e)
        {
            pnlHome.Visible = true;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            view.MdiParent = this;
            pnlHome.Visible = false;
            view.Show();
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            book.MdiParent = this;
            pnlHome.Visible = false;
            book.Show();
        }
    }
}
