namespace _10_Tuple
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] personInfo = ReadInput();
            string personName = personInfo[0] + " " + personInfo[1];
            string address = personInfo[2];

            string[] beerInfo = ReadInput();
            string name = beerInfo[0];
            int beers = int.Parse(beerInfo[1]);

            string[] numersInfo = ReadInput();
            int integerNumber = int.Parse(numersInfo[0]);
            double doubleNumber = double.Parse(numersInfo[1]);

            ICustomTuple<string, string> personTuple = new CustomTuple<string, string>(personName, address);
            ICustomTuple<string, int> beerTuple = new CustomTuple<string, int>(name, beers);
            ICustomTuple<int, double> numbersTuple = new CustomTuple<int, double>(integerNumber, doubleNumber);

            Console.WriteLine(personTuple);
            Console.WriteLine(beerTuple);
            Console.WriteLine(numbersTuple);
        }

        private static string[] ReadInput()
        {
            return Console.ReadLine()
                .Split();
        }
    }
}
