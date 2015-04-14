using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.GameObjects
{
    interface IObject
    {
        int X { get; }
        int Y { get; }
        Direction Direction { get; }

        //int Speed { get; }
    }
}
