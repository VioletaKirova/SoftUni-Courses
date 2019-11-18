namespace _07_InfernoInfinity
{
    using Contracts;
    using Core;
    using Data;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IWeaponRepository weaponRepository = new WeaponRepository();
            IEngine engine = new Engine(weaponRepository);
            engine.Run();
        }
    }
}
