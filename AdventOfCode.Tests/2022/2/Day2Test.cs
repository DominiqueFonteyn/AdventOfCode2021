using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            { Hand.Rock, 1 }, 
            { Hand.Paper, 2 },
            { Hand.Scissors, 3 }
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
        
        private int Calculate2(string[] input)
        {
            var score = 0;
            foreach (var str in input)
            {
                var theirs = _hands[str[0].ToString()];
                var strategy = str[2].ToString();

                var yours = strategy switch
                {
                    "X" => _enemies.Single(x => x.Value == theirs).Key,
                    "Y" => theirs,
                    _ => _enemies[theirs]
                };

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
        
        [Fact]
        public void Part2_Example()
        {
            var result = Calculate2(File.ReadAllLines("2022/2/example.txt"));
            Assert.Equal(12, result);
        }
        
        [Fact]
        public void Part2_Input()
        {
            var input = File.ReadAllLines("2022/2/input.txt");
            Assert.Equal(0, Calculate2(input));
        }
    }
}
