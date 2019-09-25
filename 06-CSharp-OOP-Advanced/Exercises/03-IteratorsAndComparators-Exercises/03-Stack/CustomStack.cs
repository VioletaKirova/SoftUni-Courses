namespace _03_Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CustomStack<T> : ICustomStack<T>, IEnumerable<T>
    {
        public IList<T> Elements { get; private set; }

        public CustomStack()
        {
            this.Elements = new List<T>();
        }

        public T Pop()
        {
            if (this.Elements.Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }

            T element = this.Elements[this.Elements.Count - 1];
            this.Elements.RemoveAt(this.Elements.Count - 1);
            return element;
        }

        public void Push(params T[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                this.Elements.Add(elements[i]);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Elements.Count - 1; i >= 0; i--)
            {
                yield return this.Elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
