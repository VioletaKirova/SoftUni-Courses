using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            Person p2 = new Person(55);
            Person p3 = new Person("Sashkata", 22);

            Console.WriteLine(p1.Name + " " + p1.Age);
            Console.WriteLine(p2.Name + " " + p2.Age);
            Console.WriteLine(p3.Name + " " + p3.Age);
        }
    }
}
