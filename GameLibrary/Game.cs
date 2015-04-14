using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEngine.GameObjects;
using GameEngine.MapObjects;
using System.IO;

namespace GameEngine
{
    public class Game
    {
        public static int BlockSize;
        public static int countEnemies;
        public Player player { get; set; }
        public List<Enemy> enemies { get; set; }
        public List<Bullet> bullet { get; set; }
        public MapObject [,] MapObj { get; set; }
        private char[,] MapArray { get; set; }
        public Game(int x, int y)
        {
            SetStart(x, y);
            InitialiseLevel();
            InitialiseObjects();
        }
        #region InitMembers
        public void SetStart(int x, int y)
        {
            BlockSize = x;
            countEnemies = y;
        }
        public void InitialiseObjects()
        {
            player = new Player { X = 7 * BlockSize, Y = 18 * BlockSize };
            enemies = new List<Enemy>();
            bullet = new List<Bullet>();
        }
        public void InitialiseLevel()
        {
            MapObj = new MapObject[20, 20];
            //MapArray = new char[20, 20];
            int index = 0;
            char[] mapData = null;
            string path = @"../../../GameLibrary/Maps/map_1.txt";
            using (StreamReader reader = new StreamReader(path))
            {
                string mapInfo = reader.ReadToEnd();
                mapData = mapInfo.ToCharArray();
            }
            MapObject obj = null;
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    //MapArray[i, j] = mapData[index];
                    switch (mapData[index])
                    {
                        case '0': obj = new MapObject(j, i, WallType.Space); break;
                        case '1': obj = new MapObject(j, i, WallType.Concrete); break;
                        case '2': obj = new MapObject(j, i, WallType.Wall); break;
                        case '6': obj = new MapObject(j, i, WallType.Base); break;
                        default: obj = new MapObject(j, i, WallType.Space); break;
                    }
                    ++index;
                    MapObj[j, i] = obj;
                }
            }
        }
        #endregion

        public void AddEnemy()
        {
            enemies.Add(new Enemy(12, 2));
            //countEnemies -= 1;
        }
        public bool GameOver()
        {
            if (player.Lives > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #region GameObjectCollisionMethods
        public void PlayerEnemy(Player player, List<Enemy> enemy)
        {
            foreach (var item in enemy)
            {
                if (player.X == item.X && player.Y == item.Y)
                {
                    player.Die();
                }
            }
        }
        public void EnemyEnemy(List<Enemy> enemies)
        {
            //How To Do??
        }
        public void BulletEnemy(List<Bullet> bullet, List<Enemy> enemy)
        {
            for (int i=0; i<bullet.Count();i++)
            {
                for (int j = 0; j < enemy.Count; j++)
                {
                    try
                    {
                        if (bullet[i].X/Game.BlockSize == enemy[j].X/Game.BlockSize && bullet[i].Y/Game.BlockSize == enemy[j].Y/Game.BlockSize)
                        {
                            bullet.RemoveAt(i);
                            enemy.RemoveAt(j);
                            player.GetPoints();
                            //countEnemies -= 1;
                        }
                    }
                    catch
                    {

                    }
                }
            }
        }
        #endregion

        public void Loop()
        {

        }
        public void UpdatePositions()
        {

        }
    }
}





