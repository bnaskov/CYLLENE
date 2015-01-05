using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BattleField
{
    public class BattleField
    {
        static void Main(string[] args)
        {
            BattleField bf = new BattleField();

            bf.GameSession();
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

        public string[,] battleField;
        public int n;

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

        public int countOfNumberedCells = 0;

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

        public int killedNumbers = 0;

        public void Bomb(int row, int column, int range)
        {
            
            battleField[row, column] = "X"; 
            killedNumbers++;
            for (int i = row - range; i < row + range; i++)
            {
                for (int j = column - range; j < column + range; j++)
                {
                    if (!OutOfAreaCoordinates(i, j))
                    {
                        if ((battleField[i, j] != "X") && (battleField[i, j] != "-"))
                        {
                            killedNumbers++;
                            battleField[i, j] = "X";
                        }
                    }
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

        public int izgyrmqniBombi = 0;

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
            if (cellNumber > 5 || cellNumber < 0) {
                InvalidMove(); 
            }
            Bomb(row, column, cellNumber); ViewTable(); izgyrmqniBombi++;
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
    }
}
