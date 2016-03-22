namespace Problem3.FastSearchForStringsInATextFile
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class FastSearchForStringsInATextFile
    {
        static void Main()
        {
            var dictionary = new Dictionary<string, int>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string searchedWord = Console.ReadLine();
                dictionary.Add(searchedWord, 0);
            }

            int m = int.Parse(Console.ReadLine());
            for (int i = 0; i < m; i++)
            {
                string textLine = Console.ReadLine();
                StringBuilder sb = new StringBuilder();
                for (int a = 0; a < textLine.Length; a++)
                {
                    sb.Append(textLine[a]);
                    foreach (var word in dictionary.Keys.ToList())
                    {
                        if (sb.ToString().ToLower().EndsWith(word.ToLower()))
                        {
                            dictionary[word]++;
                        }
                    }
                }
            }

            foreach (var w in dictionary)
            {
                Console.WriteLine("{0} -> {1}", w.Key,w.Value);
            }
        }
    }
}
