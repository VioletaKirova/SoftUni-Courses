namespace _03_Stack
{
    public interface ICommandInterpreter<T>
    {
        void Push(T[] elements);

        void Pop();

        void END();
    }
}
