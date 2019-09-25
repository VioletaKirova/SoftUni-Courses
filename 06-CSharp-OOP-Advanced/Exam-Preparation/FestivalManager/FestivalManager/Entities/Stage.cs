namespace FestivalManager.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;

	public class Stage : IStage
	{
        private readonly List<ISet> sets;
        private readonly List<ISong> songs;
        private readonly List<IPerformer> performers;

        public Stage()
        {
            this.sets = new List<ISet>();
            this.songs = new List<ISong>();
            this.performers = new List<IPerformer>();
        }

        public IReadOnlyCollection<ISet> Sets => this.sets;

        public IReadOnlyCollection<ISong> Songs =>this.songs;

        public IReadOnlyCollection<IPerformer> Performers => this.performers;

        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);
        }

        public void AddSet(ISet performer)
        {
            this.sets.Add(performer);
        }

        public void AddSong(ISong song)
        {
            this.songs.Add(song);
        }

        public IPerformer GetPerformer(string name)
        {
            IPerformer performer = this.performers.First(p => p.Name == name);

            if (performer == null)
            {
                throw new InvalidOperationException($"Performer with name:{name} doesn't exist.");
            }
            else
            {
                return performer;
            }
        }

        public ISet GetSet(string name)
        {
            ISet set = this.sets.First(p => p.Name == name);

            if (set == null)
            {
                throw new InvalidOperationException($"Set with name:{name} doesn't exist.");
            }
            else
            {
                return set;
            }
        }

        public ISong GetSong(string name)
        {
            ISong song = this.songs.First(p => p.Name == name);

            if (song == null)
            {
                throw new InvalidOperationException($"Song with name:{name} doesn't exist.");
            }
            else
            {
                return song;
            }
        }

        public bool HasPerformer(string name)
        {
            bool isPerformerValid = this.performers.Any(p => p.Name == name);

            if (!isPerformerValid)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool HasSet(string name)
        {
            bool isSetValid = this.sets.Any(p => p.Name == name);

            if (!isSetValid)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool HasSong(string name)
        {
            bool isSongValid = this.songs.Any(p => p.Name == name);

            if (!isSongValid)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
