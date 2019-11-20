using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _07_DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();

            var files = Directory.GetFiles(path);

            var filesDictionary = new Dictionary<string, List<FileInfo>>();

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);

                var extension = fileInfo.Extension;

                if (!filesDictionary.ContainsKey(extension))
                {
                    filesDictionary[extension] = new List<FileInfo>();
                }

                filesDictionary[extension].Add(fileInfo);
            }

            filesDictionary = filesDictionary
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, y => y.Value);

            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); ;

            string fileName = desktop + "/report.txt";

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (var pair in filesDictionary)
                {
                    string fileExtension = pair.Key;

                    writer.WriteLine(fileExtension);

                    var fileInfos = pair.Value.OrderBy(x => x.Length);

                    foreach (var fileInfo in fileInfos)
                    {
                        double fileSize = (double)fileInfo.Length / 1024;

                        writer.WriteLine($"--{fileInfo.Name} - {fileSize:f3}kb");
                    }
                }
            }
        }
    }
}
