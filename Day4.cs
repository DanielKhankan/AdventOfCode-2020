using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode {
    internal static class Day4 {
        // 170
        internal static int Day4A() {
            var requiredFields = new List<string> { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };

            var passports = Day4Parse();
            var counter = (passports.Where(password => requiredFields.TrueForAll(password.ContainsKey))).Count();
            return counter;
        }

        // 103
        internal static int Day4B() {
            var requiredFields = new List<(string, Predicate<string>)>
            {
                ("byr", x => MinMaxString(x, 1920,2002)),
                ("iyr", x => MinMaxString(x, 2010, 2020)),
                ("eyr", x => MinMaxString(x, 2020, 2030)),
                ("hgt", x =>
                        {
                            if (x.EndsWith("in")) return MinMaxString(x.Remove(x.Length - 2, 2), 59, 76);
                            return x.EndsWith("cm") && MinMaxString(x.Remove(x.Length - 2, 2), 150, 193);
                        }),
                ("hcl", x=> Regex.IsMatch(x, "^#([0-9a-f]{6})$")),
                ("ecl", x=> Regex.IsMatch(x, @"^\b(amb|blu|brn|gry|grn|hzl|oth)\b$")),
                ("pid", x=> Regex.IsMatch(x, "^[0-9]{9}$"))
            };

            static bool MinMaxString(string input, int lowerLimit, int upperLimit) {
                return int.TryParse(input, out var number) && MinMax(number, lowerLimit, upperLimit);
            }

            static bool MinMax(int number, int lowerLimit, int upperLimit) {
                return number >= lowerLimit && number <= upperLimit;
            }

            var passports = Day4Parse();
            var counter = passports.Count(password => requiredFields.TrueForAll(x => password.ContainsKey(x.Item1) && x.Item2(password[x.Item1])));
            return counter;
        }

        private static IEnumerable<Dictionary<string, string>> Day4Parse() {
            var wholeFile = File.ReadAllText(Path.Combine(Program.InputsFolder, "Day4.txt"));

            var passports = wholeFile.Split("\r\n\r\n");

            foreach (var passport in passports) {
                var nameValueCollection = new Dictionary<string, string>();
                foreach (var field in passport.Split(new char[] { ' ', '\r' })) {
                    var fieldNameValue = field.Split(":");
                    nameValueCollection.Add(fieldNameValue[0].Trim(), fieldNameValue[1].Trim());
                }

                yield return nameValueCollection;
            }
        }
    }
}



