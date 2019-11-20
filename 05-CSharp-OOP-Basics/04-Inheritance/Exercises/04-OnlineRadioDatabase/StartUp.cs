using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_OnlineRadioDatabase
{
    // 63/100

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Song> playlist = new List<Song>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                try
                {
                    string[] songInfo = Console.ReadLine()
                    .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                    Validator.ValidateSong(songInfo);

                    Artist artist = new Artist(songInfo[0]);

                    string songName = songInfo[1];

                    string[] songLenInfo = songInfo[2]
                        .Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);


                    Validator.ValidateSongTotalLengthInput(songLenInfo);

                    int songMinutes = int.Parse(songLenInfo[0]);
                    int songSeconds = int.Parse(songLenInfo[1]);

                    long songLenSecs = songMinutes * 60 + songSeconds;

                    Song song = new Song(artist, songName, songLenSecs, songMinutes, songSeconds);

                    playlist.Add(song);
                    Console.WriteLine("Song added.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }

            long totalPlaylistSecs = playlist.Sum(s => s.SongLenSecs);

            //int playlistHours = (int)totalPlaylistSecs / 3600;
            //int playlistMins = ((int)totalPlaylistSecs / 60) % 60;
            //int playlistSecs = (int)totalPlaylistSecs % 60;

            TimeSpan timeSpan = TimeSpan.FromSeconds(totalPlaylistSecs);

            Console.WriteLine($"Songs added: {playlist.Count}");
            Console.WriteLine($"Playlist length: {timeSpan.Hours}h {timeSpan.Minutes}m {timeSpan.Seconds}s");
        }
    }
}
