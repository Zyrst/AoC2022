using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AoC2022
{
    internal class Day5
    {
        public void Run()
        {
            var lines = File.ReadAllLines("input/input_d5.txt").ToList();
            var input = lines.Take(8).ToArray();
            List<List<string>> stacks = new List<List<string>>() { };
            for (int i = 0; i <= input.Length; i++)
                stacks.Add(new List<string>());
            
            foreach(var line in input)
            {
                var split = line.Chunk(4).Select(x => new String(x)).ToArray();
                var z = 0;
                foreach(var x in split)
                {
                    var y = x.Replace("[", "").Replace("]", "").Trim();
                    //Console.WriteLine(y);
                    if (!String.IsNullOrEmpty(y))
                        stacks[z].Add(y);
                    z++;
                }

            }
            foreach (var l in stacks)
                l.Reverse();
                
            

            lines.RemoveRange(0, 10);    // Yeetus deletus

            int moveCnt = 0;
            foreach(var move in lines)
            {
                var moves = 0;
                List<string> fromList, toList;
                var f = move.Where(Char.IsDigit).Select(x =>  int.Parse(x.ToString())).ToArray();
                if (f.Length == 4)
                {
                    moves = int.Parse($"{f[0]}{f[1]}");
                    fromList = stacks[f[2] - 1];
                    toList = stacks[f[3] - 1];
                }
                else
                {
                    moves = f[0];
                    fromList = stacks[f[1] - 1];
                    toList = stacks[f[2] - 1];
                }

                var taken = fromList.TakeLast(moves);
                toList.AddRange(taken);
                fromList.RemoveRange(fromList.Count - moves, moves);
                moveCnt++;
            }

            foreach(var l in stacks)
                Console.Write(l.Last());
            
        }
    }
}
