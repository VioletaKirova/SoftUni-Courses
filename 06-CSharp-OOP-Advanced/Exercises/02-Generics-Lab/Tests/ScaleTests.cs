namespace Tests
{
    using GenericScale;
    using Xunit;

    public class ScaleTests
    {
        [Fact]
        public void ScaleGetHeavier_ShouldReturnLeftSide()
        {
            // Arrange
            IScale<int> scale = new Scale<int>(2, 1);

            // Act
            int heavierElement = scale.GetHeavier();

            // Assert
            Assert.Equal(2, heavierElement);
        }
    }
}
