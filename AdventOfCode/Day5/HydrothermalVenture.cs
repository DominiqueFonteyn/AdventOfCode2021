using System;
using System.Collections.Generic;

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
        private readonly int[,] _grid;

        public Grid(int height, int width)
        {
            Width = width;
            Height = height;

            _grid = new int[height, width];
        }

        public int Height { get; }
        public int Width { get; }

        public void Apply(Vector vector)
        {
            foreach (var coordinate in vector.Project()) 
                _grid[coordinate.Y, coordinate.X] += 1;
        }

        public int ValueAt(Coordinate position)
        {
            return _grid[position.Y, position.X];
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

        public IEnumerable<Coordinate> Project()
        {
            if (Start.X == End.X)
                for (var i = Start.Y; i <= End.Y; i++)
                    yield return new Coordinate(Start.X, i);
            else
                for (var i = Start.X; i <= End.X; i++)
                    yield return new Coordinate(i, Start.Y);
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