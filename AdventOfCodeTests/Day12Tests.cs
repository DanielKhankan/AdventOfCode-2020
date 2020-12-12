using System.IO;
using AdventOfCode;
using Xunit;

namespace AdventOfCodeTests {
    public class Day12Tests : AdventOfCodeTestsBase {
        [Fact]
        public void Day12_A_Success() {
            // Arrange
            var day12 = new Day12(Path.Combine(InputFolder, "Day12.txt"));

            // Act
            var result = day12.A();

            // Assert
            Assert.Equal(1186, result);
        }

        [Fact]
        public void Day12_B_Success() {
            // Arrange
            var day12 = new Day12(Path.Combine(InputFolder, "Day12.txt"));

            // Act
            var result = day12.B();

            // Assert
            Assert.Equal(47806, result);
        }
    }
}

