using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEngine.GameObjects;
using GameEngine.GameObjects.DynamicObjects;

namespace GameEngine
{
    public class Game
    {
        public Enemy enemy;
        public Player player;
        public Bullet bullet;
        public GameBoard GameBoard;
        public List<Bullet> bullets;
        public List<Enemy> enemies;
        public Game game;
        public Game()
        {
            enemies = new List<Enemy>();
            bullets = new List<Bullet>();
            GameBoard = new GameBoard();
            player = new Player(7, 18);
            Enemy e1 = new Enemy(7, 3);
            Enemy e2 = new Enemy(1, 1);
            Enemy e3 = new Enemy(14, 1);
            Enemy e4 = new Enemy(9, 9);
            enemies.Add(e1);
            enemies.Add(e2);
            enemies.Add(e3);
            enemies.Add(e4);

            LoadMap();
            GameBoard.AddObject(player);
            GameBoard.AddObject(e1);
            GameBoard.AddObject(e2);
            GameBoard.AddObject(e3);
            GameBoard.AddObject(e4);
        }
        
        public void Fire(Player player)
        {
            Bullet b = new Bullet(player.X, player.Y , player.Direction, true);
            bullets.Add(b);
            GameBoard.AddObject(b);
        }
        public void EnemyFire(Enemy e1)
        {
            Bullet b = new Bullet(e1.X, e1.Y, e1.Direction, false);
            bullets.Add(b);
            GameBoard.AddObject(b);
        }
        public void CheckBullets()
        {
            for (int i=0; i<bullets.Count; i++)
            {
                if (bullets[i].Transparency==false)
                {
                    bullets.RemoveAt(i);
                }
            }
        }
        public void CheckEnemies()
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].Transparency == false)
                {
                    enemies.RemoveAt(i);
                }
            }
        }
        public void LoadMap()
        {
            World world = new World();
            for (int i=0; i<20; i++)
            {
                for (int j=0; j<20; j++)
                {
                    switch (World.MapArray[j,i])
                    {
                        case '1': GameBoard.AddObject(new GameObjects.UnmovableObjects.Concrete(i, j)); break;
                        case '2': GameBoard.AddObject(new GameObjects.UnmovableObjects.Wall(i, j)); break;
                        default: break;
                    }
                }
            }

        }
    }
}
