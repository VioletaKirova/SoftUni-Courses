using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Files4
{
    class File
    {
        public string Root { get; set; }
        public string Name { get; set; }
        public long Size { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var filesByRoot = new Dictionary<string, List<File>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] filePath = Console.ReadLine().Split(new char[] { '\\', ';' }, StringSplitOptions.RemoveEmptyEntries);

                string fileRoot = filePath[0];
                string fileName = filePath[filePath.Length - 2];
                long fileSize = long.Parse(filePath[filePath.Length - 1]);

                if (!filesByRoot.ContainsKey(fileRoot))
                {
                    filesByRoot.Add(fileRoot, new List<File>());
                }

                var existingFile = filesByRoot[fileRoot].FirstOrDefault(x => x.Name == fileName);

                if (existingFile == null)
                {
                    File newFile = new File
                    {
                        Name = fileName,
                        Root = fileRoot,
                        Size = fileSize
                    };

                    filesByRoot[fileRoot].Add(newFile);
                }
                else
                {
                    existingFile.Size = fileSize;
                }
            }
            string[] query = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string extension = query[0];
            string root = query[2];

            if (!filesByRoot.ContainsKey(root))
            {
                Console.WriteLine("No");
                return;
            }

            var result = filesByRoot[root]
                .Where(x => x.Name.EndsWith(extension))
                .OrderByDescending(x => x.Size)
                .ThenBy(x => x.Name)
                .ToList();

            if (!result.Any())
            {
                Console.WriteLine("No");
            }
            else
            {
                foreach (var file in result)
                {
                    Console.WriteLine($"{file.Name} - {file.Size} KB ");
                }
            }
        }
    }
}