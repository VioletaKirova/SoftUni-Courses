using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_DifferentIntegersSize
{
    class Program
    {
        static void Main(string[] args)
        {
            // sbyte < byte < short < ushort < int < uint < long
            string n = Console.ReadLine();
            bool canFit = false;
            string message = "";

            try
            {
                sbyte sbyteN = sbyte.Parse(n);
                message += "* sbyte\n";
                canFit = true;
            }
            catch (Exception)
            {
            }

            try
            {
                byte byteN = byte.Parse(n);
                message += "* byte\n";
                canFit = true;
            }
            catch (Exception)
            {
            }

            try
            {
                short shortN = short.Parse(n);
                message += "* short\n";
                canFit = true;
            }
            catch (Exception)
            {
            }

            try
            {
                ushort ushortN = ushort.Parse(n);
                message += "* ushort\n";
                canFit = true;
            }
            catch (Exception)
            {
            }

            try
            {
                int intN = int.Parse(n);
                message += "* int\n";
                canFit = true;
            }
            catch (Exception)
            {
            }

            try
            {
                uint uintN = uint.Parse(n);
                message += "* uint\n";
                canFit = true;
            }
            catch (Exception)
            {
            }

            try
            {
                long longN = long.Parse(n);
                message += "* long\n";
                canFit = true;
            }
            catch (Exception)
            {
            }

            if (canFit)
            {
                Console.WriteLine($"{n} can fit in:");
                Console.WriteLine(message);
            }
            else
            {
                Console.WriteLine($"{n} can't fit in any type");
            }
        }
    }
}
