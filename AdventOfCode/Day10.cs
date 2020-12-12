using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode {
    public class Day10 : AdventOfCodeBase {
        public Day10(string fileName) : base(fileName) { }

        // 2176
        public long A()
        {
            var allNumbers = Input.Select(int.Parse).ToList();

            if (!allNumbers.Contains(0))
            {
                allNumbers.Add(0);
            }

            allNumbers.Add(allNumbers.Max() +3);
            allNumbers.Sort();

            var counter = (new List<int>(), new List<int>());
            foreach (var number in allNumbers)
            {
                if (allNumbers.Contains(number+1))
                {
                    counter.Item1.Add(number+1);
                }else if (allNumbers.Contains(number + 3))
                {
                    counter.Item2.Add(number + 3);
                }
            }

            return counter.Item1.Count * counter.Item2.Count;
        }

        // 18512297918464
        public long B()
        {
            var allNumbers = Input.Select(int.Parse).ToList();
            if (!allNumbers.Contains(0))
            {
                allNumbers.Add(0);
            }

            allNumbers.Add(allNumbers.Max() + 3);
            allNumbers.Sort();

            var dictionary = new Dictionary<long, long>();

            var counter = GetCount(allNumbers[^1]);

            long GetCount(int number)
            {
                if (number == 0)
                {
                    return 1;
                }

                if (!allNumbers.Contains(number))
                {
                    return 0;
                }

                if (dictionary.ContainsKey(number))
                {
                    return dictionary[number];
                }

                var dic3 = GetCount(number - 3);
                var dic2 = GetCount(number - 2);
                var dic1 = GetCount(number - 1);

                dictionary[number] = dic1 + dic2 + dic3;
                return dictionary[number];
            }
            
            return counter;
        }
    }
}
