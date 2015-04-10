using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.GameObjects
{
    public class Enemy:GameObject
    {
        Random r = new Random();
        public void ChangeDirection()
        {
            
            int i = r.Next(1, 4);
            this.Direction = (Direction)i;

        }
        public void Move()
        {
            ChangeDirection();
            switch (Direction)
            {
                case Direction.Up: Y -= 1;break;
                case Direction.Down: Y += 1; break;
                case Direction.Left: X -= 1; break;
                case Direction.Right: Y += 1; break;
            }
        }
    }
}
