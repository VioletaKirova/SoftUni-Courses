using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_SoftUniCamp
{
    class Program
    {
        static void Main(string[] args)
        {
            int groups = int.Parse(Console.ReadLine());

            double peopleWithCar = 0; 
            double peopleWithMicrobus = 0; 
            double peopleWithMinibus = 0; 
            double peopleWithBigbus = 0;
            double peopleWithTrain = 0;

            double all = 0;

            for (int i = 0; i < groups; i++)
            {
                double people = double.Parse(Console.ReadLine());

                all += people;

                if (people <= 5)
                {
                    peopleWithCar += people;
                }
                else if (people > 5 && people <= 12)
                {
                    peopleWithMicrobus += people;
                }
                else if (people > 12 && people <= 25)
                {
                    peopleWithMinibus += people;
                }
                else if (people > 25 && people <= 40)
                {
                    peopleWithBigbus += people;
                }
                else if (people > 40)
                {
                    peopleWithTrain += people;
                }
            }

            double percentWithCar = peopleWithCar / all * 100;
            double percentWithMicrobus = peopleWithMicrobus / all * 100;
            double percentWithMinibus = peopleWithMinibus / all * 100;
            double percentWithBigbus = peopleWithBigbus / all * 100;
            double percentWithTrain = peopleWithTrain / all * 100;

            Console.WriteLine($"{percentWithCar:f2}%");
            Console.WriteLine($"{percentWithMicrobus:f2}%");
            Console.WriteLine($"{percentWithMinibus:f2}%");
            Console.WriteLine($"{percentWithBigbus:f2}%");
            Console.WriteLine($"{percentWithTrain:f2}%");
        }
    }
}
