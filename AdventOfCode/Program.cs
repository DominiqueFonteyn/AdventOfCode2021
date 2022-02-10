using System;
using System.IO;
using AdventOfCode.Day3;

namespace AdventOfCode
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(BinaryDiagnostic.PartOne(File.ReadAllLines(args[0])));
            Console.WriteLine(BinaryDiagnostic.PartTwo(File.ReadAllLines(args[0])));

            // var dive = new Dive();
            // Console.WriteLine(dive.PartOne(File.ReadAllLines(args[0])));
            // Console.WriteLine(dive.PartTwo(File.ReadAllLines(args[0])));

            // var input = File.ReadAllLines(args[0]).Select(int.Parse).ToArray();
            // var sonarSweep = new SonarSweep();
            // Console.WriteLine($"Increases: {sonarSweep.CountNumberOfIncreases(input)}");
            // Console.WriteLine($"Increases with 3-window: {sonarSweep.CountNumberOfIncreasesBySlidingWindow(input)}");
        }
    }
}