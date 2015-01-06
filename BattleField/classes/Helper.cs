using System;

namespace BattleField
{

    public class Helper
    {
        
        
        public static int ReadBoardSize()
        {
            int n;
            do
            {
                Console.Write("Please enter field size (1..9): ");
                try
                {
                    n = int.Parse(Console.ReadLine());
                    Validator.ValidateBoardSize(n);
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
            return n;
        }

        public static int[] ReadUserInput()
        {
            string inputRowAndColumn;
            int[] coords = new int[2];

            //(kyamaliev) TODO: should do it without loop here, too difficult to rethrow exceptions
            do
            {
                try
                {
                    Console.Write("Please enter cell coordinates (x y): ");
                    inputRowAndColumn = Console.ReadLine();
                    string[] coordinates = inputRowAndColumn.Split(' ');
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
                break;

            } while (true);

            return coords;
        }

        public static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        

        //public void Play()
        //{
        //    Console.Write("Please Enter Coordinates : ");

            
            

        //    if ((rowAndColumnSplit.Length) <= 1)
        //    {
        //        row = -1;
        //        column = -1;
        //    }
        //    else
        //    {
        //        if (!(int.TryParse(rowAndColumnSplit[0], out row)))
        //        {
        //            row = -1;
        //        }
        //        if (!(int.TryParse(rowAndColumnSplit[1], out column)))
        //        {
        //            column = -1;
        //        }
        //    }

        //    if ((OutOfAreaCoordinates(row, column)))
        //    {
        //        Console.WriteLine("This Move Is Out Of Area.");
        //    }
        //    else
        //    {
        //        MineCell(row, column);
        //    }
        //}
    }

    
}
