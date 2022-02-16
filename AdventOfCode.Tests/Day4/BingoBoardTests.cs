using AdventOfCode.Day4;
using Xunit;

namespace AdventOfCode.Tests.Day4
{
    public class BingoBoardTests
    {
        private readonly int[] _numbers =
        {
            22, 13, 17, 11, 0,
            8, 2, 23, 4, 24,
            21, 9, 14, 16, 7,
            6, 10, 3, 18, 5,
            1, 12, 20, 15, 19
        };

        [Theory]
        // horizontal
        [InlineData(new[] { 22, 13, 17, 11, 0 }, true)]
        [InlineData(new[] { 8, 2, 23, 4, 24 }, true)]
        [InlineData(new[] { 21, 9, 14, 16, 7 }, true)]
        [InlineData(new[] { 6, 10, 3, 18, 5 }, true)]
        [InlineData(new[] { 1, 12, 20, 15, 19 }, true)]
        // vertical
        [InlineData(new[] { 22, 8, 21, 6, 1 }, true)]
        [InlineData(new[] { 13, 2, 9, 10, 12 }, true)]
        [InlineData(new[] { 17, 23, 14, 3, 20 }, true)]
        [InlineData(new[] { 11, 4, 16, 18, 15 }, true)]
        [InlineData(new[] { 0, 24, 7, 5, 19 }, true)]
        // other combos
        [InlineData(new[] { 22, 8, 21 }, false)]
        [InlineData(new[] { 22, 13, 17 }, false)]
        [InlineData(new[] { 22, 2, 14, 18, 19 }, false)]
        [InlineData(new[] { 99 }, false)]
        public void HasCompleteRow(int[] numbers, bool hasRow)
        {
            var board = new BingoBoard(_numbers);
            foreach (var number in numbers) board.Mark(number);

            Assert.Equal(hasRow, board.Wins());
        }

        [Fact]
        public void ReturnUnmarkedNumbers()
        {
            var board = new BingoBoard(_numbers);
            for (var i = 0; i < 20; i++) board.Mark(_numbers[i]);

            var unmarked = board.UnmarkedNumbers();

            Assert.Equal(new[] { 1, 12, 20, 15, 19 }, unmarked);
        }
    }
}