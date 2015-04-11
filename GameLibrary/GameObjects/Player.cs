using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.GameObjects
{
    public class Player : GameObject
    {
        public Player()
        {
            Lives = 3;
            Points = 0;
            //Size = 1;
            //IsMove = true;
        }
        public int Lives { get; set; }
        public int Points { get; set; }
        //public bool IsMove { get; set; }

        public Bullet Fire()
        {
            Bullet b = new Bullet();
            b.X = X;
            b.Y = Y;
            b.Direction = Direction;
            return b;
        }
        
        public void Move()
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
                }
            }
        }
    }

