using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace AdventOfCode.Tests._2022._1
{
    public class CalorieCountingTest
    {
        [Fact]
        public void Part1_Example()
        {
            var mostCalories = new CalorieCounting().FindMostCalories(File.ReadAllLines("2022/1/example.txt"));
            Assert.Equal(24000, mostCalories);
        }

        [Fact]
        public void Part1_Input()
        {
            var input = File.ReadAllLines("2022/1/input.txt");
            Assert.Equal(0, new CalorieCounting().FindMostCalories(input));
        }

        [Fact]
        public void Part2_Example()
        {
            var mostCalories = new CalorieCounting().FindMostCalories(File.ReadAllLines("2022/1/example.txt"));
            Assert.Equal(45000, mostCalories);
        }

        [Fact]
        public void Part2_Input()
        {
            var input = File.ReadAllLines("2022/1/input.txt");
            Assert.Equal(0, new CalorieCounting().FindMostCalories(input));
        }
    }

    public class CalorieCounting
    {
        public int FindMostCalories(string[] input)
        {
            var calories = new List<int> { 0 };

            foreach (var value in input)
            {
                if (string.IsNullOrEmpty(value))
                {
                    calories.Add(0);
                    continue;
                }

                calories[^1] += int.Parse(value);
            }

            return calories
                .OrderByDescending(x => x)
                .Take(3)
                .Sum(x => x);
        }
    }
}
