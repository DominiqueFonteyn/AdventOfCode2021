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
            var y1 = Math.Min(Start.Y, End.Y);
            var y2 = Math.Max(Start.Y, End.Y);
            var x1 = Math.Min(Start.X, End.X);
            var x2 = Math.Max(Start.X, End.X);

            return Direction switch
            {
                VectorDirection.Vertical => ProjectVertical(y1, y2),
                VectorDirection.Horizontal => ProjectHorizontal(x1, x2),
                VectorDirection.Diagonal => ProjectDiagonal(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private IEnumerable<Coordinate> ProjectDiagonal()
        {
            if (End.X - Start.X == End.Y - Start.Y)
            {
                var coefficient = Start.X < End.X ? 1 : -1;
                for (var i = 0; i <= Math.Abs(End.X - Start.X); i++)
                    yield return new Coordinate(
                        Start.X + i * coefficient,
                        Start.Y + i * coefficient
                    );
            }
            else
            {
                var coefficient = Start.X < End.X ? 1 : -1;
                for (var i = 0; i <= Math.Abs(End.X - Start.X); i++)
                    yield return new Coordinate(
                        Start.X + i * coefficient,
                        Start.Y - i * coefficient
                    );
            }
        }

        private IEnumerable<Coordinate> ProjectHorizontal(int x1, int x2)
        {
            var coefficient = Start.X < End.X ? 1 : -1;
            for (var i = 0; i <= Math.Abs(End.X - Start.X); i++)
                yield return new Coordinate(Start.X + i * coefficient, Start.Y);
        }

        private IEnumerable<Coordinate> ProjectVertical(int y1, int y2)
        {
            var coefficient = Start.Y < End.Y ? 1 : -1;
            for (var i = 0; i <= Math.Abs(End.Y - Start.Y); i++)
                yield return new Coordinate(Start.X, Start.Y + i * coefficient);
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