namespace Problem4.LongestPathInATree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class LongestPathInATree
    {
        private static IDictionary<int, IList<int>> nodes;
        private static IDictionary<int, int?> parents;
        private static IDictionary<int, int> nodeToRootSum;

        static void Main()
        {
            nodes = new Dictionary<int, IList<int>>();
            parents = new Dictionary<int, int?>();
            nodeToRootSum = new Dictionary<int, int>();

            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
                var parent = nums[0];
                var child = nums[1];

                if (!nodes.ContainsKey(parent))
                {
                    nodes[parent] = new List<int>();
                }

                nodes[parent].Add(child);

                if (!nodes.ContainsKey(child))
                {
                    nodes[child] = new List<int>();
                }

                if (!parents.ContainsKey(parent))
                {
                    parents[parent] = null;
                }

                parents[child] = parent;
            }

            foreach (var node in nodes.Keys)
            {
                nodeToRootSum[node] = 0;
            }

            var root = parents.FirstOrDefault(node => node.Value == null).Key;
            DFS(root, 0);

            var longestPath = 0;
            longestPath = FindLongestPath(longestPath);

            Console.WriteLine("Sum: " +  longestPath);
        }

        static void DFS(int node, int totalSum)
        {
            totalSum += node;
            nodeToRootSum[node] = totalSum;

            foreach (var child in nodes[node])
            {
                DFS(child, totalSum);
            }
        }

        private static int FindLongestPath(int longestPath)
        {
            foreach (var nodeA in nodeToRootSum)
            {
                foreach (var nodeB in nodeToRootSum)
                {
                    if (nodeA.Key != nodeB.Key)
                    {
                        var currentPath = nodeA.Value - nodeB.Value + nodeB.Key;
                        if (currentPath > longestPath)
                        {
                            longestPath = currentPath;
                        }
                    }
                }
            }

            return longestPath;
        }
    }
}
