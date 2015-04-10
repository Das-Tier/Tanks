using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEngine.GameObjects;

namespace ConsoleUI
{
    public static class Drawing
    {
        public static void DrawPlayer(Player player)
        {
            Console.SetCursorPosition(player.X, player.Y);
            Console.Write('X');
        }
        public static void ErasePlayer(Player player)
        {
            Console.SetCursorPosition(player.X, player.Y);
            Console.Write(' ');
        }
        public static void DrawBullet(List<Bullet> bullet)
        {
            foreach (var item in bullet)
            {
                Console.SetCursorPosition(item.X, item.Y);
                Console.Write('o');
            }
        }
        public static void EraseBullet(List<Bullet> bullet)
        {
            foreach (var item in bullet)
            {
                Console.SetCursorPosition(item.X, item.Y);
                Console.Write(' ');
            }
        }
        public static void DrawEnemy(List<Enemy> enemy)
        {
            foreach (var item in enemy)
            {
                Console.SetCursorPosition(item.X, item.Y);
                Console.Write('o');
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
        public static void DrawLevel(char[,] map)
        {
            ConsoleColor color = Console.ForegroundColor;
            for(int i=0; i<=map.GetUpperBound(0); i++)
            {
                for (int j=0; j<=map.GetUpperBound(1); j++)
                {
                    switch (map[j,i])
                    {
                        case '0': color = ConsoleColor.Black; break;
                        case '1': color = ConsoleColor.Yellow; break;
                        case '2': color = ConsoleColor.DarkCyan; break;
                        case '6': color = ConsoleColor.White; break;
                    }
                    Console.BackgroundColor = color;
                    Console.SetCursorPosition(i, j);
                    Console.Write(' ');
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
