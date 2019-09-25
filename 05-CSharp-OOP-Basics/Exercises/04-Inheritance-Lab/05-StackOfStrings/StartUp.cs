using System;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stack = new StackOfStrings();

            int count = 10;

            for (int i = 0; i < count; i++)
            {
                stack.Push($"Item {i}");
            }

            if (!stack.IsEmpty())
            {
                Console.WriteLine(stack.Pop());
            }

            if (!stack.IsEmpty())
            {
                Console.WriteLine(stack.Peek());
            }

            if (!stack.IsEmpty())
            {
                Console.WriteLine(stack.Pop());
            }
        }
    }
}
