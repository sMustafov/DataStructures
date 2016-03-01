namespace Problem5.CountOfOccurrences
{
    using System;
    using System.Collections.Generic;
    
    class CountOfOccurrences
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(' ');
            List<int> nums = new List<int>();

            for (int i = 0; i < input.Length; i++)
            {
                nums.Add(int.Parse(input[i]));
            }

            int[] numbers = nums.ToArray();
            Array.Sort(numbers);

            int count = 1;
            if (numbers.Length == 1)
            {
                Console.WriteLine(numbers[0] + " -> " + count + " times");
            }
            else
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (i < numbers.Length - 1)
                    {
                        if (numbers[i] == numbers[i + 1])
                        {
                            count++;
                        }
                        else
                        {
                            Console.WriteLine(numbers[i] + " -> " + count + " times");
                            count = 1;
                        }
                    }
                    else
                    {
                        if (numbers[i] == numbers[i - 1])
                        {
                            Console.WriteLine(numbers[i] + " -> " + count + " times");
                        }
                        else
                        {
                            count = 1;
                            Console.WriteLine(numbers[i] + " -> " + count + " times");
                        }
                    }
                }
            }
        }
    }
}
