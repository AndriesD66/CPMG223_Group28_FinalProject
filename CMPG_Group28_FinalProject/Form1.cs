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
        Login newLogForm;
        Clients view;
        Bookings book;
        Access acc;
        Payment pmnt;
        Reports rpt;
        Classes cls;




       
 

        private void frmHome_Load(object sender, EventArgs e)
        {

            if (!LoggedIn)
            {
                newLogForm = new Login();
                menuStrip1.Enabled = false;
                pnlHome.Visible = false; ;
                newLogForm.MdiParent = this;
                newLogForm.Show();
            }
            newLogForm.FormClosed += new FormClosedEventHandler(newLogForm_FromClosed);
           
            
            
            
        }
        private void newLogForm_FromClosed(object sender, FormClosedEventArgs e)
        {
            if (LoggedIn)
            {
                pnlHome.Visible = true;
                menuStrip1.Enabled = true;
            }
        }
        private void view_FormClosed(object sender, FormClosedEventArgs e)
        {
            pnlHome.Visible = true;
        }
        private void book_FormClosed(object sender, FormClosedEventArgs e)
        {
            pnlHome.Visible = true;
        }
        private void acc_FormClosed(object sender, FormClosedEventArgs e)
        {
            pnlHome.Visible = true;
        }
        private void pmnt_FormClosed(object sender, FormClosedEventArgs e)
        {
            pnlHome.Visible = true;
        }
        private void rpt_FormClosed(object sender, FormClosedEventArgs e)
        {
            pnlHome.Visible = true;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if(view == null || view.IsDisposed)
            {
                view = new Clients();
                view.FormClosed += new FormClosedEventHandler(view_FormClosed);

            }
           
           
          
            view.ShowDialog();

        }
        private void cls_FormClosed(object sender, EventArgs e)
        {
            pnlHome.Visible = true;
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            book = new Bookings();
            book.FormClosed += new FormClosedEventHandler(book_FormClosed);

            book.ShowDialog();
        }

        private void btnEnterExit_Click(object sender, EventArgs e)
        {

            acc = new Access();
            acc.FormClosed += new FormClosedEventHandler(acc_FormClosed);

            acc.ShowDialog();
        }

        private void btnPmnt_Click(object sender, EventArgs e)
        {
            pmnt = new Payment();
            pmnt.FormClosed += new FormClosedEventHandler(pmnt_FormClosed);

            pmnt.ShowDialog();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            rpt = new Reports();

            rpt.FormClosed += new FormClosedEventHandler(rpt_FormClosed);

            rpt.ShowDialog();
            rpt.Focus();
           

        }

        private void pnlHome_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Exit_Click(object sender, EventArgs e)
        {
           
            
            Application.Exit();
        }



        

        private void viewUpdateOrDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            btnView_Click(sender, e);
            
        }

        private void bookAClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnBook_Click(sender, e);


        }

        private void clientAccessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnEnterExit_Click(sender, e);

        }

        private void logAPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnPmnt_Click(sender, e);
            
        }

        private void requestReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnReport_Click(sender, e);
        }

        private void btnClasses_Click(object sender, EventArgs e)
        {
            cls = new Classes();
            cls.FormClosed += new FormClosedEventHandler(cls_FormClosed);
            cls.ShowDialog();
        }

        private void EditClassesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnClasses_Click(sender, e);
        }
    }
}
