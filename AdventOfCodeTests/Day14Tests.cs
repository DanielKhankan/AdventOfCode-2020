using AdventOfCode;
using Xunit;
using System.IO;

namespace AdventOfCodeTests
{
    public class Day14Tests : AdventOfCodeTestsBase
    {
        [Fact]
        public void Day14_A_ExampleSuccess()
        {
            // Arrange
            var day14 = new Day14(Path.Combine(InputFolder, "Day14ExampleA.txt"));

            // Act
            var result = day14.A();

            // Assert
            Assert.Equal(165, result);
        }

        [Fact]
        public void Day14_A_Success()
        {
            // Arrange
            var day14 = new Day14(Path.Combine(InputFolder, "Day14.txt"));

            // Act
            var result = day14.A();

            // Assert
            Assert.Equal(17481577045893, result);
        }

        [Fact]
        public void Day14_B_ExampleSuccess()
        {
            // Arrange
            var day14 = new Day14(Path.Combine(InputFolder, "Day14ExampleB.txt"));

            // Act
            var result = day14.B();

            // Assert
            Assert.Equal(208, result);
        }

        [Fact]
        public void Day14_B_Success()
        {
            // Arrange
            var day14 = new Day14(Path.Combine(InputFolder, "Day14.txt"));

            // Act
            var result = day14.B();

            // Assert
            Assert.Equal(4160009892257, result);
        }
    }
}
