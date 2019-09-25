using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount
{
    public class BankAccount
    {
        private int id;
        private decimal balance;

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public decimal Balance
        {
            get { return this.balance; }
            set { this.balance = value; }
        }

        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }

        public void WithDraw(decimal amount)
        {
            this.Balance -= amount;
        }

        public void Print(int imputId)
        {
            Console.WriteLine($"Account ID{this.Id}, balance {this.Balance:f2}"); ;
        }
    }
}
