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
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        SqlCommand comm;
        SqlDataAdapter adap;
        SqlDataReader read;
        DataSet ds;
        string BankAcc = "";
        double Amount;
        DateTime PayDate;
        MessageBoxButtons btn = MessageBoxButtons.OK;
        MessageBoxIcon warn = MessageBoxIcon.Warning;
        MessageBoxIcon info = MessageBoxIcon.Information;


        private void btnPay_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(Global.ConString);
            try
            {
                conn.Open();
                string sql = "Select * from Member Where Bank_Account_Number = '" + tbBank.Text.Trim() + "'";
                comm = new SqlCommand(sql, conn);
                read = comm.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        if (!String.IsNullOrWhiteSpace(Convert.ToString(read.GetValue(0))))
                        {
                            BankAcc = read["Bank_Account_Number"].ToString();
                        }
                    }
                }
                read.Close();
                if ((BankAcc == tbBank.Text) && (tbAmount.Text != ""))
                {
                    int PayID = 0;
                    BankAcc = tbBank.Text;
                    Amount = Convert.ToDouble(tbAmount.Text);
                    PayDate = dtPay.Value.Date;
                    sql = "Select Top 1 PaymentID From Payment Order By PaymentID Desc";
                    comm = new SqlCommand(sql, conn);
                    read = comm.ExecuteReader();
                    if (read.HasRows)
                    {
                        while (read.Read())
                        {
                            PayID = Convert.ToInt32(read["PaymentID"].ToString());
                        }
                    }
                    read.Close();
                    PayID++;
                    sql = "Insert Payment(PaymentID, Bank_Account_Number, PaymentAmount, PaymentDate) Values (" + PayID + ", '" + BankAcc + "', " + Amount + ", '" + PayDate + "')";
                    comm = new SqlCommand(sql, conn);
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Payment has been logged", "", btn, info);
                }
                else if ((tbAmount.Text == "") || (BankAcc != tbBank.Text))
                {
                    MessageBox.Show("Please enter a valid amount and Bank Account Number", "", btn, warn);
                    tbBank.Clear();
                    tbBank.Focus();
                    tbAmount.Clear();
                    BankAcc = "";
                    Amount = 0.00;
                }
                conn.Close();
            }
            catch (Exception ae)
            {
                MessageBox.Show(ae.Message.ToString(), "", btn, warn);
            }
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(Global.ConString);
            conn.Open();
            conn.Close();
        }
    }
}
