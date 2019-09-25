using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double grade = double.Parse(Console.ReadLine());
            double minimalIncome = double.Parse(Console.ReadLine());
            double scholarship = 0;

            if (income < minimalIncome &&  grade >= 5.50 )
            {
                scholarship = grade * 25;
                Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(scholarship)} BGN");
            }
            else if (income < minimalIncome && grade > 4.5)
            {
                scholarship = minimalIncome * 0.35;
                Console.WriteLine($"You get a Social scholarship {Math.Floor(scholarship)} BGN");
            }
            else if (income >= minimalIncome && grade >= 5.5)
            {
                scholarship = grade * 25;
                Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(scholarship)} BGN");
            }
            else
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
        }
    }
}
