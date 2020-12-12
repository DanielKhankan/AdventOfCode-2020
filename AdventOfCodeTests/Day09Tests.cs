using System.IO;
using AdventOfCode;
using Xunit;

namespace AdventOfCodeTests {
    public class Day09Tests : AdventOfCodeTestsBase {
        [Fact]
        public void Day09_A_Success() {
            // Arrange
            var day09 = new Day09(Path.Combine(InputFolder, "Day09.txt"));

            // Act
            var result = day09.A();

            // Assert
            Assert.Equal(70639851, result);
        }

        [Fact]
        public void Day09_B_Success() {
            // Arrange
            var day09 = new Day09(Path.Combine(InputFolder, "Day09.txt"));

            // Act
            var result = day09.B();

            // Assert
            Assert.Equal(8249240, result);
        }
    }
}

