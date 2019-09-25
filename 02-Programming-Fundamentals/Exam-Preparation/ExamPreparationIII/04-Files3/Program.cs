using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Files3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var filesByRootsDict = new Dictionary<string, Dictionary<string, long>>();

            for (int i = 0; i < n; i++)
            {
                string[] filePath = Console.ReadLine().Split(new char[] {'\\', ';'}, StringSplitOptions.RemoveEmptyEntries);

                string root = filePath[0];
                string fileName = filePath[filePath.Length - 2];
                long size = long.Parse(filePath[filePath.Length - 1]);

                if (!filesByRootsDict.ContainsKey(root))
                {
                    filesByRootsDict.Add(root, new Dictionary<string, long>());
                }

                if (!filesByRootsDict[root].ContainsKey(fileName))
                {
                    filesByRootsDict[root].Add(fileName, 0);
                }

                filesByRootsDict[root][fileName] = size;
            }

            string[] input = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            string neededExtension = input[0];
            string neededRoot = input[2];
            bool filesFound = false;

            if (!filesByRootsDict.ContainsKey(neededRoot))
            {
                Console.WriteLine("No");
                return;
            }

            foreach (var file in filesByRootsDict[neededRoot].OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                string[] fileParts = file.Key.Split('.');
                string fileExt = fileParts[fileParts.Length - 1];

                if (fileExt == neededExtension)
                {
                    filesFound = true;
                    Console.WriteLine($"{file.Key} - {file.Value} KB");
                }
            }

            if (!filesFound)
            {
                Console.WriteLine("No");
            }
        }
    }
}