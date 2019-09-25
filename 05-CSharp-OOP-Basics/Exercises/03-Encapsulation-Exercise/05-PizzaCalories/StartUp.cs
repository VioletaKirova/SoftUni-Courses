using System;

namespace P05_PizzaCalories
{
    public class StartUp
    {
        private static void Main(string[] args)
        {
            try
            {
                string[] pizzaArgs = Console.ReadLine()
                    .Split();

                string pizzaName = pizzaArgs[1];

                Pizza pizza = new Pizza(pizzaName);

                string[] doughArgs = Console.ReadLine()
                    .Split();

                string doughType = doughArgs[1];
                string doughBakingTechnique = doughArgs[2];
                double doughWeight = double.Parse(doughArgs[3]);

                Dough dough = new Dough(doughType, doughBakingTechnique, doughWeight);

                pizza.Dough = dough;

                string toppingInput = Console.ReadLine();

                while (toppingInput != "END")
                {
                    string[] toppingArgs = toppingInput
                        .Split();

                    string toppingType = toppingArgs[1];
                    double toppingWeight = double.Parse(toppingArgs[2]);

                    Topping topping = new Topping(toppingType, toppingWeight);

                    pizza.AddTopping(topping);

                    toppingInput = Console.ReadLine();
                }

                Console.WriteLine(pizza.ToString());
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }
        }
    }
}