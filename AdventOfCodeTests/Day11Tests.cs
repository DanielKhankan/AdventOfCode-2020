using System.IO;
using AdventOfCode;
using Xunit;

namespace AdventOfCodeTests {
    public class Day11Tests : AdventOfCodeTestsBase {
        [Fact]
        public void Day11_A_Success() {
            // Arrange
            var day11 = new Day11(Path.Combine(InputFolder, "Day11.txt"));

            // Act
            var result = day11.A();

            // Assert
            Assert.Equal(2316, result);
        }

        [Fact]
        public void Day11_B_Success() {
            // Arrange
            var day11 = new Day11(Path.Combine(InputFolder, "Day11.txt"));

            // Act
            var result = day11.B();

            // Assert
            Assert.Equal(2128, result);
        }
    }
}

