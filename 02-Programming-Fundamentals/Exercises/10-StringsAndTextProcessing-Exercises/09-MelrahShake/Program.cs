using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09_MelrahShake
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = Console.ReadLine();

            while (pattern.Length > 0)
            {
                int firstIndex = text.IndexOf(pattern);
                int lastIndex = text.LastIndexOf(pattern);

                if (firstIndex != lastIndex)
                {
                    text = text.Remove(lastIndex, pattern.Length)
                        .Remove(firstIndex, pattern.Length);
                    pattern = pattern.Remove(pattern.Length / 2, 1);
                    Console.WriteLine("Shaked it.");
                }
                else
                {                    
                    break;
                }              
            }

            Console.WriteLine("No shake.");
            Console.WriteLine(text);
        }
    }
}