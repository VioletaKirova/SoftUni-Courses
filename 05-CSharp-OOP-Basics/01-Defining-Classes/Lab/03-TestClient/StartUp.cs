using System;
using System.Collections.Generic;
using System.Linq;

namespace BankAccount
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] command = input
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                int commandId = int.Parse(command[1]);

                switch (command[0])
                {
                    case "Create":
                        Create(accounts, commandId);
                        break;
                    case "Deposit":
                        Deposit(accounts, command, commandId);
                        break;
                    case "Withdraw":
                        Withdraw(accounts, command, commandId);
                        break;
                    case "Print":
                        Print(accounts, commandId);
                        break;
                }

                input = Console.ReadLine();
            }
        }

        private static void Print(Dictionary<int, BankAccount> accounts, int commandId)
        {
            if (!accounts.ContainsKey(commandId))
            {
                Console.WriteLine("Account does not exist");
            }
            else
            {
                accounts[commandId].Print(commandId);
            }
        }

        private static void Withdraw(Dictionary<int, BankAccount> accounts, string[] command, int commandId)
        {
            decimal withdrawAmount = decimal.Parse(command[2]);

            if (!accounts.ContainsKey(commandId))
            {
                Console.WriteLine("Account does not exist");
            }
            else if (accounts[commandId].Balance < withdrawAmount)
            {
                Console.WriteLine("Insufficient balance");
            }
            else
            {
                accounts[commandId].Balance -= withdrawAmount;
            }
        }

        private static void Deposit(Dictionary<int, BankAccount> accounts, string[] command, int commandId)
        {
            if (!accounts.ContainsKey(commandId))
            {
                Console.WriteLine("Account does not exist");
            }
            else
            {
                decimal depositAmount = decimal.Parse(command[2]);

                accounts[commandId].Balance += depositAmount;
            }
        }

        private static void Create(Dictionary<int, BankAccount> accounts, int commandId)
        {
            if (!accounts.ContainsKey(commandId))
            {
                BankAccount account = new BankAccount();

                account.Id = commandId;

                accounts[commandId] = account;
            }
            else
            {
                Console.WriteLine("Account already exists");
            }
        }
    }
}
