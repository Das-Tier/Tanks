﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.GameObjects
{
    public abstract class BaseGameObject:IGameObject
    {
       
        public BaseGameObject(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public bool Transparency { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public GameBoard Board { get; set; }
       
    }
}
