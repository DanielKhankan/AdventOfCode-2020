using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Day06 : AdventOfCodeBase {
        public Day06(string fileName) : base(fileName) { }

        public long A() {
            var list = new List<HashSet<char>>();

            using var streamReader = new StreamReader(FileName);
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
        public long A2()
        {
            return Input
                .Chunk(string.IsNullOrEmpty)
                .Select(x => x.SelectMany(s => s.AsEnumerable()).Distinct().Count())
                .Sum();
        }

        // functional style
        public long B2()
        {
            var foo = Input
                .Chunk(string.IsNullOrEmpty)
                .Select(x => x.SelectMany(s => s.AsEnumerable().Distinct()).ToLookup(c => c, c => x.All(list => list.Contains(c))));

            return foo.SelectMany(lookup => lookup.Where(grouping => grouping.First()).Select(grouping => lookup)).Count();
        }

        public long B()
        {
            var list = new List<int>();

            using var streamReader = new StreamReader(FileName);
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

            return list.Sum();
        }
        

        
    }
}
