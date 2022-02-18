using AdventOfCode.Day6;
using Xunit;

namespace AdventOfCode.Tests.Day6
{
    public class LanternFishTests
    {
        private readonly string[] _input = { "3,4,3,1,2" };

        [Fact]
        public void PartOne()
        {
            Assert.Equal(5934, new LanternFish().PartOne(_input));
        }
    }
}