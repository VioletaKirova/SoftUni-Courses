using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_DNASequences
{
    class Program
    {
        static void Main(string[] args)
        {
            var matchSum = int.Parse(Console.ReadLine());

            var valueN1 = 0;
            var valueN2 = 0;
            var valueN3 = 0;
            var sum = 0;

            var count = 0;

            for (char n1 = 'A'; n1 <= 'T'; n1++)
            {
                for (char n2 = 'A'; n2 <= 'T'; n2++)
                {
                    for (char n3 = 'A'; n3 <= 'T'; n3++)
                    {
                        if ((n1 == 'A' || n1 == 'C' || n1 == 'G' || n1 == 'T') &&
                            (n2 == 'A' || n2 == 'C' || n2 == 'G' || n2 == 'T') &&
                            (n3 == 'A' || n3 == 'C' || n3 == 'G' || n3 == 'T'))
                        {
                            count++;

                            if (n1 == 'A') valueN1 = 1;
                            else if (n1 == 'C') valueN1 = 2;
                            else if (n1 == 'G') valueN1 = 3;
                            else if (n1 == 'T') valueN1 = 4;

                            if (n2 == 'A') valueN2 = 1;
                            else if (n2 == 'C') valueN2 = 2;
                            else if (n2 == 'G') valueN2 = 3;
                            else if (n2 == 'T') valueN2 = 4;

                            if (n3 == 'A') valueN3 = 1;
                            else if (n3 == 'C') valueN3 = 2;
                            else if (n3 == 'G') valueN3 = 3;
                            else if (n3 == 'T') valueN3 = 4;

                            sum = valueN1 + valueN2 + valueN3;

                            if (sum >= matchSum)
                                Console.Write($"O{n1}{n2}{n3}O ");
                            else
                                Console.Write($"X{n1}{n2}{n3}X ");

                            if (count % 4 == 0)
                                Console.WriteLine();
                        }
                    }
                }
            }
        }
    }
}
