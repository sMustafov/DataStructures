namespace Problem3.RideTheHorse
{
    using System;
    using System.Collections.Generic;

    class Point
    {
        public Point(int x, int y, int value = 1)
        {
            this.X = x;
            this.Y = y;
            this.Value = value;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int Value { get; set; }
    }

    class RideTheHorse
    {
        private static int[,] field;
        private static int width;
        private static int height;

        static void Main()
        {
            width = int.Parse(Console.ReadLine());
            height = int.Parse(Console.ReadLine());
            field = new int[width,height];

            int rowOfStartPos = int.Parse(Console.ReadLine());
            int colOfStartPos = int.Parse(Console.ReadLine());
            var startCell = new Point(rowOfStartPos,colOfStartPos);
            var queue = new Queue<Point>();
            queue.Enqueue(startCell);
            while (queue.Count > 0)
            {
                var currentCell = queue.Dequeue();
                field[currentCell.X, currentCell.Y] = currentCell.Value;

                TryDirection(queue, currentCell, -2, 1);
                TryDirection(queue, currentCell, -1, 2);
                TryDirection(queue, currentCell, 1, 2);
                TryDirection(queue, currentCell, 2, 1);
                TryDirection(queue, currentCell, 2, -1);
                TryDirection(queue, currentCell, 1, -2);
                TryDirection(queue, currentCell, -1, -2);
                TryDirection(queue, currentCell, -2, -1);
            }

            PrintNeededCol();

        }

        static void TryDirection(Queue<Point> queue, Point currentCell, int deltaX, int deltaY)
        {
            int newX = currentCell.X + deltaX;
            int newY = currentCell.Y + deltaY;

            if (newX >= 0 && newX < width &&
                newY >= 0 && newY < height &&
                field[newX, newY] == 0)
            {
                queue.Enqueue(new Point(newX, newY, currentCell.Value + 1));
            }
        }

        private static void PrintNeededCol()
        {
            Console.WriteLine();

            for (int x = 0; x < width; x++)
            {
                Console.WriteLine(field[x, height / 2]);
            }
        }
    }
}
