using _06_Animals.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _06_Animals
{
    public class Frog :Animal, ISoundProducable
    {
        public Frog(string name, int age, string gender)
            : base(name, age, gender)
        {

        }

        public override void ProduceSound()
        {
            Console.WriteLine("Ribbit");
        }
    }
}
