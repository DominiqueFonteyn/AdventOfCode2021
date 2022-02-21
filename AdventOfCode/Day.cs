using System.Linq;

namespace AdventOfCode
{
    public abstract class Day<T> : IDay<T>
    {
        protected Day(int day)
        {
            DayNr = day;
        }

        public int DayNr { get; }
        public abstract T PartOne(string[] input);
        public abstract T PartTwo(string[] input);

        protected static int[] ParseToIntArray(string[] input)
        {
            return input[0].Split(',').Select(int.Parse).ToArray();
        }
    }
}