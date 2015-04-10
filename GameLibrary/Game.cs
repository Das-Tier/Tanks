using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEngine.GameObjects;

namespace GameEngine
{
    public class Game
    {
        public Player player { get; set; }
        public List<Enemy> enemies { get; set; }
        public List<Bullet> bullet { get; set; }
        public Game()
        {
            player = new Player { X = 15, Y = 7 };
            enemies = new List<Enemy>{new Enemy()};
            bullet = new List<Bullet>();
            World w = new World();
        }

        public void Fire(GameObject obj)
        {
            player.IsMove = false;
            bullet.Add(new Bullet(obj));
        }
        public void CheckActions()
        {
            
        }
        public void UpdatePositions()
        {

        }

        
    }
}
