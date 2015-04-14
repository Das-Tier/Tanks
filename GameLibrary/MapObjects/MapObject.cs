using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.MapObjects
{
    public enum WallType
    {
        Wall, Concrete, Base, Space
    }
    
    
    public class MapObject
    {
        public WallType WallType { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        //public bool GameBase { get; set; }
        public MapObject(int x, int y, WallType type)
        {
            X = x;
            Y = y;
            WallType = type;
        }
        
    }
}
