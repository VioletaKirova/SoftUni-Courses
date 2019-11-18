namespace _08_PetClinic
{
    using System;

    public class Pet : IPet, IComparable<Pet>
    {
        public Pet(string name, int age, string kind)
        {
            this.Name = name;
            this.Age = age;
            this.Kind = kind;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Kind { get; private set; }

        public int CompareTo(Pet other)
        {
            return this.Name.CompareTo(other.Name);
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Age} {this.Kind}";
        }
    }
}
