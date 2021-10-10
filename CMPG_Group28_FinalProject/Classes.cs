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
    public partial class Classes : Form
    {
        public Classes()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(Global.ConString);
        SqlCommand comm;
        SqlDataAdapter adap;
        SqlDataReader read;
        DataSet ds;
        int ClassID;
        int newClsID;
        int oldClsID;
        string ClassType;
        DateTime clsDate;
        DateTime clsTime;
        string clsDesc;
        int clsAtt = 0;
        public int oldMemID;
        string lastProcessed;


        private void Classes_Load(object sender, EventArgs e)
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
      
        
        private void updateDG()
        {
            conn.Close();

            try
            {
                conn.Open();
                string classSql = "Select * from ClassType";
                adap = new SqlDataAdapter(classSql, conn);
                DataTable dtbl = new DataTable();
                adap.Fill(dtbl);
                dgvClasses.DataSource = dtbl;
                conn.Close();
            }
            catch (SqlException error)
            {
                if (MessageBox.Show(error.Message.ToString(), "ERROR!!", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) { conn.Close(); }
            }

            tbID.Clear();
            cmbClass.SelectedIndex = -1;
            dtClassDate.Value = DateTime.Today;
            tbClassTime.Clear();
            tbDesc.Clear();
            conn.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(tbDelete.Text))
                {
                    tbDelete.Focus();
                    tbDelete.Clear();
                    throw new Exception("Please enter a valid ClassId ");
                }
                string sql = "Select * from ClassType Where ClassID = '" + tbDelete.Text.Trim() + "'";
                comm = new SqlCommand(sql, conn);
                conn.Open();
                read = comm.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        ClassID = int.Parse(Convert.ToString(read.GetValue(0)));
                    }
                }
                read.Close();
                if (ClassID == int.Parse(tbDelete.Text))
                {

                }
                string del = "Delete from ClassType Where ClassID = " + Convert.ToInt32(tbDelete.Text.Trim()) + "";
                adap = new SqlDataAdapter();
                comm = new SqlCommand(del, conn);
                adap.DeleteCommand = comm;
                //Maak dat jy seker maak die value is die een wat jy wil delete

                if (MessageBox.Show("Are you sure you want to delete class " + tbDelete.Text.Trim(), "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK) { adap.DeleteCommand.ExecuteNonQuery(); updateDG(); }
                else
                {
                    MessageBox.Show("Canceled the deletion of class :" + tbDelete.Text); ;
                    tbID.Clear();
                    cmbClass.SelectedIndex = -1;
                    dtClassDate.Value = DateTime.Today;
                    tbClassTime.Clear();
                    tbDesc.Clear();
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

        private void btnAddEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int.TryParse(tbID.Text, out oldMemID);
                if (btAddEdit.Text == "Add Record")
                {
                    tbErrorTests();
                    if (MessageBox.Show("Are you sure you want to enter Class ?", "Adding Member", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                    {
                        conn.Open();
                        MessageBox.Show("Added new Class!");
                        string clsID = "Select Max(ClassID) FROM ClassType";
                        comm = new SqlCommand(clsID, conn);
                        read = comm.ExecuteReader();
                        if (read.HasRows)
                        {
                            while (read.Read())
                            {
                                if (!String.IsNullOrWhiteSpace(Convert.ToString(read.GetValue(0))))
                                {
                                    // MessageBox.Show(Convert.ToString(read.GetValue(0)));
                                    newClsID = int.Parse(Convert.ToString(read.GetValue(0)));
                                }
                                else
                                {
                                    newClsID = 0;
                                }
                            }
                        }
                        read.Close();
                        if (cmbClass.SelectedIndex != -1)
                        {
                            ClassType = cmbClass.GetItemText(cmbClass.SelectedItem);
                        }
                        else
                        {
                            MessageBox.Show("Please select what type of class you want to book", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        clsDate = dtClassDate.Value.Date;
                        clsTime = Convert.ToDateTime(tbClassTime.Text);
                        clsDesc = tbDesc.Text;
                        string add = "INSERT INTO ClassType(ClassID, ClassType, ClassTime, ClassDate, Description, Attendants) VALUES (@ID, @Type, @Time, @Date, @Desc, @Att) ";
                        comm = new SqlCommand(add, conn);
                        comm.Parameters.AddWithValue("@ID", newClsID + 1);
                        comm.Parameters.AddWithValue("@Type", ClassType);
                        comm.Parameters.AddWithValue("@Time", clsTime);
                        comm.Parameters.AddWithValue("@Date", clsDate);
                        comm.Parameters.AddWithValue("@Desc", clsDesc);
                        comm.Parameters.AddWithValue("@Att", clsAtt);
                        comm.ExecuteNonQuery();
                    }
                    else if (MessageBox.Show("Are yo sure you want to enter class ?", "Adding Class", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
                    {
                        MessageBox.Show("Canceled new Class");
                        tbID.Clear();
                        cmbClass.SelectedIndex = -1;
                        dtClassDate.Value = DateTime.Today;
                        tbClassTime.Clear();
                        tbDesc.Clear();
                    }
                    conn.Close();
                    updateDG();

                }
                else if (btAddEdit.Text == "Edit Record")
                {
                    tbErrorTests();

                    if (MessageBox.Show("Are yo sure you want to edit class ?", "Edited Class", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                    {
                        conn.Open();
                        if (!int.TryParse(lastProcessed, out oldClsID)) { tbID.Clear(); tbID.Focus(); throw new Exception("Insure that you have entered the correct Class ID"); }
                        string updateCls = "UPDATE ClassType SET ClassType = @Type, ClassTime = @Time, ClassDate = @Date, Description = @Desc WHERE ClassID = '" + oldClsID + "'";
                        comm = new SqlCommand(updateCls, conn);
                        if (cmbClass.SelectedIndex != -1)
                        {
                            ClassType = cmbClass.GetItemText(cmbClass.SelectedItem);
                        }
                        else
                        {
                            MessageBox.Show("Please select what type of class you want to book", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        clsTime = Convert.ToDateTime(tbClassTime.Text);
                        clsDesc = tbDesc.Text;
                        clsDate = dtClassDate.Value.Date;
                        comm.Parameters.AddWithValue("@Type", ClassType);
                        comm.Parameters.AddWithValue("@Time", clsTime);
                        comm.Parameters.AddWithValue("@Date", clsDate);
                        comm.Parameters.AddWithValue("@Desc", clsDesc);
                        comm.ExecuteNonQuery();
                        MessageBox.Show("Succesfully edited Class!");
                    }
                    else if (MessageBox.Show("Are yo sure you want to enter Class ?", "Cancelled  Class Edit", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
                    {
                        MessageBox.Show("Canceled new Class Edit");
                        tbID.Clear();
                        tbID.Clear();
                        cmbClass.SelectedIndex = -1;
                        dtClassDate.Value = DateTime.Today;
                        tbClassTime.Clear();
                        tbDesc.Clear();
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
        private void tbErrorTests()
        {
            //Errorhandling van textbox variables
            if (String.IsNullOrWhiteSpace(tbClassTime.Text)) { tbClassTime.Focus(); tbClassTime.Clear(); throw new Exception("Please enter a valid Class Time "); }
            if (String.IsNullOrWhiteSpace(tbDesc.Text)) { tbDesc.Focus(); tbDesc.Clear(); throw new Exception("Please enter a valid Class Description"); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tbClassType.Text))
            {
                cmbClass.Items.Add(tbClassType.Text);
                tbClassType.Clear();
                MessageBox.Show("Class type added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please enter the type of class you want to add!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelClass_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tbClassType.Text))
            {
                cmbClass.Items.Remove(tbClassType.Text);
                tbClassType.Clear();
                MessageBox.Show("Class type deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please enter the type of class you want to delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

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

        private async void tbID_TextChanged(object sender, EventArgs e)
        {
            //conn = new SqlConnection(Global.ConString);
            conn.Close();
            conn.Open();
            if (int.TryParse(tbID.Text, out oldMemID)) { }
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
                string fetchMember = "Select * FROM ClassType WHERE ClassID Like '" + oldMemID + "'";
                comm = new SqlCommand(fetchMember, conn);
                read = comm.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        cmbClass.SelectedItem = Convert.ToString(read.GetValue(1));
                        
                        tbClassTime.Text = Convert.ToString(read.GetValue(2));
                        dtClassDate.Text = Convert.ToString(read.GetValue(3));
                        tbDesc.Text = Convert.ToString(read.GetValue(4));
                        
                    }
                }
                read.Close();
                conn.Close();
            }
            catch (SqlException ae)
            {
                if (MessageBox.Show(ae.Message.ToString(), "ERROR!!", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) { conn.Close(); }
            }

            try
            {
                conn.Open();
                string sql = "SELECT * FROM ClassType WHERE ClassID Like '" + oldMemID + "'";
                comm = new SqlCommand(sql, conn);
                ds = new DataSet();
                adap = new SqlDataAdapter();

                adap.SelectCommand = comm;
                adap.Fill(ds, "SourceTable");

                dgvClasses.DataSource = ds;
                dgvClasses.DataMember = "SourceTable";
                conn.Close();
            }
            catch (SqlException error)
            {
                if (MessageBox.Show(error.Message.ToString(), "ERROR!!", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) { conn.Close(); }
            }

            if (String.IsNullOrEmpty(tbID.Text))
            {
                updateDG();
                tbID.Clear();
                cmbClass.SelectedIndex= -1;

                tbClassTime.Clear();
                dtClassDate.Value = DateTime.Today;
                tbDesc.Clear();
            }
            conn.Close();
        }
    }
}

