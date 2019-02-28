using System;
using System.Data;
using System.Xml;

namespace Blone
{
    public class Hero
    {
        public int X;
        public int Y;
        public string LookDirection;
        public int[,] VisionCoordinates = new int[25,2];
        public Gun Gun;

        public Hero()
        {
            X = 20;
            Y = 20;
            DrawHero(X, Y);
            Gun = new Shotgun();
            LookDirection = DevHelper.Up;
            UpdateVision(LookDirection);
        }

        public void CheckEnemiesInVision()
        {
            for (int i = 0; i < GameContainer.EnemyList.Count; i++)
            {
                for (int j = 0; j < VisionCoordinates.Length/2; j++)
                {
                    var enemy = GameContainer.EnemyList[i];
                    var visionX = VisionCoordinates[j, 0];
                    var visionY = VisionCoordinates[j, 1];
                    
                    if (enemy.X == visionX && enemy.Y == visionY)
                    {
                        enemy.Draw();
                    }

                }
            }
        }
        public void UpdateVision(string direction)
        {
            var visionCoordinateTracker = 0;
            switch (direction)
            {
                case DevHelper.Up:
                    for (int i = 1; i < 5; i++)
                    {
                        for (int j = 0; j < 1 + 2*i; j++)
                        {
                            if (X - j + i > -1 && X - j + i < Console.BufferWidth && Y - i > -1 && Y - i < Console.BufferHeight)
                            {
                                Console.SetCursorPosition(X - j + i, Y - i);
                                Console.BackgroundColor = ConsoleColor.Yellow;
                                Console.Write(" ");
                                VisionCoordinates[visionCoordinateTracker, 0] = (X - j + i);
                                VisionCoordinates[visionCoordinateTracker, 1] = (Y - i);
                                visionCoordinateTracker++;
                            }
                        }
                    }
                    break;
                case DevHelper.Down:
                    for (int i = 1; i < 5; i++)
                    {
                        for (int j = 0; j < 1 + 2*i; j++)
                        {
                            if (X - j + i > -1 && X - j + i < Console.BufferWidth && Y + i > -1 && Y + i < Console.BufferHeight)
                            {
                                Console.SetCursorPosition(X - j + i, Y + i);
                                Console.BackgroundColor = ConsoleColor.Yellow;
                                Console.Write(" ");
                                VisionCoordinates[visionCoordinateTracker, 0] = (X - j + i);
                                VisionCoordinates[visionCoordinateTracker, 1] = (Y + i);
                                visionCoordinateTracker++;
                            }
                        }
                    }
                    break;
                case DevHelper.Left:
                    for (int i = 1; i < 5; i++)
                    {
                        for (int j = 0; j < 1 + 2*i; j++)
                        {
                            if (X - i > -1 && X - i < Console.BufferWidth && Y - j + i > -1 && Y - j + i < Console.BufferHeight)
                            {
                                Console.SetCursorPosition(X - i, Y - j + i);
                                Console.BackgroundColor = ConsoleColor.Yellow;
                                Console.Write(" ");
                                VisionCoordinates[visionCoordinateTracker, 0] = X - i;
                                VisionCoordinates[visionCoordinateTracker, 1] = Y - j + i;
                                visionCoordinateTracker++;
                            }
                        }
                    }
                    break;
                case DevHelper.Right:
                    for (int i = 1; i < 5; i++)
                    {
                        for (int j = 0; j < 1 + 2*i; j++)
                        {
                            if (X + i > -1 && X + i < Console.BufferWidth && Y - j + i > -1 && Y - j + i < Console.BufferHeight)
                            {
                                Console.SetCursorPosition(X + i, Y - j + i);
                                Console.BackgroundColor = ConsoleColor.Yellow;
                                Console.Write(" ");
                                VisionCoordinates[visionCoordinateTracker, 0] = X + i;
                                VisionCoordinates[visionCoordinateTracker, 1] = Y - j + i;
                                visionCoordinateTracker++;
                            }
                        }
                    }
                    break;
            }
            Console.BackgroundColor = ConsoleColor.Black;
            CheckEnemiesInVision();

        }

        public void EraseVision()
        {
            for (int i = 0; i < VisionCoordinates.Length/2; i++)
            {
                Console.SetCursorPosition(VisionCoordinates[i, 0], VisionCoordinates[i, 1]);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(" ");
            }
        }

        public void EraseHero()
        {
            Console.SetCursorPosition(X,Y);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(' ');
        }

        public void DrawHero(int x, int y)
        {
            Y = y;
            X = x;
            Console.SetCursorPosition(x, y);
            Console.Write('H');
        }

        public void ChangeLookDirection(string direction)
        {
            switch (direction) 
            {
                case DevHelper.Up:
                    if (LookDirection == DevHelper.Up)
                    {
                        Gun.Shoot(X, Y, LookDirection);
                    }
                    else
                    {
                        LookDirection = DevHelper.Up;
                        EraseVision();
                        UpdateVision(LookDirection);
                    }
                    break;
                case DevHelper.Down:
                    if (LookDirection == DevHelper.Down)
                    {
                        Gun.Shoot(X, Y, LookDirection);
                    }
                    else
                    {
                        LookDirection = DevHelper.Down;
                        EraseVision();
                        UpdateVision(LookDirection);       
                    }
                    break;
                case DevHelper.Left:
                    if (LookDirection == DevHelper.Left)
                    {
                        Gun.Shoot(X, Y, LookDirection);
                    }
                    else
                    {
                        LookDirection = DevHelper.Left;        
                        EraseVision();
                        UpdateVision(LookDirection);       
                    }
                    break;
                case DevHelper.Right:
                    if (LookDirection == DevHelper.Right)
                    {
                        Gun.Shoot(X, Y, LookDirection);
                    }
                    else
                    {
                        LookDirection = DevHelper.Right;   
                        EraseVision();
                        UpdateVision(LookDirection);       
                    }
                    break;
            }
        }
        
        public void MoveHero(string direction)
        {
            switch (direction)
            {
                case DevHelper.Up:
                    if (Y - 1 >= 0 && Y - 1 < Console.BufferHeight)
                    {
                        EraseHero();
                        DrawHero(X, Y-1);
                    }
                    break;
                case DevHelper.Down:
                    if (Y+1 >= 0 && Y+1 < Console.BufferHeight)
                    {
                        EraseHero();
                        DrawHero(X, Y + 1);
                    }
                    break;
                case DevHelper.Left:
                    if (X - 1 >= 0 && X - 1 < Console.BufferWidth)
                    {
                        EraseHero();
                        DrawHero(X - 1, Y);
                    }
                    break;
                case DevHelper.Right:
                    if (X + 1 >= 0 && X + 1 < Console.BufferWidth)
                    {
                        EraseHero();
                        DrawHero(X + 1, Y);
                    }
                    break;
            }
            CheckEnemiesInVision();
        }
    }
}