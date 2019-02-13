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
        private Stopwatch _bulletMovement = new Stopwatch();

        public void UpdateProjectiles()
        {
            _bulletMovement.Start();
            for (int i = 0; i < ProjectileList.Count; i++)
            {
                if (ProjectileList[i].Type == DevHelper.Bullet && _bulletMovement.ElapsedMilliseconds > 1000)
                {
                    if (ProjectileList[i].CheckCollision() == DevHelper.NoCollision)
                    {
                        ProjectileList[i].Move();
                        _bulletMovement.Reset();
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
                            _hero.UpdateVision(_hero.LookDirection);
                            break;
                        case ConsoleKey.S:
                            _hero.EraseVision();
                            _hero.MoveHero(DevHelper.Down);
                            _hero.UpdateVision(_hero.LookDirection);
                            break;
                        case ConsoleKey.A:
                            _hero.EraseVision();
                            _hero.MoveHero(DevHelper.Left);
                            _hero.UpdateVision(_hero.LookDirection);
                            break;
                        case ConsoleKey.D:                            
                            _hero.EraseVision();
                            _hero.MoveHero(DevHelper.Right);
                            _hero.UpdateVision(_hero.LookDirection);
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