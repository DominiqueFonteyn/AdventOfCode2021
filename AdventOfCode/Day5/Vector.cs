using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
                Direction = VectorDirection.Diagonal;
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
                    var y1 = Math.Min(Start.Y, End.Y);
                    var y2 = Math.Max(Start.Y, End.Y);
                    for (var i = y1; i <= y2; i++)
                        yield return new Coordinate(Start.X, i);
                    break;
                }
                case VectorDirection.Horizontal:
                {
                    var x1 = Math.Min(Start.X, End.X);
                    var x2 = Math.Max(Start.X, End.X);
                    for (var i = x1; i <= x2; i++)
                        yield return new Coordinate(i, Start.Y);
                    break;
                }
                case VectorDirection.Diagonal:
                    
                    // TODO
                    
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
        Diagonal
    }
}