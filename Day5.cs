﻿using System;
using System.IO;
using System.Linq;

namespace AdventOfCode {
    internal static class Day5
    {
        internal static int Day5A()
        {
            var wholeFile = File.ReadAllLines(Path.Combine(Program.InputsFolder, "Day5.txt"));

            return wholeFile.Max(GetSeatId);
        }

        internal static int Day5B()
        {
            var allSeatIds = File.ReadAllLines(Path.Combine(Program.InputsFolder, "Day5.txt")).Select(GetSeatId).ToList();
            allSeatIds.Sort();

            var currentSeatId = allSeatIds[0];
            var index = 1;
            while (index < allSeatIds.Count)
            {
                var difference = allSeatIds[index] - currentSeatId;
                if (difference > 1)
                {
                    return currentSeatId + 1;
                }
                currentSeatId = allSeatIds[index];
                index++;
            }

            return 666;
        }

        private static int GetSeatId(string inputString)
        {
            var encodedRow = inputString.Substring(0, 7);
            var encodedCol = inputString.Substring(7, 3);
            var rowId = GetRowId((0, 127), encodedRow, 'F', 0).Item1;
            var coldId = GetRowId((0, 7), encodedCol, 'L', 0).Item1;

            return rowId * 8 + coldId;
        }

        private static (int, int) GetRowId((int, int) range, string input, char lowerHalfCharacter, int index)
        {
            var pivot = ((float)range.Item1 + (float)range.Item2) / 2;
            var newRange = input[index] == lowerHalfCharacter ? (range.Item1, (int)Math.Floor(pivot)) : ((int)Math.Ceiling(pivot), range.Item2);

            if (newRange.Item2 - newRange.Item1 > 0)
            {
                return GetRowId(newRange, input, lowerHalfCharacter, index + 1);
            }

            return newRange;
        }
    }
}
