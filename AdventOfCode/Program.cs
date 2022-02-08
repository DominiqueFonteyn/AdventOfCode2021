using System;
using System.IO;
using System.Linq;
using AdventOfCode.Day1;

namespace AdventOfCode
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var input = File.ReadAllLines(args[0]).Select(int.Parse).ToArray();
            var sonarSweep = new SonarSweep();
            Console.WriteLine($"Increases: {sonarSweep.CountNumberOfIncreases(input)}");
            Console.WriteLine($"Increases with 3-window: {sonarSweep.CountNumberOfIncreasesBySlidingWindow(input)}");
        }
    }
}