using System;

namespace AdventOfCode {

    public static class Program
    {
        internal const string InputsFolder = "Inputs";

        static void Main()
        {
           Console.WriteLine($"Day1:\tA[{Day01.Day1A() == 224436}]\tB[{Day01.Day1B() == 303394260}]");
           Console.WriteLine($"Day2:\tA[{Day02.Day2A() == 666}]\tB[{Day02.Day2B() == 670}]");
           Console.WriteLine($"Day3:\tA[{Day03.Day3A() == 171}]\tB[{Day03.Day3B() == 1206576000}]");
           Console.WriteLine($"Day4:\tA[{Day04.Day4A() == 170}]\tB[{Day04.Day4B() == 103}]");
           Console.WriteLine($"Day5:\tA[{Day05.Day5A() == 994}]\tB[{Day05.Day5B() == 741}]");
           Console.WriteLine($"Day6:\tA[{Day06.Day6A() == Day06.Day6A2() && Day06.Day6A2() == 6585}]\tB[{Day06.Day6B() == Day06.Day6B2() && Day06.Day6B2() == 3276}]");
           Console.WriteLine($"Day7:\tA[{Day07.Day7A() == 192}]\tB[{Day07.Day7B() == 12128}]");
           Console.WriteLine($"Day8:\tA[{Day08.Day8A() == 1654}]\tB[{Day08.Day8B() == 833}]");
           Console.WriteLine($"Day9:\tA[{Day09.Day9A() == 70639851}]\tB[{Day09.Day9B() == 8249240}]");
           Console.WriteLine($"Day10:\tA[{Day10.Day10A() == 2176}]\tB[{Day10.Day10B() == 18512297918464}]");
           Console.WriteLine($"Day11:\tA[{Day11.Day11A() == 2316}]\tB[{Day11.Day11B() == 2128}]");
           Console.WriteLine($"Day12:\tA[{Day12.Day12A() == 1186}]\tB[{Day12.Day12B() == 47806}]");
        }
    }
}
