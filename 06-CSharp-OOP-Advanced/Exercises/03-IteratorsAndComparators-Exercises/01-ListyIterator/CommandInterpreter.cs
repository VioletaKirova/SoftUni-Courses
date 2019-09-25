namespace _01_02_ListyIterator
{
    using System;

    public class CommandInterpreter<T> : ICommandInterpreter<T>
    {
        private ListyIterator<T> listyIterator;

        public void Create(params T[] elements)
        {
            this.listyIterator = new ListyIterator<T>(elements);
        }

        public void END()
        {
            Environment.Exit(0);
        }

        public bool HasNext()
        {
            bool result = this.listyIterator.HasNext();
            Console.WriteLine(result);
            return result;
        }

        public bool Move()
        {
            bool result = this.listyIterator.Move();
            Console.WriteLine(result);
            return result;
        }

        public void Print()
        {
            this.listyIterator.Print();
        }

        public void PrintAll()
        {
            this.listyIterator.PrintAll();
        }
    }
}
