using System.Collections.Generic;
using Xunit.Abstractions;

namespace AdventOfCode.Tests._2022._9
{
    public class Day9Test : TestBase
    {
        private readonly ITestOutputHelper _output;

        public Day9Test(ITestOutputHelper output) : base(2022, 9)
        {
            _output = output;
        }

        protected override int ExpectedResultPart1 => 13;
        protected override int ExpectedResultPart2 => 36;

        protected override string[] ExampleData(int part)
        {
            if (part == 1)
            {
                return base.ExampleData(part);
            }

            return new[]
            {
                "R 5",
                "U 8",
                "L 8",
                "D 3",
                "R 17",
                "D 10",
                "L 25",
                "U 20"
            };
        }

        protected override int Calculate(string[] data)
        {
            return Count(data, 2);
        }

        protected override int Calculate2(string[] data)
        {
            return Count(data, 10);
        }

        private int Count(IEnumerable<string> data, int numberOfKnots)
        {
            var knots = InitKnots(numberOfKnots);
            var visited = new HashSet<Position> { new Position(1, 1) };
            var step = 0;

            var head = knots[0];
            var tail = knots[^1];
            foreach (var line in data)
            {
                var motion = new Motion(line);
                _output.WriteLine(line);

                for (var i = 0; i < motion.Steps; i++)
                {
                    head.StepTo(motion.Direction);

                    for (var knotIndex = 1; knotIndex < knots.Length; knotIndex++)
                    {
                        if (!knots[knotIndex].Touches(knots[knotIndex - 1]))
                        {
                            knots[knotIndex].MoveTowards(knots[knotIndex - 1]);
                        }
                    }
                    
                    visited.Add(tail);

                    _output.WriteLine($"step {++step}: head {head} - tail {tail}");
                }
            }

            return visited.Count;
        }

        private static Position[] InitKnots(int numberOfKnots)
        {
            var knots = new Position[numberOfKnots];
            for (var i = 0; i < knots.Length; i++) knots[i] = new Position(1, 1);
            return knots;
        }
    }
}
