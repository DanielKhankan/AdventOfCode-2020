using System.IO;
using AdventOfCode;
using Xunit;

namespace AdventOfCodeTests {
    public class Day05Tests : AdventOfCodeTestsBase {
        [Fact]
        public void Day5_A_Success() {
            // Arrange
            var day05 = new Day05(Path.Combine(InputFolder, "Day05.txt"));

            // Act
            var result = day05.A();

            // Assert
            Assert.Equal(994, result);
        }

        [Fact]
        public void Day05_B_Success() {
            // Arrange
            var day05 = new Day05(Path.Combine(InputFolder, "Day05.txt"));

            // Act
            var result = day05.B();

            // Assert
            Assert.Equal(741, result);
        }
    }
}

