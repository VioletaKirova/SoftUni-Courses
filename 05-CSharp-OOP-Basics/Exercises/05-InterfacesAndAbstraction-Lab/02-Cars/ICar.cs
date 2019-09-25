namespace Cars
{
    public interface ICar
    {
        string Model { get; }
        string Color { get; set; }

        string Start();

        string Stop();
    }
}
