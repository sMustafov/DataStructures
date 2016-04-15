namespace AvlTreeLab
{
    using System;

    public class Node<T> where T : IComparable<T>
    {
        private Node<T> leftChild;
        private Node<T> rightChild;
        private int childrenCount;

        public Node(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public Node<T> LeftChild
        {
            get { return this.leftChild; }
            set
            {
                if (value == null)
                {
                    value.Parent = this;
                }

                this.leftChild = value;
                this.childrenCount++;
            }
        }

        public Node<T> RightChild
        {
            get
            {
                return rightChild;
            }
            set
            {
                if (value == null)
                {
                    value.Parent = this;
                }

                this.rightChild = value;
                this.childrenCount++;
            }
        }

        public Node<T> Parent { get; set; }

        public int BalanceFactor { get; set; }

        public bool IsLeftChild
        {
            get
            {
                return LeftChild.Value.CompareTo(Parent.Value) < 0;
            }
        }

        public bool IsRightChild
        {
            get
            {
                return RightChild.Value.CompareTo(Parent.Value) > 0;
            }
        }

        public int ChildrenCount
        {
            get
            {
                return this.childrenCount;
            }
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}

