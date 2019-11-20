using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_VowelsSum
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            int wordLength = word.Length;
            int value = 0;

            for (int i = 0; i < wordLength; i++)
            {
                switch (word[i])
                {
                    case 'a': value++; break;
                    case 'e': value += 2; break;
                    case 'i': value += 3; break;
                    case 'o': value += 4; break;
                    case 'u': value += 5; break;
                }
            }

            Console.WriteLine(value);
        }
    }
}
