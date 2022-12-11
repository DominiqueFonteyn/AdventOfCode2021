using System;

namespace AdventOfCode.Tests._2022._9
{
    public class Position
    {
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; private set; }
        public int Y { get; private set; }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Position pos)) return false;
            return pos.X == X && pos.Y == Y;
        }

        protected bool Equals(Position other)
        {
            return X == other.X
                && Y == other.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public static bool operator ==(Position left, Position right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Position left, Position right)
        {
            return !Equals(left, right);
        }

        public void StepTo(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    Y++;
                    break;
                case Direction.Down:
                    Y--;
                    break;
                case Direction.Right:
                    X++;
                    break;
                case Direction.Left:
                default:
                    X--;
                    break;
            }
        }

        public void MoveTowards(Position position)
        {
            if (position.Y == Y)
            {
                X += position.X > X ? 1 : -1;
            }
            else if (position.X == X)
            {
                Y += position.Y > Y ? 1 : -1;
            }
            else
            {
                Y += position.Y > Y ? 1 : -1;
                X += position.X > X ? 1 : -1;
            }
        }

        public bool Touches(Position pos)
        {
            if (pos == this) return true;
            if (Math.Abs(pos.X - X) == 1 && Math.Abs(pos.Y - Y) == 1) return true;
            if (Math.Abs(pos.X - X) == 1 && pos.Y == Y) return true;
            if (Math.Abs(pos.Y - Y) == 1 && pos.X == X) return true;
            return false;
        }
    }
}
