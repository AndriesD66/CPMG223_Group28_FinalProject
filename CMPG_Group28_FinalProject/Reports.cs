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

namespace CMPG_Group28_FinalProject
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        SqlCommand comm;
        SqlDataAdapter adap;
        SqlDataReader read;
        MessageBoxButtons btn = MessageBoxButtons.OK;
        MessageBoxIcon info = MessageBoxIcon.Information;
        MessageBoxIcon warn = MessageBoxIcon.Warning;
        int NumBookings;
        double[] paymentsMonth = new double[31];
        double[] paymentsYear = new double[365];
        DateTime today = DateTime.Today;
        DateTime monthAgo = DateTime.Today.AddMonths(-1);
        DateTime yearAgo = DateTime.Today.AddYears(-1);

        private void Reports_Load(object sender, EventArgs e)
        {
            DataSet book, enter, pay;
            conn = new SqlConnection(Global.ConString);
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
                    int c1 = 0;
                    while (read.Read())
                    {
                        paymentsMonth[c1] = Convert.ToDouble(read.GetValue(c1));
                        c1++;
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
                    int c2 = 0;
                    while (read.Read())
                    {
                        paymentsYear[c2] = Convert.ToDouble(read.GetValue(c2));
                        c2++;
                    }
                }

                conn.Close();
            }
            catch (Exception ae)
            {
                MessageBox.Show(ae.ToString(), "", btn, warn);
                conn.Close();
            }
            //read.Close();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (cmbRepType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the type of report you wish to see", "", btn, warn);
            }
            else if (cmbRepType.SelectedIndex == 0)
            {
                rtbShowReport.AppendText("\n Total Income from payments in the last year: " + paymentsYear.Sum().ToString(CultureInfo.CurrentCulture));
            }
            else if (cmbRepType.SelectedIndex == 1)
            {
                rtbShowReport.AppendText("\n Total Income from payments in the last month: "+paymentsMonth.Sum().ToString(CultureInfo.CurrentCulture));
            }
            else if (cmbRepType.SelectedIndex == 3)
            {
                rtbShowReport.AppendText("\n Number of bookings in the last month: " + NumBookings);
            }
        }
    }
}
