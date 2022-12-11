using System;

namespace AdventOfCode.Tests._2022._9
{
    public class Motion
    {
        public Motion(string input)
        {
            Direction = GetDirection(input[..1]);
            Steps = int.Parse(input[2..]);
        }

        public Direction Direction { get; }
        public int Steps { get; }

        private Direction GetDirection(string d)
        {
            return d switch
            {
                "U" => Direction.Up,
                "R" => Direction.Right,
                "D" => Direction.Down,
                "L" => Direction.Left,
                _ => throw new NotSupportedException()
            };
        }
    }
}
