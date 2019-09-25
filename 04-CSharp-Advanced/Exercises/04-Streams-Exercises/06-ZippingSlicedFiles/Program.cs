using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace _05_SlicingFile_2
{
    class Program
    {
        private const int bufferSize = 4096;

        static void Main(string[] args)
        {
            string sourceFile = "sliceMe.mp4";

            string destination = "";

            int parts = 5;

            Zip(sourceFile, destination, parts);

            List<string> files = new List<string>
            {
                "Part-0.mp4.gz",
                "Part-1.mp4.gz",
                "Part-2.mp4.gz",
                "Part-3.mp4.gz",
                "Part-4.mp4.gz"
            };

            Unzip(files, destination);
        }      

        static void Zip(string sourceFile, string destinationDirectory, int parts)
        {
            using (FileStream reader = new FileStream(sourceFile, FileMode.Open))
            {
                string extension = sourceFile.Substring(sourceFile.IndexOf(".") + 1);

                long partSize = (long)(Math.Ceiling((double)reader.Length / parts));

                for (int i = 0; i < parts; i++)
                {
                    long currentPartSize = 0;

                    if (destinationDirectory == string.Empty)
                    {
                        destinationDirectory = "./";
                    }

                    string currentPart = destinationDirectory + $"Part-{i}.{extension}.gz";

                    using (GZipStream compressor = new GZipStream(new FileStream(currentPart, FileMode.Create), CompressionLevel.Optimal))
                    {
                        byte[] buffer = new byte[bufferSize];

                        while (reader.Read(buffer, 0, bufferSize) == bufferSize)
                        {
                            compressor.Write(buffer, 0, bufferSize);

                            currentPartSize += bufferSize;

                            if (currentPartSize >= partSize)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        static void Unzip(List<string> files, string destinationDirectory)
        {
            string extension = files[0].Substring(files[0].IndexOf(".") + 1, files[0].Length - files[0].IndexOf(".gz"));

            if (destinationDirectory == string.Empty)
            {
                destinationDirectory = "./";
            }

            if (!destinationDirectory.EndsWith("/"))
            {
                destinationDirectory += "/";
            }

            string assembledFile = destinationDirectory + $"assembled.{extension}";

            using (FileStream writer = new FileStream(assembledFile, FileMode.Create))
            {
                byte[] buffer = new byte[bufferSize];

                foreach (var file in files)
                {
                    using (GZipStream decompressor = new GZipStream(new FileStream(file, FileMode.Open), CompressionMode.Decompress))
                    {
                        while (decompressor.Read(buffer, 0, bufferSize) == bufferSize)
                        {
                            writer.Write(buffer, 0, bufferSize);
                        }
                    }
                }
            }
        }
    }
}
