using System;
using System.Collections.Generic;
using System.Text;

namespace S10205022_mybankapp
{
    class SavingsAccount:BankAccount
    {
        private double rate;

        public double Rate
        {
            get { return rate; }
            set { rate = value; }
        }

        public SavingsAccount() :base() { }

        public SavingsAccount(string a, string n, double b, double r ):base(a,n,b)
        {
            rate = r; 
        }

        public double CalculateInterest()
        {
            return Bal * rate / 100;
        }
        public override string ToString()
        {
            return base.ToString() + "Rate:" + rate + '%';
        }

    }
}
