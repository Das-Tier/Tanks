using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEngine.MapObjects;

namespace GameEngine.GameObjects
{
    public class Bullet:GameObject
    {
        public Bullet() { }
        public  bool Move(MapObject[,] walls)
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
            
            
            if (walls[newX/Game.BlockSize,newY/Game.BlockSize].WallType==WallType.Space)
            {
                X = newX;
                Y = newY;
                return true;
            }
            else
            {
                switch (walls[newX/Game.BlockSize,newY/Game.BlockSize].WallType)
                {
                    case WallType.Wall: walls[newX/Game.BlockSize, newY/Game.BlockSize].WallType = WallType.Space; break;
                    case WallType.Concrete: break;
                }
                return false;
            }
        }
    }
}
