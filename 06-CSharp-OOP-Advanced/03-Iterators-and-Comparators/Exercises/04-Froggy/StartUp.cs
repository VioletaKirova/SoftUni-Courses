namespace _04_Froggy
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] stones = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            ILake lake = new Lake(stones);
            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
