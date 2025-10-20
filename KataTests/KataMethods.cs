using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataTests
{
    public interface IKataMethods
    {
        char? CheckBoard();
        char? checkForWin(int a, int b, int c);
        List<string> DisplayBoard();
        int GetPosition();
        string GetRow(int j);
    }

    public class KataMethods : IKataMethods
    {
        private static Random Random = new Random(); // a static so we get random values
        public char?[] board = new char?[9]; // positions 0-8 represent board positions 1-9
        private List<int[]> lines = new List<int[]> // all possible winning lines
        {
            new int[]{1,2,3 }, new int[]{4,5,6}, new int[]{7,8,9},
            new int[]{1,4,7}, new int[]{2,5,8}, new int[]{3,6,9},
            new int[]{1,5,9}, new int[]{3,5,7}
        };
        public int GetPosition()
        {
            return Random.Next(9);
        }
        // Check the board for a winner
        public char? CheckBoard()
        {
            foreach (var line in lines)
            {
                var result = checkForWin(line[0], line[1], line[2]);
                if (result.HasValue)
                    return result.Value;

            }
            return null;
        }
        // Check if positions a, b, c are a winning line
        public char? checkForWin(int a, int b, int c)
        {
            if (board[a - 1].HasValue && board[b - 1].HasValue && board[c - 1].HasValue)
                if ((board[a - 1] == board[b - 1]) && board[b - 1] == board[c - 1])
                    return board[b - 1];
                else return null;
            return null;
        }
        // Display the board as a list of strings
        public List<string> DisplayBoard()
        {
            var boardDisplay = new List<string>();
            string RowSpacer = "-------";
            boardDisplay.Add(RowSpacer);
            for (int i = 0; i < 3; i++)
            {
                int j = i * 3;
                string row = GetRow(j);
                boardDisplay.Add(row);
                boardDisplay.Add(RowSpacer);
            }
            return boardDisplay;
        }
        // Get a row string for row starting at index j
        public string GetRow(int j)
        {
            string row = "|";
            for (int i = 0; i < 3; i++)
            {
                int k = j + i;
                row += board[k].HasValue ? board[k] : ' ' ;
                row += "|";
            }
            return row;
        }
    }
}
