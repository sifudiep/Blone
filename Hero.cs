using System;
using System.Data;
using System.Xml;

namespace Blone
{
    public class Hero
    {
        private int _x;
        private int _y;
        public string LookDirection;
        public readonly int[,] VisionCoordinates = new int[25,2];
        public Gun Gun;

        public Hero()
        {
            _x = Console.BufferWidth/2;
            _y = Console.BufferHeight/2;
            DrawHero(_x, _y);
            Gun = new Rifle();
        }

        public void UpdateVision(string direction)
        {
            var VisionCoordinateTracker = 0;
            switch (direction)
            {
                case DevHelper.Up:
                    for (int i = 1; i < 5; i++)
                    {
                        for (int j = 0; j < 1 + 2*i; j++)
                        {
                            if (_x - j + i > -1 && _x - j + i < Console.BufferWidth && _y - i > -1 && _y - i < Console.BufferHeight)
                            {
                                Console.SetCursorPosition(_x - j + i, _y - i);
                                Console.BackgroundColor = ConsoleColor.Yellow;
                                Console.Write(" ");
                                VisionCoordinates[VisionCoordinateTracker, 0] = (_x - j + i);
                                VisionCoordinates[VisionCoordinateTracker, 1] = (_y - i);
                                VisionCoordinateTracker++;
                            }
                            
                        }
                    }
                    break;
                case DevHelper.Down:
                    for (int i = 1; i < 5; i++)
                    {
                        for (int j = 0; j < 1 + 2*i; j++)
                        {
                            if (_x - j + i > -1 && _x - j + i < Console.BufferWidth && _y + i > -1 && _y + i < Console.BufferHeight)
                            {
                                Console.SetCursorPosition(_x - j + i, _y + i);
                                Console.BackgroundColor = ConsoleColor.Yellow;
                                Console.Write(" ");
                                VisionCoordinates[VisionCoordinateTracker, 0] = (_x - j + i);
                                VisionCoordinates[VisionCoordinateTracker, 1] = (_y + i);
                                VisionCoordinateTracker++;
                            }
                        }
                    }
                    break;
                case DevHelper.Left:
                    for (int i = 1; i < 5; i++)
                    {
                        for (int j = 0; j < 1 + 2*i; j++)
                        {
                            if (_x - i > -1 && _x - i < Console.BufferWidth && _y - j + i > -1 && _y - j + i < Console.BufferHeight)
                            {
                                Console.SetCursorPosition(_x - i, _y - j + i);
                                Console.BackgroundColor = ConsoleColor.Yellow;
                                Console.Write(" ");
                                VisionCoordinates[VisionCoordinateTracker, 0] = _x - i;
                                VisionCoordinates[VisionCoordinateTracker, 1] = _y - j + i;
                                VisionCoordinateTracker++;
                            }
                        }
                    }
                    break;
                case DevHelper.Right:
                    for (int i = 1; i < 5; i++)
                    {
                        for (int j = 0; j < 1 + 2*i; j++)
                        {
                            if (_x + i > -1 && _x + i < Console.BufferWidth && _y - j + i > -1 && _y - j + i < Console.BufferHeight)
                            {
                                Console.SetCursorPosition(_x + i, _y - j + i);
                                Console.BackgroundColor = ConsoleColor.Yellow;
                                Console.Write(" ");
                                VisionCoordinates[VisionCoordinateTracker, 0] = _x + i;
                                VisionCoordinates[VisionCoordinateTracker, 1] = _y - j + i;
                                VisionCoordinateTracker++;
                            }
                        }
                    }
                    break;
            }
            Console.BackgroundColor = ConsoleColor.Black;
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
            Console.SetCursorPosition(_x,_y);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(' ');
        }

        public void DrawHero(int x, int y)
        {
            _y = y;
            _x = x;
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
                        Gun.Shoot(_x, _y, LookDirection);
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
                        Gun.Shoot(_x, _y, LookDirection);
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
                        Gun.Shoot(_x, _y, LookDirection);
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
                        Gun.Shoot(_x, _y, LookDirection);
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
                    if (_y - 1 >= 0 && _y - 1 < Console.BufferHeight)
                    {
                        EraseHero();
                        DrawHero(_x, _y-1);
                    }
                    break;
                case DevHelper.Down:
                    if (_y+1 >= 0 && _y+1 < Console.BufferHeight)
                    {
                        EraseHero();
                        DrawHero(_x, _y + 1);
                    }
                    break;
                case DevHelper.Left:
                    if (_x - 1 >= 0 && _x - 1 < Console.BufferWidth)
                    {
                        EraseHero();
                        DrawHero(_x - 1, _y);
                    }
                    break;
                case DevHelper.Right:
                    if (_x + 1 >= 0 && _x + 1 < Console.BufferWidth)
                    {
                        EraseHero();
                        DrawHero(_x + 1, _y);
                    }
                    break;
            }
        }
    }
}