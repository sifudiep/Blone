using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml;

namespace Blone
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var hero = new Hero();
            var gc = new GameContainer(hero);
            var spawner = new Spawner(hero);
            GameContainer.WallList = new Wall[196];
            var mapCreator = new MapCreator();
            mapCreator.MapSettings();
            Console.CursorVisible = false;
            while (GameContainer.AliveHero)
            {
                gc.HandleInput();
                gc.UpdateProjectiles();
                spawner.CheckEnemySpawner();
                gc.UpdateEnemies();
            }  
        }

        
        
        
    }
}
