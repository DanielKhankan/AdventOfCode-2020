using System.Linq;

namespace AdventOfCode {
    public class Day02 : AdventOfCodeBase {
        public Day02(string fileName) : base(fileName) { }

        // 666
        public long A() {
            return Input
                .Select(Day2ParseLine)
                .Count(x => {
                    var (lowerLimit, upperLimit, character, passwordString) = x;
                    var count = passwordString.Count(c => c == character);
                    return count >= lowerLimit && count <= upperLimit;
                });
        }

        // 670
        public long B() {
            return Input
                .Select(Day2ParseLine)
                .Count(x => {
                    var (lowerLimit, upperLimit, character, passwordString) = x;
                    return passwordString[lowerLimit - 1] == character ^ passwordString[upperLimit - 1] == character;
                });
        }

        private static (int lowerLimit, int upperLimit, char character, string passwordString) Day2ParseLine(string lineInput) {
            var splits = lineInput.Split(' ');
            return (int.Parse(splits[0].Split('-')[0]), int.Parse(splits[0].Split('-')[1]), splits[1][0], splits[2]);
        }
    }
}
