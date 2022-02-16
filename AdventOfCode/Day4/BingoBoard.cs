using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day4
{
    public class BingoBoard
    {
        public const int Size = 5;

        public BingoBoard(IEnumerable<int> numbers)
        {
            Numbers = numbers.Select(x => new Number(x)).ToArray();
        }

        public Number[] Numbers { get; }

        public bool Wins()
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
                yield return Numbers[position * Size + i];
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

        public int Score(int lastNumber)
        {
            return UnmarkedNumbers().Sum(x => x) * lastNumber;
        }

        public override string ToString()
        {
            var strBuilder = new StringBuilder();

            for (var i = 0; i < Size; i++)
                strBuilder.AppendLine(string.Join(" ", Numbers.Skip(i * Size).Take(Size)));

            return strBuilder.ToString();
        }
    }
}