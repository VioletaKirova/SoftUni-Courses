namespace _07_CustomList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class CustomList<T> : ICustomList<T>, IEnumerable<T> 
        where T: IComparable
    {
        private const int InitialArrayLength = 4;

        private T[] array;

        public CustomList()
        {
            this.array = new T[InitialArrayLength];
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void Add(T element)
        {
            if (this.Count > this.array.Length - 1)
            {
                Resize();
            }

            this.array[this.Count++] = element;
        }

        public bool Contains(T element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.array[i].Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        public int CountGreaterThan(T element)
        {
            int count = 0;

            for (int i = 0; i < this.Count; i++)
            {
                if (this.array[i].CompareTo(element) > 0)
                {
                    count++;
                }
            }

            return count;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.array[i];
            }
        }

        public T Max()
        {
            T maxElement = this.array[0];

            for (int i = 1; i < this.Count; i++)
            {
                if (this.array[i].CompareTo(maxElement) > 0)
                {
                    maxElement = this.array[i];
                }
            }

            return maxElement;
        }

        public T Min()
        {
            T minElement = this.array[0];

            for (int i = 1; i < this.Count; i++)
            {
                if (this.array[i].CompareTo(minElement) < 0)
                {
                    minElement = this.array[i];
                }
            }

            return minElement;
        }

        public T Remove(int index)
        {
            if (index < 0 || index > this.Count)
            {
                throw new IndexOutOfRangeException();
            }

            T element = this.array[index];
            this.array[index] = default(T);
            this.Count--;

            for (int i = index; i < this.Count; i++)
            {
                this.array[i] = this.array[i + 1];
            }

            this.array[this.Count] = default(T);

            return element;
        }

        public void Sort()
        {
            for (int i = 0; i < this.Count; i++)
            {
                for (int j = i + 1; j < this.Count; j++)
                {
                    if (this.array[i].CompareTo(this.array[j]) > 0)
                    {
                        T tempElement = this.array[i];
                        this.array[i] = this.array[j];
                        this.array[j] = tempElement;
                    }
                }
            }
        }

        public void Swap(int index1, int index2)
        {
            if (index1 < 0 || index1 > this.Count ||
                index2 < 0 || index2 > this.Count)
            {
                throw new IndexOutOfRangeException();
            }

            T tempElement = this.array[index1];
            this.array[index1] = this.array[index2];
            this.array[index2] = tempElement;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < this.Count; i++)
            {
                result.AppendLine(this.array[i].ToString());
            }

            return result.ToString().TrimEnd();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public T this[int number]
        {
            get
            {
                if (number >= 0 && number < this.Count)
                {
                    return this.array[number];
                }

                throw new IndexOutOfRangeException();
            }
            set
            {
                if (number >= 0 && number < this.Count)
                {
                    this.array[number] = value;
                }

                throw new IndexOutOfRangeException();
            }
        }

        private void Resize()
        {
            T[] tempArray = new T[this.array.Length * 2];
            for (int i = 0; i < this.array.Length; i++)
            {
                tempArray[i] = this.array[i];
            }
            this.array = tempArray;
        }
    }
}
