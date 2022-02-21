using System;
using System.IO;
using AdventOfCode.Day8;

namespace AdventOfCode
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var file = args[0];
            var lines = File.ReadAllLines(file);

            Console.WriteLine(new SevenSegmentSearch().PartOne(lines));
            Console.WriteLine(new SevenSegmentSearch().PartTwo(lines));

            return;

            // if (!args.Any())
            // {
            //     Console.WriteLine("Please provide the directory of the input files as the first argument");
            //     return;
            // }
            //
            // var inputFolder = args[0];
            // if (!Directory.Exists(inputFolder)) Console.WriteLine($"{inputFolder} should point to a directory!");
        }
    }
}