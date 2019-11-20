namespace Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DummyTests
    {
        private ITarget target;
        private IWeapon weapon;

        [Test]
        public void TestDummyLosesHealthIfAttacked()
        {
            // Arrange
            target = new Dummy(10, 10);
            weapon = new Axe(5, 10);

            // Act
            weapon.Attack(target);
            var actual = target.Health;
            var expected = 5;

            // Assert
            Assert.AreEqual(expected, actual, "Dummy doesn't lose health if attacked.");
        }

        [Test]
        public void TestDeadDummyThrowsExceptionIfAttacked()
        {
            // Arrange
            target = new Dummy(0, 10);
            weapon = new Axe(10, 10);

            // Act

            // Assert
            Assert.Throws<InvalidOperationException>(() => weapon.Attack(target), "Dead dummy doesn't throw an invalid operation exception if attacked.");
        }

        [Test]
        public void TestDeadDummyCanGiveXP()
        {
            // Arrange
            target = new Dummy(0, 10);

            // Act
            var actual = target.GiveExperience();
            var expected = 10;

            // Assert
            Assert.AreEqual(expected, actual, "Dead dummy doesn't give XP.");
        }

        [Test]
        public void TestAliveDummyCantGiveXP()
        {
            // Arrange
            target = new Dummy(10, 10);

            // Act

            // Assert
            Assert.Throws<InvalidOperationException>(() => target.GiveExperience(), "Alive dummy gives XP.");
        }
    }
}
