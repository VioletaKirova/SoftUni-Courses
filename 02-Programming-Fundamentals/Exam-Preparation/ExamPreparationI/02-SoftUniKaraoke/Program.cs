using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_SoftUniKaraoke
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] participants = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            string[] songs = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < participants.Length; i++)
                participants[i] = participants[i].Trim();

            for (int i = 0; i < songs.Length; i++)
                songs[i] = songs[i].Trim();

            var awards = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "dawn")
            {
                string[] currentParticipant = input.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                string name = currentParticipant[0];
                string song = currentParticipant[1];
                string award = currentParticipant[2];

                if (!participants.Contains(name) || !songs.Contains(song))
                {
                    input = Console.ReadLine();
                    continue;
                }

                if (!awards.ContainsKey(name))
                    awards.Add(name, new List<string>());

                if (!awards[name].Contains(award))
                    awards[name].Add(award);

                input = Console.ReadLine();
            }

            if (awards.Count < 1)
                Console.WriteLine("No awards");
            else
            {
                foreach (var p in awards.OrderByDescending(x => x.Value.Count()).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{p.Key}: {p.Value.Count} awards");

                    foreach (var award in p.Value.OrderBy(x => x))
                    {
                        Console.WriteLine($"--{award}");
                    }
                }
            }
        }
    }
}