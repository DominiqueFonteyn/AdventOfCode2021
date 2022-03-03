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

            return notes.Sum(note =>
                note.Outputs.Select(DetermineDigit)
                    .Count(digit =>
                        new[] { 1, 4, 7, 8 }.Contains(digit)));
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

        public Dictionary<int, string> Map(string[] patterns)
        {
            var mapping = new Dictionary<int, string>
            {
                { 1, patterns.Single(x => x.Length == 2) },
                { 7, patterns.Single(x => x.Length == 3) },
                { 4, patterns.Single(x => x.Length == 4) },
                { 8, patterns.Single(x => x.Length == 7) }
            };

            var length5 = patterns.Where(x => x.Length == 5).ToHashSet();
            var length6 = patterns.Where(x => x.Length == 6).ToHashSet();

            // find 3
            mapping.Add(3, length5.Single(x => !mapping[1].ToCharArray().Except(x.ToCharArray()).Any()));
            length5.Remove(mapping[3]);

            // find 6
            mapping.Add(6, length6.Single(x => mapping[1].ToCharArray().Except(x.ToCharArray()).Count() == 1));
            length6.Remove(mapping[6]);

            // find 9
            var _4_7 = mapping[4].ToCharArray().Union(mapping[7].ToCharArray()).ToArray();
            mapping.Add(9, length6.Single(x => x.ToCharArray().Intersect(_4_7).Count() == _4_7.Count()));
            length6.Remove(mapping[9]);

            // find 0
            mapping.Add(0, length6.Single());

            // find 5
            mapping.Add(5, length5.Single(x => mapping[9].ToCharArray().Except(x.ToCharArray()).Count() == 1));
            length5.Remove(mapping[5]);

            // find 2
            mapping.Add(2, length5.Single());
            
            return mapping;
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