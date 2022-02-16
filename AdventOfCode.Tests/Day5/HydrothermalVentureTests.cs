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
        private const int X1 = 0;
        private const int Y1 = 9;
        private const int X2 = 5;
        private const int Y2 = 8;
        private const string VectorStr = "0,9 -> 5,8";

        [Fact]
        public void Ctor()
        {
            var vector = new Vector(new Coordinate(X1, Y1), new Coordinate(X2, Y2));
            
            Assert.Equal(X1, vector.Start.X);
            Assert.Equal(Y1, vector.Start.Y);
            Assert.Equal(X2, vector.End.X);
            Assert.Equal(Y2, vector.End.Y);
        }

        [Fact]
        public void OverridesToString()
        {
            var vector = new Vector(new Coordinate(X1, Y1), new Coordinate(X2, Y2));
            
            Assert.Equal(VectorStr, vector.ToString());
        }

        [Fact]
        public void InitializeFromString()
        {
            var vector = Vector.FromString(VectorStr);
            
            Assert.Equal(VectorStr, vector.ToString());
        }
    }

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
            Assert.Equal(CoordinateStr, new Coordinate(X,Y).ToString());
        }

        [Fact]
        public void InitializeFromString()
        {
            var coordinate = Coordinate.FromString(CoordinateStr);
            
            Assert.Equal(CoordinateStr, coordinate.ToString());
        }
    }
}