using System.Linq;
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

        [Fact]
        public void PartTwo()
        {
            Assert.Equal(26984457539, new LanternFish().PartTwo(_input));
        }

        [Theory]
        [InlineData(0, 5)]
        [InlineData(1, 5)]
        [InlineData(2, 6)]
        [InlineData(3, 7)]
        [InlineData(10, 12)]
        [InlineData(20, 34)]
        [InlineData(80, 5934)]
        public void SimulateSpawn(int numberOfDays, int expectedCount)
        {
            var fish = _input[0].Split(',').Select(int.Parse).ToArray();
            Assert.Equal(expectedCount, new LanternFish().SimulateSpawn(fish, numberOfDays));
        }
    }
}