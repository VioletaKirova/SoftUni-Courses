using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_Ladybugs
{
    // 80/100
    class Program
    {
        static void Main(string[] args)
        {
            int fieldLen = int.Parse(Console.ReadLine());
            List<int> field = new List<int>();
            for (int i = 0; i < fieldLen; i++)
                field.Add(0);

            int[] indexes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            foreach (var index in indexes)
            {
                if (index <= field.Count - 1)
                    field[index] = 1;
            }

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] commands = input.Split(' ').ToArray();
                int ladybugIndex = int.Parse(commands[0]);
                string direction = commands[1];
                int flyLength = int.Parse(commands[2]);

                if (ladybugIndex > field.Count - 1 || ladybugIndex < 0)
                {
                    input = Console.ReadLine();
                    continue;
                }
                else if (field[ladybugIndex] == 0)
                {
                    input = Console.ReadLine();
                    continue;
                }

                field[ladybugIndex] = 0;

                if (direction == "right")
                {                  
                    for (int i = ladybugIndex + flyLength; i < field.Count; i += flyLength)
                    {
                        if (field[i] == 0)
                        {
                            field[i] = 1;
                            break;
                        }
                    }
                }
                else if (direction == "left")
                {
                    for (int i = ladybugIndex - flyLength; i >= 0; i -= flyLength)
                    {
                        if (field[i] == 0)
                        {
                            field[i] = 1;
                            break;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", field));
        }
    }
}