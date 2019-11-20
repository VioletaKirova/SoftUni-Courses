namespace _07_CustomList
{
    using System;

    public class CommandInterpreter<T> : ICommandInterpreter<T> where T : IComparable
    {
        private CustomList<T> customList;

        public CommandInterpreter()
        {
            this.customList = new CustomList<T>();
        }

        public void Add(T element)
        {
            this.customList.Add(element);
        }

        public void Remove(int index)
        {
            this.customList.Remove(index);
        }

        public void Contains(T element)
        {
            Console.WriteLine(this.customList.Contains(element));
        }

        public void Swap(int index1, int index2)
        {
            this.customList.Swap(index1, index2);
        }

        public void Greater(T element)
        {
            Console.WriteLine(this.customList.CountGreaterThan(element));
        }

        public void Max()
        {
            Console.WriteLine(this.customList.Max());
        }

        public void Min()
        {
            Console.WriteLine(this.customList.Min());
        }

        public void Print()
        {
            for (int i = 0; i < this.customList.Count; i++)
            {
                Console.WriteLine(this.customList[i]);
            }
        }

        public void Sort()
        {
            this.customList.Sort();
        }
    }
}
