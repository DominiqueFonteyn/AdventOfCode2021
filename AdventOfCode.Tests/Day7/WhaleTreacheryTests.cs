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
    }
}