using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_MovieTime
{
    class Program
    {
        static void Main(string[] args)
        {
            string genre = Console.ReadLine();
            string duration = Console.ReadLine();

            Dictionary<string, TimeSpan> playList = new Dictionary<string, TimeSpan>();

            TimeSpan totalPlaylistDuration = new TimeSpan();

            string input = Console.ReadLine();

            while (input != "POPCORN!")
            {
                string[] filmInfo = input.Split('|', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string filmName = filmInfo[0];
                string filmGenre = filmInfo[1];
                int[] filmTimeSpanInfo = filmInfo[2].Split(':', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                TimeSpan filmTimeSpan = new TimeSpan(filmTimeSpanInfo[0], filmTimeSpanInfo[1], filmTimeSpanInfo[2]);

                totalPlaylistDuration += filmTimeSpan;

                if (filmGenre == genre)
                {
                    playList[filmName] = filmTimeSpan;
                }

                input = Console.ReadLine();
            }
            
            if (duration == "Short")
            {
                playList = playList.OrderBy(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);
            }
            else if (duration == "Long")
            {
                playList = playList.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);
            }

            string faveFilm = string.Empty;

            foreach (var film in playList)
            {
                Console.WriteLine(film.Key);
                faveFilm = film.Key;

                input = Console.ReadLine();

                if (input == "Yes")
                {
                    break;
                }
            }
            
            string format = @"hh\:mm\:ss";

            Console.WriteLine($"We're watching {faveFilm} - {playList[faveFilm].ToString(format)}");
            Console.WriteLine($"Total Playlist Duration: {totalPlaylistDuration.ToString(format)}");
        }
    }
}
