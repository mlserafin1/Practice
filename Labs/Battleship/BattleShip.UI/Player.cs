using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    public class Player
    {
        

        public string Name;
        public bool victoryCheck = false;

        public int GetX(string s)
        {
            int x = -111;
            
            string letterToInt;
            if (s == "")
            {
                Console.WriteLine("Not a valid X coordinate! Please re-enter your coordinate.");
                x = -1345;
                return x;
            }
            letterToInt = s.Substring(0, 1);
            switch (letterToInt)
            {
                case "A":
                case "a":
                    x = 1;   //changed a-j to 1-10 instead of 0-9 to account for letter and number array labels
                    return x;
                case "B":
                case "b":
                    x = 2;
                    return x;
                case "C":
                case "c":
                    x = 3;
                    return x;
                case "D":
                case "d":
                    x = 4;
                    return x;
                case "E":
                case "e":
                    x = 5;
                    return x;
                case "F":
                case "f":
                    x = 6;
                    return x;
                case "G":
                case "g":
                    x = 7;
                    return x;
                case "H":
                case "h":
                    x = 8;
                    return x;
                case "I":
                case "i":
                    x = 9;
                    return x;
                case "J":
                case "j":
                    x = 10;
                    return x;
                default:
                    Console.WriteLine("Not a valid X coordinate! Please re-enter your coordinate.");
                    x = -1345;
                    return x;
            }
        }

        public int GetY(string s)
        {
            int y;
            if (s == "")
            {
                Console.WriteLine("Not a valid Y coordinate! Please re-enter your coordinate.");
                y = -1345;
                return y;
            }
            int.TryParse(s.Substring(1), out y);
            if (y < 1 || y > 10)
            {
                Console.WriteLine("Not a valid Y coordinate! Please re-enter your coordinate.");
                y = -1345;
            }
            return y;
        }

        public void SetShips(Player player, Board board)
        {
            
            ConsoleIO output = new ConsoleIO();

            bool validCoord = true;
            bool placeCheck = true;
            
            foreach (var sType in Enum.GetValues(typeof(ShipType)))
            {
                    
                    string tempCoord = null;
                     int x = 0;
                     int y = 0;
                while (placeCheck)
                {
                    while (validCoord == true)
                    {
                        Console.Clear();
                        player.DrawBoard();
                        Console.WriteLine($"{player.Name}, enter a starting coordinate for your {(ShipType) sType}.");
                        Console.WriteLine("Destroyer = 2 slots, Submarine = 3, Cruiser = 3, Battleship = 4, Carrier = 5.");
                        tempCoord = Console.ReadLine();
                        x = player.GetX(tempCoord);
                        y = player.GetY(tempCoord);
                        if (x != -1345 && y != -1345) //coord check, x from getx invalid, get x return x as -2. Same for get y.
                        {
                            validCoord = false;
                        }
                        else
                        {
                            Thread.Sleep(1000);
                        }
                    }
                     validCoord = true; //reset validcoord
                

                    var direction = ShipDirection.Up;
                    string readDirection;
                    while (true)
                    {
                        Console.WriteLine(
                            $"Enter a direction for your {(ShipType)sType} to be placed, starting from your entered coordinate.");
                        Console.WriteLine("U = up, D = down, R = right, L = left.");

                        readDirection = Console.ReadLine();
                        if (readDirection == "U" || readDirection == "u")
                        {
                            direction = ShipDirection.Up;
                            break;
                        }
                        else if (readDirection == "D" || readDirection == "d")
                        {
                            direction = ShipDirection.Down;
                            break;
                        }
                        else if (readDirection == "R" || readDirection == "r")
                        {
                            direction = ShipDirection.Right;
                            break;
                        }
                        else if (readDirection == "L" || readDirection == "l")
                        {
                            direction = ShipDirection.Left;
                            break;
                        }
                        else
                            Console.WriteLine("Not a valid direction, please enter a valid direction.");
                    }


                    PlaceShipRequest p = new PlaceShipRequest()
                    {
                        Coordinate = new Coordinate(x, y),
                        Direction = direction,
                        ShipType = (ShipType) sType
                    };
                    var response = board.PlaceShip(p);
                    if (response == ShipPlacement.NotEnoughSpace)
                    {
                        Console.WriteLine($"Not enough space to place {(ShipType) sType}. Please try again.");
                        Thread.Sleep(1000);
                    }
                    else if (response == ShipPlacement.Overlap)
                    {
                        Console.WriteLine($"{(ShipType) sType} overlaps with another ship. Please try again.");
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Console.WriteLine($"{(ShipType) sType} placed!");
                        Thread.Sleep(1000);
                        Console.Clear();
                        placeCheck = false;
                    }

                }
                placeCheck = true; //reset placecheck
            }
        }

        public void ShootIt(Player player,Board board) //pass in enemy board!!!!!
        {
            
            
            bool validCoord = true;
            int x = 0;
            int y = 0;
            string tempCoord = null;
            bool check = true;

            

            while (check == true)
            {
                while (validCoord == true)
                {
                    
                    Console.Clear();
                    
                    player.DrawBoard();
                    Console.WriteLine($"{player.Name}, enter a coordinate to fire at.");

                    tempCoord = Console.ReadLine();
                    x = player.GetX(tempCoord);
                    y = player.GetY(tempCoord);

                    if (x != -1345 && y != -1345) //coord check, x from getx invalid, get x return x as -2. Same for get y.
                    {
                        validCoord = false;
                    }
                    else
                    {
                        Thread.Sleep(1000);
                    }

                }
                validCoord = true; //reset validcoord

                var coordinate = new Coordinate(x, y);
                var response = board.FireShot(coordinate);
                if (response.ShotStatus == ShotStatus.Duplicate)
                {
                    Console.WriteLine($"{player.Name}, you already fired at that coordinate.");
                    Thread.Sleep(1000);

                }
                else if (response.ShotStatus == ShotStatus.Victory)
                {
                    Console.WriteLine($"{player.Name} wins!!!");
                    victoryCheck = true;
                    check = false;
                }
                else if (response.ShotStatus == ShotStatus.HitAndSunk)
                {
                    Console.WriteLine($"Sunk {response.ShipImpacted}!");
                    boardOfPlayer[x, y] = "  H  ";
                    
                    check = false;
                }
                else if (response.ShotStatus == ShotStatus.Hit)
                {
                    Console.WriteLine("Hit!");
                    boardOfPlayer[x, y] = "  H  ";
                    
                    check = false;
                }
                else if (response.ShotStatus == ShotStatus.Miss)
                {
                    Console.WriteLine("Miss!");
                    boardOfPlayer[x, y] = "  M  ";
                    
                    check = false;
                }
            }
        }


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
            boardOfPlayer[1, 0] = "   A ";
            boardOfPlayer[2, 0] = "   B ";
            boardOfPlayer[3, 0] = "   C ";
            boardOfPlayer[4, 0] = "   D ";
            boardOfPlayer[5, 0] = "   E ";
            boardOfPlayer[6, 0] = "   F ";
            boardOfPlayer[7, 0] = "   G ";
            boardOfPlayer[8, 0] = "   H ";
            boardOfPlayer[9, 0] = "   I ";
            boardOfPlayer[10, 0] = "   J ";
            for (int i = 1; i < boardOfPlayer.GetLength(0); i++)
            {
                for (int j = 1; j < boardOfPlayer.GetLength(1); j++)
                {
                    boardOfPlayer[i, j] = "  O  ";
                }
            }
        }

        public void DrawBoard()
        {
            
            Console.WriteLine();

            for (int i = 0; i < boardOfPlayer.GetLength(0); i++)
            {
                for (int j = 0; j < boardOfPlayer.GetLength(1); j++)
                {
                    if (boardOfPlayer[i,j] == "  H  " && j == 10)
                    {
                        Console.ForegroundColor=ConsoleColor.Red;
                        Console.Write($"{boardOfPlayer[i, j]}");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.WriteLine();
                        continue;
                    }
                    else if(boardOfPlayer[i, j] == "  H  ")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"{boardOfPlayer[i, j]}");
                        Console.ResetColor();
                        continue;
                    }
                    else if (boardOfPlayer[i, j] == "  M  " && j == 10)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($"{boardOfPlayer[i, j]}");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.WriteLine();
                        continue;
                    }
                    else if (boardOfPlayer[i, j] == "  M  ")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($"{boardOfPlayer[i, j]}");
                        Console.ResetColor();
                        continue;
                    }
                    Console.Write($"{boardOfPlayer[i, j]}");
                    if (j == 10)
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                    }
                }
            }
            
        }

    }
}
