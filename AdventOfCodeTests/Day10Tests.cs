using System.IO;
using AdventOfCode;
using Xunit;

namespace AdventOfCodeTests {
    public class Day10Tests : AdventOfCodeTestsBase {
        [Fact]
        public void Day10_A_Success() {
            // Arrange
            var day10 = new Day10(Path.Combine(InputFolder, "Day10.txt"));

            // Act
            var result = day10.A();

            // Assert
            Assert.Equal(2176, result);
        }

        [Fact]
        public void Day1_B_Success() {
            // Arrange
            var day10 = new Day10(Path.Combine(InputFolder, "Day10.txt"));

            // Act
            var result = day10.B();

            // Assert
            Assert.Equal(18512297918464, result);
        }
    }
}

