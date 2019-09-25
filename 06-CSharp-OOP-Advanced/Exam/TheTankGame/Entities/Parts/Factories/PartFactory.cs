namespace TheTankGame.Entities.Parts.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using TheTankGame.Entities.Parts.Contracts;
    using TheTankGame.Entities.Parts.Factories.Contracts;

    public class PartFactory : IPartFactory
    {
        public IPart CreatePart(string partType, string model, double weight, decimal price, int additionalParameter)
        {
            Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name.StartsWith(partType));
            var instance = (IPart)Activator.CreateInstance(type, new object[] { model, weight, price, additionalParameter });
            return instance;
        }
    }
}
