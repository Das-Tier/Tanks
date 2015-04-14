using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEngine;
using GameEngine.MapObjects;

namespace GameEngine.GameObjects
{
    public class Player : GameObject
    {
        public Player()
        {
            Lives = 3;
            Points = 0;
            //IsMove = true;
        }
        public int Lives { get; set; }
        public int Points { get; set; }

        public Bullet Fire()
        {
            Bullet bullet = new Bullet();
            bullet.X = X;
            bullet.Y = Y;
            bullet.Direction = Direction;
            return bullet;
        }

        public void Move(MapObject[,] walls)
        {
            newX = X;
            newY = Y;
            switch (Direction)
            {
                case Direction.Up: newY -= 1; break;
                case Direction.Down: newY += 1; break;
                case Direction.Left: newX -= 1; break;
                case Direction.Right: newX += 1; break;
            }

            if (walls[newX / Game.BlockSize, newY / Game.BlockSize].WallType == WallType.Space)
            {
                X = newX;
                Y = newY;
            }
        }
        public void Die()
        {
            Lives--;
            X = 7 * Game.BlockSize;
            Y = 18 * Game.BlockSize;
        }
        public void GetPoints()
        {
            Points += 10;
        }
    }
}