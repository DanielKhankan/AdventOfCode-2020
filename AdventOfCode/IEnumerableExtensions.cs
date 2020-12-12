using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    internal static class IEnumerableExtensions {
        public static IEnumerable<(T1, T2)> Cartesian<T1, T2>(this IEnumerable<T1> list1, IEnumerable<T2> list2) {
            var list2Cached = list2.ToList();
            foreach (var item1 in list1) {
                foreach (var item2 in list2Cached) {
                    yield return (item1, item2);
                }
            }
        }

        public static IEnumerable<(T1, T2, T3)> Cartesian<T1, T2, T3>(this IEnumerable<T1> list1, IEnumerable<T2> list2, IEnumerable<T3> list3) {
            var list2Cached = list2.ToList();
            var list3Cached = list3.ToList();

            foreach (var item1 in list1) {
                foreach (var item2 in list2Cached) {
                    foreach (var item3 in list3Cached) {
                        yield return (item1, item2, item3);
                    }
                }
            }
        }

        public static IEnumerable<ICollection<T>> Chunk<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            var chunk = new List<T>();
            foreach (var enumerable in source)
            {
                if (!predicate(enumerable))
                {
                    chunk.Add(enumerable);
                }
                else
                {
                    yield return chunk;
                    chunk = new List<T>();
                }
            }
            yield return chunk;
        }
    }
}