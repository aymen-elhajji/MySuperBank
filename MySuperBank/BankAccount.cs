﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySuperBank
{
    public class BankAccount
    {
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions) 
                {
                    balance += item.Amount;
                }
                return balance;
            }

        }

        private static int accountNumberSeed = 1234567890;
        private List<Transaction> allTransactions = new List<Transaction>();

        public BankAccount(string Name, decimal InitialBalance)
        {
            this.Owner = Name;

            MakingDeposit(InitialBalance, DateTime.Now, "Initial Balance");

            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;
        }
       
        public void MakingDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0) 
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }
        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficent funds for this withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }

        public string GetAccountHistory()
        {
            var report = new StringBuilder();

            //HEADER
            report.AppendLine("Date\t\tAmmount\tNote");

            foreach (var item in allTransactions)
            {
                //ROWS
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{item.Notes}");
            }
            return report.ToString();
        }

    }
}
