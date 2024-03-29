﻿using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Day8;
using Xunit;

namespace AdventOfCode.Tests.Day8
{
    public class SevenSegmentSearchTests
    {
        private readonly string[] _input =
        {
            "be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe",
            "edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc",
            "fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg",
            "fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb",
            "aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea",
            "fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb",
            "dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe",
            "bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef",
            "egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb",
            "gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce"
        };

        [Fact]
        public void PartOne()
        {
            Assert.Equal(26, new SevenSegmentSearch().PartOne(_input));
        }

        [Fact]
        public void PartTwo()
        {
            Assert.Equal(61229, new SevenSegmentSearch().PartTwo(_input));
        }

        [Fact]
        public void Map()
        {
            var patterns = new[]
            {
                "acedgfb", "cdfbe", "gcdfa", "fbcad", "dab", 
                "cefabd", "cdfgeb", "eafb", "cagedb", "ab"
            };

            var mapping = new SevenSegmentSearch().Map(patterns);
            
            Assert.Equal(10, mapping.Keys.Count);
            Assert.Equal("cagedb", mapping[0]);
            Assert.Equal("ab", mapping[1]);
            Assert.Equal("gcdfa", mapping[2]);
            Assert.Equal("fbcad", mapping[3]);
            Assert.Equal("eafb", mapping[4]);
            Assert.Equal("cdfbe", mapping[5]);
            Assert.Equal("cdfgeb", mapping[6]);
            Assert.Equal("dab", mapping[7]);
            Assert.Equal("acedgfb", mapping[8]);
            Assert.Equal("cefabd", mapping[9]);
        }
    }

    public class NotesParserTests
    {
        private readonly string[] _input =
        {
            "be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe",
            "edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc",
            "fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg",
            "fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb",
            "aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea",
            "fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb",
            "dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfev",
            "bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef",
            "egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb",
            "gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce"
        };

        [Fact]
        public void ParseOneLine()
        {
            var notes = NotesParser.Parse(new[] { _input[0] });

            var note = Assert.Single(notes);
            Assert.Equal(10, note.Signals.Length);
            Assert.Equal(4, note.Outputs.Length);
        }

        [Fact]
        public void ParseMultipleLines()
        {
            var notes = NotesParser.Parse(_input);
            Assert.Equal(_input.Length, notes.Count());
        }
    }
}