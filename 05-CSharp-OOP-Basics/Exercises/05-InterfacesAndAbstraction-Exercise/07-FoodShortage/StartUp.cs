using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Citizen> citizens = new List<Citizen>();
            List<Rebel> rebels = new List<Rebel>();

            int peopleCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < peopleCount; i++)
            {
                string[] personArgs = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (personArgs.Length == 4)
                {
                    Citizen citizen = new Citizen(personArgs[0], personArgs[1], personArgs[2], personArgs[3]);
                    citizens.Add(citizen);
                }
                else if (personArgs.Length == 3)
                {
                    Rebel rebel = new Rebel(personArgs[0], personArgs[1], personArgs[2]);
                    rebels.Add(rebel);
                }
            }

            string name = Console.ReadLine();

            while (name != "End")
            {
                Citizen citizenBuyer = citizens.FirstOrDefault(c => c.Name == name);

                if (citizenBuyer != null)
                {
                    citizenBuyer.BuyFood();
                    name = Console.ReadLine();
                    continue;
                }

                Rebel rebelBuyer = rebels.FirstOrDefault(c => c.Name == name);

                if (rebelBuyer != null)
                {
                    rebelBuyer.BuyFood();
                }

                name = Console.ReadLine();
            }

            int totalFoodAmount = citizens.Sum(c => c.Food) + rebels.Sum(r => r.Food);
            Console.WriteLine(totalFoodAmount);
        }
    }
}
