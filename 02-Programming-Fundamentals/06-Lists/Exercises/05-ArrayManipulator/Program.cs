using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<string> commands = new List<string>();

            for (int i = 0; ; i++)
            {
                commands = Console.ReadLine().Split(' ').ToList();

                if (commands[0] == "add")
                {
                    nums.Insert(int.Parse(commands[1]), int.Parse(commands[2]));
                }
                else if (commands[0] == "addMany")
                {
                    int index = int.Parse(commands[1]);

                    for (int j = 2; j < commands.Count; j++)
                    {
                        nums.Insert(index, int.Parse(commands[j]));
                        index++;
                    }
                }
                else if (commands[0] == "contains")
                {
                    for (int j = 0; j < nums.Count; j++)
                    {
                        if (int.Parse(commands[1]) == nums[j])
                        {
                            Console.WriteLine(j);
                            break;
                        }

                        if (j == nums.Count - 1 && int.Parse(commands[1]) != nums[j])
                        {
                            Console.WriteLine("-1");
                        }
                    }
                }
                else if (commands[0] == "remove")
                {
                    nums.RemoveAt(int.Parse(commands[1]));
                }
                else if (commands[0] == "shift")
                {
                    int positions = int.Parse(commands[1]);

                    for (int j = 0; j < positions; j++)
                    {
                        int firstElement = nums[0];

                        for (int x = 1; x < nums.Count; x++)
                        {
                            nums[x - 1] = nums[x];
                        }

                        nums[nums.Count - 1] = firstElement;
                    }
                }
                else if (commands[0] == "sumPairs")
                {
                    for (int j = 0; j < nums.Count; j++)
                    {
                        if (j == nums.Count - 1)
                        {
                            break;
                        }

                        nums[j] += nums[j + 1];
                        nums.RemoveAt(j + 1);
                    }
                }
                else if (commands[0] == "print")
                {
                    break;
                }
            }

            Console.WriteLine("[" + string.Join(", ", nums) + "]");
        }
    }
}