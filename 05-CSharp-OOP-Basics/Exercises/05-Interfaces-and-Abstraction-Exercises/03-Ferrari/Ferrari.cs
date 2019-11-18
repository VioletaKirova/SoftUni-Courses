namespace _03_Ferrari
{
    public class Ferrari : IFerrari
    {
        public Ferrari(string driver)
        {
            Model = "488-Spider";
            Driver = driver;
        }

        public string Model { get; private set; }

        public string Driver { get; set; }

        public string PushBrakes()
        {
            return "Brakes!";
        }

        public string PushGasPedal()
        {
            return "Zadu6avam sA!";
        }

        public override string ToString()
        {
            return $"{Model}/{PushBrakes()}/{PushGasPedal()}/{Driver}";
        }
    }
}
