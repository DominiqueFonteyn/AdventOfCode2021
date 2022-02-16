using AdventOfCode.Day5;
using Xunit;

namespace AdventOfCode.Tests.Day5
{
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

        [Fact]
        public void ApplyOverlappingHorizontalVectors()
        {
            var grid = new Grid(10, 10);

            grid.Apply(Vector.FromString("1,0 -> 3,0"));
            grid.Apply(Vector.FromString("2,0 -> 4,0"));

            Assert.Equal(1, grid.ValueAt(new Coordinate(1, 0)));
            Assert.Equal(2, grid.ValueAt(new Coordinate(2, 0)));
            Assert.Equal(2, grid.ValueAt(new Coordinate(3, 0)));
            Assert.Equal(1, grid.ValueAt(new Coordinate(4, 0)));
        }

        [Fact]
        public void ApplyOverlappingVerticalVectors()
        {
            var grid = new Grid(10, 10);

            grid.Apply(Vector.FromString("0,1 -> 0,3"));
            grid.Apply(Vector.FromString("0,2 -> 0,4"));

            Assert.Equal(1, grid.ValueAt(new Coordinate(0, 1)));
            Assert.Equal(2, grid.ValueAt(new Coordinate(0, 2)));
            Assert.Equal(2, grid.ValueAt(new Coordinate(0, 3)));
            Assert.Equal(1, grid.ValueAt(new Coordinate(0, 4)));
        }

        [Fact]
        public void ApplyIntersectingVectors()
        {
            var grid = new Grid(10, 10);

            grid.Apply(Vector.FromString("2,4 -> 6,4"));
            grid.Apply(Vector.FromString("3,1 -> 3,8"));

            Assert.Equal(2, grid.ValueAt(new Coordinate(3, 4)));
        }

        [Fact]
        public void CountOverlaps()
        {
            var grid = new Grid(10, 10);

            grid.Apply(Vector.FromString("0,1 -> 0,3"));
            grid.Apply(Vector.FromString("0,2 -> 0,4"));
            grid.Apply(Vector.FromString("2,4 -> 6,4"));
            grid.Apply(Vector.FromString("3,1 -> 3,8"));

            Assert.Equal(3, grid.CountOverlaps());
        }
    }
}