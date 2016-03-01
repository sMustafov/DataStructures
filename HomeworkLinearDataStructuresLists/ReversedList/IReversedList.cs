namespace ReversedList
{
    using System.Collections.Generic;

    public interface IReversedList<T> : IEnumerable<T>
    {
        int Count { get; }

        int Capacity { get; }

        void Add(T item);

        void Remove(int index);

        T this[int index] { get; set; }
    }
}