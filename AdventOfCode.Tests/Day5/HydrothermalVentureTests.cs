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
        [Fact]
        public void InitializeGrid()
        {
            var grid = new Grid(10, 5);

            Assert.Equal(10, grid.Height);
            Assert.Equal(5, grid.Width);
        }

        [Fact]
        public void InitialGridIsEmpty()
        {
            var grid = new Grid(10, 10);

            for (var x = 0; x < 10; x++)
            for (var y = 0; y < 10; y++)
                Assert.Equal(0, grid.ValueAt(new Coordinate(x, y)));
        }

        [Fact]
        public void ApplySingleHorizontalVector()
        {
            var grid = new Grid(10, 10);

            grid.Apply(Vector.FromString("1,0 -> 3,0"));

            Assert.Equal(0, grid.ValueAt(new Coordinate(0, 0)));
            Assert.Equal(1, grid.ValueAt(new Coordinate(1, 0)));
            Assert.Equal(1, grid.ValueAt(new Coordinate(2, 0)));
            Assert.Equal(1, grid.ValueAt(new Coordinate(3, 0)));
            Assert.Equal(0, grid.ValueAt(new Coordinate(4, 0)));
        }
        
        [Fact]
        public void ApplySingleVerticalVector()
        {
            var grid = new Grid(10, 10);

            grid.Apply(Vector.FromString("0,1 -> 0,3"));

            Assert.Equal(0, grid.ValueAt(new Coordinate(0, 0)));
            Assert.Equal(1, grid.ValueAt(new Coordinate(0, 1)));
            Assert.Equal(1, grid.ValueAt(new Coordinate(0, 2)));
            Assert.Equal(1, grid.ValueAt(new Coordinate(0, 3)));
            Assert.Equal(0, grid.ValueAt(new Coordinate(0, 4)));
        }
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

        [Fact]
        public void ProjectVertical()
        {
            var vector = Vector.FromString("0,0 -> 0,2");
            
            Assert.Collection(vector.Project(),
                coordinate => Assert.Equal("0,0", coordinate.ToString()),
                coordinate => Assert.Equal("0,1", coordinate.ToString()),
                coordinate => Assert.Equal("0,2", coordinate.ToString()));
        }

        [Fact]
        public void ProjectHorizontal()
        {
            var vector = Vector.FromString("0,0 -> 2,0");
            
            Assert.Collection(vector.Project(),
                coordinate => Assert.Equal("0,0", coordinate.ToString()),
                coordinate => Assert.Equal("1,0", coordinate.ToString()),
                coordinate => Assert.Equal("2,0", coordinate.ToString()));
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