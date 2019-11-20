namespace BoxOfT
{
    using System.Collections.Generic;

    public class Box<T> : IBox<T>
    {
        private IList<T> elements;

        public Box()
        {
            this.elements = new List<T>();
        }

        public int Count => this.elements.Count;

        public void Add(T element)
        {
            this.elements.Add(element);
        }

        public T Remove()
        {
            T element = this.elements[this.elements.Count - 1];
            this.elements.RemoveAt(this.elements.Count - 1);
            return element;
        }
    }
}
