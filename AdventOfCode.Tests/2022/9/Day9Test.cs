using System;
using System.Collections.Generic;
using Xunit;

namespace AdventOfCode.Tests._2022._9
{
    public class Day9Test : TestBase
    {
        public Day9Test() : base(2022, 9)
        {
        }

        protected override int ExpectedResultPart1 => 13;
        protected override int ExpectedResultPart2 { get; }

        protected override int Calculate(string[] data)
        {
            var head = new Position(0, 0);
            var tail = new Position(0, 0);
            var visited = new HashSet<Position> { new Position(0, 0) };

            foreach (var line in data)
            {
                var motion = new Motion(line);

                // handle motion
                for (var i = 0; i < motion.Steps; i++)
                {
                    head.StepTo(motion.Direction);
                }
            }

            return visited.Count;
        }

        protected override int Calculate2(string[] data)
        {
            throw new NotImplementedException();
        }
    }

    #region Motion

    public enum Direction
    {
        Up,
        Right,
        Down,
        Left
    }

    public class Motion
    {
        public Motion(string input)
        {
            Direction = GetDirection(input[..1]);
            Steps = int.Parse(input[2..]);
        }

        public Direction Direction { get; }
        public int Steps { get; }

        private Direction GetDirection(string d)
        {
            return d switch
            {
                "U" => Direction.Up,
                "R" => Direction.Right,
                "D" => Direction.Down,
                "L" => Direction.Left,
                _ => throw new NotSupportedException()
            };
        }
    }

    public class MotionTest
    {
        [Theory]
        [InlineData("U 13", Direction.Up, 13)]
        [InlineData("L 1", Direction.Left, 1)]
        [InlineData("R 10", Direction.Right, 10)]
        [InlineData("D 3", Direction.Down, 3)]
        public void Ctor_ParsesInput(string input, Direction direction, int steps)
        {
            var motion = new Motion(input);

            Assert.Equal(direction, motion.Direction);
            Assert.Equal(steps, motion.Steps);
        }
    }

    #endregion

    #region Position

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
    }

    public class PositionTests
    {
        [Theory]
        [InlineData(5, 5, Direction.Up, 5, 6)]
        [InlineData(5, 5, Direction.Down, 5, 4)]
        [InlineData(5, 5, Direction.Right, 6, 5)]
        [InlineData(5, 5, Direction.Left, 4, 5)]
        public void StepTo(int startX, int startY, Direction direction, int expectedX, int expectedY)
        {
            var position = new Position(startX, startY);

            position.StepTo(direction);

            Assert.Equal(expectedX, position.X);
            Assert.Equal(expectedY, position.Y);
        }
    }

    #endregion
}
