using AdventOfCode.Day9;
using Xunit;

namespace AdventOfCode.Tests.Day9
{
    public class SmokeBasinTests
    {
        private readonly string[] _input =
        {
            "2199943210",
            "3987894921",
            "9856789892",
            "8767896789",
            "9899965678"
        };

        [Fact]
        public void PartOne()
        {
            Assert.Equal(15, new SmokeBasin().PartOne(_input));
        }
    }
}