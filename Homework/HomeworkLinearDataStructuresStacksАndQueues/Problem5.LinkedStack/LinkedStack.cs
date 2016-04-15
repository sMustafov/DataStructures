namespace Problem5.LinkedStack
{
    using System;
    
    public class LinkedStack<T> : ILinkedStack<T>
    {
        private class Node<T>
        {
            public Node(T value, Node<T> nextNode = null)
            {
                this.Value = value;
                this.NextNode = nextNode;
            }

            public Node<T> NextNode { get;set; }

            public T Value { get; set; }
        }

        private Node<T> firstNode;

        public int Count { get; private set; }

        public void Push(T element)
        {
            this.firstNode = new Node<T>(element, this.firstNode);

            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List empty");
            }
            var resultNode = firstNode;
            this.firstNode = this.firstNode.NextNode;
            this.Count--;

            return resultNode.Value;
        }

        public T[] ToArray()
        {
            T[] array = new T[this.Count];
            Node<T> currNode = this.firstNode;
            int currIndex = 0;

            while (currNode != null)
            {
                array[currIndex] = currNode.Value;
                currNode = currNode.NextNode;
                currIndex++;
            }

            return array;
        }
    }
}