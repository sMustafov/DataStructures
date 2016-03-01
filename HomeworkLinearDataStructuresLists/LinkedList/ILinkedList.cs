namespace LinkedList
{
    using System.Collections.Generic;

    public interface ILinkedList <T> : IEnumerable<T>
    {
        void Add(T item);

        void Remove(int index);

        int Count { get; }

        int FirstIndexOf(T item);

        int LastIndexOf(T item);
    }
}