using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Tests._2022._4
{
    public class Day4Test : TestBase
    {
        public Day4Test() : base(2022, 4)
        {
        }

        protected override int ExpectedResultPart1 => 2;
        protected override int ExpectedResultPart2 => 4;

        protected override int Calculate(string[] data)
        {
            var total = 0;
            foreach (var line in data)
            {
                var assignments = line.Split(',');
                var a = Assignment.FromStr(assignments[0]);
                var b = Assignment.FromStr(assignments[1]);

                if (FullyContains(a, b) || FullyContains(b, a))
                {
                    total++;
                }

            }
            return total;
        }

        private static bool FullyContains(Assignment a, Assignment b)
        {
            return a.Sections.Contains(b.Sections.Min()) && a.Sections.Contains(b.Sections.Max());
        }

        protected override int Calculate2(string[] data)
        {
            var total = 0;
            foreach (var line in data)
            {
                var assignments = line.Split(',');
                var a = Assignment.FromStr(assignments[0]);
                var b = Assignment.FromStr(assignments[1]);

                if (a.Sections.Intersect(b.Sections).Any())
                {
                    total++;
                }
            }
            return total;
        }

        private class Assignment
        {
            private readonly int _from;
            private readonly int _to;

            public Assignment(int from, int to)
            {
                _from = from;
                _to = to;

                Sections = ComputeSections();
            }

            public int[] Sections { get; }

            public static Assignment FromStr(string assignment)
            {
                var sections = assignment.Split('-');
                return new Assignment(
                    int.Parse(sections[0]),
                    int.Parse(sections[1]));
            }

            private int[] ComputeSections()
            {
                var sections = new List<int>();

                var i = _from;
                do
                {
                    sections.Add(i);
                } while (i++ < _to);

                return sections.ToArray();
            }

            public override string ToString()
            {
                return $"{_from}-{_to}";
            }
        }
    }
}
