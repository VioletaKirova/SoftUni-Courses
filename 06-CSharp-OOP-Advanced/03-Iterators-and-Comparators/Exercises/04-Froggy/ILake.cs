namespace _04_Froggy
{
    using System.Collections.Generic;

    public interface ILake : IEnumerable<int>
    {
        int[] Path { get; }
    }
}
