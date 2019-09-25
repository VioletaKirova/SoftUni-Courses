using _06_Animals.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _06_Animals
{
    public class Cat : Animal, ISoundProducable
    {
        public Cat(string name, int age, string gender)
            :base(name, age, gender)
        {

        }
        
        public override void ProduceSound()
        {
            Console.WriteLine("Meow meow");
        }
    }
}
