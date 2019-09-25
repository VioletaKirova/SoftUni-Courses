namespace Database
{
    using System;

    public interface IPerson : IComparable<IPerson>
    {
        string Name { get; }

        long Id { get; }
    }
}
