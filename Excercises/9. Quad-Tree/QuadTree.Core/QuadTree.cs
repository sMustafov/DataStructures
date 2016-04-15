namespace QuadTree.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class QuadTree<T> where T : IBoundable, IComparable
    {
        public const int DefaultMaxDepth = 5;

        public readonly int MaxDepth;

        private Node<T> root;

        public QuadTree(int width, int height, int maxDepth = DefaultMaxDepth)
        {
            this.root = new Node<T>(0,0,width,height);
            this.Bounds = this.root.Bounds;
            this.MaxDepth = maxDepth;
        }

        public int Count { get; private set; }

        public Rectangle Bounds { get; private set; }

        public bool Insert(T item)
        {
            if (!item.Bounds.IsInside(this.Bounds))
            {
                return false;
            }

            int depth = 1;
            var currentNode = this.root;

            while (currentNode.Children != null)
            {
                var quadrant = GetQuadrant(currentNode, item.Bounds);
                if (quadrant == -1)
                {
                    currentNode.Items[quadrant] = item;////////
                }
            }
            currentNode.Items.Add(item);
            this.Split(currentNode, depth);
            this.Count++;

            return true;
        }

        private static int GetQuadrant(Node<T> node, Rectangle bounds)
        {
            var verticalMidpoint = node.Bounds.MidX;
            var horizontalMidpoint = node.Bounds.MidY;

            var inTopQuadrant = node.Bounds.Y1 <= bounds.Y1 && bounds.Y2 <= horizontalMidpoint;
            var inBottomQuadrant = horizontalMidpoint <= bounds.Y1 && bounds.Y2 < node.Bounds.Y2;
            var inLeftQuadrant = node.Bounds.X1 <= bounds.X1 && bounds.X2 <= verticalMidpoint;
            var inRightQuadrant = verticalMidpoint <= bounds.X1 && bounds.X2 < node.Bounds.X2;

            if (inLeftQuadrant)
            {
                if (inTopQuadrant)
                {
                    return 2;
                }
                else if (inBottomQuadrant)
                {
                    return 3;
                }
            }
            else if (inRightQuadrant)
            {
                if (inTopQuadrant)
                {
                    return 1;
                }
                else if (inBottomQuadrant)
                {
                    return 4;
                }
            }

            return 0;
        }

        private void Split(Node<T> node, int nodeDepth)
        {
            if (!(node.ShouldSplit && nodeDepth < MaxDepth))
            {
                return;
            }

            var leftWidth = node.Bounds.Width / 2;
            var rightWidth = node.Bounds.Width - leftWidth;
            var topHight = node.Bounds.Height / 2;
            var bottomHeight = node.Bounds.Height - topHight;

            node.Children = new Node<T>[4];
            node.Children[0] = new Node<T>(node.Bounds.MidY, node.Bounds.Y1, rightWidth, topHight);
            node.Children[1] = new Node<T>(node.Bounds.X1, node.Bounds.Y1, leftWidth, topHight);
            node.Children[2] = new Node<T>(node.Bounds.X2,node.Bounds.Y2,leftWidth,bottomHeight);////////
            node.Children[3] = new Node<T>(node.Bounds.MidX,node.Bounds.Y2,rightWidth,bottomHeight);////////

            for (int i = 0; i < node.Items.Count; i++)
            {
                var item = node.Items[i];
                var quadrant = GetQuadrant(node, item.Bounds);
                if (quadrant != -1)
                {
                   //////////
                }
            }

            foreach (var child in node.Children)
            {
                Split(child, nodeDepth + 1);
            }
        }

        public List<T> Report(Rectangle bounds)
        {
            var collisionCandidate = new List<T>();

            GetCollisionCandidate(this.root, bounds, collisionCandidate);

            return collisionCandidate;
        }

        private static void GetCollisionCandidate(Node<T> node, Rectangle bounds, List<T> results)
        {
            var quadrant = GetQuadrant(node, bounds);
            if (quadrant == -1)
            {
                GetSubTreeContents(node, bounds, results);
            }
            else
            {
                if (node.Children != null)
                {
                    GetQuadrant(node, bounds); //////
                }
                results.AddRange(node.Items);
            }
        }

        private static void GetSubTreeContents(Node<T> node, Rectangle bounds, List<T> results)
        {
            if (node.Children != null)
            {
                foreach (var child in node.Children)
                {
                    if (child.Bounds.Intersects(bounds))
                    {
                        GetSubTreeContents(child, bounds, results);
                    }
                }
            }
            results.AddRange(node.Items);
        }

        public void ForEachDfs(Action<List<T>, int, int> action)
        {
            ForEachDfs(this.root, action);
        }

        private void ForEachDfs(Node<T> node, Action<List<T>, int, int> action, int depth = 1, int quadrant = 0)
        {
            if (node == null)
            {
                return;
            }

            if (node.Items.Any())
            {
                action(node.Items, depth, quadrant);
            }

            if (node.Children != null)
            {
                foreach (var child in node.Children)
                {
                    ForEachDfs(child,action);/////////
                }
            }
        }

        private static List<GameObject> SweetAndPrune(List<GameObject> objects)
        {
            InsertionSort(objects);
            for (int i = 0; i < objects.Count; i++)
            {
                var currentObject = objects[i];
                for (int j = i + 1; j < objects.Count; j++)
                {
                    var candidateCollisionObject = objects[i];
                    if (currentObject.X2 < candidateCollisionObject.X1)
                    {
                        break;
                    }

                    /////////////
                }
            }

            return objects;
        }

        private static void InsertionSort(List<GameObject> objects)
        {
            for (int i = 0; i < objects.Count - 1; i++)
            {
                int j = i + 1;

                while (j > 0)
                {
                    if (objects[j - 1] > objects[j])//////////
                    {
                        var temp = objects[j - 1];
                        objects[j - 1] = objects[j];
                        objects[j] = temp;

                    }
                    j--;
                }
            }
        }
    }
}
