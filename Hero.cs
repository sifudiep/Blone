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
        public int[,] VisionCoordinates = new int[25,2];

        public Hero()
        {
            _x = Console.WindowWidth/2;
            _y = Console.WindowHeight/2;
            DrawHero(_x, _y);
        }
        public void Spawn(int x, int y)
        {
            _x = x;
            _y = y;
            DrawHero(_x,_y);
        }

        public void UpdateVision(string direction)
        {
            var VisionCoordinateTracker = 0;
            switch (direction)
            {
                case DevHelper.DIRECTION_UP:
                    for (int i = 1; i < 5; i++)
                    {
                        for (int j = 0; j < 1 + 2*i; j++)
                        {
                            Console.SetCursorPosition(_x - j + i, _y - i);
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.Write(" ");
                            VisionCoordinates[VisionCoordinateTracker, 0] = (_x - j + i);
                            VisionCoordinates[VisionCoordinateTracker, 1] = (_y - i);
                            VisionCoordinateTracker++;
                        }
                    }
                    break;
                case DevHelper.DIRECTION_DOWN:
                    for (int i = 1; i < 5; i++)
                    {
                        for (int j = _x; j < ((_x+1)+(2*i)); j++)
                        {
                            Console.SetCursorPosition(j-i, i+_y);
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.Write(" ");
                            VisionCoordinates[VisionCoordinateTracker, 0] = j - i;
                            VisionCoordinates[VisionCoordinateTracker, 1] = i+_y;
                            VisionCoordinateTracker++;
                        }
                    }
                    break;
                case DevHelper.DIRECTION_LEFT:
                    for (int i = 5; i < 5; i++)
                    {
                        for (int j = 0; j < 1 + 2*i; j++)
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.Write(" ");
                        }
                    }
                    break;
                case DevHelper.DIRECTION_RIGHT:
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
                case DevHelper.DIRECTION_UP:
                    if (LookDirection == DevHelper.DIRECTION_UP)
                    {
                        Console.WriteLine("SHOOT");
                    }
                    else
                    {
                        LookDirection = DevHelper.DIRECTION_UP;
                        EraseVision();
                        UpdateVision(LookDirection);                        
                    }
                    break;
                case DevHelper.DIRECTION_DOWN:
                    if (LookDirection == DevHelper.DIRECTION_DOWN)
                    {
                        Console.WriteLine("SHOOT");
                    }
                    else
                    {
                        LookDirection = DevHelper.DIRECTION_DOWN;
                        EraseVision();
                        UpdateVision(LookDirection);       
                    }
                    break;
                case DevHelper.DIRECTION_LEFT:
                    if (LookDirection == DevHelper.DIRECTION_LEFT)
                    {
                        Console.WriteLine("SHOOT");
                    }
                    else
                    {
                        LookDirection = DevHelper.DIRECTION_LEFT;        
                        EraseVision();
                        UpdateVision(LookDirection);       
                    }
                    break;
                case DevHelper.DIRECTION_RIGHT:
                    if (LookDirection == DevHelper.DIRECTION_RIGHT)
                    {
                        Console.WriteLine("SHOOT");
                    }
                    else
                    {
                        LookDirection = DevHelper.DIRECTION_RIGHT;   
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
                case DevHelper.DIRECTION_UP:
                    EraseHero();
                    DrawHero(_x, _y-1);
                    break;
                case DevHelper.DIRECTION_DOWN:
                    EraseHero();
                    DrawHero(_x, _y+1);
                    break;
                case DevHelper.DIRECTION_LEFT:
                    EraseHero();
                    DrawHero(_x-1, _y);
                    break;
                case DevHelper.DIRECTION_RIGHT:
                    EraseHero();
                    DrawHero(_x+1, _y);
                    break;
            }
        }
    }
}