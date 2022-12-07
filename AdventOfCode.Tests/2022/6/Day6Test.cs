using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AdventOfCode.Tests._2022._6
{
    public class Day6Test : TestBase
    {
        public Day6Test() : base(2022, 6)
        {
        }

        protected override int ExpectedResultPart1 => 7;
        protected override int ExpectedResultPart2 => 19;

        protected override int Calculate(string[] data)
        {
            return DetectStart(data, 4);
        }

        protected override int Calculate2(string[] data)
        {
            return DetectStart(data, 14);
        }

        private static int DetectStart(string[] data, int packetSize)
        {
            var input = data.Single();
            for (var i = 0; i < input.Length - packetSize; i++)
            {
                var fragment = input.Substring(i, packetSize);
                var set = new HashSet<char>(fragment);
                if (set.Count == packetSize)
                {
                    return i + packetSize;
                }
            }

            return 0;
        }

        [Theory]
        [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)]
        [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
        [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 6)]
        [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
        [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
        public void TestCalculate(string input, int expected)
        {
            Assert.Equal(expected, Calculate(new[] { input }));
        }

        [Theory]
        [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
        [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
        [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 23)]
        [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
        [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
        public void TestCalculate2(string input, int expected)
        {
            Assert.Equal(expected, Calculate2(new[] { input }));
        }
    }
}
