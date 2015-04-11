using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.GameObjects
{
    public class Bullet:GameObject
    {
        public Bullet() { }
        public void KillObject(GameObject obj)
        {

        }
        public bool Move()
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
            if (World.MapArray[newY, newX] == '0')
            {
                X = newX;
                Y = newY;
                return true;
            }
            else
            {
                switch (World.MapArray[newY, newX])
                {
                    case '2': World.MapArray[newY, newX] = '0'; break;
                    case '6': break;
                    default: break;
                }
                return false;
            }
        }
    }
}
