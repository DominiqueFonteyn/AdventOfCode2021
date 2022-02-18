using System;
using System.Collections.Generic;

namespace AdventOfCode.Day5
{
    public class Vector
    {
        public Vector(Coordinate start, Coordinate end)
        {
            Start = start;
            End = end;

            DetermineDirection();
        }

        public Coordinate Start { get; }
        public Coordinate End { get; }

        public VectorDirection Direction { get; private set; }

        private void DetermineDirection()
        {
            if (Start.X == End.X)
                Direction = VectorDirection.Vertical;
            else if (Start.Y == End.Y)
                Direction = VectorDirection.Horizontal;
            else
                Direction = VectorDirection.Other;
        }

        public static Vector FromString(string str)
        {
            var split = str.Split(" -> ");
            return new Vector(
                Coordinate.FromString(split[0]),
                Coordinate.FromString(split[1]));
        }

        public IEnumerable<Coordinate> Project()
        {
            switch (Direction)
            {
                case VectorDirection.Vertical:
                {
                    for (var i = Start.Y; i <= End.Y; i++)
                        yield return new Coordinate(Start.X, i);
                    break;
                }
                case VectorDirection.Horizontal:
                {
                    for (var i = Start.X; i <= End.X; i++)
                        yield return new Coordinate(i, Start.Y);
                    break;
                }
                case VectorDirection.Other:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override string ToString()
        {
            return $"{Start} -> {End}";
        }
    }

    public enum VectorDirection
    {
        Horizontal,
        Vertical,
        Other
    }
}