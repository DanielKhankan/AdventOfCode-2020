using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public class Day13 
    {
        public long A(long timestamp, string input)
        {
            // 939 -(939 % 59) + 59
            var buslines = input.Split(",").Where(bus => bus.Trim() != "x").Select(bus => int.Parse(bus)).ToList();

            var bus = buslines.Select(bus => (bus, timestamp - (timestamp % bus) + bus));

            var thebus = bus.First();
            foreach (var ss in bus.Where(ss => ss.Item2 < thebus.Item2))
            {
                thebus = ss;
            }

            return (thebus.Item2 - timestamp) * thebus.bus;
        }


        public long B(string input)
        {
            var busLines = input.Split(",");
            busLines = busLines.Select(s => s.Trim()).ToArray();

            var zipped = busLines.Zip(Enumerable.Range(0, busLines.Length)).Where( x=> x.First.Trim() != "x").Select(x => (int.Parse(x.First), x.Second)).ToList();

            for (long i = 0; i < long.MaxValue; i += zipped.First().Item1)
            {
                if (zipped.All( x => ((i + x.Second) % x.Item1) == 0))
                {
                    return i;
                }
            }
            return 0;
        }
    }
}
