using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode {
    internal static class Day09 {

        internal static long Day9A()
        {
            const int preambleLength = 25;
            var allNumbers = File.ReadAllLines(Path.Combine(Program.InputsFolder, "Day9.txt")).Select(long.Parse).ToList();

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

        internal static long Day9B()
        {
            const long sumToFind = 70639851;

            var allNumbers = File.ReadAllLines(Path.Combine(Program.InputsFolder, "Day9.txt")).Select(long.Parse).Where( x=> x != sumToFind).ToList();

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

        private static IEnumerable<(T1, T2)> Cartesian<T1, T2>(this IEnumerable<T1> list1, IEnumerable<T2> list2)
        {
            var list2Cached = list2.ToList();

            foreach (var item1 in list1)
            {
                foreach (var item2 in list2Cached)
                {
                    yield return (item1, item2);
                }
            }
        }
    }
}
