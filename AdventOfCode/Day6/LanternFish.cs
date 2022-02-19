using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day6
{
    public class LanternFish : Day<long>
    {
        public LanternFish() : base(6)
        {
        }

        public override long PartOne(string[] input)
        {
            var fish = new List<int>(input[0].Split(',').Select(int.Parse));
            return SimulateSpawn(fish.ToArray(), 80);
        }

        public override long PartTwo(string[] input)
        {
            var fish = new List<int>(input[0].Split(',').Select(int.Parse));
            return SimulateSpawn(fish.ToArray(), 256);
        }

        public long SimulateSpawn(int[] fish, int dayCount)
        {
            // initialize bucket
            var bucket = new long[9];
            for (var age = 0; age < bucket.Length; age++)
                bucket[age] = fish.Count(x => x == age);

            // simulate growth
            for (var day = 0; day < dayCount; day++)
            {
                var afterSpawn = new long[bucket.Length];

                for (var age = 0; age < bucket.Length; age++)
                    afterSpawn[age] = age switch
                    {
                        6 => bucket[0] + bucket[age + 1],
                        8 => bucket[0],
                        _ => bucket[age + 1]
                    };

                bucket = afterSpawn;
            }

            return bucket.Sum();
        }
    }
}