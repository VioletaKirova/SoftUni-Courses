namespace Tests
{
    using BoxOfT;
    using Xunit;

    public class BoxTests
    {
        [Fact]
        public void BoxRemove_ShouldReturnRemovedElement()
        {
            // Arrange
            IBox<int> box = new Box<int>();
            box.Add(1);
            box.Add(2);
            box.Add(3);

            // Act
            int element = box.Remove();

            // Assert
            Assert.Equal(3, element);
        }
    }
}
