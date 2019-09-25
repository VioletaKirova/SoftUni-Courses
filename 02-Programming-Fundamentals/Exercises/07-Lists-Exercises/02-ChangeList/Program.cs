using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            for (int i = 0; ; i++)
            {
                List<string> commands = Console.ReadLine().Split(' ').ToList();

                if (commands[0] == "Odd")
                {
                    for (int j = 0; j < nums.Count; j++)
                    {
                        if (nums[j] % 2 != 0)
                            Console.Write($"{nums[j]} ");
                    }

                    break;
                }

                if (commands[0] == "Even")
                {
                    for (int j = 0; j < nums.Count; j++)
                    {
                        if (nums[j] % 2 == 0)
                            Console.Write($"{nums[j]} ");
                    }

                    break;
                }

                if (commands[0] == "Delete")
                {
                    for (int j = 0; j < nums.Count; j++)
                    {
                        if (int.Parse(commands[1]) == nums[j])
                        {
                            nums.Remove(int.Parse(commands[1]));
                            j--;
                        }
                    }
                }

                if (commands[0] == "Insert")
                {
                    nums.Insert(int.Parse(commands[2]), int.Parse(commands[1]));
                }
            }
        }
    }
}