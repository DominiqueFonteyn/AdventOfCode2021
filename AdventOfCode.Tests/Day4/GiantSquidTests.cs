using AdventOfCode.Day4;
using Xunit;

namespace AdventOfCode.Tests.Day4
{
    public class GiantSquidTests
    {
        private readonly string[] _input =
        {
            "7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1",
            "",
            "22 13 17 11  0",
            "8  2 23  4 24",
            "21  9 14 16  7",
            "6 10  3 18  5",
            "1 12 20 15 19",
            "",
            "3 15  0  2 22",
            "9 18 13 17  5",
            "19  8  7 25 23",
            "20 11 10 24  4",
            "14 21 16 12  6",
            "",
            "14 21 17 24  4",
            "10 16 15  9 19",
            "18  8 23 26 20",
            "22 11 13  6  5",
            "2  0 12  3  7"
        };

        [Fact]
        public void PartOne()
        {
            Assert.Equal(4512, new GiantSquid().PartOne(_input));
        }

        [Fact]
        public void ReadPickedNumbers()
        {
            var numbers = new GiantSquid().ReadPickedNumbers(_input);

            Assert.Equal(string.Join(",", numbers), _input[0]);
        }

        [Fact]
        public void ParseBoards()
        {
            var boards = new GiantSquid().ParseBoards(_input);

            Assert.Equal(3, boards.Length);

            foreach (var board in boards) Assert.Equal(25, board.Numbers.Length);
        }
    }

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