namespace AvlTreeLab
{
    using System;

    public class AvlTree<T> where T : IComparable<T>
    {
        private Node<T> root;

        public int Count { get; private set; }

        public void Add(T item)
        {
            var inserted = true;
            if (this.root == null)
            {
                this.root = new Node<T>(item);
            }
            else
            {
                inserted = this.InsertInternal(this.root, item);
            }
            if (inserted)
            {
                this.Count++;
            }
        }

        private bool InsertInternal(Node<T> node, T item)
        {
            var currentNode = node;
            var newNode = new Node<T>(item);
            var shouldRetrace = false;

            while (true)
            {
                if (currentNode.Value.CompareTo(item) < 0)
                {
                    if (currentNode.RightChild == null)
                    {
                        newNode = currentNode.RightChild;
                        currentNode.BalanceFactor--;
                        shouldRetrace = currentNode.BalanceFactor != 0;
                        break;
                    }

                    currentNode = currentNode.RightChild;
                }
                else
                {
                    if (currentNode.LeftChild == null)
                    {
                        newNode = currentNode.LeftChild;
                        currentNode.BalanceFactor++;
                        shouldRetrace = currentNode.BalanceFactor != 0;
                        break;
                    }

                    currentNode = currentNode.LeftChild;
                }
            }
            if (shouldRetrace)
            {
                this.RetraceInsert(currentNode);
            }

            return true;
        }

        private void RetraceInsert(Node<T> node)
        {
            var parent = node.Parent;
            while (parent != null)
            {
                if (node.IsLeftChild)
                {
                    if (parent.BalanceFactor == 1)
                    {
                        parent.BalanceFactor++;

                        if (node.BalanceFactor == -1)
                        {
                            this.RotateLeft(node);
                        }

                        this.RotateRight(parent);
                        break;
                    }
                    else if (parent.BalanceFactor == -1)
                    {
                        parent.BalanceFactor = 0;
                        break;
                    }
                    else
                    {
                        parent.BalanceFactor = 1;
                    }
                }
                else
                {
                    if (parent.BalanceFactor == -1)
                    {
                        parent.BalanceFactor--;

                        if (node.BalanceFactor == 1)
                        {
                            this.RotateRight(node);
                        }

                        this.RotateLeft(parent);
                        break;
                    }
                    else if (parent.BalanceFactor == 1)
                    {
                        parent.BalanceFactor = 0;
                        break;
                    }
                    else
                    {
                        parent.BalanceFactor = -1;
                    }
                }

                node = parent;
                parent = node.Parent;
            }
        }

        private void RotateLeft(Node<T> node)
        {
            var parent = node.Parent;
            var child = node.RightChild;

            if (parent != null)
            {
                if (node.IsLeftChild)
                {
                    parent.LeftChild = child;
                }
                else
                {
                    parent.RightChild = child;
                }
            }

            node.RightChild = child.LeftChild;
            child.LeftChild = node;

            node.BalanceFactor += 1 - Math.Min(child.BalanceFactor, 0);
            child.BalanceFactor += 1 + Math.Max(node.BalanceFactor, 0);
        }

        private void RotateRight(Node<T> node)
        {
            var parent = node.Parent;
            var child = node.LeftChild;

            if (parent != null)
            {
                if (node.IsRightChild)
                {
                    parent.RightChild = child;
                }
                else
                {
                    parent.LeftChild = child;
                }
            }

            node.LeftChild = child.RightChild;
            child.RightChild = node;

            node.BalanceFactor -= 1 + Math.Min(child.BalanceFactor, 0);
            child.BalanceFactor -= 1 - Math.Max(node.BalanceFactor, 0);
        }
        //TODO
        public bool Contains(T item)
        {
            while (item != null)
            {
                if (item.CompareTo(this.root.Value) == 0)
                {
                    return true;
                }
                else
                {
                    if (item.CompareTo(this.root.Value) > 0)
                    {
                        this.root = this.root.LeftChild;
                        return (Contains(item));
                    }
                    else
                    {
                        if (item.CompareTo(this.root.Value) < 0)
                        {
                            this.root = this.root.RightChild;
                            return (Contains(item));
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }

            return false;
        }

        public void ForeachDfs(Action<int, T> action)
        {
            if (this.Count == 0)
            {
                return;
            }

            this.InOrderDfs(this.root, 1, action);
        }

        private void InOrderDfs(Node<T> node, int depth, Action<int, T> action)
        {
            if (node != null)
            {
                InOrderDfs(node.LeftChild, 2, action);
                Console.WriteLine(node.Value);
                InOrderDfs(node.RightChild, 2, action);
            }
        }
    }
}
