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
    public partial class Clients : Form
    {
        public Clients()
        {
            InitializeComponent();
        }

        string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\andre\OneDrive - NORTH-WEST UNIVERSITY\Documents\GitHub\CPMG223_Group28_FinalProject\CMPG_Group28_FinalProject\CMPG_Group28_FinalProject\GYM_DB.mdf;Integrated Security=True";
        SqlConnection conn;
        SqlCommand comm;
        SqlDataAdapter adap;
        SqlDataReader read;
        DataSet ds;

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
            conn = new SqlConnection(conStr);
            conn.Open();
            string sql = "Select * from Member";
            adap = new SqlDataAdapter(sql, conn);
            DataTable dtbl = new DataTable();
            adap.Fill(dtbl);
            dgvClients.DataSource = dtbl;
            conn.Close();
        }
    }
}
