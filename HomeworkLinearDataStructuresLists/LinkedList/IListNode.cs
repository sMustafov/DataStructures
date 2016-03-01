namespace LinkedList
{
    public interface IListNode<T>
    {
        T Value { get; set; }

        IListNode<T> NextNode { get; set; }
    }
}