using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode21.puzzles
{
    internal class Day1
    {
        public Day1()
        {
            sweep1();
            sweep2();
        }

        public void sweep1()
        {
            var sweeps = File.ReadAllLines("Sonar Sweep.txt");
            var increases = 0;
            var decreases = 0;
            var noChanges = 0;
            for (int i = 1; i < sweeps.Length; i++)
            {
                Console.Write(sweeps[i]);
                if (int.Parse(sweeps[i]) > int.Parse(sweeps[i - 1]))
                {
                    Console.WriteLine(" increased");
                    increases++;
                }
                else if (int.Parse(sweeps[i]) < int.Parse(sweeps[i - 1]))
                {
                    Console.WriteLine(" decreased");
                    decreases++;
                }
                else
                {
                    Console.WriteLine(" no change");
                    noChanges++;
                }
            }
            Console.WriteLine("increases: " + increases);
            Console.WriteLine("decreases: " + decreases);
            Console.WriteLine("no changes: " + noChanges);
        }

        public void sweep2()
        {
            var sweeps = File.ReadAllLines("Sonar Sweep.txt");
            var increases = 0;
            var decreases = 0;
            var noChanges = 0;
            var sum = 0;
            int oldSum;
            for (int i = 2; i < sweeps.Length -1; i++)
            {
                oldSum = sum;
                sum = int.Parse(sweeps[i - 1]) + int.Parse(sweeps[i]) + int.Parse(sweeps[i + 1]);

                Console.Write(sweeps[i]);
                if (sum > oldSum)
                {
                    Console.WriteLine(" increased");
                    increases++;
                } else if (sum < oldSum)
                {
                    Console.WriteLine(" decreased");
                    decreases++;
                } else
                {
                    Console.WriteLine(" no change");
                    noChanges++;
                }
            }
            Console.WriteLine("increases: " + increases);
            Console.WriteLine("decreases: " + decreases);
            Console.WriteLine("no changes: " + noChanges);
        }
    }
}
