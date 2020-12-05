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
        }
    }
}
