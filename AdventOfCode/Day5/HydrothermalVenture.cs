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
            Start = start;
            End = end;
        }

        public Coordinate Start { get; }
        public Coordinate End { get; }

        public static Vector FromString(string str)
        {
            var split = str.Split(" -> ");
            return new Vector(
                Coordinate.FromString(split[0]),
                Coordinate.FromString(split[1]));
        }


        public override string ToString()
        {
            return $"{Start} -> {End}";
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

        public static Coordinate FromString(string str)
        {
            var split = str.Split(',');
            return new Coordinate(int.Parse(split[0]), int.Parse(split[1]));
        }
    }
}