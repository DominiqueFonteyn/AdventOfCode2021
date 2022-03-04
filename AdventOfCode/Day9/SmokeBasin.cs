using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day9
{
    public class SmokeBasin : Day<int>
    {
        public SmokeBasin() : base(9)
        {
        }

        public override int PartOne(string[] input)
        {
            var grid = MapToGrid(input);
            var lowPoints = FindLowPoints(grid);

            return lowPoints.Sum(RiskLevel);
        }

        public override int PartTwo(string[] input)
        {
            var grid = MapToGrid(input);
            var lowPoints = FindLowPoints(grid);
            var basins = FindBasins(lowPoints, grid).OrderByDescending(x => x.Length).ToArray();
            var top3 = basins.Take(3);

            var totalSize = 1;
            foreach (var basin in top3)
            {
                Console.WriteLine($"Basin ({basin.Length}): {string.Join(", ", basin)}");
                totalSize *= basin.Length;
            }

            return totalSize;
        }

        public int[,] MapToGrid(string[] input)
        {
            var width = input[0].Length;
            var height = input.Length;

            var grid = new int[height, width];
            for (var i = 0; i < height; i++)
            for (var j = 0; j < width; j++)
                grid[i, j] = int.Parse(input[i][j].ToString());

            return grid;
        }

        public IEnumerable<Point> FindLowPoints(int[,] grid)
        {
            var overlay = new int[grid.GetLength(0), grid.GetLength(1)];

            for (var i = 0; i < grid.GetLength(0); i++)
            for (var j = 0; j < grid.GetLength(1); j++)
                if (IsLowerThanAdjacentLocations(i, j, grid))
                {
                    Console.WriteLine($"grid[{i},{j}] = {grid[i, j]}");
                    yield return new Point(i, j, grid[i, j]);
                    overlay[i, j] = 1;
                }
        }

        private bool IsLowerThanAdjacentLocations(int i, int j, int[,] grid)
        {
            return FindAdjacentLocations(i, j, grid)
                .All(adjacentLocation => adjacentLocation.Value > grid[i, j]);
        }

        private IEnumerable<Point> FindAdjacentLocations(int i, int j, int[,] grid)
        {
            var height = grid.GetLength(0) - 1;
            var width = grid.GetLength(1) - 1;

            if (j > 0) yield return new Point(i, j - 1, grid[i, j - 1]);
            if (j < width) yield return new Point(i, j + 1, grid[i, j + 1]);
            if (i > 0) yield return new Point(i - 1, j, grid[i - 1, j]);
            if (i < height) yield return new Point(i + 1, j, grid[i + 1, j]);
        }

        private IEnumerable<Point> FindAdjacentLocations(Point point, int[,] grid)
        {
            return FindAdjacentLocations(point.I, point.J, grid);
        }

        public int RiskLevel(Point p)
        {
            return p.Value + 1;
        }

        public IEnumerable<int[]> FindBasins(IEnumerable<Point> lowPoints, int[,] grid)
        {
            return lowPoints.Select(
                point => FindBasin(point, grid, new HashSet<Point>()).Select(x => x.Value).ToArray());
        }

        private IEnumerable<Point> FindBasin(Point startPoint, int[,] grid, HashSet<Point> ignore)
        {
            var basin = new HashSet<Point> { startPoint };
            var adjacentLocations = FindAdjacentLocations(startPoint, grid);
            var queue = new Queue<Point>(adjacentLocations.Except(ignore));

            while (queue.Count > 0)
            {
                var point = queue.Dequeue();
                if (point.Value != 9 && (IsSameHeight(startPoint, point) || FlowsDownward(startPoint, point)))
                    foreach (var c in FindBasin(point, grid, basin))
                        basin.Add(c);
            }

            return basin;
        }

        private static bool FlowsDownward(Point startPoint, Point point)
        {
            return point.Value == startPoint.Value + 1;
        }

        private static bool IsSameHeight(Point startPoint, Point point)
        {
            return point.Value == startPoint.Value;
        }
    }
}