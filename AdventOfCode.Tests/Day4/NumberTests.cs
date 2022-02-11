using AdventOfCode.Day4;
using Xunit;

namespace AdventOfCode.Tests.Day4
{
    public class NumberTests
    {
        [Fact]
        public void InitWithNumber()
        {
            var number = new GiantSquid.Number(10);
            
            Assert.Equal(10, number.Value);
            Assert.False(number.IsMarked);
        }

        [Fact]
        public void Mark()
        {
            var number = new GiantSquid.Number(10);
            
            number.Mark();
            
            Assert.True(number.IsMarked);
        }
    }
}