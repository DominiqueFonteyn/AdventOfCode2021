namespace AdventOfCode.Day5
{
    public class Grid
    {
        private readonly int[,] _grid;

        public Grid(int height, int width)
        {
            Width = width;
            Height = height;

            _grid = new int[height, width];
        }

        public int Height { get; }
        public int Width { get; }

        public void Apply(Vector vector)
        {
            foreach (var coordinate in vector.Project())
                _grid[coordinate.Y, coordinate.X] += 1;
        }

        public int ValueAt(Coordinate position)
        {
            return _grid[position.Y, position.X];
        }

        public int CountOverlaps()
        {
            var count = 0;
            for (var i = 0; i < Height; i++)
            for (var j = 0; j < Width; j++)
                if (_grid[i, j] >= 2)
                    count++;

            return count;
        }
    }
}