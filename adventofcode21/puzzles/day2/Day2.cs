using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace adventofcode21.puzzles
{
    internal class Day2
    {
        public Day2()
        {
            dive1();
            dive2();
        }

        public void dive1()
        {
            var depth = 0;
            var horizontalPos = 0;

            var instructions = File.ReadAllLines("puzzles/day2/dive.txt");

            foreach (var instruction in instructions)
            {
                var steps = int.Parse(Regex.Match(instruction, "\\d+").Value);
                if (instruction.StartsWith("forward"))
                {
                    horizontalPos += steps;
                } else if (instruction.StartsWith("down"))
                {
                    depth += steps;
                } else
                {
                    depth -= steps;
                }
            }
            Console.WriteLine("mutli. of depth and horizontal position: " + depth * horizontalPos);
        }

        public void dive2()
        {
            var aim = 0;
            var depth = 0;
            var horizontalPos = 0;

            var instructions = File.ReadAllLines("dive.txt");

            foreach (var instruction in instructions)
            {
                var steps = int.Parse(Regex.Match(instruction, "\\d+").Value);
                if (instruction.StartsWith("forward"))
                {
                    horizontalPos += steps;
                    depth += aim * steps;
                    //horizontalPos += steps;
                }
                else if (instruction.StartsWith("down"))
                {
                    aim += steps;
                    //depth += steps;
                }
                else
                {
                    aim -= steps;
                    //depth -= steps;
                }
            }
            Console.WriteLine("mutli. of depth and horizontal position: " + depth * horizontalPos);
        }
    }
}
