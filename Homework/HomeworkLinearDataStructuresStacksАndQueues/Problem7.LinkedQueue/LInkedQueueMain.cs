using System;

namespace Problem7.LinkedQueue
{
    class LinkedQueueMain
    {
        static void Main()
        {
            LinkedQueue<int> linkedQueue = new LinkedQueue<int>();
            linkedQueue.Enqueue(1);
            linkedQueue.Enqueue(2);
            linkedQueue.Enqueue(3);
            linkedQueue.Enqueue(4);
            linkedQueue.Enqueue(5);
            Console.WriteLine("Count: " + linkedQueue.Count);
            Console.WriteLine(linkedQueue.Dequeue());
            Console.WriteLine(linkedQueue.Dequeue());
            Console.WriteLine("Count: " + linkedQueue.Count);
        }
    }
}
