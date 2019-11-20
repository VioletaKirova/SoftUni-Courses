namespace BillsPaymentSystem.App.Core.Commands
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Data;
    using Models;
    using Models.Enums;

    public class UserDetailsCommand : ICommand
    {
        private readonly BillsPaymentSystemContext context;

        public UserDetailsCommand(BillsPaymentSystemContext context)
        {
            this.context = context;
        }

        public string Execute(string[] args)
        {
            int userId = int.Parse(args[0]);

            User user = this.context.Users.FirstOrDefault(u => u.UserId == userId);

            if (user == null)
            {
                throw new ArgumentNullException($"User with id {userId} not found!");
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"User: {user.FirstName} {user.LastName}");

            var userBankAccounts = context.PaymentMethods.Where(x => x.UserId == userId && x.Type == (PaymentType)0).Select(x => x.BankAccount).ToList();
            var userCreditCards = context.PaymentMethods.Where(x => x.UserId == userId && x.Type == (PaymentType)1).Select(x => x.CreditCard).ToList();

            if (userBankAccounts.Any())
            {
                sb.AppendLine("Bank Accounts:");

                foreach (var bankAccount in userBankAccounts)
                {
                    sb.AppendLine($"-- ID: {bankAccount.BankAccountId}");
                    sb.AppendLine($"--- Balance: {bankAccount.Balance:f2}");
                    sb.AppendLine($"--- Bank: {bankAccount.BankName}");
                    sb.AppendLine($"--- SWIFT: {bankAccount.SwiftCode}");
                }
            }

            if (userCreditCards.Any())
            {
                sb.AppendLine("Credit Cards:");

                foreach (var creditCard in userCreditCards)
                {
                    sb.AppendLine($"-- ID: {creditCard.CreditCardId}");
                    sb.AppendLine($"--- Limit: {creditCard.Limit:f2}");
                    sb.AppendLine($"--- Money Owed: {creditCard.MoneyOwed:f2}");
                    sb.AppendLine($"--- Limit Left: {creditCard.LimitLeft:f2}");
                    sb.AppendLine($"--- Expiration Date: {creditCard.ExpirationDate.ToString("yyyy/MM", CultureInfo.InvariantCulture)}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
