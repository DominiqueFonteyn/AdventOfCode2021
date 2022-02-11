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
        [InlineData(new[] { 22, 13, 17, 11, 0 }, true)]
        [InlineData(new[] { 22, 8, 21, 6, 1 }, true)]
        [InlineData(new[] { 22, 8, 21 }, false)]
        [InlineData(new[] { 22, 13, 17 }, false)]
        [InlineData(new[] { 22, 2, 14, 18, 19 }, false)]
        [InlineData(new[] { 99 }, false)]
        public void HasCompleteRow(int[] numbers, bool hasRow)
        {
            var board = new GiantSquid.BingoBoard(_numbers);
            foreach (var number in numbers) board.Mark(number);

            Assert.Equal(hasRow, board.HasCompleteRow());
        }

        [Fact]
        public void ReturnUnmarkedNumbers()
        {
            var board = new GiantSquid.BingoBoard(_numbers);
            for (var i = 0; i < 20; i++) board.Mark(_numbers[i]);

            var unmarked = board.UnmarkedNumbers();

            Assert.Equal(new[] { 1, 12, 20, 15, 19 }, unmarked);
        }
    }
}