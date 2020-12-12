using System.Linq;

namespace AdventOfCode {
    public class Day01 : AdventOfCodeBase {

        public Day01(string fileName) : base(fileName) { }

        // 303394260
        public long B()
        {
            var list = Input.Select(int.Parse).ToList();
            
            var (item1, item2, item3) = list.Cartesian(list, list).First(x => x.Item1 + x.Item2 + x.Item3 == 2020);
            return item1 * item2 * item3;
        }

        // 224436
        public long A()
        {
            var list = Input.Select(int.Parse).ToList();

            var (item1, item2) = list.Cartesian(list).First(x => x.Item1 + x.Item2 == 2020);

            return item1 * item2;
        }
    }
}
