using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEngine;
using GameEngine.MapObjects;

namespace GameEngine.GameObjects
{
    public class Enemy:GameObject
    {
        Random r = new Random();
        public Enemy(int x, int y)
        {
            X = 1*Game.BlockSize;
            Y = 2*Game.BlockSize;
        }
        public void ChangeDirection()
        {
            
            int i = r.Next(-3, 3);
            Direction = (Direction)i;
        }
     
        public void Move(MapObject[,] mapArr)
        {  
            ChangeDirection();
            newX = X;
            newY = Y;
            switch (Direction)
            {
                case Direction.Up: newY -= 1;break;
                case Direction.Down: newY += 1; break;
                case Direction.Left: newX -= 1; break;
                case Direction.Right: newX += 1; break;
            }
            if (mapArr[newX/Game.BlockSize, newY/Game.BlockSize].WallType==WallType.Space)
            {
                X = newX;
                Y = newY;
            }
        }
    }
}
