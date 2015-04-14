using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEngine.GameObjects;
using GameEngine.MapObjects;

namespace ConsoleUI
{
    public static class Drawing
    {
        #region DrawMethods
        public static void DrawEnemy(List<Enemy> enemy)
        {
            foreach (var item in enemy)
            {
                Console.SetCursorPosition(item.X, item.Y);
                Console.Write('o');
            }
        }
        
        public static void DrawPlayer(Player player)
        {
            Console.SetCursorPosition(player.X, player.Y);
            Console.Write('X');
        }
        
        public static void DrawBullet(List<Bullet> bullet)
        {
            foreach (var item in bullet)
            {
                Console.SetCursorPosition(item.X, item.Y);
                Console.Write('+');
            }
        }
        #endregion

        #region EraseMethods
        public static void ErasePlayer(Player player)
        {
            Console.SetCursorPosition(player.X, player.Y);
            Console.Write(' ');
        }
        public static void EraseBullet(List<Bullet> bullet)
        {
            foreach (var item in bullet)
            {
                Console.SetCursorPosition(item.X, item.Y);
                Console.Write(' ');
            }
        }
        public static void EraseEnemy(List<Enemy> enemy)
        {
            foreach (var item in enemy)
            {
                Console.SetCursorPosition(item.X, item.Y);
                Console.Write(' ');
            }
        }
        #endregion

        public static void ShowInfo(Player player)
        {
            Console.SetCursorPosition(22, 1);
            Console.WriteLine("Lives:{0}, Points:{1}", player.Lives, player.Points);
        }

        public static void DrawLevel(MapObject [,] walls)
        {
            ConsoleColor color = Console.ForegroundColor;
            foreach (var i in walls)
            {
                switch (i.WallType)
                {
                    case WallType.Concrete: color = ConsoleColor.DarkCyan; break;
                    case WallType.Wall: color = ConsoleColor.Yellow; break;
                    case WallType.Space: color = ConsoleColor.Black; break;
                    case WallType.Base: color = ConsoleColor.Red; break;
                }
                Console.BackgroundColor = color;
                Console.SetCursorPosition(i.X, i.Y);
                Console.Write(' ');
            }
                      
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}

