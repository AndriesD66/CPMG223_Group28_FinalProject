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
    public partial class Login : Form
    {
        public Login(bool log)
        {
            InitializeComponent();
            ValidLogin = log;
        }

        public static string clientID = "1234567890";
        public static string password = "mIghTy4#";
        public static bool isAdmin = true;
        public static bool ValidLogin = false;
        
        public bool LoggedIn()
        {
            return ValidLogin;
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string error="";
            try
            {
                if ((tbClientID.Text==null)||(tbPassword.Text==null))
                {
                    error = "Please enter a Client ID and a password!";
                }
                if ((tbClientID.Text!=clientID)||(tbPassword.Text!=password))
                {
                    error = "Client ID or password incorrect!";
                }
                if (!isAdmin)
                {
                    error = "This Client ID is not registered as an administrator. You must be an administrator to continue!";
                }
                if ((tbClientID.Text==clientID)&&(tbPassword.Text==password)&&(isAdmin))
                {
                    ValidLogin = true;
                    frmHome.LoggedIn = true;
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show(error);
                tbClientID.Clear();
                tbPassword.Clear();
                tbClientID.Focus();
            }
        }
    }
}
