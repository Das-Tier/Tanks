﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.GameObjects
{
    interface IMovable
    {
        Direction Direction { get; set; }
        void MoveOn(int dx, int dy);
    }
}
