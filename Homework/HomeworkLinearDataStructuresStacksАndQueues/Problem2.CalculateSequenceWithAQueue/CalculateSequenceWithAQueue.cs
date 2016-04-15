namespace Problem2.CalculateSequenceWithAQueue
{
    using System;
    using System.Collections.Generic;

    class CalculateSequenceWithAQueue
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int> queue = new Queue<int>();
            int firstNum = n;
            queue.Enqueue(firstNum);
            Console.WriteLine("S1: " + firstNum);

            for (int i = 2; i < 49; i++)
            {
                firstNum = queue.Dequeue();

                int secondNum = firstNum + 1;
                queue.Enqueue(secondNum);
                Console.WriteLine("S{0}: {1}", i, secondNum);

                int thirdNum = 2*firstNum + 1;
                queue.Enqueue(thirdNum);
                Console.WriteLine("S{0}: {1}", i + 1, thirdNum);

                int forthNum = firstNum + 2;
                queue.Enqueue(forthNum);
                Console.WriteLine("S{0}: {1}", i + 2, forthNum);
            }
        }
    }
}
