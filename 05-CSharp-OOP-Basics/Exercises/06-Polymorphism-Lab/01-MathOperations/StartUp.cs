using System;

namespace Operations
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(MathOperations.Add(2, 3));
            Console.WriteLine(MathOperations.Add(2.2, 3.3, 5.5));
            Console.WriteLine(MathOperations.Add(2.2m, 3.3m, 4.4m));
        }
    }
}
