using AdventOfCode.Day5;
using Xunit;

namespace AdventOfCode.Tests.Day5
{
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
}