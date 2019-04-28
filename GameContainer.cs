using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Xml;
using System.Xml.Schema;

namespace Blone
{
    public class GameContainer
    {
        /// <summary>
        /// Updates the interface for the user. 
        /// </summary>
        /// <param name="hero">Uses hero param to set _hero.</param>
        public GameContainer(Hero hero)
        {
            _hero = hero;
            UserInterface = new UserInterface(_hero);
            UserInterface.UpdateHealth();
            UserInterface.UpdateAmmo();
            UserInterface.UpdateScore();
        }

        private Random rnd = new Random();
        private ConsoleKeyInfo _keyInfo;
        private Hero _hero;
        private readonly Stopwatch _enemyMoveTimer = new Stopwatch();

        public static bool AliveHero = true;
        public static int Score = 0;
        public static List<Projectile> ProjectileList = new List<Projectile>();
        public static List<Enemy> EnemyList = new List<Enemy>();
        public static Wall[] WallList;
        public static UserInterface UserInterface;
        

        /// <summary>
        /// Updates all projectiles if enough time has elapsed.
        /// </summary>
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

        public static void EndGame()
        {
            AliveHero = false;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Black;
            for (int i = 0; i < 44; i++)
            {
                for (int j = 0; j < 23; j++)
                {
                    Console.SetCursorPosition(DevHelper.XGameOver + i, DevHelper.YGameOver + j);
                    Console.Write("GAMEOVER!");
                    Thread.Sleep(1);
                }
            }

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.SetCursorPosition(DevHelper.XEyeOne + i, DevHelper.YEyeOne + j);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write('o');
                    Thread.Sleep(10);
                }
            }
            
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.SetCursorPosition(DevHelper.XEyeTwo + i, DevHelper.YEyeTwo + j);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write('o');
                    Thread.Sleep(10);
                }
            }

            for (int i = 0; i < 29; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (!(j > 1 && i > 6 && i < 23))
                    {
                        Console.SetCursorPosition(DevHelper.XFrown + i, DevHelper.YFrown + j);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write('o');
                        Thread.Sleep(10);
                    }
                }
            }

            for (int i = 0; i < 17; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.SetCursorPosition(DevHelper.XEyeOne+3 + j, DevHelper.YEyeOne+3 + i);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write('o');
                    Thread.Sleep(100 );
                }
            }
            
            for (int i = 0; i < 17; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.SetCursorPosition(DevHelper.XEyeTwo+3 + j, DevHelper.YEyeTwo+3 + i);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write('o');
                    Thread.Sleep(100 );
                }
            }
            
            
            
            Environment.Exit(0);
        }

        /// <summary>
        /// Updates all enemies in the enemyList
        /// </summary>
        public void UpdateEnemies()
        {
            _enemyMoveTimer.Start();
            if (_enemyMoveTimer.ElapsedMilliseconds > DevHelper.EnemyMovesPerKSeconds)
            {
                for (int i = 0; i < EnemyList.Count; i++)
                {
                    EnemyList[i].HuntHero();
                    _enemyMoveTimer.Restart();
                }
            }
        }

        /// <summary>
        /// Checks if/what hero collides with. 
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
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
                    UserInterface.UpdateHealth();
                    EnemyList.RemoveAt(i);
                }
            }

            return true;
        }

        /// <summary>
        /// Handles all inputs from the user. 
        /// </summary>
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
                                _hero.DrawHero();
                                _hero.UpdateVision(_hero.LookDirection);
                            }
                            break;
                        case ConsoleKey.S:
                            if (CheckHeroCollision(DevHelper.Down))
                            {
                                _hero.MoveHero(DevHelper.Down);
                                _hero.EraseVision();
                                _hero.DrawHero();
                                _hero.UpdateVision(_hero.LookDirection);
                            }
                            break;
                        case ConsoleKey.A:
                            if (CheckHeroCollision(DevHelper.Left))
                            {
                                _hero.MoveHero(DevHelper.Left);
                                _hero.EraseVision();
                                _hero.DrawHero();
                                _hero.UpdateVision(_hero.LookDirection);
                            }
                            break;
                        case ConsoleKey.D:
                            if (CheckHeroCollision(DevHelper.Right))
                            {
                                _hero.MoveHero(DevHelper.Right);
                                _hero.EraseVision();
                                _hero.DrawHero();
                                _hero.DrawHero();
                                _hero.UpdateVision(_hero.LookDirection);
                            }
                            break;
                        case ConsoleKey.R:
                            _hero.Gun.Reload();
                            break;
                        case ConsoleKey.D1:
                            if (_hero.Gun.Reloading == false)
                            {
                                _hero.Gun = _hero.Arsenal[0];
                                UserInterface.UpdateAmmo();
                            }
                            break;
                        case ConsoleKey.D2:
                            if (_hero.Gun.Reloading == false)
                            {
                                _hero.Gun = _hero.Arsenal[1];
                                UserInterface.UpdateAmmo();
                            }
                            break;
                        case ConsoleKey.D3:
                            if (_hero.Gun.Reloading == false)
                            {
                                _hero.Gun = _hero.Arsenal[2];
                                UserInterface.UpdateAmmo();
                            }
                            break;
                    }
                }
            }
        }
    }
}