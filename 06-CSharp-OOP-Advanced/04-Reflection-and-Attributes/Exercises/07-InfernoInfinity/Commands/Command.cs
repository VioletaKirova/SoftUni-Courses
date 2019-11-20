namespace _07_InfernoInfinity.Commands
{
    using Factories;
    using Contracts;

    public abstract class Command : ICommand
    {
        protected Command(string type, string[] data, IWeaponRepository weaponRepository)
        {
            this.Type = type;
            this.Data = data;
            this.WeaponRepository = weaponRepository;
            this.WeaponFactory = new WeaponFactory();
            this.GemFactory = new GemFactory();
        }

        public string Type { get; private set; }

        public string[] Data { get; private set; }

        public IWeaponRepository WeaponRepository { get;private set; }

        public WeaponFactory WeaponFactory { get; private set; }

        public GemFactory GemFactory { get; private set; }

        public abstract void Execude();
    }
}
