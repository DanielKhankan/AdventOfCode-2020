using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    public class Day14 : AdventOfCodeBase
    {
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
                    var (adress, number) = Parse(line);

                    var binarynumber = Convert.ToString(number, 2);
                    binarynumber = binarynumber.PadLeft(36).Replace(" ", "0");

                    memory[adress] = ApplyMask(bitMask, binarynumber);
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
                    var (adress, number) = Parse(line);

                    var binaryadress = Convert.ToString(adress, 2);
                    binaryadress = binaryadress.PadLeft(36).Replace(" ", "0");

                    var array = binaryadress.ToCharArray();
                    for (var i = 0; i < binaryadress.Length; i++)
                    {
                        if (bitMask[i] != '0')
                        {
                            array[i] = bitMask[i];
                        }
                    }

                    var adresses = ApplyMask2(bitMask, new string(array));

                    foreach (var a in adresses)
                    {
                        memory[a] = number;
                    }
                }
            }

            return memory.Values.Sum();
        }

        private List<long> ApplyMask2(string bitMask, string binaryNumber)
        {
            var array = binaryNumber.ToCharArray();

            var list = new List<long>();

            //for (var i = 0; i < binaryNumber.Length; i++)
            //{
            //    if (bitMask[i] != '0')
            //    {
            //        array[i] = bitMask[i];
            //    }
            //}

            var firstIndex = array.Count(x => x == 'X');
            if (firstIndex > 0)
            {
                var array2 = new char[array.Length];
                Array.Copy(array, array2, array.Length);

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == 'X')
                    {
                        array[i] = '0';
                        array2[i] = '1';
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

        private long ApplyMask(string bitMask, string binaryNumber)
        {
            var array = binaryNumber.ToCharArray();
            for (var i = 0; i< binaryNumber.Length; i++)
            {
                if (bitMask[i] != 'X')
                {
                    array[i] = bitMask[i];
                }
            }

           
            return Convert.ToInt64(new string(array), 2);
        }

        private (long adress, long number) Parse(string s)
        {
            var split = s.Split("=");
            var adress = int.Parse(split[0].Replace("mem[", "").Replace("]", "").Trim());
            var number = int.Parse(split[1].Trim());

            return (adress, number);
        }
    }
}
