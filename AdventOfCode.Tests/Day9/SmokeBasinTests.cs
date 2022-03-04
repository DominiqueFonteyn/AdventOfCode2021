using System.Collections.Generic;
using System.Linq;
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

        private readonly SmokeBasin _smokeBasin;

        public SmokeBasinTests()
        {
            _smokeBasin = new SmokeBasin();
        }

        [Fact]
        public void PartOne()
        {
            Assert.Equal(15, _smokeBasin.PartOne(_input));
        }

        [Fact]
        public void PartOne_OtherSample()
        {
            string[] input =
            {
                "111110"
            };

            Assert.Equal(1, _smokeBasin.PartOne(input));
        }

        [Fact]
        public void PartTwo()
        {
            Assert.Equal(1134, _smokeBasin.PartTwo(_input));
        }

        [Fact]
        public void MapToGrid()
        {
            var grid = _smokeBasin.MapToGrid(_input);

            Assert.Equal(5, grid.GetLength(0));
            Assert.Equal(10, grid.GetLength(1));

            Assert.Equal(2, grid[0, 0]);
            Assert.Equal(6, grid[2, 3]);
        }

        [Fact]
        public void FindLowPoints()
        {
            var grid = _smokeBasin.MapToGrid(_input);

            var lowPoints = _smokeBasin.FindLowPoints(grid).ToArray();

            Assert.Equal(4, lowPoints.Length);
            Assert.Contains(new Point(0, 9, 0), lowPoints);
            Assert.Contains(new Point(0, 1, 1), lowPoints);
            Assert.Contains(new Point(2, 2, 5), lowPoints);
            Assert.Contains(new Point(4, 6, 5), lowPoints);
        }

        [Fact]
        public void RiskLevel()
        {
            Assert.Equal(2, _smokeBasin.RiskLevel(new Point(0, 0, 1)));
        }

        [Theory]
        [MemberData(nameof(FindBasinsTestData))]
        public void FindBasins(string[] input, IEnumerable<int> expectedBasin)
        {
            var grid = _smokeBasin.MapToGrid(input);
            var lowPoints = _smokeBasin.FindLowPoints(grid);

            var basins = _smokeBasin.FindBasins(lowPoints, grid);

            var basin = Assert.Single(basins);
            Assert.True(basin.OrderBy(x => x).SequenceEqual(expectedBasin.OrderBy(x => x)));
        }

        public static IEnumerable<object[]> FindBasinsTestData()
        {
            return new[]
            {
                new object[] { new[] { "910" }, new[] { 0, 1 } },
                new object[] { new[] { "9210" }, new[] { 0, 1, 2 } },
                new object[] { new[] { "943210" }, new[] { 0, 1, 2, 3, 4 } },
                new object[] { new[] { "910", "923" }, new[] { 0, 1, 2, 3 } },
                new object[] { new[] { "987" }, new[] { 7, 8 } }
            };
        }
    }
}