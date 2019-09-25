namespace _03_GenericSwapMethodString
{
    using System.Collections.Generic;

    public static class ElementSwapper
    {
        public static void SwapElements<T>(IList<T> elements, int firstIndex, int secondIndex)
        {
            T firstElement = elements[firstIndex];
            elements[firstIndex] = elements[secondIndex];
            elements[secondIndex] = firstElement;
        }
    }
}
