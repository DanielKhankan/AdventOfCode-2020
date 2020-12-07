using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

namespace AdventOfCode
{
    internal static class Day6
    {
        internal static int Day6A()
        {
            var list = new List<HashSet<char>>();

            using var streamReader = new StreamReader(Path.Combine(Program.InputsFolder, "Day6.txt"));
            var hashset = new HashSet<char>();

            string line;
            while ((line = streamReader.ReadLine()) != null) {

                if (string.IsNullOrEmpty(line))
                {
                    list.Add(hashset);
                    hashset = new HashSet<char>();
                }
                else
                {
                    foreach (var c in line.Trim())
                    {
                        hashset.Add(c);
                    }
                }
            }
            list.Add(hashset);

            return list.Select(x=> x.Count).Sum();
        }

        // functional style
        internal static int Day6A2()
        {
            return File.ReadAllLines(Path.Combine(Program.InputsFolder, "Day6.txt"))
                .Chunk(string.IsNullOrEmpty)
                .Select(x => x.SelectMany(s => s.AsEnumerable()).Distinct().Count())
                .Sum();
        }

        // functional style
        internal static int Day6B2()
        {
            var foo = File.ReadAllLines(Path.Combine(Program.InputsFolder, "Day6.txt"))
                .Chunk(string.IsNullOrEmpty)
                .Select(x => x.SelectMany(s => s.AsEnumerable().Distinct()).ToLookup(c => c, c => x.All(list => list.Contains(c))));

            return foo.SelectMany(lookup => lookup.Where(grouping => grouping.First()).Select(grouping => lookup)).Count();
        }

        internal static int Day6B()
        {
            var list = new List<int>();

            using (var streamReader = new StreamReader(Path.Combine(Program.InputsFolder, "Day6.txt")))
            {
                var countDictionary = new Dictionary<char, int>();

                string line;
                int groupMembers = 0;
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (string.IsNullOrEmpty(line))
                    {
                        list.Add(countDictionary.Values.Count(x => x == groupMembers));
                        countDictionary = new Dictionary<char, int>();
                        groupMembers = 0;
                    }
                    else
                    {
                        groupMembers++;
                        foreach (var c in line.Trim())
                        {
                            if (countDictionary.ContainsKey(c)) {
                                countDictionary[c] = countDictionary[c] + 1;
                            }
                            else {
                                countDictionary.Add(c, 1);
                            }
                        }
                    }
                }
                list.Add(countDictionary.Values.Count(x => x == groupMembers));
            }

            return list.Sum();
        }
        

        internal static IEnumerable<ICollection<T>> Chunk<T>(this IEnumerable<T> source, Predicate<T> predicate)
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
