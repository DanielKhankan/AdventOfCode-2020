using System.IO;
using AdventOfCode;
using Xunit;

namespace AdventOfCodeTests {
    public class Day04Tests : AdventOfCodeTestsBase {
        [Fact]
        public void Day4_A_Success() {
            // Arrange
            var day04 = new Day04(Path.Combine(InputFolder, "Day04.txt"));

            // Act
            var result = day04.A();

            // Assert
            Assert.Equal(170, result);
        }

        [Fact]
        public void Day4_B_Success() {
            // Arrange
            var day04 = new Day04(Path.Combine(InputFolder, "Day04.txt"));

            // Act
            var result = day04.B();

            // Assert
            Assert.Equal(103, result);
        }
    }
}

