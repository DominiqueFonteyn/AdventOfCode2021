using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day6
{
    public class LanternFish : Day<int>
    {
        public LanternFish() : base(6)
        {
        }

        public override int PartOne(string[] input)
        {
            var fish = new List<int>(input[0].Split(',').Select(int.Parse));

            Iterate(fish, 80);

            return fish.Count;
        }

        public override int PartTwo(string[] input)
        {
            throw new NotImplementedException();
        }

        public void Iterate(List<int> fish, int numberOfDays)
        {
            for (var i = 0; i < numberOfDays; i++)
            {
                var spawn = 0;
                for (var f = 0; f < fish.Count; f++)
                {
                    if (fish[f] == 0)
                    {
                        spawn++;
                        fish[f] = 6;
                    }
                    else
                    {
                        fish[f] -= 1;
                    }
                }

                for (var j = 0; j < spawn; j++) 
                    fish.Add(8);
            }
        }
    }
}