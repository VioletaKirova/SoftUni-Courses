namespace _06_GenericCountMethodDouble
{
    using System;

    public class Box<T> : IComparable<T>
        where T : IComparable
    {
        private T value;

        public Box(T value)
        {
            this.value = value;
        }

        public int CompareTo(T element)
        {
            return this.value.CompareTo(element);
        }

        public override string ToString()
        {
            return $"{this.value.GetType().FullName}: {this.value}";
        }
    }
}
