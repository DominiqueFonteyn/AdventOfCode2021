namespace AdventOfCode.Day5
{
    public class Coordinate
    {
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }

        public override string ToString()
        {
            return $"{X},{Y}";
        }

        public static Coordinate FromString(string str)
        {
            var split = str.Split(',');
            return new Coordinate(int.Parse(split[0]), int.Parse(split[1]));
        }
    }
}