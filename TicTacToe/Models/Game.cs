using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe.Models
{
    public class Game
    {

        private static int _current = 0;
        private static string _winner = string.Empty;
        private static bool _blocked = false;
        private static int _moveCount = 0;
        static int[,] board = new int[3, 3]
            {
                {
                    -1,-1,-1
                },
                {
                    -1,-1,-1
                },
                {
                    -1,-1,-1
                }
            };

        public static void Move(int move)
        {
            if (_blocked)
                return;
            if (_moveCount == 9 || move > 9 || move < 1)
            {
                throw new InvalidOperationException("Invalid Move!");
            }
            int row = 0;
            int column = 0;
            GetIndex(move, ref row, ref column);
            if (board[row, column] != -1)
            {
                throw new InvalidOperationException("Invalid Move!");
            }
            board[row, column] = _current;
            _moveCount++;
            if (_current == 0)
                _current = 1;
            else
                _current = 0;
            checkWinner();
        }

        public static string GetStatus()
        {
            if (_moveCount == 9 && String.IsNullOrEmpty(_winner))
            {
                return "DRAW";
            }
            if (String.IsNullOrEmpty(_winner))
            {
                return "IN PROGRESS";
            }
            else
            {
                return _winner + " Wins!";
            }
        }

        public static void GetIndex(int input, ref int row, ref int column)
        {
            if (input == 1 || input == 4 || input == 7)
                column = 0;
            else if (input == 2 || input == 5 || input == 8)
                column = 1;
            else if (input == 3 || input == 6 || input == 9)
                column = 2;
            if (input <= 3)
            {
                row = 0;
            }
            else if (input > 3 && input <= 6)
            {
                row = 1;
            }
            else
            {
                row = 2;
            }
        }

        public static void checkWinner()
        {
            int zeroCount = 0;
            int oneCount = 0;
            for (int i = 0; i < 3; i++)
            {
                zeroCount = 0;
                oneCount = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == 0)
                        zeroCount++;
                    else if (board[i, j] == 1)
                        oneCount++;
                }
                if (zeroCount == 3)
                {
                    _blocked = true;
                    _winner = "Player 1";
                    return;
                }
                if (oneCount == 3)
                {
                    _blocked = true;
                    _winner = "Player 2";
                    return;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                zeroCount = 0;
                oneCount = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (board[j, i] == 0)
                        zeroCount++;
                    else if (board[j, i] == 1)
                        oneCount++;
                }
                if (zeroCount == 3)
                {
                    _blocked = true;
                    _winner = "Player 1";
                    return;
                }
                if (oneCount == 3)
                {
                    _blocked = true;
                    _winner = "Player 2";
                    return;
                }
            }
            zeroCount = 0;
            oneCount = 0;
            for (int i = 0, j = 0; i < 3; i++, j++)
            {
                if (board[i, j] == 0)
                    zeroCount++;
                else if (board[i, j] == 1)
                    oneCount++;
            }
            if (zeroCount == 3)
            {
                _blocked = true;
                _winner = "Player 1";
                return;
            }
            if (oneCount == 3)
            {
                _blocked = true;
                _winner = "Player 2";
                return;
            }
            zeroCount = 0;
            oneCount = 0;
            for (int i = 0, j = 2; i < 3; i++, j--)
            {
                if (board[i, j] == 0)
                    zeroCount++;
                else if (board[i, j] == 1)
                    oneCount++;
            }
            if (zeroCount == 3)
            {
                _blocked = true;
                _winner = "Player 1";
                return;
            }
            if (oneCount == 3)
            {
                _blocked = true;
                _winner = "Player 2";
                return;
            }
        }

    }
}
