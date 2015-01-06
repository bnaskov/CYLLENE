using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleField.classes
{
    public class Engine
    {
        public string[,] battleField;
        public int n;

        public void CreateBattleField()
        {
            n = Helper.ReadBoardSize();
            battleField = new string[n, n];
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    battleField[row, col] = "-";
                }
            }
        }

        public int countOfNumberedCells = 0;

        public void FillInTheFields()
        {
            int row;
            int column;
            while (countOfNumberedCells + 1 <= 0.3 * n * n)
            {
                row = Helper.RandomNumber(0, n - 1);
                column = Helper.RandomNumber(0, n - 1);

                if (battleField[row, column] == "-")
                {
                    battleField[row, column] = Convert.ToString(Helper.RandomNumber(1, 5));
                    countOfNumberedCells++;

                    if (countOfNumberedCells >= 0.15 * n * n) //TODO(kyamaliev): Randomize the number of mines!
                    {
                        //(kyamaliev) - what is the purpose of the following code?
                        // originally was int stopFilling = RandomNumber(0, 1); , but in this case stopFilling can never be 1
                        int stopFilling = Helper.RandomNumber(0, 2);
                        if (stopFilling == 1)
                        {
                            break;
                        }
                    }
                }
            }
        }

        public int killedNumbers = 0;
        //(kyamaliev) TODO: needs more work, different mines detonate differently
        public void Bomb(int row, int column, int range) //(kyamaliev)why is it called range?
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
        // (kyamaliev)only draws
        public void DrawTable()
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

        //(kyamaliev) actual gameplay
        public int detonatedMines = 0;

        public void DetonateMine(int row, int column)
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
            if (cellNumber > 5 || cellNumber < 0)
            {
                InvalidMove();
            }
            Bomb(row, column, cellNumber); DrawTable(); detonatedMines++;
        }

        //(kyamaliev)game over
        public bool Over()
        {
            return killedNumbers == countOfNumberedCells;
        }

        //(kyamaliev)validator
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
