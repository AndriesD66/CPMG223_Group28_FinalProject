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
using System.Data;

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
            Access acc = new Access();
            Payment pmnt = new Payment();
            Reports rpt = new Reports();




        SqlConnection conn;
        SqlCommand comm;
        SqlDataAdapter adap;
        SqlDataReader read;
        DataSet ds;

        private void frmHome_Load(object sender, EventArgs e)
        {

            if (!LoggedIn)
            {
                menuStrip1.Enabled = false;
                pnlHome.Visible = false; ;
                newLogForm.MdiParent = this;
                newLogForm.Show();
            }
            newLogForm.FormClosed += new FormClosedEventHandler(newLogForm_FromClosed);
            view.FormClosed += new FormClosedEventHandler(view_FormClosed);
            book.FormClosed += new FormClosedEventHandler(book_FormClosed);
            acc.FormClosed += new FormClosedEventHandler(acc_FormClosed);
            pmnt.FormClosed += new FormClosedEventHandler(pmnt_FormClosed);
            rpt.FormClosed += new FormClosedEventHandler(rpt_FormClosed);
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
                view.MdiParent = this;
                pnlHome.Visible = false;
                book.Visible = false;
                acc.Visible = false;
                pmnt.Visible = false;
                rpt.Visible = false;
                view.Show();
            
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            book.MdiParent = this;
            pnlHome.Visible = false;
            view.Visible = false;
            acc.Visible = false;
            pmnt.Visible = false;
            rpt.Visible = false;
            book.Show();
        }

        private void btnEnterExit_Click(object sender, EventArgs e)
        {
            acc.MdiParent = this;
            pnlHome.Visible = false;
            book.Visible = false;
            view.Visible = false;
            pmnt.Visible = false;
            rpt.Visible = false;
            acc.Show();
        }

        private void btnPmnt_Click(object sender, EventArgs e)
        {
            pmnt.MdiParent = this;
            pnlHome.Visible = false;
            book.Visible = false;
            acc.Visible = false;
            view.Visible = false;
            rpt.Visible = false;
            pmnt.Show();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            rpt.MdiParent = this;
            pnlHome.Visible = false;
            book.Visible = false;
            acc.Visible = false;
            pmnt.Visible = false;
            view.Visible = false;
            rpt.Show();
        }

        private void pnlHome_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            SQLcommit();
            
            Application.Exit();
        }


        private void SQLcommit()
        {
            conn = new SqlConnection(Global.ConString);
            conn.Open();

            string sql = "Commit * FROM Member";

            comm = new SqlCommand(sql, conn);
           
            conn.Close();


            

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





    }
}
