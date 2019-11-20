using System;
using System.Linq;

namespace P03_JediGalaxy
{
    public class StartUp
    {
        static Galaxy galaxy;

        static void Main()
        {
            int[] dimestions = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimestions[0];
            int cols = dimestions[1];

            galaxy = new Galaxy(rows, cols);
            galaxy.SetGalaxyStarValue();

            string command = Console.ReadLine();

            long sum = 0;

            while (command != "Let the Force be with you")
            {
                int[] playerPosition = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int[] evilPosition = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int evilRow = evilPosition[0];
                int evilCol = evilPosition[1];
                Player evil = new Player(evilRow, evilCol);

                while (evil.Row >= 0 && evil.Col >= 0)
                {
                    if (galaxy.IsInside(evil.Row, evil.Col))
                    {
                        galaxy.Matrix[evil.Row, evil.Col] = 0;
                    }

                    evil.Row--;
                    evil.Col--;
                }

                int playerRow = playerPosition[0];
                int playerCol = playerPosition[1];
                Player player = new Player(playerRow, playerCol);

                while (player.Row >= 0 && player.Col < galaxy.Matrix.GetLength(1))
                {
                    if (galaxy.IsInside(player.Row, player.Col))
                    {
                        sum += galaxy.Matrix[player.Row, player.Col];
                    }

                    player.Row--;
                    player.Col++;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);

        }
    }
}
