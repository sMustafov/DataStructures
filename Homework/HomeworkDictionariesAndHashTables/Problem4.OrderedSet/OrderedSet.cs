﻿namespace Problem4.OrderedSet
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class OrderedSet<T> : IEnumerable<T> where T : IComparable<T>
    {
        private BinaryTree<T> container;

        public int Count()
        {
            if (this.container == null)
            {
                return 0;
            }

            return this.container.Count();
        }

        public void Add(T element)
        {
            if (this.container == null)
            {
                this.container = new BinaryTree<T>(element);
            }
            else
            {
                if (!this.container.Contains(element))
                {
                    this.container.Add(element);
                }
            }
        }

        public bool Contains(T element)
        {
            if (this.container.Contains(element))
            {
                return true;
            }

            return false;
        }

        public void Remove(T element)
        {
            if (this.Count() == 0)
            {
                throw new InvalidOperationException("The set is empty");
            }

            this.container.Remove(element);
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (this.Count() == 0)
            {
                throw new InvalidOperationException("The set is empty");
            }

            var elements = this.container.GetElementsByValue();
            foreach (var element in elements)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}