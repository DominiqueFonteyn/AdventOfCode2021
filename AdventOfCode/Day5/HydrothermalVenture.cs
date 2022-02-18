using System;

namespace AdventOfCode.Day5
{
    public class HydrothermalVenture : Day<int>
    {
        public HydrothermalVenture() : base(5)
        {
        }

        public override int PartOne(string[] input)
        {
            var grid = new Grid(10, 10);

            foreach (var line in input)
            {
                var vector = Vector.FromString(line);
                Console.WriteLine($"Applying {vector}");
                grid.Apply(Vector.FromString(line));
                Console.WriteLine(grid);
                Console.WriteLine();
            }

            return grid.CountOverlaps();
        }

        public override int PartTwo(string[] input)
        {
            throw new NotImplementedException();
        }
    }
}