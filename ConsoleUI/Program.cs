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
         
            Drawing.DrawLevel(World.MapArray);
            do
            {
                Drawing.EraseEnemy(game.enemies);
                Drawing.EraseBullet(game.bullet);
                Drawing.ErasePlayer(game.player);
                if (Console.KeyAvailable)
                {
                    game.player.IsMove = game.player.IsMove = true; ;
                    key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow: game.player.Direction = GameEngine.GameObjects.Direction.Up; break;
                        case ConsoleKey.DownArrow:  game.player.Direction = GameEngine.GameObjects.Direction.Down; break;
                        case ConsoleKey.LeftArrow:  game.player.Direction = GameEngine.GameObjects.Direction.Left; break;
                        case ConsoleKey.RightArrow:  game.player.Direction = GameEngine.GameObjects.Direction.Right; break;
                        case ConsoleKey.Spacebar:  game.Fire(game.player); break;
                    }
                    {
                        game.player.Move();
                    }
                   
                }


                foreach (var i in game.enemies)
                {
                    i.Move();
                }
                foreach (var i in game.bullet)
                {
                    i.Move();
                }
                Drawing.DrawEnemy(game.enemies);
                Drawing.DrawBullet(game.bullet);
                Drawing.DrawPlayer(game.player);
                System.Threading.Thread.Sleep(200);
            }
            while (key.Key!=ConsoleKey.Escape);
           // Console.ReadLine();
        }
    }
}
