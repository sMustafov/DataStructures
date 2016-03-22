namespace Problem1.FindTheRoot
{
    using System;
    using System.Collections.Generic;

    class FindTheRoot
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            bool[] hasParents = new bool[n + 1];

            for (int i = 0; i < m; i++)
            {
                var num = Console.ReadLine().Split(' ');
                var toNode = int.Parse(num[1]);

                hasParents[toNode] = true;
            }

            List<int> parents = new List<int>();
            for (int i = 0; i < n; i++)
            {
                if (!hasParents[i])
                {
                    parents.Add(i);
                }
            }

            if (parents.Count == 0)
            {
                Console.WriteLine("No root!");
            }
            else if (parents.Count > 1)
            {
                Console.WriteLine("Multiple root nodes!");
            }
            else
            {
                Console.WriteLine("Root: " + parents[0]);
            }
        }
    }
}
