using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public string RandomString()
        {
            Random random = new Random();
            int index = random.Next(0, base.Count - 1);
            string randStr = base[index];
            base.RemoveAt(index);

            return randStr;
        }
    }
}
