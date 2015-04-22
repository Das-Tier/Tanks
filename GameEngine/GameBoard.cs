using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEngine.GameObjects;

namespace GameEngine
{
    public class GameBoard
    {
        public List<IGameObject> gameObjects = new List<IGameObject>();

        public IEnumerable<IGameObject> GameObjects
        {
            get { return gameObjects; }
        }
        public void AddObject(IGameObject gameObject)
        {
            if (IsCorrectPosition(gameObject, gameObject.X, gameObject.Y) == false)
            {
               // throw new ArgumentException("!!!");
            }
            gameObjects.Add(gameObject);
            gameObject.Board = this;
        }
        public bool CanBePlaced(GameObjects.IGameObject gameObject, int newX, int newY)
        {
            if (this.gameObjects.Any(r => r == gameObject) == false)
            {
                //throw new ArgumentException("!!!");
                return false;
            }
            else
            {
                return IsCorrectPosition(gameObject, newX, newY);
            }
        }
        public bool IsCorrectPosition(GameObjects.IGameObject gameObject, int newX, int newY)
        {
            if (this.gameObjects.Any(r => r.X == newX && r.Y == newY) == true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool BulletObjectCollision(GameObjects.DynamicObjects.Bullet bullet, int newX, int newY)
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                if (gameObjects[i].X == newX && gameObjects[i].Y == newY)
                {
                    //throw new ArgumentException("!!!");
                    Type type = gameObjects[i].GetType();
                    #region switch
                    switch (type.FullName)
                    {
                        case "GameEngine.GameObjects.UnmovableObjects.Wall":
                            {
                                // throw new ArgumentException("!!!");
                                gameObjects[i].Transparency = false;
                                Console.SetCursorPosition(gameObjects[i].X, gameObjects[i].Y);
                                Console.Write(' ');
                                gameObjects.Remove(this.gameObjects[i]);
                                gameObjects.Remove(bullet);
                                
                                break;
                            }
                        case "GameEngine.GameObjects.DynamicObjects.Enemy":
                            {
                                if (bullet.OfPlayer == true)
                                {
                                    gameObjects[i].Transparency = false;
                                    gameObjects.Remove(this.gameObjects[i]);
                                }
                                //gameObjects.Remove(bullet);
                                break;
                            }
                        case "GameEngine.GameObjects.UnmovableObjects.Concrete":
                            {
                              // throw new ArgumentException("!!!");
                              break;
                            }
                    }
                    #endregion
                    bullet.Transparency = false;
                    gameObjects.Remove(bullet);
                    return false;
                }
            }
            return true;
        }
    }
}


