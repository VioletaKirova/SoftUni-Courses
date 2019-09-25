namespace _07_EqualityLogic
{
    using System;

    public interface IPerson : IComparable<IPerson>
    {
        string Name { get; }

        int Age { get; }
    }
}
