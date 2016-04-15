namespace Problem3ImplementAnArrayBasedStack
{
    using System;

    class ArrayStackMain
    {
        static void Main()
        {
            ArrayStack<int> arrayStack = new ArrayStack<int>();
            arrayStack.Push(1);
            arrayStack.Push(3);
            arrayStack.Push(5);
            arrayStack.Push(7);
            arrayStack.Push(9);
            arrayStack.Push(11);
            arrayStack.Push(13);
            arrayStack.Push(15);
            arrayStack.Push(16);
            arrayStack.Push(18);
            arrayStack.Push(20);
            arrayStack.Push(22);
            arrayStack.Push(33);
            arrayStack.Push(40);
            arrayStack.Push(50);
            arrayStack.Push(66);
            arrayStack.Push(69);
            arrayStack.Push(90);
            
            Console.WriteLine("Arrays Capacity : " + arrayStack.Capacity);
            Console.WriteLine("Arrays Count before pop : " + arrayStack.Count);

            Console.WriteLine(arrayStack.Pop());
            Console.WriteLine(arrayStack.Pop());
            Console.WriteLine(arrayStack.Pop());
            Console.WriteLine(arrayStack.Pop());
            Console.WriteLine(arrayStack.Pop());
            Console.WriteLine(arrayStack.Pop());
            Console.WriteLine(arrayStack.Pop());

            Console.WriteLine("Arrays Count after pop : " + arrayStack.Count);
        }
    }
}
