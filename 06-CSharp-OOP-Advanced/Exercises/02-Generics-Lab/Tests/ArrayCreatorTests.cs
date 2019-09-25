namespace Tests
{
    using GenericArrayCreator;
    using Xunit;

    public class ArrayCreatorTests
    {
        [Fact]
        public void ArrayCreatorCreate_ShouldHaveFourItems()
        {
            // Arrange
            int[] array = ArrayCreator.Create<int>(4, 1);
            int arrayLength = array.Length;

            // Act

            // Assert
            Assert.Equal(4, arrayLength);
        }
    }
}
