using System.IO;
using AdventOfCode;
using Xunit;

namespace AdventOfCodeTests {
    public class Day02Tests : AdventOfCodeTestsBase {
        [Fact]
        public void Day2_A_Success() {
            // Arrange
            var day02 = new Day02(Path.Combine(InputFolder, "Day02.txt"));

            // Act
            var result = day02.A();

            // Assert
            Assert.Equal(666, result);
        }

        [Fact]
        public void Day2_B_Success() {
            // Arrange
            var day02 = new Day02(Path.Combine(InputFolder, "Day02.txt"));

            // Act
            var result = day02.B();

            // Assert
            Assert.Equal(670, result);
        }
    }
}
