using System.Collections.Generic;
using System.IO;
using Xunit;

namespace AdventOfCode.Tests._2022._2
{
    public class Day2Test
    {
        private enum Hand
        {
            Rock,
            Paper,
            Scissors
        }

        private readonly Dictionary<string, Hand> _hands = new Dictionary<string, Hand>()
        {
            {"A", Hand.Rock},
            {"B", Hand.Paper},
            {"C", Hand.Scissors},
            {"X", Hand.Rock},
            {"Y", Hand.Paper},
            {"Z", Hand.Scissors},
        };
        
        private readonly Dictionary<Hand, Hand> _enemies = new Dictionary<Hand, Hand>()
        {
            { Hand.Rock, Hand.Paper }, 
            { Hand.Paper, Hand.Scissors },
            { Hand.Scissors, Hand.Rock }
        };

        private readonly Dictionary<Hand, int> _scoring = new Dictionary<Hand, int>
        {
            { Hand.Rock, 1 }, // Rock
            { Hand.Paper, 2 }, // Paper
            { Hand.Scissors, 3 }  // Scissors
        };

        private int Calculate(string[] input)
        {
            var score = 0;
            foreach (var str in input)
            {
                var theirs = _hands[str[0].ToString()];
                var yours = _hands[str[2].ToString()];
                score += Score(theirs, yours) + _scoring[yours];
            }
            return score;
        }

        private int Score(Hand theirs, Hand yours)
        {
            if (_enemies[theirs] == yours) return 6;
            if (theirs == yours) return 3;
            return 0;
        }

        [Fact]
        public void Part1_Example()
        {
            var result = Calculate(File.ReadAllLines("2022/2/example.txt"));
            Assert.Equal(15, result);
        }

        [Fact]
        public void Part1_Input()
        {
            var input = File.ReadAllLines("2022/2/input.txt");
            Assert.Equal(0, Calculate(input));
        }
        //
        // [Fact]
        // public void Part2_Example()
        // {
        //     var result = Calculate(File.ReadAllLines("2022/2/example.txt"));
        //     Assert.Equal(45000, result);
        // }
        //
        // [Fact]
        // public void Part2_Input()
        // {
        //     var input = File.ReadAllLines("2022/2/input.txt");
        //     Assert.Equal(0, Calculate(input));
        // }
    }
}
