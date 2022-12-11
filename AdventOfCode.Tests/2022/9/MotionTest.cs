using Xunit;

namespace AdventOfCode.Tests._2022._9
{
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
}
