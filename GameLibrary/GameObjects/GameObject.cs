using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GameEngine.GameObjects
{
    public class GameObject:IObject
    {
        public int Size { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int newX { get; set; }
        public int newY { get; set; }
        public Direction Direction { get; set; }
        public int Speed { get; set; }
    }
}
