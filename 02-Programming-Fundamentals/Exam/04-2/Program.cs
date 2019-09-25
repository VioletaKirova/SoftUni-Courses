using System;
using System.Collections.Generic;
using System.Linq;

namespace _04
{
    // 80/100
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var forceSidesDict = new Dictionary<string, List<string>>();

            while (input != "Lumpawaroo")
            {
                if (input.Contains(" | "))
                {
                    string[] inputParts = input.Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);

                    if (inputParts.Length > 2)
                    {
                        continue;
                    }

                    string forceSide = inputParts[0];
                    string forceUser = inputParts[1];

                    bool userFount = false;

                    foreach (var side in forceSidesDict)
                    {
                        foreach (var user in side.Value)
                        {
                            if (user == forceUser)
                            {
                                userFount = true;
                                break;
                            }
                        }

                        if (userFount)
                        {
                            break;
                        }
                    }

                    if (userFount)
                    {
                        continue;
                    }

                    if (!forceSidesDict.ContainsKey(forceSide))
                    {
                        forceSidesDict.Add(forceSide, new List<string>());
                    }

                    if (!forceSidesDict[forceSide].Contains(forceUser))
                    {
                        forceSidesDict[forceSide].Add(forceUser);
                    }
                }
                else if (input.Contains(" -> "))
                {
                    string[] inputParts = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);

                    if (inputParts.Length > 2)
                    {
                        continue;
                    }

                    string forceSide = inputParts[1];
                    string forceUser = inputParts[0];

                    foreach (var side in forceSidesDict)
                    {
                        for (int i = 0; i < side.Value.Count; i++)
                        {
                            if (side.Value[i] == forceUser)
                            {
                                side.Value.Remove(forceUser);
                                i--;
                            }
                        }
                    }

                    if (!forceSidesDict.ContainsKey(forceSide))
                    {
                        forceSidesDict.Add(forceSide, new List<string>());
                    }

                    forceSidesDict[forceSide].Add(forceUser);
                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }

                input = Console.ReadLine();
            }

            foreach (var side in forceSidesDict.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                if (side.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");

                    foreach (var user in side.Value.OrderBy(x => x))
                    {
                        Console.WriteLine($"! {user}");
                    }
                }
            }
        }
    }
}