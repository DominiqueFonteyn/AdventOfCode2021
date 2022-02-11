using AdventOfCode.Day1;
using Xunit;

namespace AdventOfCode.Tests.Day1
{
    public class SonarSweepTests
    {
        private readonly SonarSweep _sonarSweep;

        public SonarSweepTests()
        {
            _sonarSweep = new SonarSweep();
        }

        [Fact]
        public void CountIncreases()
        {
            var measurements = new[]
            {
                199,
                200,
                208,
                210,
                200,
                207,
                240,
                269,
                260,
                263,
            };
            
            Assert.Equal(7, _sonarSweep.PartOne(measurements));
        }
        
        
        [Fact]
        public void CountIncreasesBySlidingWindow()
        {
            var measurements = new[]
            {
                607 ,
                618,
                618,
                617,
                647,
                716,
                769,
                792
            };
            
            Assert.Equal(5, _sonarSweep.PartTwo(measurements));
        }
    }
}