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
using System.Data.OleDb;



namespace CMPG_Group28_FinalProject
{
    public partial class Clients : Form
    {
        public Clients()
        {
            InitializeComponent();
        }


        //string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\andre\OneDrive - NORTH-WEST UNIVERSITY\Documents\GitHub\CPMG223_Group28_FinalProject\CMPG_Group28_FinalProject\CMPG_Group28_FinalProject\GYM_DB.mdf;Integrated Security=True";
        
        SqlConnection conn = new SqlConnection(Global.ConString);
        SqlCommand comm;
        SqlDataAdapter adap;
        SqlDataReader read;
        DataSet ds;

        bool checkAdmin = false;
        public int newMemID;
        public int oldMemID;
        public string BankNum;
        public string cNumber;
        public string name;
        public string surname;
        public string email;
        public int MemberID;

        private void cbEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEdit.Checked)
            {
                btAddEdit.Text = "Edit Record";
                lblID.Enabled = true;
                tbID.Enabled = true;

            }
            else if (!cbEdit.Checked)
            {
                btAddEdit.Text = "Add Record";
                lblID.Enabled = false;
                tbID.Enabled = false;
                tbID.Clear();
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
            updateDG();
           
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
               
                
                if (String.IsNullOrWhiteSpace(tbDelete.Text))
                {


                    tbDelete.Focus();
                    tbDelete.Clear();
                    throw new Exception("Please enter a valid MemberId ");
                }
                string sql = "Select * from Member Where MemberId = '" + tbDelete.Text.Trim() + "'";
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
                if (MemberID == int.Parse(tbDelete.Text))
                {

                }
               
                
                string del = "Delete from Member Where MemberID = " + Convert.ToInt32(tbDelete.Text.Trim()) + "";
                adap = new SqlDataAdapter();
                comm = new SqlCommand(del, conn);
                adap.DeleteCommand = comm;
                


                //Maak dat jy seker maak die value is die een wat jy wil delete

                if (MessageBox.Show("Are you sure you want to delete member " + tbDelete.Text.Trim() , "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK) { adap.DeleteCommand.ExecuteNonQuery(); updateDG(); }
                else 
                {
                    MessageBox.Show("Canceled the deletion of member :" + tbDelete.Text); ;
                    tbID.Clear();
                    tbName.Clear();
                    tbSurname.Clear();
                    tbEmail.Clear();
                    tbBank.Clear();
                    tbContact.Clear();
                    cbAdmin.Checked = false;



                }

                conn.Close();
                updateDG();
            }
            catch (Exception ae)
            {
                MessageBox.Show(ae.Message.ToString());
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (btAddEdit.Text == "Add Record")
                {
                    tbErrorTests();


                    if (MessageBox.Show("Are you sure you want to enter member ?", "Adding Member", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                    {
                        conn.Open();
                        MessageBox.Show("Added new Member!");

                        string memID = "Select Max(MemberID) FROM Member";
                        comm = new SqlCommand(memID, conn);
                        read = comm.ExecuteReader();
                        if (read.HasRows)
                        {
                            while (read.Read())
                            {
                                if (!String.IsNullOrWhiteSpace(Convert.ToString(read.GetValue(0))))
                                {
                                    // MessageBox.Show(Convert.ToString(read.GetValue(0)));
                                    newMemID = int.Parse(Convert.ToString(read.GetValue(0)));


                                }
                                else
                                {
                                    newMemID = 0;
                                }
                            }
                        }
                        read.Close();

                        name = tbName.Text;
                        surname = tbSurname.Text;
                        email = tbEmail.Text;
                        BankNum = tbBank.Text;
                        cNumber = tbContact.Text;

                        
                       
                        string add = "INSERT INTO Member(MemberID, Name, Surname, Email, Bank_Account_Number, ContactNumber, IsAdmin) VALUES (@ID, @Name, @Surname, @Email, @BankNum, @Contact, @Admin) ";
                        comm = new SqlCommand(add, conn);

                        comm.Parameters.AddWithValue("@ID", newMemID+1);
                        comm.Parameters.AddWithValue("@Name", name);
                        comm.Parameters.AddWithValue("@Surname", surname);
                        comm.Parameters.AddWithValue("@Email", email);
                        comm.Parameters.AddWithValue("@BankNum", BankNum);
                        comm.Parameters.AddWithValue("@Contact", cNumber);
                        comm.Parameters.AddWithValue("@Admin", checkAdmin);





                        comm.ExecuteNonQuery(); 
                        




                    }
                    else if (MessageBox.Show("Are yo sure you want to enter member ?", "Adding Member", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
                    {
                        MessageBox.Show("Canceled new Member");
                        tbName.Clear();
                        tbSurname.Clear();
                        tbEmail.Clear();
                        tbBank.Clear();
                        tbContact.Clear();



                    }
                    conn.Close();
                    updateDG();

                }
                else if (btAddEdit.Text == "Edit Record")
                {
                    tbErrorTests();

                    if (MessageBox.Show("Are yo sure you want to edit member ?", "Edited Member", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK) 
                    {

                        conn.Open();

                        if (!int.TryParse(lastProcessed, out oldMemID)) {tbID.Clear(); tbID.Focus(); throw new Exception("Insure that you have entered the correct Member ID");  }

                        string updateMem = "UPDATE Member SET Name = @Name, Surname = @Surname, Email = @Email, Bank_Account_Number = @BankNum, ContactNumber = @Contact, IsAdmin = @Admin  WHERE MemberID='" + oldMemID + "'";

                        comm = new SqlCommand(updateMem, conn);
                        comm.Parameters.AddWithValue("@Name", tbName.Text);
                        comm.Parameters.AddWithValue("@Surname", tbSurname.Text);
                        comm.Parameters.AddWithValue("@Email", tbEmail.Text);
                        comm.Parameters.AddWithValue("@BankNum", tbBank.Text);
                        comm.Parameters.AddWithValue("@Contact", tbContact.Text);
                        comm.Parameters.AddWithValue("@Admin", checkAdmin);

                        comm.ExecuteNonQuery();




                        MessageBox.Show("Succesfully edited Member!");




                       
                    }
                    else if (MessageBox.Show("Are yo sure you want to enter member ?", "Cancled  Member Edit", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
                    {
                        MessageBox.Show("Canceled new Member Edit");
                        tbID.Clear();
                        tbName.Clear();
                        tbSurname.Clear();
                        tbEmail.Clear();
                        tbBank.Clear();
                        tbContact.Clear();
                        cbAdmin.Checked = false;



                    }
                    conn.Close();
                    updateDG();
                }

            }
            catch (Exception ae)
            {

                MessageBox.Show(ae.Message.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }




        }


        private void updateDG()
        {
           
            
            try
            {
                
                conn.Open();
                string sql = "Select * from Member";
                adap = new SqlDataAdapter(sql, conn);
                DataTable dtbl = new DataTable();
                adap.Fill(dtbl);
                dgvClients.DataSource = dtbl;
                
                conn.Close();
            }
            catch(SqlException error)
            {
                if (MessageBox.Show(error.Message.ToString(), "ERROR!!", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) { conn.Close(); }
            }

            tbID.Clear();
            tbName.Clear();
            tbSurname.Clear();
            tbEmail.Clear();
            tbBank.Clear();
            tbContact.Clear();
            cbAdmin.Checked = false;

           

            conn.Close();
        }

        private void cbAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAdmin.Checked)
            {
                checkAdmin = true;
            }
            else if (!cbAdmin.Checked)
            {
                checkAdmin = false;
            }
        }
        string lastProcessed;
        private async void tbID_TextChanged(object sender, EventArgs e)
        {
            //conn = new SqlConnection(Global.ConString);
            conn.Open();
            if(int.TryParse(tbID.Text, out oldMemID)) { }

            // clear last processed text if user deleted all text
            if (string.IsNullOrEmpty(tbID.Text)) lastProcessed = null;
            // this inner method checks if user is still typing
            async Task<bool> UserKeepsTyping()
            {
                string txt = tbID.Text;   // remember text
                await Task.Delay(500);        // wait some
                return txt != tbID.Text;  // return that text chaged or not
            }
            if (await UserKeepsTyping() || tbID.Text == lastProcessed) return;
            // save the text you process, and do your stuff
            lastProcessed = tbID.Text;
            // Checks if the member id is a integer
            conn.Close();

            try
            {
                conn.Open();
                string fetchMember = "Select * FROM Member WHERE MemberID Like '" + oldMemID + "'";

                comm = new SqlCommand(fetchMember, conn);

                read = comm.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        tbName.Text = Convert.ToString(read.GetValue(1));
                        tbSurname.Text = Convert.ToString(read.GetValue(2));
                        tbEmail.Text = Convert.ToString(read.GetValue(3));
                        tbBank.Text = Convert.ToString(read.GetValue(4));
                        tbContact.Text = Convert.ToString(read.GetValue(5));
                        bool checkAdminTemp = Convert.ToBoolean(read.GetValue(6));
                        if (checkAdminTemp) { cbAdmin.Checked = true; }
                        else { cbAdmin.Checked = false; }
                    }
                }
                read.Close();
                conn.Close();
            }
            catch(SqlException ae)
            {
                if (MessageBox.Show(ae.Message.ToString(), "ERROR!!", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) { conn.Close(); }
            }
            

            try
            {
                conn.Open();
                string sql = "SELECT * FROM Member WHERE MemberID Like '" + oldMemID + "'";
                comm = new SqlCommand(sql, conn);
                ds = new DataSet();
                adap = new SqlDataAdapter();

                adap.SelectCommand = comm;
                adap.Fill(ds, "SourceTable");

                dgvClients.DataSource = ds;
                dgvClients.DataMember = "SourceTable";
                conn.Close();
            }
            catch (SqlException error)
            {
                if (MessageBox.Show(error.Message.ToString(), "ERROR!!", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) { conn.Close(); }
            }


           
            if(String.IsNullOrEmpty(tbID.Text))
            {
                updateDG();
                tbID.Clear();
                tbName.Clear();
                tbSurname.Clear();
                tbEmail.Clear();
                tbBank.Clear();
                tbContact.Clear();
                cbAdmin.Checked = false;
            }
           

        }

        private void tbErrorTests()
        {


            //Errorhandling van textbox variables

            if (String.IsNullOrWhiteSpace(tbName.Text)) { tbName.Focus(); tbName.Clear(); throw new Exception("Please enter a valid Name "); }
            else if (String.IsNullOrWhiteSpace(tbSurname.Text)) { tbSurname.Focus(); tbSurname.Clear(); throw new Exception("Please enter a valid Surname "); }
            else if (String.IsNullOrWhiteSpace(tbEmail.Text)) { tbEmail.Focus(); tbEmail.Clear(); throw new Exception("Please enter a valid Email "); }
            else if (!tbEmail.Text.Contains("@gmail.com")) { tbEmail.Focus(); tbEmail.Clear(); throw new Exception("Ensure the email is a Gmail account ending in @gmail.com"); }
            else if (String.IsNullOrWhiteSpace(tbBank.Text)) { tbBank.Focus(); tbBank.Clear(); throw new Exception("Please enter a valid Bank Number "); }
            else if (String.IsNullOrWhiteSpace(tbContact.Text)) { tbContact.Focus(); tbContact.Clear(); throw new Exception("Please enter a valid Contact Number "); }
            else if (tbContact.Text.Length != 10) { tbContact.Focus(); tbContact.Clear(); throw new Exception("Please enter a valid Contact Number that is 10 numbers "); }



        }


       




    }

}
