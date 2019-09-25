using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _01_Anonymous_Downsite
{
    // 90/100
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger securityKey = BigInteger.Parse(Console.ReadLine());

            List<string> affectedSites = new List<string>();
            decimal totalLoss = 0.0m;

            for (int i = 0; i < n; i++)
            {
                string[] siteInfo = Console.ReadLine().Split(' ').ToArray();

                string siteName = siteInfo[0];
                BigInteger siteVisits = BigInteger.Parse(siteInfo[1]);
                decimal sitePricePerVisit = decimal.Parse(siteInfo[2]);

                affectedSites.Add(siteName);
                decimal siteLoss = (decimal)siteVisits * sitePricePerVisit;
                totalLoss += siteLoss;
            }

            BigInteger securityToken = BigInteger.Pow(securityKey, n);

            foreach (var site in affectedSites)
                Console.WriteLine(site);

            Console.WriteLine($"Total Loss: {totalLoss:f20}");
            Console.WriteLine($"Security Token: {securityToken}");
        }
    }
}