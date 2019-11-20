namespace BillsPaymentSystem.App.Core.Commands
{
    using System;
    using System.Linq;

    using Contracts;
    using Data;
    using Models;

    public class WithdrawCommand : ICommand
    {
        private readonly BillsPaymentSystemContext context;

        public WithdrawCommand(BillsPaymentSystemContext context)
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

            bool hasEnoughMoney = false;

            var bankAccounts = context.PaymentMethods
                .Where(pm => pm.UserId == userId && pm.BankAccount != null)
                .Select(pm => pm.BankAccount)
                .ToList();

            var creditCards = context.PaymentMethods
                .Where(pm => pm.UserId == userId && pm.CreditCard != null)
                .Select(pm => pm.CreditCard)
                .ToList();

            if (!bankAccounts.Any() && !creditCards.Any())
            {
                throw new ArgumentNullException("User doesn't have a valid bank account or credit card!");
            }

            if (bankAccounts.Any())
            {
                foreach (var bankAccount in bankAccounts)
                {
                    if (bankAccount.Balance >= amount)
                    {
                        hasEnoughMoney = true;
                        currentBalance = bankAccount.Balance -= amount;
                        break;
                    }
                }
            }

            if (creditCards.Any() && !hasEnoughMoney)
            {
                foreach (var creditCard in creditCards)
                {
                    if (creditCard.LimitLeft >= amount)
                    {
                        hasEnoughMoney = true;
                        currentBalance = creditCard.Limit -= amount;
                        break;
                    }
                }
            }

            if (!hasEnoughMoney)
            {
                result = "Insufficient amount!";
            }
            else
            {
                context.SaveChanges();

                result = $"Transaction completed! Balance after withdraw: {currentBalance:f2}";
            }

            return result;
        }
    }
}
