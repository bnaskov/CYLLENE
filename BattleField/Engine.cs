﻿using System;

namespace BattleField
{

    public class Engine
    {
        //private int initialMineCount = 0;
        //private string[,] battleField;

        private int N { get; set; }
        private int InitialMineCount { get; set; }
        private string[,] BattleField { get; set; }
        public int DestroyedMines { get; set; }
        
        public Engine()
        {
            this.InitialMineCount = 0;
            this.DestroyedMines = 0;
        }

        private static int RandomNumber(int min, int max)
        {
            var random = new Random();
            return random.Next(min, max);
        }

       

        private void FillInCells()
        {
            while (this.InitialMineCount + 1 <= 0.3 * this.N * this.N)
            {
                var row = RandomNumber(0, this.N - 1);
                var column = RandomNumber(0, this.N - 1);

                if (this.BattleField[row, column] == "-")
                {
                    this.BattleField[row, column] = Convert.ToString(RandomNumber(1, 6));
                    this.InitialMineCount++;

                    //if (this.InitialMineCount >= 0.15 * this.N * this.N) //TODO(kyamaliev): Randomize the number of mines!
                    //{
                    //    //(kyamaliev) - what is the purpose of the following code?
                    //    // originally was int stopFilling = RandomNumber(0, 1); , but in this case stopFilling can never be 1
                    //    int stopFilling = RandomNumber(0, 2);
                    //    if (stopFilling == 1)
                    //    {
                    //        break;
                    //    }
                    //}
                }
            }
        }

        private static void InvalidMove()
        {
            Console.WriteLine("Invalid Move!");
            Console.WriteLine();
        }

        private void DrawTable()
        {
            Console.Write("   ");
            for (var k = 0; k < this.N; k++)
            {
                Console.Write(k + " ");
            }

            Console.WriteLine();
            Console.Write("   ");
            for (var k = 0; k < this.N; k++)
            {
                Console.Write("--");
            }

            Console.WriteLine();

            for (var i = 0; i < this.N; i++)
            {
                Console.Write(i + "| ");
                for (var j = 0; j < this.N; j++)
                {
                    Console.Write(this.BattleField[i, j] + " ");
                }

                Console.WriteLine();
                Console.WriteLine();
            }
        }

        public void DetonateMine(int row, int column)
        {

            //if ((this.BattleField[row, column] == "X") || ((this.BattleField[row, column]) == "-"))
            //{
            //    cellNumber = 0;
            //}
            
            int cellNumber = Convert.ToInt32(this.BattleField[row, column]);
            
            if (cellNumber > 5 || cellNumber < 0)
            {
                InvalidMove();
            }
            this.Bomb(row, column, cellNumber); this.DrawTable(); this.DestroyedMines++;
        }

        public bool GameOver()
        {
            return this.DestroyedMines == this.InitialMineCount;
        }

        //(kyamaliev)validator
        private bool OutOfAreaCoordinates(int row, int column)
        {
            if ((row >= 0) && (row <= this.N - 1) && (column >= 0) && (column <= this.N - 1))
            {
                return false;
            }
            return true;
        }

        private bool IsNumber(int row, int column)
        {
            if ((this.BattleField[row, column] != "X") && (this.BattleField[row, column] != "-"))
            {
                return false;
            }
            return true;
        }

        private void Bomb(int row, int column, int number)
        {

            this.BattleField[row, column] = "X";
            this.DestroyedMines++;

            switch (number)
            {
                case 1:
                    if (this.OutOfAreaCoordinates(row - 1, column - 1) && this.IsNumber(row - 1, column - 1))
                    {
                        this.DestroyedMines++;
                        this.BattleField[row - 1, column - 1] = "X";
                    }

                    if (this.OutOfAreaCoordinates(row + 1, column - 1) && this.IsNumber(row + 1, column - 1))
                    {
                        this.DestroyedMines++; this.BattleField[row + 1, column - 1] = "X";
                    }

                    if (this.OutOfAreaCoordinates(row - 1, column + 1) && this.IsNumber(row - 1, column + 1))
                    {
                        this.DestroyedMines++; this.BattleField[row - 1, column + 1] = "X";
                    }

                    if (this.OutOfAreaCoordinates(row + 1, column + 1) && this.IsNumber(row + 1, column + 1))
                    {
                        this.DestroyedMines++; this.BattleField[row + 1, column + 1] = "X";
                    }

                    break;

                case 2:
                    this.Bomb(row, column, 1);

                    if (this.OutOfAreaCoordinates(row - 1, column) && this.IsNumber(row - 1, column))
                    {
                        this.DestroyedMines++; this.BattleField[row - 1, column] = "X";
                    }

                    if (this.OutOfAreaCoordinates(row, column - 1) && this.IsNumber(row, column - 1))
                    {
                        this.DestroyedMines++; this.BattleField[row, column - 1] = "X";
                    }

                    if (this.OutOfAreaCoordinates(row, column + 1) && this.IsNumber(row, column + 1))
                    {
                        this.DestroyedMines++; this.BattleField[row, column + 1] = "X";
                    }

                    if (this.OutOfAreaCoordinates(row + 1, column) && this.IsNumber(row + 1, column))
                    {
                        this.DestroyedMines++; this.BattleField[row + 1, column] = "X";
                    }

                    break;
                case 3:
                    this.Bomb(row, column, 2);

                    if (this.OutOfAreaCoordinates(row - 2, column) && this.IsNumber(row - 2, column))
                    {
                        this.DestroyedMines++; this.BattleField[row - 2, column] = "X";
                    };

                    if (this.OutOfAreaCoordinates(row, column - 2) && this.IsNumber(row, column - 2))
                    {
                        this.DestroyedMines++; this.BattleField[row, column - 2] = "X";
                    };

                    if (this.OutOfAreaCoordinates(row, column + 2) && this.IsNumber(row, column + 2))
                    {
                        this.DestroyedMines++; this.BattleField[row, column + 2] = "X";
                    };

                    if (this.OutOfAreaCoordinates(row + 2, column) && this.IsNumber(row + 2, column))
                    {
                        this.DestroyedMines++; this.BattleField[row + 2, column] = "X";
                    };

                    break;
                case 4:
                    Bomb(row, column, 3);

                    if (this.OutOfAreaCoordinates(row - 1, column - 2) && this.IsNumber(row - 1, column - 2))
                    {
                        this.DestroyedMines++; this.BattleField[row - 1, column - 2] = "X";
                    };

                    if (this.OutOfAreaCoordinates(row + 1, column - 2) && this.IsNumber(row + 1, column - 2))
                    {
                        this.DestroyedMines++; this.BattleField[row + 1, column - 2] = "X";
                    };

                    if (this.OutOfAreaCoordinates(row - 2, column - 1) && this.IsNumber(row - 2, column - 1))
                    {
                        this.DestroyedMines++; this.BattleField[row - 2, column - 1] = "X";
                    };

                    if (this.OutOfAreaCoordinates(row + 2, column - 1) && this.IsNumber(row + 2, column - 1))
                    {
                        this.DestroyedMines++; this.BattleField[row + 2, column - 1] = "X";
                    };

                    if (this.OutOfAreaCoordinates(row - 1, column + 2) && this.IsNumber(row - 1, column + 2))
                    {
                        this.DestroyedMines++; this.BattleField[row - 1, column + 2] = "X";
                    };

                    if (this.OutOfAreaCoordinates(row + 1, column + 2) && this.IsNumber(row + 1, column + 2))
                    {
                        this.DestroyedMines++; this.BattleField[row + 1, column + 2] = "X";
                    };

                    if (this.OutOfAreaCoordinates(row - 2, column + 1) && this.IsNumber(row - 2, column + 1))
                    {
                        this.DestroyedMines++; this.BattleField[row - 2, column + 1] = "X";
                    };

                    if (this.OutOfAreaCoordinates(row + 2, column + 1) && this.IsNumber(row + 2, column + 1))
                    {
                        this.DestroyedMines++; this.BattleField[row + 2, column + 1] = "X";
                    };
                    break;

                case 5: Bomb(row, column, 4);

                    if (this.OutOfAreaCoordinates(row - 2, column - 2) && this.IsNumber(row - 2, column - 2))
                    {
                        this.DestroyedMines++; this.BattleField[row - 2, column - 2] = "X";
                    };

                    if (this.OutOfAreaCoordinates(row + 2, column - 2) && this.IsNumber(row + 2, column - 2))
                    {
                        this.DestroyedMines++; this.BattleField[row + 2, column - 2] = "X";
                    };

                    if (this.OutOfAreaCoordinates(row + 2, column + 2) && this.IsNumber(row + 2, column + 2))
                    {
                        this.DestroyedMines++; this.BattleField[row + 2, column + 2] = "X";
                    };

                    if (this.OutOfAreaCoordinates(row - 2, column + 2) && this.IsNumber(row - 2, column + 2))
                    {
                        this.DestroyedMines++; this.BattleField[row - 2, column + 2] = "X";
                    };

                    break;
                default:
                    InvalidMove();
                    break;
            }
        }

        private int ReadBoardSize()
        {
            //int n;
            do
            {
                Console.Write("Please enter field size (1..9): ");
                try
                {
                    this.N = int.Parse(Console.ReadLine());
                    Validator.ValidateBoardSize(this.N);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Incorrect input. Please try again.");
                    continue;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Incorrect input. Please try again.");

                    continue;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Incorrect input. Please try again.");

                    continue;
                }

                break;
            } while (true);
            return this.N;
        }

        public static int[] ReadUserInput()
        {
            int[] coords = new int[2];

            //(kyamaliev) TODO: should do it without loop here, too difficult to rethrow exceptions
            do
            {
                try
                {
                    Console.Write("Please enter cell coordinates (x y): ");
                    string inputRowAndColumn = Console.ReadLine();
                    string[] coordinates = inputRowAndColumn.Trim().Split(' ');
                    coords[0] = int.Parse(coordinates[0]);
                    coords[1] = int.Parse(coordinates[1]);
                    Validator.ValidateCoordinates(coords);

                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Incorrect input. Please try again.");
                    continue;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Incorrect input. Please try again.");
                    continue;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Incorrect input. Please try again.");
                    continue;
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Incorrect input. Please try again.");
                    continue;
                }
                break;

            } while (true);

            return coords;
        }

        public void Init()
        {
            this.CreateBattleField();
            this.FillInCells();
            this.DrawTable();
        }

        private void CreateBattleField()
        {
            this.N = this.ReadBoardSize();
            this.BattleField = new string[this.N, this.N];
            for (var row = 0; row < this.N; row++)
            {
                for (var col = 0; col < this.N; col++)
                {
                    this.BattleField[row, col] = "-";
                }
            }
        }
    }

}

