namespace _01_02_ListyIterator
{
    public interface ICommandInterpreter<T>
    {
        void Create(params T[] elements);

        bool Move();

        void Print();

        bool HasNext();

        void END();

        void PrintAll();
    }
}
