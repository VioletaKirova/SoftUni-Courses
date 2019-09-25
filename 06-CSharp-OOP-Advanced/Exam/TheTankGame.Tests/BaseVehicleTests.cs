namespace TheTankGame.Tests
{
    using NUnit.Framework;
    using TheTankGame.Entities.Miscellaneous;
    using TheTankGame.Entities.Miscellaneous.Contracts;
    using TheTankGame.Entities.Parts;
    using TheTankGame.Entities.Vehicles;
    using TheTankGame.Entities.Vehicles.Contracts;

    [TestFixture]
    public class BaseVehicleTests
    {
        [Test]
        public void TestAddPartMethods()
        {
            IAssembler assembler = new VehicleAssembler();
            IVehicle vehicle = new Revenger("AKU", 1000, 1000, 1000, 1000, 1000, assembler);

            vehicle.AddArsenalPart(new ArsenalPart("Part1", 300, 500, 450));
            vehicle.AddShellPart(new ShellPart("Part2", 300, 500, 450));
            vehicle.AddEndurancePart(new EndurancePart("Part3", 300, 500, 450));

            int actualArsenalParts = assembler.ArsenalParts.Count;
            int expectedArsenalParts = 1;
            Assert.AreEqual(expectedArsenalParts, actualArsenalParts);

            int actualShellParts = assembler.ShellParts.Count;
            int expectedShellParts = 1;
            Assert.AreEqual(actualShellParts, expectedShellParts);

            int actualEnduranceParts = assembler.EnduranceParts.Count;
            int expectedEnduranceParts = 1;
            Assert.AreEqual(actualEnduranceParts, expectedEnduranceParts);
        }

        [Test]
        public void TestPartsPropertyValue()
        {
            IAssembler assembler = new VehicleAssembler();
            IVehicle vehicle = new Revenger("AKU", 1000, 1000, 1000, 1000, 1000, assembler);

            vehicle.AddArsenalPart(new ArsenalPart("Part1", 300, 500, 450));
            vehicle.AddShellPart(new ShellPart("Part2", 300, 500, 450));
            vehicle.AddEndurancePart(new EndurancePart("Part3", 300, 500, 450));

            string actual = string.Join(" ", vehicle.Parts);
            //Arsenal Part - Part1+450 Attack Shell Part - Part2+450 Defense Endurance Part - Part3+450 HitPoints
            string expected = "Arsenal Part - Part1+450 Attack Shell Part - Part2+450 Defense Endurance Part - Part3+450 HitPoints";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestToStringMethod()
        {
            IAssembler assembler = new VehicleAssembler();
            IVehicle vehicle = new Revenger("AKU", 1000, 1000, 1000, 1000, 1000, assembler);

            vehicle.AddArsenalPart(new ArsenalPart("Part1", 300, 500, 450));
            vehicle.AddShellPart(new ShellPart("Part2", 300, 500, 450));
            vehicle.AddEndurancePart(new EndurancePart("Part3", 300, 500, 450));

            string actual = vehicle.ToString();
            //Revenger - AKU\r\nTotal Weight: 1900.000\r\nTotal Price: 2500.000\r\nAttack: 1450\r\nDefense: 1450\r\nHitPoints: 1450\r\nParts: Part1, Part2, Part3
            string expected = "Revenger - AKU\r\nTotal Weight: 1900.000\r\nTotal Price: 2500.000\r\nAttack: 1450\r\nDefense: 1450\r\nHitPoints: 1450\r\nParts: Part1, Part2, Part3";

            Assert.AreEqual(expected, actual);
        }
    }
}