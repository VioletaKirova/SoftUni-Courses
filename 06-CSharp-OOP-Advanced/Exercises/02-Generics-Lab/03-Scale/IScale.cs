namespace GenericScale
{
    public interface IScale<T>
    {
        T Left { get; set; }

        T Right { get; set; }

        T GetHeavier();
    }
}
