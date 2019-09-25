namespace Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AxeTests
    {
        private const int DummyHealth = 10;
        private const int DummyExperience = 10;

        private ITarget target;
        private IWeapon weapon;

        [SetUp]
        public void CreateDummy()
        {
            target = new Dummy(DummyHealth, DummyExperience);
        }

        [Test]
        public void TestIfAxeLosesDurabilityAfterEachAttack()
        {
            // Arrange
            weapon = new Axe(10, 10);

            // Act
            weapon.Attack(target);
            var actual = weapon.DurabilityPoints;
            var expected = 9;

            // Assert
            Assert.AreEqual(expected, actual, "Axe doesn't lose durability after an attack.");
        }

        [Test]
        public void TestAttackingWithBrokenAxe()
        {
            // Arrange
            weapon = new Axe(10, 0);

            // Act

            // Assert
            Assert.Throws<InvalidOperationException>(() => weapon.Attack(target), "Attacking with a broken axe doesn't throw invalid operation exception.");
        }
    }
}
