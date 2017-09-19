using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    public class PlayerBoard
    {
        string[,] boardOfPlayer = new string[11, 11];

        public void PopulateBoard()
        {
            boardOfPlayer[0, 0] = "     ";
            boardOfPlayer[0, 1] = "  1  ";
            boardOfPlayer[0, 2] = "  2  ";
            boardOfPlayer[0, 3] = "  3  ";
            boardOfPlayer[0, 4] = "  4  ";
            boardOfPlayer[0, 5] = "  5  ";
            boardOfPlayer[0, 6] = "  6  ";
            boardOfPlayer[0, 7] = "  7  ";
            boardOfPlayer[0, 8] = "  8  ";
            boardOfPlayer[0, 9] = "  9  ";
            boardOfPlayer[0, 10] = "  10  ";
            boardOfPlayer[1, 0] = "  A  ";
            boardOfPlayer[2, 0] = "  B  ";
            boardOfPlayer[3, 0] = "  C  ";
            boardOfPlayer[4, 0] = "  D  ";
            boardOfPlayer[5, 0] = "  E  ";
            boardOfPlayer[6, 0] = "  F  ";
            boardOfPlayer[7, 0] = "  G  ";
            boardOfPlayer[8, 0] = "  H  ";
            boardOfPlayer[9, 0] = "  I  ";
            boardOfPlayer[10, 0] = "  J  ";
            for (int i = 1; i < boardOfPlayer.GetLength(0); i++)
            {
                for (int j = 1; j < boardOfPlayer.GetLength(1); j++)
                {
                    boardOfPlayer[i,j] = "  O  ";
                }
            }
        }

        public void SetBoard(Board board, int x, int y)
        {
            Console.Clear();
            Console.WriteLine();

            for (int i = 0; i < boardOfPlayer.GetLength(0); i++)
            {
                for (int j = 0; j < boardOfPlayer.GetLength(1); j++)
                {
                    Console.Write($"{boardOfPlayer[i,j]}");
                    if (j == 10)
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                    }
                }
            }
            Console.ReadKey();
        }

        

            
        }
}
