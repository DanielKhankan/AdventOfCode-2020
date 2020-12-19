using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode {
    public class Day15 {
        public long A(IEnumerable<long> startingNumbers, int wantedIndex)
        {
            return GetNumbers(startingNumbers).Take(wantedIndex).Last();
        }

        private static IEnumerable<long> GetNumbers(IEnumerable<long> startingList)
        {
            var list = new List<long>();
            list.AddRange(startingList);

            var turn = list.Count;

            foreach (var start in list)
            {
                yield return start;
            }

            do
            {
                var lastNumber = list[turn - 1];

                var lastIndex = list.LastIndexOf(lastNumber, turn - 2);
                if (lastIndex == -1)
                {
                    list.Add(0);
                    yield return 0;
                }
                else
                {
                    var difference = turn - (lastIndex + 1);
                    list.Add(difference);
                    yield return difference;
                }

                turn++;
            } while (true);
        }

        public long B(IEnumerable<long> startingNumbers, int wantedIndex)
        {
            return GetNumbersB(startingNumbers).Take(wantedIndex).Last();
        }

        private static IEnumerable<long> GetNumbersB(IEnumerable<long> startingList)
        {
            var dictionary = new Dictionary<long, long[]>();

            var turn = 1;
            var lastNumber = 0L;

            foreach (var start in startingList)
            {
                dictionary.Add(start, new long[] {0, turn});
                yield return start;
                lastNumber = start;
                turn++;
            }

            do
            {
                if (dictionary[lastNumber].Any( x => x == 0))
                {
                    yield return 0;
                    lastNumber = 0;

                    dictionary[0] = new[] {dictionary[lastNumber].Max(), turn};
                }
                else
                {
                    var difference = dictionary[lastNumber][1] - dictionary[lastNumber][0];

                    if (!dictionary.ContainsKey(difference))
                    {
                        dictionary[difference] = new long[] {0, turn};
                    }
                    else
                    {
                        dictionary[difference] = new[] {dictionary[difference].Max(), turn};
                    }

                    yield return difference;
                    lastNumber = difference;
                }

                turn++;
            } while (true);
        }
    }
}
