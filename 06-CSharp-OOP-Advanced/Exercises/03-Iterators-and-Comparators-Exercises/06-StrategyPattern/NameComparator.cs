namespace _06_StrategyPattern
{
    using System.Collections.Generic;

    public class NameComparator : IComparer<IPerson>
    {
        public int Compare(IPerson first, IPerson second)
        {
            int result = first.Name.Length.CompareTo(second.Name.Length);

            if (result == 0)
            {
                char firstFirstLetter = char.ToLower(first.Name[0]);
                char secondFirstLetter = char.ToLower(second.Name[0]);
                result = firstFirstLetter.CompareTo(secondFirstLetter);
            }

            return result;
        }
    }
}

