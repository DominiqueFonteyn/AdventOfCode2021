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
            throw new NotImplementedException();
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

        public IEnumerable<int> FindLowPoints(int[,] grid)
        {
            // var overlay = new int[grid.GetLength(0), grid.GetLength(1)];

            for (var i = 0; i < grid.GetLength(0); i++)
            for (var j = 0; j < grid.GetLength(1); j++)
                if (IsLowerThanAdjacentLocations(i, j, grid))
                    yield return grid[i, j];
            // overlay[i, j] = 1;
        }

        private bool IsLowerThanAdjacentLocations(int i, int j, int[,] grid)
        {
            return FindAdjacentLocations(i, j, grid)
                .All(adjacentLocation => adjacentLocation >= grid[i, j]);
        }

        private IEnumerable<int> FindAdjacentLocations(int i, int j, int[,] grid)
        {
            var height = grid.GetLength(0) - 1;
            var width = grid.GetLength(1) - 1;

            if (j > 0) yield return grid[i, j - 1];
            if (j < width) yield return grid[i, j + 1];
            if (i > 0) yield return grid[i - 1, j];
            if (i < height) yield return grid[i + 1, j];
        }

        public int RiskLevel(int i)
        {
            return i + 1;
        }
    }
}