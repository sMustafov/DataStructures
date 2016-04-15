namespace ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IReversedList<T>
    {
        private const int DefaultCapacity = 16;
        private T[] array;
        private int capacity;

        public ReversedList(int capacity = DefaultCapacity)
        {
            this.Capacity = capacity;
            this.Count = 0;
            this.array = new T[this.Capacity];
        }

        public int Count { get; private set; }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The capacity should be positive integer");
                }

                this.capacity = value;
            }
        }

        public void Add(T item)
        {

            if (this.Count >= this.Capacity - 1)
            {
                this.Capacity *= 2;
                var newArray = new T[this.Capacity];
                Array.Copy(array, newArray, this.array.Length - 1);
                this.array = newArray;
            }

            this.array[this.Count] = item;
            this.Count++;
        }

        public T this[int index]
        {
            get
            {
                this.CheckIfIndexIsInRange(index);

                index = this.Count - 1 - index;
                var element = this.array[index];

                return element;
            }
            set
            {
                this.CheckIfIndexIsInRange(index);

                if (this.Count >= this.Capacity - 1)
                {
                    this.Capacity *= 2;
                    var newStorage = new T[this.Capacity];
                    Array.Copy(this.array, newStorage, this.array.Length - 1);
                    this.array = newStorage;
                }

                index = this.Count - 1 - index;

                for (int i = this.Count; i >= index; i--)
                {
                    this.array[i] = this.array[i - 1];
                }

                this.array[index] = value;
                this.Count++;
            }
        }

        public void Remove(int index)
        {
            this.CheckIfIndexIsInRange(index);

            index = this.Count - 1 - index;

            for (int i = index; i < this.Count - 1; i++)
            {
                this.array[i] = this.array[i + 1];
            }

            this.array[this.Count - 1] = default(T);
            this.Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void CheckIfIndexIsInRange(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }
        }
    }
}