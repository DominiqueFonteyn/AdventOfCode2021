using AdventOfCode.Day3;
using Xunit;

namespace AdventOfCode.Tests.Day3
{
    public class BinaryDiagnosticTests
    {
        private readonly string[] _input =
        {
            "00100",
            "11110",
            "10110",
            "10111",
            "10101",
            "01111",
            "00111",
            "11100",
            "10000",
            "11001",
            "00010",
            "01010"
        };

        [Fact]
        public void PartOne()
        {
            Assert.Equal(198, new BinaryDiagnostic().PartOne(_input));
        }
    }
}