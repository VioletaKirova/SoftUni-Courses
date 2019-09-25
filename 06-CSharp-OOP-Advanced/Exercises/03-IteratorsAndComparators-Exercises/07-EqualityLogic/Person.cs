namespace _07_EqualityLogic
{
    public class Person : IPerson
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public int CompareTo(IPerson other)
        {
            int result = this.Name.CompareTo(other.Name);

            if (result == 0)
            {
                result = this.Age.CompareTo(other.Age);
            }

            return result;
        }

        public override bool Equals(object obj)
        {
            IPerson other = (Person)obj;
            return this.Name == other.Name && this.Age == other.Age;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + this.Age.GetHashCode();
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Age}";
        }
    }
}
