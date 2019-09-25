using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace _06_ZippingSlicedFiles2
{
    class Program
    {
        static List<string> paths;

        static void Main(string[] args)
        {
            string sourceFile = "..//..//..//..//Resources//sliceMe.mp4";
            string destination = "..//..//..//..//Resources//";
            int parts = 5;

            paths = new List<string>();

            Slice(sourceFile, destination, parts);

            Assemble(paths, destination + "assembled.mp4");
        }

        static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            using (FileStream reader = new FileStream(sourceFile, FileMode.Open))
            {
                long size = reader.Length / parts + reader.Length % parts;

                byte[] buffer = new byte[size];

                for (int i = 0; i < parts; i++)
                {
                    string partDestinationDirectory = destinationDirectory + $"Part-{i}.mp4";

                    paths.Add(partDestinationDirectory);

                    using (FileStream writer = new FileStream(partDestinationDirectory, FileMode.Create))
                    {
                        int bytes = reader.Read(buffer, 0, buffer.Length);

                        writer.Write(buffer, 0, buffer.Length);
                    }

                    using (GZipStream gz = new GZipStream(new FileStream(partDestinationDirectory + ".gz", FileMode.Create), CompressionMode.Compress))
                    {
                        gz.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }

        static void Assemble(List<string> paths, string destinationDirectory)
        {
            using (FileStream writer = new FileStream(destinationDirectory, FileMode.Create))
            {
                byte[] buffer = new byte[4096];

                foreach (var path in paths)
                {
                    using (GZipStream gz = new GZipStream(new FileStream(path + ".gz", FileMode.Open), CompressionMode.Decompress))
                    {
                        int bytes = gz.Read(buffer, 0, buffer.Length);

                        while (bytes != 0)
                        {
                            writer.Write(buffer, 0, bytes);

                            bytes = gz.Read(buffer, 0, buffer.Length);
                        }
                    }
                }
            }
        }

    }
}
