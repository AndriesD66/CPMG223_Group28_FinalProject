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
    public partial class Access : Form
    {
        public Access()
        {
            InitializeComponent();
        }

        string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\andre\OneDrive - NORTH-WEST UNIVERSITY\Documents\GitHub\CPMG223_Group28_FinalProject\CMPG_Group28_FinalProject\CMPG_Group28_FinalProject\GYM_DB.mdf;Integrated Security=True";
        SqlConnection conn;
        SqlCommand comm;
        SqlDataAdapter adap;
        SqlDataReader read;
        DataSet ds;
        string MemberID;

        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "Select * from Member Where MemberId = '" + tbEnter.Text.Trim() + "'";
                comm = new SqlCommand(sql, conn);
                conn.Open();
                read = comm.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        MemberID = Convert.ToString(read.GetValue(0));
                    }
                }
                read.Close();
                if (MemberID == tbEnter.Text)
                {
                    MessageBox.Show("Member " + MemberID + " entered the gym");
                }
                else
                {
                    MessageBox.Show("Member not found");
                }
                conn.Close();
            }
            catch(Exception ae)
            {
                MessageBox.Show(ae.ToString());
            }
        }

        private void Access_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(conStr);
            conn.Open();
            conn.Close();
        }
    }
}
