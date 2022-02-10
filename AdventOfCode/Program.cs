using System;
using System.IO;
using System.Linq;
using AdventOfCode.Day1;
using AdventOfCode.Day2;

namespace AdventOfCode
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var dive = new Dive();
            Console.WriteLine(dive.PartOne(File.ReadAllLines(args[0])));
            Console.WriteLine(dive.PartTwo(File.ReadAllLines(args[0])));

            return;
            var input = File.ReadAllLines(args[0]).Select(int.Parse).ToArray();
            var sonarSweep = new SonarSweep();
            Console.WriteLine($"Increases: {sonarSweep.CountNumberOfIncreases(input)}");
            Console.WriteLine($"Increases with 3-window: {sonarSweep.CountNumberOfIncreasesBySlidingWindow(input)}");
        }
    }
}