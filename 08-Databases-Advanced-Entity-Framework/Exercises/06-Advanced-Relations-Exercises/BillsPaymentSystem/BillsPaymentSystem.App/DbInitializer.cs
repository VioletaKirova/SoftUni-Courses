namespace BillsPaymentSystem.App
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Data;
    using Models;
    using Models.Enums;

    public class DbInitializer
    {
        public static void Seed(BillsPaymentSystemContext context)
        {
            SeedUsers(context);
            SeedCreditCards(context);
            SeedBankAccounts(context);
            SeedPaymentMethods(context);
        }

        private static void SeedPaymentMethods(BillsPaymentSystemContext context)
        {
            List<PaymentMethod> paymentMethods = new List<PaymentMethod>();

            for (int i = 0; i < 8; i++)
            {
                PaymentMethod paymentMethod = new PaymentMethod
                {
                    UserId = i + 1,
                    BankAccountId = i + 1,
                    CreditCardId = i + 1             
                };

                if (i % 3 == 0)
                {
                    // should fail
                    paymentMethod.BankAccountId = null;
                    paymentMethod.CreditCardId = null;
                }
                else if (i % 2 == 0)
                {
                    paymentMethod.BankAccountId = null;
                    paymentMethod.Type = PaymentType.CreditCard;
                }
                else
                {
                    paymentMethod.CreditCardId = null;
                    paymentMethod.Type = PaymentType.BankAccount;
                }

                if (!IsValid(paymentMethod))
                {
                    continue;
                }

                paymentMethods.Add(paymentMethod);
            }

            context.PaymentMethods.AddRange(paymentMethods);
            context.SaveChanges();
        }

        private static void SeedBankAccounts(BillsPaymentSystemContext context)
        {
            List<BankAccount> bankAccounts = new List<BankAccount>();

            int count = 0;

            while (true)
            {
                count++;

                BankAccount bankAccount = new BankAccount
                {
                    Balance = new Random().Next(-200, 2500),
                    BankName = $"Bank{count}",
                    SwiftCode = $"SWIFT{count}"
                };

                if (!IsValid(bankAccount))
                {
                    continue;
                }

                bankAccounts.Add(bankAccount);

                if (bankAccounts.Count == 8)
                {
                    break;
                }
            }

            context.BankAccounts.AddRange(bankAccounts);
            context.SaveChanges();
        }

        private static void SeedCreditCards(BillsPaymentSystemContext context)
        {
            List<CreditCard> creditCards = new List<CreditCard>();

            while (true)
            {
                CreditCard creditCard = new CreditCard
                {
                    Limit = new Random().Next(-2500, 2500),
                    MoneyOwed = new Random().Next(-500, 500),
                    ExpirationDate = DateTime.Now.AddDays(new Random().Next(-200, 200))
                };

                if (!IsValid(creditCard))
                {
                    continue;
                }

                creditCards.Add(creditCard);

                if (creditCards.Count == 8)
                {
                    break;
                }
            }

            context.CreditCards.AddRange(creditCards);
            context.SaveChanges();
        }

        private static void SeedUsers(BillsPaymentSystemContext context)
        {
            List<User> users = new List<User>();

            var firstNames = new string[]
            {
                "Iliyan",
                "Filip",
                "Grigor",
                "Emanuil",
                "Petko",
                "Ana",
                "Violeta",
                "R.", //should't be added to the Users table
                "Silviya",
                "Mihaela"
            };

            var lastNames = new string[]
            {
                "Iliev",
                "Kirov",
                "Ivanov",
                "Staikov",
                "Andonov",
                "Dimitrova",
                "Simeonova",
                "Velizarova",
                "Kuzmanova",
                "Radeva"
            };

            var emails = new string[]
            {
                "i.iliev@gmail.com",
                "f.kirov@gmail.com",
                "g.ivanov@gmail.com",
                "e.staikov@gmail.com",
                "p.andonov@gmail.com",
                "a.dimitrova@gmail.com",
                "v.simeonova@gmail.com",
                "r.velizarova@gmail.com",
                null, //should't be added to the Users table
                "m.radeva@gmail.com"
            };

            for (int i = 0; i < 10; i++)
            {
                var user = new User
                {
                    FirstName = firstNames[i],
                    LastName = lastNames[i],
                    Email = emails[i],
                    Password = $"Password{i + 1}"
                };

                if(!IsValid(user))
                {
                    continue;
                }

                users.Add(user);
            }

            // 8 users should be added to the Users table
            context.Users.AddRange(users);
            context.SaveChanges();
        }

        private static bool IsValid(object entity)
        {
            ValidationContext validationContext = new ValidationContext(entity);
            List<ValidationResult> validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(entity, validationContext, validationResults, true);

            return isValid;
        }
    }
}
