using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.SqlServer.Server;

namespace Blone
{
    public class Spawner
    {
        /// <summary>
        /// Sets _hero as the parameter hero.
        /// </summary>
        /// <param name="hero">Current hero player.</param>
        public Spawner(Hero hero)
        {
            _hero = hero;
        }

        private readonly Hero _hero; 
        private readonly Stopwatch _enemySpawnTimer = new Stopwatch();
        private readonly Random _randomLocation = new Random();

        private int EnemiesPerKSeconds = 1000;

        /// <summary>
        /// Checks if enemy should spawn with a _enemySpawnTimer, spawns if it should, doesn't spawn if it shouldn't. 
        /// </summary>
        public void CheckEnemySpawner()
        {
            _enemySpawnTimer.Start();
            if (_enemySpawnTimer.ElapsedMilliseconds > EnemiesPerKSeconds 
                && GameContainer.EnemyList.Count < DevHelper.EnemyLimit)
            {
                var possibleX = _randomLocation.Next(2, DevHelper.MapWidth);
                var possibleY = _randomLocation.Next(3, DevHelper.MapHeight);
                var validSpawn = true;

                for (int i = 0; i < GameContainer.WallList.Length; i++)
                {
                    if (GameContainer.WallList[i].X == possibleX && GameContainer.WallList[i].Y == possibleY)
                    {
                        validSpawn = false;
                        break;
                    }
                }

                for (int i = 0; i < GameContainer.EnemyList.Count; i++)
                {
                    if (GameContainer.EnemyList[i].X == possibleX && GameContainer.WallList[i].Y == possibleY)
                    {
                        validSpawn = false;
                        break;
                    }
                }
                
                if (possibleX == _hero.X && possibleY == _hero.Y)
                {
                    validSpawn = false;
                }

                if (validSpawn)
                {
                    var enemy = new Enemy(possibleX, possibleY, _hero);
                    GameContainer.EnemyList.Add(enemy);
                    _enemySpawnTimer.Restart();
                }
            }
        }
    }
}