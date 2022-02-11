using System.Linq;

namespace AdventOfCode.Day1
{
    public class SonarSweep : Day<int>
    {
        public SonarSweep() : base(1)
        {
        }

        public int PartOne(int[] measurements)
        {
            var increases = 0;

            for (var i = 1; i < measurements.Length; i++)
                if (measurements[i] > measurements[i - 1])
                    increases++;

            return increases;
        }

        public int PartTwo(int[] measurements)
        {
            var increases = 0;
            var windowSize = 3;

            for (var i = 3; i < measurements.Length; i++)
                if (SumOfWindow(measurements, i, windowSize) > SumOfWindow(measurements, i - 1, windowSize))
                    increases++;

            return increases;
        }

        private int SumOfWindow(int[] measurements, int start, int windowSize)
        {
            var sum = 0;
            for (var i = 0; i < windowSize; i++)
                sum += measurements[start - i];
            return sum;
        }

        public override int PartOne(string[] input)
        {
            return PartOne(input.Select(int.Parse).ToArray());
        }

        public override int PartTwo(string[] input)
        {
            return PartTwo(input.Select(int.Parse).ToArray());
        }
    }
}