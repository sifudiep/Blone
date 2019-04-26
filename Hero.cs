using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Xml;
using Microsoft.SqlServer.Server;

namespace Blone
{
    public class Hero
    {
        public int X;
        public int Y;
        public string LookDirection;
        public static List<VisionCoordinate> VisionCoordinates = new List<VisionCoordinate>();
        public int Health; 
        public Gun Gun;
        public List<Gun> Arsenal = new List<Gun>();
        

        /// <summary>
        /// Sets start values for the multiple fields.
        /// Also initializes the VisionCoordinates. 
        /// </summary>
        public Hero()
        {
            X = DevHelper.MapWidth / 2;
            Y = DevHelper.MapHeight / 2;
            Arsenal.Add(new Pistol());
            Arsenal.Add(new Rifle());
            Arsenal.Add(new Shotgun());
            Gun = Arsenal[0];
            Health = DevHelper.StartHealth;
            // Initialize VisionCoordinates list
            for (int i = 0; i < 24; i++)
            {
                VisionCoordinate visionCoordinate; 
                if (i == 0 || i == 1 || i == 2)
                {
                    visionCoordinate = new VisionCoordinate()
                    {
                        FirstVictim = new VisionCoordinate(),
                        SecondVictim = new VisionCoordinate(),
                        Essential = true,
                    };
                }
                else
                {
                    visionCoordinate = new VisionCoordinate()
                    {
                        FirstVictim = new VisionCoordinate(),
                        SecondVictim = new VisionCoordinate(),
                    };
                }
                VisionCoordinates.Add(visionCoordinate);
            }

            for (int i = 0; i < VisionCoordinates.Count; i++)
            {
                int row = 1;

                if (i < 3)
                    row = 1;
                if (i > 2 && i < 8)
                    row = 2;
                if (i > 7 && i < 15)
                    row = 3;
                if (i > 14)
                    row = 4;

                VisionCoordinates[i].Row = row;
                
                // Rightside
                if (i == 0 || i == 4 || i == 3 || i == 10 || i == 9 || i == 8)
                {
                    VisionCoordinates[i].FirstVictim = VisionCoordinates[i + (2 + 2 * row)];
                    VisionCoordinates[i].SecondVictim = VisionCoordinates[i + (1 + 2 * row)];
                }
                // Middle
                if (i == 1 || i == 5 || i == 11)
                {
                    VisionCoordinates[i].FirstVictim = VisionCoordinates[i + (2 + 2 * row)];
                }
                // LeftSide
                if (i == 2 || i == 7 || i == 6 || i == 14 || i == 13 || i == 12)
                {
                    VisionCoordinates[i].FirstVictim = VisionCoordinates[i + (2 + 2 * row)];
                    VisionCoordinates[i].SecondVictim = VisionCoordinates[i + (3 + 2 * row)];
                }
            }
        }

        /// <summary>
        /// Checks if enemies collides with the visionCoordinates. 
        /// </summary>
        public void CheckEnemiesInVision()
        {
            for (int i = 0; i < GameContainer.EnemyList.Count; i++)
            {
                for (int j = 0; j < VisionCoordinates.Count; j++)
                {
                    if (GameContainer.EnemyList[i].X == VisionCoordinates[j].X && 
                        GameContainer.EnemyList[i].Y == VisionCoordinates[j].Y && 
                        VisionCoordinates[j].InsideWall == false)
                    {
                       GameContainer.EnemyList[i].Draw();
                    }
                }
            }
        }
        
        /// <summary>
        /// Updates the visionCoordinates to fit the direction and coordinates of the Hero.
        /// </summary>
        /// <param name="direction"></param>
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
                                // Checks if the current visionCoordinate collides with a wall.
                                for (int k = 0; k < GameContainer.WallList.Length; k++)
                                {
                                    if (GameContainer.WallList[k].X == X - j + i &&
                                        GameContainer.WallList[k].Y == Y - i)
                                    {
                                        VisionCoordinates[visionCoordinateTracker].Infected = true;
                                        VisionCoordinates[visionCoordinateTracker].InsideWall = true;
                                        break;
                                    }

                                    VisionCoordinates[visionCoordinateTracker].InsideWall = false;
                                    
                                }

                                if (VisionCoordinates[visionCoordinateTracker].Infected &&
                                    VisionCoordinates[visionCoordinateTracker].InsideWall == false &&
                                    VisionCoordinates[visionCoordinateTracker].Essential)
                                {
                                    VisionCoordinates[visionCoordinateTracker].Infected = false;
                                }
                                
                                // Writes and sets visionCoordinate
                                if (VisionCoordinates[visionCoordinateTracker].Infected == false )
                                {
                                    Console.SetCursorPosition(X - j + i, Y - i);
                                    Console.BackgroundColor = ConsoleColor.Yellow;
                                    Console.Write(" ");
                                    VisionCoordinates[visionCoordinateTracker].X = (X - j + i);
                                    VisionCoordinates[visionCoordinateTracker].Y = (Y - i);
                                    if (VisionCoordinates[visionCoordinateTracker].Row < 4)
                                    {
                                        VisionCoordinates[visionCoordinateTracker].FirstVictim.Infected = false;
                                        VisionCoordinates[visionCoordinateTracker].SecondVictim.Infected = false;
                                    }
                                    
                                }
                                else
                                {
                                    if (VisionCoordinates[visionCoordinateTracker].Row < 4)
                                    {
                                        VisionCoordinates[visionCoordinateTracker].FirstVictim.Infected = true;
                                        VisionCoordinates[visionCoordinateTracker].SecondVictim.Infected = true;
                                    }
                                }
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
                            // Checks if the current visionCoordinate collides with a wall.
                            for (int k = 0; k < GameContainer.WallList.Length; k++)
                            {
                                if (GameContainer.WallList[k].X == X - j + i &&
                                    GameContainer.WallList[k].Y == Y + i)
                                {
                                    VisionCoordinates[visionCoordinateTracker].Infected = true;
                                    VisionCoordinates[visionCoordinateTracker].InsideWall = true;
                                    break;
                                }

                                VisionCoordinates[visionCoordinateTracker].InsideWall = false;
                                
                            }

                            if (VisionCoordinates[visionCoordinateTracker].Infected &&
                                VisionCoordinates[visionCoordinateTracker].InsideWall == false &&
                                VisionCoordinates[visionCoordinateTracker].Essential)
                            {
                                VisionCoordinates[visionCoordinateTracker].Infected = false;
                            }
                            
                            // Writes and sets visionCoordinate
                            if (VisionCoordinates[visionCoordinateTracker].Infected == false )
                            {
                                Console.SetCursorPosition(X - j + i, Y + i);
                                Console.BackgroundColor = ConsoleColor.Yellow;
                                Console.Write(" ");
                                VisionCoordinates[visionCoordinateTracker].X = (X - j + i);
                                VisionCoordinates[visionCoordinateTracker].Y = (Y + i);
                                if (VisionCoordinates[visionCoordinateTracker].Row < 4)
                                {
                                    VisionCoordinates[visionCoordinateTracker].FirstVictim.Infected = false;
                                    VisionCoordinates[visionCoordinateTracker].SecondVictim.Infected = false;
                                }
                                
                            }
                            else
                            {
                                if (VisionCoordinates[visionCoordinateTracker].Row < 4)
                                {
                                    VisionCoordinates[visionCoordinateTracker].FirstVictim.Infected = true;
                                    VisionCoordinates[visionCoordinateTracker].SecondVictim.Infected = true;
                                }
                            }
                            visionCoordinateTracker++;
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
                                for (int k = 0; k < GameContainer.WallList.Length; k++)
                                {
                                    if (GameContainer.WallList[k].X == X - i &&
                                        GameContainer.WallList[k].Y == Y - j + i)
                                    {
                                        VisionCoordinates[visionCoordinateTracker].Infected = true;
                                        VisionCoordinates[visionCoordinateTracker].InsideWall = true;
                                        break;
                                    }

                                    VisionCoordinates[visionCoordinateTracker].InsideWall = false;
                                    
                                }

                                if (VisionCoordinates[visionCoordinateTracker].Infected &&
                                    VisionCoordinates[visionCoordinateTracker].InsideWall == false &&
                                    VisionCoordinates[visionCoordinateTracker].Essential)
                                {
                                    VisionCoordinates[visionCoordinateTracker].Infected = false;
                                }
                                
                                // Writes and sets visionCoordinate
                                if (VisionCoordinates[visionCoordinateTracker].Infected == false )
                                {
                                    Console.SetCursorPosition(X - i, Y - j + i);
                                    Console.BackgroundColor = ConsoleColor.Yellow;
                                    Console.Write(" ");
                                    VisionCoordinates[visionCoordinateTracker].X = (X - i);
                                    VisionCoordinates[visionCoordinateTracker].Y = (Y - j + i);
                                    if (VisionCoordinates[visionCoordinateTracker].Row < 4)
                                    {
                                        VisionCoordinates[visionCoordinateTracker].FirstVictim.Infected = false;
                                        VisionCoordinates[visionCoordinateTracker].SecondVictim.Infected = false;
                                    }
                                    
                                }
                                else
                                {
                                    if (VisionCoordinates[visionCoordinateTracker].Row < 4)
                                    {
                                        VisionCoordinates[visionCoordinateTracker].FirstVictim.Infected = true;
                                        VisionCoordinates[visionCoordinateTracker].SecondVictim.Infected = true;
                                    }
                                }
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
                                
                                for (int k = 0; k < GameContainer.WallList.Length; k++)
                                {
                                    if (GameContainer.WallList[k].X == X + i &&
                                        GameContainer.WallList[k].Y == Y - j + i)
                                    {
                                        VisionCoordinates[visionCoordinateTracker].Infected = true;
                                        VisionCoordinates[visionCoordinateTracker].InsideWall = true;
                                        break;
                                    }

                                    VisionCoordinates[visionCoordinateTracker].InsideWall = false;
                                    
                                }

                                if (VisionCoordinates[visionCoordinateTracker].Infected &&
                                    VisionCoordinates[visionCoordinateTracker].InsideWall == false &&
                                    VisionCoordinates[visionCoordinateTracker].Essential)
                                {
                                    VisionCoordinates[visionCoordinateTracker].Infected = false;
                                }
                                
                                // Writes and sets visionCoordinate
                                if (VisionCoordinates[visionCoordinateTracker].Infected == false )
                                {
                                    Console.SetCursorPosition(X + i, Y - j + i);
                                    Console.BackgroundColor = ConsoleColor.Yellow;
                                    Console.Write(" ");
                                    VisionCoordinates[visionCoordinateTracker].X = (X + i);
                                    VisionCoordinates[visionCoordinateTracker].Y = (Y - j + i);
                                    if (VisionCoordinates[visionCoordinateTracker].Row < 4)
                                    {
                                        VisionCoordinates[visionCoordinateTracker].FirstVictim.Infected = false;
                                        VisionCoordinates[visionCoordinateTracker].SecondVictim.Infected = false;
                                    }
                                    
                                }
                                else
                                {
                                    if (VisionCoordinates[visionCoordinateTracker].Row < 4)
                                    {
                                        VisionCoordinates[visionCoordinateTracker].FirstVictim.Infected = true;
                                        VisionCoordinates[visionCoordinateTracker].SecondVictim.Infected = true;
                                    }
                                }
                                visionCoordinateTracker++;
                            }
                        }
                    }
                    break;
            }
            Console.BackgroundColor = ConsoleColor.Black;
            CheckEnemiesInVision();

        }

        /// <summary>
        /// Erases the vision of the hero at its current coordinates.
        /// </summary>
        public void EraseVision()
        {
            for (int i = 0; i < VisionCoordinates.Count; i++)
            {
                Console.SetCursorPosition(VisionCoordinates[i].X, VisionCoordinates[i].Y);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(" ");
            }
        }

        /// <summary>
        /// Erases the hero at its current coordinates.
        /// </summary>
        public void EraseHero()
        {
            Console.SetCursorPosition(X,Y);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(' ');
        }

        /// <summary>
        ///  Draws the hero at its current coordinates. 
        /// </summary>
        public void DrawHero()
        {
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write('H');
        }
        /// <summary>
        /// Draws hero at specific coordinates. 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void DrawHero(int x, int y)
        {
            Y = y;
            X = x;
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write('H');
        }

        /// <summary>
        /// Changes look direction for the hero.
        /// </summary>
        /// <param name="direction">Direction which hero should have.</param>
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
        
        /// <summary>
        /// Moves hero in the parameter direction.
        /// </summary>
        /// <param name="direction">What direction the hero should move in.</param>
        public void MoveHero(string direction)
        {
            switch (direction)
            {
                case DevHelper.Up:
                    EraseHero();
                    DrawHero(X, Y-1);
                    break;
                case DevHelper.Down:
                    EraseHero();
                    DrawHero(X, Y + 1);
                    break;
                case DevHelper.Left:
                    EraseHero();
                    DrawHero(X - 1, Y);
                    break;
                case DevHelper.Right:
                    EraseHero();
                    DrawHero(X + 1, Y);
                    break;
            }
            CheckEnemiesInVision();
        }
    }
}