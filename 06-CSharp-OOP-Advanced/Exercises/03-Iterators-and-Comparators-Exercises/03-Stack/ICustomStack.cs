namespace _03_Stack
{
    using System.Collections.Generic;

    public interface ICustomStack<T>
    {
        IList<T> Elements { get; }

        void Push(params T[] elements);

        T Pop();
    }
}
