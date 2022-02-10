namespace AdventOfCode.Day2
{
    public class Dive
    {
        public int PartOne(string[] instructions, bool withAim = false)
        {
            var horizontal = 0;
            var depth = 0;
            var aim = 0;
            foreach (var instruction in instructions)
            {
                var split = instruction.Split(new[] { ' ' });
                var direction = split[0];
                var amount = int.Parse(split[1]);

                switch (direction)
                {
                    case "forward":
                        horizontal += amount;
                        if (withAim)
                            depth += (aim * amount);
                        break;
                    case "up":
                        if (!withAim) depth -= amount;
                        aim -= amount;
                        break;
                    case "down":
                        if (!withAim) depth += amount;
                        aim += amount;
                        break;
                }
            }

            return horizontal * depth;
        }

        public int PartTwo(string[] instructions)
        {
            return PartOne(instructions, true);
        }
    }
}