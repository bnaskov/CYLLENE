using System;


namespace BattleField
{
    public class BattleFieldGame
    {
        static void Main()
        {
            BattleFieldGame bf = new BattleFieldGame();
            bf.GameSession();
            
        }

        private void GameSession()
        {
            Engine e = new Engine();
            e.Init();

            while (!(e.GameOver()))
            {
                int[] coordinates = e.ReadUserInput();
                e.DetonateMine(coordinates[0], coordinates[1]);
            }

            Console.WriteLine("Game GameOver. Detonated Mines {0}", this.detonatedMines);
        }
    }
}
