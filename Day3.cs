using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode {
    internal static class Day3 {

        // 171
        internal static int Day3A()
        {
            var playground = Day3Parse();

            var counter = 0;
            var x = 0;
            var y = 0;

            while (y < playground.yDimension)
            {
                if (playground.field[x, y])
                {
                    counter++;
                }

                x += 3;
                y += 1;

                x %= playground.xDimension;
            }

            return counter;
        }

        // 1206576000
        internal static int Day3B()
        {
            var playground = Day3Parse();
            var counters = new List<int>
            {
                Traverse(playground, x => x + 1, y => y + 1).Count(coord => playground.field[coord.x, coord.y]),
                Traverse(playground, x => x + 3, y => y + 1).Count(coord => playground.field[coord.x, coord.y]),
                Traverse(playground, x => x + 5, y => y + 1).Count(coord => playground.field[coord.x, coord.y]),
                Traverse(playground, x => x + 7, y => y + 1).Count(coord => playground.field[coord.x, coord.y]),
                Traverse(playground, x => x + 1, y => y + 2).Count(coord => playground.field[coord.x, coord.y])
            };

            var result = counters.Aggregate(1, (x, y) => x*y);

            static IEnumerable<(int x, int y)> Traverse((bool[,] field, int xDimension, int yDimension) valueTuple, Func<int, int> xIncrease, Func<int, int> yIncrease)
            {
                var x = 0;
                var y = 0;
                while (y < valueTuple.yDimension)
                {
                    yield return (x, y);

                    x = xIncrease(x);
                    y = yIncrease(y);

                    x %= valueTuple.xDimension;
                }
            }

            return result;
        }

        private static (bool[,] field, int xDimension, int yDimension) Day3Parse()
        {
            var lines = File.ReadAllLines(Path.Combine(Program.InputsFolder, "Day3.txt"));

            int xDimension = lines[0].Length;
            int yDimension = lines.Length;

            var result = new bool[xDimension,yDimension];

            var y = 0;
            foreach (var line in lines)
            {
                var x = 0;
                foreach (var c in line)
                {
                    result[x, y] = c == '#';
                    x++;
                }

                y++;
            }

            return (result, xDimension, yDimension);
        }
    }
}
