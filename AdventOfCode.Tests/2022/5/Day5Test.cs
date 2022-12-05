using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Tests._2022._5
{
    public class Day5Test : TestBase<string>
    {
        public Day5Test() : base(2022, 5)
        {
        }

        protected override string ExpectedResultPart1 => "CMZ";
        protected override string ExpectedResultPart2 => "MCD";

        protected override string Calculate(string[] data)
        {
            var containerLines = new List<string>();
            var operations = new List<string>();

            var isContainerLine = true;
            Stack<string>[] containers = null;

            foreach (var line in data)
            {
                if (isContainerLine)
                {
                    containerLines.Add(line);
                }
                else
                {
                    if (line.Trim().Length > 0)
                    {
                        operations.Add(line);
                        continue;
                    }
                }

                if (line.StartsWith(" 1"))
                {
                    isContainerLine = false;
                    containers = InitializeContainers(line);
                }
            }

            FillContainers(containers, containerLines);

            OperateCrane(containers, operations);

            return string.Join(null, containers
                    .Select(x => x.Peek()))
                .Replace("[", "")
                .Replace("]", "");
        }

        private void OperateCrane(Stack<string>[] containers, List<string> operations, bool moveMultiple = false)
        {
            foreach (var line in operations)
            {
                var parts = line.Split(new[] { "move ", " from ", " to " }, StringSplitOptions.RemoveEmptyEntries);

                var amount = int.Parse(parts[0]);
                var from = int.Parse(parts[1]);
                var to = int.Parse(parts[2]);

                if (moveMultiple)
                {
                    var temp = new Stack<string>();
                    for (var i = 0; i < amount; i++)
                        temp.Push(containers[from-1].Pop());
                    for (var i = 0; i < amount; i++)
                        containers[to-1].Push(temp.Pop());
                }
                else
                {
                    for (var i = 0; i < amount; i++)
                        containers[to - 1].Push(containers[from - 1].Pop());    
                }
                
                
            }
        }

        private Stack<string>[] InitializeContainers(string containerLine)
        {
            var parts = containerLine.Trim().Split("   ");
            return new Stack<string>[parts.Length];
        }

        private void FillContainers(Stack<string>[] containers, List<string> contentLines)
        {
            contentLines.Reverse();

            foreach (var line in contentLines)
                for (var i = 0; i < containers.Length; i++)
                {
                    containers[i] ??= new Stack<string>();
                    var content = line.Substring(i * 4, 3);
                    if (content.StartsWith("["))
                    {
                        containers[i].Push(content);
                    }
                }
        }

        protected override string Calculate2(string[] data)
        {
            var containerLines = new List<string>();
            var operations = new List<string>();

            var isContainerLine = true;
            Stack<string>[] containers = null;

            foreach (var line in data)
            {
                if (isContainerLine)
                {
                    containerLines.Add(line);
                }
                else
                {
                    if (line.Trim().Length > 0)
                    {
                        operations.Add(line);
                        continue;
                    }
                }

                if (line.StartsWith(" 1"))
                {
                    isContainerLine = false;
                    containers = InitializeContainers(line);
                }
            }

            FillContainers(containers, containerLines);

            OperateCrane(containers, operations, true);

            return string.Join(null, containers
                    .Select(x => x.Peek()))
                .Replace("[", "")
                .Replace("]", "");
        }
    }
}
