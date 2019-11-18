namespace Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class HeroTests
    {
        private ITarget fakeTarget;
        private IWeapon fakeWeapon;

        [SetUp]
        public void CreateTargetAndWeapon()
        {
            fakeTarget = new FakeDummy();
            fakeWeapon = new FakeAxe();
        }

        [Test]
        public void TestHeroGainsExperienceAfterAttackIfTargetDies()
        {
            // Arrange
            Hero hero = new Hero("Pesho", fakeWeapon);

            // Act
            hero.Attack(fakeTarget);
            var actual = hero.Experience;
            var expected = 10;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
