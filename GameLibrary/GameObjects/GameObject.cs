using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GameEngine.GameObjects
{
    public class GameObject:IObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }
        public int Speed { get; set; }
    }
}
