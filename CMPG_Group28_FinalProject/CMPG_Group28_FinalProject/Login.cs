using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMPG_Group28_FinalProject
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        public static string clientID = "1234567890";
        public static string adminPassword = "mIghTy4#";
        public static bool isAdmin = true;
        public static bool ValidLogin = false;

        string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\andre\OneDrive - NORTH-WEST UNIVERSITY\Documents\GitHub\CPMG223_Group28_FinalProject\CMPG_Group28_FinalProject\CMPG_Group28_FinalProject\GYM_DB.mdf;Integrated Security=True";
        SqlConnection conn;
        SqlCommand comm;
        SqlDataAdapter adap;
        SqlDataReader read;
        DataSet ds;

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            conn.Open();

            string sql = "Select * from Member Where MemberId = '" + tbClientID.Text.Trim() + "'";

            adap = new SqlDataAdapter(sql, conn);
            DataTable dtbl = new DataTable();

            adap.Fill(dtbl);
            if (dtbl.Rows.Count == 1)
            {
                if (adminPassword == tbPassword.Text)
                {
                    ValidLogin = true;
                    frmHome.LoggedIn = ValidLogin;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Input a valid Admin password");
                    tbPassword.Clear();
                    tbPassword.Focus();
                }

            }
            else
            {
                MessageBox.Show("Input a valid Member ID ");
                tbClientID.Clear();
                tbPassword.Clear();
                tbClientID.Focus();
            }

            conn.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(conStr);
            conn.Open();
            conn.Close();
        }
    }
}
