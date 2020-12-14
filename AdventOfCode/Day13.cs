using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Day13 
    {
        public long A(long timestamp, string input)
        {
            // 939 -(939 % 59) + 59
            var buslines = input.Split(",").Where(x => x.Trim() != "x").Select(int.Parse).ToList();

            var busesWithOffset = buslines
                .Select(x => (bus: x, timestamp - (timestamp % x) + x))
                .ToList();

            var firstBus = busesWithOffset.First();
            foreach (var bus in busesWithOffset.Where(x => x.Item2 < firstBus.Item2))
            {
                firstBus = bus;
            }

            return (firstBus.Item2 - timestamp) * firstBus.bus;
        }


        public long B(string input)
        {
            var busLines = input.Split(",");
            busLines = busLines.Select(s => s.Trim()).ToArray();

            var zipped = busLines.Zip(Enumerable.Range(0, busLines.Length))
                .Where( x=> x.First.Trim() != "x")
                .Select(x => (busline: int.Parse(x.First), offset: x.Second)).ToList();

            for (long i = 0; i < long.MaxValue; i ++)
            {
                if (zipped.All( x => (i + x.offset) % x.busline == 0))
                {
                    return i;
                }
            }
            return 0;
        }
    }
}
