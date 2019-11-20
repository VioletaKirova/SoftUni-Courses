using System;
using System.Collections.Generic;
using System.Linq;

namespace _12_InfernoIII
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<List<int>> print = p => Console.WriteLine(string.Join(' ', p));

            var filters = new Dictionary<string, Dictionary<int, Func<int, int, bool>>>();

            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string input = Console.ReadLine();

            while (input != "Forge")
            {
                string[] commandArgs = input.Split(';');

                string command = commandArgs[0];
                string functionName = commandArgs[1];
                int value = int.Parse(commandArgs[2]);

                Func<int, int, bool> sumFunc = GetFunction(numbers, functionName);

                if (command == "Exclude")
                {
                    if (!filters.ContainsKey(functionName))
                    {
                        filters[functionName] = new Dictionary<int, Func<int, int, bool>>();
                    }

                    if (!filters[functionName].ContainsKey(value))
                    {
                        filters[functionName][value] = sumFunc;
                    }
                }
                else
                {
                    if (filters.ContainsKey(functionName) && filters[functionName].ContainsKey(value))
                    {
                        filters[functionName].Remove(value);
                    }
                }

                input = Console.ReadLine();
            }

            List<int> result = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                bool isValid = true;

                foreach (var filter in filters)
                {
                    foreach (var kvp in filter.Value)
                    {
                        if (kvp.Value(i, kvp.Key))
                        {
                            isValid = false;
                            break;
                        }
                    }
                }

                if (isValid)
                {
                    result.Add(numbers[i]);
                }
            }

            print(result);
        }

        private static Func<int, int, bool> GetFunction(List<int> numbers, string functionName)
        {
            if (functionName == "Sum Left")
            {
                return (i, targetSum) => i == 0 ? numbers[i] == targetSum : numbers[i] + numbers[i - 1] == targetSum;
            }
            else if (functionName == "Sum Right")
            {
                return (i, targetSum) => i == numbers.Count - 1 ? numbers[i] == targetSum : numbers[i] + numbers[i + 1] == targetSum;
            }
            else if (functionName == "Sum Left Right")
            {
                return (i, targetSum) => numbers.Count == 1 ? numbers[i] == targetSum :
                i == numbers.Count - 1 ? numbers[i] + numbers[i - 1] == targetSum :
                i == 0 ? numbers[i] + numbers[i + 1] == targetSum :
                numbers[i - 1] + numbers[i] + numbers[i + 1] == targetSum;
            }

            return null;
        }
    }
}
