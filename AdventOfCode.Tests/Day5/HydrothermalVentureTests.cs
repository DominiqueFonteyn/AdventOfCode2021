using AdventOfCode.Day5;
using Xunit;

namespace AdventOfCode.Tests.Day5
{
    public class HydrothermalVentureTests
    {
        private readonly string[] _input =
        {
            "0,9 -> 5,9",
            "8,0 -> 0,8",
            "9,4 -> 3,4",
            "2,2 -> 2,1",
            "7,0 -> 7,4",
            "6,4 -> 2,0",
            "0,9 -> 2,9",
            "3,4 -> 1,4",
            "0,0 -> 8,8",
            "5,5 -> 8,2"
        };

        [Fact]
        public void PartOne()
        {
            Assert.Equal(5, new HydrothermalVenture().PartOne(_input));
        }
    }

    public class GridTests
    {
    }

    public class VectorTests
    {
    }

    public class CoordinateTests
    {
        private const int Y = 9;
        private const int X = 5;

        [Fact]
        public void CtorSetsX()
        {
            Assert.Equal(X, new Coordinate(X, Y).X);
        }

        [Fact]
        public void CtorSetsY()
        {
            Assert.Equal(Y, new Coordinate(X, Y).Y);
        }

        [Fact]
        public void OverridesToString()
        {
            Assert.Equal("5,9", new Coordinate(X,Y).ToString());
        }
    }
}