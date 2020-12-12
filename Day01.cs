using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode {

    internal static class Day01 {
        // 303394260
        internal static int Day1B()
        {
            var list = File.ReadAllLines(Path.Combine(Program.InputsFolder, "Day1.txt")).Select(int.Parse).ToList();
            
            var (item1, item2, item3) = list.Cartesian(list, list).First(x => x.Item1 + x.Item2 + x.Item3 == 2020);
            return item1 * item2 * item3;
        }

        // 224436
        internal static int Day1A()
        {
            var list = File.ReadAllLines(Path.Combine(Program.InputsFolder, "Day1.txt")).Select(int.Parse).ToList();

            var (item1, item2) = list.Cartesian(list).First(x => x.Item1 + x.Item2 == 2020);

            return item1 * item2;
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

        private static IEnumerable<(T1, T2, T3)> Cartesian<T1, T2, T3>(this IEnumerable<T1> list1, IEnumerable<T2> list2, IEnumerable<T3> list3)
        {
            var list2Cached = list2.ToList();
            var list3Cached = list3.ToList();

            foreach (var item1 in list1)
            {
                foreach (var item2 in list2Cached)
                {
                    foreach (var item3 in list3Cached)
                    {
                        yield return (item1, item2, item3);
                    }
                }
            }
        }
    }
}
