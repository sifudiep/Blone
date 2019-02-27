using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.SqlServer.Server;

namespace Blone
{
    public class Spawner
    {
        private Stopwatch EnemySpawnTimer = new Stopwatch();
        private Stopwatch HeroResourceSpawnTimer = new Stopwatch();
        private Random RandomLocation = new Random();

        private int EnemiesPerKSeconds = 1000;

        public void CheckEnemySpawner()
        {
            EnemySpawnTimer.Start();
            if (EnemySpawnTimer.ElapsedMilliseconds > EnemiesPerKSeconds)
            {
                var enemy = new Enemy(RandomLocation.Next(0,Console.BufferWidth), RandomLocation.Next(0, Console.BufferHeight));
                GameContainer.EnemyList.Add(enemy);
                EnemySpawnTimer.Restart();
            }
        }
    }
}