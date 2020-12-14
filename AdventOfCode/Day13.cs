using System.Linq;
using System.Numerics;

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


        public BigInteger B(string input)
        {
            var busLines = input.Split(",");
            busLines = busLines.Select(s => s.Trim()).ToArray();

            var zipped = busLines.Zip(Enumerable.Range(0, busLines.Length))
                .Where( x=> x.First.Trim() != "x")
                .Select(x => (busline: int.Parse(x.First), offset: x.Second)).ToList();

            var firstResult = B2(zipped[1], 0, zipped[0].busline);
            var interval = new BigInteger(zipped[0].busline * zipped[1].busline);

            var index = 2;

            if (zipped.Count == 2)
            {
                return firstResult;
            }

            while (index < zipped.Count)
            {
                firstResult = B2(zipped[index], firstResult, interval);
                interval = zipped[index].busline * interval;
                index++;
            } 

            return firstResult;
        }

        private BigInteger B2((long bus, long offset) bus, BigInteger start, BigInteger interval)
        {
            BigInteger i = start;

            while ((i + bus.offset) % bus.bus != 0)
            {
                i += interval;
            }

            return i;
        }
    }
}
