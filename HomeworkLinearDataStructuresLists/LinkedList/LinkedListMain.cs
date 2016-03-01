namespace LinkedList
{
    using System;

    class LinkedListMain
    {
        static void Main()
        {
            LinkedList<int> linkedList = new LinkedList<int>();
            linkedList.Add(3);
            linkedList.Add(7);
            linkedList.Add(5);
            linkedList.Add(9);
            linkedList.Add(11);
            linkedList.Add(13);
            linkedList.Add(5);

            Console.WriteLine("Elements of LinkedList: ");
            Console.WriteLine(string.Join(", ", linkedList));
            Console.WriteLine("Count: {0}", linkedList.Count);

            linkedList.Remove(0);
            linkedList.Remove(0);
            Console.WriteLine("Elements of LinkedList: ");
            Console.WriteLine(string.Join(", ", linkedList));
            Console.WriteLine("Count: {0}", linkedList.Count);

            Console.WriteLine("First index of 5: {0}", linkedList.FirstIndexOf(5));
            Console.WriteLine("Last index of 5: {0}", linkedList.LastIndexOf(5));
        }
    }
}
