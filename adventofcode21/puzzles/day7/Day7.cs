using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace adventofcode21.puzzles
{
    internal class Day7
    {
        public Day7()
        {
            //crabPuzzle1();
            crabPuzzle2();
        }

        public void crabPuzzle1()
        {
            var input = File.ReadAllText("puzzles/day7/crab position.txt");
            var crabs = Regex.Matches(input, "\\d+").Select(x => int.Parse(x.Value)).ToList();

            var leastFuelUsage = int.MaxValue;
            var leastStartingPos = 0;
            for (int startingPos = crabs.Min(); startingPos < crabs.Max(); startingPos++)
            {
                int fuelUsage = 0;
                foreach (var crabPos in crabs)
                {
                    fuelUsage += Math.Abs(startingPos - crabPos);
                }
                leastStartingPos = leastFuelUsage > fuelUsage ? startingPos : leastStartingPos;
                leastFuelUsage = leastFuelUsage > fuelUsage ? fuelUsage : leastFuelUsage;
                Console.WriteLine(fuelUsage);
            }
            Console.WriteLine($"least amout of fuel usage at position: { leastStartingPos } with { leastFuelUsage } fuel used.");
        }

        public void crabPuzzle2()
        {
            var input = File.ReadAllText("puzzles/day7/crab position.txt");
            var crabs = Regex.Matches(input, "\\d+").Select(x => int.Parse(x.Value)).ToList();

            var leastFuelUsage = int.MaxValue;
            var leastStartingPos = 0;
            for (int startingPos = crabs.Min(); startingPos < crabs.Max(); startingPos++)
            {
                int fuelUsage = 0;
                foreach (var crabPos in crabs)
                {
                    fuelUsage += getComplicatedFuelUsage(Math.Abs(startingPos - crabPos));
                }
                leastStartingPos = leastFuelUsage > fuelUsage ? startingPos : leastStartingPos;
                leastFuelUsage = leastFuelUsage > fuelUsage ? fuelUsage : leastFuelUsage;
                Console.WriteLine(fuelUsage);
            }
            Console.WriteLine($"least amout of fuel usage at position: { leastStartingPos } with { leastFuelUsage } fuel used.");
        }

        private int getComplicatedFuelUsage(int stepsToTravel)
        {
            var fuelUsage = 0;

            for (int i = 0; i < stepsToTravel; i++)
            {
                fuelUsage += (i + 1);
            }

            return fuelUsage;
        }
    }
}
