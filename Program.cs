using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml;

namespace Blone
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Start:
            Console.Clear();
            Console.WriteLine("For game instructions type '!help' for help");
            Console.WriteLine("Otherwise type '!start' to start the game");
            var input = Console.ReadLine();
            
            if (input == "!start")
            {
                Console.Clear();
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
            else if (input == "!help")
            {
                Console.WriteLine("-Move the hero using the WASD keys.");
                Console.WriteLine("-Control the field of view with the arrow keys.");
                Console.WriteLine("-You can also shoot using the arrow keys, however you may only shoot in the direction that your watching.");
                Console.WriteLine("-Meaning that to shoot to the left, you must first have placed you field of view to the left of your hero.");
                Console.WriteLine("-Using the number buttons above WASD (not on the numpad) you can switch guns.");
                Console.WriteLine("-In the bottom left corner you will also see your ammo,\n once you deplete your ammo you can either reload the guns or switch to another one using the number buttons");
                Console.WriteLine("-Once your health reaches 0, you lose the game.");
                Console.ReadLine();
                goto Start;
            }
            else
            {
                goto Start;
            }
        }

        
        
        
    }
}
