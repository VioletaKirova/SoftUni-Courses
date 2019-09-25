namespace _05_ComparingObjects
{
    using System;

    public interface IPerson : IComparable<IPerson>
    {
        string Name { get; }

        int Age { get; }

        string Town { get; }
    }
}
