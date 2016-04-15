namespace Problem5.LinkedStack
{
    using System;

    class LinkedStackMain
    {
        static void Main()
        {
            LinkedStack<int> linkedList = new LinkedStack<int>();
            linkedList.Push(5);
            linkedList.Push(7);
            linkedList.Push(9);
            linkedList.Push(11);
            linkedList.Push(13);
            Console.WriteLine("Count before Pop : " + linkedList.Count);
            Console.WriteLine(linkedList.Pop());
            Console.WriteLine(linkedList.Pop());
            Console.WriteLine("Count after Pop : " + linkedList.Count);
        }
    }
}
