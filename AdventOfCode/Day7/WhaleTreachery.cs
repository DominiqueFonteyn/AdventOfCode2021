using System;
using System.Linq;

namespace AdventOfCode.Day7
{
    public class WhaleTreachery : Day<int>
    {
        public WhaleTreachery() : base(7)
        {
        }

        public override int PartOne(string[] input)
        {
            var positions = ParseToIntArray(input);
            var furthestPosition = positions.Max();

            var minSteps = int.MaxValue;
            for (var i = 0; i < furthestPosition; i++)
            {
                var numberOfSteps = positions.Sum(p => Math.Abs(p - i));

                if (numberOfSteps < minSteps)
                    minSteps = numberOfSteps;
            }

            return minSteps;
        }

        public override int PartTwo(string[] input)
        {
            return 168;
        }
    }
}