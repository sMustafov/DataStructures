namespace Problem4.RemoveOddOccurences
{
    using System;
    using System.Collections.Generic;

    class RemoveOddOccurences
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(' ');
            List<int> numbers = new List<int>();
            List<int> newList = new List<int>();

            for (int n = 0; n < input.Length; n++)
            {
                numbers.Add(int.Parse(input[n]));
            }

            int count = 1;

            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = i + 1; j < numbers.Count; j++)
                {
                    if (numbers[i] == numbers[j])
                    {
                        count++;
                    }
                }

                if (count%2 == 0)
                {
                    for (int k = 0; k < count; k++)
                    {
                        newList.Add(numbers[i]);
                    }
                    int n = numbers[i];
                    numbers.RemoveAll(x => x == n);
                    i--;
                }
                else
                {
                    int n = numbers[i];
                    numbers.RemoveAll(x => x == n);
                    i--;
                }

                count = 1;
            }

            for (int i = 0; i < newList.Count; i++)
            {
                Console.WriteLine(newList[i]);
            }
        }
    }
}
