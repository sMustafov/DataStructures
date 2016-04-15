namespace Problem7.LinkedQueue
{
    using System;

    public class LinkedQueue<T> : ILinkedQueue<T>
    {
        private class QueueNode<T>
        {
            public QueueNode(T value)
            {
                this.Value = value;
            }

            public T Value { get; private set; }

            public QueueNode<T> NextNode { get; set; }

            public QueueNode<T> PreviousNode { get; set; }
        }

        private QueueNode<T> head;
        private QueueNode<T> tail;

        public int Count { get; private set; }

        public void Enqueue(T element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new QueueNode<T>(element);
            }
            else
            {
                var newTail = new QueueNode<T>(element);
                newTail.PreviousNode = this.tail;
                this.tail.NextNode = newTail;
                this.tail = newTail;
            }

            this.Count++;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List empty");
            }

            var firstElement = this.head.Value;
            this.head = this.head.NextNode;
            if (this.head != null)
            {
                this.head.PreviousNode = null;
            }
            else
            {
                this.tail = null;
            }

            this.Count--;
            return firstElement;
        }

        public T[] ToArray()
        {
            var resultArr = new T[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                resultArr[i] = this.tail.Value;
                this.tail = this.tail.PreviousNode;
            }

            return resultArr;
        }
    }
}