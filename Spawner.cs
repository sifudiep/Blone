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

        private int EnemiesPerKSeconds = 1;

        public void CheckEnemySpawner()
        {
            _enemySpawnTimer.Start();
            if (_enemySpawnTimer.ElapsedMilliseconds > EnemiesPerKSeconds)
            {
                var enemy = new Enemy(_randomLocation.Next(0,Console.BufferWidth), _randomLocation.Next(0, Console.BufferHeight));
                GameContainer.EnemyList.Add(enemy);
                _enemySpawnTimer.Restart();
            }
        }
    }
}