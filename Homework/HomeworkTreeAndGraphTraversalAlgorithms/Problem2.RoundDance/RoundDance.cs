namespace Problem2.RoundDance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class RoundDance
    {
        private static Dictionary<int, List<int>> roundDance = new Dictionary<int, List<int>>();
        private static List<int> visited = new List<int>();

        static void Main()
        {
            roundDance = new Dictionary<int, List<int>>();
            int frindships = int.Parse(Console.ReadLine());
            int leaderOfDance = int.Parse(Console.ReadLine());

            for (int i = 0; i < frindships; i++)
            {
                var num = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
                if (!roundDance.ContainsKey(num[0]))
                {
                    roundDance.Add(num[0],new List<int>());
                }

                roundDance[num[0]].Add(num[1]);

                if (!roundDance.ContainsKey(num[1]))
                {
                    roundDance.Add(num[1], new List<int>());
                }

                roundDance[num[1]].Add(num[0]);
            }

            Console.WriteLine(DFS(leaderOfDance, 1));
        }

        static int DFS(int leaderOfDance, int currentMax)
        {
            if (!visited.Contains(leaderOfDance))
            {
                visited.Add(leaderOfDance);
                currentMax = 0;

                foreach (var childNode in roundDance[leaderOfDance])
                {
                    currentMax = DFS(childNode, currentMax);
                }

                currentMax++;
            }

            return currentMax;
        }
    }
}
