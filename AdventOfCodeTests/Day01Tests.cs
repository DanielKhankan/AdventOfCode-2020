using System.IO;
using AdventOfCode;
using Xunit;

namespace AdventOfCodeTests {
    public class Day01Tests : AdventOfCodeTestsBase {
        [Fact]
        public void Day1_A_Success() {
            // Arrange
            var day01 = new Day01(Path.Combine(InputFolder, "Day01.txt"));

            // Act
            var result = day01.A();

            // Assert
            Assert.Equal(224436, result);
        }

        [Fact]
        public void Day1_B_Success() {
            // Arrange
            var day01 = new Day01(Path.Combine(InputFolder, "Day01.txt"));

            // Act
            var result = day01.B();

            // Assert
            Assert.Equal(303394260, result);
        }
    }
}
