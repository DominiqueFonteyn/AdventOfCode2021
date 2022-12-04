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
            var firstGroup = new List<string>();
            var secondGroup = new List<string>();

            var count = 0;
            foreach (var line in input)
            {
                if (count < input.Length / 2)
                {
                    firstGroup.Add(line);
                }
                else
                {
                    secondGroup.Add(line);
                }
                count++;
            }

            var item1 = FindCommonItem2(firstGroup);
            var item2 = FindCommonItem2(secondGroup);
            return ScoreItem(item1) + ScoreItem(item2);
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
            var exclude = new HashSet<char>();
            
            var result = '0';
            foreach (var item in values.First())
            {
                if (exclude.Contains(item)) continue;

                result = item;
                foreach (var str in values)
                    if (!str.Contains(item, StringComparison.Ordinal))
                    {
                        result = '0';
                        break;
                    }
                if (result == item) return item;

                exclude.Add(item);
            }

            return result;
        }

        private int ScoreItem(char item)
        {
            var scoring = new Dictionary<char, int>();
            var score = 1;
            score = CalculateItemScoring(scoring, score, 'a', 'z');
            score = CalculateItemScoring(scoring, score, 'A', 'Z');

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
