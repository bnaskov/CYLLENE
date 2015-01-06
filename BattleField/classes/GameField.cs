using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleField.classes
{
    public class GameField
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
    }
}
