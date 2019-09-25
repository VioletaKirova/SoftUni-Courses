using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_ParkingValidation
{
    // 90/100
    class Program
    {
        static void Main(string[] args)
        {        
            int n = int.Parse(Console.ReadLine());

            var database = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                List<string> input = Console.ReadLine().Split(' ').ToList();

                string command = input[0];
                string name = input[1];

                if (command == "register")
                {
                    string plateStr = input[2];
                    char[] plateArr = input[2].ToArray();
                    string plateNums = plateStr.Remove(0, 2).Remove(4, 2);
                    int parsedNums = 0;

                    bool invalid = false;
                    bool checkMiddleChars = int.TryParse(plateNums, out parsedNums);

                    if (plateArr.Length != 8)
                    {
                        invalid = true;
                    }
                    else if (((int)plateArr[0] < 65 || (int)plateArr[0] > 90) || (((int)plateArr[1] < 65) || (int)plateArr[1] > 90) ||
                            (((int)plateArr[6] < 65) || (int)plateArr[6] > 90) || (((int)plateArr[7] < 65) || (int)plateArr[7] > 90))
                    {
                        invalid = true;
                    }
                    else if (parsedNums == 0)
                        invalid = true;

                    if (invalid)
                    {
                        Console.WriteLine($"ERROR: invalid license plate {plateStr}");
                        continue;
                    }

                    if (!database.ContainsKey(name) && !database.ContainsValue(plateStr))
                    {
                        database[name] = plateStr;
                        Console.WriteLine($"{name} registered {plateStr} successfully");
                    }
                    else if (database.ContainsKey(name) && !database.ContainsValue(plateStr))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {database[name]}");
                    }
                    else if (!database.ContainsKey(name) && database.ContainsValue(plateStr))
                    {
                        Console.WriteLine($"ERROR: license plate {plateStr} is busy");
                    }
         
                }
                else if (command == "unregister")
                {
                    if (!database.ContainsKey(name))
                    {
                        Console.WriteLine($"ERROR: user {name} not found");
                    }
                    else
                    {
                        Console.WriteLine($"user {name} unregistered successfully");
                        database.Remove(name);
                    }
                }                            
            }

            foreach (var car in database)
            {
                Console.WriteLine($"{car.Key} => {car.Value}");
            }
        }
    }
}