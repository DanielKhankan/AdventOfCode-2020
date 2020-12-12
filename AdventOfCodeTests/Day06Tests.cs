using System.IO;
using AdventOfCode;
using Xunit;

namespace AdventOfCodeTests {
    public class Day06Tests : AdventOfCodeTestsBase {
        [Fact]
        public void Day06_A_Success() {
            // Arrange
            var day06 = new Day06(Path.Combine(InputFolder, "Day06.txt"));

            // Act
            var result = day06.A();

            // Assert
            Assert.Equal(6585, result);
        }

        [Fact]
        public void Day06_A1_Success() {
            // Arrange
            var day06 = new Day06(Path.Combine(InputFolder, "Day06.txt"));

            // Act
            var result = day06.A2();

            // Assert
            Assert.Equal(6585, result);
        }

        [Fact]
        public void Day06_B_Success() {
            // Arrange
            var day06 = new Day06(Path.Combine(InputFolder, "Day06.txt"));

            // Act
            var result = day06.B();

            // Assert
            Assert.Equal(3276, result);
        }

        [Fact]
        public void Day06_B2_Success() {
            // Arrange
            var day06 = new Day06(Path.Combine(InputFolder, "Day06.txt"));

            // Act
            var result = day06.B2();

            // Assert
            Assert.Equal(3276, result);
        }
    }
}

