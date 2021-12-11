using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode20.puzzles
{
    internal class Day1
    {
        public Day1()
        {
            part1();
        }

        private void part1()
        {
            var input = File.ReadAllLines("puzzles/Day1/input.txt").Select(x => int.Parse(x)).ToList();
            foreach(var n in input)
            {
                foreach(var c in input)
                {
                    foreach(var d in input)
                    {
                        if (n + c + d == 2020)
                        {
                            Console.WriteLine("n: " + n + "\nc: " + c + "\nd: " + d + "\nn*c*d: " + n * c * d);
                        }
                    }
                    
                }
            }
        }
    }
}
