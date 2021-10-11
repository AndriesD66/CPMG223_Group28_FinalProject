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
        SqlConnection conn = new SqlConnection(Global.ConString);
        SqlCommand comm;
        SqlDataReader read;
        int MemberID;
        int EntryID;
        int ExitID;
        public int attendants;
        public string ClassType;
        MessageBoxButtons btn = MessageBoxButtons.OK;
        MessageBoxIcon info = MessageBoxIcon.Information;
        MessageBoxIcon warn = MessageBoxIcon.Warning;


        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(tbEnter.Text))
                {
                    tbEnter.Focus();
                    tbEnter.Clear();
                    throw new Exception("Please enter a valid MemberId ");
                }

                string sql = "Select * from Member Where MemberId = '" + tbEnter.Text.Trim() + "'";
                comm = new SqlCommand(sql, conn);
                conn.Open();
                read = comm.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        MemberID = int.Parse(Convert.ToString(read.GetValue(0)));
                    }
                }
                read.Close();
                if (MemberID == int.Parse(tbEnter.Text))
                {
                    string sqlSelectIndex = "Select Max(EntryID) FROM Entry";
                    comm = new SqlCommand(sqlSelectIndex, conn);
                    read = comm.ExecuteReader();
                    if (read.HasRows)
                    {
                        while (read.Read())
                        {
                            EntryID = int.Parse(Convert.ToString(read.GetValue(0)));
                        }
                    }
                    read.Close();

                    try
                    {
                        //Insert of all the things needed to know when one logs into system
                        string sqlInsertNewEntry = "INSERT INTO Entry(EntryID, MemberID, EntryTime, EntryDate ) VALUES(@EntryID, @MemberID, @Time, @Date)";
                        comm = new SqlCommand(sqlInsertNewEntry, conn);
                        comm.Parameters.AddWithValue("@EntryID", EntryID + 1);
                        comm.Parameters.AddWithValue("@MemberID", MemberID);
                        comm.Parameters.AddWithValue("@Time", DateTime.Now.ToShortTimeString());
                        comm.Parameters.AddWithValue("@Date", DateTime.Today);

                        comm.ExecuteNonQuery();
                        MessageBox.Show("Added entry");
                        conn.Close();
                    }
                    catch (SqlException error)
                    {
                        MessageBox.Show(error.Message, "", btn, warn);
                    }
                    MessageBox.Show("Member " + MemberID + " entered the gym", "", btn, info);
                }
                else
                {
                    MessageBox.Show("Member not found, try again", "", btn, warn);
                    tbEnter.Focus();
                }
                conn.Close();
                if (cmbClass.SelectedIndex == -1) { throw new Exception("Please select a class in the combo box"); }
                if (cmbClass.SelectedIndex >= 1) { addAttendance(cmbClass.SelectedItem.ToString()); }

            }
            catch (Exception ae)
            {
                MessageBox.Show(ae.Message.ToString(), "", btn, MessageBoxIcon.Warning);
            }
        }

        private void Access_Load(object sender, EventArgs e)
        {
            CheckAdmin();
            populateCB();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            NewMethod();
            conn.Close();
        }

        private void NewMethod()
        {
            try
            { 
                if(String.IsNullOrWhiteSpace(tbExit.Text))
                {
                    
                    
                    tbExit.Focus();
                    tbExit.Clear();
                    throw new Exception("Please enter a valid MemberId ");
                }
                string sql = "Select * from Member Where MemberId = '" + tbExit.Text.Trim() + "'";
                comm = new SqlCommand(sql, conn);
                conn.Open();
                read = comm.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        MemberID = int.Parse(Convert.ToString(read.GetValue(0)));
                    }
                }
                read.Close();
                if (MemberID == int.Parse(tbExit.Text))
                {
                    string sqlSelectIndexExit = "Select Max(ExitID) FROM ExitGym";
                    comm = new SqlCommand(sqlSelectIndexExit, conn);
                    read = comm.ExecuteReader();
                    if (read.HasRows)
                    {
                        while (read.Read())
                        {
                            if (!String.IsNullOrWhiteSpace(Convert.ToString(read.GetValue(0))))
                            {
                                MessageBox.Show(Convert.ToString(read.GetValue(0)),"", btn, info);
                                ExitID = int.Parse(Convert.ToString(read.GetValue(0)));
                                

                            }
                            else
                            {
                                ExitID = 0;
                            }
                        }
                    }
                    read.Close();
                    try
                    {
                        //Insert of all the things needed to know when one logs out of system
                        string sqlInsertNewEntryE = "INSERT INTO ExitGym(ExitID, MemberID, ExitTime, ExitDate ) VALUES(@ExitID, @MemberID, @Time, @Date)";
                        comm = new SqlCommand(sqlInsertNewEntryE, conn);
                        comm.Parameters.AddWithValue("@ExitID", ExitID + 1);
                        comm.Parameters.AddWithValue("@MemberID", MemberID);
                        comm.Parameters.AddWithValue("@Time", DateTime.Now.ToShortTimeString());
                        comm.Parameters.AddWithValue("@Date", DateTime.Today);
                        comm.ExecuteNonQuery();
                        MessageBox.Show("Added entry", "", btn, info);
                        conn.Close();
                    }
                    catch (SqlException error)
                    {
                        MessageBox.Show(error.Message);
                    }

                    MessageBox.Show("Member " + MemberID + " exited the gym", "", btn, info);
                }
                else
                {
                    MessageBox.Show("Member not found, try again", "", btn, warn);
                    tbExit.Focus();
                }

            }
            catch (Exception ae)
            {
                MessageBox.Show(ae.Message.ToString(), "", btn, warn);
                conn.Close();
            }
        }

        public void CheckAdmin()
        {
            if (frmHome.LoggedIn)
            {
                tbExit.Text = frmHome.membeID.ToString();
                tbExit.Enabled = false;
                tbEnter.Text = frmHome.membeID.ToString();
                tbEnter.Enabled = false;
            }
        }

        private void cmbClassType_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                        if (!String.IsNullOrWhiteSpace(Convert.ToString(read.GetValue(0))))
                        {
                            ClassType = Convert.ToString(read.GetValue(0));
                            if (!cmbClass.Items.Contains(ClassType))
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

        public void addAttendance(String Name)
        {
            conn.Open();

            string getAttendance = "Select Attendants From Classtype Where ClassType = '" + Name + "'";
            comm = new SqlCommand(getAttendance, conn);
            read = comm.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read())
                {
                   attendants = Convert.ToInt32(read.GetValue(0));

                }
            }
            read.Close();

            string addAttendance = "Update ClassType Set Attendants = @Attend Where ClassType = '" + Name + "'";


            comm = new SqlCommand(addAttendance, conn);
            comm.Parameters.AddWithValue("@Attend", attendants + 1 );

            comm.ExecuteNonQuery();




            conn.Close();
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

