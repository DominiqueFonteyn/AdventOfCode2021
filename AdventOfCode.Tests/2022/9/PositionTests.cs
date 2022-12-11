using Xunit;

namespace AdventOfCode.Tests._2022._9
{
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
        [InlineData(5, 5, 4, 4, true)]
        [InlineData(5, 5, 6, 4, true)]
        [InlineData(5, 5, 4, 6, true)]
        [InlineData(5, 5, 7, 7, false)] 
        [InlineData(5, 5, 6, 9, false)] 
        public void Touches(int headX, int headY, int tailX, int tailY, bool touches)
        {
            var head = new Position(headX, headY);
            var tail = new Position(tailX, tailY);
            
            Assert.Equal(touches, tail.Touches(head));
        }
    }
}
