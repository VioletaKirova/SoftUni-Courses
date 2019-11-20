using _06_BirthdayCelebrations.Contracts;

namespace _06_BirthdayCelebrations.Models
{
    public class Citizen : IIdentifiable, IBirthable
    {
        public Citizen(string name, string age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }

        public string Name { get; private set; }
        public string Age { get; private set; }
        public string Id { get; private set; }
        public string Birthdate { get; private set; }
    }
}
