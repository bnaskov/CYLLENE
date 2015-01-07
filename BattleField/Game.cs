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
                int[] coordinates = Engine.ReadUserInput();
                e.DetonateMine(coordinates[0], coordinates[1]);
            }

            Console.WriteLine("Game Over. Detonated Mines {0}", e.DestroyedMines);
        }
    }
}
