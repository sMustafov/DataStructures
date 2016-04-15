namespace Problem2.SortWords
{
    using System;
    using System.Collections.Generic;

    class SortWords
    {
        static void Main()
        {
            string[] inputLine = Console.ReadLine().Split(' ');
            List<String> words = new List<string>();

            for (int i = 0; i < inputLine.Length; i++)
            {
                words.Add(inputLine[i]);
            }

            string[] wordsArr = words.ToArray();
            Array.Sort(wordsArr);

            for (int i = 0; i < wordsArr.Length; i++)
            {
                Console.Write(wordsArr[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
