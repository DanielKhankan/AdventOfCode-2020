using System.IO;

namespace AdventOfCode
{
    public class AdventOfCodeBase
    {
        protected string FileName { get; set; }

        public string[] Input => File.ReadAllLines(FileName);

        public string WholeFile => File.ReadAllText(FileName);

        public AdventOfCodeBase(string fileName)
        {
            FileName = fileName;
        }
    }
}