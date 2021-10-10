using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMPG_Group28_FinalProject
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(Global.ConString);
        SqlCommand comm;
        SqlDataReader read;
        MessageBoxButtons btn = MessageBoxButtons.OK;
        MessageBoxIcon info = MessageBoxIcon.Information;
        MessageBoxIcon warn = MessageBoxIcon.Warning;
        int NumBookings;
        int attYoga;
        int attPal;
        int attCross;
        int attSpin;

        public int countAtt;
        double paymentsMonth;
        double paymentsYear;
        DateTime today = DateTime.Today;
        DateTime monthAgo = DateTime.Today.AddMonths(-1);
        DateTime yearAgo = DateTime.Today.AddYears(-1);
        


        private void Reports_Load(object sender, EventArgs e)
        {
            cmbClass.Hide();

            rtbShowReport.AppendText("\n\n Managing your Gym since 2021");
            rtbShowReport.AppendText("\n\nReports will be show here \n");

            conn.Open();
            try
            {
                string sql = "Select Top 1 BookingID From Booking Where BookingDate Between '"+monthAgo+"' And '"+today+"' Order By BookingID Desc";
                comm = new SqlCommand(sql, conn);
                read = comm.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        NumBookings = Convert.ToInt32(read.GetValue(0));
                    }
                }
                read.Close();
                conn.Close();
                conn.Open();
                sql = "Select PaymentAmount From Payment Where PaymentDate Between '" + monthAgo + "' And '" + today + "'";
                comm = new SqlCommand(sql, conn);
                read = comm.ExecuteReader();
                if (read.HasRows)
                { 
                    //int c1 = 0;
                    while (read.Read())
                    {
                        paymentsMonth += Convert.ToDouble(read["PaymentAmount"]);
                        /*read.NextResult();
                        c1++;*/
                    }
                }
                read.Close();
                conn.Close();
                conn.Open();
                sql = "Select PaymentAmount From Payment Where PaymentDate Between '" + yearAgo + "' And '" + today + "'";
                comm = new SqlCommand(sql, conn);
                read = comm.ExecuteReader();
                if (read.HasRows)
                {
                    //int c2 = 0;
                    while (read.Read())
                    {
                        paymentsYear += Convert.ToDouble(read["PaymentAmount"]);
                        /*read.NextResult();
                        c2++;*/
                    }
                }
                read.Close();
                conn.Close();
             
            }
            catch (Exception ae)
            {
                MessageBox.Show(ae.ToString(), "", btn, warn);
                conn.Close();
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {


            rtbShowReport.Clear();

            /* rtbShowReport.AppendText("  __     ___ || __         ____      \n");
               rtbShowReport.AppendText(@" ||\\  //|| || ||__   ___  ||       \n");
               rtbShowReport.AppendText("  || \\// ||_|| || || || || || || || \n");
               rtbShowReport.AppendText("                      ___||    ___||  \n");
               rtbShowReport.AppendText("                      ----     ..... \n");*/

            if (cmbRepType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the type of report you wish to see", "", btn, warn);
            }
            else if (cmbRepType.SelectedIndex == 0)
            {
                rtbShowReport.AppendText("-------------------------------------------------------------------------------------------------------------------\n");
                rtbShowReport.AppendText("\nPayment ID\tBank_Account_Number\tPayment Amount\tPayment Date\n");
                rtbShowReport.AppendText("-------------------------------------------------------------------------------------------------------------------\n");


                conn.Open();
                string sqlPayments = "Select * From Payment ORDER BY PaymentAmount Desc";
                comm = new SqlCommand(sqlPayments, conn);
                read = comm.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        rtbShowReport.AppendText(Convert.ToString(read.GetValue(0)) + "|\t\t||\t\t" + Convert.ToString(read.GetValue(1)) + "\t\t||\t" + Convert.ToString(read.GetValue(2)) + "\t\t\t||" + Convert.ToString(read.GetValue(3)) + "\n");
                    }


                }
                read.Close();


                rtbShowReport.AppendText("\nTotal Income from payments in the last year: " + paymentsYear.ToString("C2",CultureInfo.CurrentCulture));
                conn.Close();


                rtbShowReport.AppendText("\n-------------------------------------------------------------------------------------------------------------------\n");
                rtbShowReport.AppendText("                                                          END OF REPORT\n");
                rtbShowReport.AppendText("-------------------------------------------------------------------------------------------------------------------\n");
            }
            else if (cmbRepType.SelectedIndex == 1)
            {
                rtbShowReport.AppendText("-------------------------------------------------------------------------------------------------------------------\n");
                rtbShowReport.AppendText("\nPayment ID\tBank_Account_Number\tPayment Amount\tPayment Date\n");
                rtbShowReport.AppendText("-------------------------------------------------------------------------------------------------------------------\n");

                conn.Open();
                string sqlPayments = "Select * From Payment Where PaymentDaTe >= '" + monthAgo.ToString() + "' ORDER BY PaymentAmount Desc";
                comm = new SqlCommand(sqlPayments, conn);
                read = comm.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        rtbShowReport.AppendText(Convert.ToString(read.GetValue(0)) + "|\t\t||\t\t" + Convert.ToString(read.GetValue(1)) + "\t\t||\t" + Convert.ToString(read.GetValue(2)) + "\t\t\t||" + Convert.ToString(read.GetValue(3)) + "\n");
                    }
                }
                read.Close();


                
                conn.Close();



                rtbShowReport.AppendText("\nTotal Income from payments in the last month: "+paymentsMonth.ToString("C2", CultureInfo.CurrentCulture));

                rtbShowReport.AppendText("\n----------------------------------------------------------------------------------------------------------------------------\n");
                rtbShowReport.AppendText("                                                          END OF REPORT\n");
                rtbShowReport.AppendText("--------------------------------------------------------------------------------------------------------------------------\n");
            }
            else if (cmbRepType.SelectedIndex == 2)
            {
                rtbShowReport.AppendText("-------------------------------------------------------------------------------------------------------------------------------------\n");
                rtbShowReport.AppendText("CLassId ID \t\t Class Type \t ClassTime \t\t Class Date\t\t\t\t     Description \t Attendants\n");
                rtbShowReport.AppendText("-------------------------------------------------------------------------------------------------------------------------------------\n");
                 
                conn.Open();


                string sqlPayments = "Select * From ClassType  ORDER BY Attendants Desc";
                comm = new SqlCommand(sqlPayments, conn);
                read = comm.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        rtbShowReport.AppendText(Convert.ToString(read.GetValue(0)) + "\t\t\t" + Convert.ToString(read.GetValue(1)) + "\t\t\t" + Convert.ToString(read.GetValue(2)) + "\t\t" + Convert.ToString(read.GetValue(3)) + "\t\t" + Convert.ToString(read.GetValue(4)) + "\t\t" + Convert.ToString(read.GetValue(5)) + "\n");
                    }
                }
                read.Close();

                rtbShowReport.AppendText("                                                          \nNumber of Attendants for eacb class for all time\n");
                rtbShowReport.AppendText("----------------------------------------------------------------------------------------------------------------------------------\n");
                try
                { 
                    string updateCB = "Select ClassType,Attendants From ClassType";
                    comm = new SqlCommand(updateCB, conn);
                    read = comm.ExecuteReader();
                    if (read.HasRows)
                    {
                        while (read.Read())
                        {
                            if (!String.IsNullOrWhiteSpace(Convert.ToString(read.GetValue(0))))
                            {
                                string ClassType = Convert.ToString(read.GetValue(0));
                                if (!cmbClass.Items.Contains(ClassType))
                                {
                                    rtbShowReport.AppendText( "Class :" + Convert.ToString(read.GetValue(0)) + "\t\t Attendants\t" + Convert.ToString(read.GetValue(1)) + "\n");
                                }

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
                    rtbShowReport.AppendText("\n--------------------------------------------------------------------------------------------------------------------------------\n");
                    rtbShowReport.AppendText("                                                          END OF REPORT\n");
                    rtbShowReport.AppendText("----------------------------------------------------------------------------------------------------------------------------------\n");
            }
            else if (cmbRepType.SelectedIndex == 3)
            {



                rtbShowReport.AppendText("-------------------------------------------------------------------------------------------------------------------------------------\n");
                rtbShowReport.AppendText("CLassId ID \t\t Class Type \t ClassTime \t\t Class Date\t\t\t\t     Description \t Attendants\n");
                rtbShowReport.AppendText("-------------------------------------------------------------------------------------------------------------------------------------\n");

                conn.Open();


                string sqlPayments = "Select * From ClassType Where ClassDate >= '"  + monthAgo    + "' ORDER BY Attendants Desc";
                comm = new SqlCommand(sqlPayments, conn);
                read = comm.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        rtbShowReport.AppendText(Convert.ToString(read.GetValue(0)) + "\t\t\t" + Convert.ToString(read.GetValue(1)) + "\t\t\t" + Convert.ToString(read.GetValue(2)) + "\t\t" + Convert.ToString(read.GetValue(3)) + "\t\t" + Convert.ToString(read.GetValue(4)) + "\t\t" + Convert.ToString(read.GetValue(5)) + "\n");
                    }
                }
                read.Close();

                rtbShowReport.AppendText("                                                          \nNumber of Attendants for eacb class for all time\n");
                rtbShowReport.AppendText("----------------------------------------------------------------------------------------------------------------------------------\n");
                try
                {
                    string updateCB = "Select ClassType,Attendants From ClassType";
                    comm = new SqlCommand(updateCB, conn);
                    read = comm.ExecuteReader();
                    if (read.HasRows)
                    {
                        while (read.Read())
                        {
                            if (!String.IsNullOrWhiteSpace(Convert.ToString(read.GetValue(0))))
                            {
                                string ClassType = Convert.ToString(read.GetValue(0));
                                if (!cmbClass.Items.Contains(ClassType))
                                {
                                    rtbShowReport.AppendText("Class :" + Convert.ToString(read.GetValue(0)) + "\t\t Attendants\t" + Convert.ToString(read.GetValue(1)) + "\n");
                                    countAtt += Convert.ToInt32(read.GetValue(1));
                                }

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

                rtbShowReport.AppendText("\nNumber of bookings in the last month: " + countAtt);

                rtbShowReport.AppendText("\n-------------------------------------------------------------------------------------------------------------------\n");
                rtbShowReport.AppendText("                                                          END OF REPORT\n");
                rtbShowReport.AppendText("-------------------------------------------------------------------------------------------------------------------\n");
            }
            conn.Close();
        }

        private void cmbRepType_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtbShowReport.Clear();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btSave_Click(object sender, EventArgs e)
        {
            StreamWriter outputfile;

            try
            {
                if (saveD.ShowDialog() == DialogResult.OK)
                {
                    string path = saveD.FileName;

                    outputfile = File.CreateText(path + ".txt");
                    outputfile.WriteLine(rtbShowReport.Text);
                    outputfile.Close();


                    MessageBox.Show("Saved Report Succesfully");
                }
                else
                {
                    MessageBox.Show("No File Selected");
                }

            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
