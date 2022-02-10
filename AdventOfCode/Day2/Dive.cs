namespace AdventOfCode.Day2
{
    public class Dive
    {
        public int Run(string[] instructions)
        {
            var horizontal = 0;
            var depth = 0;

            foreach (var instruction in instructions)
            {
                var split = instruction.Split(new[] { ' ' });
                var direction = split[0];
                var amount = int.Parse(split[1]);

                switch (direction)
                {
                    case "forward":
                        horizontal += amount;
                        break;
                    case "up":
                        depth -= amount;
                        break;
                    case "down":
                        depth += amount;
                        break;
                }
            }

            return horizontal * depth;
        }
    }
}