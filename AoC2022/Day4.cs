using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2022
{
    internal class Day4
    {
        public void Run()
        {
            var lines = File.ReadAllLines("input/input_d4.txt");
            int fullRanges = 0;
            int overlap = 0;
            foreach (var line in lines)
            {
                var s = line.Split(",");
                List<(int, int)> ranges = new List<(int, int)>();
                foreach (var range in s)
                {
                    var x = range.Split("-");
                    ranges.Add((int.Parse(x[0]), int.Parse(x[1])));
                }

                if (ranges[0].Item1 <= ranges[1].Item1 && ranges[0].Item2 >= ranges[1].Item2) { fullRanges++; }
                else if (ranges[0].Item1 >= ranges[1].Item1 && ranges[0].Item2 <= ranges[1].Item2) { fullRanges++; }


                if(Enumerable.Range(ranges[0].Item1, ranges[0].Item2 - ranges[0].Item1 + 1).Intersect(Enumerable.Range(ranges[1].Item1, ranges[1].Item2 - ranges[1].Item1 + 1)).Count() > 0)
                {
                    overlap++;
                }
            }

            Console.WriteLine($"Full ranges: {fullRanges}");
            Console.WriteLine($"Overlap : {overlap}");
        }
    }
}
