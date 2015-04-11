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

            Game game = new Game();
            game.enemies.Add(new GameEngine.GameObjects.Enemy());
            Drawing.DrawLevel(World.MapArray);
            do
            {
                Drawing.EraseEnemy(game.enemies);
                Drawing.EraseBullet(game.bullet);
                Drawing.ErasePlayer(game.player);
                if (Console.KeyAvailable)
                {
                    // game.player.IsMove = game.player.IsMove = true; ;
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
                        game.player.Move();
                    }
                }

                for (int i = 0; i < game.bullet.Count;i++ )
                {
                    if (!game.bullet[i].Move())
                    {
                        game.bullet.RemoveAt(i);
                        Drawing.DrawLevel(World.MapArray);
                    }
                }
                foreach (var i in game.enemies)
                {
                    i.Move();
                }
                Drawing.DrawEnemy(game.enemies);
                Drawing.DrawBullet(game.bullet);
                Drawing.DrawPlayer(game.player);
                //Drawing.DrawLevel(World.MapArray);
                System.Threading.Thread.Sleep(100);
            }

            while (key.Key != ConsoleKey.Escape);
            // Console.ReadLine();




        }
    }
}
