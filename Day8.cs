using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode {
    internal static class Day8
    {
        private const string Nop = "nop";
        private const string Acc = "acc";
        private const string Jmp = "jmp";

        private class ProgramEnvironment
        {
            public int Accumulator { get; set; }
            public int InstructionPointer { get; set; }
        }

        internal static int Day8A()
        {
            var program = File.ReadAllLines(Path.Combine(Program.InputsFolder, "Day8.txt"))
                .Select(Parse)
                .ToList();

            return Run(new ProgramEnvironment(), program).Accumulator;
        }

        private static (int Accumulator, bool didTerminate) Run(ProgramEnvironment environment, IReadOnlyList<Action<ProgramEnvironment>> program)
        {
            var visitedMemoryLocations = new HashSet<int>();
            while (true) {
                var previousAcc = environment.Accumulator;

                program[environment.InstructionPointer](environment);

                if (environment.InstructionPointer == program.Count - 1) {
                    return (environment.Accumulator, true);
                }

                if (visitedMemoryLocations.Contains(environment.InstructionPointer)) {
                    return (previousAcc, false);
                }

                visitedMemoryLocations.Add(environment.InstructionPointer);
            }
        }

        internal static int Day8B()
        {
            var input = File.ReadAllLines(Path.Combine(Program.InputsFolder, "Day8.txt"));

            foreach (var program in AllPossiblePrograms(input))
            {
                var (accumulator, didTerminate) = Run(new ProgramEnvironment(), program);
                if (didTerminate)
                {
                    return accumulator;
                }
            }
            
            return 666;
        }

        private static IEnumerable<IReadOnlyList<Action<ProgramEnvironment>>> AllPossiblePrograms(IReadOnlyCollection<string> input)
        {
            yield return input.Select(Parse).ToList();

            var lineToChange = 0;
            while (lineToChange < input.Count)
            {
                var program = new List<string>(input);
                var (op, _) = Scan(program[lineToChange]);

                switch (op) {
                    case Nop:
                        program[lineToChange] = program[lineToChange].Replace(Nop, Jmp);
                        yield return program.Select(Parse).ToList();
                        break;
                    case Jmp:
                        program[lineToChange] = program[lineToChange].Replace(Jmp, Nop);
                        yield return program.Select(Parse).ToList();
                        break;
                }

                lineToChange++;
            }
        }

        private static Action<ProgramEnvironment> Parse(string expression)
        {
            var (op, argument) = Scan(expression);

            return (op, argument) switch
            {
                (Nop, _) => x => x.InstructionPointer += 1,
                (Acc, var arg) => x =>
                {
                    x.Accumulator += arg;
                    x.InstructionPointer += 1;
                },
                (Jmp, var arg) => x => x.InstructionPointer += arg,
                _ => throw new ArgumentException($"unknown operation {op}")
            };
        }

        private static (string op, int argument) Scan(string expression)
        {
            expression = expression.Trim();
            var op = expression.Substring(0, 3);
            var argument = int.Parse(expression.Substring(4));

            return (op, argument);
        }
    }
}
