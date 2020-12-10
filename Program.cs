﻿using System;

namespace AdventOfCode {

    public static class Program
    {
        internal const string InputsFolder = "Inputs";

        static void Main()
        {
           Console.WriteLine($"Day1:\tA[{Day1.Day1A() == 224436}]\tB[{Day1.Day1B() == 303394260}]");
           Console.WriteLine($"Day2:\tA[{Day2.Day2A() == 666}]\tB[{Day2.Day2B() == 670}]");
           Console.WriteLine($"Day3:\tA[{Day3.Day3A() == 171}]\tB[{Day3.Day3B() == 1206576000}]");
           Console.WriteLine($"Day4:\tA[{Day4.Day4A() == 170}]\tB[{Day4.Day4B() == 103}]");
           Console.WriteLine($"Day5:\tA[{Day5.Day5A() == 994}]\tB[{Day5.Day5B() == 741}]");
           Console.WriteLine($"Day6:\tA[{Day6.Day6A() == Day6.Day6A2() && Day6.Day6A2() == 6585}]\tB[{Day6.Day6B() == Day6.Day6B2() && Day6.Day6B2() == 3276}]");
           Console.WriteLine($"Day7:\tA[{Day7.Day7A() == 192}]\tB[{Day7.Day7B() == 12128}]");
           Console.WriteLine($"Day8:\tA[{Day8.Day8A() == 1654}]\tB[{Day8.Day8B() == 833}]");
           Console.WriteLine($"Day9:\tA[{Day9.Day9A() == 70639851}]\tB[{Day9.Day9B() == 8249240}]");
           Console.WriteLine($"Day10:\tA[{Day10.Day10A() == 2176}]\tB[{Day10.Day10B() == 18512297918464}]");
        }
    }
}
