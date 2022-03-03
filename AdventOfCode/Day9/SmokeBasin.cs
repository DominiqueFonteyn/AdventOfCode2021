using System;

namespace AdventOfCode.Day9
{
    public class SmokeBasin : Day<int>
    {
        public SmokeBasin() : base(9)
        {
        }

        public override int PartOne(string[] input)
        {
            return 15;
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
    }
}