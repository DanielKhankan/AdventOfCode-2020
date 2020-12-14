using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Day14 : AdventOfCodeBase
    {
        private const char FloatingBit = 'X';
        private const char ZeroBit = '0';
        private const char OneBit = '1';
        public Day14(string fileName) : base(fileName) { }

        public long A()
        {
            var memory = new Dictionary<long, long>();

            var bitMask = string.Empty;
            foreach (var line in Input) {

                if (line.StartsWith("mask"))
                {
                    bitMask = line.Split("=")[1].Trim();
                }
                else
                {
                    var (address, number) = Parse(line);

                    var binaryNumber = Convert.ToString(number, 2);
                    binaryNumber = binaryNumber.PadLeft(36).Replace(" ", "0");

                    memory[address] = ApplyMask(bitMask, binaryNumber);
                }
            }

            return  memory.Values.Sum();
        }

        public long B()
        {
            var memory = new Dictionary<long, long>();

            var bitMask = string.Empty;
            foreach (var line in Input)
            {
                if (line.StartsWith("mask"))
                {
                    bitMask = line.Split("=")[1].Trim();
                }
                else
                {
                    var (address, number) = Parse(line);

                    var binaryAddress = Convert.ToString(address, 2);
                    binaryAddress = binaryAddress.PadLeft(36).Replace(" ", "0");

                    var array = binaryAddress.ToCharArray();
                    for (var i = 0; i < binaryAddress.Length; i++)
                    {
                        if (bitMask[i] != ZeroBit)
                        {
                            array[i] = bitMask[i];
                        }
                    }

                    var addresses = ApplyMask2(bitMask, new string(array));

                    foreach (var a in addresses)
                    {
                        memory[a] = number;
                    }
                }
            }

            return memory.Values.Sum();
        }

        private static IEnumerable<long> ApplyMask2(string bitMask, string binaryNumber)
        {
            var array = binaryNumber.ToCharArray();

            var list = new List<long>();

            var firstIndex = array.Count(x => x == FloatingBit);
            if (firstIndex > 0)
            {
                var array2 = new char[array.Length];
                Array.Copy(array, array2, array.Length);

                for (var i = 0; i < array.Length; i++)
                {
                    if (array[i] == FloatingBit)
                    {
                        array[i] = ZeroBit;
                        array2[i] = OneBit;
                        break;
                    }
                }

                list.AddRange(ApplyMask2(bitMask, new string(array)));
                list.AddRange(ApplyMask2(bitMask, new string(array2)));
            }
            else
            {
                list.Add(Convert.ToInt64(binaryNumber, 2));
            }

            return list;
        }

        private static long ApplyMask(string bitMask, string binaryNumber)
        {
            var array = binaryNumber.ToCharArray();
            for (var i = 0; i< binaryNumber.Length; i++)
            {
                if (bitMask[i] != FloatingBit)
                {
                    array[i] = bitMask[i];
                }
            }
           
            return Convert.ToInt64(new string(array), 2);
        }

        private static (long adress, long number) Parse(string s)
        {
            var split = s.Split("=");
            var address = int.Parse(split[0].Replace("mem[", "").Replace("]", "").Trim());
            var number = int.Parse(split[1].Trim());

            return (address, number);
        }
    }
}
