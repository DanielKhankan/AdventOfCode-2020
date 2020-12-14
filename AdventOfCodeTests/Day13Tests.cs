using AdventOfCode;
using Xunit;

namespace AdventOfCodeTests
{
    public class Day13ests : AdventOfCodeTestsBase
    {
        [Fact]
        public void Day13_A_ExampleSuccess()
        {
            // Arrange
            var day13 = new Day13();

            // Act
            var result = day13.A(939, "7, 13, x, x, 59, x, 31, 19");

            // Assert
            Assert.Equal(295, result);
        }

        [Fact]
        public void Day13_A_Success()
        {
            // Arrange
            var day13 = new Day13();

            // Act
            var result = day13.A(1006697, "13,x,x,41,x,x,x,x,x,x,x,x,x,641,x,x,x,x,x,x,x,x,x,x,x,19,x,x,x,x,17,x,x,x,x,x,x,x,x,x,x,x,29,x,661,x,x,x,x,x,37,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,23");

            // Assert
            Assert.Equal(3966, result);
        }

        [Fact]
        public void Day13_B_ExampleSuccess()
        {
            // Arrange
            var day13 = new Day13();

            // Act
            var result = day13.B("7, 13, x, x, 59, x, 31, 19");

            // Assert
            Assert.Equal(1068781, result);
        }

       // [Fact(Skip = "not implemented correctly")]
        [Fact]
        public void Day13_B_Example2Success()
        {
            // Arrange
            var day13 = new Day13();

            // Act
            var result = day13.B("1789,37,47,1889");

            // Assert
            Assert.Equal(1202161486, result);
        }

        [Fact]
        public void Day13_B_Example23232Success()
        {
            // Arrange
            var day13 = new Day13();

            // Act
            var result = day13.B("7,5,3");

            // Assert
            Assert.Equal(49, result);
        }

        [Fact]
        public void Day13_B_Success()
        {
            // Arrange
            var day13 = new Day13();

            // Act
            var result = day13.B("13,x,x,41,x,x,x,x,x,x,x,x,x,641,x,x,x,x,x,x,x,x,x,x,x,19,x,x,x,x,17,x,x,x,x,x,x,x,x,x,x,x,29,x,661,x,x,x,x,x,37,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,23 ");

            // Assert
            Assert.Equal(800177252346225, result);
        }
    }
}
