namespace _05_GenericCountMethodString
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Comparator
    {
        public static int FindGreaterElements<T>(IList<Box<T>> elements, T element)
            where T : IComparable<T>
        {
            int greaterElementsCount = elements.Where(x => x.CompareTo(element) > 0).Count();
            return greaterElementsCount;
        }
    }
}
