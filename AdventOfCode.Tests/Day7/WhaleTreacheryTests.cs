using AdventOfCode.Day7;
using Xunit;

namespace AdventOfCode.Tests.Day7
{
    public class WhaleTreacheryTests
    {
        private readonly string[] _input = { "16,1,2,0,4,2,7,1,2,14" };

        [Fact]
        public void PartOne()
        {
            Assert.Equal(37, new WhaleTreachery().PartOne(_input));
        }

        [Fact]
        public void PartTwo()
        {
            Assert.Equal(168, new WhaleTreachery().PartTwo(_input));
        }

        [Theory]
        [InlineData(16, 5, 66)]
        [InlineData(1, 5, 10)]
        [InlineData(2, 5, 6)]
        [InlineData(0, 5, 15)]
        [InlineData(4, 5, 1)]
        [InlineData(7, 5, 3)]
        [InlineData(14, 5, 45)]
        public void Move(int current, int destination, int fuel)
        {
            Assert.Equal(fuel, new WhaleTreachery().Move(current, destination));
        }
    }
}