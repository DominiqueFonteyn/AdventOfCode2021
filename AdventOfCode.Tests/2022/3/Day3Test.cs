using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AdventOfCode.Tests._2022._3
{
    public class Day3Test : TestBase
    {
        public Day3Test() : base(2022, 3)
        {
        }

        [Fact]
        public void Part1_Example()
        {
            var result = Calculate(ExampleData);
            Assert.Equal(157, result);
        }

        [Fact]
        public void Part1_Input()
        {
            var result = Calculate(InputData);
            Assert.Equal(0, result);
        }

        [Fact]
        public void Part2_Example()
        {
            var result = Calculate2(ExampleData);
            Assert.Equal(70, result);
        }

        [Fact]
        public void Part2_Input()
        {
            Assert.Equal(0, Calculate2(InputData));
        }

        private int Calculate(string[] input)
        {
            var result = 0;
            foreach (var line in input)
            {
                var secondPartIndex = line.Length / 2;
                var part1 = line[..secondPartIndex];
                var part2 = line[secondPartIndex..];

                var sharedItem = FindCommonItem(part1, part2);
                var score = ScoreItem(sharedItem);
                result += score;
            }

            return result;
        }

        private int Calculate2(string[] input)
        {
            var groups = new List<List<string>> { new List<string>() };
            for (var i = 0; i < input.Length; i++)
            {
                var line = input[i];
                groups.Last().Add(line);

                if (groups.Last().Count == 3 && i < input.Length - 1)
                {
                    groups.Add(new List<string>());
                }
            }

            return groups
                .Select(x => ScoreItem(FindCommonItem2(x)))
                .Sum();
        }

        private char FindCommonItem(string part1, string part2)
        {
            return (from item in part1
                    where part2.Contains(item, StringComparison.Ordinal)
                    select item)
                .First();
        }

        private char FindCommonItem2(List<string> values)
        {
            for (var c = 'a'; c <= 'z'; c++)
                if (values.All(x => x.Contains(c)))
                {
                    return c;
                }

            for (var c = 'A'; c <= 'Z'; c++)
                if (values.All(x => x.Contains(c)))
                {
                    return c;
                }

            return '0';
        }

        private int ScoreItem(char item)
        {
            var scoring = new Dictionary<char, int>();
            var score = 1;
            score = CalculateItemScoring(scoring, score, 'a', 'z');
            CalculateItemScoring(scoring, score, 'A', 'Z');

            return scoring[item];
        }

        private int CalculateItemScoring(IDictionary<char, int> scoring, int score, char start, char end)
        {
            for (var c = start; c <= end; c++)
                scoring.Add(c, score++);
            return score;
        }
    }
}
