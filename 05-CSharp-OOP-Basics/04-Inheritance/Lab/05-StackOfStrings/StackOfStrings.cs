using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : List<string>
    {
        public void Push(string item)
        {
            base.Add(item);
        }

        public string Pop()
        {
            string item = base[Count - 1];
            base.RemoveAt(Count - 1);

            return item;
        }

        public string Peek()
        {
            string item = base[Count - 1];

            return item;
        }

        public bool IsEmpty()
        {
            if (base.Count == 0)
            {
                return true;
            }

            return false;
        }
    }
}
