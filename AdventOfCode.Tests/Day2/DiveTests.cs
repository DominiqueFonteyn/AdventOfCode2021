using AdventOfCode.Day2;
using Xunit;

namespace AdventOfCode.Tests.Day2
{
    public class DiveTests
    {
        private readonly string[] _instructions =
        {
            "forward 5",
            "down 5",
            "forward 8",
            "up 3",
            "down 8",
            "forward 2"
        };

        [Fact]
        public void PartOne()
        {
            Assert.Equal(150, new Dive().PartOne(_instructions));
        }
        
        [Fact]
        public void PartTwo()
        {
            Assert.Equal(900, new Dive().PartTwo(_instructions));
        }
    }
}