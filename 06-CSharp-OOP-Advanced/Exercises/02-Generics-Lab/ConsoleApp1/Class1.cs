namespace ConsoleApp1
{
    using System;

    public abstract class BaseClass
    {
        public BaseClass()
        {
            Console.WriteLine("BaseClass constructor called.");

            VirtualMethod();
            AbstractMethod();
        }

        public virtual void VirtualMethod()
        {
            Console.WriteLine("Base virtual method called");
        }

        public abstract void AbstractMethod();
    }


    public class DerivedClass : BaseClass
    {
        public DerivedClass()
        {
            Console.WriteLine("Derived class constructor executed VERY late.");
        }

        public override void VirtualMethod()
        {
            base.VirtualMethod();

            Console.WriteLine("Derived Virtual Method");
        }

        public override void AbstractMethod()
        {
            Console.WriteLine("Derived Abstract Method");
        }
    }
}
