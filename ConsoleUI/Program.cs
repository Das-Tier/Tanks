using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEngine;
using GameEngine.GameObjects;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            int countIter = 0;
            ConsoleKeyInfo key;
            Game game = new Game();
            View.DrawMap(game);
            while (true)
            {
                countIter++;
                //View.DrawMap(game);
                
                Console.CursorVisible = false;
                View.HideEnemy(game);
                View.HideBullet(game);
                if (Console.KeyAvailable)
                {
                    View.HidePlayer(game);
                    key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Spacebar)
                    {
                        game.Fire(game.player);
                    }
                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow: game.player.MoveOn(0, -1); game.player.Direction = Direction.Up; break;
                        case ConsoleKey.DownArrow: game.player.MoveOn(0, 1); game.player.Direction = Direction.Down; break;
                        case ConsoleKey.LeftArrow: game.player.MoveOn(-1, 0); game.player.Direction = Direction.Left; break;
                        case ConsoleKey.RightArrow: game.player.MoveOn(1, 0); game.player.Direction = Direction.Right; break;
                    }
                }
                game.CheckBullets();
                game.CheckEnemies();
                for (int i=0; i<game.enemies.Count;i++)
                {
                    game.enemies[i].MoveOn(game.player.X, game.player.Y);
                    if (countIter%10==0&&i%2==0)
                    {
                        game.EnemyFire(game.enemies[i]);
                    }
                    if (countIter%15==0&&i%2==1)
                    {
                        game.EnemyFire(game.enemies[i]);
                    }
                }
                foreach (var i in game.bullets)
                {
                    i.MoveOn(0, 0);
                }
                View.RefreshMap(game);
                View.ShowPlayer(game);
                View.ShowEnemy(game);
                View.ShowBullet(game);
                System.Threading.Thread.Sleep(100);
            }
        }
    }
}
