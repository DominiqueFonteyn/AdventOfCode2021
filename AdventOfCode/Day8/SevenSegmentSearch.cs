using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day8
{
    public class SevenSegmentSearch : Day<int>
    {
        public SevenSegmentSearch() : base(8)
        {
        }

        public override int PartOne(string[] input)
        {
            var notes = NotesParser.Parse(input);

            var mapping = new Dictionary<int, char[]>
            {
                { 0, "abcefg".ToCharArray() },
                { 1, "cf".ToCharArray() },
                { 2, "acdeg".ToCharArray() },
                { 3, "acdfg".ToCharArray() },
                { 4, "bcdf".ToCharArray() },
                { 5, "abdfg".ToCharArray() },
                { 6, "abdefg".ToCharArray() },
                { 7, "acf".ToCharArray() },
                { 8, "abcdefg".ToCharArray() },
                { 9, "abcdfg".ToCharArray() }
            };

            var outcome = 0;
            foreach (var note in notes)
            foreach (var output in note.Outputs)
            {
                var digit = DetermineDigit(output);
                if (digit > -1)
                {
                    outcome++;
                    Console.WriteLine($"{output} = {digit}; {outcome}");
                }
            }

            return outcome;
        }

        private int DetermineDigit(string value)
        {
            return value.Length switch
            {
                2 => 1,
                3 => 7,
                4 => 4,
                7 => 8,
                _ => -1
            };
        }

        public override int PartTwo(string[] input)
        {
            return 0;
        }
    }

    public static class NotesParser
    {
        public static IEnumerable<Note> Parse(string[] input)
        {
            return input
                .Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                .Select(split => new Note(
                    split.Take(10).ToArray(),
                    split.Skip(11).Take(4).ToArray()));
        }
    }

    public class Note
    {
        public Note(string[] signals, string[] outputs)
        {
            Signals = signals;
            Outputs = outputs;
        }

        public string[] Signals { get; }
        public string[] Outputs { get; }
    }
}