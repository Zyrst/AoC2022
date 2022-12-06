using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2022
{
    internal class Day6
    {
        public void Run()
        {
            var line = File.ReadAllLines("input/input_d6.txt").Single();
            Solve(4, line);
            Solve(14, line);
        }

        private void Solve(int number, string line)
        {
            var rolling = line.Take(number).ToList();

            var count = number;
            foreach (var l in line.Skip(number))
            {
                count++;
                rolling.Add(l);
                if (count > number)
                    rolling.RemoveAt(0);
                if (new string(rolling.ToArray()).Distinct().Count() == number)
                {
                    break;
                }

            }
            Console.WriteLine(count);
        }
    }
}
