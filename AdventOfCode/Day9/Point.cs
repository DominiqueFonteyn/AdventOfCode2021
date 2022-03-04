using System;

namespace AdventOfCode.Day9
{
    public class Point
    {
        public Point(int i, int j, int value)
        {
            I = i;
            J = j;
            Value = value;
        }

        public int I { get; }
        public int J { get; }
        public int Value { get; }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Point);
        }

        private bool Equals(Point other)
        {
            return I == other.I && J == other.J && Value == other.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(I, J, Value);
        }

        public static bool operator ==(Point left, Point right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Point left, Point right)
        {
            return !Equals(left, right);
        }
    }
}