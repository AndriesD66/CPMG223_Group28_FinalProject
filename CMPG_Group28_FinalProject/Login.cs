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
using System.IO;

namespace CMPG_Group28_FinalProject
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public static string adminPassword = "mIghTy4#";
        public static bool isAdmin = true;
        public static bool ValidLogin = false;
        public static bool ValidLoginAdmin = false;
        public int oldMemID;
        public string lastProcessed;
        public string memberName;
        SqlConnection conn = new SqlConnection(Global.ConString);
        SqlCommand comm;
        SqlDataAdapter adap;
        SqlDataReader read;

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            conn.Open();
            getName();
            if (String.IsNullOrWhiteSpace(tbClientID.Text))
            {
                MessageBoxButtons btn = MessageBoxButtons.OK;
                MessageBox.Show("Input a valid Member ID ", "Error", btn, MessageBoxIcon.Warning);
                tbClientID.Clear();
                tbClientID.Focus();
            }
            string sql = "Select * from Member Where MemberId = '" + tbClientID.Text.Trim() + "'";
            adap = new SqlDataAdapter(sql, conn);
            DataTable dtbl = new DataTable();
            adap.Fill(dtbl);
            if (dtbl.Rows.Count == 1)
            {
                if (adminPassword == tbPassword.Text && isAdmin == true)
                {
                    ValidLoginAdmin = true;
                    frmHome.LoggedInAdmin = ValidLoginAdmin;
                    this.Close();
                    MessageBox.Show("Welcome Admin " + memberName);
                }
                if(tbPassword.Visible == false && isAdmin == false)
                {
                    ValidLogin = true;
                    frmHome.LoggedIn = ValidLogin;
                    frmHome.membeID = oldMemID;
                    this.Close();
                    MessageBox.Show("Welcome Client " + memberName);
                }
            }
            conn.Close();
        }

        private async void tbClientID_TextChanged(object sender, EventArgs e)
        {
            conn.Close();
            conn.Open();
            if (int.TryParse(tbClientID.Text, out oldMemID)) { }
            // clear last processed text if user deleted all text
            if (string.IsNullOrEmpty(tbClientID.Text)) lastProcessed = null;
            // this inner method checks if user is still typing
            async Task<bool> UserKeepsTyping()
            {
                string txt = tbClientID.Text;   // remember text
                await Task.Delay(500);        // wait some
                return txt != tbClientID.Text;  // return that text chaged or not
            }
            if (await UserKeepsTyping() || tbClientID.Text == lastProcessed) return;
            // save the text you process, and do your stuff
            lastProcessed = tbClientID.Text;
            // Checks if the member id is a integer
            conn.Close();
            try
            {
                conn.Open();
                string checkMember = "Select IsAdmin FROM Member WHERE MemberID Like '" + oldMemID + "'";
                comm = new SqlCommand(checkMember, conn);
                read = comm.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        if(!Boolean.Parse(Convert.ToString(read.GetValue(0))))
                        {
                            tbPassword.Hide();
                            label2.Hide();
                            MessageBox.Show("You are not an Admin", "Admin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            isAdmin = false;
                        }
                        else
                        {
                            MessageBox.Show("You are an Admin\nPlease enter the given admin Password", "Admin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            isAdmin = true;
                        }
                    }
                       
                    
                }
                if (String.IsNullOrWhiteSpace(tbClientID.Text))
                {
                    tbClientID.Clear();
                    tbClientID.Focus();
                    tbPassword.Show();
                    label2.Show();
                }
                read.Close();
                conn.Close();
            }
            catch (SqlException ae)
            {
                if (MessageBox.Show(ae.Message.ToString(), "ERROR!!", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) { conn.Close(); }
            }
        }

        public void getName()
        {
            conn.Close();
            try
            {
                conn.Open();
                string checkMember = "Select Name FROM Member WHERE MemberID Like '" + oldMemID + "'";
                comm = new SqlCommand(checkMember, conn);
                read = comm.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        memberName = Convert.ToString(read.GetValue(0));
                    }
                }
                read.Close();
                conn.Close();
            }
            catch (SqlException ae)
            {
                if (MessageBox.Show(ae.Message.ToString(), "ERROR!!", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) { conn.Close(); }
            }
        }
    }
    
}
