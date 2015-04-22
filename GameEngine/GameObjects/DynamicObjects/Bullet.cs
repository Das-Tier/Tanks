using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.GameObjects.DynamicObjects
{
    public class Bullet:BaseGameObject, IMovable
    {
        public Bullet(int x, int y, Direction direction, bool ofPlayer)
            : base(x, y)
        {
            OfPlayer = ofPlayer;
            Transparency = true;
            Direction = direction;
        }
        public Direction Direction { get; set; }
        //public bool Transparency { get; set; }
        public bool OfPlayer { get; set; }
        public void MoveOn(int dx, int dy)
        {
            dy = 0; dx = 0;
            switch (Direction)
            {
                case Direction.Up: dy -= 1; break;
                case Direction.Down: dy += 1; break;
                case Direction.Left: dx -= 1; break;
                case Direction.Right: dx += 1; break;
                case Direction.Stop: break;
            }
            int newX = X + dx;
            int newY = Y + dy;
            if (CheckMoveOn(newX, newY))
            {
                X = newX;
                Y = newY;
            }
            else
                Direction = Direction.Stop;
        }
        public bool CheckMoveOn(int newX, int newY)
        {
            if (this.Board != null)
            {
                return this.Board.BulletObjectCollision(this, newX, newY);
            }
            else
            {
                return true;
            }
        }
    }
}
