using System.IO;

namespace _02_LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceFile = "..//..//..//..//Resources//text.txt";
            string destinationPath = "..//..//..//..//Resources//output.txt";

            using (StreamReader reader = new StreamReader(sourceFile))
            {
                using (StreamWriter writer = new StreamWriter(destinationPath))
                {
                    string line = reader.ReadLine();

                    int lineNumber = 0;

                    while (line != null)
                    {
                        lineNumber++;

                        writer.WriteLine($"Line {lineNumber}: {line}");

                        line = reader.ReadLine();
                    }               
                }
            }
        }
    }
}
