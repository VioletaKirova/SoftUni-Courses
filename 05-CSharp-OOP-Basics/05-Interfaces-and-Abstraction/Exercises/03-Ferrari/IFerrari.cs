namespace _03_Ferrari
{
    public interface IFerrari
    {
        string Model { get; }
        string Driver { get; set; }

        string PushBrakes();
        string PushGasPedal();
    }
}
