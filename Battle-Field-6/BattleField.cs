using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BattleField
{
    public class BattleField
    {
        public static Boolean isValidFieldSize(int inputNumber)
        {
            return ((inputNumber >= 1) && (inputNumber <= 10));
        }

        public int ReadCellsNumber()
        {
            int n;
            do
            {
                Console.Write("Please Enter Valid Size Of The Field. n=");

                if (!(Int32.TryParse(Console.ReadLine(), out n))) 
                { 
                    n = -1; 
                }
            }
            while (!(isValidFieldSize(n)));

            return n;
        }

        string[,] battleField;
        int n;

        public void CreateBattleField()
        {
            n = ReadCellsNumber();
            battleField = new string[n, n];
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    battleField[row, col] = "-";
                }
            }    
        }

        private static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        int countOfNumberedCells = 0;

        public void FillInTheFields()
        {
            int row;
            int column;
            while (countOfNumberedCells + 1 <= 0.3 * n * n)
            {
                row = RandomNumber(0, n - 1);
                column = RandomNumber(0, n - 1);

                if (battleField[row, column] == "-")
                {
                    battleField[row, column] = Convert.ToString(RandomNumber(1, 5));
                    countOfNumberedCells++;

                    if (countOfNumberedCells >= 0.15 * n * n)
                    {
                        // originally was int stopFilling = RandomNumber(0, 1); , but in this case stopFilling can never be 1
                        int stopFilling = RandomNumber(0, 2);
                        if (stopFilling == 1) 
                        { 
                            break; 
                        }
                    }
                }
            }
        }

        int killedNumbers = 0;

        public void BombOne(int row, int column)
        {
            battleField[row, column] = "X"; 
            killedNumbers++;
            if ((row - 1 >= 0) && (column - 1 >= 0))
            {
                if ((battleField[row - 1, column - 1] != "X") && (battleField[row - 1, column - 1] != "-"))
                {
                    killedNumbers++; 
                    battleField[row - 1, column - 1] = "X";
                }
            }

            if ((row + 1 <= n - 1) && (column - 1 >= 0))
            {
                if ((battleField[row + 1, column - 1] != "X") && (battleField[row + 1, column - 1] != "-"))
                {
                    killedNumbers++; 
                    battleField[row + 1, column - 1] = "X";
                }
            }

            if ((row - 1 >= 0) && (column + 1 <= n - 1))
            {
                if ((battleField[row - 1, column + 1] != "X") && (battleField[row - 1, column + 1] != "-"))
                {
                    killedNumbers++;
                    battleField[row - 1, column + 1] = "X";
                }
            }

            if ((row + 1 <= n - 1) && (column + 1 <= n - 1))
            {
                if ((battleField[row + 1, column + 1] != "X") && (battleField[row + 1, column + 1] != "-"))
                {
                    killedNumbers++; 
                    battleField[row + 1, column + 1] = "X";
                }
            }
        }

        public void BombTwo(int row, int column)
        {
            BombOne(row, column);

            if (row - 1 >= 0)
            {
                if ((battleField[row - 1, column] != "X") && (battleField[row - 1, column] != "-"))
                {
                    killedNumbers++; 
                    battleField[row - 1, column] = "X";
                }
            }

            if (column - 1 >= 0)
            {
                if ((battleField[row, column - 1] != "X") && (battleField[row, column - 1] != "-"))
                {
                    killedNumbers++; 
                    battleField[row, column - 1] = "X";
                }
            }

            if (column + 1 <= n - 1)
            {
                if ((battleField[row, column + 1] != "X") && (battleField[row, column + 1] != "-"))
                {
                    killedNumbers++; 
                    battleField[row, column + 1] = "X";
                }
            }

            if (row + 1 <= n - 1)
            {
                if ((battleField[row + 1, column] != "X") && (battleField[row + 1, column] != "-"))
                {
                    killedNumbers++; 
                    battleField[row + 1, column] = "X";
                }
            }
        }

        public void BombThree(int row, int column)
        {
            BombTwo(row, column);

            if (row - 2 >= 0)
            {
                if ((battleField[row - 2, column] != "X") && (battleField[row - 2, column] != "-"))
                {
                    killedNumbers++; 
                    battleField[row - 2, column] = "X";
                }
            }

            if (column - 2 >= 0)
            {
                if ((battleField[row, column - 2] != "X") && (battleField[row, column - 2] != "-"))
                {
                    killedNumbers++; 
                    battleField[row, column - 2] = "X";
                }
            }

            if (column + 2 <= n - 1)
            {
                if ((battleField[row, column + 2] != "X") && (battleField[row, column + 2] != "-"))
                {
                    killedNumbers++; 
                    battleField[row, column + 2] = "X";
                }
            }

            if (row + 2 <= n - 1)
            {
                if ((battleField[row + 2, column] != "X") && (battleField[row + 2, column] != "-"))
                {
                    killedNumbers++; 
                    battleField[row + 2, column] = "X";
                }
            }

        }

        public void BombFour(int row, int column)
        {
            BombThree(row, column);

            if ((row - 1 >= 0) && (column - 2 >= 0))
            {
                if ((battleField[row - 1, column - 2] != "X") && (battleField[row - 1, column - 2] != "-"))
                {
                    killedNumbers++; 
                    battleField[row - 1, column - 2] = "X";
                }
            }

            if ((row + 1 <= n - 1) && (column - 2 >= 0))
            {
                if ((battleField[row + 1, column - 2] != "X") && (battleField[row + 1, column - 2] != "-"))
                {
                    killedNumbers++; 
                    battleField[row + 1, column - 2] = "X";
                }
            }

            if ((row - 2 >= 0) && (column - 1 >= 0))
            {
                if ((battleField[row - 2, column - 1] != "X") && (battleField[row - 2, column - 1] != "-"))
                {
                    killedNumbers++; 
                    battleField[row - 2, column - 1] = "X";
                }
            };

            if ((row + 2 <= n - 1) && (column - 1 >= 0))
            {
                if ((battleField[row + 2, column - 1] != "X") && (battleField[row + 2, column - 1] != "-"))
                {
                    killedNumbers++; 
                    battleField[row + 2, column - 1] = "X";
                }
            }

            if ((row - 1 >= 0) && (column + 2 <= n - 1))
            {
                if ((battleField[row - 1, column + 2] != "X") && (battleField[row - 1, column + 2] != "-"))
                {
                    killedNumbers++; 
                    battleField[row - 1, column + 2] = "X";
                }
            }

            if ((row + 1 <= n - 1) && (column + 2 <= n - 1))
            {
                if ((battleField[row + 1, column + 2] != "X") && (battleField[row + 1, column + 2] != "-"))
                {
                    killedNumbers++; 
                    battleField[row + 1, column + 2] = "X";
                }
            }

            if ((row - 2 >= 0) && (column + 1 <= n - 1))
            {
                if ((battleField[row - 2, column + 1] != "X") && (battleField[row - 2, column + 1] != "-"))
                {
                    killedNumbers++; 
                    battleField[row - 2, column + 1] = "X";
                }
            }

            if ((row + 2 <= n - 1) && (column + 1 <= n - 1))
            {
                if ((battleField[row + 2, column + 1] != "X") && (battleField[row + 2, column + 1] != "-"))
                {
                    killedNumbers++; 
                    battleField[row + 2, column + 1] = "X";
                }
            }
        }

        public void BombFive(int row, int column)
        {
            BombFour(row, column);

            if ((row - 2 >= 0) && (column - 2 >= 0))
            {
                if ((battleField[row - 2, column - 2] != "X") && (battleField[row - 2, column - 2] != "-"))
                {
                    killedNumbers++; 
                    battleField[row - 2, column - 2] = "X";
                }
            }

            if ((row + 2 <= n - 1) && (column - 2 >= 0))
            {
                if ((battleField[row + 2, column - 2] != "X") && (battleField[row + 2, column - 2] != "-"))
                {
                    killedNumbers++; 
                    battleField[row + 2, column - 2] = "X";
                }
            }

            if ((row - 2 >= 0) && (column + 2 <= n - 1))
            {
                if ((battleField[row - 2, column + 2] != "X") && (battleField[row - 2, column + 2] != "-"))
                {
                    killedNumbers++; 
                    battleField[row - 2, column + 2] = "X";
                }
            }

            if ((row + 2 <= n - 1) && (column + 2 <= n - 1))
            {
                if ((battleField[row + 2, column + 2] != "X") && (battleField[row + 2, column + 2] != "-"))
                {
                    killedNumbers++; 
                    battleField[row + 2, column + 2] = "X";
                }
            }
        }

        public void InvalidMove()
        {
            Console.WriteLine("Invalid Move!");
            Console.WriteLine();
        }

        public void ViewTable()
        {
            Console.Write("   ");
            for (int k = 0; k < n; k++) 
            { 
                Console.Write(k + " "); 
            }

            Console.WriteLine();
            Console.Write("   ");
            for (int k = 0; k < n; k++) 
            { 
                Console.Write("--"); 
            }

            Console.WriteLine();

            for (int i = 0; i < n; i++)
            {
                Console.Write(i + "| ");
                for (int j = 0; j < n; j++)
                {
                    Console.Write(battleField[i, j] + " ");
                }

                Console.WriteLine();
                Console.WriteLine();
            }
        }

        int izgyrmqniBombi = 0;

        public void MineCell(int row, int column)
        {
            int cellNumber;

            if ((battleField[row, column] == "X") || ((battleField[row, column]) == "-"))
            {
                cellNumber = 0;
            }
            else
            {
                cellNumber = Convert.ToInt32(battleField[row, column]);
            }

            switch (cellNumber)
            {
                case 1: { BombOne(row, column); ViewTable(); izgyrmqniBombi++; break; };
                case 2: { BombTwo(row, column); ViewTable(); izgyrmqniBombi++; break; };
                case 3: { BombThree(row, column); ViewTable(); izgyrmqniBombi++; break; };
                case 4: { BombFour(row, column); ViewTable(); izgyrmqniBombi++; break; };
                case 5: { BombFive(row, column); ViewTable(); izgyrmqniBombi++; break; };

                default: { InvalidMove(); break; };
            }
        }

        public bool Over()
        {
            return killedNumbers == countOfNumberedCells;
        }

        public bool OutOfAreaCoordinates(int row, int column)
        {
            if ((row >= 0) && (row <= n - 1) && (column >= 0) && (column <= n - 1))
            {
                return false;
            }
            return true;
        }

        public void GameSession()
        {
            CreateBattleField();
            FillInTheFields();
            ViewTable();

            while (!(Over()))
            {
                Console.Write("Please Enter Coordinates : ");

                string inputRowAndColumn = Console.ReadLine();
                string[] rowAndColumnSplit = inputRowAndColumn.Split(' ');
                int row;
                int column;

                if ((rowAndColumnSplit.Length) <= 1) 
                { 
                    row = -1; 
                    column = -1; 
                }
                else
                {
                    if (!(int.TryParse(rowAndColumnSplit[0], out row)))
                    {
                        row = -1;
                    }
                    if (!(int.TryParse(rowAndColumnSplit[1], out column)))
                    {
                        column = -1;
                    }
                }

                if ((OutOfAreaCoordinates(row, column)))
                {
                    Console.WriteLine("This Move Is Out Of Area.");
                }
                else
                {
                    MineCell(row, column);
                }
            }

            Console.WriteLine("Game Over. Detonated Mines {0}", izgyrmqniBombi);

        }
        static void Main(string[] args)
        {
            BattleField bf = new BattleField();

            bf.GameSession();
        }
    }
}
