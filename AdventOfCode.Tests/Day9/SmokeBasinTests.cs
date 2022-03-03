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

        [Fact]
        public void MapToGrid()
        {
            var grid = new SmokeBasin().MapToGrid(_input);

            Assert.Equal(5, grid.GetLength(0));
            Assert.Equal(10, grid.GetLength(1));
            
            Assert.Equal(2, grid[0,0]);
            Assert.Equal(6, grid[2,3]);
        }
        
        
    }
}