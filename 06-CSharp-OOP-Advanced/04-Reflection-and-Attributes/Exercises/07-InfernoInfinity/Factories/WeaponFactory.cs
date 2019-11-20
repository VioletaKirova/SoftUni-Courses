namespace _07_InfernoInfinity.Factories
{
    using Contracts;
    using Enums;
    using System;
    using System.Linq;
    using System.Reflection;

    public class WeaponFactory : IWeaponFactory
    {
        public IWeapon CreateWeapon(string weaponType, string[] data, string name, Rarity rarity)
        {
            Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == weaponType);
            var instance = (IWeapon)Activator.CreateInstance(type, new object[] { name, rarity });

            return instance;
        }
    }
}
