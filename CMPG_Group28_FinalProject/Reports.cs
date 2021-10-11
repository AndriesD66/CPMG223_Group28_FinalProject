using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
        public string ClassType;
        public int countAttendees= 0;
        double paymentsMonth;
        double paymentsYear;
        DateTime today = DateTime.Today;
        DateTime monthAgo = DateTime.Today.AddMonths(-1);
        DateTime yearAgo = DateTime.Today.AddYears(-1);

        private void Reports_Load(object sender, EventArgs e)
        {
            rtbShowReport.AppendText("Reports will be show here \n");
            cmbClass.Hide();
            populateCB();

            conn.Open();
            try
            {
                string sql = "Select Top 1 BookingID From Booking Where BookingDate Between '" + monthAgo + "' And '" + today + "' Order By BookingID Desc";
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
                        paymentsYear += Convert.ToDouble(read["PaymentAmount"].ToString());
                        /* / read.NextResult();
                         c2++;/*/
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

        /*
        Income in  the last year
        Income in the last month
        Class attendance summary
        Number of bookings in the last month*/
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (cmbRepType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the type of report you wish to see", "", btn, warn);

            }
            else if (cmbRepType.SelectedIndex == 0)
            {
                rtbShowReport.Clear();
                rtbShowReport.AppendText("-------------------------------------------------------------------------------------------------------------------------------------------\n");
                rtbShowReport.AppendText("                                               INCOME Summary OF PREVIOUS YEAR\n");
                rtbShowReport.AppendText("-------------------------------------------------------------------------------------------------------------------------------------------\n");
                rtbShowReport.AppendText("Payment ID\t\tBank Account Number\t\t Payment Amount\t\tPayment Date\n");
                rtbShowReport.AppendText("-------------------------------------------------------------------------------------------------------------------------------------------\n");

                conn.Open();
                string sql = "SELECT * FROM Payment Where PaymentDate Between '" + yearAgo + "' And '" + today + "'";
                comm = new SqlCommand(sql, conn);

                read = comm.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        rtbShowReport.AppendText(Convert.ToString(read.GetValue(0)) + "\t\t\t\t" + Convert.ToString(read.GetValue(1)) + "\t\t\t\t" + Convert.ToString(read.GetValue(2)) + "\t\t\t\t" + Convert.ToString(read.GetValue(3)) + "\n");
                    }
                }
                read.Close();
                conn.Close();




                rtbShowReport.AppendText("\n-------------------------------------------------------------------------------------------------------------------------------------------\n");
                rtbShowReport.AppendText("                                               TOTAL PAYMENTS FROM LAST YEAR\n");
                rtbShowReport.AppendText("-------------------------------------------------------------------------------------------------------------------------------------------\n");

                rtbShowReport.AppendText("\nTotal Income from payments in the last year: " + paymentsYear.ToString("C2", CultureInfo.CurrentCulture));

                rtbShowReport.AppendText("\n-------------------------------------------------------------------------------------------------------------------------------------------\n");
                rtbShowReport.AppendText("                                                                         END OF REPORT\n");
                rtbShowReport.AppendText("-------------------------------------------------------------------------------------------------------------------------------------------\n");
            }
            else if (cmbRepType.SelectedIndex == 1)
            {
                rtbShowReport.Clear();
                rtbShowReport.AppendText("-------------------------------------------------------------------------------------------------------------------------------------------\n");
                rtbShowReport.AppendText("                                              INCOME IN THE LAST MONTH\n");
                rtbShowReport.AppendText("-------------------------------------------------------------------------------------------------------------------------------------------\n");
                rtbShowReport.AppendText("Payment ID\t\tBank Account Number\t\t Payment Amount\t\tPayment Date\n");
                rtbShowReport.AppendText("-------------------------------------------------------------------------------------------------------------------------------------------\n");

                conn.Open();
                string sql = "SELECT * FROM Payment Where PaymentDate Between '" + monthAgo + "' And '" + today + "'";
                comm = new SqlCommand(sql, conn);

                read = comm.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        rtbShowReport.AppendText(Convert.ToString(read.GetValue(0)) + "\t\t\t\t" + Convert.ToString(read.GetValue(1)) + "\t\t\t\t" + Convert.ToString(read.GetValue(2)) + "\t\t\t\t" + Convert.ToString(read.GetValue(3)) + "\n");
                    }
                }
                read.Close();
                conn.Close();

                rtbShowReport.AppendText("\n-------------------------------------------------------------------------------------------------------------------------------------------\n");
                rtbShowReport.AppendText("                                               TOTAL PAYMENTS FROM LAST MONTH\n");
                rtbShowReport.AppendText("-------------------------------------------------------------------------------------------------------------------------------------------\n");

                rtbShowReport.AppendText("\nTotal Income from payments in the last month: " + paymentsMonth.ToString("C2", CultureInfo.CurrentCulture));


                rtbShowReport.AppendText("\n-------------------------------------------------------------------------------------------------------------------------------------------\n");
                rtbShowReport.AppendText("                                                               END OF REPORT\n");
                rtbShowReport.AppendText("-------------------------------------------------------------------------------------------------------------------------------------------\n");
            }
            else if (cmbRepType.SelectedIndex == 2)
            {
                countAttendees = 0;
                rtbShowReport.Clear();
                rtbShowReport.AppendText("-------------------------------------------------------------------------------------------------------------------------------------------\n");
                rtbShowReport.AppendText("                                               CLASS ATTENDANCE SUMMARY\n");
                rtbShowReport.AppendText("-------------------------------------------------------------------------------------------------------------------------------------------\n");

                rtbShowReport.AppendText("Class Id\t\tClass Type\t\tClass Time\t\tClass Date\t\t\t\tDescription\t\tAttendants\n");
                rtbShowReport.AppendText("-------------------------------------------------------------------------------------------------------------------------------------------\n");



                try
                {
                    conn.Open();

                    string updateCB = "Select * From ClassType";
                    comm = new SqlCommand(updateCB, conn);
                    read = comm.ExecuteReader();
                    if (read.HasRows)
                    {
                        while (read.Read())
                        {

                            ClassType = Convert.ToString(read.GetValue(2));
                            if (!cmbClass.Items.Contains(ClassType))
                            {
                                rtbShowReport.AppendText(Convert.ToString(read.GetValue(0)) + "\t\t\t" + Convert.ToString(read.GetValue(1)) +"\t\t\t" +Convert.ToString(read.GetValue(2)) + "\t\t" + Convert.ToString(read.GetValue(3)) + "\t\t"+ Convert.ToString(read.GetValue(4)) + "\t\t" + Convert.ToString(read.GetValue(5)) + "\n");
                                countAttendees += Convert.ToInt32(read.GetValue(5));
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







                rtbShowReport.AppendText("\n-------------------------------------------------------------------------------------------------------------------------------------------\n");
                rtbShowReport.AppendText("                                             NUMBER OF BOOKINGS \n");
                rtbShowReport.AppendText("-------------------------------------------------------------------------------------------------------------------------------------------\n");

                rtbShowReport.AppendText("\nTotal class bookings for last month " + countAttendees);


                rtbShowReport.AppendText("\n-------------------------------------------------------------------------------------------------------------------------------------------\n");
                rtbShowReport.AppendText("                                               END OF REPORT\n");
                rtbShowReport.AppendText("-------------------------------------------------------------------------------------------------------------------------------------------\n");
            }
            else if (cmbRepType.SelectedIndex == 3)
            {
                countAttendees = 0;
                rtbShowReport.Clear();
                rtbShowReport.AppendText("-------------------------------------------------------------------------------------------------------------------------------------------\n");
                rtbShowReport.AppendText("                                               SUMMARY OF BOOKINGS FOR THE LAST MONTH\n");
                rtbShowReport.AppendText("-------------------------------------------------------------------------------------------------------------------------------------------\n");


                rtbShowReport.AppendText("Class Id\t\tClass Type\t\tClass Time\t\tClass Date\t\t\t\tDescription\t\tAttendants\n");
                rtbShowReport.AppendText("-------------------------------------------------------------------------------------------------------------------------------------------\n");






                try
                {
                    conn.Open();

                    string updateCB = "Select * From ClassType WHERE ClassDate BETWEEN '" + monthAgo + "' And '" + today + "'"; ;
                    comm = new SqlCommand(updateCB, conn);
                    read = comm.ExecuteReader();
                    if (read.HasRows)
                    {
                        while (read.Read())
                        {

                            ClassType = Convert.ToString(read.GetValue(2));
                            if (!cmbClass.Items.Contains(ClassType))
                            {
                                rtbShowReport.AppendText(Convert.ToString(read.GetValue(0)) + "\t\t\t" + Convert.ToString(read.GetValue(1)) + "\t\t\t" + Convert.ToString(read.GetValue(2)) + "\t\t" + Convert.ToString(read.GetValue(3)) + "\t\t" + Convert.ToString(read.GetValue(4)) + "\t\t" + Convert.ToString(read.GetValue(5)) + "\n");
                                countAttendees += Convert.ToInt32(read.GetValue(5));
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





                rtbShowReport.AppendText("\n-------------------------------------------------------------------------------------------------------------------------------------------\n");
                rtbShowReport.AppendText("                                               NUMBER OF BOOKINGS FOR THE LAST MONTH\n");
                rtbShowReport.AppendText("-------------------------------------------------------------------------------------------------------------------------------------------\n");


                rtbShowReport.AppendText("\nTotal class bookings for last month " + countAttendees);

                rtbShowReport.AppendText("\n-------------------------------------------------------------------------------------------------------------------------------------------\n");
                rtbShowReport.AppendText("                                               END OF REPORT\n");
                rtbShowReport.AppendText("-------------------------------------------------------------------------------------------------------------------------------------------\n");
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            StreamWriter outputFile;

            try
            {
                if (saveD.ShowDialog() == DialogResult.OK)
                {
                    string path = saveD.FileName;
                    outputFile = File.CreateText(path = ".txt");
                    outputFile.WriteLine(rtbShowReport.Text);
                    outputFile.Close();
                    MessageBox.Show("Saved Report succesfully");
                }
                else
                {
                    MessageBox.Show("No file selected");
                }


            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }






        }

        private void cmbRepType_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtbShowReport.Clear();
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
    }
}