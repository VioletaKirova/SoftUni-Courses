namespace Travel.Entities.Airplanes
{
	public class LightAirplane : Airplane
	{
        private const int defaultSeats = 5;
        private const int defaultBaggageCompartments = 8;

		public LightAirplane()
			: base(defaultSeats, defaultBaggageCompartments)
		{
		}
	}
}