using System;

namespace AdventOfCode {

    public static class Program
    {
        internal const string InputsFolder = "Inputs";

        static void Main()
        {
           Console.WriteLine($"Day1: A[{Day1.Day1A() == 224436}]\tB[{Day1.Day1B() == 303394260}]");
           Console.WriteLine($"Day2: A[{Day2.Day2A() == 666}]\tB[{Day2.Day2B() == 670}]");
           Console.WriteLine($"Day3: A[{Day3.Day3A() == 171}]\tB[{Day3.Day3B() == 1206576000}]");
           Console.WriteLine($"Day4: A[{Day4.Day4A() == 170}]\tB[{Day4.Day4B() == 103}]");
           Console.WriteLine($"Day5: A[{Day5.Day5A() == 994}]\tB[{Day5.Day5B() == 741}]");
           Console.WriteLine($"Day6: A[{Day6.Day6A() == Day6.Day6A2() && Day6.Day6A2() == 6585}]\tB[{Day6.Day6B() == Day6.Day6B2() && Day6.Day6B2() == 3276}]");
           Console.WriteLine($"Day7: A[{Day7.Day7A() == 192}]\tB[{Day7.Day7B() == 12128}]");
           Console.WriteLine($"Day8: A[{Day8.Day8A() == 1654}]\tB[{Day8.Day8B() == 833}]");
        }
    }
}
