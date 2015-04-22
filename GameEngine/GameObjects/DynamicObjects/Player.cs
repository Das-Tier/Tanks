using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.GameObjects.DynamicObjects
{
    public class Player:BaseGameObject, IMovable
    {
        public Direction Direction { get; set; }
        public int Lives { get; set; }
        public Player(int x, int y)
            : base(x, y)
        {
            Direction = Direction.Up;
            Lives = 3;
        }
        public void MoveOn(int dx, int dy)
        {
            if (CheckMoveOn(dx, dy) == true)
            {
                //throw new ArgumentException("Player cannot be move");
                X += dx;
                Y += dy;
            }
            
           
        }
        public bool CheckMoveOn(int dx, int dy)
        {
            int newX = X + dx;
            int newY = Y + dy;
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
