using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day5
{
    public class HydrothermalVenture : Day<int>
    {
        private readonly List<Vector> _vectors;
        private readonly Grid _grid;

        public HydrothermalVenture(string[] input) : base(5)
        {
            _vectors = new List<Vector>();
            
            var width = 0;
            var height = 0;
            foreach (var line in input)
            {
                var vector = Vector.FromString(line);
                _vectors.Add(vector);

                var w = Math.Max(vector.Start.X, vector.End.X);
                if (width < w)
                    width = w;
                var h = Math.Max(vector.Start.Y, vector.End.Y);
                if (height < h)
                    height = h;
            }

            _grid = new Grid(height + 1, width + 1);
        }

        public override int PartOne(string[] input)
        {
            foreach (var vector in _vectors.Where(vector => vector.Direction != VectorDirection.Diagonal))
            {
                Console.WriteLine($"Applying {vector}");
                _grid.Apply(vector);
            }

            return _grid.CountOverlaps();
        }

        public override int PartTwo(string[] input)
        {
            foreach (var vector in _vectors)
            {
                Console.WriteLine($"Applying {vector}");
                _grid.Apply(vector);
            }

            return _grid.CountOverlaps();
        }
    }
}