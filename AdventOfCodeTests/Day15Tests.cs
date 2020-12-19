using System.Collections.Generic;
using AdventOfCode;
using Xunit;

namespace AdventOfCodeTests {
    public class Day15Tests {
        [Fact]
        public void Day15_A_ExampleSuccess() {
            // Arrange
            var day15 = new Day15();

            // Act
            var result = day15.A(new List<long> { 0, 3, 6 }, 2020);
            var result2 = day15.A(new List<long> { 1, 3, 2 }, 2020);
            var result3 = day15.A(new List<long> { 2, 1, 3 }, 2020);
            var result4 = day15.A(new List<long> { 1, 2, 3 }, 2020);
            var result5 = day15.A(new List<long> { 2, 3, 1 }, 2020);
            var result6 = day15.A(new List<long> { 3, 2, 1 }, 2020);
            var result7 = day15.A(new List<long> { 3, 1, 2 }, 2020);

            // Assert
            Assert.Equal(436, result);
            Assert.Equal(1, result2);
            Assert.Equal(10, result3);
            Assert.Equal(27, result4);
            Assert.Equal(78, result5);
            Assert.Equal(438, result6);
            Assert.Equal(1836, result7);
        }

        [Fact]
        public void Day15_A_Success() {
            // Arrange
            var day15 = new Day15();

            // Act
            var result = day15.A(new List<long> { 20, 0, 1, 11, 6, 3 }, 2020);


            // Assert
            Assert.Equal(421, result);
        }

        [Fact]
        public void Day15_B_ExampleSuccess() {
            // Arrange
            var day15 = new Day15();

            // Act
            var result = day15.B(new List<long> { 0, 3, 6 }, 30000000);

            // Assert
            Assert.Equal(175594, result);
        }

        [Fact]
        public void Day15_B_Success() {
            // Arrange
            var day15 = new Day15();

            // Act
            var result = day15.B(new List<long> { 20,0,1,11,6,3 }, 30000000);

            // Assert
            Assert.Equal(436, result);
        }
    }
}
