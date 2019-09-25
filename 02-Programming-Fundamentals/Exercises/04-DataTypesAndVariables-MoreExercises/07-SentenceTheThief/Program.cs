using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_SentenceTheThief
{
    class Program
    {
        static void Main(string[] args)
        {
            string numType = Console.ReadLine();
            sbyte n = sbyte.Parse(Console.ReadLine());
            long id = long.MinValue;

            for (sbyte i = 0; i < n; i++)
            {
                long currentId = long.Parse(Console.ReadLine());

                if (numType == "sbyte")
                {
                    if (currentId <= sbyte.MaxValue && currentId > id)
                    {
                        id = currentId;
                    }
                }
                else if (numType == "int")
                {
                    if (currentId <= int.MaxValue && currentId > id)
                    {
                        id = currentId;
                    }
                }
                else if (numType == "long")
                {
                    if (currentId <= long.MaxValue && currentId > id)
                    {
                        id = currentId;
                    }
                }

            }

            decimal years = 0.0m;

            if (id <= -128)
                years = Math.Ceiling(Math.Abs((decimal)id) / 128);
            else
                years = Math.Ceiling(Math.Abs((decimal)id) / 127);

            if (years <= 1)
                Console.WriteLine($"Prisoner with id {id} is sentenced to {years} year");
            else
                Console.WriteLine($"Prisoner with id {id} is sentenced to {years} years");
        }
    }
}
