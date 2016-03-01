namespace Problem1.ReverseNumbersWithАStack
{
    using System;
    using System.Collections.Generic;

    class ReverseNumbersWithAStack
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Stack<int> stack = new Stack<int>();

            try
            {
                string[] nums = input.Split(' ');

                for (int i = 0; i < nums.Length; i++)
                {
                    stack.Push(int.Parse(nums[i]));
                }

                while (stack.Count != 0)
                {
                    Console.Write(stack.Pop() + " ");
                }

                Console.WriteLine();
            }
            catch (Exception)
            {
                Console.WriteLine(input);
            }
        }
    }
}
