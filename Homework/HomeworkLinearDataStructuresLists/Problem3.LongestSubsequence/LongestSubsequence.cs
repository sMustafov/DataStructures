namespace Problem3.LongestSubsequence
{
    using System;
    using System.Collections.Generic;

    class LongestSubsequence
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(' ');
            List<int> numbers = new List<int>();
            List<int> newList = new List<int>();
            int num = 0;
            int count = 1;
            int maxCount = 0;

            if (input.Length == 1)
            {
                newList.Add(int.Parse(input[0]));
                Console.WriteLine(newList[0]);
            }
            else
            {
                for (int i = 0; i < input.Length - 1; i++)
                {
                    numbers.Add(int.Parse(input[i]));

                    if (int.Parse(input[i]) == int.Parse(input[i + 1]))
                    {
                        count++;

                        if (maxCount < count)
                        {
                            num = int.Parse(input[i]);
                            maxCount = count;
                        }
                    }
                    else
                    {
                        count = 1;

                        if (maxCount < count)
                        {
                            num = int.Parse(input[i]);
                            maxCount = count;
                        }
                    }
                }
            }

            for (int i = 0; i < maxCount; i++)
            {
                newList.Add(num);
            }

            for (int i = 0; i < maxCount; i++)
            {
                Console.Write(newList[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
