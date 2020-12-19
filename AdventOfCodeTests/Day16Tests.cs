using System.IO;
using AdventOfCode;
using Xunit;

namespace AdventOfCodeTests {
    public class Day16Tests : AdventOfCodeTestsBase{

        [Fact]
        public void Day16_A_ExampleSuccess()
        {
            // Arrange
            var day16 = new Day16(Path.Combine(InputFolder, "Day16ExampleA.txt"));

            // Act
            var result = day16.A( );

            // Assert
            Assert.Equal(71, result);
        }

        [Fact]
        public void Day16_A_Success()
        {
            // Arrange
            var day16 = new Day16(Path.Combine(InputFolder, "Day16.txt"));

            // Act
            var result = day16.A( );

            // Assert
            Assert.Equal(20975, result);
        }


    }
}
