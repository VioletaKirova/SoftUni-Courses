namespace _03_Stack
{
    using System;

    public class CommandInterpreter<T> : ICommandInterpreter<T>
    {
        private CustomStack<T> customStack;

        public CommandInterpreter()
        {
            this.customStack = new CustomStack<T>();
        }

        public void END()
        {
            for (int i = 0; i < 2; i++)
            {
                foreach (var element in this.customStack)
                {
                    Console.WriteLine(element);
                }
            }

            Environment.Exit(0);
        }

        public void Pop()
        {
            this.customStack.Pop();
        }

        public void Push(T[] elements)
        {
            this.customStack.Push(elements);
        }
    }
}
