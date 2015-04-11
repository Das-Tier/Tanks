using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.GameObjects
{
    public class Enemy:GameObject
    {
        Random r = new Random();
        public Enemy()
        {
            X = 1;
            Y = 2;
            //newX = X;
            //newY = Y;
        }
        public void ChangeDirection()
        {
            
            int i = r.Next(1, 4);
            this.Direction = (Direction)i;

        }
        public void Move()
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
            if (World.MapArray[newY, newX] == '0')
            {
                X = newX;
                Y = newY;
            }
        }
    }
}
