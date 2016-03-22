namespace Problem2.CountSymbols
{
    using System;
    using System.Collections.Generic;

    class CountSymbols
    {
        static void Main()
        {
            var symbols = new SortedDictionary<char,int>();
            string input = Console.ReadLine();
            int counter = 1;
            for (int i = 0; i < input.Length; i++)
            {
                if (!symbols.ContainsKey(input[i]))
                {
                    symbols[input[i]] = counter;
                    counter = 1;
                }
                else
                {
                    symbols[input[i]]++;
                }
            }

            foreach (var symbol in symbols)
            {
                Console.WriteLine("{0}: {1} time/s", symbol.Key,symbol.Value);
            }
        }
    }
}
