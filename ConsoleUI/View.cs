using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEngine;

namespace ConsoleUI
{
    public static class View
    {
        public static void HideObject(Game game)
        {
            foreach (var obj in game.GameBoard.gameObjects)
            {
                Console.SetCursorPosition(obj.X, obj.Y);
                Console.Write(' ');
            }
        }
        public static void ShowObject(Game game)
        {
            foreach (var obj in game.GameBoard.gameObjects)
            {
                Console.SetCursorPosition(obj.X, obj.Y);
                Console.Write('X');
            }
        }
        //public static void ShowObject(Game game)
        //{

        //}
        public static void DrawMap(Game game)
        {
            foreach (var i in game.GameBoard.gameObjects)
            {
                if (i.Transparency == true)
                {
                    ConsoleColor color = ConsoleColor.Black;
                    Type type = i.GetType();
                    string tempType = type.ToString();
                    //Console.WriteLine(type.ToString());
                    //Console.ReadLine();
                    switch (tempType)
                    {
                        case "GameEngine.GameObjects.UnmovableObjects.Wall": color = ConsoleColor.Yellow; break;
                        case "GameEngine.GameObjects.UnmovableObjects.Concrete": color = ConsoleColor.Magenta; break;
                        default: break;
                    }
                    Console.BackgroundColor = color;
                    Console.SetCursorPosition(i.X, i.Y);
                    Console.Write(' ');
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static void RefreshMap(Game game)
        {
            foreach (var i in game.GameBoard.gameObjects)
            {
                
            }
        }

        public static void ShowBullet(Game game)
        {
            foreach (var i in game.bullets)
            {
                if (i.Transparency == true)
                {
                    Console.SetCursorPosition(i.X, i.Y);
                    Console.Write("o");
                }
            }
        }
        public static void HideBullet(Game game)
        {
            foreach (var i in game.bullets)
            {

                Console.SetCursorPosition(i.X, i.Y);
                Console.Write(' ');

            }
        }
        public static void HidePlayer(Game game)
        {
            Console.SetCursorPosition(game.player.X, game.player.Y);
            Console.Write(' ');
        }
        public static void ShowPlayer(Game game)
        {
            Console.SetCursorPosition(game.player.X, game.player.Y);
            Console.Write('X');
        }
        public static void HideEnemy(Game game)
        {
            foreach (var i in game.enemies)
            {
                Console.SetCursorPosition(i.X, i.Y);
                Console.Write(' ');
            }
        }
        public static void ShowEnemy(Game game)
        {
            foreach (var i in game.enemies)
            {
                if (i.Transparency == true)
                {
                    Console.SetCursorPosition(i.X, i.Y);
                    Console.Write("E");
                }
            }
        }
    }
}
