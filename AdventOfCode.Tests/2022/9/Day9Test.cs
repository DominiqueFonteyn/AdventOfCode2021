using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode.Tests._2022._9
{
    public class Day9Test : TestBase
    {
        private readonly ITestOutputHelper _output;

        public Day9Test(ITestOutputHelper output) : base(2022, 9)
        {
            _output = output;
        }

        protected override int ExpectedResultPart1 => 13;
        protected override int ExpectedResultPart2 { get; }

        protected override int Calculate(string[] data)
        {
            var head = new Position(1, 1);
            var tail = new Position(1, 1);
            var visited = new HashSet<Position> { new Position(1, 1) };
            var step = 0;

            foreach (var line in data)
            {
                var motion = new Motion(line);
                _output.WriteLine(line);

                // handle motion
                for (var i = 0; i < motion.Steps; i++)
                {
                    step++;
                    head.StepTo(motion.Direction);
                    
                    if (!tail.Touches(head))
                    {
                        tail.MoveTowards(head);
                        visited.Add(tail);
                    }
                    
                    _output.WriteLine($"step {step}: head {head} - tail {tail}");
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

        [Theory]
        [InlineData(1, 1, 3, 1, 2, 1)] // horizontal
        [InlineData(3, 1, 1, 1, 2, 1)]
        [InlineData(1, 4, 1, 2, 1, 3)] // vertical
        [InlineData(1, 2, 1, 4, 1, 3)]
        [InlineData(2, 2, 3, 4, 3, 3)] // diagonal
        [InlineData(2, 2, 4, 3, 3, 3)]
        public void MoveTowards(int startX, int startY, int toX, int toY, int expectedX, int expectedY)
        {
            var position = new Position(startX, startY);

            position.MoveTowards(new Position(toX, toY));

            Assert.Equal(expectedX, position.X);
            Assert.Equal(expectedY, position.Y);
        }

        [Theory]
        [InlineData(5, 5, 5, 5, true)] // on same spot
        [InlineData(5, 5, 4, 5, true)] // horizontal
        [InlineData(5, 5, 6, 5, true)]
        [InlineData(5, 5, 3, 5, false)]
        [InlineData(5, 5, 7, 5, false)]
        [InlineData(5, 5, 5, 4, true)] // vertical
        [InlineData(5, 5, 5, 6, true)]
        [InlineData(5, 5, 5, 3, false)]
        [InlineData(5, 5, 5, 7, false)]
        [InlineData(5, 5, 6, 6, true)] // diagonal
        [InlineData(5, 5, 4, 4, true)] // diagonal
        [InlineData(5, 5, 6, 4, true)] // diagonal
        [InlineData(5, 5, 4, 6, true)] // diagonal
        [InlineData(5, 5, 7, 7, false)] // diagonal
        [InlineData(5, 5, 6, 9, false)] // diagonal
        public void Touches(int headX, int headY, int tailX, int tailY, bool touches)
        {
            var head = new Position(headX, headY);
            var tail = new Position(tailX, tailY);
            
            Assert.Equal(touches, tail.Touches(head));
        }
    }

    #endregion
}
