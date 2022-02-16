using System;

namespace AdventOfCode.Day5
{
    public class HydrothermalVenture : Day<int>
    {
        public HydrothermalVenture() : base(5)
        {
        }

        public override int PartOne(string[] input)
        {
            throw new NotImplementedException();
        }

        public override int PartTwo(string[] input)
        {
            throw new NotImplementedException();
        }
    }

    public class Grid
    {
        private readonly int _height;
        private readonly int _width;

        private int[,] _grid;

        public Grid(int width, int height)
        {
            _width = width;
            _height = height;

            _grid = new int[height, width];
        }
    }

    public class Vector
    {
        public Vector(Coordinate start, Coordinate end)
        {
            
        }
    }

    public class Coordinate
    {
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }

        public override string ToString()
        {
            return $"{X},{Y}";
        }
    }
}