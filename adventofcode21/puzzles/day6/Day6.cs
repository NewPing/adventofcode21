using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace adventofcode21.puzzles
{
    internal class Day6
    {
        public Day6()
        {
            //lanternfish1();
            lanternfish2();
        }

        public void lanternfish1()
        {
            var input = File.ReadAllText("puzzles/day6/lanternfish.txt");
            var lanternfishes = Regex.Matches(input, "\\d+").Select(x => new Lanternfish(byte.Parse(x.Value))).ToList();

            Console.Write("Initial state: ");
            foreach(var fish in lanternfishes)
            {
                Console.Write(fish.internalCounter + ",");
            }
            Console.WriteLine();

            var daysToCompute = 80;
            for (int i = 0; i < daysToCompute; i++)
            {
                var newFishes = new List<Lanternfish>();
                foreach(var fish in lanternfishes)
                {
                    if (fish.internalCounter == 0)
                    {
                        newFishes.Add(new Lanternfish());
                    }
                    fish.update();
                }
                lanternfishes = lanternfishes.Concat(newFishes).ToList();

                //Console.Write($"After { i +1} days: ");
                //foreach (var fish in lanternfishes)
                //{
                //    Console.Write(fish.internalCounter + ",");
                //}
                //Console.WriteLine();
            }

            Console.WriteLine($"Number of lanternfish after { daysToCompute } days: " + lanternfishes.Count);
        }

        public void lanternfish2()
        {
            var input = File.ReadAllText("puzzles/day6/lanternfish.txt");
            List<byte> lanternfishes = Regex.Matches(input, "\\d+").Select(x => byte.Parse(x.Value)).ToList();

            Console.Write("Initial state: ");
            foreach (var fish in lanternfishes)
            {
                Console.Write(fish + ",");
            }
            Console.WriteLine();

            var daysToCompute = 265;
            for (int i = 0; i < daysToCompute; i++)
            {
                Console.WriteLine($"Currently on day { i + 1 }");
                var newFishes = new List<byte>();
                for (int fish = 0; fish < lanternfishes.Count; fish++)
                {
                    if (lanternfishes[fish] == 0)
                    {
                        newFishes.Add(0);
                    }
                    lanternfishes[fish] = update(lanternfishes[fish]);
                }
                lanternfishes = lanternfishes.Concat(newFishes).ToList();
            }

            Console.WriteLine($"Number of lanternfish after { daysToCompute } days: { lanternfishes.Count }");
        }

        public byte update(byte val)
        {
            if (val == 0)
            {
                val = 7;
            }

            return val--;
        }
    }

    public class Lanternfish
    {
        public byte internalCounter;

        public Lanternfish(byte initalDays = 8)
        {
            internalCounter = initalDays;
        }

        public void update()
        {
            if (internalCounter == 0)
            {
                internalCounter = 7;
            }

            internalCounter--;
        }
    }

}
