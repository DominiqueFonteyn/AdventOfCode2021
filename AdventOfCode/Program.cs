using System;
using System.IO;
using System.Linq;
using AdventOfCode.Day4;

namespace AdventOfCode
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var file = args[0];
            
            Console.WriteLine(new GiantSquid().PartOne(File.ReadAllLines(file)));
            Console.WriteLine();
            Console.WriteLine(new GiantSquid().PartTwo(File.ReadAllLines(file)));
            
            if (!args.Any())
            {
                Console.WriteLine("Please provide the directory of the input files as the first argument");
                return;
            }

            var inputFolder = args[0];
            if (!Directory.Exists(inputFolder))
            {
                Console.WriteLine($"{inputFolder} should point to a directory!");
            }


            // Console.WriteLine(BinaryDiagnostic.PartOne(File.ReadAllLines(args[0])));
            // Console.WriteLine(BinaryDiagnostic.PartTwo(File.ReadAllLines(args[0])));

            // var dive = new Dive();
            // Console.WriteLine(dive.PartOne(File.ReadAllLines(args[0])));
            // Console.WriteLine(dive.PartTwo(File.ReadAllLines(args[0])));

            // var input = File.ReadAllLines(args[0]).Select(int.Parse).ToArray();
            // var sonarSweep = new SonarSweep();
            // Console.WriteLine($"Increases: {sonarSweep.CountNumberOfIncreases(input)}");
            // Console.WriteLine($"Increases with 3-window: {sonarSweep.CountNumberOfIncreasesBySlidingWindow(input)}");
        }
    }

    
    public interface IDay<out T>
    {
        int DayNr { get; }
        T PartOne(string[] input);
        T PartTwo(string[] input);
    }

    public abstract class Day<T> : IDay<T>
    {
        protected Day(int day)
        {
            DayNr = day;
        }

        public int DayNr { get; }
        public abstract T PartOne(string[] input);
        public abstract T PartTwo(string[] input);
    }
}