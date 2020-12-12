using System.IO;
using AdventOfCode;
using Xunit;

namespace AdventOfCodeTests {
    public class Day03Tests : AdventOfCodeTestsBase {
        [Fact]
        public void Day3_A_Success() {
            // Arrange
            var day03 = new Day03(Path.Combine(InputFolder, "Day03.txt"));

            // Act
            var result = day03.A();

            // Assert
            Assert.Equal(171, result);
        }

        [Fact]
        public void Day3_B_Success() {
            // Arrange
            var day03 = new Day03(Path.Combine(InputFolder, "Day03.txt"));

            // Act
            var result = day03.B();

            // Assert
            Assert.Equal(1206576000, result);
        }
    }
}

