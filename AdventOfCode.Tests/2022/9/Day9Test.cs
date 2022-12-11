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
            var head = new Position(1, 1);
            var tail = new Position(1, 1);
            var visited = new HashSet<Position> { new Position(1, 1) };
            var step = 0;

            foreach (var line in data)
            {
                var motion = new Motion(line);
                _output.WriteLine(line);

                for (var i = 0; i < motion.Steps; i++)
                {
                    head.StepTo(motion.Direction);

                    if (!tail.Touches(head))
                    {
                        tail.MoveTowards(head);
                        visited.Add(tail);
                    }

                    _output.WriteLine($"step {++step}: head {head} - tail {tail}");
                }
            }

            return visited.Count;
        }

        protected override int Calculate2(string[] data)
        {
            var knots = new Position[10];
            for (var i = 0; i < knots.Length; i++) knots[i] = new Position(1, 1);

            var visited = new HashSet<Position> { new Position(1, 1) };
            var step = 0;

            foreach (var line in data)
            {
                var motion = new Motion(line);
                _output.WriteLine(line);

                for (var i = 0; i < motion.Steps; i++)
                {
                    knots[0].StepTo(motion.Direction);

                    for (var knotIndex = 1; knotIndex < knots.Length; knotIndex++)
                        if (!knots[knotIndex].Touches(knots[knotIndex - 1]))
                        {
                            knots[knotIndex].MoveTowards(knots[knotIndex - 1]);
                        }

                    visited.Add(knots[^1]);

                    _output.WriteLine($"step {++step}: head {knots[0]} - tail {knots[^1]}");
                }
            }

            return visited.Count;
        }
    }
}
