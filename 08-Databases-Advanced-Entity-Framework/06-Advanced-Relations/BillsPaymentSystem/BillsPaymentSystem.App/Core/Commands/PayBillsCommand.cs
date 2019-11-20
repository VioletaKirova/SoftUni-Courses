namespace BillsPaymentSystem.App.Core.Commands
{
    using System;
    using System.Linq;

    using Contracts;
    using Data;
    using Models;

    public class PayBillsCommand : ICommand
    {
        private readonly BillsPaymentSystemContext context;

        public PayBillsCommand(BillsPaymentSystemContext context)
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

            var bankAccounts = context.PaymentMethods
                .Where(pm => pm.UserId == userId && pm.BankAccount != null)
                .Select(pm => pm.BankAccount)
                .OrderBy(pm => pm.BankAccountId)
                .ToList();

            var creditCards = context.PaymentMethods
                .Where(pm => pm.UserId == userId && pm.CreditCard != null)
                .Select(pm => pm.CreditCard)
                .OrderBy(pm => pm.CreditCardId)
                .ToList();

            int bankAccountIndex = 0;

            if (bankAccounts.Any())
            {
                while (amount > 0 && bankAccountIndex != bankAccounts.Count)
                {
                    var currentBankAccount = bankAccounts[bankAccountIndex];
                    amount -= currentBankAccount.Balance;

                    if (amount < 0)
                    {
                        bankAccounts[bankAccountIndex].Balance = amount * (-1);
                    }
                    else
                    {
                        bankAccounts[bankAccountIndex].Balance = 0;
                    }

                    bankAccountIndex++;
                }
            }

            int creditCardIndex = 0;

            if (amount > 0 && creditCards.Any())
            {
                while (amount > 0 && creditCardIndex != creditCards.Count)
                {
                    var currentCreditCard = creditCards[creditCardIndex];

                    if (currentCreditCard.LimitLeft == 0)
                    {
                        creditCardIndex++;
                        continue;
                    }

                    var currentAmount = amount;
                    amount -= currentCreditCard.LimitLeft;

                    if (amount < 0)
                    {
                        creditCards[creditCardIndex].Limit += currentAmount + amount;
                    }
                    else
                    {
                        creditCards[creditCardIndex].Limit = creditCards[creditCardIndex].MoneyOwed;
                    }

                    creditCardIndex++;
                }
            }

            if (amount <= 0)
            {
                context.SaveChanges();
                result = "Transaction completed!";
            }
            else
            {
                result = "Insufficient funds!";
            }

            return result;
        }
    }
}
