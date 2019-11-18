namespace Database
{
    using System;

    public class Database : IDatabase
    {
        private const int Capacity = 16;

        private IPerson[] data;

        public Database(params IPerson[] data)
        {
            this.Data = data;
        }

        public int Count { get; private set; }

        public IPerson[] Data
        {
            get
            {
                return data;
            }
            private set
            {
                if (value.Length > Capacity)
                {
                    throw new InvalidOperationException("Number of people must be < 17!");
                }

                data = new IPerson[16];

                for (int i = 0; i < value.Length; i++)
                {
                    data[i] = value[i];
                }

                this.Count = value.Length;
            }
        }

        public void Add(IPerson element)
        {
            if (this.Count == 16)
            {
                throw new InvalidOperationException("Database is full!");
            }

            for (int i = 0; i < this.Count; i++)
            {
                if (this.Data[i].Name == element.Name || this.Data[i].Id == element.Id)
                {
                    throw new InvalidOperationException("Person already exists!");
                }
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
            this.Data[lastIndex] = null;
            this.Count--;
        }

        public IPerson FindByUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException(nameof(username));
            }

            for (int i = 0; i < this.Count; i++)
            {
                if (this.Data[i].Name == username)
                {
                    return this.Data[i];
                }
            }

            throw new InvalidOperationException($"Person with username:{username} doesn't exist!");
        }

        public IPerson FindById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Id must be >= 0.");
            }

            for (int i = 0; i < this.Count; i++)
            {
                if (this.Data[i].Id == id)
                {
                    return this.Data[i];
                }
            }

            throw new InvalidOperationException($"Person with ID:{id} doesn't exist!");
        }
    }
}
