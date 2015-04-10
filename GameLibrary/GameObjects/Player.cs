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
            IsMove = true;
        }
        public int Lives { get; set; }
        public int Points { get; set; }
        public bool IsMove { get; set; }
        public void Move()
        {
            if (IsMove)
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
}
