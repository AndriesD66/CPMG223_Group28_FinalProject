﻿using System;
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

        //string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\andre\OneDrive - NORTH-WEST UNIVERSITY\Documents\GitHub\CPMG223_Group28_FinalProject\CMPG_Group28_FinalProject\CMPG_Group28_FinalProject\GYM_DB.mdf;Integrated Security=True";
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
            conn = new SqlConnection(Global.ConString);
            conn.Open();
            string sql = "Select * from Member";
            adap = new SqlDataAdapter(sql, conn);
            DataTable dtbl = new DataTable();
            adap.Fill(dtbl);
            dgvClients.DataSource = dtbl;
            conn.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(Global.ConString);
                conn.Open();
                string sql = "Select * from Member";
                string del = "Delete from Member Where MemberID = " + Convert.ToInt32(tbDelete.Text.Trim()) + "";
                adap = new SqlDataAdapter(sql, conn);
                comm = new SqlCommand(del, conn);
                int deleted = comm.ExecuteNonQuery();
                adap = new SqlDataAdapter(sql, conn);
                DataTable dtbl = new DataTable();
                adap.Fill(dtbl);
                dgvClients.DataSource = dtbl;
                MessageBox.Show(deleted.ToString() + " item(s) have been deleted");
                conn.Close();
            }
            catch (Exception ae)
            {
                MessageBox.Show(ae.ToString());
            }
        }
    }
}
