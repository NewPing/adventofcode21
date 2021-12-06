using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace adventofcode21.puzzles
{
    internal class Day5
    {
        public Day5()
        {
            hydrothermalVents1();
        }

        public void hydrothermalVents1()
        {

            //init
            var input = File.ReadAllLines("puzzles/day5/hydrothermal vents.txt");
            var vents = new List<Vent>();
            foreach (var line in input)
            {
                var coord = Regex.Matches(line, "\\d+").Select(x => int.Parse(x.Value)).ToList();
                vents.Add(new Vent(coord[0], coord[1], coord[2], coord[3]));
            }

            int[][] mineField = new int[Vent.maxX + 1][];
            for (int i = 0; i < mineField.Length; i++)
            {
                mineField[i] = new int[Vent.maxY + 1];
            }

            //mapping mineField
            foreach (var vent in vents)
            {
                if (vent.isNormal)
                {
                    if (vent.x1 != vent.x2)
                    {
                        var modifierX = vent.diffX >= 0 ? 1 : -1;
                        for (int x = vent.x1; x != vent.x2 + modifierX; x += modifierX)
                        {
                            mineField[x][vent.y1]++;
                        }
                    }
                    if (vent.y1 != vent.y2)
                    {
                        var modifierY = vent.diffY >= 0 ? 1 : -1;
                        for (int y = vent.y1; y != vent.y2 + modifierY; y += modifierY)
                        {
                            mineField[vent.x1][y]++;
                        }
                    }
                }
                else
                {
                    var modifierX = vent.diffX >= 0 ? 1 : -1;
                    var modifierY = vent.diffY >= 0 ? 1 : -1;
                    for (int x = vent.x1, y = vent.y1; x != vent.x2 + modifierX; x += modifierX, y += modifierY)
                    {
                        mineField[x][y]++;
                    }
                }
            }

            var ventCounter = 0;

            for (int y = 0; y < mineField[0].Length; y++)
            {
                for (int x = 0; x < mineField.Length; x++)
                {
                    //Console.Write(mineField[x][y]);
                    if (mineField[x][y] >= 2)
                    {
                        ventCounter++;
                    }
                }
                //Console.WriteLine();
            }

            Console.WriteLine("Number of overlapping vent points bigger then 2: " + ventCounter);
        }

        public void hydrothermalVents2()
        {

            //init
            var input = File.ReadAllLines("puzzles/day5/hydrothermal vents.txt");
            var vents = new List<Vent>();
            foreach (var line in input)
            {
                var coord = Regex.Matches(line, "\\d+").Select(x => int.Parse(x.Value)).ToList();
                vents.Add(new Vent(coord[0], coord[1], coord[2], coord[3]));
            }

            int[][] mineField = new int[Vent.maxX + 1][];
            for (int i = 0; i < mineField.Length; i++)
            {
                mineField[i] = new int[Vent.maxY + 1];
            }

            //mapping mineField
            foreach (var vent in vents)
            {
                if (vent.isNormal)
                {
                    if (vent.x1 != vent.x2)
                    {
                        var modifierX = vent.diffX >= 0 ? 1 : -1;
                        for (int x = vent.x1; x != vent.x2 + modifierX; x += modifierX)
                        {
                            mineField[x][vent.y1]++;
                        }
                    }
                    if (vent.y1 != vent.y2)
                    {
                        var modifierY = vent.diffY >= 0 ? 1 : -1;
                        for (int y = vent.y1; y != vent.y2 + modifierY; y += modifierY)
                        {
                            mineField[vent.x1][y]++;
                        }
                    }
                }
            }

            var ventCounter = 0;

            for (int y = 0; y < mineField[0].Length; y++)
            {
                for (int x = 0; x < mineField.Length; x++)
                {
                    //Console.Write(mineField[x][y]);
                    if (mineField[x][y] >= 2)
                    {
                        ventCounter++;
                    }
                }
                //Console.WriteLine();
            }

            Console.WriteLine("Number of overlapping vent points bigger then 2: " + ventCounter);
        }
    }

    public class Vent
    {
        public static int maxX = 0;
        public static int maxY = 0;
        public bool isNormal = false;
        public int x1 { get; }
        public int y1 { get; }
        public int x2 { get; }
        public int y2 { get; }
        public int diffX { get; }
        public int diffY { get; }

        public Vent(int px1, int py1, int px2, int py2)
        {
            x1 = px1;
            y1 = py1;
            x2 = px2;
            y2 = py2;

            diffX = x2 - x1;
            diffY = y2 - y1;

            maxX = x1 > maxX ? x1 : maxX;
            maxX = x2 > maxX ? x2 : maxX;
            maxY = y1 > maxY ? y1 : maxY;
            maxY = y2 > maxY ? y2 : maxY;

            if (x1 == x2 || y1 == y2)
            {
                isNormal = true;
            }
        }
    }
}
