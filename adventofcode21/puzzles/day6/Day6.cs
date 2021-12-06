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
            var lanternfishes = Regex.Matches(input, "\\d+").Select(x => new Lanternfish(int.Parse(x.Value))).ToList();

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
            var initalFishes = Regex.Matches(input, "\\d+").Select(x => int.Parse(x.Value)).ToList();

            long[] fishesByDay = new long[9]; //fishes[9] is tmp day
            for (int i = 0; i < initalFishes.Count; i++)
            {
                fishesByDay[initalFishes[i]]++; 
            }

            var daysToCompute = 256;
            for (int i = 0; i < daysToCompute; i++)
            {
                var tmp = fishesByDay[0];

                fishesByDay[0] = fishesByDay[1];
                fishesByDay[1] = fishesByDay[2];
                fishesByDay[2] = fishesByDay[3];
                fishesByDay[3] = fishesByDay[4];
                fishesByDay[4] = fishesByDay[5];
                fishesByDay[5] = fishesByDay[6];
                fishesByDay[6] = fishesByDay[7];
                fishesByDay[7] = fishesByDay[8];

                fishesByDay[6] += tmp;
                fishesByDay[8] = tmp;

                Console.WriteLine($"After { i + 1 } day: " + fishesByDay.Sum());
            }

            Console.WriteLine($"Number of lanternfish after { daysToCompute } days: " + fishesByDay.Sum());
        }

    }

    public class Lanternfish
    {
        public int internalCounter;

        public Lanternfish(int initalDays = 8)
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
