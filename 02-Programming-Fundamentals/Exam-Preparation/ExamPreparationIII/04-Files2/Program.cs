using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Files
{
    // 80/100
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var files = new Dictionary<string, Dictionary<string, long>>();

            string extensionToPrint = string.Empty;
            string rootToPrint = string.Empty;

            for (int i = 0; i <= n; i++)
            {
                string input = Console.ReadLine();

                if (i == n)
                {
                    string[] inputArr = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    extensionToPrint = inputArr[0];
                    rootToPrint = inputArr[2];
                }
                else
                {
                    string[] inputArr = input.Split('\\', ';').Select(x => x.Trim()).ToArray();
                    string root = inputArr[0];
                    long size = long.Parse(inputArr[inputArr.Length - 1]);
                    string fileName = inputArr[inputArr.Length - 2];

                    if (!fileName.Contains("."))
                        continue;

                    if (!files.ContainsKey(root))
                        files.Add(root, new Dictionary<string, long>());

                    if (files[root].ContainsKey(fileName))
                        files[root][fileName] = size;
                    else
                        files[root].Add(fileName, size);
                }
            }

            bool thereIsMatch = false;

            foreach (var file in files[rootToPrint].OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                string[] keyParts = file.Key.Split('.');

                if (keyParts[keyParts.Length - 1] == extensionToPrint)
                {
                    thereIsMatch = true;
                    Console.WriteLine($"{file.Key} - {file.Value} KB");
                }
            }

            if (!thereIsMatch)
                Console.WriteLine("No");
        }
    }
}