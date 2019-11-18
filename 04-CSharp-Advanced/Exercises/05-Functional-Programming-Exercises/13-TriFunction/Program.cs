using System;
using System.Linq;

namespace _13_TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            string[] inputNames = Console.ReadLine().Split();

            Action<string> print = n => Console.WriteLine(n);

            Func<string, int, bool> checkName = (name, num) => 
            name.Sum(x => x) >= num;

            Func<string[], Func<string, int, bool>, string> findName = (names, checkNameFunc) => 
            names.FirstOrDefault(x => checkNameFunc(x, number));

            string result = findName(inputNames, checkName);
            print(result);
        }
    }
}
