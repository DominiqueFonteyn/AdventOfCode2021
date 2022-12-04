using System.IO;
using Xunit;

namespace AdventOfCode.Tests
{
    public abstract class TestBase
    {
        private readonly int _year;
        private readonly int _day;
        protected abstract int ExpectedResultPart1 { get; }
        protected abstract int ExpectedResultPart2 { get; }

        protected TestBase(int year, int day)
        {
            _year = year;
            _day = day;
        }
        
        protected string[] ExampleData => File.ReadAllLines($"{_year}/{_day}/example.txt");
        protected string[] InputData => File.ReadAllLines($"{_year}/{_day}/input.txt");
        
        protected abstract int Calculate(string[] data);
        protected abstract int Calculate2(string[] data);
        
        [Fact]
        public void Part1_Example()
        {
            var result = Calculate(ExampleData);
            Assert.Equal(ExpectedResultPart1, result);
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
            Assert.Equal(ExpectedResultPart2, result);
        }

        [Fact]
        public void Part2_Input()
        {
            Assert.Equal(0, Calculate2(InputData));
        }
    }
}