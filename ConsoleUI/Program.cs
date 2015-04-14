using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEngine;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo key = new ConsoleKeyInfo();

            Game game = new Game(1, 3);
            //game.enemies.Add(new GameEngine.GameObjects.Enemy(3, 5));
            Drawing.DrawLevel(game.MapObj);
            do
            {
                if (game.enemies.Count() < 3)
                {
                    game.AddEnemy();
                }
                Drawing.EraseEnemy(game.enemies);
                Drawing.EraseBullet(game.bullet);
                Drawing.ErasePlayer(game.player);
                if (Console.KeyAvailable)
                {
                    // game.player.IsMove = true; ;
                    key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Spacebar)
                    {
                        game.bullet.Add(game.player.Fire());
                    }
                    else
                    {
                        switch (key.Key)
                        {
                            case ConsoleKey.UpArrow: game.player.Direction = GameEngine.GameObjects.Direction.Up; break;
                            case ConsoleKey.DownArrow: game.player.Direction = GameEngine.GameObjects.Direction.Down; break;
                            case ConsoleKey.LeftArrow: game.player.Direction = GameEngine.GameObjects.Direction.Left; break;
                            case ConsoleKey.RightArrow: game.player.Direction = GameEngine.GameObjects.Direction.Right; break;
                        }
                        game.player.Move(game.MapObj);
                    }
                }
                #region CheckActions
                game.PlayerEnemy(game.player, game.enemies);
                game.BulletEnemy(game.bullet, game.enemies);
                game.EnemyEnemy(game.enemies);
                #endregion
                for (int i = 0; i < game.bullet.Count; i++)
                {
                    if (!game.bullet[i].Move(game.MapObj))
                    {
                        game.bullet.RemoveAt(i);
                        Drawing.DrawLevel(game.MapObj);
                    }
                }

                foreach (var i in game.enemies)
                {
                    i.Move(game.MapObj);
                }
                #region Render
                Drawing.DrawEnemy(game.enemies);
                Drawing.DrawBullet(game.bullet);
                Drawing.DrawPlayer(game.player);
                Drawing.ShowInfo(game.player);
                #endregion
                //Drawing.DrawLevel(World.MapArray);
                System.Threading.Thread.Sleep(100);
            }
            while (game.GameOver());
        }
    }
}
