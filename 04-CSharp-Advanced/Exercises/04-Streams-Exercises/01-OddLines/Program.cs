using System;
using System.IO;

namespace _01_OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("..//..//..//..//Resources//text.txt"))
            {
                string currentLine = reader.ReadLine();

                int counter = 0;

                while (currentLine != null)
                {
                    if (counter % 2 != 0)
                    {
                        Console.WriteLine(currentLine);
                    }

                    counter++;

                    currentLine = reader.ReadLine();
                }
            }
        }
    }
}
