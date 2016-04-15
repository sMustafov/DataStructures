namespace Problem1.PlayWithTrees
{
    using System;
    using System.Collections.Generic;

    public interface ITree<T>
    {
        T Value { get; set; }

        ITree<T> Parent { get; set; }

        IList<Tree<T>> Children { get; }

        void Print(int indent);

        void Each(Action<T> action);
    }
}