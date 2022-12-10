using System;
using Xunit;

namespace AdventOfCode.Tests._2022._9
{
    public class Day9Test : TestBase
    {
        public Day9Test() : base(2022, 9)
        {
        }

        protected override int ExpectedResultPart1 { get; }
        protected override int ExpectedResultPart2 { get; }

        protected override int Calculate(string[] data)
        {
            throw new NotImplementedException();
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
}
