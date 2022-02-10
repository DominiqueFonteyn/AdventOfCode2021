using System;
using System.Linq;

namespace AdventOfCode.Day3
{
    public class BinaryDiagnostic
    {
        public decimal PartOne(string[] input)
        {
            var size = input[0].Length;
            var gammaArray = new int[size];
            var epsilonArray = new int[size];

            for (var i = 0; i < size; i++)
            {
                gammaArray[i] = MostCommonBit(input, i);
                epsilonArray[i] = Math.Abs(gammaArray[i] - 1);
            }

            var gamma = BitArrayToInt(gammaArray);
            var epsilonRate = BitArrayToInt(epsilonArray);

            return gamma * epsilonRate;
        }

        public decimal PartTwo(string[] input)
        {
            return 0;
        }

        private int MostCommonBit(string[] input, int position)
        {
            var total = input.Sum(x => int.Parse(x[position].ToString()));
            if (total > input.Length / 2) return 1;
            return 0;
        }

        private int BitArrayToInt(int[] bits)
        {
            return Convert.ToInt32(string.Join("", bits), 2);
        }
    }
}