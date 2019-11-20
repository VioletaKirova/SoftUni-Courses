using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_AndreyAndBilliard
{
    class Program
    {
        class Customer
        {
            public string Name { get; set; }
            public Dictionary<string, int> ShopList { get; set; }
            public decimal Bill { get; set; }
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var menu = new Dictionary<string, decimal>();

            for (int i = 0; i < n; i++)
            {
                List<string> input = Console.ReadLine().Split('-').ToList();
                if (!menu.ContainsKey(input[0]))
                {
                    menu[input[0]] = 0;
                }
                menu[input[0]] = decimal.Parse(input[1]);
            }

            List<Customer> customers = new List<Customer>();

            string clientInput = Console.ReadLine();

            while(clientInput != "end of clients")
            {
                List<string> input = clientInput.Split('-', ',').ToList();

                if (!menu.ContainsKey(input[1]))
                {
                    clientInput = Console.ReadLine();
                    continue;
                }

                Customer customer = new Customer();
                customer.ShopList = new Dictionary<string, int>();
                customer.Name = input[0];
                customer.ShopList.Add(input[1], int.Parse(input[2]));

                if (customers.Any(c => c.Name == input[0]))
                {
                    Customer existingCustomer = customers.First(c => c.Name == input[0]);

                    if (existingCustomer.ShopList.ContainsKey(input[1]))
                    {
                        existingCustomer.ShopList[input[1]] += int.Parse(input[2]);
                    }
                    else
                    {
                        existingCustomer.ShopList[input[1]] = int.Parse(input[2]);
                    }
                }
                else
                {
                    customers.Add(customer);
                }

                clientInput = Console.ReadLine();
            }

            foreach (var customer in customers)
            {
                foreach (var item in customer.ShopList)
                {
                    foreach (var product in menu)
                    {
                        if (item.Key == product.Key)
                        {
                            customer.Bill += item.Value * product.Value;
                        }
                    }
                }
            }

            decimal totalBill = 0;

            foreach (var c in customers.OrderBy(c => c.Name))
            {
                Console.WriteLine(c.Name);

                foreach (KeyValuePair<string, int> item in c.ShopList)
                {
                    Console.WriteLine($"-- {item.Key} - {item.Value}");
                }

                totalBill += c.Bill;
                Console.WriteLine($"Bill: {c.Bill:f2}");
            }

            Console.WriteLine($"Total bill: {totalBill:f2}");
        }
    }
}