using System;
using System.Collections.Generic;
using System.Linq;

namespace _10_SimpleTextEditor
{
    // 30/100

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<char> charStack = new Stack<char>();
            Stack<string[]> commandStack = new Stack<string[]>();

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(' ');

                switch (command[0])
                {
                    case "1":
                        commandStack.Push(command);

                        char[] charArr = command[1].ToCharArray();

                        foreach (var c in charArr)
                        {
                            charStack.Push(c);
                        }

                        break;
                    case "2":
                        commandStack.Push(command);

                        int count = int.Parse(command[1]);

                        for (int j = 0; j < count; j++)
                        {
                            charStack.Pop();
                        }

                        break;
                    case "3":
                        string text = string.Join("", charStack.ToArray().Reverse().ToArray());

                        int index = int.Parse(command[1]);

                        char element = text[index - 1];

                        Console.WriteLine(element.ToString());

                        break;
                    case "4":
                        string[] commandToUndo = commandStack.Pop();

                        switch (commandToUndo[0])
                        {
                            case "1":
                                int stringLength = commandToUndo[1].Length;

                                for (int j = 0; j < stringLength; j++)
                                {
                                    charStack.Pop();
                                }

                                break;
                            case "2":
                                string[] lastCommand = new string[2];

                                while (true)
                                {
                                    lastCommand = commandStack.Pop();

                                    if (lastCommand[0] == "1")
                                    {
                                        break;
                                    }
                                }

                                char[] redoCharArr = lastCommand[1].ToCharArray();

                                foreach (var c in redoCharArr)
                                {
                                    charStack.Push(c);
                                }

                                break;
                        }

                        break;
                }
            }
        }
    }
}
