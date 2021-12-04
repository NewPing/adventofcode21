using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace adventofcode21.puzzles
{
    internal class Day4
    {
        public Day4()
        {
            board1();
            board2();
        }

        public void board1()
        {
            var boardsData = File.ReadAllLines("puzzles/day4/bingo boards.txt").ToList();
            var draws = getDraws(boardsData);
            var boards = getBoards(boardsData);
            
            foreach(var draw in draws)
            {
                foreach(var board in boards)
                {
                    board.mark(draw);
                }
                foreach (var board in boards)
                {
                    var boardState = board.getBoardState();
                    if (boardState.Item1)
                    {
                        Console.WriteLine($"Winning Board Score: { boardState.Item2 * draw }");
                        return;
                    }
                }
            }
        }

        public void board2()
        {
            var boardsData = File.ReadAllLines("puzzles/day4/bingo boards.txt").ToList();
            var draws = getDraws(boardsData);
            var boards = getBoards(boardsData);

            var winningBoards = new List<Board>();
            
            foreach (var draw in draws)
            {
                foreach (var board in boards)
                {
                    board.mark(draw);
                }
                foreach (var board in boards)
                {
                    var boardState = board.getBoardState();
                    if (boardState.Item1 && board.winningDraw.Equals(-1))
                    {
                        board.winningDraw = draw;
                        board.winningScore = boardState.Item2;
                        winningBoards.Add(board);
                    }
                }
            }

            var lastWinningBoard = winningBoards.Last();
            Console.WriteLine($"Last Winning Board Score: { lastWinningBoard.winningScore * lastWinningBoard.winningDraw }");
        }

        private List<int> getDraws(List<string> boardsData)
        {
            return boardsData[0].Split(',').Select(x => int.Parse(x)).ToList();
        }

        private List<Board> getBoards(List<string> boardsData)
        {
            var boards = new List<Board>();
            var board = new Board();

            boardsData.RemoveAt(0);
            boardsData.RemoveAt(0);

            foreach (var line in boardsData)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    board.data.Add(Regex.Matches(line, "\\d+").Select(x => new KeyValuePair<int, bool>(int.Parse(x.Value), false)).ToDictionary(pair => pair.Key, pair => pair.Value));
                }
                else
                {
                    boards.Add(board);
                    board = new Board();
                }
            }

            return boards;
        }
    }

    public class Board
    {
        public List<Dictionary<int, bool>> data = new List<Dictionary<int, bool>>();
        public int winningDraw = -1;
        public int winningScore = -1;

        public void mark(int number)
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].ContainsKey(number))
                {
                    data[i][number] = true;
                }
            }
        }

        public Tuple<bool, int> getBoardState()
        {
            var markings = getMarkedArray();

            //horizontal
            for (int i = 0; i < markings.Length; i++)
            {
                var horizontalMarkings = 0;
                for (var j = 0; j < markings[i].Length; j++)
                {
                    if (markings[i][j])
                    {
                        horizontalMarkings++;
                    }
                }
                if (horizontalMarkings.Equals(5))
                {
                    return new Tuple<bool, int>(true, getUnmarkedSum());
                }
            }

            //vertical
            for (int i = 0; i < markings[0].Length; i++)
            {
                var verticalMarkings = 0;
                for (var j = 0; j < markings.Length; j++)
                {
                    if (markings[j][i])
                    {
                        verticalMarkings++;
                    }
                }
                if (verticalMarkings.Equals(5))
                {
                    return new Tuple<bool, int>(true, getUnmarkedSum());
                }
            }

            return new Tuple<bool, int>(false, 0); ;
        }

        private bool[][] getMarkedArray()
        {
            bool[][] markedArray = new bool[5][];
            for (int i = 0; i < markedArray.Length; i++)
            {
                markedArray[i] = new bool[5];
            }
            for (int j = 0; j < data.Count; j++)
            {
                var lineVal = data[j].ToList();
                for (int i = 0; i < lineVal.Count; i++)
                {
                    markedArray[j][i] = lineVal[i].Value;
                }
            }
            return markedArray;
        }

        private int getUnmarkedSum()
        {
            int sum = 0;

            foreach (var line in data)
            {
                var lineVal = line.ToList();
                for (int i = 0; i < lineVal.Count; i++)
                {
                    if (!lineVal[i].Value)
                    {
                        sum += lineVal[i].Key;
                    }
                }
            }

            return sum;
        }
    }
}
