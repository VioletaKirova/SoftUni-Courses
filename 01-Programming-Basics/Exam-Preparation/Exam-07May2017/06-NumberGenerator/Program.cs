using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_NumberGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string m = Console.ReadLine();
            string n = Console.ReadLine();
            string l = Console.ReadLine();
            int specialNum = int.Parse(Console.ReadLine());
            int controlNum = int.Parse(Console.ReadLine());

            bool specNumReached = false;

            for (int i = int.Parse(m); i >= 1; i--)
            {
                for (int j = int.Parse(n); j >= 1; j--)
                {
                    for (int h = int.Parse(l); h >= 1; h--)
                    {
                        int current = int.Parse(i.ToString() + j.ToString() + h.ToString());

                        if (current % 3 == 0)
                        {
                            specialNum += 5;
                        }
                        else if (current % 10 == 5)
                        {
                            specialNum -= 2;
                        }
                        else if (current % 2 == 0)
                        {
                            specialNum *= 2;
                        }

                        if (specialNum >= controlNum)
                        {
                            specNumReached = true;
                            break;
                        }
                    }

                        if (specNumReached) break;

                }

                if (specNumReached) break;

            }

            if (!specNumReached)
            {
                Console.WriteLine($"No! {specialNum} is the last reached special number.");
            }
            else
            {
                Console.WriteLine($"Yes! Control number was reached! Current special number is {specialNum}.");
            }
        }
    }
}
