namespace _01_02_ListyIterator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ListyIterator<T> : IListyIterator, IEnumerable<T>
    {
        private List<T> elements;

        private int index;

        public ListyIterator(params T[] elements)
        {
            this.elements = new List<T>(elements);
            this.index = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.elements.Count; i++)
            {
                yield return this.elements[i];
            }
        }

        public bool HasNext()
        {
            if (index < this.elements.Count - 1)
            {
                return true;
            }

            return false;
        }

        public bool Move()
        {
            if (HasNext())
            {
                index++;
                return true;
            }

            return false;
        }

        public void Print()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine($"{this.elements[index]}");
        }

        public void PrintAll()
        {
            Console.WriteLine(string.Join(' ', this.elements));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
