namespace BillsPaymentSystem.App.Core.Commands
{
    using System;
    using System.Linq;

    using Contracts;
    using Data;
    using Models;

    public class DepositCommand : ICommand
    {
        private readonly BillsPaymentSystemContext context;

        public DepositCommand(BillsPaymentSystemContext context)
        {
            this.context = context;
        }

        public string Execute(string[] args)
        {
            int userId = int.Parse(args[0]);
            decimal amount = decimal.Parse(args[1]);

            User user = context.Users
                .FirstOrDefault(u => u.UserId == userId);

            if (user == null)
            {
                throw new ArgumentNullException($"User with id {userId} not found!");
            }

            string result = string.Empty;
            decimal currentBalance = 0.0m;

            var bankAccounts = context.PaymentMethods
                .Where(pm => pm.UserId == userId && pm.BankAccount != null)
                .Select(pm => pm.BankAccount)
                .ToList();

            var creditCards = context
                .PaymentMethods
                .Where(pm => pm.UserId == userId && pm.CreditCard != null)
                .Select(pm => pm.CreditCard)
                .ToList();

            if (bankAccounts.Any())
            {
                currentBalance = bankAccounts
                    .FirstOrDefault().Balance += amount;
            }
            else if (creditCards.Any())
            {
                currentBalance = creditCards
                    .FirstOrDefault().Limit += amount;
            }
            else
            {
                throw new ArgumentNullException("User doesn't have a valid bank account or credit card!");
            }

            context.SaveChanges();

            result = $"Transaction completed! Balance after deposit: {currentBalance:f2}";

            return result;
        }
    }
}
