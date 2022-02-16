using System.Collections.Generic;

namespace AdventOfCode.Day5
{
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
}