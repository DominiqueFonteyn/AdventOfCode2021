using System;
using System.Collections.Generic;
using System.Linq;
using Xunit.Abstractions;

namespace AdventOfCode.Tests._2022._10
{
    public class Day10Test : TestBase
    {
        private readonly ITestOutputHelper _output;

        public Day10Test(ITestOutputHelper output) : base(2022, 10)
        {
            _output = output;
        }

        protected override int ExpectedResultPart1 => 13140;
        protected override int ExpectedResultPart2 => 0;

        private static Instruction Noop(string command = "noop") => new Instruction
        {
            Command = command,
            Value = 0
        };

        protected override int Calculate(string[] data)
        {
            var signalStrengths = new List<int>();
            var registerX = 1;
            var currentCycle = 0;
            var cycles = new[] { 20, 60, 100, 140, 180, 220 };
            var instructions = Instructions(data);
            foreach (var instruction in instructions)
            {
                currentCycle++;
                AddSignalStrength(signalStrengths, registerX);
                registerX += instruction.Value;
                _output.WriteLine(
                    $"{currentCycle}: {instruction.Command} - X = {registerX}, signal strength = {signalStrengths.Last()}");
            }

            PrintSignalStrengths(cycles, signalStrengths);

            return cycles.Sum(c => signalStrengths[c - 1]);
        }

        private IEnumerable<Instruction> Instructions(string[] data)
        {
            foreach (var line in data)
                if (line == "noop")
                {
                    yield return Noop();
                }
                else
                {
                    yield return Noop(line);

                    yield return new Instruction
                    {
                        Command = line,
                        Value = GetV(line)
                    };
                }
        }

        private void PrintSignalStrengths(IEnumerable<int> cycles, IReadOnlyList<int> signalStrengths)
        {
            foreach (var cycle in cycles)
                _output.WriteLine($"cycle {cycle}: {signalStrengths[cycle - 1]}");
        }

        private static int GetV(string line)
        {
            var v = int.Parse(line["addx ".Length..]);
            return v;
        }

        private static void AddSignalStrength(List<int> signalStrengths, int registerX)
        {
            signalStrengths.Add((signalStrengths.Count + 1) * registerX);
        }

        protected override int Calculate2(string[] data)
        {
            throw new NotImplementedException();
        }

        private struct Instruction
        {
            public int Value { get; set; }
            public string Command { get; set; }
        }
    }
}
