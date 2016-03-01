namespace Problem1.SumAndAverage
{
    using System;
    using System.Collections.Generic;

    class SumAndAverage
    {
        static void Main()
        {
            string inputLine = Console.ReadLine();

            if (inputLine == "")
            {
                Console.WriteLine("Sum=0; Average=0");
            }
            else
            {
                string[] input = inputLine.Split(' ');
                List<int> numbers = new List<int>();
                double sum = 0.0;
                double average = 0.0;

                for (int i = 0; i < input.Length; i++)
                {
                    numbers.Add(int.Parse(input[i]));
                    sum += numbers[i];
                }

                average = sum / numbers.Count;
                Console.WriteLine("Sum={0}; Average={1}", sum, average);
            }
        }
    }
}
