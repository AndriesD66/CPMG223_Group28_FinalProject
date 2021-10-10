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
        int[] attend = new int[4] { 0, 0, 0, 0 };
        int MemberID;
        int EntryID;
        int ExitID;
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
            }
            catch (Exception ae)
            {
                
                MessageBox.Show(ae.Message.ToString(), "", btn, MessageBoxIcon.Warning);
            }
            getAttendance();
        }

        private void Access_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(Global.ConString);
            conn.Open();
            conn.Close();
            this.FormClosed += new FormClosedEventHandler(this_FormClosed);
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

                    MessageBox.Show("Member " + MemberID + " entered the gym", "", btn, info);
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
        private void getAttendance()
        {
            if (cmbClassType.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose the class being attended!", "Error!!", btn, warn);
            }
            else if (cmbClassType.SelectedIndex == 1)
            {
                attend[0] += 1;
            }
            else if (cmbClassType.SelectedIndex == 2)
            {
                attend[1] += 1;
            }
            else if (cmbClassType.SelectedIndex == 3)
            {
                attend[2] += 1;
            }
            else if (cmbClassType.SelectedIndex == 4)
            {
                attend[3] += 1;
            }
        }
        private void setAttendance()
        {
            try
            {
                conn.Open();
                string YogaAtt = "Update ClassType Set Attendants = @YogaAtt Where ClassType = 'Yoga'";
                comm = new SqlCommand(YogaAtt, conn);
                comm.Parameters.AddWithValue("@YogaAtt", attend[0]);
                comm.ExecuteNonQuery();
                string PalAtt = "Update ClassType Set Attendants = @PalAtt Where ClassType = 'Palates'";
                comm = new SqlCommand(PalAtt, conn);
                comm.Parameters.AddWithValue("@PalAtt", attend[1]);
                comm.ExecuteNonQuery();
                string CrossAtt = "Update ClassType Set Attendants = @CrossAtt Where ClassType = 'CrossFit'";
                comm = new SqlCommand(CrossAtt, conn);
                comm.Parameters.AddWithValue("@CrossAtt", attend[2]);
                comm.ExecuteNonQuery();
                string SpinAtt = "Update ClassType Set Attendants = @SpinAtt Where ClassType = 'Spin'";
                comm = new SqlCommand(SpinAtt, conn);
                comm.Parameters.AddWithValue("@SpinAtt", attend[3]);
                comm.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ae)
            {
                MessageBox.Show(ae.Message.ToString(), "Error", btn, warn);
                conn.Close();
            }
            
        }
        private void this_FormClosed(object sender, EventArgs e)
        {
            setAttendance();
        }
      
    }
}

