namespace ReversedList
{
    using System;

    public class ReversedListMain
    {
        public static void Main()
        {
            ReversedList<int> reversedList = new ReversedList<int>();
            reversedList.Add(4);
            reversedList.Add(6);
            reversedList.Add(8);
            reversedList.Add(10);
            reversedList.Add(12);
            reversedList.Add(14);

            int count = reversedList.Count;
            Console.WriteLine("Count : {0}", count);

            int capacity = reversedList.Capacity;
            Console.WriteLine("Capacity : {0}", capacity);

            int forthNum = reversedList[3];
            Console.WriteLine("Forth Num : {0}", forthNum);

            Console.WriteLine("Before Removing an element : ");
            Console.WriteLine(string.Join(", ", reversedList));

            reversedList.Remove(3); // element = 8
            Console.WriteLine("After Removing an element : ");
            Console.WriteLine(string.Join(", ", reversedList));
        }
    }
}
