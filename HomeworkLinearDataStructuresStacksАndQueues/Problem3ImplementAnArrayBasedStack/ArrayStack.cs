namespace Problem3ImplementAnArrayBasedStack
{
    using System;

    public class ArrayStack<T> : IArrayStack<T>
    {
        private const int InitialCapacity = 16;
        private T[] elements;

        public ArrayStack(int capacity = InitialCapacity)
        {
            this.elements = new T[capacity];
        }

        public int Count { get; private set; }

        public int Capacity { get { return this.elements.Length; } }

        public void Push(T element)
        {
            if (this.Count >= this.elements.Length)
            {
                this.Grow();
            }

            this.elements[this.Count] = element;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new ArgumentException("The Array Stack is empty");
            }

            this.Count--;
            return this.elements[this.Count];
        }

        public T[] ToArray()
        {
            var resultArr = new T[this.Count];
            Array.Copy(this.elements, resultArr, this.Count);
            return resultArr;
        }

        private void Grow()
        {
            int elementsNewLenght = 2 * this.elements.Length;
            T[] newElements = new T[elementsNewLenght];
            Array.Copy(this.elements, newElements, this.elements.Length);
            this.elements = newElements;
        }
    }
}