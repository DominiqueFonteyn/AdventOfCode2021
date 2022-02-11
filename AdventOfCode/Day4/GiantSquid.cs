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
            var numbers = ReadPickedNumbers(input);
            var boards = ParseBoards(input);

            BingoBoard winningBoard = null;
            var lastNumber = 0;
            foreach (var number in numbers)
            {
                lastNumber = number;
                foreach (var board in boards)
                {
                    board.Mark(number);
                    if (board.HasCompleteRow()) 
                        winningBoard = board;
                }

                if (winningBoard != null)
                    break;
            }

            if (winningBoard == null) return 0;

            var sumOfUnmarked = winningBoard.UnmarkedNumbers().Sum(x => x);
            return sumOfUnmarked * lastNumber;
        }

        public override int PartTwo(string[] input)
        {
            throw new NotImplementedException();
        }

        public int[] ReadPickedNumbers(string[] input)
        {
            return input[0].Split(',').Select(int.Parse).ToArray();
        }

        public BingoBoard[] ParseBoards(string[] input)
        {
            var boards = new List<BingoBoard>();

            for (var i = 2; i < input.Length; i++)
            {
                var numbers = new List<int>();
                var row = 0;
                while (row < BingoBoard.Size)
                {
                    numbers.AddRange(input[i + row].Replace("  ", " ").Split(" ").Select(int.Parse));
                    row++;
                }

                boards.Add(new BingoBoard(numbers.ToArray()));

                i += BingoBoard.Size;
            }

            return boards.ToArray();
        }

        public class BingoBoard
        {
            public static int Size = 5;

            public BingoBoard(int[] numbers)
            {
                Numbers = numbers.Select(x => new Number(x)).ToArray();
            }

            public Number[] Numbers { get; }

            public bool HasCompleteRow()
            {
                for (var i = 0; i < Size; i++)
                {
                    if (Row(i).All(x => x.IsMarked)) return true;
                    if (Column(i).All(x => x.IsMarked)) return true;
                }

                return false;
            }

            private IEnumerable<Number> Row(int position)
            {
                for (var i = 0; i < Size; i++)
                    yield return Numbers[position + i];
            }

            private IEnumerable<Number> Column(int position)
            {
                for (var i = 0; i < Size; i++)
                    yield return Numbers[position + i * Size];
            }

            public void Mark(int number)
            {
                Numbers.SingleOrDefault(x => x.Value == number)?.Mark();
            }

            public int[] UnmarkedNumbers()
            {
                return Numbers
                    .Where(x => !x.IsMarked)
                    .Select(x => x.Value)
                    .ToArray();
            }
        }

        public class Number
        {
            public Number(int value)
            {
                Value = value;
                IsMarked = false;
            }

            public int Value { get; }

            public bool IsMarked { get; private set; }

            public void Mark()
            {
                IsMarked = true;
            }
        }
    }
}