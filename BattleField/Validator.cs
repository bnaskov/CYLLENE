using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleField
{
    public class Validator
    {
        public static void ValidateBoardSize(int boardSize)
        {
            if (boardSize < 1 || boardSize > 9)// || (boardSize % 1 != 0))
            {
                throw new ArgumentException("Input must be an integer (1..9).");
            }
        }

        public static void ValidateCoordinates(int[] coords)
        {
            int x = coords[0];
            int y = coords[1];
            if ((x < 0 || x > 8) || (y < 0 || y > 8))
            {
                throw new ArgumentException("Input must be between (0..8).");
            }
        }
    }
}
