using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2022
{
    internal class Day3
    {
        public void Run()
        {
            var lines = File.ReadAllLines("input/input_d3.txt");
            var sum = 0;
            foreach(var line in lines)
            {
                var first = line.Substring(0, line.Length / 2);
                var second = line.Substring(line.Length / 2);
                var common = first.Intersect(second).ToArray();
                var val = CharToVal(common[0]);
                sum += val;
            }

            Console.WriteLine(sum);

            sum = 0;
            // sum = lines.Chunk(3).Select(items => items[0].Intersect(items[1]).Intersect(items[2]).Single()).Sum(CharToVal);  // Nice version on reddit, chuck splits in to the 3 pieces I wanted
            for (int i = 0; i < lines.Length; i += 3)
            {
                var items = lines.Skip(i).Take(3).ToArray();
                var common = items[0].Intersect(items[1]).Intersect(items[2]).ToArray();

                var val = CharToVal(common[0]);
                sum += val;
            }
            Console.WriteLine(sum);
        }

        private int CharToVal(char c)
        {
            var t = c % 32;
            var val = Char.IsUpper(c) ? (t + 26) : t;
            return val;
        }
    }
}
