using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day5
{
    public class HydrothermalVenture : Day<int>
    {
        public HydrothermalVenture() : base(5)
        {
        }

        public override int PartOne(string[] input)
        {
            var vectors = new List<Vector>();
            var width = 0;
            var height = 0;
            foreach (var line in input)
            {
                var vector = Vector.FromString(line);
                vectors.Add(vector);

                var w = Math.Max(vector.Start.X, vector.End.X);
                if (width < w)
                    width = w;
                var h = Math.Max(vector.Start.Y, vector.End.Y);
                if (height < h)
                    height = h;
            }

            var grid = new Grid(height + 1, width + 1);

            foreach (var vector in vectors.Where(vector => vector.Direction != VectorDirection.Other))
            {
                Console.WriteLine($"Applying {vector}");
                grid.Apply(vector);
            }

            return grid.CountOverlaps();
        }

        public override int PartTwo(string[] input)
        {
            throw new NotImplementedException();
        }
    }
}