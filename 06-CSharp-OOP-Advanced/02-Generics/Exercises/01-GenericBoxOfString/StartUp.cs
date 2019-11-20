namespace _01_GenericBoxOfString
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string elementValue = Console.ReadLine();
                Box<string> box = new Box<string>(elementValue);
                Console.WriteLine(box);
            }
        }
    }
}
