using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.GameObjects.DynamicObjects
{
    public class Enemy:BaseGameObject, IMovable
    {
        public Enemy(int x, int y)
            : base(x, y)
        {
            Direction = Direction.Down;
            Transparency = true;
        }
        //public bool Transparency { get; set; }
        public Direction Direction { get; set; }

        Random randomDirect = new Random();
        public void MoveOn(int pX, int pY)
        {
            int newX = X;
            int newY = Y;
            switch (Direction)
            {
                case Direction.Down: newY++; break;
                case Direction.Up: newY--; break;
                case Direction.Left: newX--; break;
                case Direction.Right: newX++; break;
            }
            if (CheckMoveOn(newX, newY))
            {
                X = newX;
                Y = newY;
            }
            else
            {
                Direction = (Direction)randomDirect.Next(0, 5);
            }

        }
        public bool CheckMoveOn(int newX, int newY)
        {

            if (Board != null)
            {
                return this.Board.IsCorrectPosition(this, newX, newY);
            }
            else
            {
                return true;
            }

        }
    }
}
