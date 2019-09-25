using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            string[] peopleInput = Console.ReadLine()
                .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            string[] productsInput = Console.ReadLine()
                .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < peopleInput.Length; i++)
            {
                string[] personArgs = peopleInput[i]
                    .Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

                string name = personArgs[0];
                decimal money = decimal.Parse(personArgs[1]);

                try
                {
                    Person person = new Person(name, money);
                    people.Add(person);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    return;
                }
            }

            for (int i = 0; i < productsInput.Length; i++)
            {
                string[] productArgs = productsInput[i]
                                    .Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

                string name = productArgs[0];
                decimal cost = decimal.Parse(productArgs[1]);

                try
                {
                    Product product = new Product(name, cost);
                    products.Add(product);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    return;
                }
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] commandArgs = command
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string personName = commandArgs[0];
                string productName = commandArgs[1];

                Person person = people.First(x => x.Name == personName);
                Product product = products.First(x => x.Name == productName);

                if (person.Money < product.Cost)
                {
                    Console.WriteLine($"{person.Name} can't afford {product.Name}");
                }
                else
                {
                    person.Money -= product.Cost;
                    person.Products.Add(product);
                    Console.WriteLine($"{person.Name} bought {product.Name}");
                }

                command = Console.ReadLine();
            }

            foreach (var person in people)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}
