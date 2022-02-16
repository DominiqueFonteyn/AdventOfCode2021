using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day4
{
    public class GiantSquid : Day<int>
    {
        public GiantSquid() : base(4)
        {
        }

        public override int PartOne(string[] input)
        {
            var numbers = ReadNumbers(input);
            var boards = ReadBoards(input);

            PrintNumbers(numbers);

            foreach (var number in numbers)
                for (var i = 0; i < boards.Length; i++)
                {
                    boards[i].Mark(number);
                    if (boards[i].Wins())
                    {
                        PrintBoard(i, boards[i]);
                        return boards[i].Score(number);
                    }
                }

            return 0;
        }

        public override int PartTwo(string[] input)
        {
            var numbers = ReadNumbers(input);
            var boards = ReadBoards(input).ToArray();
            var winners = new HashSet<int>();

            PrintNumbers(numbers);

            var lastNumber = 0;
            foreach (var number in numbers)
                for (var i = 0; i < boards.Length; i++)
                {
                    if (winners.Contains(i))
                        continue;

                    boards[i].Mark(number);
                    if (boards[i].Wins())
                    {
                        PrintBoard(i, boards[i]);
                        winners.Add(i);
                        lastNumber = number;
                    }
                }

            return boards[winners.Last()].Score(lastNumber);
        }

        private static void PrintBoard(int i, BingoBoard board)
        {
            Console.WriteLine($"Board {i + 1} won");
            Console.WriteLine(board);
        }

        private void PrintNumbers(int[] numbers)
        {
            Console.WriteLine(string.Join(", ", numbers));
        }

        public int[] ReadNumbers(string[] input)
        {
            return input[0].Split(',').Select(int.Parse).ToArray();
        }

        public BingoBoard[] ReadBoards(string[] input)
        {
            var boards = new List<BingoBoard>();
            for (var i = 2; i < input.Length; i++)
            {
                var numbers = new List<int>();
                var row = 0;
                while (row < BingoBoard.Size)
                {
                    numbers.AddRange(
                        input[i + row]
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse));
                    row++;
                }

                boards.Add(new BingoBoard(numbers.ToArray()));

                i += BingoBoard.Size;
            }

            return boards.ToArray();
        }
    }
}