using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.SqlServer.Server;

namespace Blone
{
    public class Spawner
    {
        private readonly Stopwatch _enemySpawnTimer = new Stopwatch();
        private readonly Stopwatch _heroResourceSpawnTimer = new Stopwatch();
        private readonly Random _randomLocation = new Random();

        private int EnemiesPerKSeconds = 1000;

        public void CheckEnemySpawner()
        {
            _enemySpawnTimer.Start();
            if (_enemySpawnTimer.ElapsedMilliseconds > EnemiesPerKSeconds 
                && GameContainer.EnemyList.Count < DevHelper.EnemyLimit)
            {
                var possibleX = _randomLocation.Next(2, DevHelper.MapWidth);
                var possibleY = _randomLocation.Next(3, DevHelper.MapHeight);
                var validSpawn = true;

                for (int i = 0; i < GameContainer.WallList.Count; i++)
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

                if (validSpawn)
                {
                    var enemy = new Enemy(possibleX, possibleY);
                    GameContainer.EnemyList.Add(enemy);
                    _enemySpawnTimer.Restart();
                }
            }
        }
    }
}