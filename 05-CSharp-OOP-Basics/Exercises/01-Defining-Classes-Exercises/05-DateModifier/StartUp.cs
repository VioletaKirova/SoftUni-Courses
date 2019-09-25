using System;

namespace _05_DateModifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string firstDateStr = Console.ReadLine();
            string secondDateStr = Console.ReadLine();

            Date firstDate = new Date(firstDateStr);
            Date secondDate = new Date(secondDateStr);

            int daysDifference = (firstDate.DateTime - secondDate.DateTime).Days;

            Console.WriteLine(Math.Abs(daysDifference));
        }
    }
}
