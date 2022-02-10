using AdventOfCode.Day2;
using Xunit;

namespace AdventOfCode.Tests.Day2
{
    public class DiveTests
    {
        [Fact]
        public void Run()
        {
            var instructions = new[]
            {
                "forward 5",
                "down 5",
                "forward 8",
                "up 3",
                "down 8",
                "forward 2"
            };
            
            Assert.Equal(150, new Dive().Run(instructions));
        }
    }
}