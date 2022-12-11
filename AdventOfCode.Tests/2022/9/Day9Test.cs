using System;
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
        protected override int ExpectedResultPart2 { get; }

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
            throw new NotImplementedException();
        }
    }
}
