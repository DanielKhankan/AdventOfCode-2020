using System.IO;
using AdventOfCode;
using Xunit;

namespace AdventOfCodeTests {
    public class Day08Tests : AdventOfCodeTestsBase {
        [Fact]
        public void Day08_A_Success() {
            // Arrange
            var day08 = new Day08(Path.Combine(InputFolder, "Day08.txt"));

            // Act
            var result = day08.A();

            // Assert
            Assert.Equal(1654, result);
        }

        [Fact]
        public void Day08_B_Success() {
            // Arrange
            var day08 = new Day08(Path.Combine(InputFolder, "Day08.txt"));

            // Act
            var result = day08.B();

            // Assert
            Assert.Equal(833, result);
        }
    }
}

