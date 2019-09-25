using _06_Animals.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _06_Animals
{
    public class Tomcat : Cat, ISoundProducable
    {
        public Tomcat(string name, int age)
            :base(name, age, "Male")
        {

        }

        public override void ProduceSound()
        {
            Console.WriteLine("MEOW");
        }
    }
}
