using System;
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
        protected override int ExpectedResultPart2 { get; }

        protected override int Calculate(string[] data)
        {
            var input = data.Single();
            for (var i = 0; i < input.Length - 4; i++)
            {
                var fragment = input.Substring(i, 4);
                var set = new HashSet<char>(fragment);
                if (set.Count == 4)
                {
                    return i + 4;
                }
            }

            return 0;
        }

        protected override int Calculate2(string[] data)
        {
            throw new NotImplementedException();
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
    }
}
