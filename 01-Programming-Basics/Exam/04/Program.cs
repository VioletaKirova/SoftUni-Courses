using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double poor = 0.0;
            double satisfactory = 0.0;
            double good = 0.0;
            double veryGood = 0.0;
            double excellent = 0.0;

            for (int i = 0; i < n; i++)
            {
                double points = double.Parse(Console.ReadLine());

                if (points >= 0 && points <= 22.5)
                {
                    poor++;
                }
                else if (points > 22.5 && points <= 40.5)
                {
                    satisfactory++;
                }
                else if (points > 40.5 && points <= 58.5)
                {
                    good++;
                }
                else if (points > 58.5 && points <= 76.5)
                {
                    veryGood++;
                }
                else if (points > 76.5 && points <= 100)
                {
                    excellent++;
                }
            }

            double percentPoor = poor / n * 100;
            double percentSatisfactory = satisfactory / n * 100;
            double percentGood = good / n * 100;
            double percentVeryGood = veryGood / n * 100;
            double percentExcellent = excellent / n * 100;

            Console.WriteLine($"{percentPoor:f2}% poor marks");
            Console.WriteLine($"{percentSatisfactory:f2}% satisfactory marks");
            Console.WriteLine($"{percentGood:f2}% good marks");
            Console.WriteLine($"{percentVeryGood:f2}% very good marks");
            Console.WriteLine($"{percentExcellent:f2}% excellent marks");
        }
    }
}
