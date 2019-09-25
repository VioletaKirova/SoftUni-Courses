using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04_OnlineRadioDatabase
{
    public static class Validator
    {
        private const int ARTIST_MIN_NAME_LEN = 3;
        private const int ARTIST_MAX_NAME_LEN = 20;

        private const int SONG_MIN_NAME_LEN = 3;
        private const int SONG_MAX_NAME_LEN = 30;

        private const int MIN_SONG_SECS = 0;
        private const int MAX_SONG_SECS = 14 * 60 + 59;

        private const int MIN_MINUTES = 0;
        private const int MAX_MINUTES = 14;

        private const int MIN_SECONDS = 0;
        private const int MAX_SECONDS = 59;

        public static void ValidateArtistName(string name)
        {
            if (name.Length < ARTIST_MIN_NAME_LEN || name.Length > ARTIST_MAX_NAME_LEN)
            {
                InvalidArtistNameException();
            }
        }
   
        public static void ValidateSong(string[] songInfo)
        {
            if (songInfo.Length != 3)
            {
                InvalidSongException();
            }
        }

        public static void ValidateSongName(string name)
        {
            if (name.Length < SONG_MIN_NAME_LEN || name.Length > SONG_MAX_NAME_LEN)
            {
                InvalidSongNameException();
            }
        }
       
        public static void ValidateSongTotalLengthInput(string[] songLenInfo)
        {
            if (songLenInfo.Length != 2)
            {
                InvalidSongLengthException();
            }

            int minutes;
            int seconds;

            bool parseMinutes = int.TryParse(songLenInfo[0], out minutes);
            bool parseSeconds = int.TryParse(songLenInfo[1], out seconds);

            if (!(parseMinutes && parseSeconds))
            {
                InvalidSongLengthException();
            }
        }

        public static void ValidateSongTotalLength(long songLenSecs)
        {
            if (songLenSecs < MIN_SONG_SECS || songLenSecs > MAX_SONG_SECS)
            {
                InvalidSongLengthException();
            }
        }

        public static void ValidatSongMinutes(int minutes)
        {
            if (minutes < MIN_MINUTES || minutes > MAX_MINUTES)
            {
                InvalidSongMinutesException();
            }
        }

        public static void ValidateSongSeconds(int seconds)
        {
            if (seconds < MIN_SECONDS || seconds > MAX_SECONDS)
            {
                InvalidSongSecondsException();
            }
        }

        private static void InvalidSongSecondsException()
        {
            throw new ArgumentException($"Song seconds should be between {MIN_SECONDS} and {MAX_SECONDS}.");
        }

        private static void InvalidSongMinutesException()
        {
            throw new ArgumentException($"Song minutes should be between {MIN_MINUTES} and {MAX_MINUTES}.");
        }

        private static void InvalidSongLengthException()
        {
            throw new ArgumentException("Invalid song length.");
        }

        private static void InvalidSongNameException()
        {
            throw new ArgumentException($"Song name should be between {SONG_MIN_NAME_LEN} and {SONG_MAX_NAME_LEN} symbols.");
        }

        private static void InvalidArtistNameException()
        {
            throw new ArgumentException($"Artist name should be between {ARTIST_MIN_NAME_LEN} and {ARTIST_MAX_NAME_LEN} symbols.");
        }

        private static void InvalidSongException()
        {
            throw new Exception("Invalid song!");
        }
    }
}
