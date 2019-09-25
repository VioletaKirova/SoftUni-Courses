using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03_Snowflake
{
    // 90/100
    class Program
    {
        static void Main(string[] args)
        {            
            List<string> allLines = new List<string>();
            for (int i = 0; i < 5; i++)
                allLines.Add(Console.ReadLine());

            string surfacePattern = @"[^A-Za-z\d]+";
            string mantlePattern = @"[\d_]+";
            string corePattern = @"[a-zA-Z]+";
            string middlePattern = @"^([^A-Za-z\d]+)([\d_]+)([a-zA-Z]+)([\d_]+)([^A-Za-z\d]+)$";

            Match surface = Regex.Match(allLines[0], surfacePattern);
            Match mantle = Regex.Match(allLines[1], mantlePattern);
            Match middle = Regex.Match(allLines[2], middlePattern);
            Match mantle2 = Regex.Match(allLines[3], mantlePattern);
            Match surface2 = Regex.Match(allLines[4], surfacePattern);

            if (surface.Success && mantle.Success && middle.Success && mantle2.Success && surface2.Success)
            {
                Console.WriteLine("Valid");
                Console.WriteLine(middle.Groups[3].Value.Length);
            }
            else
                Console.WriteLine("Invalid");
        }
    }
}