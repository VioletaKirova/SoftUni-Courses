using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int cakeWidth = int.Parse(Console.ReadLine());
            int cakeLength = int.Parse(Console.ReadLine());
            int allPieces = cakeWidth * cakeLength;
            int takenPieces = 0;
            int notEnough = 0;
            int piecesLeft = 0;

            for (int i = 1; i <= allPieces; i++)
            {
                string input = Console.ReadLine();

                if (input == "STOP")
                {
                    piecesLeft = allPieces - takenPieces;
                    Console.WriteLine($"{piecesLeft} pieces are left.");
                    break;
                }
                else
                {
                    takenPieces += int.Parse(input);
                }

                if (takenPieces > allPieces)
                {
                    notEnough = takenPieces - allPieces;
                    Console.WriteLine($"No more cake left! You need {notEnough} pieces more.");
                    break;
                }
            }
        }
    }
}
