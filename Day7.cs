using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode {
    internal static class Day7 {

        internal static int Day7A() {
            var rules = File.ReadAllLines(Path.Combine(Program.InputsFolder, "Day7.txt"))
                .Select(ParseRule)
                .ToDictionary(x => x.rule, x => x.functions);

            var result = new List<string>();
            var foundParents = FindParents(rules, new List<string> { "shiny gold bags" }).ToList();

            while (foundParents.Any()) {
                result.AddRange(foundParents);
                foundParents = FindParents(rules, foundParents).ToList();
            }

            return result.Distinct().Count();


            static IEnumerable<string> FindParents(IDictionary<string, List<string>> rules, IEnumerable<string> terminals) {
                var foundRules = new List<string>();
                foreach (var terminal in terminals) {
                    foundRules.AddRange(rules.Where(x => x.Value.Contains(terminal)).Select(x => x.Key));
                }

                return foundRules.Distinct();
            }
        }

        internal static int Day7B() {
            var rules = File.ReadAllLines(Path.Combine(Program.InputsFolder, "Day7.txt"))
                .Select(ParseRule)
                .ToDictionary(x => x.rule, x => x.functions);

            var result = new List<string>();
            var foundProductions = FindProductions(rules, new List<string> { "shiny gold bags" }).ToList();

            while (foundProductions.Any()) {
                result.AddRange(foundProductions);
                foundProductions = FindProductions(rules, foundProductions).ToList();
            }

            return result.Count;

            static IEnumerable<string> FindProductions(IDictionary<string, List<string>> rules, IEnumerable<string> terminals) {
                var foundRules = new List<string>();
                foreach (var terminal in terminals) {
                    foundRules.AddRange(rules[terminal]);
                }

                return foundRules;
            }
        }

        private static (string rule, List<string> functions) ParseRule(string ruleInput) {
            var split = ruleInput.Split("contain");
            var ruleName = split[0].Trim();
            var rules = split[1].Trim();
            rules = rules[..^1];

            var list = new List<string>();
            if (rules == "no other bags") {
                return (ruleName, list);
            }

            foreach (var rule in rules.Split(",")) {
                var trimmedRule = rule.Trim();
                var splitIndex = trimmedRule.IndexOf(' ');
                var cardinality = trimmedRule.Substring(0, splitIndex);
                var daRule = trimmedRule.Substring(splitIndex, trimmedRule.Length - 1).Trim();

                if (!daRule.EndsWith("s")) {
                    daRule += "s";
                }
                list.AddRange(Enumerable.Range(1, int.Parse(cardinality)).Select(x => daRule));
            }

            return (ruleName, list);
        }
    }
}
