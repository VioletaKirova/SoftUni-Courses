namespace FestivalManager.Core.Controllers
{
    using Contracts;
    using Entities.Contracts;
    using FestivalManager.Entities.Factories;
    using FestivalManager.Entities.Factories.Contracts;
    using System;
    using System.Linq;

    public class FestivalController : IFestivalController
	{
        private IInstrumentFactory instrumentFactory;
        private IPerformerFactory performerFactory;
        private ISetFactory setFactory;
        private ISongFactory songFactory;

        private const string TimeFormat = "mm\\:ss";
		private const string TimeFormatLong = "{0:2D}:{1:2D}";
		//const string TimeFormatThreeDimensional = "{0:3D}:{1:3D}";

		private readonly IStage stage;

		public FestivalController(IStage stage)
		{
			this.stage = stage;
            this.instrumentFactory = new InstrumentFactory();
            this.performerFactory = new PerformerFactory();
            this.setFactory = new SetFactory();
            this.songFactory = new SongFactory();
        }

		public string ProduceReport()
		{
			var result = string.Empty;

			var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

            result += ($"Festival length: {FormatTimeSpan(totalFestivalLength)}") + "\n";

			foreach (var set in this.stage.Sets)
			{
				result += ($"--{set.Name} ({FormatTimeSpan(set.ActualDuration)}):") + "\n";

				var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
				foreach (var performer in performersOrderedDescendingByAge)
				{
                    // TODO check if instrument is broken
					var instruments = string.Join(", ", performer.Instruments
						.OrderByDescending(i => i.Wear));

					result += ($"---{performer.Name} ({instruments})") + "\n";
				}

				if (!set.Songs.Any())
					result += ("--No songs played") + "\n";
				else
				{
					result += ("--Songs played:") + "\n";
					foreach (var song in set.Songs)
					{
						result += ($"----{song.Name} ({song.Duration.ToString(TimeFormat)})") + "\n";
					}
				}
			}

			return result.ToString();
		}

        public string RegisterSet(string[] args)
		{
            string name = args[0];
            string type = args[1];

            ISet set = this.setFactory.CreateSet(name, type);

            this.stage.AddSet(set);

            return $"Registered {type} set";
		}

		public string SignUpPerformer(string[] args)
		{
			var name = args[0];
			var age = int.Parse(args[1]);

            IPerformer performer = this.performerFactory.CreatePerformer(name, age); ;

            if (args.Length > 2)
            {
                var instrumentTypes = args.Skip(2).ToArray();

                var isntruments = instrumentTypes
                    .Select(i => this.instrumentFactory.CreateInstrument(i))
                    .ToArray();

                foreach (var instrument in isntruments)
                {
                    performer.AddInstrument(instrument);
                }
            }

			this.stage.AddPerformer(performer);

			return $"Registered performer {performer.Name}";
		}

		public string RegisterSong(string[] args)
		{
            string name = args[0];
            TimeSpan duration = TimeSpan.ParseExact(args[1], TimeFormat, null);
            ISong song = this.songFactory.CreateSong(name, duration);

            this.stage.AddSong(song);

            return $"Registered song {song.Name} ({duration.ToString(TimeFormat)})";
        }

		//public string SongRegistration(string[] args)
		//{
			//var songName = args[0];
			//var setName = args[1];

			//if (!this.stage.HasSet(setName))
			//{
			//	throw new InvalidOperationException("Invalid set provided");
			//}

			//if (!this.stage.HasSong(songName))
			//{
			//	throw new InvalidOperationException("Invalid song provided");
			//}

			//var set = this.stage.GetSet(setName);
			//var song = this.stage.GetSong(songName);

			//set.AddSong(song);

			//return $"Added {song} to {set.Name}";
		//}

		// Временно!!! Чтобы работало делаем срез на конец месяца
		public string AddPerformerToSet(string[] args)
		{
            var performerName = args[0];
            var setName = args[1];

            if (!this.stage.HasPerformer(performerName))
            {
                throw new InvalidOperationException("Invalid performer provided");
            }

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            var performer = this.stage.GetPerformer(performerName);
            var set = this.stage.GetSet(setName);

            set.AddPerformer(performer);

            return $"Added {performer.Name} to {set.Name}";
        }

		//public string PerformerRegistration(string[] args)
		//{
			//var performerName = args[0];
			//var setName = args[1];

			//if (!this.stage.HasPerformer(performerName))
			//{
			//	throw new InvalidOperationException("Invalid performer provided");
			//}

			//if (!this.stage.HasSet(setName))
			//{
			//	throw new InvalidOperationException("Invalid set provided");
			//}

			//AddPerformerToSet(args);

			//var performer = this.stage.GetPerformer(performerName);
			//var set = this.stage.GetSet(setName);

			//set.AddPerformer(performer);

			//return $"Added {performer.Name} to {set.Name}";
		//}

		public string RepairInstruments(string[] args)
		{
			var instrumentsToRepair = this.stage.Performers
				.SelectMany(p => p.Instruments)
				.Where(i => i.Wear < 100)
				.ToArray();

			foreach (var instrument in instrumentsToRepair)
			{
				instrument.Repair();
			}

			return $"Repaired {instrumentsToRepair.Length} instruments";
		}

        public string AddSongToSet(string[] args)
        {
            var songName = args[0];
            var setName = args[1];

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            if (!this.stage.HasSong(songName))
            {
                throw new InvalidOperationException("Invalid song provided");
            }

            var set = this.stage.GetSet(setName);
            var song = this.stage.GetSong(songName);

            set.AddSong(song);

            return $"Added {song.Name} ({song.Duration.ToString(TimeFormat)}) to {set.Name}";
        }

        private static string FormatTimeSpan(TimeSpan timeSpan)
        {
            var formatted = string.Format("{0:D2}:{1:D2}", (int)timeSpan.TotalMinutes, timeSpan.Seconds);
            return formatted;
        }
    }
}