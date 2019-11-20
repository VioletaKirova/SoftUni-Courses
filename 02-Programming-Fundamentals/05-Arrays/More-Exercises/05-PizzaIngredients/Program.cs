using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_PizzaIngredients
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] ingredients = Console.ReadLine().Split(' ').ToArray();
            int stringLength = int.Parse(Console.ReadLine());
            int ingredientCount = 0;
            string finalLineOfOutput = "The ingredients are: ";

            for (int i = 0; i < ingredients.Length; i++)
            {
                if (ingredients[i].Length == stringLength)
                {
                    ingredientCount++;
                    Console.WriteLine($"Adding {ingredients[i]}.");
                    finalLineOfOutput += $"{ingredients[i]}, ";
                }

                if (ingredientCount == 10)
                {
                    break;
                }
            }

            Console.WriteLine($"Made pizza with total of {ingredientCount} ingredients.");
            finalLineOfOutput = finalLineOfOutput.Remove(finalLineOfOutput.Length - 2);
            Console.WriteLine($"{finalLineOfOutput}.");
        }
    }
}