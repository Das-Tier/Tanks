using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameEngine;
using System.Linq;
using GameEngine.GameObjects.DynamicObjects;
using GameEngine.GameObjects.UnmovableObjects;

namespace GameEngineTest
{
    [TestClass]
    public class GameEngineTest
    {
        [TestMethod]
        public void TestConstructor()
        {
            GameBoard board = new GameBoard();
            Assert.IsNotNull(board);
        }
        [TestMethod]
        public void TestCanBePlaced()
        {
            GameBoard board = new GameBoard();
           GameEngine.GameObjects.IGameObject p1 = new Player(1, 1);
            GameEngine.GameObjects.IGameObject p2 = new Player(2, 2);
            board.AddObject(p1);
            board.AddObject(p2);
            Assert.IsTrue(board.CanBePlaced(p1, 3, 2));
            Assert.IsTrue(board.CanBePlaced(p1, 3, 5));

            Assert.IsFalse(board.CanBePlaced(p1, 2, 2));
        }
        [TestMethod]
        public void TestAddObject()
        {
            GameBoard board = new GameBoard();
            GameEngine.GameObjects.IGameObject player = new Player(1, 1);
            board.AddObject(player);
            GameEngine.GameObjects.IGameObject lastGameObject = board.GameObjects.Last();
            Assert.AreSame(lastGameObject, player);
            Assert.AreSame(board, player.Board);
        }
        [TestMethod]
        public void CheckGameConstructor()
        {
            Game game = new Game();
            Assert.IsNotNull(game.bullets);
            Assert.IsNotNull(game.enemies);
            Assert.IsNotNull(game.GameBoard);
            Assert.IsNotNull(game.player);

        }
        [TestMethod]
        public void CheckFire()
        {
            Game game = new Game();
            game.Fire(game.player);
            Bullet bullet=game.bullets.Last();
            Assert.IsTrue(game.player.X == bullet.X && game.player.Y == bullet.Y && game.player.Direction == bullet.Direction);
        }
        [TestMethod]
        public void TestLoadMap()
        {
            World world = new World();
            Assert.IsNotNull(world);
        }
        [TestMethod]
        public void TestPlayerCheckMoveOn()
        {
            GameBoard board = new GameBoard();
            Player p1 = new Player(1, 1);
            board.AddObject(p1);
            p1.MoveOn(1, 1);
            Assert.IsTrue(p1.X == 2 && p1.Y == 2);
            Assert.IsTrue(p1.CheckMoveOn(1, 1));
                     
            
        }
        [TestMethod]
        public void CheckWall()
        {
            Wall wall = new Wall(1, 1);
            Assert.IsTrue(wall.Transparency == true);
            Assert.IsNotNull(wall);
            Assert.IsTrue(wall.X == 1 && wall.Y == 1);
        }
        [TestMethod]
        public void CheckConcrete()
        {
            Wall wall = new Wall(1, 1);
            Assert.IsTrue(wall.Transparency == true);
            Assert.IsNotNull(wall);
            Assert.IsTrue(wall.X == 1 && wall.Y == 1);
        }
        [TestMethod]
        public void CheckBullet()
        {
            GameBoard board = new GameBoard();
            Bullet bullet = new Bullet(5, 5, GameEngine.GameObjects.Direction.Down);
            Wall wall=new Wall(6,6);
            Concrete concrete=new Concrete(4,4);
            board.AddObject(concrete);
            board.AddObject(wall);
            board.AddObject(bullet);
            Assert.IsFalse(bullet.CheckMoveOn(4, 4));
            Assert.IsFalse(bullet.CheckMoveOn(6, 6));
            Assert.IsTrue(bullet.CheckMoveOn(3, 3));
           
        }
        [TestMethod]
        public void CheckBulletMove()
        {
            GameBoard board=new GameBoard();
            Bullet bullet = new Bullet(5, 5, GameEngine.GameObjects.Direction.Down);
            board.AddObject(bullet);
            bullet.MoveOn(0, 0);
            Assert.IsTrue(bullet.Y == 6);
            bullet.Direction = GameEngine.GameObjects.Direction.Up;
            bullet.MoveOn(0, 0);
            Assert.IsTrue(bullet.Y == 5);
            bullet.Direction = GameEngine.GameObjects.Direction.Left;
            bullet.MoveOn(0, 0);
            Assert.IsTrue(bullet.X == 4);
            bullet.Direction = GameEngine.GameObjects.Direction.Right;
            bullet.MoveOn(0, 0);
            Assert.IsTrue(bullet.X == 5);
        }
    }
}
