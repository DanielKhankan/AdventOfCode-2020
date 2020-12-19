using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode {
    public class Day16 : AdventOfCodeBase {
        public Day16(string fileName) : base(fileName) { }

        public long A() {
            var fieldList = new List<int>();

            var listOfInvalidTickets = new List<int>();
            var inputChunks = Input.Chunk(string.IsNullOrEmpty).ToList();

            var fieldsDictionary = CreateFieldDictionary(inputChunks[0]);

            var values = fieldsDictionary.Values.SelectMany(x => x);
            fieldList.AddRange(values.Distinct());

            foreach (var line in inputChunks.Skip(1).SelectMany(x => x)) {
                var numbers = ParseTickets(line);
                listOfInvalidTickets.AddRange(numbers.Where(x => !DictionaryContains(fieldsDictionary, x)));
            }
            return listOfInvalidTickets.Sum();
        }

        private static IDictionary<string, List<int>> CreateFieldDictionary(IEnumerable<string> inputChunk) {
            var fieldsDictionary = new Dictionary<string, List<int>>();
            foreach (var line in inputChunk) {
                var (field, newNumbers) = ParseField(line);

                if (fieldsDictionary.TryGetValue(field, out var numbers)) {
                    numbers.AddRange(newNumbers);
                }
                else {
                    fieldsDictionary[field] = newNumbers;
                }
            }

            return fieldsDictionary;
        }

        public long B() {
            var fieldList = new List<int>();

            var inputChunks = Input.Chunk(string.IsNullOrEmpty).ToList();
            var fieldsDictionary = CreateFieldDictionary(inputChunks[0]);

            // remove illegal tickets

            return 0;
        }

        private static (string field, List<int> number) ParseField(string line) {
            var splits = line.Split(":");
            var fieldName = splits[0].Trim();

            var numbers = new List<int>();
            var numberSplit = splits[1].Split("or");

            var range1 = numberSplit[0].Trim().Split("-").Select(int.Parse).ToArray();
            var range2 = numberSplit[1].Trim().Split("-").Select(int.Parse).ToArray();

            numbers.AddRange(Enumerable.Range(range1[0], range1[1] - range1[0] + 1));
            numbers.AddRange(Enumerable.Range(range2[0], range2[1] - range2[0] + 1));

            return (fieldName, numbers);
        }

        private static IEnumerable<int> ParseTickets(string input) {
            if (input.StartsWith("your") || input.StartsWith("nearby")) {
                return Enumerable.Empty<int>();
            }

            return input.Split(",").Select(int.Parse).ToArray();
        }

        private static bool DictionaryContains(IDictionary<string, List<int>> dictionary, int number) {
            return dictionary.Values.Any(list => list.Contains(number));
        }
    }
}
