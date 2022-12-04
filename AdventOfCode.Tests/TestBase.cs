using System.IO;

namespace AdventOfCode.Tests
{
    public abstract class TestBase
    {
        private readonly int _year;
        private readonly int _day;

        protected TestBase(int year, int day)
        {
            _year = year;
            _day = day;
        }
        
        protected string[] ExampleData => File.ReadAllLines($"{_year}/{_day}/example.txt");
        protected string[] InputData => File.ReadAllLines($"{_year}/{_day}/input.txt");
    }
}