using System;

namespace ConsoleApp1 {

    public static class Program
    {
        internal const string InputsFolder = "Inputs";

        static void Main()
        {
           Console.WriteLine($"Day1: A[{Day1.Day1A()==224436}]\tB[{Day1.Day1B()==303394260}]");
           Console.WriteLine($"Day2: A[{Day2.Day2A()==666}]\tB[{Day2.Day2B()==670}]");
           Console.WriteLine($"Day3: A[{Day3.Day3A()==171}]\tB[{Day3.Day3B()==1206576000}]");
        }
    }
}
