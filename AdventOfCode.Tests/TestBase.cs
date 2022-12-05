using System.IO;
using Xunit;

namespace AdventOfCode.Tests
{
    public abstract class TestBase<T>
    {
        private readonly int _day;

        private readonly int _year;

        protected TestBase(int year, int day)
        {
            _year = year;
            _day = day;
        }

        protected abstract T ExpectedResultPart1 { get; }
        protected abstract T ExpectedResultPart2 { get; }

        protected string[] ExampleData => File.ReadAllLines($"{_year}/{_day}/example.txt");
        protected string[] InputData => File.ReadAllLines($"{_year}/{_day}/input.txt");

        protected abstract T Calculate(string[] data);
        protected abstract T Calculate2(string[] data);

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
            Assert.Equal(default, result);
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
            Assert.Equal(default, Calculate2(InputData));
        }
    }

    public abstract class TestBase : TestBase<int>
    {
        protected TestBase(int year, int day) : base(year, day)
        {
        }
    }
}
