// REMOVE any "using" statements, which start with "Travel." BEFORE SUBMITTING

namespace Travel.Tests
{
	using NUnit.Framework;
    using Travel.Core.Controllers;
    using Travel.Core.Controllers.Contracts;
    using Travel.Entities;
    using Travel.Entities.Airplanes;
    using Travel.Entities.Airplanes.Contracts;
    using Travel.Entities.Contracts;
    using Travel.Entities.Items;
    using Travel.Entities.Items.Contracts;

    [TestFixture]
    public class FlightControllerTests
    {
	    [Test]
	    public void TestTakeOffMethodReturnsCorrectMessageWhenTripOverbooked()
	    {
            IAirport airport = new Airport();
            IAirplane airplane = new LightAirplane();
            ITrip trip = new Trip("Sofia", "Pomorie", airplane);

            for (int i = 0; i < 6; i++)
            {
                trip.Airplane.AddPassenger(new Passenger("Gosho" + i));
            }

            airport.AddTrip(trip);

            IFlightController flightController = new FlightController(airport);

            string actual = flightController.TakeOff();
            string expected = "Overbooked! Ejected Gosho1\r\nConfiscated 0 bags ($0)\r\nSuccessfully transported 5 passengers from Sofia to Pomorie.\r\nConfiscated bags: 0 (0 items) => $0";

            Assert.IsTrue(actual.EndsWith(expected));
        }

        [Test]
        public void TestTakeOffMethodReturnsCorrectMessageWhenCompletedTripIsSkipped()
        {
            IAirport airport = new Airport();
            IAirplane airplane = new LightAirplane();

            ITrip trip = new Trip("Sofia", "Pomorie", airplane);

            IPassenger passenger = new Passenger("Gosho");
            IBag bag = new Bag(passenger, new IItem[] { new Toothbrush() });
            passenger.Bags.Add(bag);
            trip.Airplane.AddPassenger(passenger);

            airport.AddTrip(trip);

            ITrip completedTrip = new Trip("Sf", "Pm", airplane);

            IPassenger passenger2 = new Passenger("Pesho");
            IBag bag2 = new Bag(passenger2, new IItem[] { new Colombian() });
            passenger2.Bags.Add(bag2);
            completedTrip.Airplane.AddPassenger(passenger2);
            completedTrip.Complete();

            airport.AddTrip(completedTrip);

            IFlightController flightController = new FlightController(airport);

            string actual = flightController.TakeOff();
            string expected = "Successfully transported 2 passengers from Sofia to Pomorie.\r\nConfiscated bags: 0 (0 items) => $0";

            Assert.IsTrue(actual.EndsWith(expected));
        }

        [Test]
        public void TestTakeOffMethodReturnsCorrectMessageWhenLuggageIsConfiscated()
        {
            IAirport airport = new Airport();
            IAirplane airplane = new LightAirplane();

            ITrip trip = new Trip("Sofia", "Pomorie", airplane);

            for (int i = 0; i < 6; i++)
            {
                IPassenger passenger = new Passenger("Gosho" + i);

                if (i % 2 == 0)
                {
                    IBag bag = new Bag(passenger, new IItem[] { new Toothbrush() });
                    passenger.Bags.Add(bag);
                }
                else
                {
                    IBag bag = new Bag(passenger, new IItem[] { new Colombian() });
                    passenger.Bags.Add(bag);
                }
                
                trip.Airplane.AddPassenger(passenger);
            }

            airport.AddTrip(trip);

            IFlightController flightController = new FlightController(airport);

            string actual = flightController.TakeOff();
            string expected = "Overbooked! Ejected Gosho1\r\nConfiscated 1 bags ($50000)\r\nSuccessfully transported 5 passengers from Sofia to Pomorie.\r\nConfiscated bags: 1 (1 items) => $50000";

            Assert.IsTrue(actual.EndsWith(expected));
        }
    }
}
