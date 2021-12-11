using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode21.puzzles
{
    internal class Day10
    {
        Dictionary<char, char> openToCloseChar = new Dictionary<char, char>()
            {
                { '(', ')' },
                { '[', ']' },
                { '{', '}' },
                { '<', '>' }
            };
        Dictionary<char, int> pointsPerWrongChar = new Dictionary<char, int>()
            {
                { '(', 3 },
                { '[', 57 },
                { '{', 1197 },
                { '<', 25137 }
            };
        Dictionary<char, int> pointsPerAutocompletedChar = new Dictionary<char, int>()
            {
                { '(', 1 },
                { '[', 2 },
                { '{', 3 },
                { '<', 4 }
            };

        public Day10()
        {
            part1();
            part2();
        }

        public void part1()
        {
            var input = File.ReadAllLines("puzzles/day10/input.txt");

            var wrongCharacters = new List<char>();
            foreach(var line in input)
            {
                var openingCharacters = new Stack<char>();
                foreach(var c in line)
                {
                    if (openToCloseChar.ContainsKey(c))
                    {
                        //is opening character
                        openingCharacters.Push(c);
                    }
                    else
                    {
                        //is closing character
                        if (openingCharacters.Peek().Equals(getKeyByValueChar(c)))
                        {
                            //closing char is a match for the last opening character in openingCharacters
                            openingCharacters.Pop();
                        }
                        else
                        {
                            wrongCharacters.Add(c);
                            break;
                        }
                    }
                }
            }

            var totalScore = 0;
            foreach(var c in wrongCharacters)
            {
                totalScore += pointsPerWrongChar[getKeyByValueChar(c)];
            }

            Console.WriteLine("Total Syntax Error Score: " + totalScore);
        }

        public void part2()
        {
            var input = File.ReadAllLines("puzzles/day10/input.txt");

            var totalScores = new List<long>();
            foreach (var line in input)
            {
                var openingCharacters = getMissingOpeningChars(line);
                if (openingCharacters.Count > 0)
                {
                    //this is the actual start of part2
                    long lineScore = 0;
                    foreach (var c in openingCharacters)
                    {
                        lineScore *= 5;
                        lineScore += pointsPerAutocompletedChar[c];
                    }
                    totalScores.Add(lineScore);
                }
            }

            totalScores.Sort();

            Console.WriteLine("Middle autocompletion Score: " + totalScores[(int)(totalScores.Count / 2 + 0.5)]);
        }

        private List<char> getMissingOpeningChars(string line)
        {
            var openingCharacters = new Stack<char>();
            //doing this to filter out every line of part1
            foreach (var c in line)
            {
                if (openToCloseChar.ContainsKey(c))
                {
                    //is opening character
                    openingCharacters.Push(c);
                }
                else
                {
                    //is closing character
                    if (openingCharacters.Peek().Equals(getKeyByValueChar(c)))
                    {
                        //closing char is a match for the last opening character in openingCharacters
                        openingCharacters.Pop();
                    }
                    else
                    {
                        return new List<char>();
                    }
                }
            }
            return openingCharacters.ToList();
        }

        private char getKeyByValueChar(char c)
        {
            return openToCloseChar.First(x => x.Value == c).Key;
        }
    }
}
