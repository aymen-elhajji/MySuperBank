using System;

namespace MySuperBank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Aymen",1500);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance}.");

            account.MakeWithdrawal(60, DateTime.Now, "Hammock");
            account.MakeWithdrawal(60, DateTime.Now, "Xbox Game");
            



            Console.WriteLine(account.GetAccountHistory());











            ////This is a comment

            ////Test for negative balance 
            //try
            //{
            //    account.MakeWithdrawal(150, DateTime.Now, "Attempt to overdraw");
            //}
            //catch (InvalidOperationException e)
            //{
            //    Console.WriteLine("Exception caught trying to overdraw");
            //    Console.WriteLine(e.ToString());
            //}

            ////Test that the initial balance must be positive
            //try
            //{
            //    var invalidAccount = new BankAccount("Invalid", -55);
            //}
            //catch (ArgumentOutOfRangeException e)
            //{
            //    Console.WriteLine("Exception caught creating account with negative balance");
            //    Console.WriteLine(e.ToString());
            //}


        }
    }
}
