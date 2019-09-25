namespace Database
{
    using System;
    using System.Linq;

    public class Database : IDatabase
    {
        private const int Capacity = 16;

        private int[] data;

        public Database(params int[] data)
        {
            this.Data = data;
        }

        public int Count { get; private set; }

        public int[] Data
        {
            get
            {
                return data;
            }
            private set
            {
                if (value.Length > Capacity)
                {
                    throw new InvalidOperationException("The size of the array must be maximum 16 integers long!");
                }

                data = new int[16];

                for (int i = 0; i < value.Length; i++)
                {
                    data[i] = value[i];
                }

                this.Count = value.Length;
            }
        }

        public void Add(int element)
        {
            if (this.Count == 16)
            {
                throw new InvalidOperationException("Database is full!");
            }

            this.Data[this.Count] = element;
            this.Count++;
        }

        public void Remove()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Database is empty!");
            }

            int lastIndex = this.Count - 1;
            this.Data[lastIndex] = 0;
            this.Count--;
        }

        public int[] Fetch()
        {
            return this.Data.Take(this.Count).ToArray();
        }
    }
}
