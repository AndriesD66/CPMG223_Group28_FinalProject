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
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(Global.ConString);
        SqlCommand comm;
        SqlDataAdapter adap;
        SqlTransaction transact;
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
            checkAdmin();
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
                if ((BankAcc != tbBank.Text.Trim() || String.IsNullOrWhiteSpace(tbBank.Text.Trim()) )) throw new Exception("Enter a valid bank account number!"); 
                if (String.IsNullOrWhiteSpace(tbAmount.Text.Trim()) || !(double.Parse(tbAmount.Text.Trim()) >= 100.00)) { throw new Exception("Enter a valid ammount that is exceeding a R100 !"); }
                string message = "Are you sure you want to make payment for bank account num :" + tbBank.Text.ToString() + " for the amount of R " + tbAmount.Text.ToString() + "?";
                if (MessageBox.Show(message.ToString(), "Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if ((BankAcc == tbBank.Text) && (tbAmount.Text != ""))
                    {
                        int PayID = 0;
                        BankAcc = tbBank.Text;
                        Amount = Convert.ToDouble(tbAmount.Text);
                        PayDate = dtPay.Value.Date;
                        string sql1 = "Select Top 1 PaymentID From Payment Order By PaymentID Desc";
                        comm = new SqlCommand(sql1, conn);
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
                        transact = conn.BeginTransaction("Add Payment");
                        string sqlPay = "Insert Payment(PaymentID, Bank_Account_Number, PaymentAmount, PaymentDate) Values (" + PayID + ", '" + BankAcc + "', " + Amount + ", '" + PayDate + "')";
                        comm = new SqlCommand(sqlPay, conn);
                        comm.Transaction = transact;
                        comm.ExecuteNonQuery();
                        MessageBox.Show("Payment has been logged", "", btn, info);
                        transact.Commit();
                        string updateSql = "Select * From Payment";
                        adap = new SqlDataAdapter(updateSql, conn);
                        adap = new SqlDataAdapter(updateSql, conn);
                        DataTable dt = new DataTable();
                        adap.Fill(dt);
                        dgvPay.DataSource = dt;
                        dt.AcceptChanges();
                    }
                }
                else if ((tbAmount.Text == "") && (BankAcc != tbBank.Text))
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
                conn.Close();
            }
            if(frmHome.LoggedIn)
            {
                UpdateDGNonAdmin();
            }
            else
            {
                UpdateDG();
            }
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            checkAdmin();
        }

        private void UpdateDG()
        {
            conn.Open();
            string sql = "Select * From Payment";
            adap = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dgvPay.DataSource = dt;
            conn.Close();
        }

        private void UpdateDGNonAdmin()
        {
            conn.Close();
            conn.Open();
            string getDG = "Select * From Payment Where Bank_Account_Number = '" + BankAcc + "'";
            adap = new SqlDataAdapter(getDG, conn);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dgvPay.DataSource = dt;
            conn.Close();
        }

        public void checkAdmin()
        {
            try
            {
                if (frmHome.LoggedIn)
                {
                    conn.Open();
                    string memId = frmHome.membeID.ToString();
                    string getBankNum = "Select Bank_Account_Number From Member Where MemberID = '" + memId + "'";
                    comm = new SqlCommand(getBankNum, conn);
                    read = comm.ExecuteReader();
                    if (read.HasRows)
                    {
                        while (read.Read())
                        {
                            if (!String.IsNullOrWhiteSpace(Convert.ToString(read.GetValue(0))))
                            {
                                BankAcc = Convert.ToString(read.GetValue(0));
                            }
                        }
                    }
                    read.Close();

                    tbBank.Text = BankAcc;
                    tbBank.Enabled = false;
                    UpdateDGNonAdmin();
                    conn.Close();
                }
                else
                {
                    UpdateDG();
                }
            }
            catch (SqlException ae)
            {
                MessageBox.Show(ae.ToString(), "", btn, warn);
                conn.Close();
            }
        }
    }
}
