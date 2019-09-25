using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _01_CharityMarathon
{
    class Program
    {
        static void Main(string[] args)
        {
            int lengthInDays = int.Parse(Console.ReadLine());
            BigInteger runners = BigInteger.Parse(Console.ReadLine());
            int lapsPerRunner = int.Parse(Console.ReadLine());
            BigInteger trackLength = BigInteger.Parse(Console.ReadLine());
            int trackCapacity = int.Parse(Console.ReadLine());
            decimal moneyPerKilometer = decimal.Parse(Console.ReadLine());

            BigInteger runnersTakingPart = 0;

            if (runners >= trackCapacity * lengthInDays)
                runnersTakingPart = trackCapacity * lengthInDays;
            else
                runnersTakingPart = runners;

            BigInteger totalKilometers = (runnersTakingPart * (BigInteger)lapsPerRunner * trackLength) / 1000;
            decimal raisedMoney = (decimal)totalKilometers * moneyPerKilometer;

            Console.WriteLine($"Money raised: {raisedMoney:f2}");
        }
    }
}