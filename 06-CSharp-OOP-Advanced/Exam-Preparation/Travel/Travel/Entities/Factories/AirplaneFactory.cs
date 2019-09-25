namespace Travel.Entities.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Airplanes.Contracts;
    using Contracts;

    public class AirplaneFactory : IAirplaneFactory
	{
		public IAirplane CreateAirplane(string type)
		{
            Type airplaneType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);
            IAirplane instance = (IAirplane)(Activator.CreateInstance(airplaneType));
            return instance;
		}
	}
}