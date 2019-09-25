using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_WordInPlural
{
    class Program
    {
        static void Main(string[] args)
        {
            var word = Console.ReadLine();

            bool ies = word.EndsWith("y");
            bool es = word.EndsWith("o") || word.EndsWith("ch") || word.EndsWith("s") || word.EndsWith("sh")
                || word.EndsWith("x") || word.EndsWith("z");

            if (ies)
            {
                word = word.Remove(word.Length - 1);
                Console.WriteLine(word + "ies");
            }
            else if (es)
            {
                Console.WriteLine(word + "es");
            }
            else
            {
                Console.WriteLine(word + "s");
            }
        }
    }
}
