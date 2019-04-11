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
            UserInterface = new UserInterface(_hero);
            UserInterface.UpdateHealth();
            UserInterface.UpdateAmmo();
        }
        private ConsoleKeyInfo _keyInfo;
        private Hero _hero;
        
        public static List<Projectile> ProjectileList = new List<Projectile>();
        public static List<Enemy> EnemyList = new List<Enemy>();
        public static Wall[] WallList;
        public static UserInterface UserInterface;

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
                }
            }
        }

        public bool CheckHeroCollision(string direction)
        {
            var possibleX = _hero.X;
            var possibleY = _hero.Y;

            switch (direction)
            {
                case DevHelper.Up:
                    possibleY -= 1;
                    break;
                case DevHelper.Down:
                    possibleY += 1;
                    break;
                case DevHelper.Left:
                    possibleX -= 1;
                    break;
                case DevHelper.Right:
                    possibleX += 1;
                    break;
            }

            for (int i = 0; i < WallList.Length; i++)
            {
                if (WallList[i].X == possibleX && WallList[i].Y == possibleY)
                {
                    return false;
                }
            }

            for (int i = 0; i < EnemyList.Count; i++)
            {
                if (EnemyList[i].X == possibleX && EnemyList[i].Y == possibleY)
                {
                    _hero.Health -= DevHelper.EnemyDamage;
                    GameContainer.UserInterface.UpdateHealth();
                    EnemyList.RemoveAt(i);
                }
            }

            return true;
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
                            if (CheckHeroCollision(DevHelper.Up))
                            {
                                _hero.MoveHero(DevHelper.Up);
                                _hero.EraseVision();
                                _hero.UpdateVision(_hero.LookDirection);
                            }
                            break;
                        case ConsoleKey.S:
                            if (CheckHeroCollision(DevHelper.Down))
                            {
                                _hero.MoveHero(DevHelper.Down);
                                _hero.EraseVision();
                                _hero.UpdateVision(_hero.LookDirection);
                            }
                            break;
                        case ConsoleKey.A:
                            if (CheckHeroCollision(DevHelper.Left))
                            {
                                _hero.MoveHero(DevHelper.Left);
                                _hero.EraseVision();
                                _hero.UpdateVision(_hero.LookDirection);
                            }
                            break;
                        case ConsoleKey.D:
                            if (CheckHeroCollision(DevHelper.Right))
                            {
                                _hero.MoveHero(DevHelper.Right);
                                _hero.EraseVision();
                                _hero.UpdateVision(_hero.LookDirection);
                            }
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