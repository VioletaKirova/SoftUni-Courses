namespace Travel.Entities.Airplanes
{
	public class MediumAirplane : Airplane
	{
        private const int defaultSeats = 10;
        private const int defaultBaggageCompartments = 14;

        public MediumAirplane()
			: base(defaultSeats, defaultBaggageCompartments)
		{
		}
	}
}