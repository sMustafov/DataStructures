namespace Problem4.OrderedSet
{
    using System;
    using System.Collections.Generic;

    public class BinaryTree<T> where T : IComparable<T>
    {
        private int treeCount;

        public BinaryTree(T value)
        {
            this.Value = value;
            this.Child = new BinaryTree<T>[2];
            this.treeCount = 1;
        }

        public T Value { get; set; }

        public int Count()
        {
            this.GetCount(this);
            return this.treeCount;
        }

        private void GetCount(BinaryTree<T> parent)
        {
            foreach (var child in parent.Child)
            {
                if (child != null)
                {
                    this.treeCount++;
                    this.GetCount(child);
                }
            }
        }

        public BinaryTree<T>[] Child { get; set; }

        public BinaryTree<T> Parent { get; set; }

        public void Add(T element)
        {
            this.AddToCorrectPlace(this, new BinaryTree<T>(element));
        }

        private void AddToCorrectPlace(BinaryTree<T> parent, BinaryTree<T> node)
        {
            var leftChild = parent.Child[0];
            var rightChild = parent.Child[1];
            var isLeftOfParent = parent.Value.CompareTo(node.Value) > 0;

            if (leftChild != null && rightChild != null)
            {
                if (isLeftOfParent)
                {
                    AddToCorrectPlace(leftChild, node);
                }
                else
                {
                    AddToCorrectPlace(rightChild, node);
                }
            }
            else if (leftChild != null)
            {
                if (isLeftOfParent)
                {
                    AddToCorrectPlace(leftChild, node);
                }
                else
                {
                    parent.Child[1] = node;
                    node.Parent = parent;
                }
            }
            else if (rightChild != null)
            {
                if (isLeftOfParent)
                {
                    parent.Child[0] = node;
                    node.Parent = parent;
                }
                else
                {
                    AddToCorrectPlace(rightChild, node);
                }
            }
            else
            {
                if (isLeftOfParent)
                {
                    parent.Child[0] = node;
                }
                else
                {
                    parent.Child[1] = node;
                }

                node.Parent = parent;
            }
        }

        public bool Contains(T element)
        {
            var foundElement = this.Contains(this, element);
            if (foundElement)
            {
                return true;
            }

            return false;
        }

        private bool Contains(BinaryTree<T> parent, T element, bool isFound = false)
        {
            if (parent.Value.Equals(element))
            {
                return true;
            }

            var leftChild = parent.Child[0];
            var rightChild = parent.Child[1];
            var isLeftOfParent = parent.Value.CompareTo(element) > 0;

            if (leftChild != null && isLeftOfParent)
            {
                isFound = this.Contains(leftChild, element);
            }

            if (rightChild != null && !isLeftOfParent)
            {
                isFound = this.Contains(rightChild, element);
            }

            return isFound;
        }

        public void Remove(T element)
        {
            if (!this.Contains(element))
            {
                var message = string.Format("{0} not found!", element);
                throw new InvalidOperationException(message);
            }

            this.Remove(this, element);
        }

        private void Remove(BinaryTree<T> parent, T element)
        {
            var leftChild = parent.Child[0];
            var rightChild = parent.Child[1];

            if (parent.Value.Equals(element))
            {
                var grandDaddy = parent.Parent;
                var newParent = leftChild;
                if (newParent == null)
                {
                    newParent = rightChild;
                }

                if (leftChild != null && rightChild != null)
                {
                    if (leftChild.Value.CompareTo(rightChild.Value) > 0)
                    {
                        newParent = leftChild;
                        if (newParent.Child[0] == null)
                        {
                            newParent.Child[0] = rightChild;
                        }
                        else if (newParent.Child[1] == null)
                        {
                            newParent.Child[1] = rightChild;
                        }
                        else
                        {
                            this.Remove(rightChild.Value);
                            this.Add(rightChild.Value);
                        }

                        rightChild.Parent = newParent;
                    }
                    else
                    {
                        newParent = rightChild;
                        if (newParent.Child[0] == null)
                        {
                            newParent.Child[0] = leftChild;
                        }
                        else if (newParent.Child[1] == null)
                        {
                            newParent.Child[1] = leftChild;
                        }
                        else
                        {
                            this.Remove(leftChild.Value);
                            this.Add(leftChild.Value);
                        }

                        leftChild.Parent = newParent;
                    }
                }

                newParent.Parent = grandDaddy;
                if (grandDaddy.Child[0] == parent)
                {
                    grandDaddy.Child[0] = newParent;
                }
                else
                {
                    grandDaddy.Child[1] = newParent;
                }
            }

            var isLeftOfParent = parent.Value.CompareTo(element) > 0;
            if (leftChild != null && isLeftOfParent)
            {
                this.Remove(leftChild, element);
            }

            if (rightChild != null && !isLeftOfParent)
            {
                this.Remove(rightChild, element);
            }
        }

        public ICollection<T> GetElementsByValue()
        {
            var elements = this.GetElementsByValue(this, new List<T>());
            var sortedElements = this.SortValues(elements);

            return sortedElements;
        }

        private List<T> GetElementsByValue(BinaryTree<T> parent, List<T> elements)
        {
            elements.Add(parent.Value);
            foreach (var child in parent.Child)
            {
                if (child != null)
                {
                    elements = this.GetElementsByValue(child, elements);
                }
            }

            return elements;
        }

        private ICollection<T> SortValues(List<T> values)
        {
            bool sort = true;
            while (sort)
            {
                sort = false;
                for (int i = 0; i < values.Count - 1; i++)
                {
                    if (values[i].CompareTo(values[i + 1]) > 0)
                    {
                        T swapper = values[i];
                        values[i] = values[i + 1];
                        values[i + 1] = swapper;
                        sort = true;
                    }
                }
            }

            return values;
        }
    }
}