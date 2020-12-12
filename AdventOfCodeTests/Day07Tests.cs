using System.IO;
using AdventOfCode;
using Xunit;

namespace AdventOfCodeTests {
    public class Day07Tests : AdventOfCodeTestsBase {
        [Fact]
        public void Day07_A_Success() {
            // Arrange
            var day07 = new Day07(Path.Combine(InputFolder, "Day07.txt"));

            // Act
            var result = day07.A();

            // Assert
            Assert.Equal(192, result);
        }

        [Fact]
        public void Day07_B_Success() {
            // Arrange
            var day07 = new Day07(Path.Combine(InputFolder, "Day07.txt"));

            // Act
            var result = day07.B();

            // Assert
            Assert.Equal(12128, result);
        }
    }
}

