using _05_BorderControl.Contracts;

namespace _05_BorderControl.Models
{
    public class Citizen : IIdentifiable
    {
        public Citizen(string name, string age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
        }

        public string Name { get; private set; }
        public string Age { get; private set; }
        public string Id { get; private set; }
    }
}
