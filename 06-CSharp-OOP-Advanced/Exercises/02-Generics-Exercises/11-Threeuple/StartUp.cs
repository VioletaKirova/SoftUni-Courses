namespace _11_Threeuple
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] personInfo = ReadInput();
            string personName = personInfo[0] + " " + personInfo[1];
            string address = personInfo[2];
            string town = personInfo[3];

            string[] beerInfo = ReadInput();
            string beerDrinker = beerInfo[0];
            int beers = int.Parse(beerInfo[1]);
            bool isDrunk = beerInfo[2] == "drunk" ? true : false;

            string[] balanceInfo = ReadInput();
            string balanceOwner = balanceInfo[0];
            double balance = double.Parse(balanceInfo[1]);
            string bank = balanceInfo[2];

            IThreeuple<string, string, string> personThreeuple = new Threeuple<string, string, string>(personName, address, town);
            IThreeuple<string, int, bool> beerThreeuple = new Threeuple<string, int, bool>(beerDrinker, beers, isDrunk);
            IThreeuple<string, double, string> balanceThreeuple = new Threeuple<string, double, string>(balanceOwner, balance, bank);

            Console.WriteLine(personThreeuple);
            Console.WriteLine(beerThreeuple);
            Console.WriteLine(balanceThreeuple);
        }

        private static string[] ReadInput()
        {
            return Console.ReadLine()
                .Split();
        }
    }
}
