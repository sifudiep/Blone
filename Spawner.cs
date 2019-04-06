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
            if (_enemySpawnTimer.ElapsedMilliseconds > EnemiesPerKSeconds)
            {
                var enemy = new Enemy(_randomLocation.Next(0,DevHelper.MapWidth), _randomLocation.Next(0, DevHelper.MapHeight));
                GameContainer.EnemyList.Add(enemy);
                _enemySpawnTimer.Restart();
            }
        }
    }
}