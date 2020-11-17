using System;
using System.IO;
using System.Collections.Generic;

namespace S10205022_mybankapp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<SavingsAccount> sList = new List<SavingsAccount>();
            initializing(sList);
            DisplayMenu(sList);
            
        }







        static void initializing(List<SavingsAccount> sList)
        {
            using (StreamReader sr = new StreamReader("savings_account(2).csv"))
            {

                string s = sr.ReadLine(); // read the heading

                //string[] heading = s.Split(',');

                while ((s = sr.ReadLine()) != null)
                {
                    string[] content = s.Split(',');
                    string accNo = content[0];
                    string accName = content[1];
                    double balance = Convert.ToDouble(content[2]);
                    double rate = Convert.ToDouble(content[3]);
                    sList.Add(new SavingsAccount(accNo, accName, balance, rate));

                }


            }


        }
        static void DisplayMenu(List<SavingsAccount> sList)
        {
            Console.WriteLine("Menu");
            Console.WriteLine("[1] Display all accounts");
            Console.WriteLine("[2] Deposit");
            Console.WriteLine("[3] Withdraw");
            Console.WriteLine("[4] Display details");
            Console.WriteLine("[0] Exit");
            
            
            while (true)
            {
                Console.Write("Enter your options:");
                int input = Convert.ToInt32(Console.ReadLine());
                if (input == 1)
                {
                    DisplayAll(sList);
                }
                else if (input == 2)
                {
                    Console.Write("Enter the Account Number:");
                    string accnumber = Console.ReadLine();
                    SearchAcc(sList, accnumber);
                    if ((SearchAcc(sList, accnumber)) == null)
                    {
                        Console.WriteLine("Unable to find account number. Please try again.");
                    }
                    else
                    {
                        Console.Write("Amount to deposit: ");
                        int amount = Convert.ToInt32(Console.ReadLine());
                        SearchAcc(sList, accnumber).Deposit(amount);
                        Console.WriteLine(amount + " deposited succesfully");
                        var i = SearchAcc(sList, accnumber);
                        Console.WriteLine("Acc number: {0,-10} Acc Name: {1,-10} Balance: {2,-10} Rate: {3,-10} ",
                                                i.ACCno, i.ACCname, i.Bal, i.Rate);
                    }
                }
                else if (input == 3)
                {
                    Console.Write("Enter the Account Number:");
                    string accnumber = Console.ReadLine();
                    if ((SearchAcc(sList, accnumber)) == null)
                    {
                        Console.WriteLine("Unable to find account number. Please try again.");
                    }
                    else
                    {
                        Console.Write("Enter amount to withdraw:");
                        int withdraw_amt = Convert.ToInt32(Console.ReadLine());
                        //SearchAcc(sList, accnumber).Withdraw(withdraw_amt);
                        bool tf = SearchAcc(sList, accnumber).Withdraw(withdraw_amt);
                        if (tf)
                        {
                            Console.WriteLine(withdraw_amt + " withdrawn successfully");
                            var i = SearchAcc(sList, accnumber);
                            Console.WriteLine("Acc number: {0,-10} Acc Name: {1,-10} Balance: {2,-10} Rate: {3,-10} ",
                                                    i.ACCno, i.ACCname, i.Bal, i.Rate);

                        }
                        else
                        {
                            Console.WriteLine("Insufficient funds");
                        }

                    }

                }
                else if (input==4)
                {
                    Console.WriteLine("{0,-10}  {1,-10}  {2,-10}  {3,-10} {4,-10}",
                       "Acc No", "Acc Name", "Balance", "Rate","Interest Amt");

                    foreach (SavingsAccount s in sList)
                    {
                        Console.WriteLine("{0,-10}  {1,-10}  {2,-10}  {3,-10} {4,-10} ",
                                s.ACCno, s.ACCname, s.Bal, s.Rate, s.CalculateInterest());
                    }
                }
                else if (input == 0)
                {

                    break;

                }
                
            }
            Console.WriteLine("Bye");


        }

        static void DisplayAll(List<SavingsAccount> sList)
        {
            

            foreach (SavingsAccount s in sList)
            {
                Console.WriteLine("Acc number: {0,-10} Acc Name: {1,-10} Balance: {2,-10} Rate: {3,-10} ",
                        s.ACCno, s.ACCname, s.Bal, s.Rate);
            }
        }

        static SavingsAccount SearchAcc(List<SavingsAccount> sList, string accNo)
        {
            foreach (SavingsAccount j in sList)
            {
                if (j.ACCno == accNo)
                {
                    return j;
                    

                }

            }
            return null;
        }

    }
}
