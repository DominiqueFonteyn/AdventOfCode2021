namespace AdventOfCode.Tests._2022._8
{
    public class Day8Test : TestBase
    {
        public Day8Test() : base(2022, 8)
        {
        }

        protected override int ExpectedResultPart1 => 21;
        protected override int ExpectedResultPart2 => 8;

        protected override int Calculate(string[] data)
        {
            var rows = data.Length;
            var cols = data[0].Length;
            var grid = InitGrid(data, rows, cols);

            var visibleTrees = 0;
            for (var row = 0; row < rows; row++)
            for (var col = 0; col < cols; col++)
            {
                if (IsEdge(row, rows, col, cols))
                {
                    visibleTrees++;
                    continue;
                }

                var left = true;
                for (var i = col - 1; i >= 0 && left; i--) left &= grid[row, i] < grid[row, col];
                if (left)
                {
                    visibleTrees++;
                    continue;
                }

                var right = true;
                for (var i = col + 1; i < cols && right; i++) right &= grid[row, i] < grid[row, col];
                if (right)
                {
                    visibleTrees++;
                    continue;
                }
                
                var top = true;
                for (var i = row - 1; i >= 0 && top; i--) top &= grid[i, col] < grid[row, col];
                if (top)
                {
                    visibleTrees++;
                    continue;
                }
                
                var bottom = true;
                for (var i = row + 1; i < rows && bottom; i++) bottom &= grid[i, col] < grid[row, col];
                if (bottom)
                {
                    visibleTrees++;
                    continue;
                }
            }

            return visibleTrees;
        }

        private static bool IsEdge(int row, int rows, int col, int cols)
        {
            return row == 0 || row == rows - 1 || col == 0 || col == cols - 1;
        }

        private int[,] InitGrid(string[] data, int rows, int cols)
        {
            var grid = new int[rows, cols];

            for (var row = 0; row < rows; row++)
            for (var col = 0; col < cols; col++)
                grid[row, col] = int.Parse($"{data[row][col]}");

            return grid;
        }

        protected override int Calculate2(string[] data)
        {
            var rows = data.Length;
            var cols = data[0].Length;
            var grid = InitGrid(data, rows, cols);

            var highestScenicScore = 0;

            var visibleTrees = 0;
            for (var row = 0; row < rows; row++)
            for (var col = 0; col < cols; col++)
            {
                if (IsEdge(row, rows, col, cols))
                {
                    visibleTrees++;
                    continue;
                }

                var left = true;
                var viewingDistanceLeft = 0;
                for (var i = col - 1; i >= 0 && left; i--)
                {
                    viewingDistanceLeft++;
                    left &= grid[row, i] < grid[row, col];
                }

                var right = true;
                var viewingDistanceRight = 0;
                for (var i = col + 1; i < cols && right; i++)
                {
                    viewingDistanceRight++;
                    right &= grid[row, i] < grid[row, col];
                }

                var up = true;
                var viewingDistanceUp = 0;
                for (var i = row - 1; i >= 0 && up; i--)
                {
                    viewingDistanceUp++;
                    up &= grid[i, col] < grid[row, col];
                }

                var down = true;
                var viewingDistanceDown = 0;
                for (var i = row + 1; i < rows && down; i++)
                {
                    viewingDistanceDown++;
                    down &= grid[i, col] < grid[row, col];
                }

                var scenicScore = viewingDistanceLeft * viewingDistanceRight * viewingDistanceUp * viewingDistanceDown;

                if (scenicScore > highestScenicScore)
                    highestScenicScore = scenicScore;
            }

            return highestScenicScore;;
        }
    }
}
