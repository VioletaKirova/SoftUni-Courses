namespace _06_StrategyPattern
{
    using System.Collections.Generic;

    public class AgeComparator : IComparer<IPerson>
    {
        public int Compare(IPerson first, IPerson second)
        {
            return first.Age.CompareTo(second.Age);
        }
    }
}
