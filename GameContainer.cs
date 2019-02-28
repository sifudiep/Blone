using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Blone
{
    public class GameContainer
    {
        public GameContainer(Hero hero)
        {
            _hero = hero;
        }
        private ConsoleKeyInfo _keyInfo;
        private Hero _hero;
        
        public static List<Projectile> ProjectileList = new List<Projectile>();
        public static List<Enemy> EnemyList = new List<Enemy>();

        public void UpdateProjectiles()
        {
            for (int i = 0; i < ProjectileList.Count; i++)
            {
                ProjectileList[i].MoveStopwatch.Start();
                if (ProjectileList[i].MoveStopwatch.ElapsedMilliseconds > ProjectileList[i].Speed)
                {
                    if (ProjectileList[i].CheckCollision() == DevHelper.NoCollision)
                    {
                        ProjectileList[i].Move();
                    }
                    else
                    {
                        ProjectileList[i].Erase();
                        ProjectileList.RemoveAt(i);
                    }
                }
            }
        }

        public void HandleInput()
        {
            if (Console.KeyAvailable)
            {
                if ((_keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
                {
                    switch (_keyInfo.Key) 
                    {
                        case ConsoleKey.UpArrow:
                            _hero.ChangeLookDirection(DevHelper.Up);
                            break;
                        case ConsoleKey.DownArrow:
                            _hero.ChangeLookDirection(DevHelper.Down);
                            break;
                        case ConsoleKey.LeftArrow:
                            _hero.ChangeLookDirection(DevHelper.Left);
                            break;
                        case ConsoleKey.RightArrow:
                            _hero.ChangeLookDirection(DevHelper.Right);
                            break;
                        case ConsoleKey.W:
                            _hero.EraseVision();
                            _hero.MoveHero(DevHelper.Up);
                            _hero.EraseVision();
                            _hero.UpdateVision(_hero.LookDirection);
                            break;
                        case ConsoleKey.S:
                            _hero.EraseVision();
                            _hero.MoveHero(DevHelper.Down);
                            _hero.EraseVision();
                            _hero.UpdateVision(_hero.LookDirection);
                            break;
                        case ConsoleKey.A:
                            _hero.EraseVision();
                            _hero.MoveHero(DevHelper.Left);
                            _hero.EraseVision();
                            _hero.UpdateVision(_hero.LookDirection);
                            break;
                        case ConsoleKey.D:                            
                            _hero.EraseVision();
                            _hero.MoveHero(DevHelper.Right);
                            _hero.EraseVision();
                            _hero.UpdateVision(_hero.LookDirection);
                            break;
                        case ConsoleKey.R:
                            _hero.Gun.Reload();
                            break;
                        case ConsoleKey.Spacebar:
                            Console.WriteLine("SPACEBAR");
                            // Use powerup
                            break;
                    }
                }
            }
        }
    }
}