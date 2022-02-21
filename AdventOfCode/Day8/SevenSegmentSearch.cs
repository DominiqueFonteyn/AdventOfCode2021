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
            
            
            
            return 0;
        }

        public override int PartTwo(string[] input)
        {
            throw new NotImplementedException();
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