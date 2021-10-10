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
    public partial class Bookings : Form
    {
        public Bookings()
        {
            InitializeComponent();
        }
        string MemberID;

        //string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\andre\OneDrive - NORTH-WEST UNIVERSITY\Documents\GitHub\CPMG223_Group28_FinalProject\CMPG_Group28_FinalProject\CMPG_Group28_FinalProject\GYM_DB.mdf;Integrated Security=True";
        SqlConnection conn = new SqlConnection(Global.ConString);

        SqlCommand comm;
        SqlDataAdapter adap;
        SqlDataReader read;
        DataSet ds;
        MessageBoxButtons btn = MessageBoxButtons.OK;
        MessageBoxIcon warn = MessageBoxIcon.Warning;
        MessageBoxIcon info = MessageBoxIcon.Information;
        private string ClassType;

        private void Bookings_Load(object sender, EventArgs e)
        {
            UpdateDG();
            populateCB();
        }

      

        private void btnBook_Click(object sender, EventArgs e)
        {
            int BookingID = 0;
            string ClassType = "";
            DateTime bookDate;
            DateTime bookTime;
            try
            {
                string sql = "Select * from Member Where MemberID = '" + tbBooking.Text.Trim() + "'";
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
                if (MemberID == tbBooking.Text)
                {
                    MemberID = tbBooking.Text;
                    bookDate = dtClass.Value.Date;
                    bookTime = DateTime.Now;
                    if (cmbClass.SelectedIndex!=-1)
                    {
                        ClassType = cmbClass.GetItemText(cmbClass.SelectedItem);
                    }
                    else
                    {
                        MessageBox.Show("Please select what type of class you want to book", "", btn, warn);
                        tbBooking.Clear();
                        tbBooking.Focus();
                        conn.Close();
                    }
                    sql = "Select Top 1 BookingID From Booking Order By BookingID Desc";
                    comm = new SqlCommand(sql, conn);
                    read = comm.ExecuteReader();
                    if (read.HasRows)
                    {
                        while (read.Read())
                        {
                            BookingID = Convert.ToInt32(read.GetValue(0));
                        }
                    }
                    read.Close();
                    BookingID++;
                    sql = "Insert Booking(BookingID, MemberID, ClassType, BookingTime, BookingDate) Values (" + BookingID + ", '" + MemberID + "', '" + ClassType + "', '" + bookTime + "', '" + bookDate + "')";
                    comm = new SqlCommand(sql, conn);
                    comm.ExecuteNonQuery();
                    sql = "Select * from Booking";
                    adap = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    adap.Fill(dt);
                    dgvClass.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Member not found", "", btn, warn);
                    MemberID = "";
                    tbBooking.Clear();
                    tbBooking.Focus();
                }
                MemberID = "";
                conn.Close();
                tbBooking.Clear();
                tbBooking.Focus();
                
                read.Close();
                conn.Close();
            }
            catch (Exception ae)
            {
                MessageBox.Show(ae.ToString(),"", btn, warn);
                conn.Close();
            }
            UpdateDG();

        }



        private void UpdateDG()
        {
            conn.Close();
            try
            {
                conn.Open();
                string sql = "Select * from Booking";
                adap = new SqlDataAdapter(sql, conn);
                DataTable dtbl = new DataTable();
                adap.Fill(dtbl);
                dgvClass.DataSource = dtbl;
                conn.Close();
            }
            catch (Exception ae)
            {
                MessageBox.Show(ae.ToString(), "", btn, warn);
                conn.Close();
            }
           
        }

        private void tbBooking_TextChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                string sqlShowMem = "Select * From Booking Where MemberID ='" + tbBooking.Text.Trim() + "'";
                adap = new SqlDataAdapter(sqlShowMem, conn);
                DataTable dtbl = new DataTable();
                adap.Fill(dtbl);
                dgvClass.DataSource = dtbl;
                
                if (String.IsNullOrWhiteSpace(tbBooking.Text))
                {
                    UpdateDG();
                }
                conn.Close();
            }
            catch (SqlException ae)
            {
                MessageBox.Show(ae.ToString(), "", btn, warn);
                conn.Close();
            }


        }

        private void populateCB()
        {
            try
            {
                conn.Open();

                string updateCB = "Select ClassType From ClassType";
                comm = new SqlCommand(updateCB, conn);
                read = comm.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        if(!String.IsNullOrWhiteSpace(Convert.ToString(read.GetValue(0))))
                        {
                            ClassType = Convert.ToString(read.GetValue(0));
                            if(!cmbClass.Items.Contains(ClassType))
                            {
                                cmbClass.Items.Add(ClassType);
                            }
                           
                        }
                        else
                        {
                            ClassType = "Empty";
                            
                        }
                    }
                }
                read.Close();


                
            }
            catch (SqlException ae)
            {
                MessageBox.Show(ae.ToString(), "", btn, warn);
                conn.Close();
            }
            conn.Close();
        }



        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
