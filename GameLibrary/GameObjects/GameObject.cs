using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEngine;


namespace GameEngine.GameObjects
{
     
    public class GameObject : IObject
    {
       
        //public int Size { get; set; }
        //public int blockX { get; set; }
        //public int blockY { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int newX { get; set; }
        public int newY { get; set; }
        public Direction Direction { get; set; }
        //public abstract void Move(MapObjects.MapObject[,] mapArr);
        //public int Speed { get; set; }
    }
}