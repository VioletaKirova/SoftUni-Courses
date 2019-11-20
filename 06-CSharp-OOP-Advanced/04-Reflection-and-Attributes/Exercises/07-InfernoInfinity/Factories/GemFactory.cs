namespace _07_InfernoInfinity.Factories
{
    using _07_InfernoInfinity.Contracts;
    using _07_InfernoInfinity.Enums;
    using System;
    using System.Linq;
    using System.Reflection;

    public class GemFactory : IGemFactory
    {
        public IGem CreateGem(string gemType, Clarity clarity)
        {
            Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == gemType);
            IGem instance = (IGem)Activator.CreateInstance(type, new object[] { clarity });

            return instance;
        }
    }
}
