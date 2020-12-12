using System.Linq;

namespace AdventOfCode {
    public class Day09 : AdventOfCodeBase {

        public Day09(string fileName) : base(fileName) { }

        public long A()
        {
            const int preambleLength = 25;
            var allNumbers = Input.Select(long.Parse).ToList();

            var counter = 0;
            foreach (var number in allNumbers.Skip(preambleLength))
            {
                var preambleInput = allNumbers.Skip(counter).Take(preambleLength).ToList();
                var preamble = preambleInput.Cartesian(preambleInput);

                if (preamble.All(pre => pre.Item2 + pre.Item1 != number))
                {
                    return number;
                }

                counter++;
            }

            return 0;
        }

        public long B()
        {
            const long sumToFind = 70639851;

            var allNumbers = Input.Select(long.Parse).Where( x=> x != sumToFind).ToList();

            var startIndex = 0;
            foreach (var _ in allNumbers)
            {
                var length = 0;
                long sum = 0;

                while (startIndex + length < allNumbers.Count - 1)
                {
                    sum += allNumbers[startIndex + length];
                    
                    if (sum == sumToFind)
                    {
                        var list = allNumbers.Skip(startIndex).Take(length).ToList();
                        return list.Max() + list.Min();
                    }
                    length++;
                }
                startIndex++;
            }

            return 0;
        }
    }
}
