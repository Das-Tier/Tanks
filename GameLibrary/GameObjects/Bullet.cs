using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.GameObjects
{
    public class Bullet:GameObject
    {
        public Bullet(GameObject obj)
        {
            Direction = obj.Direction;
            switch(Direction)
            {
                case Direction.Up: X = obj.X; Y = obj.Y - 1; break;
                case Direction.Down: X = obj.X; Y = obj.Y + 1; break;
                case Direction.Left: X = obj.X - 1; Y = obj.Y; break;
                case Direction.Right: X = obj.X + 1; Y = obj.Y; break;
            }
        }
        public void Move()
        {
            switch (Direction)
            {
                case Direction.Up: Y -= 1; break;
                case Direction.Down: Y += 1; break;
                case Direction.Left: X -= 1; break;
                case Direction.Right: X += 1; break;
            }
        }
    }
}
