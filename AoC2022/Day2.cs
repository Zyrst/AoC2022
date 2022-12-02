using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2022
{

    internal class Day2
    {
        public void Run()
        {
            var lines = File.ReadAllLines("input/input_d2.txt");
            // x = rock, y = paper, z = scissors
            // a = rock, b = paper, c = scissors
            int sum = 0;
            foreach (var line in lines)
            {
                var s = line.Split(" ");
                if ((s[0] == "A" && s[1] == "X") || (s[0] == "B" && s[1] == "Y") || (s[0] == "C" && s[1] == "Z"))
                {
                    sum += GetValue(s[1]);
                    sum += 3;
                }
                else if ((s[0] == "A" && s[1] == "Y") || (s[0] == "C" && s[1] == "X") || (s[0] == "B" && s[1] == "Z"))
                {
                    sum += GetValue(s[1]);
                    sum += 6;
                }
                else
                {
                    sum += GetValue(s[1]);
                }
            }

            Console.WriteLine($"Winning sum: {sum}");
            var sumNew = 0;
            // X = Lose, Y = Draw, Z = Win
            foreach (var line in lines)
            {
                var s = line.Split(" ");
                switch (s[0])
                {
                    case "A":
                        switch (s[1])
                        {
                            case "X":
                                sumNew += GetValue("Z");
                                break;
                            case "Y":
                                sumNew += GetValue("X");
                                sumNew += 3;
                                break;
                            case "Z":
                                sumNew += GetValue("Y");
                                sumNew += 6;
                                break;
                        }
                        break;
                    case "B":
                        switch (s[1])
                        {
                            case "X":
                                sumNew += GetValue("X");
                                break;
                            case "Y":
                                sumNew += GetValue("Y");
                                sumNew += 3;
                                break;
                            case "Z":
                                sumNew += GetValue("Z");
                                sumNew += 6;
                                break;
                        }
                        break;
                    case "C":
                        switch (s[1])
                        {
                            case "X":
                                sumNew += GetValue("Y");
                                break;
                            case "Y":
                                sumNew += GetValue("Z");
                                sumNew += 3;
                                break;
                            case "Z":
                                sumNew += GetValue("X");
                                sumNew += 6;
                                break;
                        }
                        break;
                }
            }

            Console.WriteLine($"New Winning: {sumNew}");
        }

        private int GetValue(string s)
        {
            if (s == "X")
                return 1;
            else if (s == "Y")
                return 2;
            else if (s == "Z")
                return 3;
            return 0;
        }
        
    }
}
