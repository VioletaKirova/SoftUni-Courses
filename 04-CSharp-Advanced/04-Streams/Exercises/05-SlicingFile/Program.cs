using System;
using System.Collections.Generic;
using System.IO;

namespace _05_SlicingFile
{
    class Program
    {
        static string sourceFileDestination = "sliceMe.mp4";

        static string outputDirectory = "";

        static string sourceFileExtension = sourceFileDestination.Substring(sourceFileDestination.IndexOf('.'));

        static int numberOfParts = 5;

        static void Main(string[] args)
        {
            Slice(sourceFileDestination, outputDirectory, numberOfParts);

            List<string> files = new List<string>();

            for (int i = 0; i < numberOfParts; i++)
            {
                files.Add($"Part-{i}{sourceFileExtension}");
            }

            Assemble(files, outputDirectory);
        }

        static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            using (FileStream originalFile = new FileStream(sourceFile, FileMode.Open))
            {
                int partSize = (int)(Math.Ceiling((double)originalFile.Length / parts));

                byte[] buffer = new byte[partSize];

                int bytes = originalFile.Read(buffer, 0, buffer.Length);

                for (int i = 0; i < parts; i++)
                {
                    using (FileStream filePart = new FileStream(destinationDirectory + $"Part-{i}{sourceFileExtension}", FileMode.Create))
                    {
                        filePart.Write(buffer, 0, buffer.Length);

                        bytes = originalFile.Read(buffer, 0, buffer.Length);
                    }
                }
            }
        }

        static void Assemble(List<string> files, string destinationDirectory)
        {          
            using (FileStream assembler = new FileStream($"assembled{sourceFileExtension}", FileMode.Create))
            {
                foreach (var f in files)
                {
                    using (FileStream reader = new FileStream(f, FileMode.Open))
                    {
                        byte[] buffer = new byte[reader.Length];

                        int bytes = reader.Read(buffer, 0, buffer.Length);

                        assembler.Write(buffer, 0, bytes);
                    }
                }
            }             
        }
    }
}
