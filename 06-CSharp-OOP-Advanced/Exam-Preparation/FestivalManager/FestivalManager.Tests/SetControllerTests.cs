// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
namespace FestivalManager.Tests
{
    using System;

    using NUnit.Framework;
    using FestivalManager.Core.Controllers;
    using FestivalManager.Core.Controllers.Contracts;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Contracts;
    using FestivalManager.Entities.Instruments;
    using FestivalManager.Entities.Sets;

    [TestFixture]
	public class SetControllerTests
    {
		[Test]
        public void TestPerformSetsMethodFails()
        {
            IStage stage = new Stage();
            ISetController setController = new SetController(stage);

            ISet set = new Short("Set1");
            stage.AddSet(set);

            string actual = setController.PerformSets();
            string expected = "1. Set1:\r\n-- Did not perform";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestPerformSetsMethodSucceeds()
        {
            IStage stage = new Stage();
            ISetController setController = new SetController(stage);

            ISet set = new Short("Set1");
            stage.AddSet(set);

            IPerformer performer = new Performer("Gosho", 20);
            IInstrument instrument = new Guitar();
            performer.AddInstrument(instrument);
            set.AddPerformer(performer);

            ISong song = new Song("Song1", new TimeSpan(0, 2, 20));
            set.AddSong(song);

            string actual = setController.PerformSets();
            string expected = "1. Set1:\r\n-- 1. Song1 (02:20)\r\n-- Set Successful";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestPerformSetsMethodWearsDownInstruments()
        {
            IStage stage = new Stage();
            ISetController setController = new SetController(stage);

            ISet set = new Short("Set1");
            stage.AddSet(set);

            IPerformer performer = new Performer("Gosho", 20);
            IInstrument instrument = new Guitar();
            performer.AddInstrument(instrument);
            set.AddPerformer(performer);

            ISong song = new Song("Song1", new TimeSpan(0, 2, 20));
            set.AddSong(song);

            setController.PerformSets();

            double actualWearAfterPerformance = instrument.Wear;
            double expectedWearAfterPerformance = 40;

            Assert.AreEqual(expectedWearAfterPerformance, actualWearAfterPerformance);
        }
    }
}