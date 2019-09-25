using System;
using System.Collections.Generic;
using System.Text;

namespace _04_OnlineRadioDatabase
{
    public class Song
    {
        private Artist artist;
        private string name;
        private long songLenSecs;
        private int minutes;
        private int seconds;

        public Song(Artist artist, string name, long songLenSecs, int minutes, int seconds)
        {
            this.Artist = artist;
            this.Name = name;
            this.SongLenSecs = songLenSecs;
            this.Minutes = minutes;
            this.Seconds = seconds;
        }

        public Artist Artist
        {
            get { return artist; }
            set { artist = value; }
        }

        public string Name
        {
            get { return name; }
            set
            {
                Validator.ValidateSongName(value);

                name = value;
            }
        }


        public long SongLenSecs
        {
            get { return songLenSecs; }
            set
            {
                Validator.ValidateSongTotalLength(value);

                songLenSecs = value;
            }
        }

        public int Minutes
        {
            get { return minutes; }
            set
            {
                Validator.ValidatSongMinutes(value);

                minutes = value;
            }
        }

        public int Seconds
        {
            get { return seconds; }
            set
            {
                Validator.ValidateSongSeconds(value);

                seconds = value;
            }
        }      
    }
}
