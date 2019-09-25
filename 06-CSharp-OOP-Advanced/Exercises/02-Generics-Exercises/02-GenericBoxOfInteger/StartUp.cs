namespace _02_GenericBoxOfInteger
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int elementValue = int.Parse(Console.ReadLine());
                Box<int> box = new Box<int>(elementValue);
                Console.WriteLine(box);
            }
        }
    }
}
