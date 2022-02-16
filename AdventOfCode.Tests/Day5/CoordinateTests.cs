using AdventOfCode.Day5;
using Xunit;

namespace AdventOfCode.Tests.Day5
{
    public class CoordinateTests
    {
        private const int Y = 9;
        private const int X = 5;
        private const string CoordinateStr = "5,9";

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
            Assert.Equal(CoordinateStr, new Coordinate(X, Y).ToString());
        }

        [Fact]
        public void InitializeFromString()
        {
            var coordinate = Coordinate.FromString(CoordinateStr);

            Assert.Equal(CoordinateStr, coordinate.ToString());
        }
    }
}