namespace Tests
{
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class HeroTestsWithMoq
    {
        [Test]
        public void TestHeroGainsExperienceAfterAttackIfTargetDies()
        {
            // Arrange
            Mock<ITarget> fakeTarget = new Mock<ITarget>();
            fakeTarget.Setup(t => t.Health).Returns(0);
            fakeTarget.Setup(t => t.GiveExperience()).Returns(10);
            fakeTarget.Setup(t => t.IsDead()).Returns(true);

            Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();

            Hero hero = new Hero("Pesho", fakeWeapon.Object);

            // Act
            hero.Attack(fakeTarget.Object);
            var actual = hero.Experience;
            var expected = 10;

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
