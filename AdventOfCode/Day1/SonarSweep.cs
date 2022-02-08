namespace AdventOfCode.Day1
{
    public class SonarSweep
    {
        public int CountNumberOfIncreases(int[] measurements)
        {
            var increases = 0;

            for (var i = 1; i < measurements.Length; i++)
                if (measurements[i] > measurements[i - 1])
                    increases++;

            return increases;
        }

        public int CountNumberOfIncreasesBySlidingWindow(int[] measurements)
        {
            var increases = 0;
            var windowSize = 3;

            for (var i = 1; i < measurements.Length && measurements.Length - i > windowSize - 1; i++)
                if (SumOfWindow(measurements, i, windowSize) > SumOfWindow(measurements, i - 1, windowSize))
                    increases++;

            return increases;
        }

        private int SumOfWindow(int[] measurements, int start, int windowSize)
        {
            var sum = 0;
            for (var i = 0; i < windowSize; i++) sum += measurements[start + i];
            return sum;
        }
    }
}