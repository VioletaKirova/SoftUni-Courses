using _06_Animals.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _06_Animals
{
    public class Kitten : Cat, ISoundProducable
    {
        public Kitten(string name, int age)
            : base(name, age, "Female")
        {

        }

        public override void ProduceSound()
        {
            Console.WriteLine("Meow");
        }
    }
}
