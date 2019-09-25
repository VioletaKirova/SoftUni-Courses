namespace Travel.Entities.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;
    using Items.Contracts;

    public class ItemFactory : IItemFactory
	{
		public IItem CreateItem(string type)
		{
            Type itemType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);
            IItem instance = (IItem)(Activator.CreateInstance(itemType));
            return instance;
		}
	}
}
