using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day3
{
    public class BinaryDiagnostic : Day<decimal>
    {
        public BinaryDiagnostic() : base(3)
        {
        }

        private static int BitArrayToInt(int[] bits)
        {
            return BinaryStringToInt(string.Join("", bits));
        }

        private static int BinaryStringToInt(string binaryNumber)
        {
            return Convert.ToInt32(binaryNumber, 2);
        }

        #region Part One

        public override decimal PartOne(string[] input)
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

        private static int MostCommonBit(string[] input, int position)
        {
            var total = input.Sum(x => int.Parse(x[position].ToString()));
            if (total > input.Length / 2) return 1;
            return 0;
        }

        #endregion

        #region Part Two

        public override decimal PartTwo(string[] input)
        {
            var oxygenGeneratorRating = FindRating(input, '1',
                (withCriteria, withoutCriteria) => withCriteria >= withoutCriteria);
            var co2ScrubberRating = FindRating(input, '0',
                (withCriteria, withoutCriteria) => withCriteria <= withoutCriteria);
            return oxygenGeneratorRating * co2ScrubberRating;
        }

        private static decimal FindRating(string[] input, char criteria, Func<int, int, bool> compare)
        {
            var size = input[0].Length;
            var remainingNumbers = input;
            for (var i = 0; i < size; i++)
            {
                var listWithoutCriteria = new List<string>();
                var listWithCriteria = new List<string>();

                foreach (var number in remainingNumbers)
                    if (number[i] == criteria)
                        listWithCriteria.Add(number);
                    else
                        listWithoutCriteria.Add(number);

                remainingNumbers = compare(listWithCriteria.Count, listWithoutCriteria.Count)
                    ? listWithCriteria.ToArray()
                    : listWithoutCriteria.ToArray();

                if (remainingNumbers.Length == 1)
                    break;
            }

            return BinaryStringToInt(remainingNumbers[0]);
        }

        #endregion
    }
}