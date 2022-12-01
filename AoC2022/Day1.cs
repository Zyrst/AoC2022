using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AoC2022
{
    internal class Day1
    {

        public void Run()
        {
            var file = File.ReadAllLines("input/input_d1.txt");
            var elfs = new List<int>() { 0 };
            foreach(var line in file)
            {
                if(line == "")
                {
                    elfs.Add(0);
                }
                else
                {
                    elfs[elfs.Count - 1] += int.Parse(line);
                }
            }

            var max_elf = elfs.Max();
            elfs.Sort();
            elfs.Reverse();
            var three_elfs_sum = elfs.Take(3).Sum();
            Console.WriteLine($"Max elf: {max_elf}");
            Console.WriteLine($"Total three: {three_elfs_sum}");
        }
    }
}
