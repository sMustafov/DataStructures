namespace LinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedList<T> : ILinkedList<T>
    {
        private ListNode<T> head;
        private ListNode<T> tail;

        public LinkedList()
        {
            this.head = null;
            this.tail = null;
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (this.head == null) // same as this.Count == 0
            {
                this.head = this.tail = new ListNode<T>(item);
            }
            else
            {
                this.tail.NextNode = this.tail = new ListNode<T>(item);
            }

            this.Count++;
        }

        public void Remove(int index)
        {
            var nodeToRemove = this[index];

            if (this.Count == 1)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                var nextNode = nodeToRemove.NextNode;
                ListNode<T> prevNode = null;

                try
                {
                    prevNode = this[index - 1];
                }
                catch (IndexOutOfRangeException)
                {
                }

                if (prevNode == null)
                {
                    this.head = nextNode;
                }
                else
                {
                    prevNode.NextNode = nextNode;
                }
            }

            this.Count--;
        }

        public int FirstIndexOf(T item)
        {
            var index = 0;
            foreach (var element in this)
            {
                if (element.Equals(item))
                {
                    return index;
                }

                index++;
            }

            return -1;
        }

        public int LastIndexOf(T item)
        {
            var index = 0;
            var indexFound = -1;

            foreach (var element in this)
            {
                if (element.Equals(item))
                {
                    indexFound = index;
                }

                index++;
            }

            return indexFound;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private ListNode<T> this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException("Index is out of range");
                }

                var currentIndex = 0;
                var currentNode = this.head;

                while (currentNode != null)
                {
                    if (currentIndex == index)
                    {
                        break;
                    }

                    currentIndex++;
                    currentNode = currentNode.NextNode;
                }

                return currentNode;
            }
        }
    }
}