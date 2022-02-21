namespace AdventOfCode
{
    public interface IDay<out T>
    {
        int DayNr { get; }
        T PartOne(string[] input);
        T PartTwo(string[] input);
    }
}