namespace _04_Froggy
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Lake : ILake, IEnumerable<int>
    {
        public Lake(int[] stones)
        {
            this.Path = stones;
        }

        public int[] Path { get; set; }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.Path.Length; i += 2)
            {
                yield return this.Path[i];
            }

            int oddStartingIndex = this.Path.Length % 2 == 0 ? this.Path.Length - 1 : this.Path.Length - 2;

            for (int i = oddStartingIndex; i >= 1; i -= 2)
            {
                yield return this.Path[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
