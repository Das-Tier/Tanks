using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.GameObjects
{
    public interface IGameObject
    {
        int X { get; }
        int Y { get; }
        bool Transparency { get; set; }
        GameBoard Board { get; set; }
    }
}
