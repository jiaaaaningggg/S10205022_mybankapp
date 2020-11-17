using System;
using System.Collections.Generic;
using System.Text;

namespace S10205022_mybankapp
{
    class BankAccount
    {
        private string accNo;

        public string ACCno
        {
            get { return accNo; }
            set { accNo = value; }
        }

        private string accName;

        public string ACCname
        {
            get { return accName; }
            set { accName = value; }
        }

        private double balance;

        public double Bal
        {
            get { return balance; }
            set { balance = value; }
        }
        public BankAccount() { }

        public BankAccount(string a, string n , double b)
        {
            ACCno = a;
            ACCname = n;
            Bal = b;
        }

        public void Deposit(double amount)
        {
            Bal += amount;
         
        }

        public bool Withdraw(double amount)
        {
            if (amount <= Bal)
            {
                Bal -= amount;
                return true;
            }
            else
                return false;
        }


        public override string ToString()
        {
            return "Account Number:" + ACCno + "Account Name:" + ACCname + "Balance:" + Bal;

        }
    }
}
