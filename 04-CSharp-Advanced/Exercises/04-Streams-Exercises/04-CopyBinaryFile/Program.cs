using System.IO;

namespace _04_CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceFile = "..//..//..//..//Resources//copyMe.png";
            string destinationPath = "..//..//..//..//Resources//copyMe-copy.png";

            using (FileStream reader = new FileStream(sourceFile, FileMode.Open))
            {
                using (FileStream writer = new FileStream(destinationPath, FileMode.Create))
                {
                    byte[] buffer = new byte[4096];

                    int bytes = reader.Read(buffer, 0, buffer.Length);

                    while (bytes != 0)
                    {
                        writer.Write(buffer, 0, bytes);

                        bytes = reader.Read(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}
