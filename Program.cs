using System;
using System.Runtime.CompilerServices;
using System.Xml;

namespace Blone
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var gc = new GameContainer(new Hero());
            var spawner = new Spawner();
            GameContainer.WallList = new Wall[196];
            var mapCreator = new MapCreator();
            mapCreator.MapSettings();
            Console.CursorVisible = false;
            while (true)
            {
                gc.HandleInput();
                gc.UpdateProjectiles();
                spawner.CheckEnemySpawner();
            }  
        }

        
        
        
    }
}