using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_BombNumbers2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> bombAndPower = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            int bomb = bombAndPower[0];
            int power = bombAndPower[1];

            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] == bomb)
                {
                    for (int j = 1; j <= power; j++)
                    {
                        if (i - j < 0)
                        {
                            break;
                        }
                        else
                        {
                            nums[i - j] = 0;
                        }
                    }

                    for (int j = 1; j <= power; j++)
                    {
                        if (i + j > nums.Count - 1)
                        {
                            break;
                        }
                        else
                        {
                            nums[i + j] = 0;
                        }
                    }

                    nums[i] = 0;
                }              
            }

            int sum = nums.Sum();
            Console.WriteLine(sum);
        }
    }
}